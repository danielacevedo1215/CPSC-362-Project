#pragma once
// Definition of class Date in date.h 
#ifndef PATIENT1_H
#define PATIENT_H
#include <iostream>
#include <string>
#include "date.h"
#include <cstring>
class Patient
{
public:
	Patient();
	struct procedure
	{
		Date dateOfProcedure;
		int procedureID;
		int procedureProviderID;
	};

	Patient(const char *, const char *, const char *, Date, int);
	//Put in default values just as in Date class
	//Use the set functions so input values are checked  
	~Patient();
	void setID(const char *);  //check if length of name string is < 32.
									// if not, shorten to 32 letters.

	void setFirstName(const char *); //check if length of name string is < 
										  // 15, if not, shorten to 14 letters.
	void setLastName(const char *);  //check if length of name string is < 
										  // 15, if not, shorten to 14 letters.
	void setBirthDate(Date );
	void setPrimaryDoctorID(int);

	const char * getID();
	const char * getFirstName();
	const char * getLastName();
	Date getBirthDate();
	int getPrimaryDoctorID();

	bool enterProcedure(Date procedureDate, int procedureID, int procedureProviderID);//tries to add a new entry to record array, returns 									 //true if added, false if cannot be added
	void printAllProcedures();


private:
	char ID[33];
	char firstName[15];
	char lastName[15];
	Date  birthdate;
	int primaryDoctorID;
	procedure record[100];
	int currentCountOfProcedures;
};
#endif
