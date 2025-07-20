using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1.Helpers
{
    public class PriorityTemplateSelector: DataTemplateSelector
    {
        public DataTemplate HighPriorityTemplate { get; set; }
        public DataTemplate MediumPriorityTemplate { get; set; }
        public DataTemplate LowPriorityTemplate { get; set; }
        public DataTemplate NormalPriorityTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TodoItem todo)
            {
                return todo.Priority switch
                {
                    PriorityLevel.High=> HighPriorityTemplate,
                    PriorityLevel.Medium => MediumPriorityTemplate,
                    PriorityLevel.Low => LowPriorityTemplate,
                    _ => NormalPriorityTemplate

                };
            }

            return base.SelectTemplate(item, container);

        }
    }
}
