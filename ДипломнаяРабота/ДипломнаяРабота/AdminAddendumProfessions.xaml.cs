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
    /// Логика взаимодействия для AdminAddendumProfessions.xaml
    /// </summary>
    public partial class AdminAddendumProfessions : Page
    {
        MainWindow mainWindow = new MainWindow();
        private readonly User _user;
        public AdminAddendumProfessions(User user)
        {
            _user = user;
            InitializeComponent();
            string sconnect = mainWindow.sconnect;
            refresh();
            

        }
        public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT * FROM Профессия ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableProfessions.ItemsSource = dt.AsDataView();
            con.Close();

            


        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //инициализация переменных
            string ProfessionNumber = номерПрофессииTextBox.Text;
            string Name = названиеTextBox.Text;
            string Salary = окладTextBox.Text;
            string Category = категорияTextBox.Text;
           
            if (ProfessionNumber == null || Name == null || Salary == null || Category == null )
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Профессия", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", ProfessionNumber));
                cmdd.Parameters.Add(new SqlParameter("@Название", Name));
                cmdd.Parameters.Add(new SqlParameter("@Оклад", Salary));
                cmdd.Parameters.Add(new SqlParameter("@Категория", Category));
                cmdd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");
                refresh();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //вытаскиваем табельный номер для удаления
            if (TableProfessions.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDelete = Convert.ToString(row["НомерПрофессии"]);
                try
                {
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From Профессия WHERE НомерПрофессии=@ID ", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", IdDelete));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись удолена");
                    refresh();

                }
                catch
                {
                    MessageBox.Show("Нажмите на номер професси которую хотите удолить");
                }
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            string sconnect=mainWindow.sconnect;
            if (TableProfessions.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["НомерПрофессии"]);
                try
                {
                    string Name = названиеTextBox.Text;
                    string Salary = окладTextBox.Text;
                    string Category = категорияTextBox.Text;

                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("Update Профессия SET Название=@Название, Категория=@Категория, Оклад=@Оклад  WHERE НомерПрофессии=@НомерПрофессии ", conn);
                    conn.Open();
                    cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", IdUpdate));
                    cmdd.Parameters.Add(new SqlParameter("@Название", Name));
                    cmdd.Parameters.Add(new SqlParameter("@Оклад", Salary));
                    cmdd.Parameters.Add(new SqlParameter("@Категория", Category));
                    cmdd.ExecuteNonQuery();
                    MessageBox.Show("Запись изменена");
                    refresh();
                }
                catch
                {
                    MessageBox.Show("Проверте поля на правильность записи");

                }
            }
        }

        private void TableProfessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableProfessions.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["НомерПрофессии"]);
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("Select НомерПрофессии, Название, Категория, Оклад  From Профессия WHERE НомерПрофессии=@НомерПрофессии ", conn);
                conn.Open();
                cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", IdUpdate));
                SqlDataReader dr = cmdd.ExecuteReader();
                dr.Read();
                номерПрофессииTextBox.Text = dr.GetValue(0).ToString();
                названиеTextBox.Text = dr.GetValue(1).ToString();
                категорияTextBox.Text = dr.GetValue(2).ToString();
                окладTextBox.Text = dr.GetValue(3).ToString();
            }
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {

        }
    }
}
