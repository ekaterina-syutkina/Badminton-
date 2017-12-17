using System;

using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class Form1 : Form
    {
        FileStream _fs;

        public string ConfigPath = Directory.GetCurrentDirectory() + "\\badm.cfg";
        struct Record //запись спортсмена
        {
            //Год/р	Разряд	Регион	Рейтинг	Личные	Команд
            public uint Number;
            public string Name;
            public uint BirthYear;
            public string Qualification;
            public string Region;
            public uint Rating;
            public char Change;
            public uint Personal;
            public uint Team;
            public string hash;
        } 

        struct Competition // запись события
        {
            public string Date;
            public string Name;
            public string Place;
            public int Intl;
        }
        Competition[] competitions;

        struct Info
        {
           // public string hash;
            public string name;
            public int year;
            public string qualification;
            public string date;
            public int points;
            public string included;
        }
        Info[] days;

        struct Post
        {
            public string author;
            public DateTime date;
            public string heading;
            public string text;
            public uint id;
        }
        Post[] posts;
        struct Arg2
        {
            public Info[] data;
            public string table;
        }
        [Serializable]
        struct MySqlSettings //настройки MySQL
        {
            public string Address;
            public string BaseN;
            public string Login;
            public string Password;
        }
        MySqlSettings CurrentSettings;
        void AddLogMessage(string msg) //добавление сообщения в лог: пометка даты/времени, сообщение, прокрутка к последнему
        {
            msg =
                $"[{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}  {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {msg}\n";
            logBox.Text += msg;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
        
        uint GetLength(ref Excel.Worksheet excelworksheet) //считываем число записей
        {
            uint length = 0;
            for (int i = 7; i < 10000; i++)
            {
                Excel.Range excelcells = excelworksheet.get_Range($"A{i}", Type.Missing);
                if (excelcells.Value2 == null||excelcells.Value2.ToString()=="") { break; } //добрались до конца => вышли
                length++;
            }
            return length;
        }

        Record[] Parse(DataRow dr, OleDbCommand cmd, ref Excel.Worksheet wrkSheet) //парсинг
        {
            DataSet ds = new DataSet();
            string sheetName = dr["TABLE_NAME"].ToString();
            Console.WriteLine(sheetName);
            // Get all rows from the Sheet
            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
            DataTable dt = new DataTable();
            dt.TableName = sheetName;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            ds.Tables.Add(dt);

            DataRowCollection rows = ds.Tables[0].Rows;
            cmd = null;
            int length = 5;
            do
            {
                if (rows[length][0] is DBNull) break;
                length++;
            } while (true); // получаем длину
            Record[] result = new Record[length - 5];

            for (int i = 5; i < length; i++)//строки
            {
                result[i - 5].Number = Convert.ToUInt32(rows[i][0]);
                result[i - 5].Name = rows[i][1].ToString();
                try
                {
                    result[i - 5].BirthYear = Convert.ToUInt32(rows[i][2]);
                }
                catch
                {
                    result[i - 5].BirthYear = 0;
                }
                
                result[i - 5].Qualification = rows[i][3].ToString();
                result[i - 5].Region = rows[i][4].ToString();
                result[i - 5].Rating = Convert.ToUInt32(rows[i][5]);
                result[i - 5].Personal = Convert.ToUInt32(rows[i][6]);
                result[i - 5].Team = Convert.ToUInt32(rows[i][7]);

                if (wrkSheet.Cells[i + 2, 6].Font.Color.ToString() == "255") //красный -- рост
                {
                    result[i - 5].Change = '-'; 
                }
                if (wrkSheet.Cells[i + 2, 6].Font.Color.ToString() == "65280") //не рост
                {
                    result[i - 5].Change = '+';
                }
            }
            
            return result;
        }

        Info[] ParseNakop(DataRow dr, OleDbCommand cmd, ref Excel.Worksheet wrkSheet)
        {
            DataSet ds = new DataSet();
            string sheetName = dr["TABLE_NAME"].ToString();
            Console.WriteLine(sheetName);
            // Get all rows from the Sheet
            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
            DataTable dt = new DataTable();
            dt.TableName = sheetName;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            ds.Tables.Add(dt);
            DataRowCollection rows = ds.Tables[0].Rows; //получил все строки таблицы
            cmd = null;

            int g = 0; //ширина
            Info[] days = new Info[1];

            for (int i = 7; i < 500; i++) //считаем количество дней
            {
                string date = (string)wrkSheet.Cells[2, i].Value.ToString();
                date = date.Substring(0, 10);
                DateTime thisDate = Convert.ToDateTime(date);
                if ((DateTime.Now - thisDate).Days > 365)
                {
                    g = i; break; //запоминаем докуда считать по горизонтали
                }
            }

            int index = 0;
            int depth = 0; //глубина
            do
            {
                try
                {
                    if (rows[depth][0] is DBNull) break;
                    depth++;
                }
                catch
                {
                    break;
                }
                
            } while (true);

            //for (int i = 0; i < depth; i++)
            for (int i = 1; i < depth; i++)
            {
                if (rows[i][5].ToString() != "0") //если рейтинг !=0
                {

                    int delta = 4; //4 сорев назад проверка
                    string name = rows[i][0].ToString();
                    int year = 0;
                    try
                    {
                        year = Convert.ToInt32(rows[i][1]);
                    }
                    catch { };
                    
                    string qual = rows[i][2].ToString();

                    for (int j = 6; j <= g; j++)
                    {

                        if (!(rows[i][j] is DBNull))
                        {
                            string prev = "";
                            int cur;
                            cur = 0;
                            prev = wrkSheet.Cells[2, j+1].Value.ToString("dd.MM.yyyy");
                            int c = 0;
                            if (j+1 - delta < 7) c = 7;
                            else c = j+1 - delta;
                            while (c <= j+1)
                            {
                                if (prev == wrkSheet.Cells[2, c].Value.ToString("dd.MM.yyyy"))
                                    cur++;
                                else
                                {
                                    prev = wrkSheet.Cells[2, c].Value.ToString("dd.MM.yyyy");
                                    cur = 1;
                                }
                                c++;
                            }
                            Array.Resize(ref days, days.Length + 1);
                            days[index].name = name;
                            days[index].year = year;
                            days[index].qualification = qual;
                            days[index].date = wrkSheet.Cells[2, j+1].Value.ToString("dd.MM.yyyy") + $"/{cur}";
                            if (wrkSheet.Cells[i+3, j+1].Interior.Color != 16777215)
                            {
                                days[index].included = "+";
                            }
                            else
                            {
                                days[index].included = "-";
                            }
                            days[index].points = Convert.ToInt32(rows[i][j]);
                            index++;
                        }
                    }
                }
            }
            return days;
        }

        bool CheckSql() //проверка подключения к бд
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string connect =
                    $"Database={baseName.Text};Data Source={addressSQL.Text};User Id={loginSQL.Text};Password={passwordSQL.Text}";
                MySqlConnection myConnection = new MySqlConnection(connect);

                myConnection.Open(); //Устанавливаем соединение с базой данных.
                myConnection.Close();
                statusLabel.Text = "Статус: Данные БД верны";
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex) //при возникновении ошибки
            {
                Cursor = Cursors.Arrow;
                statusLabel.Text = "Статус: Данные БД не верны";
                MessageBox.Show(this, "Ошибка подключения к БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        void SendToBase(Competition[] competitions)
        {
            try
            {
                string connect =
                    $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                MySqlConnection myConnection = new MySqlConnection(connect); 
                myConnection.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand myCommand = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE Competition; SET FOREIGN_KEY_CHECKS = 1; ", myConnection); //очистка таблицы перед отгрузкой
                myCommand.ExecuteNonQuery();
                
                int i = 1;

                backgroundWorker2.ReportProgress(1);

                foreach (var r in competitions)
                {
                    string commandText = "";
                    
                    if (r.Intl == 1)
                        commandText = //создаем строку запроса INSERT
                            $"INSERT INTO `Competition` (`Date`,`Name`,`Location`,`Intl`) VALUES ('{r.Date}', '{"<span class=\"label label-success\">Международные</span> "+r.Name}','{r.Place}',{r.Intl});";
                    else
                        commandText = //создаем строку запроса INSERT
                            $"INSERT INTO `Competition` (`Date`,`Name`,`Location`,`Intl`) VALUES ('{r.Date}', '{"<span class=\"label label-primary\">Всероссийские</span> " + r.Name}','{r.Place}',{r.Intl});";


                    myCommand = new MySqlCommand(commandText, myConnection); //создание команды
                    myCommand.ExecuteNonQuery(); //исполнение команды
                    i++;
                    backgroundWorker2.ReportProgress(Convert.ToInt32(((double)i / competitions.Length) * 100));//обновление прогрессбара
                }

                myConnection.Close(); //закрытие соединения
        }
            catch (Exception ex)//если что-то пошло не так, уведомляем
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
        void SendToBase(Record[] records, string table) //отгрузка файла в БД 
        {
            try
            {
                string connect =
                    $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                MySqlConnection myConnection = new MySqlConnection(connect); //
                myConnection.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand myCommand = new MySqlCommand($"SET FOREIGN_KEY_CHECKS = 0;  TRUNCATE TABLE {table};  SET FOREIGN_KEY_CHECKS = 1; ", myConnection); //очистка таблицы перед отгрузкой
               // MySqlCommand myCommand = new MySqlCommand("SET NAMES utf8 " + table, myConnection);
                myCommand.ExecuteNonQuery();
                
                int i = 0;

                backgroundWorker1.ReportProgress(1);

                foreach (var r in records)
                {
                        string commandText = //создаем строку запроса INSERT
                            $"INSERT INTO `{table}` (`Number`,`Name`,`BirthYear`,`Qualification`,`Region`,`Rating`,`Change`,`Personal`,`Team`,`hash`) VALUES ({r.Number},'{r.Name}', {r.BirthYear},'{r.Qualification}', '{r.Region}',{r.Rating},'{r.Change}',{r.Personal},{r.Team},'{r.hash}');";
                        myCommand = new MySqlCommand(commandText, myConnection); //создание команды
                        myCommand.ExecuteNonQuery(); //исполнение команды
                        i++;
                        backgroundWorker1.ReportProgress(Convert.ToInt32(((double)i / records.Length) * 100));//обновление прогрессбара
                }
                               
                myConnection.Close(); //закрытие соединения
            }
            catch (Exception ex)//если что-то пошло не так, уведомляем
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        void SendToBase(Info[] records, string table) //отгрузка файла в БД 
        {
            try
            {
                string connect =
                    $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                MySqlConnection myConnection = new MySqlConnection(connect); //
                myConnection.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand myCommand = new MySqlCommand($"SET FOREIGN_KEY_CHECKS = 0;  TRUNCATE TABLE {table};SET FOREIGN_KEY_CHECKS = 1; ", myConnection); //очистка таблицы перед отгрузкой
                myCommand.ExecuteNonQuery();

                backgroundWorker3.ReportProgress(1);
                int i = 0;
                foreach (var r in records)
                {
                    string commandText = //создаем строку запроса INSERT
                        $"INSERT INTO `{table}` (`Name`, `BirthYear`,`Qualification`, `date`,`points`,`included`) VALUES ('{r.name}',{r.year},'{r.qualification}','{r.date}',{r.points},'{r.included}');";
                    myCommand = new MySqlCommand(commandText, myConnection); //создание команды
                    myCommand.ExecuteNonQuery(); //исполнение команды
                    i++;
                    backgroundWorker3.ReportProgress(Convert.ToInt32(((double)i / records.Length) * 100));//обновление прогрессбара
                }

                myConnection.Close(); //закрытие соединения
            }
            catch (Exception ex)//если что-то пошло не так, уведомляем
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
        struct Arg
        {
           public Record[] data;
           public string table;
        }
        private Excel.Application excelapp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ratingFilePath.Text == "")
            {
                AddLogMessage("Не выбран файл рейтинга! Рейтинг не будет отгружен!");
               // return;
            }
           if (collectFilePath.Text == "")
            {
                AddLogMessage("Не выбран файл-накопитель! Накопленные очки не будут отгружены!");
                //return;
            }
            if (competitionFilePath.Text == "")
            {
                AddLogMessage("Не выбран файл с соревнованиями! Список соревнований не будет отгружен!");
                //return;
            }
            this.Enabled = false;
            //объявление имён
            excelapp = new Excel.Application();
            Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
            Excel.Sheets excelsheets;
            Excel.Worksheet excelworksheet;
            Excel._Workbook excelappworkbook;

            //ОБРАБОТКА ФАЙЛА РЕЙТИНГА
            if (ratingFilePath.Text != "")
            {
                string ratingFileName = ratingFilePath.Text;
                    //Открываем книгу и получаем на нее ссылку
                    excelappworkbook = excelapp.Workbooks.Open(ratingFileName,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing
                 );
                excelsheets = excelappworkbook.Worksheets;

                OleDbConnection theConnection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ratingFileName};Extended Properties=\"Excel 8.0;HDR=YES;\"");
                theConnection.Open();
                DataSet ds = new DataSet();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = theConnection;
                // Get all Sheets in Excel File
                DataTable dtSheet = theConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                // Loop through all Sheets to get data

                    //Получаем ссылку на лист ЖО
                    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                AddLogMessage("Обработка файла рейтинга");
                Arg a;
                a.data = Parse(dtSheet.Rows[0], cmd, ref excelworksheet); a.table = "jo";
                Application.DoEvents();
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка завершена");

                //Получаем ссылку на лист ЖП
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);

                a.data = Parse(dtSheet.Rows[1], cmd, ref excelworksheet); a.table = "jp";
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка завершена");

                //Получаем ссылку на лист ЖС
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(3);

                a.data = Parse(dtSheet.Rows[2], cmd, ref excelworksheet); a.table = "js";
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка завершена");

                //Получаем ссылку на лист МО
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(4);

                a.data = Parse(dtSheet.Rows[3], cmd, ref excelworksheet); a.table = "mo";
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка завершена");

                //Получаем ссылку на лист МП
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(5);

                a.data = Parse(dtSheet.Rows[4], cmd, ref excelworksheet); a.table = "mp";
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка завершена");
                //Получаем ссылку на лист МС
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(6);

                a.data = Parse(dtSheet.Rows[5], cmd, ref excelworksheet); a.table = "ms";
                AddLogMessage($"Лист {a.table} отправляется.");
                this.backgroundWorker1.RunWorkerAsync(a);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker1.IsBusy);
                AddLogMessage($"Отправка рейтинга завершена");
            }
            //ОБРАБОТКА СОРЕВНОВАНИЙ
            if (competitionFilePath.Text != "")
            {
                excelappworkbooks = excelapp.Workbooks;
                string competitionFileName = competitionFilePath.Text;

                //Открываем книгу и получаем на нее ссылку
                excelappworkbook = excelapp.Workbooks.Open(competitionFileName,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing
                 );
                excelsheets = excelappworkbook.Worksheets;
                AddLogMessage("Обработка файла соревнований");
                //Получаем ссылку на лист
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                uint l = GetLength(ref excelworksheet) + 7;
                competitions = new Competition[l];
                string prev = DateTime.Now.ToString("dd.MM.yyyy"); //храним предыдущую датувремя
                int cur = 1;
                for (uint i = l-1; i >= 1; i--)
                {
                    
                    for (char j = 'A'; j <= 'C'; j++)
                    {
                        Excel.Range cell = excelworksheet.get_Range($"{j}{i}", Type.Missing);
                        switch (j)
                        {
                            case 'A':
                                if (cell.Font.Color.ToString() != "0") competitions[i - 1].Intl = 1;
                                else competitions[i - 1].Intl = 0;
                                if (DateTime.FromOADate(Convert.ToDouble(cell.Value2)).ToString("dd.MM.yyyy") != prev)
                                {
                                    competitions[i - 1].Date = DateTime.FromOADate(Convert.ToDouble(cell.Value2)).ToString("dd.MM.yyyy")+$"/1";
                                    prev = DateTime.FromOADate(Convert.ToDouble(cell.Value2)).ToString("dd.MM.yyyy");
                                    cur= 1;
                                }
                                else
                                {
                                    cur++;
                                    competitions[i - 1].Date = DateTime.FromOADate(Convert.ToDouble(cell.Value2)).ToString("dd.MM.yyyy") + $"/{cur}";
                                    prev = DateTime.FromOADate(Convert.ToDouble(cell.Value2)).ToString("dd.MM.yyyy");
                                    
                                }
                                break;
                            case 'B':
                                competitions[i - 1].Name = cell.Value2.ToString();
                                break;
                            case 'C':
                                if (cell.Value2 != null)
                                    competitions[i - 1].Place = cell.Value2.ToString();
                                else
                                    competitions[i - 1].Place = "";
                                break;
                            default:
                                break;
                        }

                    }
                }
                AddLogMessage("Отправка файла соревнований в БД");
                backgroundWorker2.RunWorkerAsync(competitions); //подали на отправку
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker2.IsBusy);

            }
            //ОБРАБОТКА НАКОПИТЕЛЯ
            if (collectFilePath.Text != "")
            {

                excelappworkbooks = excelapp.Workbooks;
                string collectFileName = collectFilePath.Text;

                //Открываем книгу и получаем на нее ссылку
                excelappworkbook = excelapp.Workbooks.Open(collectFileName,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing
                 );
                excelsheets = excelappworkbook.Worksheets;

                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);//jo

                OleDbConnection theConnection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={collectFileName};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
                theConnection.Open();
                DataSet ds = new DataSet();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = theConnection;
                // Get all Sheets in Excel File
                DataTable dtSheet = theConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                // Loop through all Sheets to get data
                Arg2 intoWorker;
                AddLogMessage("Обработка накопителя ЖО (1/6)");
                intoWorker.data = ParseNakop(dtSheet.Rows[0], cmd, ref excelworksheet); intoWorker.table = "jo_participated";
                AddLogMessage("Отправка в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);

                ////2
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);
                AddLogMessage("Обработка накопителя ЖП (2/6)");

                intoWorker.data = ParseNakop(dtSheet.Rows[1], cmd, ref excelworksheet); intoWorker.table = "jp_participated";
                AddLogMessage("Начинаю отгрузку в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);

                ////3
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(3);
                AddLogMessage("Обработка накопителя ЖС (3/6)");
                intoWorker.data = ParseNakop(dtSheet.Rows[2], cmd, ref excelworksheet); intoWorker.table = "js_participated";
                AddLogMessage("Начинаю отгрузку в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);

                //4
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(4);
                AddLogMessage("Обработка накопителя МО (4/6)");

                intoWorker.data = ParseNakop(dtSheet.Rows[3], cmd, ref excelworksheet); intoWorker.table = "mo_participated";

                AddLogMessage("Начинаю отгрузку в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);

                //5
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(5);
                AddLogMessage("Обработка накопителя МП (5/6)");

                intoWorker.data = ParseNakop(dtSheet.Rows[4], cmd, ref excelworksheet); intoWorker.table = "mp_participated";
                AddLogMessage("Начинаю отгрузку в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);

                //6

                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(6);


                AddLogMessage("Обработка накопителя МС (6/6)");
                intoWorker.data = ParseNakop(dtSheet.Rows[5], cmd, ref excelworksheet); intoWorker.table = "ms_participated";
                AddLogMessage("Начинаю отгрузку в базу");
                backgroundWorker3.RunWorkerAsync(intoWorker);
                do
                {
                    Application.DoEvents();
                } while (backgroundWorker3.IsBusy);
            }

            excelapp.Quit();
            this.Enabled = true;
            AddLogMessage("Все отгрузки завершены.");
            progressBar1.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            bool ifExist = File.Exists(ConfigPath); //существует ли конфиг?
            if (ifExist == false) //если конфиг не найден, создаем, переходим на вкладку
            {
                startButton.Enabled = false;
                applyDate.Enabled = false;
                tabControl1.SelectTab(2); //активация панели настроек
                postsBox.Enabled = false;
                submitButton.Enabled = false;
            }
            else
            {
                try
                {
                    _fs = new FileStream(ConfigPath, FileMode.Open);
                    SoapFormatter sr = new SoapFormatter();
                    CurrentSettings = (MySqlSettings)sr.Deserialize(_fs);
                    addressSQL.Text = CurrentSettings.Address;
                    baseName.Text = CurrentSettings.BaseN;
                    loginSQL.Text = CurrentSettings.Login;
                    passwordSQL.Text = CurrentSettings.Password;
                    AddLogMessage("Настройки загружены");
                    if (CheckSql())
                    {
                        startButton.Enabled = true;
                        applyDate.Enabled = true;
                    }
                    else
                    {
                        AddLogMessage("Неверные настройки БД");
                        startButton.Enabled = false;
                        applyDate.Enabled = false;
                    }
                }
                catch
                {
                    startButton.Enabled = false;
                    applyDate.Enabled = false;
                    AddLogMessage("Ошибка загрузки настроек: укажите новые");
                }
                _fs.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkConnect_Click(object sender, EventArgs e)
        {
            CheckSql();
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = " Книги Excel(*.xlsx)|*.xlsx| Таблицы Excel(*.xls)|*.xls| All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ratingFilePath.Text = openFileDialog1.FileName;
            }
            return;
        }

        private void excelFilePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = " Книги Excel(*.xlsx)|*.xlsx| Таблицы Excel(*.xls)|*.xls| All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ratingFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CheckSql())
            {
                _fs = new FileStream(ConfigPath, FileMode.Create);
                SoapFormatter sr = new SoapFormatter();
                CurrentSettings.Address = addressSQL.Text;
                CurrentSettings.BaseN = baseName.Text;
                CurrentSettings.Login = loginSQL.Text;
                CurrentSettings.Password = passwordSQL.Text;
                sr.Serialize(_fs, CurrentSettings);
                statusLabel.Text = "Статус: Готов к работе";
                AddLogMessage("Настройки сохранены и применены, готов к работе!");
                startButton.Enabled = true;
                applyDate.Enabled = true;
                _fs.Close();
                postsBox.Enabled = true;
                submitButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
                applyDate.Enabled = false;
                statusLabel.Text = "Статус: настройки не сохранены";
                postsBox.Enabled = false;
                submitButton.Enabled = false;
                return;
            }

        }

       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
           Arg a = (Arg)e.Argument;
           SendToBase(a.data, a.table);
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void selectCompetitionFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = " Таблицы Excel(*.xls)|*.xls| Книги Excel(*.xlsx)|*.xlsx| All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                competitionFilePath.Text = openFileDialog1.FileName;
            }
            return;
        }

        private void selectCollectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = " Таблицы Excel(*.xls)|*.xls| Книги Excel(*.xlsx)|*.xlsx| All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                collectFilePath.Text = openFileDialog1.FileName;
            }
            return;
        }

        private void ratingFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(0);
            SendToBase((Competition[])e.Argument);
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker3.ReportProgress(0);
            Arg2 a = (Arg2)e.Argument;
            SendToBase(a.data, a.table);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage<100)
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage < 100)
                progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            AddLogMessage("Отправляю дату");
            string connect =
                    $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
            MySqlConnection myConnection = new MySqlConnection(connect); //
            myConnection.Open(); //Устанавливаем соединение с базой данных.
            MySqlCommand myCommand = new MySqlCommand($"SET FOREIGN_KEY_CHECKS = 0;  TRUNCATE TABLE info; SET FOREIGN_KEY_CHECKS = 1; ", myConnection); //очистка таблицы перед отгрузкой
            myCommand.ExecuteNonQuery();
            myCommand = new MySqlCommand($"INSERT INTO info (date) VALUES ('{dateTimePicker1.Value.ToString("dd.MM.yyyy")}');", myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            AddLogMessage("Отправлено.");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (postsBox.SelectedIndex == -1) return;
            submitButton.Text = "Изменить";
            authorBox.Text = posts[postsBox.SelectedIndex].author;
            headingBox.Text = posts[postsBox.SelectedIndex].heading;
            postText.InnerHtml = posts[postsBox.SelectedIndex].text;
            datePick.Value = posts[postsBox.SelectedIndex].date;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {


                posts = null;

                for (int i = postsBox.Items.Count - 1; i >= 0; i--)
                {
                    postsBox.Items.Remove(postsBox.Items[i]);
                }
                string connect =
                        $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                MySqlConnection myConnection = new MySqlConnection(connect);

                myConnection.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand myCommand = new MySqlCommand(
                    "SELECT * FROM posts",
                    myConnection
                    );
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                DataRow[] myData = dt.Select();
                posts = new Post[myData.Length];
                for (int i = 0; i < myData.Length; i++)
                {
                    posts[i].author = myData[i].ItemArray[0].ToString();
                    posts[i].date = Convert.ToDateTime(myData[i].ItemArray[1]);
                    posts[i].heading = myData[i].ItemArray[2].ToString();
                    posts[i].text = myData[i].ItemArray[3].ToString();
                    posts[i].id = Convert.ToUInt32(myData[i].ItemArray[4]);
                    postsBox.Items.Add($"{posts[i].date} - {posts[i].heading}");
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ошибка", ex.Message);
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }
        private void selectButton_Click(object sender, EventArgs e)
        {
            submitButton.Text = "Опубликовать";
            postsBox.SelectedIndex = -1;
            authorBox.Text = ""; datePick.Value = DateTime.Now;
            postText.InnerHtml = ""; headingBox.Text = "";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (authorBox.Text == "") {
                MessageBox.Show(this, "Не указан автор записи", "Ошибка публикации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; }
            if (headingBox.Text == "") {
                MessageBox.Show(this, "Не указан заголовок записи", "Ошибка публикации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; }
            if (postText.InnerHtml == "") {
                MessageBox.Show(this, "Не указан текст записи", "Ошибка публикации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; }
            try
            {


                if (postsBox.SelectedIndex == -1)
                {
                    string connect =
                        $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                    MySqlConnection myConnection = new MySqlConnection(connect);

                    myConnection.Open(); //Устанавливаем соединение с базой данных.
                    MySqlCommand myCommand = new MySqlCommand(
                        $"INSERT INTO `posts` (`author`, `date`, `heading`, `text`) VALUES ('{authorBox.Text}', '{datePick.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{headingBox.Text}', '{postText.InnerHtml}')",
                        myConnection
                        );
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show(this, "Запись опубликована!", "Публикация", MessageBoxButtons.OK, MessageBoxIcon.None);
                    comboBox1_Click(sender, e);
                    postsBox.SelectedIndex = posts.Length - 1;
                }
                else
                {
                    string connect =
                        $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
                    MySqlConnection myConnection = new MySqlConnection(connect);

                    myConnection.Open(); //Устанавливаем соединение с базой данных.

                    MySqlCommand myCommand = new MySqlCommand(
                        $"DELETE FROM posts WHERE id = {posts[postsBox.SelectedIndex].id}",
                        myConnection
                        );
                    myCommand.ExecuteNonQuery();

                    myCommand = new MySqlCommand(
                        $"INSERT INTO `posts` (`author`, `date`, `heading`, `text`) VALUES ('{authorBox.Text}', '{datePick.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{headingBox.Text}', '{postText.InnerHtml}')",
                        myConnection
                        );
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show(this, "Запись изменена!", "Публикация", MessageBoxButtons.OK, MessageBoxIcon.None);
                    selectButton_Click(sender, e);
                    comboBox1_Click(sender, e);
                }

            }
            catch
            {
                
                MessageBox.Show(this, "Неизвестная ошибка", "Ошибка публикации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connect =
                        $"Database={CurrentSettings.BaseN};Data Source={CurrentSettings.Address};User Id={CurrentSettings.Login};Password={CurrentSettings.Password}; Charset=utf8";
            MySqlConnection myConnection = new MySqlConnection(connect);

            myConnection.Open(); //Устанавливаем соединение с базой данных.

                MySqlCommand myCommand = new MySqlCommand(
                    $"DELETE FROM posts WHERE id = {posts[postsBox.SelectedIndex].id}",
                    myConnection
                    );
                myCommand.ExecuteNonQuery();
                comboBox1_Click(sender, e);
                postsBox.SelectedIndex = -1;
                authorBox.Text = ""; datePick.Value = DateTime.Now;
                postText.InnerHtml = ""; headingBox.Text = "";
                myConnection.Close();
            }
            catch {
                MessageBox.Show(this, "Неизвестная ошибка", "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
