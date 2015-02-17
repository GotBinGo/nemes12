rmdir src /s /q
mkdir src

cd ..\work
for /f "delims=" %%D in ('dir /a:d /b') do copy %%~D\%%~D\Program.cs ..\test\src\%%~D.cs 
cd ..\test
