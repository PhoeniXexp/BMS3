using Interceptor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Keys = Interceptor.Keys;

namespace BMS3
{
    class macro
    {
        private static IntPtr context;
        private static Thread callbackThread;
        private static int device, devk = 3, devm = 11;

        private static bool work = true, mss = false;

        private static event EventHandler<KeyPressedEventArgs> OnKeyPressed;
        private static event EventHandler<MousePressedEventArgs> OnMousePressed;

        private Color color_green = Color.FromRgb(190, 255, 190);
        private Color color_red = Color.FromRgb(230, 160, 230);

        private static MainWindow MainWindow;

        private static scheme profile;

        public static void init(MainWindow mw)
        {
            bool bit = Environment.Is64BitOperatingSystem;
            string path = Environment.CurrentDirectory + "\\";

            MainWindow = mw;
            profile = MainWindow.profile;

            string intors = path + "interceptor.dll";
            string intons = path + "interception.dll";

            if (!((File.Exists(intors)) & (File.Exists(intons))))
            {
                var intor = Properties.Resources.Interceptor32;
                var inton = Properties.Resources.interception32;

                if (bit)
                {
                    intor = Properties.Resources.Interceptor64;
                    inton = Properties.Resources.interception64;
                }

                using (FileStream fs = File.Create(path)) { fs.Write(intor, 0, intor.Length); }
                using (FileStream fs = File.Create(path)) { fs.Write(inton, 0, inton.Length); }
            }
        }

        private static void hook()
        {
            bool s = true;
            bool l1 = true;
            bool l2 = true;

            Stroke stroke = new Stroke();
            //InterceptionDriver.SetFilter(context, InterceptionDriver.IsKeyboard, (Int32)KeyboardFilterMode.All);
            //InterceptionDriver.SetFilter(context, InterceptionDriver.IsMouse, (Int32)MouseFilterMode.All);

            //keyboard: device=3
            //mouse: device=11

            while (InterceptionDriver.Receive(context, device = InterceptionDriver.Wait(context), ref stroke, 1) > 0)
            {
                s = true;
                if (InterceptionDriver.IsMouse(device) > 0)
                {
                    if (l1)
                    {
                        l1 = false;
                        devm = device;
                    }

                    if (OnMousePressed != null)
                    {
                        var args = new MousePressedEventArgs() { X = stroke.Mouse.X, Y = stroke.Mouse.Y, State = stroke.Mouse.State, Rolling = stroke.Mouse.Rolling };
                        OnMousePressed(null, args);

                        if (args.Handled)
                        {
                            continue;
                        }
                        stroke.Mouse.X = args.X;
                        stroke.Mouse.Y = args.Y;
                        stroke.Mouse.State = args.State;
                        stroke.Mouse.Rolling = args.Rolling;
                    }
                }

                if (InterceptionDriver.IsKeyboard(device) > 0)
                {
                    if (l2)
                    {
                        l2 = false;
                        devk = device;
                    }

                    if (stroke.Key.Code == Keys.Tilde)
                    {
                        if (work)
                        {
                            if (profile.bSS)
                            {
                                if (stroke.Key.State == KeyState.Down)
                                {
                                    if (mss == false)
                                    {
                                        m = false;
                                        mss = true;
                                        new Thread(macross).Start();
                                    }
                                }
                                else
                                if (stroke.Key.State == KeyState.Up)
                                {
                                    if (mss == true) { mss = false; }
                                }

                                s = false;
                            }
                        }
                    }



                    if (stroke.Key.Code == Keys.R)
                    {
                        if (work)
                        {
                            if (bpw)
                            {
                                if (stroke.Key.State == KeyState.Up)
                                {
                                    if (m == false)
                                    {
                                        m = true;
                                        if (mt) new Thread(macro_text).Start();
                                        else
                                            new Thread(macro).Start();
                                    }
                                    else
                                    {
                                        m = false;
                                    }
                                }
                            }
                            else
                            {
                                if (stroke.Key.State == KeyState.Down)
                                {
                                    if (m == false)
                                    {
                                        m = true;
                                        if (mt) new Thread(macro_text).Start();
                                        else
                                            new Thread(macro).Start();
                                    }
                                }
                                else
                                if (stroke.Key.State == KeyState.Up)
                                {
                                    if (m == true) { m = false; }
                                }
                            }

                            s = false;
                        }
                    }

                    if (stroke.Key.Code == Keys.Insert)
                    {
                        if (stroke.Key.State == KeyState.E0)
                        {
                            if (pause_exit) Stop();
                            new Thread(timer).Start();
                            new Thread(ch_work).Start();
                            s = false;
                        }
                    }

                    if (stroke.Key.Code == Keys.Enter)
                    {
                        if (stroke.Key.State == KeyState.Down)
                        {
                            if (work == true)
                            {
                                new Thread(ch_work).Start();
                                m = false;
                            }
                        }
                    }

                    if (OnKeyPressed != null)
                    {
                        var args = new KeyPressedEventArgs() { Key = stroke.Key.Code, State = stroke.Key.State };
                        OnKeyPressed(this, args);

                        if (args.Handled)
                        {
                            continue;
                        }
                        stroke.Key.Code = args.Key;
                        stroke.Key.State = args.State;
                    }
                }

                if (s) InterceptionDriver.Send(context, device, ref stroke, 1);
            }

            Stop();
        }

        private void macross()
        {
            while (mss)
            {
                if (mss)
                {
                    if (profile.bSS)
                    {
                        SendKey(Keys.S, KeyState.Down);
                        time(10);
                        SendKey(Keys.S, KeyState.Up);
                        time(10);
                    }
                }
            }
        }


        private void time(int p)
        {
            Thread.Sleep(p);
        }

        private void SendKey(Keys key, KeyState state)
        {
            try
            {
                Stroke stroke = new Stroke();
                KeyStroke keyStroke = new KeyStroke();

                keyStroke.Code = key;
                keyStroke.State = state;

                stroke.Key = keyStroke;

                InterceptionDriver.Send(context, devk, ref stroke, 1);
            }
            catch { Stop(); }
        }

        private void SendMouseEvent(MouseState state)
        {
            try
            {
                Stroke stroke = new Stroke();
                MouseStroke mouseStroke = new MouseStroke();

                mouseStroke.State = state;

                if (state == MouseState.ScrollUp)
                {
                    mouseStroke.Rolling = 120;
                }
                else if (state == MouseState.ScrollDown)
                {
                    mouseStroke.Rolling = -120;
                }

                stroke.Mouse = mouseStroke;

                InterceptionDriver.Send(context, devm, ref stroke, 1);
            }
            catch { Stop(); }
        }

        private void work_change()
        {
            if (work)
            {
                work = false;
                Dispatcher.CurrentDispatcher.Invoke(() => { MainWindow.main_form.Background = new SolidColorBrush(color_red); });
            }
            else
            {
                work = true;
                Dispatcher.CurrentDispatcher.Invoke(() => { MainWindow.main_form.Background = new SolidColorBrush(color_green); });
            }
        }

        public static void Start()
        {
            context = InterceptionDriver.CreateContext();

            if (context != IntPtr.Zero)
            {                
                callbackThread = new Thread(new ThreadStart(hook));
                callbackThread.Priority = ThreadPriority.Highest;
                callbackThread.IsBackground = true;
                callbackThread.Start();
            }
        }

        public static void Stop()
        {
            if (context != IntPtr.Zero)
            {
                InterceptionDriver.DestroyContext(context);
            }
            callbackThread.Abort();
        }
    }
}
