using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        public scan_area(string name)
        {
            _name = name;
            InitializeComponent();

            if (name == "hp") area_form.Background = new SolidColorBrush(Color.FromRgb(255, 0, 116));
            
            bool b = ini.iswindow(_name);
            if (b) ini.getparam(_name, ref lu, ref X, ref Y);

            set_location(b);
        }

        private string _name;
        
        public Point lu;
        public int X;
        public int Y;

        private void set_location(bool b)
        {
            if (!b) return;

            area_form.Width = X;
            area_form.Height = Y;
            area_form.Left = lu.X;
            area_form.Top = lu.Y;            
        }
        
        private void area_form_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            X = (int)this.ActualWidth;
            Y = (int)this.ActualHeight;
            lu = new Point(this.Left, this.Top);

            ini.setparam(_name, lu, X, Y);
            this.Close();
        }
    }
}
