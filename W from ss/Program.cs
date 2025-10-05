#region Third

//using System;
//using System.Diagnostics;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading;

//class Program
//{
//    [DllImport("user32.dll")]
//    private static extern IntPtr GetForegroundWindow();

//    [DllImport("user32.dll")]
//    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

//    [DllImport("user32.dll")]
//    private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

//    static void Main()
//    {
//        Console.WriteLine("Activity Logger started...");

//        string lastApp = "";
//        DateTime lastSwitch = DateTime.Now;

//        while (true)
//        {
//            string activeApp = GetActiveWindowInfo();

//            if (activeApp != lastApp)
//            {
//                DateTime now = DateTime.Now;
//                if (!string.IsNullOrEmpty(lastApp))
//                {
//                    TimeSpan duration = now - lastSwitch;
//                    Console.WriteLine($"[{lastSwitch}] -> [{now}] : {lastApp} (Used {duration.TotalSeconds:F0} sec)");
//                }

//                lastApp = activeApp;
//                lastSwitch = now;
//            }

//            Thread.Sleep(1000);
//        }
//    }

//    static string GetActiveWindowInfo()
//    {
//        const int nChars = 256;
//        StringBuilder buff = new StringBuilder(nChars);

//        IntPtr handle = GetForegroundWindow();
//        if (GetWindowText(handle, buff, nChars) > 0)
//        {
//            GetWindowThreadProcessId(handle, out int processId);
//            string processName = Process.GetProcessById(processId).ProcessName;
//            return $"{processName} - {buff}";
//        }
//        return null;
//    }
//}

#endregion





#region Second

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms; // Add reference

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Screenshot app started (Press Ctrl+C to stop)...");

        while (true)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filename = $"screenshot_{timestamp}.png";

            TakeScreenshot(filename);
            Console.WriteLine($"Saved: {filename}");

            Thread.Sleep(5000); // 5 seconds
        }
    }

    static void TakeScreenshot(string filename)
    {
        Rectangle bounds = Screen.PrimaryScreen.Bounds;

        using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            bitmap.Save(filename, ImageFormat.Png);
        }
    }
}

#endregion

#region default
//namespace W_from_ss
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            Application.Run(new Form1());
//        }
//    }
//}
#endregion

#region First

//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Threading;
//using System.Windows.Forms; // Add reference

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Screenshot app started (Press Ctrl+C to stop)...");

//        int counter = 1;
//        while (true)
//        {
//            string filename = $"screenshot_{counter}.png";
//            TakeScreenshot(filename);
//            Console.WriteLine($"Saved: {filename}");
//            counter++;

//            Thread.Sleep(5000); // 5 seconds
//        }
//    }

//    static void TakeScreenshot(string filename)
//    {
//        Rectangle bounds = Screen.PrimaryScreen.Bounds;

//        using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
//        {
//            using (Graphics g = Graphics.FromImage(bitmap))
//            {
//                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
//            }

//            bitmap.Save(filename, ImageFormat.Png);
//        }
//    }
//}
#endregion