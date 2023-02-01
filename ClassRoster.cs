using System;
using System.Collections.Generic;
namespace ClassRoster
{
    class Person
    {
        private String firstName = "";
        private String lastName = "";
        public String FirstName
        {
            get 
            {
                return this.firstName; 
            }
            set
            {
                this.firstName = value;
            }
        }
        public String LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public Person(string firstName, string lastName)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
        }
    }
    class Student : Person
    {
        private string classRank = "";
        public String ClassRank
        {
            get
            {
                return this.classRank;
            }
            set
            {
                this.classRank = value;
            }
        }
        public Student(string firstName, string lastName, string classRank) : base(firstName, lastName)
        {
            this.classRank = ClassRank;

        }
    }
    class Instructor : Person
    {
        private string contactInfo = "";
        public String ContactInfo
        {
            get
            {
                return this.contactInfo;
            }
            set
            {
                this.contactInfo = value;
            }
        }
        public Instructor(string firstName, string lastName, string contactInfo) : base(firstName, lastName)
        {
            this.contactInfo = contactInfo;
        }

    }
    class Program
    {
        static void Main(String[] args)
        { 
            bool endApp = false;
            bool addStudent = true;
            List<Instructor> iRoster = new List<Instructor>();
            List<Student> sRoster = new List<Student>();   
            string check = "";
            string fName = "";
            string lName = "";
            string cInfo = "";
            string cRank = "";
            Console.WriteLine("Hello! Welcome to the C# class roster creater");
            Console.WriteLine("Created By Mitchell Norris");
            Console.WriteLine("-------------------------------------------------");
            while (!endApp)
            {
                Console.WriteLine("Please enter Professors first name");
                fName = Console.ReadLine();
                Console.WriteLine("Please enter Professors last name");
                lName = Console.ReadLine();
                Console.WriteLine("Please enter Professors contact email");
                cInfo = Console.ReadLine();
                Instructor Professor = new Instructor(fName, lName, cInfo);
                Professor.FirstName = fName;
                Professor.LastName = lName;
                Professor.ContactInfo = cInfo;
                iRoster.Add(Professor);
                while(addStudent == true)
                {
                    Console.WriteLine("Please enter Students first name");
                    fName = Console.ReadLine();
                    Console.WriteLine("Please enter Students last name");
                    lName = Console.ReadLine();
                    Console.WriteLine("Please enter Students class rank");
                    cRank = Console.ReadLine();
                    Student student = new Student(fName, lName, cRank);
                    student.FirstName = fName;
                    student.LastName = lName;
                    student.ClassRank = cRank;
                    sRoster.Add(student);
                    Console.WriteLine("To print list type p. To continue type any other character");
                    check = Console.ReadLine();
                    if (check == "p")
                    {
                        addStudent = false;
                    }
                }
                Console.WriteLine("Here is your class roster");
                Console.WriteLine(iRoster[0].FirstName + " " + iRoster[0].LastName + " " + iRoster[0].ContactInfo);
                for(int i = 0; i < sRoster.Count; i++)
                {
                  Console.WriteLine(sRoster[i].FirstName + " " + sRoster[i].LastName + " " + sRoster[i].ClassRank);
                }
                endApp = true;
            }
            return;
        }
    }
}