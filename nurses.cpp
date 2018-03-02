#include <iomanip>
#include <iostream>
#include <vector>
using namespace std;
int currentPosition = 0;
struct NurseHolder
{
	string Name;
	string IdNum;
	int payRate;
	string roomNum;
};
vector<NurseHolder> NurseVector;
void setId( string name)
{
	int matchingNames = 0; // for finding matching names
	for( int i = 0; i< NurseVector.size(); i++)
	{
		if (NurseVector[i].Name == name)
		{
			matchingNames ++;
		}
	}
	if (matchingNames < 10)
	{
		NurseVector[currentPosition].IdNum = name + "00" + to_string(matchingNames);
	}
	else if ( matchingNames >= 10 && matchingNames < 100)
	{
		NurseVector[currentPosition].IdNum = name + "0" + to_string(matchingNames);
	}
	else
	{
		NurseVector[currentPosition].IdNum = name + to_string(matchingNames);
	}
}
void initialName( string name)
{
	NurseVector[currentPosition].Name = name;
}
void initialPayRate ( int pay)
{
	NurseVector[currentPosition].payRate = pay;
}
void initialRoomNum ( string room)
{
	NurseVector[currentPosition].roomNum = room;
}

string findNurse( string findNurse)
{
	for (int i = 0; i < NurseVector.size(); i++)
	{
		if( NurseVector[i].IdNum == findNurse)
		{
			return NurseVector[i].roomNum;
		}
	}
	return "-1";
}

bool setNurseRoom( string findNurse, string newRoom)
{
	for (int i = 0; i < NurseVector.size(); i++)
	{
		if( NurseVector[i].IdNum == findNurse)
		{
			 NurseVector[i].roomNum= newRoom;
			 return true;
		}
	}
	return false;
}

bool printANurse( string findNurse)
{
	for (int i = 0; i < NurseVector.size(); i++)
	{
		if( NurseVector[i].IdNum == findNurse)
		{
			 cout<< " Nurse Name: " << NurseVector[i].Name << endl << "Nurse ID: " << NurseVector[i].IdNum << endl << "Nurse Pay: " << NurseVector[i].payRate << endl << "Nurse Location: " << NurseVector[i].roomNum<<endl;
			 return true;
		}
	}
	return false;
}
void printAllNurse()
{
	for (int i = 0; i < NurseVector.size(); i++)
	{
		cout<< " Nurse Name: " << NurseVector[i].Name << endl << "Nurse ID: " << NurseVector[i].IdNum << endl << "Nurse Pay: " << NurseVector[i].payRate << endl << "Nurse Location: " << NurseVector[i].roomNum<<endl;
	}
}

int main ()
{
	bool run = true;
	while ( run)
	{
		char chooseOption;
		cout << endl;
		cout << "---------------------------------------------------------------" << endl;
		cout << endl;
		cout << "Welcome!" << endl;
		cout << "Please enter the letter that represent what you would like to do from the following menu: " << endl;
		cout << "N: Make a new Nurse " << endl;
		cout << "R: Find a Nurse " << endl;
		cout << "S: Set a Nurse's room " << endl;
		cout << "V: Print out information on a particular nurse " << endl;
		cout << "A: Print list of nurses " << endl;
		cout << "Q: quit " << endl;
		cin>> chooseOption;
		if ( chooseOption == 'N' || chooseOption == 'n')
		{
			NurseHolder *newNurse = new NurseHolder();
			NurseVector.push_back(*newNurse);
			string name, currentRoom;
			int pay;
			cout<< "Enter Nurse Name: " << endl;
			cin >> name;
			cout<< "Enter Nurse Pay: " << endl;
			cin >> pay;
			cout<< "Enter Current Room: " <<endl;
			cin>> currentRoom;
			cout<< "Adding Nurse to info... " <<endl;
			initialName(name);
			setId(name);
			initialPayRate(pay);
			initialRoomNum(currentRoom);
			cout<< "Nurse info for " << name<< " has been added" <<endl;
			cout<< "Nurse's ID is " << NurseVector[currentPosition].IdNum << endl;
			currentPosition++;
		}
		if ( chooseOption == 'R' || chooseOption == 'r')
		{
			string idNum;
			cout << "Enter Nurse's idNum: " << endl;
			cin>>idNum;
			string roomNum = findNurse(idNum);
			if (roomNum != "-1")
			{
				cout<< "Nurse " << idNum << " was found in Room " << roomNum << endl;
			}
			else
			{
				cout<< "Nurse not found. please Check if Id number is correct"<<endl;
			}
		}
		if ( chooseOption == 'S' || chooseOption == 's')
		{
			string idNum, newRoom;
			cout<< "Enter Nurse's idNum: " <<endl;
			cin >> idNum;
			cout<< "Enter Nurse's new Room: " <<endl;
			cin>> newRoom;
			if ( setNurseRoom(idNum, newRoom))
			{
				cout<< "Nurse " << idNum << "'s room has been updated to " << newRoom << endl;
			}
			else
			{
				cout<< "Nurse " << idNum << " was not found. Please make sure id is correct" <<endl;
			}
		}
		if (chooseOption == 'V' || chooseOption == 'v')
		{
			string idNum;
			cout<< "Enter Nurse's idNum: " << endl;
			cin>> idNum;
			if(printANurse(idNum))
			{
			}
			else
			{
				cout<< "Nurse " <<idNum << " was not found. Please make sure id is correct" <<endl;
			}
		}
		if ( chooseOption == 'A' || chooseOption == 'a')
		{
			printAllNurse();
		}
		if (chooseOption == 'Q' || chooseOption == 'q')
		{
			cout<< "Thank you for using the program. goodbye"<<endl;
			run = false;
		}
	}
	return 0;
}
			
