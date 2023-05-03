using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для PageFirstEntry.xaml
    /// </summary>
    public partial class PageFirstEntry : Page
    {

        MainWindow mainWindow = new MainWindow();
        public PageFirstEntry()
        {
            InitializeComponent();


        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            //полностью изменить
            string sconnect = mainWindow.sconnect;
            string Login = логинTextBox.Text;
            string Password = парольTextBox.Text;
            string AccessКights = "Администратор";
            string ID = "2";
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("INSERT_ПервыйВход", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@номерПользователя", ID));
            cmd.Parameters.Add(new SqlParameter("@Логин", Login));
            cmd.Parameters.Add(new SqlParameter("@Пароль", Password));
            cmd.Parameters.Add(new SqlParameter("@ПраваДоступа", AccessКights));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Запись добавлена");
            Content = null;
            WindowNavigation Win = new WindowNavigation(User.FirstEntry);
            Win.Show();
            


        }
    }
}

