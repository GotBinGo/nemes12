rem RUN %1=TestDir %2=Feladatnev %3=teszteset
rem Set TK=\NT2
If Exist %2.st%3 GoTo KI
If Exist %2.ki Del %2.ki >Nul
If Exist %2.ki%3 Del %2.ki%3 >Nul

If Exist %2.exe GoTo EXE
If Exist %2.class GoTo JAVA
echo Nincs exe
GoTo KI

:EXE
Copy %1\%2.be%3 %2.be >Nul
rem Cls
\NT2\fut.exe %2 %3
\NT2\stime.exe %2.st%3
%2.exe > %2.so%3
\NT2\ftime.exe %2.st%3
Copy %2.ki %2.ki%3 >Nul
GoTo KI

:JAVA
Copy %1\%2.be%3 %2.be >Nul
rem Cls
\NT2\fut.exe %2 %3
\NT2\stime.exe %2.st%3
java %2 > %2.so%3
\NT2\ftime.exe %2.st%3
Copy %2.ki %2.ki%3 >Nul

:KI
