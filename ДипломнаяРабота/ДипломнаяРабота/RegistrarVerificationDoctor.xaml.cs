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
    /// Логика взаимодействия для RegistrarVerificationDoctor.xaml
    /// </summary>
    public partial class RegistrarVerificationDoctor : Page
    {
        MainWindow mainWindow = new MainWindow();
        private readonly User _user;
        public RegistrarVerificationDoctor(User user)
        {
            _user = user;
            InitializeComponent();
            refreshDoctor();
        }
        public void refreshDoctor()
        {
            string sconnect = mainWindow.sconnect;
            //отображение таблицы с пациентами 
            SqlConnection scon = new SqlConnection(sconnect);
            string sql = "SELECT с.ТабельныйНомер, с.Фамилия, с.Имя, с.Отчество, п.Название  FROM  ПрофессияСотрудник пс JOIN Сотрудник с on  пс.ТабельныйНомер = с.ТабельныйНомер  JOIN Профессия п on пс.НомерПрофессии = п.НомерПрофессии   WHERE с.ПраваДоступа='Врач'";
            scon.Open();
            DataTable dt = new DataTable();
            SqlCommand scmd = new SqlCommand(sql, scon);
            SqlDataAdapter da = new SqlDataAdapter(scmd);
            da.Fill(dt);
            TableDoctor.ItemsSource = dt.AsDataView();
            scon.Close();

        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;


            DopRefreshDoctor();
            DopRefresh();
        }
        public void DopRefreshDoctor()
        {
            string sconnect = mainWindow.sconnect;

            if (TableDoctor.SelectedItem is DataRowView row)
            {
                try
                {
                    int id = (int)row[0];
                    string Id = Convert.ToString(row["ТабельныйНомер"]);
                    string buf = Id;
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("SELECT н.ДеньНедели, в.НачалоРаботы, в.КонецРаботы, в.Выходной  FROM  График г JOIN Сотрудник с on  г.ТабельныйНомер = с.ТабельныйНомер  JOIN Время в on г.НомерВремени = в.НомерВремени  JOIN  Неделя н on г.НомерНедели = н.НомерНедели WHERE с.ТабельныйНомер=@ТабельныйНомер", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    DopTableDoctor.ItemsSource = dt.AsDataView();
                }
                catch
                {

                }
            }

        }

        public void DopRefresh()
        {
            string sconnect = mainWindow.sconnect;

            if (TableDoctor.SelectedItem is DataRowView row)
            {
                
                    int id = (int)row[0];
                    string Id = Convert.ToString(row["ТабельныйНомер"]);
                    string buf = Id;
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("SELECT знп.Дата, знп.Время, п.Фамилия, п.Имя, п.Отчество  FROM   ЗаписьНаПриём знп JOIN Сотрудник с on  знп.ТабельныйНомер = с.ТабельныйНомер JOIN Пациент п on  знп.НомерПациент = знп.НомерПациент WHERE с.ТабельныйНомер=@ТабельныйНомер", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    DopTable.ItemsSource = dt.AsDataView();
               
            }

        }
        private void TableDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            string sql = "SELECT  SELECT с.ТабельныйНомер, с.Фамилия, с.Имя, с.Отчество, п.Название  FROM  ПрофессияСотрудник пс JOIN Сотрудник с on  пс.ТабельныйНомер = с.ТабельныйНомер  JOIN Профессия п on пс.НомерПрофессии = п.НомерПрофессии   WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'   ";
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
            TableDoctor.ItemsSource = dt.AsDataView();
        }
    }
}
