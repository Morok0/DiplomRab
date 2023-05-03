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
using System.Windows.Shapes;

namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для WindowNavigateFirstEntry.xaml
    /// </summary>
    public partial class WindowNavigateFirstEntry : Window
    {
        private readonly User _user;
        MainWindow mainWindow = new MainWindow();
        public WindowNavigateFirstEntry(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            
            string sconnect = mainWindow.sconnect;  
            string bufAccessRights = "Администратор";
            string ServiceNumber = табельныйНомерTextBox.Text;
            string FirstName = имяTextBox.Text;
            string LastName = фамилияTextBox.Text;
            string MiddleName = отчествоTextBox.Text;
            string Telephone = телефонTextBox.Text;
            string Passport = паспортTextBox.Text;
            string Snils = снилсTextBox.Text;
            string Login = логинTextBox.Text;
            string Password = парольTextBox.Text;
            if (ServiceNumber == null || FirstName == null || LastName == null || MiddleName == null || Telephone == null || Passport == null || Snils == null || Password == null || Login == null || bufAccessRights == null)
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {


                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Сотрудник", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.Add(new SqlParameter("@ТабельныйНомер", ServiceNumber));
                cmdd.Parameters.Add(new SqlParameter("@Имя", FirstName));
                cmdd.Parameters.Add(new SqlParameter("@Фамилия", LastName));
                cmdd.Parameters.Add(new SqlParameter("@Отчество", MiddleName));
                cmdd.Parameters.Add(new SqlParameter("@Телефон", Telephone));
                cmdd.Parameters.Add(new SqlParameter("@Паспорт", Passport));
                cmdd.Parameters.Add(new SqlParameter("@Снилс", Snils));
                cmdd.Parameters.Add(new SqlParameter("@Логин", Login));
                cmdd.Parameters.Add(new SqlParameter("@Пароль", Password));
                cmdd.Parameters.Add(new SqlParameter("@ПраваДоступа", bufAccessRights));
                cmdd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");
                
            }
            MainWindow Win = new MainWindow();
            Win.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           /* // Загрузить данные в таблицу Профессия. Можно изменить этот код как требуется.
            ДипломнаяРабота.ДипломDataSetTableAdapters.ПрофессияTableAdapter дипломDataSetПрофессияTableAdapter = new ДипломнаяРабота.ДипломDataSetTableAdapters.ПрофессияTableAdapter();
            дипломDataSetПрофессияTableAdapter.Fill(дипломDataSet.Профессия);
            System.Windows.Data.CollectionViewSource профессияViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("профессияViewSource")));
            профессияViewSource.View.MoveCurrentToFirst();*/
        }

        private void Button_Click_Information(object sender, RoutedEventArgs e)
        {

        }

        private void фамилияTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
