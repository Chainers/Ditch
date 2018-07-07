cd ..\Sources\
@echo off

del *.user /S /Q 

FOR /R %%f IN (.) DO (
	if "%%~nf"=="packages"	(	
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="obj" (
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="bin"	(	
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="Bin"	(	
		rmdir /S /Q "%%f"
	)
	if EXIST "ReSharper.*" (	
		rmdir /S /Q "_ReSharper.*"
	)
)

cd ..\Automation\