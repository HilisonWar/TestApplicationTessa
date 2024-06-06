# Мини-приложение для управления процессами в системе СЭД Tessa

# Реализованные API методы
<b>GET /api/documents </b> - получение списка созданных документов, хранящихся в БД <br>
<b>GET /api/documents/{id} </b> - получение документа по его идентификатору (id) <br> 
<b>POST /api/documents </b> - добавление нового документа с перечнем заданий <br>
<b>DELETE /api/documents/{id} </b> - удалениие документа с определенным идентификатором (id) <br>
<b>PUT /api/documents/{documentId}/tasks/{taskId}/cancel </b> - отмена активной задачи документа по ее идентификатору (taskId) и идентификатору документа (documentId)<br>
<b>PUT /api/documents/{documentId}/tasks/{taskId}/confirm </b> - установление активной задачи документа как выполненной
# Инструкция по запуску
<b>-Загрузите проект как Zip-архив, либо используйте ссылку для клонирования проекта</b> 
![image](https://github.com/HilisonWar/TestApplicationTessa/assets/106067121/c0dcf879-48a3-474b-aaf7-afba903081ea) <br><br>
<b>Откройте проект в Visual Studio и запустите его используя клавишу запуска на панели, либо нажатием F5
![image](https://github.com/HilisonWar/TestApplicationTessa/assets/106067121/28591a59-dd47-419a-b49c-10b73a33a119) <br><br>
<b>-После запуска проекта вы окажетесь на главной странице с UI интерфейсом,где предоставлена возможность создания документов с задачами и их выводом </b> <br>
![image](https://github.com/HilisonWar/TestApplicationTessa/assets/106067121/ae57469a-5e65-4c74-a56a-49b64b357266)
<b> -Для альтернативного тестирования вы можете воспользоваться Swagger, прописав в адресной строке /swagger </b> <br> <br>
![image](https://github.com/HilisonWar/TestApplicationTessa/assets/106067121/f24d72b2-2317-4ca3-8ddc-f64ccb619b40)

