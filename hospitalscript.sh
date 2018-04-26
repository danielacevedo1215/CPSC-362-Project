#!/bin/bash
#Author: Marcus Hoertz, Daniel Acevedo
#course: CPSC362
echo script File for Hospital Project begins
rm *.dll
rm *.exe
echo HospitalFrame makes the frame for the hospital
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll  -out:Hospitalframe.dll HospitalFrame.cs
echo HospitalMain creates the user interface to be interacted with
mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:Hospitalframe.dll  -out:Hospital.exe HospitalMain.cs
echo Finish successful compilation. Executing project.
./Hospital.exe
echo shell done
