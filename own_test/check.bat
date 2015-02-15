IF EXIST \NT2 xcopy \NT2 \NT2_bord /e /i /y
rmdir \NT2 /s /q
xcopy .\NT2 \NT2 /e /i /y
cd bin
call \NT2\t2.bat
IF EXIST \NT2_bord xcopy \NT2_bord \NT2 /e /i /y /q
IF EXIST \NT2_bord rmdir \NT2_bord /s /q
pause