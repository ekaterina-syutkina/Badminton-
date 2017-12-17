<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Рейтинг НФБР DEV</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
  </head>
<body>
<div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <a class="navbar-brand" href="/dev">Рейтинг НФБР</a>		  
        </div>
		<div class="navbar-brand navbar-right">
		<?php
                            $sdd_db_host='localhost'; // ваш хост
                            $sdd_db_name='volkovsema_dev'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд
                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `info`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								echo "Обновлено: ".$row['date'];
                            }
                    ?>
		
		</div>
      </div>
	  
    </div>
    <br>
    <br>
    <br>
    <div class="container-fluid">
        <div class="row-fluid">
		<!--ТАБЫ-->
            <div class="col-md-2"> 
                <ul class="nav nav-pills nav-stacked" role="tablist" id="mainMenu">
                    <li class="active"><a href="/#main" class="active"><i class="glyphicon glyphicon-arrow-left"></i> Главная</a></li>
                </ul>
            </div>
            <!--//ТАБЫ-->
            <div class="col-md-10">
                <h2 id="pageHeading">Подробная информация о спортсмене</h2>
					<div class="well">
						<?php
						if(isset($_GET['name'])){
                            //info.php?name=Косецкая+Евгения&year=1994&qual=мсмк
                                $name = urldecode($_GET['name']);
								$year = $_GET['year'];
								$qual = urldecode($_GET['qual']);
								$cat = $_GET['cat'];
                            }
								$cat_name = array(
									jo=>"Женский одиночный",
									jp=>"Женский парный",
									js=>"Смешанный (женщины)",
									mo=>"Мужской одиночный",
									mp=>"Мужской парный",
									ms=>"Смешанный (мужчины)",
									
								);
                                $sdd_db_host='localhost'; // ваш хост
                                $sdd_db_name='volkovsema_dev'; // ваша бд
                                $sdd_db_user='volkovsema_user'; // пользователь бд
                                $sdd_db_pass='1q2w3e'; // пароль к бд
                                @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                                @mysql_set_charset('utf8');
                                @mysql_select_db($sdd_db_name); // выбор бд
								
                                $result=mysql_query("
								SELECT *
								FROM ".$cat." WHERE ".$cat.".Name='".$name."' AND ".$cat.".BirthYear=".$year." AND ".$cat.".Qualification='".$qual."'"); // запрос на выборку
                                while($row=mysql_fetch_array($result))
                                {
                                echo "<b>Имя, год рождения, разряд, регион: </b>".$row['Name'].", ".$row['BirthYear'].", ".$row['Qualification'].", ".$row['Region']."<br>".
								"<b>Рейтинг, личные очки, командные очки: </b>".$row['Rating'].", ".$row['Personal'].", ".$row['Team']."<br>".
								"<b>Текущая позиция в ".$cat_name[$cat].": ".$row['Number']."</b>";	
                                }
                            ?>
					</div>
                    <div class="well">
                <table id="infoTable" class="display table  table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th>Дата</th>
                            <th>Название</th>
							<th>Очки</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            if(isset($_GET['name'])){
                            //info.php?name=Косецкая+Евгения&year=1994&qual=мсмк
                                $name = urldecode($_GET['name']);
								$year = $_GET['year'];
								$qual = urldecode($_GET['qual']);
								$cat = $_GET['cat'];
								$debug = $_GET['debug'];
                            }
                                $sdd_db_host='localhost'; // ваш хост
                                $sdd_db_name='volkovsema_dev'; // ваша бд
                                $sdd_db_user='volkovsema_user'; // пользователь бд
                                $sdd_db_pass='1q2w3e'; // пароль к бд
                                @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                                @mysql_set_charset('utf8');
                                @mysql_select_db($sdd_db_name); // выбор бд]
								
								$q = "
                                SELECT ".$cat."_participated.date, Competition.name, ".$cat."_participated.points, ".$cat."_participated.included
                                    FROM ".$cat."_participated, ".$cat.", Competition
                                WHERE ".$cat.".Name = '".$name."' AND
								".$cat.".BirthYear = ".$year." AND
								".$cat.".Qualification = '".$qual."' AND
								".$cat.".name = ".$cat."_participated.name AND
								Competition.date = ".$cat."_participated.date
                                "; // запрос на выборку GROUP BY ".$cat."_participated.date
								
///============ДЕБУГ
								if($debug=="yes")									
								echo $q;
//===========!ДЕБУГ								
                                $result=mysql_query($q);

								while($row=mysql_fetch_array($result))
                                {
									$class = '<tr><td>';
									if($row['included'] == '+'){
										$class='<tr class = "success"><td>';
									}
									
                                echo 
							
                                $class.substr($row['date'],0,10).'</td><td>'.$row['name'].'</td><td>'.$row['points'].'</td></tr>';
                                }
                            ?>
                    </tbody>
                </table>
                </div><!--/well-->	
				
				<div class="panel panel-info">
				  <div class="panel-heading">Легенда</div>
				  <div class="panel-body">
					<p>
					<ul>
						<li><span class="label label-success">Международные</span> - соревнования являются международными </li>
						<li><span class="label label-primary">Всероссийские</span> - соревнования являются всероссийскими </li>
						<li>Строка выделена зелёным — соревнования идут в расчёт рейтинга</li>
					</ul>
					</p>
					</div>
			</div>
    <hr>
</div>
</div> <!-- /container -->
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <!--DataTables OLD-->
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs/dt-1.10.15/r-2.1.1/sc-1.4.2/datatables.min.css"/>
 
<script type="text/javascript" src="https://cdn.datatables.net/v/bs/dt-1.10.15/r-2.1.1/sc-1.4.2/datatables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/plug-ins/1.10.15/sorting/date-de.js"></script>




    
    <script type="text/javascript">

        $(document).ready( function () {
			var lang = {
            "processing": "Подождите...",
            "search": "Поиск:",
            "lengthMenu": "Показать _MENU_ записей",
            "info": "Записи с _START_ до _END_ из _TOTAL_ записей",
            "infoEmpty": "Записи с 0 до 0 из 0 записей",
            "infoFiltered": "(отфильтровано из _MAX_ записей)",
            "infoPostFix": "",
            "loadingRecords": "Загрузка записей...",
            "zeroRecords": "Записи отсутствуют.",
            "emptyTable": "В таблице отсутствуют данные",
            "paginate": {
                "first": "Первая",
                "previous": "Предыдущая",
                "next": "Следующая",
                "last": "Последняя"
            },
            "aria": {
                "sortAscending": ": активировать для сортировки столбца по возрастанию",
                "sortDescending": ": активировать для сортировки столбца по убыванию"
            }
        }

			//активация menTable; русификация
        $('#infoTable').DataTable({ 
		 columnDefs: [
		   { type: 'de_date', targets: 0 }
		 ],
		 paging: false,
        "language": lang,
		"order":[[0,"desc"]],
		
		} );
		
		
		
} );//скобки .ready() не убираем

    
    </script>
</body>
</html>