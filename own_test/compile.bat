rmdir bin /s /q
mkdir bin
for /r %%v in (src\*.cs) do C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc /out:bin\%%~nv.exe %%v
