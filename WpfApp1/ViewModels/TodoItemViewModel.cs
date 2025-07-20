using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Annotations;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TodoItemViewModel: INotifyPropertyChanged
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

            StartProgressCommand = new RelayCommand(RunLongRunningTask);
        }

        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public RelayCommand StartProgressCommand { get; set; } 

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _progress; 

        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value; 
                OnPropertyChanged(nameof(Progress));
            }
        }
         
        private string _status;

        public string Status 
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private void RunLongRunningTask()
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    int current = i;
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Progress = current;
                        Status = $"Progress: {current}";
                        TodoItems.Add(new TodoItem() { Priority = PriorityLevel.Medium, Title = $"Item {current}" });

                    }), DispatcherPriority.Background);

                    Task.Delay(50).Wait(); //simulate work
                  
                }
            });
        }

    }
}
