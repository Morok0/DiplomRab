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
    /// Логика взаимодействия для AdminAddendumDepartment.xaml
    /// </summary>
    public partial class AdminAddendumDepartment : Page
    {
        MainWindow mainWindow = new MainWindow();
        private readonly User _user;
        public AdminAddendumDepartment(User user)
        {
            _user = user;
            InitializeComponent();
            refresh();
        }


        public void refresh()
        {
            
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT * FROM  Отделение";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableDepartment.ItemsSource = dt.AsDataView();
            con.Close();

        }
        private void TableDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableDepartment.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["НомерОтделения"]);
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("Select Название, НомерОтделения From Отделение WHERE НомерОтделения=@НомерОтделения ", conn);
                conn.Open();
                cmdd.Parameters.Add(new SqlParameter("@НомерОтделения", IdUpdate));
                SqlDataReader dr = cmdd.ExecuteReader();
                dr.Read();
                номерОтделенияTextBox.Text = dr.GetValue(0).ToString();
                названиеTextBox.Text = dr.GetValue(0).ToString();
            }
            
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //инициализация переменных
            string DepartmentNumber = номерОтделенияTextBox.Text;
            string Name = названиеTextBox.Text;
           

            if (DepartmentNumber == null || Name == null )
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Отделение", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.Add(new SqlParameter("@НомерОтделения", DepartmentNumber));
                cmdd.Parameters.Add(new SqlParameter("@Название", Name));
                cmdd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");
                refresh();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //вытаскиваем табельный номер для удаления
            if (TableDepartment.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDelete = Convert.ToString(row["НомерОтделения"]);
                try
                {
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From Отделение WHERE НомерОтделения=@ID ", con);
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

        }
    }
}
