<!DOCTYPE html>
<html lang="ru">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Рейтинг НФБР</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
  </head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <a class="navbar-brand" href="/">Рейтинг НФБР</a>		  
        </div>
		<div class="navbar-brand navbar-right">
		<?php
                            $sdd_db_host='localhost'; // адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
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
                    <li class="active"><a href="#main" class="active">Главная</a></li>
                    <li><a href="#women">Женщины</a></li>
                    <li><a href="#womenPairs">Женщины пары</a></li>
                    <li><a href="#womenMixed">Женщины смешанные пары</a></li>
                    <li><a href="#men">Мужчины</a></li>
                    <li><a href="#menPairs">Мужчины пары</a></li>
                    <li><a href="#menMixed">Мужчины смешанные пары</a></li>
                </ul>
            </div>
            <!--//ТАБЫ-->

            <div class="col-md-10">
            <div class="tab-content">
                <div class="tab-pane fade in active" id="main">
                    <h2 id="pageHeading">Главная</h2>
                    <?php
                            $sdd_db_host='localhost'; //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT author, date, heading, text FROM `posts` ORDER BY date DESC;'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								echo '<div class="panel panel-default">
								<div class="panel-heading"><strong>'.$row['heading'].'</strong> <span class="label label-default">'.$row['author'].', '.$row['date'].'</span></div>
								<div class="panel-body">'.$row['text'].'</div>
								</div>';
                            }
                    ?>
                </div>
                <div class="tab-pane fade" id="women">
                    <h2 id="pageHeading">Женщины</h2>

                    <div class="well">
                <table id="wT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="5%">Место</th>
                            <th width="25%">ФИО</th>
                            <th width="10%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `jo`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=jo';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div>
				<!--НАЧАЛО-->
				                <div class="tab-pane fade" id="womenPairs">
                    <h2 id="pageHeading">Женщины пары</h2>

                    <div class="well">
                <table id="wpT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="5%">Место</th>
                            <th width="25%">ФИО</th>
                            <th width="10%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `jp`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
							
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=jp';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div><!--КОНЕЦ-->
				
				                <div class="tab-pane fade" id="womenMixed">
                    <h2 id="pageHeading">Женщины смешанные</h2>

                    <div class="well">
                <table id="wmT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="5%">Место</th>
                            <th width="25%">ФИО</th>
                            <th width="10%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `js`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=js';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div>
				
				                <div class="tab-pane fade" id="men">
                    <h2 id="pageHeading">Мужчины</h2>

                    <div class="well">
                <table id="mT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="5%">Место</th>
                            <th width="25%">ФИО</th>
                            <th width="10%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `mo`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
								
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=mo';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div>
				
				                <div class="tab-pane fade" id="menPairs">
                    <h2 id="pageHeading">Мужчины пары</h2>

                    <div class="well">
                <table id="mpT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="3%">Место</th>
                            <th width="30%">ФИО</th>
                            <th width="8%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд


                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `mp`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
								
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=mp';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div>
				
				                <div class="tab-pane fade" id="menMixed">
                    <h2 id="pageHeading">Мужчины смешанные</h2>

                    <div class="well">
                <table id="mmT" class="display table table-striped table-bordered dataTable no-footer">
                    <thead>
                        <tr>
                            <th width="5%">Место</th>
                            <th width="25%">ФИО</th>
                            <th width="10%">Год/р</th>
                            <th width="15%">Разряд</th>
                            <th width="15%">Регион</th>
                            <th width="10%">Рейтинг</th>
                            <th width="10%">Личные</th>
                            <th width="10%">Командные</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                            $sdd_db_host='localhost'; // //адрес сервера бд (всё как в программе)
                            $sdd_db_name='volkovsema_newb'; // ваша бд
                            $sdd_db_user='volkovsema_user'; // пользователь бд
                            $sdd_db_pass='1q2w3e'; // пароль к бд

                            
                            @mysql_connect($sdd_db_host,$sdd_db_user,$sdd_db_pass); // коннект с сервером бд
                            @mysql_set_charset('utf8');
                            @mysql_select_db($sdd_db_name); // выбор бд
                            $result=mysql_query('SELECT * FROM `ms`'); // запрос на выборку
                            while($row=mysql_fetch_array($result))
                            {
								$change = "";
								if($row['Change']=='-')
									$change = "<i class=\"glyphicon glyphicon-triangle-bottom\" style = \"color: red\"></i>";
								if($row['Change']=='+')
									$change = "<i class=\"glyphicon glyphicon-triangle-top\" style = \"color: green\"></i>";
								$link = 'name='.urlencode($row['Name']).'&year='.$row['BirthYear'].'&qual='.urlencode($row['Qualification']).'&cat=ms';
								echo '<tr><td>'.$row['Number'].'</td><td><a href=/info.php?'.$link.'>'.$row['Name'].'</a></td><td>'.$row['BirthYear'].'</td><td>'.$row['Qualification'].'</td><td>'.$row['Region'].'</td><td>'.$row['Rating'].' '.$change.'</td><td>'.$row['Personal'].'</td><td>'.$row['Team'].'</td>
                            </tr>
                            ';// выводим данные
                            }
                    ?>
                    </tbody>
                </table>
                </div><!--/well-->
                </div>
				
			</div>
			</div>
			</div>
    <hr>
</div> <!-- /container -->
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <!--DataTables OLD-->
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs/dt-1.10.15/r-2.1.1/sc-1.4.2/datatables.min.css"/>
 
<script type="text/javascript" src="https://cdn.datatables.net/v/bs/dt-1.10.15/r-2.1.1/sc-1.4.2/datatables.min.js"></script>



    
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
        $('#wT').DataTable({ 
        "language": lang
		} );
		        $('#wpT').DataTable({ 
        "language": lang
		} );
		        $('#wmT').DataTable({ 
        "language": lang
		} );
		        $('#mT').DataTable({ 
        "language": lang
		} );
		        $('#mpT').DataTable({ 
        "language": lang
		} );
		        $('#mmT').DataTable({ 
        "language": lang
		} );
    $('#mainMenu a[href="#main"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });

    $('#mainMenu a[href="#women"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
	    $('#mainMenu a[href="#womenPairs"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
	    $('#mainMenu a[href="#womenMixed"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
	    $('#mainMenu a[href="#men"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
	    $('#mainMenu a[href="#menPairs"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
	    $('#mainMenu a[href="#menMixed"]').click(function (e) {
                e.preventDefault()
                $(this).tab('show')
    });
} );//скобки .ready() не убираем
    
    </script>
</body>
</html>