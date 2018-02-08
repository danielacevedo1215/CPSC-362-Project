#include <iostream>
#include "Patient.h"
#include "date.h"
#include <string>
#include <cstring>



Patient::Patient(const char *ident, const char *fm, const char *lm, Date dte, int did) {
	*Patient::ID = *ident;
	*Patient::firstName = *fm;
	*Patient::lastName = *lm;
	Patient::birthdate = dte;
	Patient::primaryDoctorID = did;
	Patient::currentCountOfProcedures = 0;


}

Patient::Patient() {
	Patient::currentCountOfProcedures = 0;
}

//Put in default values just as in Date class
//Use the set functions so input values are checked  
Patient::~Patient() {
	delete[] & firstName;
	delete[] & ID;
	delete[] & lastName;
}


void Patient::setID(const char *ID) {  //check if length of name string is < 32.
									   // if not, shorten to 32 letters.

	if (strlen(ID) >= 33) {

		char dest[33];
		strncpy_s(dest, ID, 32); // copy at most 32 characters (indices 0-32)
		dest[33] = 0; // ensures the last character is a null terminator
		strncpy_s(Patient::ID, dest, 32);
	}

	else {
		strncpy_s(Patient::ID, ID, strlen(ID));

	}

}

void Patient::setFirstName(const char *firstName) { //check if length of name string is < 
													// 15, if not, shorten to 14 letters.

	if (strlen(firstName) >= 15) {

		char dest[15];
		strncpy_s(dest, firstName, 14);
		dest[14] = '\0'; // ensures the last character is a null terminator
		cout << dest << endl;
		strncpy_s(Patient::firstName, dest, 14);
	}

	else {
		strncpy_s(Patient::firstName, firstName, strlen(firstName));
	}

}
void Patient::setLastName(const char *lastName) {  //check if length of name string is < 
												   // 15, if not, shorten to 14 letters.
	if (strlen(lastName) >= 15) {

		char dest[15];
		strncpy_s(dest, lastName, 14);
		dest[14] = '\0'; // ensures the last character is a null terminator
		strncpy_s(Patient::lastName, dest, 14);


	}

	else {
		strncpy_s(Patient::lastName, lastName, strlen(lastName));

	}
}



void Patient::setBirthDate(Date date) {
	Patient::birthdate = date;
	return;
}

void Patient::setPrimaryDoctorID(int DID) {
	Patient::primaryDoctorID = DID;

}

const char* Patient::getID() {
	return ID;
}
const char* Patient::getFirstName() {
	return firstName;
}
const char* Patient::getLastName() {
	return lastName;
}


Date Patient::getBirthDate() {
	return birthdate;
}


int Patient::getPrimaryDoctorID() {

	return primaryDoctorID;

}

bool Patient::enterProcedure(Date procedureDate, int procedureID, int procedureProviderID) {
	procedure patientProcedure;
	patientProcedure.dateOfProcedure = procedureDate;
	patientProcedure.procedureID = procedureID;
	patientProcedure.procedureProviderID = procedureProviderID;

	if (currentCountOfProcedures < 500) {
		record[currentCountOfProcedures] = patientProcedure;
		currentCountOfProcedures++;

		return true;
	}

	else {

		return false;
	}



}


void Patient::printAllProcedures() {
	for (int i = 0; i < currentCountOfProcedures; i++) {
		cout << record[i].dateOfProcedure << " " << record[i].procedureID << " " << record[i].procedureProviderID << endl;
	}
}
