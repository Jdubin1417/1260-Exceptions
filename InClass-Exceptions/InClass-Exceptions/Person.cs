using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Exceptions
{
    public class Person
    {
        public string Name { get; set; }

		private int _age;

		public int Age
		{
			get { return _age; }
			set 
			{
				if (value > 0)
				{
                    _age = value;
                }
				else
				{
                    //throw new AgeException("Age cannot be less than or equal to zero.");
                    throw new Exception("Age cannot be less than or equal to zero.");
                }
            }
		}

		public Person()
		{
			Name = "Bob";
			Age = 33;
		}

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			string info = "";

			info += $"\nName: {Name}";
			info += $"\nAge: {Age}";

			return info;
		}
	}
}
