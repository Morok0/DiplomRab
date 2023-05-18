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
    /// Логика взаимодействия для RegistrarAddendumPatient.xaml
    /// </summary>
    public partial class RegistrarAddendumPatient : Page
    {
        MainWindow mainWindow = new MainWindow();

        private readonly User _user;
        public RegistrarAddendumPatient(User user)
        {
            _user = user;
            InitializeComponent();
            refresh();
        }

        private void TablePatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT * FROM Пациент ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TablePatient.ItemsSource = dt.AsDataView();
            con.Close();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TablePatient.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDisplay = Convert.ToString(row["НомерПациента"]);
                try
                {
                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("Select * From Пациент WHERE НомерПациента=@ID ", conn);
                    conn.Open();
                    cmdd.Parameters.Add(new SqlParameter("@id", IdDisplay));
                    SqlDataReader drr = cmdd.ExecuteReader();
                    drr.Read();
                    //номерПациентаTextBox.Text = drr.GetValue(0).ToString();
                    имяTextBox.Text = drr.GetValue(2).ToString();
                    фамилияTextBox.Text = drr.GetValue(1).ToString();
                    отчествоTextBox.Text = drr.GetValue(3).ToString();
                    паспортTextBox.Text = drr.GetValue(4).ToString();
                    снилсTextBox.Text = drr.GetValue(5).ToString();
                    полисTextBox.Text = drr.GetValue(7).ToString();
                    профессияTextBox.Text = drr.GetValue(8).ToString();
                    местоРаботыTextBox.Text = drr.GetValue(9).ToString();
                    городTextBox.Text = drr.GetValue(10).ToString();
                    улицаTextBox.Text = drr.GetValue(11).ToString();
                    домTextBox.Text = drr.GetValue(12).ToString();
                    номерКвартирыTextBox.Text = drr.GetValue(13).ToString();
                    почтовыйИндексTextBox.Text = drr.GetValue(14).ToString();
                    телефонTextBox.Text = drr.GetValue(15).ToString();
                }
                catch
                {

                }
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            string Profession = профессияTextBox.Text;
            string Work = местоРаботыTextBox.Text;
            //string PatientNumber = номерПациентаTextBox.Text;
            string FirstName = имяTextBox.Text;
            string LastName = фамилияTextBox.Text;
            string MiddleName = отчествоTextBox.Text;
            string Telephone = телефонTextBox.Text;
            string Passport = паспортTextBox.Text;
            string Snils = снилсTextBox.Text;
            string DateOfBirth = датаРожденияDatePicker.Text;
            string Date;
            string[] words = DateOfBirth.Split(' ');
            string result = words[0] + " " + string.Join(" ", words.Skip(1).Take(words.Length - 2));
            MessageBox.Show(result);
            string Polis = полисTextBox.Text;
            string City = городTextBox.Text;
            string Street = улицаTextBox.Text;
            string House = домTextBox.Text;
            string ApartmentNumber = номерКвартирыTextBox.Text;
            string PostalCode = почтовыйИндексTextBox.Text;
            if (FirstName == null || LastName == null || MiddleName == null || Telephone == null | Passport == null || Snils == null || Work == null || Profession == null || Polis == null || DateOfBirth == null || City == null || Street == null || House == null || ApartmentNumber == null || PostalCode == null)
            {
                MessageBox.Show("Проверте все ли поля заполнены");
            }
            else
            {
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("INSERT_Пациент", conn);
                conn.Open();
                cmdd.CommandType = CommandType.StoredProcedure;
                //cmdd.Parameters.Add(new SqlParameter("@НомерПациента", PatientNumber));
                cmdd.Parameters.Add(new SqlParameter("@Имя", FirstName));
                cmdd.Parameters.Add(new SqlParameter("@Фамилия", LastName));
                cmdd.Parameters.Add(new SqlParameter("@Отчество", MiddleName));
                cmdd.Parameters.Add(new SqlParameter("@Паспорт", Passport));
                cmdd.Parameters.Add(new SqlParameter("@Снилс", Snils));
                cmdd.Parameters.Add(new SqlParameter("@ДатаРождения", result));
                cmdd.Parameters.Add(new SqlParameter("@Полис", Polis));
                cmdd.Parameters.Add(new SqlParameter("@Профессия", Profession));
                cmdd.Parameters.Add(new SqlParameter("@МестоРаботы", Work));
                cmdd.Parameters.Add(new SqlParameter("@Город", City));
                cmdd.Parameters.Add(new SqlParameter("@Улица", Street));
                cmdd.Parameters.Add(new SqlParameter("@дом", House));
                cmdd.Parameters.Add(new SqlParameter("@НомерКвартиры", ApartmentNumber));
                cmdd.Parameters.Add(new SqlParameter("@ПочтовыйИндекс", PostalCode));
                cmdd.Parameters.Add(new SqlParameter("@Телефон", Telephone));

                cmdd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");
                refresh();
              
                профессияTextBox.Clear();
                местоРаботыTextBox.Clear();
                имяTextBox.Clear(); 
                фамилияTextBox.Clear();
                отчествоTextBox.Clear();
                телефонTextBox.Clear();
                паспортTextBox.Clear();
                снилсTextBox.Clear();
                полисTextBox.Clear();
                городTextBox.Clear();
                улицаTextBox.Clear();
                домTextBox.Clear();
                номерКвартирыTextBox.Clear();
                почтовыйИндексTextBox.Clear();
            }

        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //вытаскиваем табельный номер для удаления
            if (TablePatient.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDelete = Convert.ToString(row["НомерПациента"]);
                try
                {
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From Пациент WHERE НомерПациента=@ID ", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", IdDelete));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись удолена");
                    refresh();
                    профессияTextBox.Clear();
                    местоРаботыTextBox.Clear();
                    имяTextBox.Clear();
                    фамилияTextBox.Clear();
                    отчествоTextBox.Clear();
                    телефонTextBox.Clear();
                    паспортTextBox.Clear();
                    снилсTextBox.Clear();
                    полисTextBox.Clear();
                    городTextBox.Clear();
                    улицаTextBox.Clear();
                    домTextBox.Clear();
                    номерКвартирыTextBox.Clear();
                    почтовыйИндексTextBox.Clear();
                }
                catch
                {
                    MessageBox.Show("Нажмите на номер пациента которого хотите удолить");
                }
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            
            if (TablePatient.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["НомерПациента"]);
                try
                {

                    string Profession = профессияTextBox.Text;
                    string Work = местоРаботыTextBox.Text;
                    //string PatientNumber = номерПациентаTextBox.Text;
                    string FirstName = имяTextBox.Text;
                    string LastName = фамилияTextBox.Text;
                    string MiddleName = отчествоTextBox.Text;
                    string Telephone = телефонTextBox.Text;
                    string Passport = паспортTextBox.Text;
                    string Snils = снилсTextBox.Text;
                    string DateOfBirth = датаРожденияDatePicker.Text;
                    string Polis = полисTextBox.Text;
                    string City = городTextBox.Text;
                    string Street = улицаTextBox.Text;
                    string House = домTextBox.Text;
                    string ApartmentNumber = номерКвартирыTextBox.Text;
                    string PostalCode = почтовыйИндексTextBox.Text;
                    if ( FirstName == null || LastName == null || MiddleName == null || Telephone == null || Passport == null || Snils == null || Work == null || Profession == null || Polis == null || DateOfBirth == null || City == null || Street == null || House == null || ApartmentNumber == null || PostalCode == null)
                    {
                        MessageBox.Show("Проверте все ли поля заполнены");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(sconnect);
                        SqlCommand cmdd = new SqlCommand("Update Пациент SET НомерПациента=@НомерПациента, Имя=@Имя, Фамилия=@фамилия, Отчество=@Отчество, Паспорт=@Паспорт, Снилс=@Снилс,ДатаРождения=@ДатаРождения,Полис=@Полис,Профессия=@Профессия, МестоРаботы=@МестоРаботы, Телефон=@Телефон", conn);
                        conn.Open();
                        cmdd.CommandType = CommandType.StoredProcedure;
                        //cmdd.Parameters.Add(new SqlParameter("@НомерПациента", IdUpdate));
                        cmdd.Parameters.Add(new SqlParameter("@Имя", FirstName));
                        cmdd.Parameters.Add(new SqlParameter("@Фамилия", LastName));
                        cmdd.Parameters.Add(new SqlParameter("@Отчество", MiddleName));
                        cmdd.Parameters.Add(new SqlParameter("@Паспорт", Passport));
                        cmdd.Parameters.Add(new SqlParameter("@Снилс", Snils));
                        cmdd.Parameters.Add(new SqlParameter("@ДатаРождения", DateOfBirth));
                        cmdd.Parameters.Add(new SqlParameter("@Полис", Polis));
                        cmdd.Parameters.Add(new SqlParameter("@Профессия", Profession));
                        cmdd.Parameters.Add(new SqlParameter("@МестоРаботы", Work));
                        cmdd.Parameters.Add(new SqlParameter("@Город", City));
                        cmdd.Parameters.Add(new SqlParameter("@Улица", Street));
                        cmdd.Parameters.Add(new SqlParameter("@дом", House));
                        cmdd.Parameters.Add(new SqlParameter("@НомерКвартиры", ApartmentNumber));
                        cmdd.Parameters.Add(new SqlParameter("@ПочтовыйИндекс", PostalCode));
                        cmdd.Parameters.Add(new SqlParameter("@Телефон", Telephone));

                        cmdd.ExecuteNonQuery();

                        MessageBox.Show("Запись добавлена");
                        refresh();
                    }
                }

                catch
                {

                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string name=Фамилия.Text;
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
            string sql = "SELECT * FROM Пациент  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Имя  LIKE '%' + @middleName + '%'  ";
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
            TablePatient.ItemsSource = dt.AsDataView();

            
           
        }
        private void Click_Search(object sender, RoutedEventArgs e)
        {
            
            
           
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
          
            Фамилия.Text = null;
           
            refresh();
        }

        private void профессияTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
