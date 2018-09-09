@echo off
SETLOCAL ENABLEDELAYEDEXPANSION
set back=%cd%

if not exist "%cd%\unit_info\assets" mkdir "%cd%\unit_info\assets"
if not exist "%cd%\units\assets" mkdir "%cd%\units\assets"

for /D %%s in (.\units\*) do (
	echo %%s
	xcopy %%s\*.tga "%back%\units\assets" /Y
)

for /D %%s in (.\unit_info\*) do (
	echo %%s
	xcopy %%s\*.tga "%back%\unit_info\assets" /Y
)

call clean_faction_folders.bat 
link.bat
