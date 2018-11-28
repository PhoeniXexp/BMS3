using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace BMS3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {            
            
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException +=
new UnhandledExceptionEventHandler(AppDomain_CurrentDomain_UnhandledException);

            second_start();

            profile = player.init();
            change_checks(profile);

            ini = new ini("bms");
        }

        public ini ini;

        public scheme profile;

        private static scan_area scan_area_baff;
        private static scan_area scan_area_hp;

        public bool activator = false;        

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

        #region enums and checks
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
            scan_area_baff.Close();
            scan_area_hp.Close();
        }

        private void main_form_Loaded(object sender, RoutedEventArgs e)
        {
            scan_area_baff = new scan_area("baff");
            scan_area_hp = new scan_area("hp");
        }

        private void change_checks(scheme whatdo)
        {
            ch1.IsChecked = whatdo.b1; ch2.IsChecked = whatdo.b2; ch3.IsChecked = whatdo.b3; ch4.IsChecked = whatdo.b4;
            ch1.IsChecked = whatdo.b1; ch1.IsChecked = whatdo.b1; ch1.IsChecked = whatdo.b1; ch1.IsChecked = whatdo.b1;
            chf.IsChecked = whatdo.bf; chv.IsChecked = whatdo.bv; chz.IsChecked = whatdo.bz; chx.IsChecked = whatdo.bx;
            chL.IsChecked = whatdo.bL; chP.IsChecked = whatdo.bP; chPW.IsChecked = whatdo.bPW; chSS.IsChecked = whatdo.bSS;
            chs1.IsChecked = whatdo.bs1; chs2.IsChecked = whatdo.bs2; chs3.IsChecked = whatdo.bs3; chs4.IsChecked = whatdo.bs4;
            chscan.IsChecked = whatdo.bscan;
        }

        private void chscan_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bscan = true;
        }

        private void chscan_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bscan = false;
        }

        private void ch1_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b1 = true;
        }

        private void ch1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b1 = false;
        }

        private void ch2_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b2 = true;
        }

        private void ch2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b2 = false;
        }

        private void ch3_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b3 = true;
        }

        private void ch3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b3 = false;
        }

        private void ch4_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b4 = true;
        }

        private void ch4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.b4 = false;
        }

        private void chf_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bf = true;
        }

        private void chf_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bf = false;
        }

        private void chv_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bv = true;
        }

        private void chv_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bv = false;
        }

        private void chz_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bz = true;
        }

        private void chz_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bz = false;
        }

        private void chx_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bx = true;
        }

        private void chx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bx = false;
        }

        private void chL_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bL = true;
        }

        private void chL_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bL = false;
        }

        private void chP_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bP = true;
        }

        private void chP_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bP = false;
        }

        private void chPW_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bPW = true;
        }

        private void chPW_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bPW = false;
        }

        private void chSS_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bSS = true;
        }

        private void chSS_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bSS = false;
        }

        private void chs1_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs1 = true;
        }

        private void chs1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs1 = false;
        }

        private void chs2_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs2 = true;
        }

        private void chs2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs2 = false;
        }

        private void chs3_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs3 = true;
        }

        private void chs3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs3 = false;
        }

        private void chs4_Checked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs4 = true;
        }

        private void chs4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (player.notinit) profile.bs4 = false;
        }
        #endregion

        private bool area_settings_open = false;

        private void btn_set_area_Click(object sender, RoutedEventArgs e)
        {
            if (area_settings_open)
            {
                scan_area_baff.Hide();
                scan_area_hp.Hide();
                area_settings_open = false;
            }
            else
            {
                scan_area_baff.Show();
                scan_area_hp.Show();
                area_settings_open = true;
            }
        }

        private void btn_activator_Click(object sender, RoutedEventArgs e)
        {
            if (activator)
            {
                activator = false;
                btn_activator.Content = "Start";                
            }
            else
            {
                activator = true;
                btn_activator.Content = "Stop";
                
                new Thread(qwer).Start();                            
            }
        }

        private void qwer()
        {
            string pic = "pics/sb.png";
            if (!File.Exists("pics/sb.png")) return;
            int x = scan_area_baff.X;
            int y = scan_area_baff.Y;
            Point lu = scan_area_baff.lu;

            bool b = true;
            
            while (b)
            {
                if (!activator) b = false;
                var q = match.find(lu, x, y, pic);
                ini.setskill("death", q);
                Dispatcher.Invoke(() =>
                {
                    label.Content = q;
                    if (q > 0.99)
                    {
                        ch4.IsChecked = true;
                    }
                    else
                    {
                        ch4.IsChecked = false;
                    }
                });     
                Thread.Sleep(1000);
            }
            ini.save();
        }
    }
}