using System;
using System.Collections.Generic;
namespace ClassRoster
{
    class View
    { 
        private string pfName;
        private string plName;
        private string cInfo;
        private string cRank;
        private string check;
        private string sfName;
        private string slName;
        public View() { 
            string pfName = "";
            string plName = "";
            string sfName = "";
            string slName = "";
            string cInfo = "";
            string cRank = "";
            string check = "";
            intro();
        }
        public string PFName
        {
            get { return pfName; }
            set { pfName = value; }
        }
        public string PLName
        {
            get { return plName; }
            set { plName = value; }
        }
        public string SFName
        {
            get { return sfName; }
            set
            {
                sfName = value;
            }
        }
        public string SLName
        {
            get { return slName; }
            set { slName = value; }
        }
        public string CInfo
        {
            get { return cInfo; }
            set { cInfo = value; }
        }
        public string CRank
        {
            get { return cRank; }
            set { cRank = value; }
        }
        public string Check
        {
            get { return check; }
            set { check = value; }
        }
        public void intro()
        {
            Console.WriteLine("Hello! Welcome to the C# class roster creater");
            Console.WriteLine("Created By Mitchell Norris");
            Console.WriteLine("-------------------------------------------------");
        }
        public void getProfessor()
        {
            Console.WriteLine("Please enter Professors first name");
            PFName = Console.ReadLine();
            Console.WriteLine("Please enter Professors last name");
            PLName = Console.ReadLine();
            Console.WriteLine("Please enter Professors contact email");
            CInfo = Console.ReadLine();
        }
        public void getStudent()
        {
            Console.WriteLine("Please enter Students first name");
            SFName = Console.ReadLine();
            Console.WriteLine("Please enter Students last name");
            SLName = Console.ReadLine();
            Console.WriteLine("Please enter Students class rank");
            CRank = Console.ReadLine();
            Console.WriteLine("To print list type p. To continue type any other character");
            Check = Console.ReadLine();
        }
        public void printList(string a, string b, string c)
        { 
            Console.WriteLine(a + " " + b + " " + c);
        }
        public void ending()
        {
            Console.WriteLine("Here is your class roster");
        }
    }
    class RosterController
    {
       List<Instructor> instructors = new List<Instructor>();
       List<Student> students = new List<Student>();
       private View view;
       private Model model;
        public RosterController()
        {
            view = new View();
            view.getProfessor();
            view.getStudent();
            model = new Model(view.PFName, view.PLName, view.SFName, view.SLName, view.CInfo, view.CRank);
            model.AddProfessor();
            model.AddStudent();
            while (view.Check != "p")
            {
                view.getStudent();
                model.SFirstName = view.SFName;
                model.SLastName = view.SLName;
                model.ClassRank = view.CRank;
                model.AddStudent();
            }
            instructors = model.GetIRoster();
            students = model.GetSRoster();
            view.ending();
            view.printList(instructors[0].FirstName, instructors[0].LastName, instructors[0].ContactInfo);
            for (int i = 0; i < students.Count; i++)
            {
                view.printList(students[i].FirstName, students[i].LastName, students[i].ClassRank);
            }
        }
    }
    class Model
    {
        private bool endApp;
        private bool addStudent;
        private List<Instructor> iRoster = new List<Instructor>();
        private List<Student> sRoster = new List<Student>();
        private string PfirstName;
        private string PlastName;
        private string SfirstName;
        private string SlastName;
        private string contactInfo;
        private string classRank;
        public Model()
        {
            PfirstName = "";
            PlastName = "";
            SfirstName = "";
            SlastName = "";
            contactInfo = "";
            classRank = "";
            endApp = false;
            addStudent = true;
        }
        public Model(string PFName, string PLName, string SFName, string SLName, string CInfo, string CRank)
        {
            PFirstName = PFName;
            PLastName = PLName;
            SfirstName = SFName;
            SlastName = SLName;
            ContactInfo = CInfo;
            ClassRank = CRank;
        }
        public string PFirstName
        {
            get { return PfirstName; }
            set { PfirstName = value; }
        }
        public string PLastName
        {
            get { return PlastName; }
            set { PlastName = value; }
        }
        public string SFirstName
        {
            get { return SfirstName; }
            set { SfirstName = value; }
        }
        public string SLastName
        {
            get { return SlastName; }
            set { SlastName = value; }
        }
        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }
        public string ClassRank
        {
            get { return classRank; }
            set { classRank = value; }
        }
        public void AddProfessor()
        {
            Instructor professor = new Instructor(PFirstName, PLastName, ContactInfo);
            professor.FirstName = PFirstName;
            professor.LastName = PLastName;
            professor.ContactInfo = ContactInfo;
            iRoster.Add(professor);
        }
        public void AddStudent()
        {
            Student student = new Student(SFirstName, SLastName, ClassRank);
            student.FirstName = SFirstName;
            student.LastName = SLastName;
            student.ClassRank = ClassRank;
            sRoster.Add(student);
        }
        public List<Instructor> GetIRoster()
        {
            return iRoster;
        }
        public List<Student> GetSRoster()
        {
            return sRoster;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            RosterController controller = new RosterController();
        }
    }
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
            this.firstName = firstName;
            this.lastName = lastName;
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
}