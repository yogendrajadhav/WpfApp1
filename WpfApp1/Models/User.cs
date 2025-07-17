using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.Models
{
    internal class User: ObservableObject
    {
        public string FirstName
        {
            get; set; 

        }
        public string LastName { get; set; }
    }
}
