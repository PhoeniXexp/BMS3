using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMS3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            second_start();

            profile = new scheme();
        }

        private scheme profile;

        private void second_start()
        {
            Process proc = Process.GetCurrentProcess();
            int curProc = proc.Id;
            Process[] procs = Process.GetProcessesByName("BMS3");
            foreach (Process pr in procs)
            {
                if (pr.Id != curProc)
                {
                    IntPtr hwnd = pr.MainWindowHandle;
                    if (hwnd.ToInt32() == 0) hwnd = FindWindowByCaption(IntPtr.Zero, main_form.Title);
                    ShowWindow(hwnd, ShowWindowCommands.Restore);

                    Process.GetCurrentProcess().Kill();
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        enum ShowWindowCommands
        {
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            Hide = 0,
            /// <summary>
            /// Activates and displays a window. If the window is minimized or 
            /// maximized, the system restores it to its original size and position.
            /// An application should specify this flag when displaying the window 
            /// for the first time.
            /// </summary>
            Normal = 1,
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,
            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            Maximize = 3, // is this the right value?
                          /// <summary>
                          /// Activates the window and displays it as a maximized window.
                          /// </summary>       
            ShowMaximized = 3,
            /// <summary>
            /// Displays a window in its most recent size and position. This value 
            /// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
            /// the window is not activated.
            /// </summary>
            ShowNoActivate = 4,
            /// <summary>
            /// Activates the window and displays it in its current size and position. 
            /// </summary>
            Show = 5,
            /// <summary>
            /// Minimizes the specified window and activates the next top-level 
            /// window in the Z order.
            /// </summary>
            Minimize = 6,
            /// <summary>
            /// Displays the window as a minimized window. This value is similar to
            /// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
            /// window is not activated.
            /// </summary>
            ShowMinNoActive = 7,
            /// <summary>
            /// Displays the window in its current size and position. This value is 
            /// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
            /// window is not activated.
            /// </summary>
            ShowNA = 8,
            /// <summary>
            /// Activates and displays the window. If the window is minimized or 
            /// maximized, the system restores it to its original size and position. 
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,
            /// <summary>
            /// Sets the show state based on the SW_* value specified in the 
            /// STARTUPINFO structure passed to the CreateProcess function by the 
            /// program that started the application.
            /// </summary>
            ShowDefault = 10,
            /// <summary>
            ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
            /// that owns the window is not responding. This flag should only be 
            /// used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimize = 11
        }

        private void main_form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void main_form_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ch1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ch1_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ch2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ch2_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ch3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ch3_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ch4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ch4_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chf_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chf_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chv_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chv_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chz_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chz_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chx_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chx_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chL_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chL_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chP_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chP_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chPW_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chPW_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chSS_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chSS_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chs1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chs1_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chs2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chs2_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chs3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chs3_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chs4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chs4_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            scan_area w1 = new scan_area();
            w1.Show();
        }
    }
}
