using System;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace YZYAntiVirus
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("UI异常: " + e.Exception.Message + "\n\n" + e.Exception.StackTrace, "应用程序错误");
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            string message = exception?.Message ?? "未知错误";
            string stackTrace = exception?.StackTrace ?? "无堆栈跟踪信息";
            MessageBox.Show("非UI异常: " + message + "\n\n" + stackTrace, "应用程序错误");
        }
    }
}

