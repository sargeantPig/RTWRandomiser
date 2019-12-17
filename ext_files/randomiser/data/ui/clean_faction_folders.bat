@echo off
for /D %%s in (.\units\*) do (
	IF NOT %%s == .\units\assets (
		echo %%s
		del %%s\*.tga
	)
)

for /D %%s in (.\unit_info\*) do (
	IF NOT %%s == .\unit_info\assets (
		echo %%s
		del %%s\*.tga
	)
)