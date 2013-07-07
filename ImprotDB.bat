set PWD=19880411
set MYSQLPATH="D:\Development\MySQL\MySQL Server 5.6\bin"
set DBName=world
set CP=%~dp0
cd /d %MYSQLPATH%
mysql -uroot -p%PWD% %DBName%<%CP%%DBName%.sql
pause 