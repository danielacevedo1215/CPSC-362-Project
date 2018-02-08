nclude <iostream>
#include "Patient.h"
#include "Date.h"
#include <string>
#include <cstring>
#include <vector>
#include <fstream>

using namespace std;

int main() {
	int loop = 1;
	char response;
	vector<Patient*> patientsVector; //creates vector of all patients
	vector<Patient*> patientsCheckedInVector; // Vector of patients checked in 

	fstream ioFile;


	ioFile.open("CurrentPatients.din", fstream::in | fstream::out | fstream::binary);

	if (!ioFile.is_open()) {
		cout << "not open" << endl;
	}
	else if (ioFile.peek() == std::ifstream::traits_type::eof())
		std::cout << "the file is empty\n";
	else {
		int counter = 0;
		while (ioFile.peek() != std::ifstream::traits_type::eof()) {
			ioFile.seekg(counter * sizeof(Patient));
			Patient *p = new Patient();
			ioFile.read((char*)p, sizeof(Patient));
			patientsVector.push_back(p);
			counter++;
		}
	}

	ioFile.close();

	//Today's date at start of program
	int month;
	int day;
	int year;

	cout << "Please enter the current date: (mm/dd/yyyy format) " << endl;
	cin >> month >> day >> year;
	Date *todaysDate = new Date(month, day, year);
	todaysDate->setDate(month, day, year);

	do {
		//menu
		cout << endl;
		cout << "---------------------------------------------------------------" << endl;
		cout << endl;
		cout << "Welcome!" << endl;
		cout << "Please enter the letter that represent what you would like to do from the following menu: " << endl;
		cout << "N: Check in new patient " << endl;
		cout << "R: Check in returning patient " << endl;
		cout << "O: Check out patient " << endl;
		cout << "I: Print out information on a particular patient " << endl;
		cout << "P: Print list of patients who have checked in " << endl;
		cout << "Q: quit " << endl;

		cin >> response;

		cout << endl;
		cout << "---------------------------------------------------------------" << endl;

		cout << endl;


		//switch for options

		switch (response)
		{
		case 'N':
		case 'n': {
			Patient *patient1 = new Patient();
			char fname[50];
			char lname[50];
			int month;
			int day;
			int year;
			int did;

			cout << "Please enter your first name: " << endl;
			cin >> fname;
			cout << "Please enter your last name: " << endl;
			cin >> lname;
			cout << "Please enter your birthday: (mm/dd/yyyy format) " << endl;
			cin >> month >> day >> year;
			cout << "Please enter your primary doctor ID: " << endl;
			cin >> did;

			patient1->setFirstName(fname);
			patient1->setLastName(lname);
			cout << "set name" << endl;
			Date *birthday = new Date(month, day, year);
			patient1->setBirthDate(*birthday);
			cout << "setting ID" << endl;
			//change year to char*
			char yearbuf[5];
			_itoa_s(year, yearbuf, 10);
			char buffer[33];
			
			strcpy_s(buffer, patient1->getLastName());
			strcat_s(buffer, patient1->getFirstName());
			strcat_s(buffer, yearbuf);

			patient1->setID(buffer);
			cout << patient1->getID() << endl;

			patient1->setPrimaryDoctorID(did);

			patientsVector.push_back(patient1);
			patientsCheckedInVector.push_back(patient1);
			break;
		}


		case 'R':
		case 'r': {

			char patientSearch[33];

			cout << "Please enter your ID: " << endl;
			cin >> patientSearch;

			bool found = false;
			for (int i = 0; i < patientsVector.size(); i++) {

				if (strcmp(patientsVector.at(i)->getID(), patientSearch) == 0) {
					patientsCheckedInVector.push_back(patientsVector.at(i));
					found = true;

				}
			}

			if (found) {
				cout << "Patient is now checked in" << endl;
			}
			else {
				cout << "Patient ID not found. " << endl << endl;
				cout << "Please try R again or choose N for new patient " << endl << endl;
			}

		}
				  break;

		case 'O':
		case 'o': {

			int month;
			int day;
			int year;
			int procedureID;
			int providerID;


			char patientSearch[33];
			Patient *currentPatient;

			cout << "Please enter your ID: " << endl;
			cin >> patientSearch;

			bool found = false;
			for (int i = 0; i < patientsCheckedInVector.size(); i++) {

				if (strcmp(patientsCheckedInVector.at(i)->getID(), patientSearch) == 0) {
					currentPatient = patientsCheckedInVector.at(i);
					found = true;

				}
			}

			if (!found) {
				cout << "Patient ID not found. " << endl << endl;
				cout << "Please try O again or choose N for new patient or R to check yourself in" << endl << endl;
				break;
			}

			//ask for new procedure info
			cout << "Please enter today's data: (mm/dd/yyyy format) " << endl;
			cin >> month >> day >> year;
			cout << "Please enter your procedure ID: " << endl;
			cin >> procedureID;
			cout << "Please enter your provider ID: " << endl;
			cin >> providerID;


			Date *currentDate = new Date(month, day, year);

			if (currentPatient->enterProcedure(*currentDate, procedureID, providerID)) { //enter a new procedure to record array


																						 //for loop is used to find the patient object we want to remove
				for (vector<Patient*>::iterator it = patientsVector.begin(); it != patientsVector.end(); ++it) {



					if (strcmp((*it)->getID(), currentPatient->getID()) == 0) { //comparison to find the patient we watn to remove

																				//remove the patient
						patientsVector.erase(it);

						//then push back the updated one
						patientsVector.push_back(currentPatient);
						break;
					}
				}
				for (vector<Patient*>::iterator it = patientsCheckedInVector.begin(); it != patientsCheckedInVector.end(); ++it) {



					if (strcmp((*it)->getID(), currentPatient->getID()) == 0) { //comparison to find the patient we watn to remove

																				//remove the patient
						patientsCheckedInVector.erase(it);

						break;
					}
				}

			}
			else {
				//if we couldnt enter a procedure then we print out we couldnt and exit
				cout << "error: Too many procedures entered." << endl;
			}
			break;
		}

		case 'I':
		case 'i': {
			char patientSearch[33];
			Patient *currentPatient;

			cout << "Please enter your ID: " << endl;
			cin >> patientSearch;
			cout << endl;

			bool found = false;
			for (int i = 0; i < patientsVector.size(); i++) {

				if (strcmp(patientsVector.at(i)->getID(), patientSearch) == 0) {
					currentPatient = patientsVector.at(i);
					found = true;

				}
			}

			if (!found) {
				cout << "Patient ID not found. " << endl << endl;
				cout << "Please try O again or choose N for new patient or R to check yourself in" << endl << endl;
				break;
			}

			else {
				cout << "Patient Name: " << currentPatient->getFirstName() << " " << currentPatient->getLastName() << endl
					<< "Patient birthday: " << currentPatient->getBirthDate() << endl
					<< "Primary doctor ID: " << currentPatient->getPrimaryDoctorID() << endl;
				cout << "Procedure list: " << endl;
				currentPatient->printAllProcedures();
			}
			break;

		}
		case 'P':
		case 'p': {
			for (int i = 0; i < patientsCheckedInVector.size(); i++) {

				cout << "Patient ID: " << patientsCheckedInVector.at(i)->getID() << endl <<
					"Patient Name: " << patientsCheckedInVector.at(i)->getFirstName() << " " << patientsCheckedInVector.at(i)->getLastName() << endl
					<< "Doctor ID: " << patientsCheckedInVector.at(i)->getPrimaryDoctorID() << endl;
			}
			break;
		}

		case 'Q':
		case 'q':
		{
			if (!patientsCheckedInVector.empty()) {
				cout << "Error: These patients are still checked in" << endl;
				for (int i = 0; i < patientsCheckedInVector.size(); i++) {

					cout << patientsCheckedInVector.at(i)->getID() << " " << patientsCheckedInVector.at(i)->getFirstName() << " " <<
						patientsCheckedInVector.at(i)->getLastName() << endl;
				}
			}

			else {

				ioFile.open("CurrentPatients.dat", fstream::in | fstream::out | fstream::binary);

				if (!ioFile.is_open())
				{
					cout << "not open" << endl;
				}

				for (int i = 0; i < patientsVector.size(); i++) {
					Patient *p;
					p = patientsVector.at(i);

					ioFile.write((char *)p, sizeof(Patient));
				}

				ioFile.close();

				loop = 0;
			}
			break;
		}
		default:
			cout << "That is not a valid option" << endl;
		}
	} while (loop);
}
