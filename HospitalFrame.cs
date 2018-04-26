//space for comments
// 2018 CSUF Spring CS362 Hospital Project
// By Marcus Hoertz and Daniel Acevedo
// A graphical interface for a fake hospital.
// Allows user input, different levels
// and file I/O.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;


public class HospitalFrame : Form
{
	private const int frameWidth=1080;
	private const int frameHeight=720;
	public int currentNurseIndex = 0;
	public int currentPatientIndex = 0;
	private int counter = 0;
	public string roomInfo, roomInfoHolder;
	// 1080X720
	private const string titleOfFrame= "Hospital by Marcus Hoertz and Daniel Acevedo";
	private Label title = new Label();
	private TextBox positionInput = new TextBox();
	private TextBox firstNameInput = new TextBox();
	private TextBox lastNameInput = new TextBox();
	private TextBox payOrInsuranceInput = new TextBox();
	private TextBox roomNumInput = new TextBox();
	public struct Nurse
	{
		 public string nurseFirstName;
		 public string nurseLastName;
		 public string nurseIdNum;
		 public string payRate;
		 public string nurseRoom;
	};
	List<Nurse> NurseList = new List<Nurse>();
	public struct Patient
	{
		 public string patientFirstName;
		 public string patientLastName;
		 public string patientIdNum;
		 public string insuranceId;
		 public string patientRoom;
	};
	List<Patient> PatientList = new List<Patient>();
	public struct Room
	{
		public string roomNumber;
		public string roomDescription;
		public string roomLevel;
	};
	List<Room> RoomList = new List<Room>();	
	private string roomNumberHolder= "";
	private string helpText1 = "";
	private string helpText2 = "";
	private string helpText3 = "";
	private string helpText4 = "";
	private string helpText5 = "";
	private bool firstFloor = true;
	private bool secondFloor= false;
	private bool helpText = false;
	private Pen bluePen = new Pen(Color.Blue,4);
	private Font specialFont = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
	private Font mediumFont = new System.Drawing.Font("Arial", 14, FontStyle.Regular);
	private Font bigFont = new System.Drawing.Font("Arial", 20, FontStyle.Regular);
	private Button inputInfo = new Button();
	private Button findPerson = new Button();
	private Button findRoom = new Button();
	private Button changeRoom = new Button();
	private Button changeSalary = new Button();
	private Button viewInfo = new Button();
	private Button viewNurses = new Button();
	private Button viewPatients  = new Button();
	private Button requestStock = new Button();
	private Button viewMap = new Button();
	private Button exit = new Button();
	private bool inputHelp = true;
	private bool findPersonHelp= true;
	private bool findRoomHelp = true;
	private bool changeRoomHelp = true;
	private bool changeSalaryHelp = true;
	private bool viewInfoHelp = true;
	private bool viewNursesHelp = true;
	private bool requestStockHelp = true;
	private bool adminLevel = false;
	private static System.Timers.Timer FlashClock = new System.Timers.Timer();
	private static System.Timers.Timer DisplayClock = new System.Timers.Timer();

	public HospitalFrame()
	{
		Text = "Hospital by Hoertz Acevedo";
		System.Console.WriteLine(" windowWidth = {0}. windowHeight = {1}.", frameWidth, frameHeight);
		Size= new Size(frameWidth, frameHeight);
		BackColor= Color.Gray;
		title.Text = "Hospital by Hoertz Acevedo";
		title.Size = new Size(170,18);
		title.Location = new Point(500, 20);
		inputInfo.Text = "Input";
		inputInfo.Size = new System.Drawing.Size(80,20);
		inputInfo.BackColor = Color.Green;
		inputInfo.Location = new Point (80, 510);
		findPerson.Text = "Locate Person";
		findPerson.Size = new System.Drawing.Size(80,20);
		findPerson.BackColor = Color.Green;
		findPerson.Location = new Point (180, 510);
		findRoom.Text = "Find Room";
		findRoom.Size = new System.Drawing.Size(80,20);
		findRoom.BackColor = Color.Green;
		findRoom.Location = new Point (280, 510);
		changeRoom.Text = "New Room";
		changeRoom.Size = new System.Drawing.Size(80,20);
		changeRoom.BackColor = Color.Green;
		changeRoom.Location = new Point (380, 510);
		viewInfo.Text = "View Info";
		viewInfo.Size = new System.Drawing.Size(80,20);
		viewInfo.BackColor = Color.Green;
		viewInfo.Location = new Point (480, 510);
		viewNurses.Text = "Nurses";
		viewNurses.Size = new System.Drawing.Size(80,20);
		viewNurses.BackColor = Color.Green;
		viewNurses.Location = new Point (80, 560);
		viewPatients.Text = "Patients";
		viewPatients.Size = new System.Drawing.Size(80,20);
		viewPatients.BackColor = Color.Green;
		viewPatients.Location = new Point (180, 560);
		viewMap.Text = "View Map";
		viewMap.Size = new System.Drawing.Size(80,20);
		viewMap.BackColor = Color.Green;
		viewMap.Location = new Point (280, 560);
		changeSalary.Text = "Salary";
		changeSalary.Size = new System.Drawing.Size(80,20);
		changeSalary.BackColor = Color.Red;
		changeSalary.Location = new Point (380, 560);
		requestStock.Text = "Request Stock";
		requestStock.Size = new System.Drawing.Size(80,20);
		requestStock.BackColor = Color.Red;
		requestStock.Location = new Point (480, 560);
		exit.Text = "Exit";
		exit.Size = new System.Drawing.Size( 60, 20);
		exit.BackColor = Color.Green;
		exit.Location = new Point ( 900, 650);
		positionInput.Location  = new Point(700, 500);
		positionInput.Size = new Size ( 100, 10);
		positionInput.Font = new Font("Arial", 8, FontStyle.Regular);
		positionInput.Text= "";
		firstNameInput.Location  = new Point(700, 520);
		firstNameInput.Size = new Size ( 100, 10);
		firstNameInput.Font = new Font("Arial", 8, FontStyle.Regular);
		firstNameInput.Text= "";
		lastNameInput.Location  = new Point(700, 540);
		lastNameInput.Size = new Size ( 100, 10);
		lastNameInput.Font = new Font("Arial", 8, FontStyle.Regular);
		lastNameInput.Text= "";
		payOrInsuranceInput.Location  = new Point(700, 560);
		payOrInsuranceInput.Size = new Size ( 100, 10);
		payOrInsuranceInput.Font = new Font("Arial", 8, FontStyle.Regular);
		payOrInsuranceInput.Text= "";
		roomNumInput.Location  = new Point(700, 580);
		roomNumInput.Size = new Size ( 100, 10);
		roomNumInput.Font = new Font("Arial", 8, FontStyle.Regular);
		roomNumInput.Text= "";
		Controls.Add(inputInfo);
		Controls.Add(findPerson);
		Controls.Add(findRoom);
		Controls.Add(changeRoom);
		Controls.Add(viewInfo);
		Controls.Add(viewNurses);
		Controls.Add(viewPatients);
		Controls.Add(viewMap);
		Controls.Add(changeSalary);
		Controls.Add(requestStock);
		Controls.Add(positionInput);
		Controls.Add(firstNameInput);
		Controls.Add(lastNameInput);
		Controls.Add(payOrInsuranceInput);
		Controls.Add(roomNumInput);
		Controls.Add(exit);
		FlashClock.Interval = 500;
		FlashClock.Enabled = false;
		DisplayClock.Interval = 1500;
		DisplayClock.Enabled = false;
		inputInfo.Click+= new EventHandler(newInput);
		findPerson.Click+= new EventHandler(seePerson);
		findRoom.Click+= new EventHandler(seeRoom);
		changeRoom.Click+= new EventHandler(modifyRoom);
		viewInfo.Click+= new EventHandler(seeInfo);
		viewNurses.Click+= new EventHandler(seeNurses);
		viewPatients.Click+= new EventHandler(seePatients);
		viewMap.Click+= new EventHandler(seeMap);
		changeSalary.Click+= new EventHandler(modifySalary);
		requestStock.Click+= new EventHandler(modifyStock);
		exit.Click+= new EventHandler(exitProgram);
		FlashClock.Elapsed += new ElapsedEventHandler(flashRefresh);
		DisplayClock.Elapsed += new ElapsedEventHandler(displayRefresh);
	}
	protected override void OnPaint( PaintEventArgs ee)
	{
		Graphics graph = ee.Graphics;
		// basic outline for borders
		graph.FillRectangle(Brushes.Yellow, 20, 490, 1000, 200);
		graph.FillRectangle(Brushes.White, 20, 20, 510, 410);
		graph.FillRectangle(Brushes.Blue, 600, 20, 400, 450);
		graph.FillRectangle(Brushes.White, 610, 30, 380, 430);
		graph.FillRectangle(Brushes.Red, 790, 40, 20, 80);
		graph.FillRectangle(Brushes.Red, 760, 70, 80, 20);
		// Text inside the help/ program info box
		graph.DrawString("Aherezo Hospital", bigFont, Brushes.Black, 695, 120);
		graph.DrawString("Thank you for using the Aherezo Hospital", mediumFont, Brushes.Black,620, 160);
		graph.DrawString("management system. Please click a button", mediumFont, Brushes.Black,620, 180);
		graph.DrawString("To see the prompt. Click again to ", mediumFont, Brushes.Black,620, 200);
		graph.DrawString("confirm input. ", mediumFont, Brushes.Black,620, 220);
		graph.DrawString("After you are done, please exit to save", mediumFont, Brushes.Black,620, 260);
		graph.DrawString("everything to the files. Have your ", mediumFont, Brushes.Black,620, 280);
		graph.DrawString("admin password ready if you are one! ", mediumFont, Brushes.Black,620, 300);
		graph.DrawString("Aherezo Hospital was designed by: ", mediumFont, Brushes.Black,620, 340);
		graph.DrawString("Marcus Hoertz- Graphics and Buttons ", mediumFont, Brushes.Black,620, 360);
		graph.DrawString("Daniel Acevedo- Functions and File I/O ", mediumFont, Brushes.Black,620, 380);
		// draw the first floor with highlights when necessary
		if(firstFloor)
		{	
			if(roomInfo == "101")
			{
				graph.FillRectangle(Brushes.Green, 25, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,25,100,100);
				graph.DrawString("101", specialFont, Brushes.Black, 65,70);
			}
			if(roomInfo == "102")
			{
				graph.FillRectangle(Brushes.Green, 125, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,25,100,100);
				graph.DrawString("102", specialFont, Brushes.Black, 165,70);
			}
			if(roomInfo == "103")
			{
				graph.FillRectangle(Brushes.Green, 225, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 225,25,100,100);
				graph.DrawString("103", specialFont, Brushes.Black, 265,70);
			}
			if(roomInfo == "104")
			{
				graph.FillRectangle(Brushes.Green, 325, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,25,100,100);
				graph.DrawString("104", specialFont, Brushes.Black, 365,70);
			}
			if(roomInfo == "105")
			{
				graph.FillRectangle(Brushes.Green, 425, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,25,100,100);
				graph.DrawString("105", specialFont, Brushes.Black, 465,70);
			}
			if(roomInfo == "106")
			{
				graph.FillRectangle(Brushes.Green, 25, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,175,100,100);
				graph.DrawString("106", specialFont, Brushes.Black, 65,220);
			}
			if(roomInfo == "107")
			{
				graph.FillRectangle(Brushes.Green, 125, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,175,100,100);
				graph.DrawString("107", specialFont, Brushes.Black, 165,220);
			}
			if(roomInfo == "108")
			{
				graph.FillRectangle(Brushes.Green, 325, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,175,100,100);
				graph.DrawString("108", specialFont, Brushes.Black, 365,220);
			}
			if(roomInfo == "109")
			{
				graph.FillRectangle(Brushes.Green, 425, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,175,100,100);
				graph.DrawString("109", specialFont, Brushes.Black, 465,220);
			}
			if(roomInfo == "110")
			{
				graph.FillRectangle(Brushes.Green, 25, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,325,100,100);
				graph.DrawString("110", specialFont, Brushes.Black, 65,370);
			}
			if(roomInfo == "111")
			{
				graph.FillRectangle(Brushes.Green, 125, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,325,100,100);
				graph.DrawString("111", specialFont, Brushes.Black, 165,370);
			}
			if(roomInfo == "112")
			{
				graph.FillRectangle(Brushes.Green, 225, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 225,325,100,100);
				graph.DrawString("112", specialFont, Brushes.Black, 265,370);
			}
			if(roomInfo == "113")
			{
				graph.FillRectangle(Brushes.Green, 325, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,325,100,100);
				graph.DrawString("113", specialFont, Brushes.Black, 365,370);
			}
			if(roomInfo == "114")
			{
				graph.FillRectangle(Brushes.Green, 425, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,325,100,100);
				graph.DrawString("114", specialFont, Brushes.Black, 465,370);
			}
		}
		// if the second floor is selected, show all rooms on the second floor
		// if there is a room highlighted, display it.
		if (secondFloor)
		{
			if(roomInfo == "201")
			{
				graph.FillRectangle(Brushes.Green, 25, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,25,100,100);
				graph.DrawString("201", specialFont, Brushes.Black, 65,70);
			}
			if(roomInfo == "202")
			{
				graph.FillRectangle(Brushes.Green, 125, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,25,100,100);
				graph.DrawString("202", specialFont, Brushes.Black, 165,70);
			}
			if(roomInfo == "203")
			{
				graph.FillRectangle(Brushes.Green, 225, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 225,25,100,100);
				graph.DrawString("203", specialFont, Brushes.Black, 265,70);
			}
			if(roomInfo == "204")
			{
				graph.FillRectangle(Brushes.Green, 325, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,25,100,100);
				graph.DrawString("204", specialFont, Brushes.Black, 365,70);
			}
			if(roomInfo == "205")
			{
				graph.FillRectangle(Brushes.Green, 425, 25, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,25,100,100);
				graph.DrawString("205", specialFont, Brushes.Black, 465,70);
			}
			if(roomInfo == "206")
			{
				graph.FillRectangle(Brushes.Green, 25, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,175,100,100);
				graph.DrawString("206", specialFont, Brushes.Black, 65,220);
			}
			if(roomInfo == "207")
			{
				graph.FillRectangle(Brushes.Green, 125, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,175,100,100);
				graph.DrawString("207", specialFont, Brushes.Black, 165,220);
			}
			if(roomInfo == "208")
			{
				graph.FillRectangle(Brushes.Green, 325, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,175,100,100);
				graph.DrawString("208", specialFont, Brushes.Black, 365,220);
			}
			if(roomInfo == "209")
			{
				graph.FillRectangle(Brushes.Green, 425, 175, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,175,100,100);
				graph.DrawString("209", specialFont, Brushes.Black, 465,220);
			}
			if(roomInfo == "210")
			{
				graph.FillRectangle(Brushes.Green, 25, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 25,325,100,100);
				graph.DrawString("210", specialFont, Brushes.Black, 65,370);
			}
			if(roomInfo == "211")
			{
				graph.FillRectangle(Brushes.Green, 125, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 125,325,100,100);
				graph.DrawString("211", specialFont, Brushes.Black, 165,370);
			}
			if(roomInfo == "212")
			{
				graph.FillRectangle(Brushes.Green, 225, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 225,325,100,100);
				graph.DrawString("212", specialFont, Brushes.Black, 265,370);
			}
			if(roomInfo == "213")
			{
				graph.FillRectangle(Brushes.Green, 325, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 325,325,100,100);
				graph.DrawString("213", specialFont, Brushes.Black, 365,370);
			}
			if(roomInfo == "214")
			{
				graph.FillRectangle(Brushes.Green, 425, 325, 100, 100);
			}
			else
			{
				graph.DrawRectangle(bluePen, 425,325,100,100);
				graph.DrawString("214", specialFont, Brushes.Black, 465,370);
			}
		}
		// help text outline and words displayed
		if( helpText)
		{
			graph.FillRectangle(Brushes.White, 810, 495, 200, 110);
			graph.DrawString(helpText1, specialFont, Brushes.Black, 820, 500);
			graph.DrawString(helpText2, specialFont, Brushes.Black, 820, 520);
			graph.DrawString(helpText3, specialFont, Brushes.Black, 820, 540);
			graph.DrawString(helpText4, specialFont, Brushes.Black, 820, 560);
			graph.DrawString(helpText5, specialFont, Brushes.Black, 820, 580);
		}
	}

	// gets input from the user to put into either nurse or patient
	protected void newInput(Object sender, EventArgs e)
	{
		if( inputHelp)
		{
			helpText1 = "Nurse or Patient?";
			helpText2 = "First Name";
			helpText3 = "Last Name";
			helpText4 = "Pay or Insurance";
			helpText5 = "Room Number";
			inputHelp = false;
			findPersonHelp= true;
	 		findRoomHelp = true;
	 		changeRoomHelp = true;
	 		changeSalaryHelp = true;
	 		viewInfoHelp = true;
	 		viewNursesHelp = true;
	 		requestStockHelp = true;
			helpText = true;
			Invalidate();
			
		}
		else
		{
		string positionInfo, firstNameInfo, lastNameInfo, payOrInsuranceInfo, roomNumInfo;
		positionInfo = positionInput.Text;
		firstNameInfo = firstNameInput.Text;
		lastNameInfo = lastNameInput.Text;
		payOrInsuranceInfo = payOrInsuranceInput.Text;
		roomNumInfo = roomNumInput.Text;
		//userInput = inputBox.Text;
		insertInfo(positionInfo, firstNameInfo, lastNameInfo, payOrInsuranceInfo, roomNumInfo);
		if( positionInfo == "nurse" || positionInfo == "Nurse")
		{
			System.Console.WriteLine(" {0} {1} added to the Nurse Info. Added with Id num {2}", positionInfo, lastNameInfo, NurseList[currentNurseIndex].nurseIdNum);
			currentNurseIndex++;
		}
		else
		{
			System.Console.WriteLine(" {0} {1} added to the Patient Info. Added with Id num {2}", positionInfo, firstNameInfo, PatientList[currentPatientIndex].patientIdNum);
			currentPatientIndex++;
		}
		positionInput.Text = String.Empty;
		firstNameInput.Text = String.Empty;
		lastNameInput.Text = String.Empty;
		payOrInsuranceInput.Text = String.Empty;
		roomNumInput.Text = String.Empty;
		inputHelp = true;
		helpText = false;
		Invalidate();
		}
	}

	// takes info from newInput and puts it into the appropriate list
	protected void insertInfo(string positionInput, string firstNameInput, string lastNameInput, string payOrInsuranceInput, string roomNumInput)
	{
		if( positionInput == "nurse" || positionInput == "Nurse")
		{
			Nurse newNurse = new Nurse();
			newNurse.nurseFirstName = firstNameInput;
			newNurse.nurseLastName = lastNameInput;
			newNurse.payRate = payOrInsuranceInput;
			newNurse.nurseRoom = roomNumInput;
			int idIncrement = 1;
			for( int i = 0; i< NurseList.Count; i++)
			{
				if(NurseList[i].nurseLastName == newNurse.nurseLastName)
				{
					idIncrement++;
				}
			}
			if( idIncrement <10)
			{
				newNurse.nurseIdNum = lastNameInput + "00" + idIncrement.ToString();
			}
			if( idIncrement >=10 && idIncrement< 100)
			{
				newNurse.nurseIdNum = lastNameInput + "0" + idIncrement.ToString();
			}
			if( idIncrement >=100)
			{
				newNurse.nurseIdNum = lastNameInput  + idIncrement.ToString();
			}
			NurseList.Add(newNurse);
		}
		else
		{
			Patient newPatient = new Patient();
			newPatient.patientFirstName = firstNameInput;
			newPatient.patientLastName = lastNameInput;
			newPatient.insuranceId = payOrInsuranceInput;
			newPatient.patientRoom = roomNumInput;
			int idIncrement = 1;
			for( int i = 0; i< PatientList.Count; i++)
			{
				if(PatientList[i].patientFirstName == newPatient.patientFirstName)
				{
					idIncrement++;
				}
			}
			if( idIncrement <10)
			{
				newPatient.patientIdNum = firstNameInput + "00" + idIncrement.ToString();
			}
			if( idIncrement >=10 && idIncrement< 100)
			{
				newPatient.patientIdNum = firstNameInput + "0" + idIncrement.ToString();
			}
			if( idIncrement >=100)
			{
				newPatient.patientIdNum = firstNameInput  + idIncrement.ToString();
			}
			PatientList.Add(newPatient);
		}
	}

	// finds a person based off their id and flashes their position on the map
	protected void seePerson(Object sender, EventArgs e)
	{
		if( findPersonHelp)
		{
			helpText1 = "Nurse or Patient?";
			helpText2 = "ID number";
			helpText3 = "Empty";
			helpText4 = "Empty";
			helpText5 = "Empty";
			inputHelp = true;
			findPersonHelp= false;
	 		findRoomHelp = true;
	 		changeRoomHelp = true;
	 		changeSalaryHelp = true;
	 		viewInfoHelp = true;
	 		viewNursesHelp = true;
	 		requestStockHelp = true;
			helpText = true;
			Invalidate();
		}
		else
		{
		string positionInfo = positionInput.Text;
		string IdInfo = firstNameInput.Text;
		 roomInfo = " ";
		if( positionInfo == "Nurse" || positionInfo == "nurse")
		{
			for(int i = 0; i< NurseList.Count; i++)
			{
				if(NurseList[i].nurseIdNum == IdInfo)
				{
					roomInfo = NurseList[i].nurseRoom;
				}
			}
		}
		else
		{
			for(int i = 0; i< PatientList.Count; i++)
			{
				if(PatientList[i].patientIdNum == IdInfo)
				{
					roomInfo = PatientList[i].patientRoom;
				}
			}
		}
		if(roomInfo == " ")
		{
			System.Console.WriteLine(" ERROR: {0} with id {1} not found. Please try again", positionInfo, IdInfo);
		}
		else
		{
			System.Console.WriteLine(" {0} with id {1}  found in Room {2}", positionInfo, IdInfo, roomInfo);
			roomInfoHolder= roomInfo;
			FlashClock.Enabled= true;
		}
		positionInput.Text = String.Empty;
		firstNameInput.Text = String.Empty;
		findPersonHelp = true;
		helpText = false;
		Invalidate();
		}
	}

	//Displays all nurses and patients in a particular room, and flashes the room location on the map
	protected void seeRoom(Object sender, EventArgs e)
	{
		if( findRoomHelp)
		{
			helpText1 = "Room Number";
			helpText2 = "Empty";
			helpText3 = "Empty";
			helpText4 = "Empty";
			helpText5 = "Empty";
			inputHelp = true;
			findPersonHelp= true;
	 		findRoomHelp = false;
	 		changeRoomHelp = true;
	 		changeSalaryHelp = true;
	 		viewInfoHelp = true;
	 		viewNursesHelp = true;
	 		requestStockHelp = true;
			helpText = true;
			Invalidate();
		}
		else
		{
		string roomNumFound = positionInput.Text;
		List<string> nurseIdFound = new List<string>();
		List<string> patientIdFound = new List<string>();
		for(int i = 0; i< PatientList.Count; i++)
		{
			if(PatientList[i].patientRoom == roomNumFound)
			{
				patientIdFound.Add(PatientList[i].patientIdNum);
			}
		}
		for(int i = 0; i< NurseList.Count; i++)
		{
			if(NurseList[i].nurseRoom == roomNumFound)
			{
				nurseIdFound.Add(NurseList[i].nurseIdNum);
			}
		}
		for( int i = 0; i< nurseIdFound.Count; i++)
		{
			System.Console.WriteLine(" Nurse with id {0}  is in Room {1}", nurseIdFound[i], roomNumFound);
		}
		for( int i = 0; i< patientIdFound.Count; i++)
		{
			System.Console.WriteLine(" Patient with id {0}  is in Room {1}", patientIdFound[i], roomNumFound);
		}
		roomInfo = roomNumFound;
		roomInfoHolder= roomInfo;
		FlashClock.Enabled = true;
		positionInput.Text = String.Empty;
		findRoomHelp = true;
		helpText = false;
		Invalidate();
		}
	}

	// changes the room location of a patient or nurse
	protected void modifyRoom(Object sender, EventArgs e)
	{
		if( changeRoomHelp)
		{
			helpText1 = "Nurse or Patient";
			helpText2 = "ID Number";
			helpText3 = "New Room Number";
			helpText4 = "Empty";
			helpText5 = "Empty";
			inputHelp = true;
			findPersonHelp= true;
	 		findRoomHelp = true;
	 		changeRoomHelp = false;
	 		changeSalaryHelp = true;
	 		viewInfoHelp = true;
	 		viewNursesHelp = true;
	 		requestStockHelp = true;
			helpText = true;
			Invalidate();
		}
		else
		{
		string positionHolder = positionInput.Text;
		string idNumHolder = firstNameInput.Text;
		string newRoomNum = lastNameInput.Text;
		string oldRoomHolder = " ";
		if(positionHolder == "Nurse" || positionHolder == "nurse")
		{
			for( int i = 0; i < NurseList.Count; i++)
			{
				if ( NurseList[i].nurseIdNum == idNumHolder)
				{
					oldRoomHolder = NurseList[i].nurseRoom;
					Nurse v = NurseList[i];
						v.nurseRoom = newRoomNum;
					NurseList[i] = v;
				}
			}
		}
		else
		{
			for( int i = 0; i < PatientList.Count; i++)
			{
				if ( PatientList[i].patientIdNum == idNumHolder)
				{
					oldRoomHolder = PatientList[i].patientRoom;
					Patient v = PatientList[i];
						v.patientRoom= newRoomNum;
					PatientList[i] = v;
				}
			}
		}
		if( oldRoomHolder == " ")
		{
			System.Console.WriteLine(" ERROR: {0} with id {1}  was not found. Please try again", positionHolder, idNumHolder);
		}
		else
		{
			System.Console.WriteLine(" {0} with id {1}  is now in room {2}, was in room {3}", positionHolder, idNumHolder, newRoomNum, oldRoomHolder);	
			roomInfo= newRoomNum;
			roomInfoHolder = roomInfo;
			FlashClock.Enabled = true;
		}
		positionInput.Text = String.Empty;
		firstNameInput.Text= String.Empty;
		lastNameInput.Text = String.Empty;
		changeRoomHelp = true;
		helpText = false;
		Invalidate();
		}
	}

	// shows all info on a particular nurse or patient
	// ie First/Last Name, Id number, pay or insurance,
	// and current room
	protected void seeInfo(Object sender, EventArgs e)
	{
		if( viewInfoHelp)
		{
			helpText1 = "Nurse or Patient";
			helpText2 = "ID Number";
			helpText3 = "Empty";
			helpText4 = "Empty";
			helpText5 = "Empty";
			inputHelp = true;
			findPersonHelp= true;
	 		findRoomHelp = true;
	 		changeRoomHelp = true;
	 		changeSalaryHelp = true;
	 		viewInfoHelp = false;
	 		viewNursesHelp = true;
	 		requestStockHelp = true;
			helpText = true;
			Invalidate();
		}
		else
		{

			string positionHolder = positionInput.Text;
			string idNumHolder = firstNameInput.Text;
			string roomHolder = " ";
			string firstNameHolder = " ";
			string lastNameHolder= " ";
			string payOrInsuranceHolder= " ";
			if(positionHolder == "Nurse" || positionHolder == "nurse")
			{
				for( int i = 0; i < NurseList.Count; i++)
				{
					if ( NurseList[i].nurseIdNum == idNumHolder)
					{
						firstNameHolder = NurseList[i].nurseFirstName;
						lastNameHolder = NurseList[i].nurseLastName;
						payOrInsuranceHolder = NurseList[i].payRate;
						roomHolder = NurseList[i].nurseRoom;
					}
				}
			}
			else
			{
				for( int i = 0; i < PatientList.Count; i++)
				{
					if ( PatientList[i].patientIdNum == idNumHolder)
					{
						firstNameHolder = PatientList[i].patientFirstName;
						lastNameHolder = PatientList[i].patientLastName;
						payOrInsuranceHolder = PatientList[i].insuranceId;
						roomHolder = PatientList[i].patientRoom;
					}
				}
			}
			if( roomHolder == " ")
			{
				System.Console.WriteLine(" ERROR: {0} with id {1}  was not found. Please try again", positionHolder, idNumHolder);
			}
			else
			{
				System.Console.WriteLine( " {0} with id {1} found. Here is their info:", positionHolder, idNumHolder);
				System.Console.WriteLine( " First Name: {0}", firstNameHolder);
				System.Console.WriteLine( " Last Name: {0}", lastNameHolder);
				System.Console.WriteLine( " Pay or insurance: {0}", payOrInsuranceHolder);
				System.Console.WriteLine( " Room Number: {0}", roomHolder);
			}
			positionInput.Text = String.Empty;
			firstNameInput.Text= String.Empty;
			viewInfoHelp = true;
			helpText = false;
			Invalidate();
		}
	
	}

	//shows all nurses currently in the system
	protected void seeNurses(Object sender, EventArgs e)
	{
		helpText= false;
		Invalidate();
		inputHelp = true;
		findPersonHelp= true;
		findRoomHelp = true;
	 	changeRoomHelp = true;
	 	changeSalaryHelp = true;
	 	viewInfoHelp = true;
	 	viewNursesHelp = true;
	 	requestStockHelp = true;
		System.Console.WriteLine(" Here are all {0} of our nurses" , NurseList.Count);
		for (int i = 0; i< NurseList.Count; i++)
		{
			System.Console.WriteLine("Nurse {0} {1} with ID {2}", NurseList[i].nurseFirstName, NurseList[i].nurseLastName, NurseList[i].nurseIdNum);
		}
	}

	//shows all patients currently in the system
	protected void seePatients(Object sender, EventArgs e)
	{
		helpText= false;
		Invalidate();
		inputHelp = true;
		findPersonHelp= true;
		findRoomHelp = true;
	 	changeRoomHelp = true;
	 	changeSalaryHelp = true;
	 	viewInfoHelp = true;
	 	viewNursesHelp = true;
	 	requestStockHelp = true;
		System.Console.WriteLine(" Here are all {0} of our patients" , PatientList.Count);
		for (int i = 0; i< PatientList.Count; i++)
		{
			System.Console.WriteLine("Patient {0} {1} with ID {2}", PatientList[i].patientFirstName, PatientList[i].patientLastName, PatientList[i].patientIdNum);
		}
	}

	//displays both levels of the map
	protected void seeMap(Object sender, EventArgs e)
	{
		helpText= false;
		Invalidate();
		inputHelp = true;
		findPersonHelp= true;
		findRoomHelp = true;
	 	changeRoomHelp = true;
	 	changeSalaryHelp = true;
	 	viewInfoHelp = true;
	 	viewNursesHelp = true;
	 	requestStockHelp = true;
		DisplayClock.Enabled = true;
		Invalidate();
	}

	//changes the salary of a nurse. Is username and password protected
	protected void modifySalary(Object sender, EventArgs e)
	{
		if( !adminLevel)
		{
		
			if( changeSalaryHelp)
			{
				helpText1 = "Admin ID";
				helpText2 = "Admin Password";
				helpText3 = "Empty";
				helpText4 = "Empty";
				helpText5 = "Empty";
				inputHelp = true;
				findPersonHelp= true;
	 			findRoomHelp = true;
	 			changeRoomHelp = true;
	 			changeSalaryHelp = false;
	 			viewInfoHelp = true;
	 			viewNursesHelp = true;
	 			requestStockHelp = true;
				helpText = true;
				Invalidate();
			}
			else
			{
				if( positionInput.Text == "admin" && firstNameInput.Text == "password")
				{
					System.Console.WriteLine( "Welcome administrator. Admin powers unlocked");
					changeSalary.BackColor = Color.Green;
					requestStock.BackColor = Color.Green;
					positionInput.Text = String.Empty;
					firstNameInput.Text = String.Empty;
					adminLevel = true;
				}
	
				changeSalaryHelp = true;
				helpText = false;
				Invalidate();
			}
		}
		else
		{
			if( changeSalaryHelp)
			{
				helpText1 = "Nurse ID number";
				helpText2 = "New Salary";
				helpText3 = "Empty";
				helpText4 = "Empty";
				helpText5 = "Empty";
				inputHelp = true;
				findPersonHelp= true;
	 			findRoomHelp = true;
	 			changeRoomHelp = true;
	 			changeSalaryHelp = false;
	 			viewInfoHelp = true;
	 			viewNursesHelp = true;
	 			requestStockHelp = true;
				helpText = true;
				Invalidate();
			}
			else
			{
				string idNumHolder = positionInput.Text;
				string newSalaryHolder = firstNameInput.Text;
				string oldSalaryHolder = " ";
					for( int i = 0; i < NurseList.Count ; i++)
					{
						if ( NurseList[i].nurseIdNum == idNumHolder)
						{
							oldSalaryHolder = NurseList[i].payRate;
							Nurse v = NurseList[i];
							v.payRate = newSalaryHolder;
							NurseList[i] = v;
						}
		
					}
					if( oldSalaryHolder == " ")
					{
						System.Console.WriteLine(" ERROR: Nurse with id {0}  was not found. Please try again", idNumHolder);
					}
					else
					{
						System.Console.WriteLine(" Nurse with id {0}  new Salary is {1}, old salary was {2}",  idNumHolder, newSalaryHolder, oldSalaryHolder);	
					}
				
				changeSalaryHelp = true;
				helpText = false;
				positionInput.Text = String.Empty;
				firstNameInput.Text= String.Empty;
				lastNameInput.Text = String.Empty;
				Invalidate();
			}
		}

	}

	//adds a support ticket to the room list to be modified
	//by an outside party
	protected void modifyStock(Object sender, EventArgs e)
	{
		if( !adminLevel)
		{
		
			if( requestStockHelp)
			{
				helpText1 = "Admin ID";
				helpText2 = "Admin Password";
				helpText3 = "Empty";
				helpText4 = "Empty";
				helpText5 = "Empty";
				inputHelp = true;
				findPersonHelp= true;
	 			findRoomHelp = true;
	 			changeRoomHelp = true;
	 			changeSalaryHelp = true;
	 			viewInfoHelp = true;
	 			viewNursesHelp = true;
	 			requestStockHelp = false;
				helpText = true;
				Invalidate();
			}
			else
			{
				if( positionInput.Text == "admin" && firstNameInput.Text == "password")
				{
					System.Console.WriteLine( "Welcome administrator. Admin powers unlocked");
					changeSalary.BackColor = Color.Green;
					requestStock.BackColor = Color.Green;
					positionInput.Text = String.Empty;
					firstNameInput.Text = String.Empty;
					adminLevel = true;
				}
					requestStockHelp = true;
					helpText = false;
					Invalidate();
			}
		}
		else
		{
			if( requestStockHelp)
			{
				helpText1 = "Room Number";
				helpText2 = "Problem Description";
				helpText3 = "Problem Severity";
				helpText4 = "Empty";
				helpText5 = "Empty";
				findPersonHelp= true;
	 			findRoomHelp = true;
	 			changeRoomHelp = true;
	 			changeSalaryHelp = true;
	 			viewInfoHelp = true;
	 			viewNursesHelp = true;
	 			requestStockHelp = false;
				helpText = true;
				Invalidate();
			}
			else
			{
		
				string roomNumberHolder = positionInput.Text;
				string problemDescriptionHolder = firstNameInput.Text;
				string problemSeverityHolder = lastNameInput.Text;
				Room newRoom = new Room();
				newRoom.roomNumber= roomNumberHolder;
				newRoom.roomDescription= problemDescriptionHolder;
				newRoom.roomLevel = problemSeverityHolder;
				RoomList.Add(newRoom);
				System.Console.WriteLine( "Support ticket for Room {0} with description {1} and Severity Level {2} was added.", roomNumberHolder, problemDescriptionHolder, problemSeverityHolder);
				requestStockHelp = true;
				helpText = false;
				positionInput.Text = String.Empty;
				firstNameInput.Text= String.Empty;
				lastNameInput.Text = String.Empty;
				Invalidate();
			}
		}
		
	}


	//display clock for a flashing room. Alternates on and off for 7 counts
	// "flashing" three times.
	protected void flashRefresh(System.Object sender, ElapsedEventArgs evt)
	{
		if(counter < 7)
		{
			if( counter%2== 0)
			{
				Invalidate();
				roomInfo= " ";
				counter++;
			}
			else
			{
				Invalidate();
				roomInfo = roomInfoHolder;
				counter++;
			}
		}
		else
		{
			FlashClock.Enabled= false;
			counter = 0;
			roomInfo = " ";
			roomInfoHolder = " ";
			Invalidate();
		}
			
		
	}

	//displays both levels of the hospital
protected void displayRefresh(System.Object sender, ElapsedEventArgs evt)
	{
		if (counter == 0)
		{
			firstFloor = false;
			secondFloor = true;
			Invalidate();
			counter = 1;
		}
		else
		{
			DisplayClock.Enabled = false;
			counter = 0;
			firstFloor= true;
			secondFloor = false;
			Invalidate();
		}
	}

	protected void exitProgram(Object sender, EventArgs e)
	{
		System.Console.WriteLine("This program will now end");
		Close();
	}
};
