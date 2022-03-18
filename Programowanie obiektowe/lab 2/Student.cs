using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Student : Person
    {
        protected string group;
        protected List<Task> tasks = new List<Task>();

        public string GetGroup()
        {
            return group;
        }
        public void SetGroup(string group)
        {
            this.group = group;
        }

        public Student(string name, int age, string group) : base(name, age)
        {
            this.group = group;
        }
        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            this.tasks = tasks;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(taskName, taskStatus));
        }
        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }
        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index].SetStatus(taskStatus);
        }
        public string RenderTasks(string prefix = "\t")
        {
            string returnString = "";
            for (int i = 0; i < tasks.Count; i++)
            {
                returnString += "\n" + prefix + tasks[i].ToString();
            }
            return returnString;
        }
        public string ToString()
        {
            return $"Student: {name}, ({age} y.o.)\n Group: {group}\n Tasks:\n" + RenderTasks() + "\n\n";
        }
        public bool Equals(Student student)
        {
            if (student.GetName() == name && student.GetAge() == age)
            {
                return true;
            }
            return false;
        }
        private bool SequenceEqual(List<Task> a, List<Task> b)
        {
            if (a == b)
            {
                return true;
            }
            return false;
        }

    }
}
