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
        public string Group { get => this.group; set => this.group = value; }

        public Student(string name, int age, string group) : base(name, age)
        {
            this.group = group;
        }
        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            List<Task> tasksList = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasksList.Add(new Task(tasks[i]));
            }
            this.tasks = tasksList;
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
            // https://dirask.com/snippets/java/Java+optimal+way+to+join+Strings
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < tasks.Count; i++)
            {
                builder.Append("\n" + prefix + $"{i + 1}. {tasks[i]}");
            }
            return builder.ToString();
        }
        public override string ToString()
        {
            return $"Student: {name}, ({age} y.o.)\n Group: {group}\n Tasks:\n" + RenderTasks() + "\n\n";
        }
        public bool Equals(Student student)
        {
            // https://dirask.com/posts/C-NET-compare-strings-pORJwD
            if (Object.Equals(student.Name, name) && Object.Equals(student.Age, age))
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
