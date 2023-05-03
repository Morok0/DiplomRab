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
    /// Логика взаимодействия для DoctorReception.xaml
    /// </summary>
    public partial class DoctorReception : Page
    {
        MainWindow mainWindow = new MainWindow();
        public static string buf;
        public static string bufPatient;
        public static string bufRecord;
        private readonly User _user;
        public DoctorReception(User user)
        {
            _user = user;
            InitializeComponent();

            //проверка сотрудника 
            string sconnect = mainWindow.sconnect;
            string bufUser;
            string bufLogin = mainWindow.buffLog;
            string bufPassword = mainWindow.buffPass;
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("Select ТабельныйНомер From Сотрудник Where  Логин=@Логин and Пароль=@Пароль ", con);
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@Логин", bufLogin));
            cmd.Parameters.Add(new SqlParameter("@Пароль", bufPassword));
            bufUser = cmd.ExecuteScalar().ToString();
            con.Close();
            buf = bufUser;
            refreshPatient();
        }
        /*public void refresh()
        {
            //вывод данных в таблицу администратора
            // актуализация данных в таблице 
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT * FROM ПриёмВрача ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableReception.ItemsSource = dt.AsDataView();
            con.Close();




        }*/
        public void refreshPatient()
        {
            string sconnect = mainWindow.sconnect;
            
            SqlConnection con = new SqlConnection(sconnect);
            string sql = " SELECT зп.НомерЗаписи, п.НомерПациента, п.Фамилия, п.Имя, п.Отчество, зп.Дата, зп.Время  FROM  ЗаписьНаПриём зп JOIN Пациент п on  зп.НомерПациент = п.НомерПациента  JOIN  Сотрудник с on зп.ТабельныйНомер = с.ТабельныйНомер   WHERE с.ТабельныйНомер=@ТабельныйНомер";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TablePatient.ItemsSource = dt.AsDataView();
            con.Close();
        }

            private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            
            //string Work = номерПриёмаTextBox.Text;
            string PatientNumber = началоПриёмаTextBox.Text;
            string FirstName = конецПриёмаTextBox.Text;
            string LastName = диагнозTextBox.Text;
            string MiddleName = лечениеTextBox.Text;
            
                if (PatientNumber == null || FirstName == null || LastName == null || MiddleName == null)
                {
                    MessageBox.Show("Проверте все ли поля заполнены");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("INSERT_ПриёмВрача", conn);
                    conn.Open();
                    cmdd.CommandType = CommandType.StoredProcedure;
                    //cmdd.Parameters.Add(new SqlParameter("@НомерПриёма", Work));
                    cmdd.Parameters.Add(new SqlParameter("@НачалоПриёма", PatientNumber));
                    cmdd.Parameters.Add(new SqlParameter("@КонецПриёма", FirstName));
                    cmdd.Parameters.Add(new SqlParameter("@Диагноз", LastName));
                    cmdd.Parameters.Add(new SqlParameter("@Лечение", MiddleName));
                    cmdd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
                    cmdd.Parameters.Add(new SqlParameter("@НомерПациента", bufPatient));
                    cmdd.Parameters.Add(new SqlParameter("@НомерЗаписи", bufRecord));
                    cmdd.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена");
                    //refresh();
                }
            
           /* catch
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }*/
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

        }

        /*private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TableReception.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDisplay = Convert.ToString(row["НомерПриёма"]);
                try
                {
                    SqlConnection conn = new SqlConnection(sconnect);
                    SqlCommand cmdd = new SqlCommand("Select * From ПриёмВрача WHERE НомерПриёма=@ID ", conn);
                    conn.Open();
                    cmdd.Parameters.Add(new SqlParameter("@id", IdDisplay));
                    SqlDataReader drr = cmdd.ExecuteReader();
                    drr.Read();
                    //номерПриёмаTextBox.Text = drr.GetValue(0).ToString();
                    началоПриёмаTextBox.Text = drr.GetValue(1).ToString();
                    конецПриёмаTextBox.Text = drr.GetValue(2).ToString();
                    диагнозTextBox.Text = drr.GetValue(3).ToString();
                    лечениеTextBox.Text = drr.GetValue(4).ToString();
                   

                }
                catch
                {

                }
            }
        }*/

        private void Button_Click_Patient(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;

            if (TablePatient.SelectedItem is DataRowView row)
            {
                try
                {
                    int id = (int)row[0];
                    string IdPatient = Convert.ToString(row["НомерПациента"]);
                    string IdRecord = Convert.ToString(row["НомерЗаписи"]);
                    bufPatient = IdPatient;
                    bufRecord = IdRecord;
                    
                }
                catch
                {

                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
