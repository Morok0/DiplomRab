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
    /// Логика взаимодействия для RegistrarMakeAnAppointment.xaml
    /// </summary>
    public partial class RegistrarMakeAnAppointment : Page
    {
        MainWindow mainWindow = new MainWindow();

        private readonly User _user;

        public string bufDoctor;
        public string bufPatient;
        public RegistrarMakeAnAppointment(User user)
        {
            _user = user;
            InitializeComponent();
            /*
            ДипломнаяРабота.ДипломDataSet дипломDataSet = ((ДипломнаяРабота.ДипломDataSet)(this.FindResource("дипломDataSet")));
            // Загрузить данные в таблицу Пациент. Можно изменить этот код как требуется.
            ДипломнаяРабота.ДипломDataSetTableAdapters.ПациентTableAdapter дипломDataSetПациентTableAdapter = new ДипломнаяРабота.ДипломDataSetTableAdapters.ПациентTableAdapter();
            дипломDataSetПациентTableAdapter.Fill(дипломDataSet.Пациент);
            System.Windows.Data.CollectionViewSource пациентViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("пациентViewSource")));
            пациентViewSource.View.MoveCurrentToFirst();

            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string strCmd = "SELECT Имя FROM Сотрудник";
            con.Open();
            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ComboEmployee.DataContext = ds.Tables[0];
            ComboEmployee.DisplayMemberPath = "Имя";
            cmd.ExecuteNonQuery();*/
            refresh();
            refreshPatient();
            refreshDoctor();

        }

        public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT * FROM ЗаписьНаПриём ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableMake.ItemsSource = dt.AsDataView();
            con.Close();




        }

        public void refreshPatient()
        {
            string sconnect = mainWindow.sconnect;
            //отображение таблицы с пациентами 
            SqlConnection scon = new SqlConnection(sconnect);
            string sql = "SELECT НомерПациента, Фамилия, Имя, Отчество, Паспорт, Полис, Снилс, Телефон FROM  Пациент";
            scon.Open();
            DataTable dt = new DataTable();
            SqlCommand scmd = new SqlCommand(sql, scon);
            SqlDataAdapter da = new SqlDataAdapter(scmd);
            da.Fill(dt);
            TablePatient.ItemsSource = dt.AsDataView();
            scon.Close();




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


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            //инициализация переменных
            
            string Date = датаDatePicker.Text;
            string Time = времяTextBox.Text;
           
            string NumberK = номерКабинетаTextBox.Text;


            try
            {
                //эта часть работает
                if (Date == null || Time == null || NumberK == null)
                {
                    MessageBox.Show("Проверте все ли поля заполнены");
                }
                else
                {


                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("INSERT_ЗаписьНаПриём", conn);
                    conn.Open();
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.Add(new SqlParameter("@дата", Date));
                    cmdd.Parameters.Add(new SqlParameter("@время", Time));
                    cmdd.Parameters.Add(new SqlParameter("@НомерКабинета", NumberK));
                    cmdd.Parameters.Add(new SqlParameter("@ТабельныйНомер", bufDoctor));
                    cmdd.Parameters.Add(new SqlParameter("@НомерПациент", bufPatient));
                    cmdd.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена");
                    refresh();
                }
            }
            catch
            {
                MessageBox.Show("Выберите врача и пациента");
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableMake.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDelete = Convert.ToString(row["НомерЗаписи"]);
                try
                {
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From ЗаписьНаПриём WHERE НомерЗаписи=@ID ", con);
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", IdDelete));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись удолена");
                    refresh();
                }
                catch
                {
                    MessageBox.Show("Нажмите на Табельный номер сотрудника которого хотите удолить");
                }
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableMake.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdUpdate = Convert.ToString(row["НомерЗаписи"]);
                SqlConnection conn = new SqlConnection(sconnect);
                SqlCommand cmdd = new SqlCommand("Select ТабельныйНомер, дата, время, НомерКабинета,НомерПациент  From ЗаписьНаПриём WHERE НомерЗаписи=@НомерЗаписи ", conn);
                conn.Open();
                cmdd.Parameters.Add(new SqlParameter("@НомерЗаписи", IdUpdate));
                SqlDataReader dr = cmdd.ExecuteReader();
                dr.Read();
                датаDatePicker.Text = dr.GetValue(1).ToString();
                времяTextBox.Text = dr.GetValue(2).ToString();
               
                номерКабинетаTextBox.Text = dr.GetValue(0).ToString();
            }
        }

        private void Button_Click_Patient(object sender, RoutedEventArgs e)
        {
            
            //проверка какой пациент

            if (TablePatient.SelectedItem is DataRowView roww)
            {
                int id = (int)roww[0];
                string idPatient = Convert.ToString(roww["НомерПациента"]);
                bufPatient = idPatient;

            }
        }

        private void Button_Click_Doctor(object sender, RoutedEventArgs e)
        {
            //проверка какой сотрудник
            if (TableDoctor.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string idUser = Convert.ToString(row["ТабельныйНомер"]);
                bufDoctor = idUser;

            }
           
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT НомерПациента, Фамилия, Имя, Отчество, Паспорт, Полис, Снилс FROM  Пациент  WHERE Имя LIKE '%' and Фамилия LIKE '%" + Фамилия.Text + "' and Отчество LIKE '%' ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            //результат запроса суем в таблицу
            dt.Load(dr);
            //заполняем datagridview - (поле данных...где выводится результат поиска)
            TablePatient.ItemsSource = dt.AsDataView();
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
           
            Фамилия.Text = null;
           
            refreshPatient();
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
            string sql = "SELECT  НомерПациента, Фамилия, Имя, Отчество, Паспорт, Полис, Снилс FROM Пациент  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'   ";
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

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Имя.Text;
            string surname = Имя.Text;
            string middleName = Имя.Text;
            string text = Имя.Text; // получаем текст из TextBox
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
            string sql = "SELECT с.ТабельныйНомер, с.Фамилия, с.Имя, с.Отчество, п.Название  FROM  ПрофессияСотрудник пс JOIN Сотрудник с on  пс.ТабельныйНомер = с.ТабельныйНомер  JOIN Профессия п on пс.НомерПрофессии = п.НомерПрофессии WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'  and с.ПраваДоступа='Врач' ";
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
    }
}
