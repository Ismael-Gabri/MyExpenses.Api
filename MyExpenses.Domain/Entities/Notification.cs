using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Entities
{
    public class Notification
    {
        public Notification(string name, string note)
        {
            Name = name;
            Note = note;
        }

        public string Name { get; private set; }
        public string Note { get; private set; }
    }
}
