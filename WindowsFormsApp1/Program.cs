using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // This is to handle UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // This is for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            Debug.WriteLine(e.Exception.Message);
            log.Error(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
            log.Error((e.ExceptionObject as Exception));
        }
    }
}
