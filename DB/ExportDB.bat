set PWD=
set MYSQLPATH=
set DBName=easyads
set CP=%~dp0
cd /d %MYSQLPATH%
mysqldump -uroot -p%PWD% -R %DBName%>%CP%%DBName%.sql
pause 