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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.IO;


using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Microsoft.Office.Interop.Word;
using DataTable = System.Data.DataTable;
using Page = System.Windows.Controls.Page;
using Font = Xceed.Document.NET.Font;
using System.Reflection;

namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для DoctorExtractOfTheCertificate.xaml
    /// </summary>
    public partial class DoctorExtractOfTheCertificate : Page
    {




        Word._Application oWord = new Word.Application();
        public static string Link= @"HelpTemplates";
        public static string DocumentTemplate = System.IO.Path.Combine(Environment.CurrentDirectory, @"HelpTemplates\Шаблон.docx");
        public static string DocumentToBeReplaced = System.IO.Path.Combine( Environment.CurrentDirectory, Link);
        public static string NameDoctor;//имя врача
        public static string bufText; //переменная для поиска фрагмента текста
        public static string bufReplacementText; //переменная для замены найденного фрагмента на другой текст
        public static string bufData; //переменная для установки даты в текст
        public static string bufPatient; // ID пациента
        public static string bufFirstName;
        public static string bufLastName;
        public static string bufMiddl;
        MainWindow mainWindow = new MainWindow();
        private readonly User _user;
        public DoctorExtractOfTheCertificate(User user)
        {
            _user = user;
            InitializeComponent();
           
            refreshPatient();
            
            СпаравкиComboBox.Items.Add("Справка");
            СпаравкиComboBox.Items.Add("Направление");

           
        }
       
        public void refreshPatient()
        {
            string sconnect = mainWindow.sconnect;
            SqlConnection con = new SqlConnection(sconnect);
            string sql = " SELECT НомерПациента, Фамилия, Имя, Отчество, ДатаРождения  FROM   Пациент ";
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TablePatient.ItemsSource = dt.AsDataView();
            con.Close();
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
            string sql = "SELECT  НомерПациента, Фамилия, Имя, Отчество, ДатаРождения FROM Сотрудник  WHERE Фамилия LIKE '%'+@surname+'%' or Имя  LIKE '%' + @name + '%' or Отчество  LIKE '%' + @middleName + '%'  ";
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

        private void Button_Click_Patient(object sender, RoutedEventArgs e)
        {
            string sconnect = mainWindow.sconnect;
            if (TablePatient.SelectedItem is DataRowView row)
            {
                int id = (int)row[0];
                string IdDisplay = Convert.ToString(row["НомерПациента"]);
                string FirstName = Convert.ToString(row["Имя"]);
                string LastName = Convert.ToString(row["Фамилия"]);
                string Middl = Convert.ToString(row["Отчество"]);
                string Data = Convert.ToString(row["ДатаРождения"]);
                Data.Replace(" ", "");
                string lastName = LastName.Replace(" ", "");
                string firstName = FirstName.Replace(" ", "");
                string middl = Middl.Replace(" ", "");
                try
                {

                    bufPatient = IdDisplay;
                    bufFirstName = firstName;
                    bufLastName = lastName;
                    bufMiddl = middl;
                    string[] words = Data.Split(' ');
                    string result = words[0] + " " + string.Join(" ", words.Skip(1).Take(words.Length - 2));
                    bufData = result;
                    if (СотрудникTextBox == null)
                    {


                        СотрудникTextBox.Text += lastName + " " + firstName + " " + middl;
                    }

                    else
                    {
                        СотрудникTextBox.Text = null;
                        СотрудникTextBox.Text += lastName + " " + firstName + " " + middl;
                    }


                }
                catch
                {

                }
            }
        }

        
        private void Button_Click_Reference(object sender, RoutedEventArgs e)
        {


            string sconnecte = mainWindow.sconnect;
            string sconnect = mainWindow.sconnect;

            //проверка какой именно сотрудник зашёл 
            string buf;
            string bufLogin = mainWindow.buffLog;
            string bufPassword = mainWindow.buffPass;
            SqlConnection conn = new SqlConnection(sconnecte);
            SqlCommand cmdd = new SqlCommand("Select ТабельныйНомер From Сотрудник Where  Логин=@Логин and Пароль=@Пароль ", conn);
            conn.Open();
            cmdd.Parameters.Add(new SqlParameter("@Логин", bufLogin));
            cmdd.Parameters.Add(new SqlParameter("@Пароль", bufPassword));
            buf = cmdd.ExecuteScalar().ToString();
            conn.Close();
            //вывод информации о сотруднике 
            SqlConnection con = new SqlConnection(sconnect);
            SqlCommand cmd = new SqlCommand("Select Имя, Отчество, Фамилия From Сотрудник WHERE ТабельныйНомер=@ТабельныйНомер    ", con);
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@ТабельныйНомер", buf));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string FirstName = dr.GetString(0);
            string LastName = dr.GetString(1);
            string MiddleName = dr.GetString(2);
            FirstName.Replace(" ", "");
            LastName.Replace(" ", "");
            MiddleName.Replace(" ", "");
           
            //строка для передачи ФИО врача в файл
            
            NameDoctor+=FirstName + " " + LastName + " " + MiddleName;
           
            if (СпаравкиComboBox.Text == "Справка")
            {
                Link = @"HelpTemplates\Справка_086у.docx";
                DocumentToBeReplaced = System.IO.Path.Combine(Environment.CurrentDirectory, Link);
                Filling_out_Documents();
            }

        }
        private void Filling_out_Documents()
        {

            Word.Application wApp = new Word.Application();
            Documents wDocs = wApp.Documents;
           
            Word.Document wDoc = wDocs.Add(DocumentToBeReplaced, Type.Missing, Type.Missing, true);
            Range oRange = wDoc.Content;
            wDoc.SaveAs(DocumentTemplate);
            wDoc.Activate();
            wDoc.Close();
            try
            {
                if (bufLastName.Contains(" "))
                {
                    string withoutSpaces = bufLastName.Replace(" ", "");

                }

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        string Name = "Фио";
                        bufText = Name;
                        bufReplacementText = СотрудникTextBox.Text;
                    }
                    else if (i == 1)
                    {
                        string Name = "Дт";
                        bufText = Name;
                        bufReplacementText = Convert.ToString(bufData);
                    }
                    else if (i == 2)
                    {
                        string Name = "Фиов";
                        bufText = Name;
                        bufReplacementText = NameDoctor;
                    }

                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    Object fileName = DocumentTemplate;
                    Object missing = Type.Missing;
                    app.Documents.Open(ref fileName);
                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                    find.Text = Convert.ToString(bufText);
                    find.Replacement.Text = bufReplacementText;
                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                    find.Execute(
                        FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                    app.ActiveDocument.Save();
                    app.ActiveDocument.Close();
                    app.Quit();

                }
            }
            catch
            {

            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OpenADocument(object sender, RoutedEventArgs e)
        {
            if (СпаравкиComboBox.Text == "Справка")
            {
                System.Diagnostics.Process.Start(DocumentTemplate);
            }
        }

        private void Document(object sender, RoutedEventArgs e)//печать документа
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
            ProcessStartInfo info = new ProcessStartInfo(DocumentTemplate);
            info.Verb = "PrintTo";
            //info.Arguments = pd.PrinterSettings.PrinterName;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }
    }
}
