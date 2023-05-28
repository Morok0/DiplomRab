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
    /// Логика взаимодействия для AdminDistribution.xaml
    /// </summary>
    public partial class AdminDistribution : Page
    {
        MainWindow mainWindow = new MainWindow();

        private readonly User _user;

        public static string bufAdministrator = "";
        public static string bufProfession = "";
        public static string bufDepartment = "";
        
        public AdminDistribution(User user)
        {
            _user = user;
            InitializeComponent();
            refreshAdministrator();

            

            AccessRights.Items.Add("Все");
            AccessRights.Items.Add("Администратор");
            AccessRights.Items.Add("Врач");
            AccessRights.Items.Add("Регистратор");
           





        }
        public void refreshAdministrator()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT ТабельныйНомер, Фамилия, Имя, Отчество, ПраваДоступа FROM Сотрудник ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableAdministrator.ItemsSource = dt.AsDataView();
            con.Close();

            
        }
        
        
        private void профессияComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           
        }

        private void TableAdministrator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TableProfession_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TableDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableAdministrator.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDisplay = Convert.ToString(row["ТабельныйНомер"]);
                string FirstName = Convert.ToString(row["Имя"]);
                string LastName = Convert.ToString(row["Фамилия"]);
                string Middl = Convert.ToString(row["Отчество"]);
                try
                {
                    bufAdministrator = IdDisplay;
                    if(СотрудникTextBox==null)
                    {
                        СотрудникTextBox.Text += LastName.Replace(" ", "") + " " + FirstName.Replace(" ", "")+ " " + Middl.Replace(" ", "");
                    }
                    
                    else
                    {
                        СотрудникTextBox.Text = null;
                        СотрудникTextBox.Text += LastName.Replace(" ", "") + " " + FirstName.Replace(" ", "") + " " + Middl.Replace(" ", "");
                    }


                }
                catch
                {

                }
            }
            
        }

        private void Button_Click_ToAppoint(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            

            try
            { 
            //инициализация переменных
            //string ProfessionNumber = номерПрофессииTextBox.Text;
                string Name = названиеTextBox.Text.Replace(" ", "");
                string Salary = окладTextBox.Text.Replace(" ", "");
                string Category = категорияTextBox.Text.Replace(" ", "");

                if ( названиеTextBox.Text == "" || окладTextBox.Text == "" || категорияTextBox.Text == "")
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Профессия", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                //cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", ProfessionNumber));
                cmdd.Parameters.Add(new SqlParameter("@Название", Name));
                cmdd.Parameters.Add(new SqlParameter("@Оклад", Salary));
                cmdd.Parameters.Add(new SqlParameter("@Категория", Category));
                cmdd.ExecuteNonQuery();

               
               
            }

            //string DepartmentNumber = номерОтделенияTextBox.Text;
            string NameDepartament = названиеОтделенияTextBox.Text.Replace(" ", "");
                string Number = номерКабинетаTextBox.Text.Replace(" ", "");

                if (названиеОтделенияTextBox.Text == "" || номерКабинетаTextBox.Text == "")
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Отделение", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                //cmdd.Parameters.Add(new SqlParameter("@НомерОтделения", DepartmentNumber));
                cmdd.Parameters.Add(new SqlParameter("@Название", NameDepartament));
                cmdd.Parameters.Add(new SqlParameter("@НомерКабинета", Number));
                    cmdd.ExecuteNonQuery();

               
               
            }

                //поиск только что добавленого id

                string bufProf;
                string bufDep;
                SqlConnection sconn = new SqlConnection(sconnect);
                SqlCommand scmdd = new SqlCommand("SELECT MAX(НомерПрофессии) FROM Профессия", sconn);
                sconn.Open();
                bufProf = scmdd.ExecuteScalar().ToString();
                sconn.Close();

                SqlConnection scon = new SqlConnection(sconnect);
                SqlCommand scmd = new SqlCommand("SELECT MAX(НомерОтделения) FROM Отделение", scon);
                scon.Open();
                bufDep = scmd.ExecuteScalar().ToString();
                scon.Close();

                bufDepartment = bufDep;
                bufProfession = bufProf;

                //добавления в доптаблицы
                if (bufAdministrator == null || bufProfession == null)
                {
                    MessageBox.Show("Выберите сотрудника и профессию для назначения");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("INSERT_ПрофессияСотрудник", conn);
                    conn.Open();
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.Add(new SqlParameter("@ТабельныйНомер", bufAdministrator));
                    cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", bufProfession));

                    cmdd.ExecuteNonQuery();




                }
                if (bufAdministrator == null || bufProfession == null)
                {
                    MessageBox.Show("Выберите сотрудника и профессию для назначения");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("INSERT_ВрачебноеОтделение", conn);
                    conn.Open();
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.Add(new SqlParameter("@ТабельныйНомер", bufAdministrator));
                    cmdd.Parameters.Add(new SqlParameter("@НомерОтделения", bufDepartment));

                    cmdd.ExecuteNonQuery();

                   

                }
                MessageBox.Show("Данные успешно добавлены");
                СотрудникTextBox.Clear(); 
                //номерПрофессииTextBox.Text = null;
                названиеTextBox.Clear();
                окладTextBox.Clear();
                категорияTextBox.Clear();
                //номерОтделенияTextBox.Text = null;
                названиеОтделенияTextBox.Clear();
                номерКабинетаTextBox.Clear();
            }
            catch
            {
                MessageBox.Show("проверьте правильность вводимых данных");
            }
            
        }

        private void номерКабинетаTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
            string sql = "SELECT  ТабельныйНомер, Фамилия, Имя, Отчество, ПраваДоступа FROM Сотрудник  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'  ";
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
            TableAdministrator.ItemsSource = dt.AsDataView();
        }

        private void AccessRights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bufAccessRights = "";
            bufAccessRights = AccessRights.Text;
           
            string sconnect = mainWindow.sconnect;
            if (AccessRights.Text!="Все")
            {
                SqlConnection con = new SqlConnection(sconnect);
                string sql = "SELECT  ТабельныйНомер,  Фамилия, Имя, Отчество, ПраваДоступа FROM Сотрудник  WHERE ПраваДоступа LIKE '%'+@bufAccessRights+'%'   ";
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@bufAccessRights", bufAccessRights));
                SqlDataReader dr = cmd.ExecuteReader();
                //результат запроса суем в таблицу
                dt.Load(dr);
                //заполняем datagridview - (поле данных...где выводится результат поиска)
                TableAdministrator.ItemsSource = dt.AsDataView();
            }    
           else
            {
                refreshAdministrator();
            }
        }

        private void названиеОтделенияTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
