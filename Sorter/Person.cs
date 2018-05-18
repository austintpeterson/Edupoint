using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorter
{
    class Person
    {
        private string fname;
        private string lname;

        //const
        public Person(string line)
        {
            //handles variable size whitespace
            var name = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            //if only one name on line, assign as last name (Marr)
            if (name.Length == 1)
            {
                fname = "";
                lname = name[0];
            }
            else
            {
                fname = name[0];
                lname = name[1];
            }
        }

        //getters
        public string getfName()
        {
            return fname;
        }

        public string getlName()
        {
            return lname;
        }
    }
}
