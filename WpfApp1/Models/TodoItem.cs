using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class TodoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public PriorityLevel Priority { get; set; } 
        public TodoItem() { }

    }

    public enum PriorityLevel
    {
        Normal,   
        High,
        Medium,
        Low
    }
}
