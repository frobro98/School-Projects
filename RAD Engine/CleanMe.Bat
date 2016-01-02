REM
REM Keenan's Hack to remove intermediate files
REM If you find a way to enhance, please return updates to
REM ekeenan2@cdm.depaul.edu
REM  mm mm

REM cleanup root director

    rmdir /S /Q Debug
    rmdir /S /Q Release
    rmdir /S /Q ipch
    del /F /S /A:H *.suo
    del /F /S *.sdf

REM walk through subdirectories delete Release & Debug subs

for /d %%D in (*) do (
	echo %%~fD
	rmdir /S /Q %%~D\Debug
	rmdir /S /Q %%~D\Release
	rmdir /S /Q %%~D\lib
)

REM remove azl and temp text files

del /F /S *.azul
del /F /S *.txt

REM remove the internal temps from OpenGL subdirectory
	
cd .\OpenGL
CleanMe2
