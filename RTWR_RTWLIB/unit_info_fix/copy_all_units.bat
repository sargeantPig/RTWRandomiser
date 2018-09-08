@echo off
SETLOCAL ENABLEDELAYEDEXPANSION
set back=%cd%
for /D %%s in (.\*) do (
	xcopy %%s\*.tga "%back%" /Y
)


for /D %%i in (.\*) do (
	xcopy *.tga %%i /Y
)
 
 clean.bat