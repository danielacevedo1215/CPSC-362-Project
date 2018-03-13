using System;
using System.Windows.Forms;

public class HospitalMain
{
	public static void Main()
	{
		System.Console.WriteLine("The graphics program will begin now.");
		HospitalFrame HospitalFrameApplication= new HospitalFrame();
		Application.Run(HospitalFrameApplication);
		System.Console.WriteLine("This graphics program has finished. Bye.");
	} // end of the main
}; // End of drawShapesMain class
