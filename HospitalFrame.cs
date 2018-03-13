//space for comments


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Timers;


public class HospitalFrame : Form
{
	private const int frameWidth=1080;
	private const int frameHeight=720;
	// 1080X720
	private const string titleOfFrame= "Hospital by Marcus Hoertz and Daniel Acevado";
	private Label title = new Label();
	private TextBox inputBox = new TextBox();
	private string roomNumberHolder= "";
	private string idNumberHolder= "";
	private bool isFlashing = false;
	private bool isHigh = false;
	private bool mapShown = false;
	private bool firstFloor = true;
	private bool secondFloor= false;
	private bool room101 = false;
	private bool room102 = false;
	private bool room103 = false;
	private bool room104 = false;
	private bool room105 = false;
	private bool room106 = false;
	private bool room107 = false;
	private bool room108 = false;
	private bool room109 = false;
	private bool room110 = false;
	private bool room201 = false;
	private bool room202 = false;
	private bool room203 = false;
	private bool room204 = false;
	private bool room205 = false;
	private bool room206 = false;
	private bool room207 = false;
	private bool room208 = false;
	private bool room209 = false;
	private bool room210 = false;
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
	private static System.Timers.Timer FlashClock = new System.Timers.Timer();
	private static System.Timers.Timer DisplayClock = new System.Timers.Timer();

	public HospitalFrame()
	{
		Text = "Hospital by Hoertz Acevado";
		System.Console.WriteLine(" windowWidth = {0}. windowHeight = {1}.", frameWidth, frameHeight);
		Size= new Size(frameWidth, frameHeight);
		BackColor= Color.White;
		title.Text = "Hospital by Hoertz Acevado";
		title.Size = new Size(170,18);
		title.Location = new Point(500, 20);
		inputInfo.Text = "Input";
		inputInfo.Size = new System.Drawing.Size(80,20);
		inputInfo.BackColor = Color.Green;
		inputInfo.Location = new Point (80, 600);
		findPerson.Text = "Locate Person";
		findPerson.Size = new System.Drawing.Size(80,20);
		findPerson.BackColor = Color.Green;
		findPerson.Location = new Point (180, 600);
		findRoom.Text = "Find Room";
		findRoom.Size = new System.Drawing.Size(80,20);
		findRoom.BackColor = Color.Green;
		findRoom.Location = new Point (280, 600);
		changeRoom.Text = "Change Room";
		changeRoom.Size = new System.Drawing.Size(80,20);
		changeRoom.BackColor = Color.Green;
		changeRoom.Location = new Point (380, 600);
		viewInfo.Text = "View Info";
		viewInfo.Size = new System.Drawing.Size(80,20);
		viewInfo.BackColor = Color.Green;
		viewInfo.Location = new Point (480, 600);
		viewNurses.Text = "View Nurses";
		viewNurses.Size = new System.Drawing.Size(80,20);
		viewNurses.BackColor = Color.Green;
		viewNurses.Location = new Point (80, 650);
		viewPatients.Text = "View Patients";
		viewPatients.Size = new System.Drawing.Size(80,20);
		viewPatients.BackColor = Color.Green;
		viewPatients.Location = new Point (180, 650);
		viewMap.Text = "View Map";
		viewMap.Size = new System.Drawing.Size(80,20);
		viewMap.BackColor = Color.Green;
		viewMap.Location = new Point (280, 650);
		changeSalary.Text = "Change Salary";
		changeSalary.Size = new System.Drawing.Size(80,20);
		changeSalary.BackColor = Color.Red;
		changeSalary.Location = new Point (380, 650);
		requestStock.Text = "Request Stock";
		requestStock.Size = new System.Drawing.Size(80,20);
		requestStock.BackColor = Color.Red;
		requestStock.Location = new Point (480, 650);
		exit.Text = "Exit";
		exit.Size = new System.Drawing.Size( 60, 20);
		exit.BackColor = Color.Green;
		exit.Location = new Point ( 900, 650);
		inputBox.Location  = new Point(700, 600);
		inputBox.Size = new Size ( 100, 10);
		inputBox.Font = new Font("Arial", 8, FontStyle.Regular);
		inputBox.Text= "";
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
		Controls.Add(inputBox);
		Controls.Add(exit);
		FlashClock.Interval = 30;
		FlashClock.Enabled = false;
		DisplayClock.Interval = 30;
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
		if(firstFloor)
		{
		
		}
		else if (secondFloor)
		{
		}
	}

	protected void newInput(Object sender, EventArgs e)
	{
	
	}

	protected void seePerson(Object sender, EventArgs e)
	{
	
	}

	protected void seeRoom(Object sender, EventArgs e)
	{
	
	}

	protected void modifyRoom(Object sender, EventArgs e)
	{
	
	}

	protected void seeInfo(Object sender, EventArgs e)
	{
	
	}

	protected void seeNurses(Object sender, EventArgs e)
	{
	
	}

	protected void seePatients(Object sender, EventArgs e)
	{
	
	}

	protected void seeMap(Object sender, EventArgs e)
	{
	
	}

	protected void modifySalary(Object sender, EventArgs e)
	{
	
	}

	protected void modifyStock(Object sender, EventArgs e)
	{
	
	}

	protected void flashRefresh(System.Object sender, ElapsedEventArgs evt)
	{
		
	}

protected void displayRefresh(System.Object sender, ElapsedEventArgs evt)
	{
		
	}

	protected void exitProgram(Object sender, EventArgs e)
	{
		System.Console.WriteLine("This program will now end");
		Close();
	}
};
