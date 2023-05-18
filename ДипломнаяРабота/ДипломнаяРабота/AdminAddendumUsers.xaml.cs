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
    /// Логика взаимодействия для AdminAddendum.xaml
    /// </summary>
    public partial class AdminAddendum : Page
    {

        MainWindow mainWindow = new MainWindow();

        private readonly User _user;
        public AdminAddendum(User user)
        {
            string sconnect = mainWindow.sconnect;
            _user = user;

            InitializeComponent();
            //Отображение данных в таблицу
            ДипломнаяРабота.ДипломDataSet дипломDataSet = ((ДипломнаяРабота.ДипломDataSet)(this.FindResource("дипломDataSet")));
            // Загрузить данные в таблицу Профессия. Можно изменить этот код как требуется.
            ДипломнаяРабота.ДипломDataSetTableAdapters.ПрофессияTableAdapter дипломDataSetПрофессияTableAdapter = new ДипломнаяРабота.ДипломDataSetTableAdapters.ПрофессияTableAdapter();
            дипломDataSetПрофессияTableAdapter.Fill(дипломDataSet.Профессия);
            System.Windows.Data.CollectionViewSource профессияViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("профессияViewSource")));
            профессияViewSource.View.MoveCurrentToFirst();

            //добавление данных в комбобокс с профессиями
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("Select Название From Профессия ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            refresh();

            //добавления значений в комбобокс
            AccessRights.Items.Add("Администратор");
            AccessRights.Items.Add("Врач");
            AccessRights.Items.Add("Регистратор");
            
           
                
            

        }

        private void сотрудникDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT *  FROM Сотрудник  ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableAdministrator.ItemsSource = dt.AsDataView();
            con.Close();
        }

        
        public void Click_Search(object sender, RoutedEventArgs e)
        {
            

            
        }
        


            private void Button_Click_Add(object sender, RoutedEventArgs e)
            {   
            
                


                //инициализация переменных
                string sconnect = mainWindow.sconnect;
                //string bufProfession = combo;
                string bufAccessRights = AccessRights.Text;
            
                
                string FirstName = имяTextBox.Text;
                string LastName = фамилияTextBox.Text;
                string MiddleName = отчествоTextBox.Text;
                string Telephone = телефонTextBox.Text;
                string Passport = паспортTextBox.Text;
                string Snils = снилсTextBox.Text;
                string Login = логинTextBox.Text;
                string Password = парольTextBox.Text;
            if (FirstName == null )
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Сотрудник", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.Add(new SqlParameter("@Имя", FirstName));
                cmdd.Parameters.Add(new SqlParameter("@Фамилия", LastName));
                cmdd.Parameters.Add(new SqlParameter("@Отчество", MiddleName));
                cmdd.Parameters.Add(new SqlParameter("@Телефон", Telephone));
                cmdd.Parameters.Add(new SqlParameter("@Паспорт", Passport));
                cmdd.Parameters.Add(new SqlParameter("@Снилс", Snils));
                //cmdd.Parameters.Add(new SqlParameter("@НомерПрофессии", bufProfession));
                cmdd.Parameters.Add(new SqlParameter("@Логин", Login));
                cmdd.Parameters.Add(new SqlParameter("@Пароль", Password));
                cmdd.Parameters.Add(new SqlParameter("@ПраваДоступа", bufAccessRights));
                cmdd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");
                refresh();
                имяTextBox.Clear();
                фамилияTextBox.Clear();
                отчествоTextBox.Clear();
                телефонTextBox.Clear();
                паспортTextBox.Clear();
                снилсTextBox.Clear();
                логинTextBox.Clear();
                парольTextBox.Clear();
            }

            }

        private void TableAdministrator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //вывод данных в строковые поля при выборе ТабельногоНомера
            string sconnect = mainWindow.sconnect;
            if (TableAdministrator.SelectedItem is DataRowView row)
            {
                
                int id = (int)row[0];
                string IdDisplay = Convert.ToString(row["ТабельныйНомер"]);
                MessageBox.Show(Convert.ToString(id));
                if (row == null)
                {
                    имяTextBox.Clear();
                    фамилияTextBox.Clear();
                    отчествоTextBox.Clear();
                    телефонTextBox.Clear();
                    паспортTextBox.Clear();
                    снилсTextBox.Clear();
                    логинTextBox.Clear();
                    парольTextBox.Clear();
                }
                else
                {

                    try
                    {
                        SqlConnection conn = new SqlConnection(sconnect);
                        SqlCommand cmdd = new SqlCommand("Select * From Сотрудник WHERE ТабельныйНомер=@ID ", conn);
                        conn.Open();
                        cmdd.Parameters.Add(new SqlParameter("@id", IdDisplay));
                        SqlDataReader drr = cmdd.ExecuteReader();
                        drr.Read();
                        //табельныйНомерTextBox.Text = drr.GetValue(0).ToString();
                        имяTextBox.Text = drr.GetValue(2).ToString();
                        фамилияTextBox.Text = drr.GetValue(1).ToString();
                        отчествоTextBox.Text = drr.GetValue(3).ToString();
                        телефонTextBox.Text = drr.GetValue(4).ToString();
                        паспортTextBox.Text = drr.GetValue(5).ToString();
                        снилсTextBox.Text = drr.GetValue(6).ToString();
                        логинTextBox.Text = drr.GetValue(7).ToString();
                        парольTextBox.Text = drr.GetValue(8).ToString();
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //вытаскиваем табельный номер для удаления
            if (TableAdministrator.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDelete = Convert.ToString(row["ТабельныйНомер"]);
                try
                {
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From Сотрудник WHERE ТабельныйНомер=@ID ", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", IdDelete));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись удолена");
                    refresh();
                    имяTextBox.Clear();
                    фамилияTextBox.Clear();
                    отчествоTextBox.Clear();
                    телефонTextBox.Clear();
                    паспортTextBox.Clear();
                    снилсTextBox.Clear();
                    логинTextBox.Clear();
                    парольTextBox.Clear();
                }
                catch
                {
                    MessageBox.Show("Нажмите на Табельный номер сотрудника которого хотите удолить");
                }

            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

            string sconnect = mainWindow.sconnect;
            if (TableAdministrator.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["ТабельныйНомер"]);
                try
                {
                    string FirstName = имяTextBox.Text;
                    string LastName = фамилияTextBox.Text;
                    string MiddleName = отчествоTextBox.Text;
                    string Telephone = телефонTextBox.Text;
                    string Passport = паспортTextBox.Text;
                    string Snils = снилсTextBox.Text;
                    string Login = логинTextBox.Text;
                    string Password = парольTextBox.Text;
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Update Сотрудник SET ТабельныйНомер=@ТабельныйНомер, Имя=@Имя, Фамилия=@фамилия, Отчество=@Отчество, Телефон=@Телефон, Паспорт=@Паспорт, Снилс=@Снилс, Логин=@Логин, Пароль=@Пароль   WHERE ТабельныйНомер=@id ", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", IdUpdate));
                    cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", IdUpdate));
                    cmd.Parameters.Add(new SqlParameter("@Имя", FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Фамилия", LastName));
                    cmd.Parameters.Add(new SqlParameter("@Отчество", MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@Телефон", Telephone));
                    cmd.Parameters.Add(new SqlParameter("@Паспорт", Passport));
                    cmd.Parameters.Add(new SqlParameter("@Снилс", Snils));
                    cmd.Parameters.Add(new SqlParameter("@Логин", Login));
                    cmd.Parameters.Add(new SqlParameter("@Пароль", Password));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись обновлена");
                    refresh();
                }
                catch
                {
                    MessageBox.Show("Данное поле обновить нельзя");
                }


            }
        }

        private void AccessRights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Фамилия.Text;
            string surname = Фамилия.Text;
            string middleName = Фамилия.Text;
            string text = Фамилия.Text; // получаем текст из TextBox
            string[] words = text.Split(' '); // разбиваем текст на слова по пробелу
            if (words.Length > 1) // проверяем, что введено хотя бы два слова
            {
                string Surname = words[0];
                string Name = words[1];
                string MiddleName = words[2];
                name = Name;
                surname = Surname;
                middleName = MiddleName;
            }
           
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT  * FROM Сотрудник  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'  ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@surname", surname));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@middleName", middleName));
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            TableAdministrator.ItemsSource = dt.AsDataView();
        }

        private void фамилияTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                if (((TextBox)sender).Text.Length == 1)
                    ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            
        }
    }
}
