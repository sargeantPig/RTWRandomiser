@echo off
SETLOCAL ENABLEDELAYEDEXPANSION
set back=%cd%

for /D %%s in (.\units\*) do (
	echo %%s
	IF NOT %%s == .\units\assets (
	rmdir "%%s\assets"
	rmdir %%s 
	mklink /D %%s "%cd%\units\assets"
	 )
)

for /D %%s in (.\unit_info\*) do (
	echo %%s
	IF NOT %%s == .\unit_info\assets (
		rmdir "%%s\assets"
		rmdir %%s 
		mklink /D %%s "%cd%\unit_info\assets"
	)
)