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
using WpfControlLibrary1;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {
        UserControl1 us = new UserControl1();
        public UserControl1 UserControl1
        {
            get
            {
                return us;
            }
        }

        public MyDialog()
        {
            InitializeComponent();
            DataContext = us;

        }
        private void tbThickness_TextChanged(object sender, TextChangedEventArgs e)
        {


            MainWindow.UserChooseThickness = int.Parse(tbThickness.Text);



        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
