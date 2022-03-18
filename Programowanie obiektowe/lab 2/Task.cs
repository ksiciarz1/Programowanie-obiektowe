using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Task
    {
        private string name;
        private TaskStatus status;
        public enum TaskStatus
        {
            Waiting,
            Progress,
            Done,
            Rejected
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
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
        public string ToString()
        {
            return $"{name}: {status}";
        }
        public bool Equals(Task task)
        {
            if (task.GetName() == name && task.GetStatus() == status)
            {
                return true;
            }
            return false;
        }
    }
}
