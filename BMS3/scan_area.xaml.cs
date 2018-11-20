using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BMS3
{
    /// <summary>
    /// Логика взаимодействия для scan_area.xaml
    /// </summary>
    public partial class scan_area : Window
    {
        public scan_area()
        {
            InitializeComponent();
        }

        public int lu, ru, ld, rd;

        private void area_form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.ActualHeight;
            //this.ActualWidth;
            lu = (int)this.Top;
            this.Left
        }
    }
}
