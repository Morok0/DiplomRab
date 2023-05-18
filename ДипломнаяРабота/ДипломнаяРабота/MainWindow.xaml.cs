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
using System.Data;
using System.Data.SqlClient;
using Xceed.Words.NET;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xceed.Document.NET;


namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public enum User
        {
        Administrator,
        Doctor,
        Registrar,
        FirstEntry
    }
public partial class MainWindow : Window
    {
        public static string bufLogin="";
        public static string  bufPassword="";
        public string sconnect = "Data Source=DESKTOP-H2UKF4G; Initial Catalog = Диплом; Integrated Security = True";
        public MainWindow()
        {
            InitializeComponent();

            
            //проверка есть ли в бд записи в этой таблице
            string DopPer="";
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("SELECT Логин FROM Сотрудник", con);
            con.Open();
           
            try
            {

                DopPer = cmd.ExecuteScalar().ToString();
                //обработка первого входа в приложение
                if (DopPer != null)
                {
                    this.FirstEntry.Visibility = Visibility.Hidden;
                }
            }
            catch { }
            

           

               
                
            



           
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
          

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Enter_Click(object sender, RoutedEventArgs e)//вход в приложение
        {
           
            //проверка логина и пароля
            SqlConnection con = new SqlConnection(sconnect);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Сотрудник Where Логин='" + Login.Text + "' and Пароль = '" + Password.Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            bufLogin = Login.Text;
            bufPassword = Password.Password;
            
            if (dt.Rows[0][0].ToString() == "1")
            {
                
                //проверка прав доступа
                string buf;

                SqlCommand cmd = new SqlCommand("Select ПраваДоступа From Сотрудник Where  Логин='" + Login.Text + "' and Пароль = '" + Password.Password + "'", con);
                con.Open();
                buf = cmd.ExecuteScalar().ToString();
                con.Close();
                //проверка пользователя
                if (buf == "Администратор")
                {

                    WindowNavigation Winn = new WindowNavigation(User.Administrator);
                    Winn.Show();
                    this.Close();

                }
                else if (buf == "Врач")
                {
                    WindowNavigationDoctor Winn = new WindowNavigationDoctor(User.Doctor);
                    Winn.Show();
                    this.Close();
                }
                else if (buf == "Регистратор")
                {
                    WindowNavigationRegistrar Winn = new WindowNavigationRegistrar (User.Registrar);
                    Winn.Show();
                    this.Close();
                }
                
               

            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
            }
           
           


        }

        private void FirstEntry_Click(object sender, RoutedEventArgs e)
        {
            WindowNavigateFirstEntry Win = new WindowNavigateFirstEntry(User.FirstEntry);
            Win.Show();
            this.Close();
        }

        private void ForgotYourPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В случае если вы забыли пароль или логи просьба обращаться к администратору");
        }
        public string buffLog = bufLogin;
        public string buffPass = bufPassword;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
