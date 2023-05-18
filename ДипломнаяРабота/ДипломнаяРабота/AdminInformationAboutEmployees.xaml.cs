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
    /// Логика взаимодействия для AdminInformationAboutEmployees.xaml
    /// </summary>
    public partial class AdminInformationAboutEmployees : Page
    {
        MainWindow mainWindow = new MainWindow();

        private readonly User _user;
        public AdminInformationAboutEmployees(User user)
        {
            _user = user;
            InitializeComponent();
            refreshUser();
            refreshDopTable();

        }
        public void refreshUser()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT ТабельныйНомер, Фамилия, Имя, Отчество FROM Сотрудник ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            User.ItemsSource = dt.AsDataView();
            con.Close();


        }
        public void refreshDopTable()
        {
            string sconnect = mainWindow.sconnect;
            //вытаскиваем табельный номер для удаления
            if (User.SelectedItem is DataRowView row)
            {
                try
                {
                    int id = (int)row[0];
                    string Id = Convert.ToString(row["ТабельныйНомер"]);
                    string buf = Id;
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("SELECT с.ТабельныйНомер, с.Фамилия, с.Имя, с.Отчество, с.Телефон, п.Название, п.Категория, п.Оклад , о.Название, о.НомерКабинета FROM  Сотрудник с JOIN  ПрофессияСотрудник пс on  пс.ТабельныйНомер = с.ТабельныйНомер  JOIN Профессия п on пс.НомерПрофессии = п.НомерПрофессии JOIN ВрачебноеОтделение во on с.ТабельныйНомер = во.ТабельныйНомер JOIN Отделение о on во.НомерОтделения = о.НомерОтделения WHERE с.ТабельныйНомер = @id", con);
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
            refreshDopTable();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            string sql = "SELECT  ТабельныйНомер, Имя, Фамилия, Отчество FROM Сотрудник  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'  ";
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
            User.ItemsSource = dt.AsDataView();
        }
    }
}
