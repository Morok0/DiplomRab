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

namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для WindowNavigationRegistrar.xaml
    /// </summary>
    public partial class WindowNavigationRegistrar : Window
    {
        private readonly User _user;
        public WindowNavigationRegistrar(User user)
        {
            _user = user;
            InitializeComponent();
            FrameRegistrar.Navigate(new RegistrarAddendumPatient(User.Registrar));
            
           
        }

        private void Click_Main(object sender, RoutedEventArgs e)
        {
            FrameRegistrar.Navigate(new Registrar(User.Registrar));
        }

        private void Unwrap_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            }
            else this.WindowState = WindowState.Normal;
        }

        private void ToClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        private void RollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Click_Patient(object sender, RoutedEventArgs e)
        {
            FrameRegistrar.Navigate(new RegistrarAddendumPatient(User.Registrar));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Make(object sender, RoutedEventArgs e)
        {
            FrameRegistrar.Navigate(new RegistrarMakeAnAppointment(User.Registrar));
        }

        private void Click_Verification_Patient(object sender, RoutedEventArgs e)
        {
            FrameRegistrar.Navigate(new RegistrarVerification(User.Registrar));
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

        }
        private void Click_Verification_Visit(object sender, RoutedEventArgs e)
        {
            

        }
        private void Click_Verification_Doctor(object sender, RoutedEventArgs e)
        {
            FrameRegistrar.Navigate(new RegistrarVerificationDoctor(User.Registrar));

        }
    }
}
