using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using Xceed.Words.NET;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xceed.Document.NET;


namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public enum User
        {
        Administrator,
        Doctor,
        Registrar,
        FirstEntry
    }
public partial class MainWindow : Window
    {
        public static string bufLogin="";
        public static string  bufPassword="";
        public string sconnect = "Data Source=DESKTOP-H2UKF4G; Initial Catalog = Диплом; Integrated Security = True";
        public MainWindow()
        {
            InitializeComponent();

            
            //проверка есть ли в бд записи в этой таблице
            string DopPer="";
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("SELECT Логин FROM Сотрудник", con);
            con.Open();
           
            try
            {

                DopPer = cmd.ExecuteScalar().ToString();
                //обработка первого входа в приложение
                if (DopPer != null)
                {
                    this.FirstEntry.Visibility = Visibility.Hidden;
                }
            }
            catch { }
            AutomaticRemovalOfPatients();
        
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
          

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Enter_Click(object sender, RoutedEventArgs e)//вход в приложение
        {
           
            //проверка логина и пароля
            SqlConnection con = new SqlConnection(sconnect);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Сотрудник Where Логин='" + Login.Text + "' and Пароль = '" + Password.Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            bufLogin = Login.Text;
            bufPassword = Password.Password;
            
            if (dt.Rows[0][0].ToString() == "1")
            {
                
                //проверка прав доступа
                string buf;

                SqlCommand cmd = new SqlCommand("Select ПраваДоступа From Сотрудник Where  Логин='" + Login.Text + "' and Пароль = '" + Password.Password + "'", con);
                con.Open();
                buf = cmd.ExecuteScalar().ToString();
                con.Close();
                //проверка пользователя
                if (buf == "Администратор")
                {

                    WindowNavigation Winn = new WindowNavigation(User.Administrator);
                    Winn.Show();
                    this.Close();

                }
                else if (buf == "Врач")
                {
                    WindowNavigationDoctor Winn = new WindowNavigationDoctor(User.Doctor);
                    Winn.Show();
                    this.Close();
                }
                else if (buf == "Регистратор")
                {
                    WindowNavigationRegistrar Winn = new WindowNavigationRegistrar (User.Registrar);
                    Winn.Show();
                    this.Close();
                }
                
               

            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
            }
           
           


        }

        private void FirstEntry_Click(object sender, RoutedEventArgs e)
        {
            WindowNavigateFirstEntry Win = new WindowNavigateFirstEntry(User.FirstEntry);
            Win.Show();
            this.Close();
        }

        private void ForgotYourPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В случае если вы забыли пароль или логи просьба обращаться к администратору");
        }
        public string buffLog = bufLogin;
        public string buffPass = bufPassword;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //Счётчик для автоматического удаления данных из таблицы пациента по прошествии определённого кол-во времени
        private void AutomaticRemovalOfPatients()
        {
            SqlConnection conn = new SqlConnection(sconnect);
            SqlCommand cmdd = new SqlCommand("SELECT MAX(Дата) AS Дата,  НомерПациент  FROM ЗаписьНаПриём  GROUP BY НомерПациент", conn);
            conn.Open();
            SqlDataReader drr = cmdd.ExecuteReader();
            DateTime maxDate = DateTime.MinValue;
           
            while (drr.Read())
            {

                    string ID = Convert.ToString(drr["НомерПациент"]);
                    DateTime date = (DateTime)drr["Дата"];
                    if (date > maxDate)
                    {
                        maxDate = date;
                        
                    }
                DateTime myDate = maxDate;
                DateTime otherDate = DateTime.Now;
                TimeSpan bufDate = otherDate - myDate;
               
                if (bufDate.TotalDays>90)
                {
                    //удаление ПриёмВрача 
                    SqlConnection conP = new SqlConnection(sconnect);
                    SqlCommand cmdP = new SqlCommand("Delete From ПриёмВрача WHERE НомерПациента=@ID ", conP);
                    conP.Open();
                    cmdP.Parameters.Add(new SqlParameter("@id", ID));
                    cmdP.ExecuteNonQuery();
                    //удаление ЗаписьНаПриём
                    SqlConnection conO = new SqlConnection(sconnect);
                    SqlCommand cmdO = new SqlCommand("Delete From ЗаписьНаПриём WHERE НомерПациент=@ID ", conO);
                    conO.Open();
                    cmdO.Parameters.Add(new SqlParameter("@id", ID));
                    cmdO.ExecuteNonQuery();
                    //удаление истории болезни
                    SqlConnection conI = new SqlConnection(sconnect);
                    SqlCommand cmdI = new SqlCommand("Delete From ИсторияБолезни WHERE НомерПациента=@ID ", conI);
                    conI.Open();
                    cmdI.Parameters.Add(new SqlParameter("@id", ID));
                    cmdI.ExecuteNonQuery();
                    //удаление пациента
                    SqlConnection con = new SqlConnection(sconnect);
                    SqlCommand cmd = new SqlCommand("Delete From Пациент WHERE НомерПациента=@ID ", con);
                    con.Open(); 
                    cmd.Parameters.Add(new SqlParameter("@id", ID));
                    cmd.ExecuteNonQuery();
                    
                }
            }
            drr.Close();
            
          
        }

    }
}
