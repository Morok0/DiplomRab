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
    /// Логика взаимодействия для WindowNavigationDoctor.xaml
    /// </summary>
    public partial class WindowNavigationDoctor : Window
    {
        private readonly User _user;
        public WindowNavigationDoctor(User user)
        {
            _user = user;
            InitializeComponent();
            FrameDoctor.Navigate(new Doctor(User.Doctor));
            Uri iconUri = new Uri("D://Studia//ДипломнаяРабота//ДипломнаяРабота//Bitmap1.bmp", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }

        private void Click_Main(object sender, RoutedEventArgs e)
        {
            FrameDoctor.Navigate(new Doctor(User.Doctor));
        }

        private void Unwrap_Click(object sender, RoutedEventArgs e)
        {
            ///ТЕБЕ ЭТО НАДО БЕРИ 
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

        private void Click_Reception(object sender, RoutedEventArgs e)
        {
            FrameDoctor.Navigate(new DoctorReception(User.Doctor));
        }

        private void Click_WorkSchedule(object sender, RoutedEventArgs e)
        {
            FrameDoctor.Navigate(new DoctorWorkSchedule(User.Doctor));
        }
        private void Click_MedicalHistory(object sender, RoutedEventArgs e)
        {

        }

        private void Click_ExtractOfTheCertificate(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            
        }
        
    }
}
