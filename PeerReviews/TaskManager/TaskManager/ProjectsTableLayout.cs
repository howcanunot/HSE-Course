using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagerLibrary;
using TaskManagerLibrary.Tasks;

namespace TaskManager
{
    /// <summary>
    /// Класс реализует индексатор для элемента tablelayoutpanel.
    /// Особого смысла в нем не было, просто немного удобнее.
    /// </summary>
    public class ProjectsTableLayout : TableLayoutPanel
    {
        public Control this[int row, int column]
        {
            get => this.GetControlFromPosition(column, row);
            set 
            {
                if (value.Name != "")
                {
                    this.Controls.Add(value, column, row);
                    return;
                }
                this.Controls.Remove(this[row, column]);
                this.Controls.Add(value, column, row);
            }
        }
    }
}
