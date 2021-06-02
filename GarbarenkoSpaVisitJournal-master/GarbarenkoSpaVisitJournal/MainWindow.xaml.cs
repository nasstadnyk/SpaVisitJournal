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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ButtonsNavigation;
using GarbarenkoSpaVisitJournal.Models;

namespace GarbarenkoSpaVisitJournal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _app;
        private WindowControlManager windowmanager;
        public MainWindow()
        {
            _app = ((App)Application.Current);
            InitializeComponent();
            windowmanager = new WindowControlManager();
            WelcomeLabel.Content = $"Раді вас бачити, {Environment.UserName}";
            DateLabel.Content = $"{DateTime.Now.DayOfWeek.ToString()} {DateTime.Now.Date.Day.ToString()}";
            foreach (VisitType type in _app.viewModel.contextJson.VisitType.ToList())
            {
                cmbBox_VisitType.Items.Add(type.VisitTypeName);
            }

            RefreshDataTable();
        }
        private void RefreshDataTable()
        {
            ErrorLabel.Visibility = Visibility.Hidden;
            UsersTable.ItemsSource = null;
            UsersTable.ItemsSource = _app.viewModel.contextJson.Clients.ToList();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            windowmanager.MaximazeWindow(Window.GetWindow(this));
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            windowmanager.MinimizeWindow(Window.GetWindow(this));
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            windowmanager.QuitButton(Window.GetWindow(this));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            windowmanager.WindowDragMove(sender, e, Window.GetWindow(this));
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            _app.viewModel.dataService.Add(_app.viewModel.contextJson, txtBox_FirstName.Text, txtBox_SecondName.Text, txtBox_ThirdName.Text, _app.viewModel.contextJson.VisitType[(int)cmbBox_VisitType.SelectedIndex + 1], (bool)chkBox_IsClient.IsChecked, (DateTime)DateTimePicker.Value);
            RefreshDataTable();
            HideInfo();
            try
            {
                
            }
            catch
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }

        private void ClearTextValues()
        {
            lbl_ID.Content = "*";
            txtBox_FirstName.Text = "";
            txtBox_SecondName.Text = "";
            txtBox_ThirdName.Text = "";
            cmbBox_VisitType.SelectedIndex = 1;
            chkBox_IsClient.IsChecked = false;
            DateTimePicker.Value = DateTime.Now;
        }
        private void UsersTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clients selectedclient = (Clients)UsersTable.SelectedItem;
                if (selectedclient == null)
                {
                    ClearTextValues();
                }
                else
                {
                    lbl_ID.Content = selectedclient.id;
                    txtBox_FirstName.Text = selectedclient.FirstName;
                    txtBox_SecondName.Text = selectedclient.SecondName;
                    txtBox_ThirdName.Text = selectedclient.ThirdName;
                    cmbBox_VisitType.SelectedIndex = (int)selectedclient.VisitTypeId - 1;
                    chkBox_IsClient.IsChecked = selectedclient.IsClinet;
                    DateTimePicker.Value = selectedclient.VisitDateTime;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ignoring: {ex}");
            }
        }
        private void HideInfo()
        {
            UsersTable.Columns[0].IsReadOnly = true;
            UsersTable.Columns[5].IsReadOnly = true;
            UsersTable.Columns[7].IsReadOnly = true;
            UsersTable.Columns[4].Visibility = Visibility.Hidden;
            UsersTable.Columns[5].Visibility = Visibility.Hidden;
        }
        private void UsersTable_Loaded(object sender, RoutedEventArgs e)
        {
            UsersTable.Columns[0].IsReadOnly = true;
            UsersTable.Columns[5].IsReadOnly = true;
            UsersTable.Columns[7].IsReadOnly = true;
            UsersTable.Columns[4].Visibility = Visibility.Hidden;
            UsersTable.Columns[5].Visibility = Visibility.Hidden;

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Clients selectedclient = (Clients)UsersTable.SelectedItem;
            if (selectedclient == null)
            {

            }
            else
            {
                _app.viewModel.dataService.Remove(_app.viewModel.contextJson, (Clients)UsersTable.SelectedItem);
                RefreshDataTable();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

                Clients selectedclient = (Clients)UsersTable.SelectedItem;
                if (selectedclient == null)
                {
                    
                }
                else
                {
                    selectedclient.FirstName = txtBox_FirstName.Text;
                    selectedclient.SecondName =txtBox_SecondName.Text;
                    selectedclient.ThirdName = txtBox_ThirdName.Text;
                    selectedclient.VisitTypeId = cmbBox_VisitType.SelectedIndex+1;
                    selectedclient.IsClinet = (bool)chkBox_IsClient.IsChecked;
                    selectedclient.VisitDateTime = (DateTime)DateTimePicker.Value;
                }
                RefreshDataTable();
                HideInfo();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextValues();
        }
    }
}
