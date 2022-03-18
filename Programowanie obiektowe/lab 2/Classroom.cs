using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Classroom
    {
        private string name;
        private Person[] persons;
        public string Name { get => this.name; set => this.name = value; }

        public Classroom(string name, Person[] persons)
        {
            this.name = name;
            this.persons = persons;
        }

        public override string ToString()
        {
            string returnString = $"Classromm: {name}\n\n";
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i] is Student)
                {
                    Student student = (Student)persons[i];
                    returnString += student.ToString();
                }
                else if (persons[i] is Teacher)
                {
                    Teacher teacher = (Teacher)persons[i];
                    returnString += teacher.ToString();
                }
                else
                {
                    returnString += persons[i].ToString();
                }
            }
            return returnString;
        }
    }
}
