@echo off
Set TK=\nt2
Set TD=\nt2\3
Set F1=jelzes
Set Te1=1 2 3 4
Set F2=verseny
Set Te2=1 2 3 4 5
Set F3=valogat
Set Te3=1 2 3 4 5 6 7
Set F4=parosit
Set Te4=1 2 3 4 5 6 7 8
Set F5=szamos
Set Te5=1 2 3 4 5 6 7 8
:T1
if exist %F1%.exe goto EXE1
if exist %F1%.class goto EXE1
echo Nincs %F1% exe
GoTo T2
:EXE1
Echo %F1% feladat futtat†sa ....
for %%x In (%Te1%) Do Call %TK%\RUN %TD% %F1% %%x
Echo %F1% feladat futtat†sa befejezãdîtt.

:T2
if exist %F2%.exe goto EXE2
if exist %F2%.class goto EXE2
echo Nincs %F2% exe
GoTo T3
:EXE2
Echo %F2% feladat futtat†sa ....
for %%x In (%Te2%) Do Call %TK%\RUN %TD% %F2% %%x
Echo %F2% feladat futtat†sa befejezãdîtt.

:T3
if exist %F3%.exe goto EXE3
if exist %F3%.class goto EXE3
echo Nincs %F3% exe
GoTo T4
:EXE3
Echo %F3% feladat futtat†sa ....
for %%x In (%Te3%) Do Call %TK%\RUN %TD% %F3% %%x
Echo %F3% feladat futtat†sa befejezãdîtt.

:T4
if exist %F4%.exe goto EXE4
if exist %F4%.class goto EXE4
echo Nincs %F4% exe
GoTo T5
:EXE4
Echo %F4% feladat futtat†sa ....
for %%x In (%Te4%) Do Call %TK%\RUN %TD% %F4% %%x
Echo %F4% feladat futtat†sa befejezãdîtt.

:T5
if exist %F5%.exe goto EXE5
if exist %F5%.class goto EXE5
echo Nincs %F5% exe
GoTo TV
:EXE5
Echo %F5% feladat futtat†sa ....
for %%x In (%Te5%) Do Call %TK%\RUN %TD% %F5% %%x
Echo %F5% feladat futtat†sa befejezãdîtt.

:TV
echo FUTTATµS VêGETêRT

echo A %F1% feladat ÇrtÇkelÇse ....
%TD%\%F1% %TD% %F1%

echo A %F2% feladat ÇrtÇkelÇse ....
%TD%\%F2% %TD% %F2%

echo A %F3% feladat ÇrtÇkelÇse ....
%TD%\%F3% %TD% %F3%

echo A %F4% feladat ÇrtÇkelÇse ....
%TD%\%F4% %TD% %F4%

echo A %F5% feladat ÇrtÇkelÇse ....
%TD%\%F5% %TD% %F5%

Rem CLS
%TK%\osszes %TD%

echo AZ êRTêKELêS BEFEJEZäDôTT!
echo ***********************************************
echo A teljes ÇrtÇkelÇs az EREDMENY.TXT †llom†nyban.
echo ***********************************************

:VEGE
