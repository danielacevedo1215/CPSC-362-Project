#CPSC 362 Project Python 3.6
import sqlite3
conn = sqlite3.connect("hospital.db")
c = conn.cursor()

c.execute("""CREATE TABLE PATIENT
	(Name VARCHAR(30) NOT NULL,
	ID INT NOT NULL,
	Insurance VARCHAR(30) NOT NULL,
	Primary_Doctor_ID INT NOT NULL,
	Bdate DATE NOT NULL,
	Checkin_time TIMESTAMP NOT NULL,
	Nurse VARCHAR(30),
	Checkout_time TIMESTAMP,
	Number_of_Procedures INT NOT NULL);""")
c.execute("""CREATE TABLE NURSE
        (Name VARCHAR(30) NOT NULL,
	Salary INT NOT NULL,
	Checkin_time TIMESTAMP NOT NULL,
	Checkout_time TIMESTAMP,
	CONSTRAINT Patients FOREIGN KEY(Name) REFERENCES PATIENT(Name));""")
c.execute("SELECT * FROM PATIENT;")
print(c.fetchall())
c.execute("SELECT * FROM NURSE;")
print(c.fetchall())
conn.close()
