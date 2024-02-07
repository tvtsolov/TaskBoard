using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Models
{
    public class EventLog
    {
        public EventLog(string description)
        {
            Description = description;
            DateTime = DateTime.Now;
        }
        public string Description { get; private set; }
        public DateTime DateTime { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{DateTime}: {Description}");
            return sb.ToString();
        }
    }
}
