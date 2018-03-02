#!/bin/bash
echo beginning compilation of lexerFunction
rm *.o
rm *.exe
g++ -Wall -std=c++11 -m64 nurses.cpp -c -o nurses.o
echo compilation successful. beginning linking
g++ -m64 -o p1.exe nurses.o
echo linking successful. Executing project 1
./p1.exe
echo shell done 
