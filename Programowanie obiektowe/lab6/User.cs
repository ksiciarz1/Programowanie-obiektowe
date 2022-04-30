using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public User(string name, string role, int age, int[] marks, DateTime? createdAt = null, DateTime? removedAt = null)
        {
            Name = name;
            Role = role;
            Age = age;
            Marks = marks;
            CreatedAt = createdAt;
            RemovedAt = removedAt;
        }
    }
}
