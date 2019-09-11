using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1___Simple_Class
{
    enum  HairColor
    {
        None,
        Black,
        Brown,
        Blonde,
        Red,
        Grey,
        Weird
    }

    enum Gender
    {
        NoneOfYourDamnBusiness,
        Male,
        Female,
        Both,
        Other,
        Indeterminate
    }

  
    class Person
    {
        //Backing store
        string m_FirstName;
        string m_LastName;
        uint m_ID;
        DateTime m_Birthdate;
        double m_Height; //m
        double m_Weight; //kg
        HairColor m_HairColour;
        Gender m_Gender;

        static string m_Species;

        //Constructors (ctor)

        static Person()
        {
            m_Species = "Homo Sapiens Sapiens";
        }

        public Person()
        {
            m_FirstName = "J.";
            m_LastName = "Doe";
            m_ID = 0;
            m_Birthdate = DateTime.UtcNow;
            m_Height = 0;
            m_Weight = 0;
            m_HairColour = HairColor.None;
            m_Gender = Gender.NoneOfYourDamnBusiness;
        }

        public Person(string fName, string lName, Gender gender, uint id) : this()
        {
            m_FirstName = fName;
            m_LastName = lName;
            m_Gender = gender;
            m_ID = id;
        }

        public Person(string fName, string lName, DateTime birthDate, Gender gender, uint id)
            : this(fName,lName,gender,id)
        {
            if(birthDate < DateTime.UtcNow)
                m_Birthdate = birthDate;
        }

        //Properties (Accessors + Mutators) (getters and setters or asor, mtor) 

        //Static accessor (shared by all objects) (read only in this case, no setter)
        public static string Species 
        {
            get { return m_Species; }
        }

        public double Height
        {
            get { return m_Height; }
            set { m_Height = value > 0 ? value : 0; }
        }

        public double Weight
        {
            get { return m_Weight; }
            set { m_Weight = value > 0 ? value : 0; }
        }


        public string Name
        {
            get => $"{m_FirstName} {m_LastName}";
        }

        public uint ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }


        //Methods

        public string SetName(string fname, string lname)
        {
            m_FirstName = fname;
            m_LastName = lname;
            return Name;
        }

        public override string ToString()
        {
            return $"{Name} ({ID})";
        }
    }
}
