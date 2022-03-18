using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    enum TaskStatus
    {
        Waiting,
        Progress,
        Done,
        Rejected
    }
    class Task
    {
        private string name;
        private TaskStatus status;
        public string Name { get => this.name; set => this.name = value; }

        public TaskStatus GetStatus()
        {
            return status;
        }
        public void SetStatus(TaskStatus taskStatus)
        {
            this.status = taskStatus;
        }

        public Task(string name, TaskStatus status)
        {
            this.name = name;
            this.status = status;
        }
        public Task(Task task)
        {
            this.name = task.name;
            this.status = task.status;
        }
        public override string ToString()
        {
            return $"{name} [{status}]";
        }
        public bool Equals(Task task)
        {
            if (task.Name == name && task.GetStatus() == status)
            {
                return true;
            }
            return false;
        }
    }
}
