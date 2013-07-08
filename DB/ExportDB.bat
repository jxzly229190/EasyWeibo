set PWD=root
set MYSQLPATH="C:\phpStudy\MySQL\bin"
set DBName=easyads
set CP=%~dp0
cd /d %MYSQLPATH%
mysqldump -uroot -p%PWD% -R %DBName%>%CP%%DBName%.sql
pause 