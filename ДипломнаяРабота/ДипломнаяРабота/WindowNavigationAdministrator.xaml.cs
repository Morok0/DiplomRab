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
    /// Логика взаимодействия для WindowNavigation.xaml
    /// </summary>
    
    public partial class WindowNavigation : Window
    {
        private readonly User _user;
        public WindowNavigation(User user)
        {
            _user = user;
            InitializeComponent();
            if(user == ДипломнаяРабота.User.Administrator)
            {
                Frame.Navigate(new AdminAddendum(ДипломнаяРабота.User.Administrator));
            }
            /*
            else if(user == ДипломнаяРабота.User.Administrator)
            {
                Frame.Navigate(new Administrator(ДипломнаяРабота.User.Administrator));
            }*/
            Uri iconUri = new Uri("D://Studia//ДипломнаяРабота//ДипломнаяРабота//Bitmap1.bmp", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

        }
        private void Click_Addendum_Verification(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AdminInformationAboutEmployees(ДипломнаяРабота.User.Administrator));

        }

        private void Click_Main(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Administrator(ДипломнаяРабота.User.Administrator));
          
        }

        private void Click_User(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AdminAddendum(ДипломнаяРабота.User.Administrator));
           ;
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

        /*private void Addendum_Professions_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AdminAddendumProfessions(User.Administrator));
            
        }

        private void Addendum_Department_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AdminAddendumDepartment(User.Administrator));
        }*/

        private void Click_Addendum(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AdminDistribution(ДипломнаяРабота.User.Administrator));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
