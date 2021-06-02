using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ButtonsNavigation
{
    public class WindowControlManager
    {
        public void QuitButton(Window window)
        {
            if (MessageBox.Show($"Ви дійсно бажаєте вийти ?", "Вийти?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No)
            == MessageBoxResult.Yes)
            {
                window.Close();
            }
        }
        public void WindowDragMove(object sender, MouseButtonEventArgs e, Window window)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
            }
        }
        public void MinimizeWindow(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        public void MaximazeWindow(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.WindowState = WindowState.Normal;
                Application.Current.MainWindow.Width = 1280;
                Application.Current.MainWindow.Height = 720;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
