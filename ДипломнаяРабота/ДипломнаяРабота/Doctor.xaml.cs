using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Doctor.xaml
    /// </summary>
    public partial class Doctor : Page
    {
        MainWindow mainWindow = new MainWindow();
        private readonly User _user;
        public Doctor(User user)
        {
           
            _user = user;
            InitializeComponent();
            refresh();
        }
        private void refresh()
        {
            string sconnect = mainWindow.sconnect;
            string sconnecte = mainWindow.sconnect;


            //проверка какой именно сотрудник зашёл 
            string buf;
            string bufLogin = mainWindow.buffLog;
            string bufPassword = mainWindow.buffPass;
            SqlConnection conn = new SqlConnection(sconnecte);
            SqlCommand cmdd = new SqlCommand("Select ТабельныйНомер From Сотрудник Where  Логин=@Логин and Пароль=@Пароль ", conn);
            conn.Open();

            cmdd.Parameters.Add(new SqlParameter("@Логин", bufLogin));
            cmdd.Parameters.Add(new SqlParameter("@Пароль", bufPassword));
            buf = cmdd.ExecuteScalar().ToString();
            conn.Close();

            //вывод информации о сотруднике 
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("Select Имя, Отчество, Фамилия, Телефон, Паспорт, Снилс From Сотрудник WHERE ТабельныйНомер=@ТабельныйНомер    ", con);
            con.Open();

            cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            имяTextBox.Text = dr.GetString(0);
            фамилияTextBox.Text = dr.GetString(1);
            отчествоTextBox.Text = dr.GetString(2);
            телефонTextBox.Text = dr.GetString(3);
            //паспортTextBox.Text = dr.GetInt32(4).ToString();
            //снилсTextBox.Text = dr.GetInt32(5).ToString();
        }
    }
}
