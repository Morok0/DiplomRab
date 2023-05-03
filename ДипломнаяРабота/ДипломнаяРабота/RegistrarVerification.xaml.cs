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
    /// Логика взаимодействия для RegistrarVerification.xaml
    /// </summary>
    public partial class RegistrarVerification : Page
    {
        MainWindow mainWindow = new MainWindow();
        public static string buf;
        private readonly User _user;
        public RegistrarVerification(User user)
        {
            _user = user;
            InitializeComponent();
            refresh();
            DopRefresh();


        }
        public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT НомерПациента, Фамилия, Имя, Отчество, Паспорт, Полис, Снилс, Телефон FROM Пациент ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableP.ItemsSource = dt.AsDataView();
            con.Close();



        }
        public void DopRefresh()
        {
            string sconnect = mainWindow.sconnect;
         
            if (TableP.SelectedItem is DataRowView row)
            {
                try
                {
                    int id = (int)row[0];
                    string Id = Convert.ToString(row["НомерПациента"]);
                    buf = Id;
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("SELECT з.НомерЗаписи, з.Время, з.Дата, з.НомерКабинета, с.Фамилия, с.Имя, с.Отчество, пр.Название   FROM  ЗаписьНаПриём з JOIN Пациент п on  з.НомерПациент = п.НомерПациента  JOIN Сотрудник с on з.ТабельныйНомер = с.ТабельныйНомер JOIN  ПрофессияСотрудник пс on пс.ТабельныйНомер = с.ТабельныйНомер JOIN Профессия пр on пр.НомерПрофессии = пс.НомерПрофессии  WHERE п.НомерПациента=@id", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", buf));
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    DopTable.ItemsSource = dt.AsDataView();
                }
                catch
                {

                }
            }
            
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            
            DopRefresh();


        }
        private void DataGridVerification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGridVerificationDop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Фамилия.Text;
            string surname = Фамилия.Text;
            string middleName = Фамилия.Text;
            string text = Фамилия.Text; // получаем текст из TextBox
            string[] words = text.Split(' '); // разбиваем текст на слова по пробелу
            if (words.Length > 2) // проверяем, что введено хотя бы два слова
            {
                string Surname = words[0];
                string Name = words[1];
                string MiddleName = words[2];
                name = Name;
                surname = Surname;
                middleName = MiddleName;
            }
            //MessageBox.Show(surname);
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT  НомерПациента, Фамилия, Имя, Отчество, Паспорт, Полис, Снилс, Телефон FROM Пациент  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'   ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@surname", surname));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@middleName", middleName));
            SqlDataReader dr = cmd.ExecuteReader();
            //результат запроса суем в таблицу
            dt.Load(dr);
            //заполняем datagridview - (поле данных...где выводится результат поиска)
            TableP.ItemsSource = dt.AsDataView();

        }
    }
}
