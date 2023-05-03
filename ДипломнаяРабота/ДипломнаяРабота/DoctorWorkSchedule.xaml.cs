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
    /// Логика взаимодействия для DoctorWorkSchedule.xaml
    /// </summary>
    public partial class DoctorWorkSchedule : Page
    {
        MainWindow mainWindow = new MainWindow();

        private readonly User _user;
        
        public DoctorWorkSchedule(User user)
        {
            _user = user;
            InitializeComponent();
            //добавления значений в комбобокс
            ComboBoxDayOfTheWeek.Items.Add("Понедельник");
            ComboBoxDayOfTheWeek.Items.Add("Вторник");
            ComboBoxDayOfTheWeek.Items.Add("Среда");
            ComboBoxDayOfTheWeek.Items.Add("Четверг");
            ComboBoxDayOfTheWeek.Items.Add("Пятница");
            ComboBoxDayOfTheWeek.Items.Add("Суббота");
            ComboBoxDayOfTheWeek.Items.Add("Воскресенье");
            refresh();
            
        }
        public void refresh()
        {
            
            string sconnect = mainWindow.sconnect;
            string sconnecte = mainWindow.sconnect;


            //проверка какой именно сотрудник зашёл 
            string bufUser;
            string bufLogin = mainWindow.buffLog;
            string bufPassword = mainWindow.buffPass;
            SqlConnection conn = new SqlConnection(sconnecte);
            SqlCommand cmdd = new SqlCommand("Select ТабельныйНомер From Сотрудник Where  Логин=@Логин and Пароль=@Пароль ", conn);
            conn.Open();
            cmdd.Parameters.Add(new SqlParameter("@Логин", bufLogin));
            cmdd.Parameters.Add(new SqlParameter("@Пароль", bufPassword));
            bufUser = cmdd.ExecuteScalar().ToString();
            conn.Close();

            //вывод данных в таблицу
            SqlConnection con = new SqlConnection(sconnect);
            string sql = "SELECT н.ДеньНедели, в.НачалоРаботы, в.КонецРаботы, в.Выходной  FROM  График г JOIN Сотрудник с on  г.ТабельныйНомер = с.ТабельныйНомер  JOIN Время в on г.НомерВремени = в.НомерВремени  JOIN  Неделя н on г.НомерНедели = н.НомерНедели WHERE с.ТабельныйНомер=@ТабельныйНомер";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", bufUser));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TableChart.ItemsSource = dt.AsDataView();
            con.Close();
            
               
            
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            
           
            try
            {
                string sconnect = mainWindow.sconnect;
                string sconnecte = mainWindow.sconnect;
                string sconnectet = mainWindow.sconnect;

                //инициализация переменных
                string Time = началоРаботыTextBox.Text;
                string TimeEnd = конецРаботыTextBox.Text;
                string Weekend = выходнойTextBox.Text;
                string DayOfTheWeek = ComboBoxDayOfTheWeek.Text;
                string bufDayOfTheWeek = null;
                string bufUser = null;
                string bufLogin = mainWindow.buffLog;
                string bufPassword = mainWindow.buffPass;
                string bufTime = null;


                //добавление времени
                SqlConnection scon = new SqlConnection(sconnect);
                SqlCommand scmd = new SqlCommand("INSERT_Время", scon);
                scon.Open();
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.Add(new SqlParameter("@НачалоРаботы", Time));
                scmd.Parameters.Add(new SqlParameter("@КонецРаботы", TimeEnd));
                scmd.Parameters.Add(new SqlParameter("@Выходной", Weekend));
                scmd.ExecuteNonQuery();
                scon.Close();

                //поиск только что добавленного id
                SqlConnection sconn = new SqlConnection(sconnect);
                SqlCommand scmdd = new SqlCommand("SELECT MAX(НомерВремени) FROM Время", sconn);
                sconn.Open();
                bufTime = scmdd.ExecuteScalar().ToString();
                sconn.Close();

                //проверка дня недели
                SqlConnection con = new SqlConnection(sconnect);
                SqlCommand cmd = new SqlCommand("Select НомерНедели From Неделя Where  ДеньНедели=@ДеньНедели ", con);
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@ДеньНедели", DayOfTheWeek));
                bufDayOfTheWeek = cmd.ExecuteScalar().ToString();
                con.Close();

                //проверка какой именно сотрудник зашёл 
                SqlConnection conn = new SqlConnection(sconnecte);
                SqlCommand cmdd = new SqlCommand("Select ТабельныйНомер From Сотрудник Where  Логин=@Логин and Пароль=@Пароль ", conn);
                conn.Open();
                cmdd.Parameters.Add(new SqlParameter("@Логин", bufLogin));
                cmdd.Parameters.Add(new SqlParameter("@Пароль", bufPassword));
                bufUser = cmdd.ExecuteScalar().ToString();
                conn.Close();


                //назначение графика в таблицы график 
                SqlConnection sqcon = new SqlConnection(sconnect);
                SqlCommand sqcmd = new SqlCommand("INSERT_График", sqcon);
                sqcon.Open();
                sqcmd.CommandType = CommandType.StoredProcedure;
                sqcmd.Parameters.Add(new SqlParameter("@НомерВремени", bufTime));
                sqcmd.Parameters.Add(new SqlParameter("@НомерНедели", bufDayOfTheWeek));
                sqcmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", bufUser));
                sqcmd.ExecuteNonQuery();
                sqcon.Close();
                refresh();

            }
            catch
            {
                MessageBox.Show("Проверьте правильность внесённых данных");
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

        }
    }
}
