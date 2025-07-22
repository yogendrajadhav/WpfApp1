using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;
using WpfApp1.Helpers;

namespace WpfApp1.ViewModels
{
    public class ParentViewModel : INotifyPropertyChanged
    {
        private string _childData;
        public string ChildData
        {
            get => _childData;
            set
            {
                if (_childData != value)
                {
                    _childData = value;
                    OnPropertyChanged(nameof(ChildData));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
