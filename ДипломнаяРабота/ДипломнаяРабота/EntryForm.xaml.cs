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
using System.Windows.Shapes;

namespace ДипломнаяРабота
{
    /// <summary>
    /// Логика взаимодействия для EntryForm.xaml
    /// </summary>
    public partial class EntryForm : Window
    {
        public EntryForm()
        {
            InitializeComponent();
            Uri iconUri = new Uri("D://Studia//ДипломнаяРабота//ДипломнаяРабота//Bitmap1.bmp", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }
    }
}
