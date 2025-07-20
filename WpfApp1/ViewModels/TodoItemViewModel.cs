using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TodoItemViewModel
    {
        public TodoItemViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>()
            {
                new TodoItem { Title = "Fix Bug", Description = "Fix login crash", Priority = PriorityLevel.High },
                new TodoItem { Title = "Email Team", Description = "Weekly status report", Priority = PriorityLevel.Medium },
                new TodoItem { Title = "Water Plants", Description = "Before weekend", Priority = PriorityLevel.Low },
                new TodoItem { Title = "Bring vegetables", Description = "Bring Veggies on weekend", Priority = PriorityLevel.Normal },
            };
        }
        public ObservableCollection<TodoItem> TodoItems { get; set; }
    }
}
