set PWD=19880411
set MYSQLPATH="D:\Development\MySQL\MySQL Server 5.6\bin"
set DBName=easyads
set CP=%~dp0
cd /d %MYSQLPATH%
mysqldump -uroot -p%PWD% -R %DBName%>%CP%%DBName%.sql
pause 