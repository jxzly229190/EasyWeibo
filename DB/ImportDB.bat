set PWD=root
set MYSQLPATH="C:\phpStudy\MySQL\bin"
set DBName=easyads
set CP=%~dp0
cd /d %MYSQLPATH%
mysql -uroot -p%PWD% %DBName%<%CP%%DBName%.sql
pause 