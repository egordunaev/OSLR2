@Echo Off
Set FileExe="OSLR2.Exe"
Echo [Dunaev Egor, 3-42]
If "%1" == "" GoTo :NoParm
Set FileTxt=%1
If Not Exist "%FileTxt%" GoTo :NoFileTxt
If Not Exist "%FileExe%" GoTo :NoFileExe
Set DirNm="DIR"
If "%2" == "" GoTo :No2
If "%3" == "" GoTo :NoParm
Set DirNm="%2"
Set DirName="%3"
:No2
Md %DirNm%
%FileExe% %FileTxt% %DirNm% %DirName%
Echo Error code: %ERRORLEVEL%
If %ERRORLEVEL% == 5 Echo ERROR 5
GoTo :Eof
:NoParm
Echo ERROR %ERRORLEVEL% : NO Parameter
GoTo WaitKey
:NoFileTxt
Echo ERROR %ERRORLEVEL% : File  %FileTxt%  does not exists
GoTo WaitKey
:NoFileExe
Echo ERROR %ERRORLEVEL% : File  %FileExe%  does not exists
:WaitKey
pause