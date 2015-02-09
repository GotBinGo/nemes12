IF EXIST \NT2 xcopy \NT2 \NT2_bord /e /i /y
xcopy .\NT2 \NT2 /e /i /y
IF EXIST \NT2_bord xcopy \NT2_bord \NT2 /e /i /y
IF EXIST \NT2_bord rmdir \NT2_bord /s /q
cd bin
start ..\NT2\t2.bat
