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
using WpfControlLibrary1;
using System.IO;
using System.Xml;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public int UserChooseThickness { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += Main_MouseDoun;
            this.MouseMove += MainWindow_MouseMove;
            
            CommandBinding bidingSave = new CommandBinding(ApplicationCommands.Save);
            bidingSave.Executed += BidingSave_Executed;
            CommandBinding bidingOpen = new CommandBinding(ApplicationCommands.Open);
            bidingOpen.Executed += BidingOpen_Executed;
            this.CommandBindings.Add(bidingSave);
            this.CommandBindings.Add(bidingOpen);
            CommandBinding bindingAbout = new CommandBinding(MyComands.About);
            bindingAbout.Executed += BindingAbout_Executed;
            this.CommandBindings.Add(bindingAbout);
            CommandBinding bindingLineThickness = new CommandBinding(MyComands.WCross);
            bindingLineThickness.Executed += BindingLineThickness_Executed;
            this.CommandBindings.Add(bindingLineThickness);
        }

        private void BindingLineThickness_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MyDialog dialog = new MyDialog();
            if ((dialog.ShowDialog()) == true)
            {
                foreach (var item in star.Children)
                {
                    if (item is UserControl1)
                    {
                        ((UserControl1)item).WCross = UserChooseThickness;
                    }
                }
            }
        }

        private void BidingOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            star.Children.Clear();
            string fileName = System.IO.Path.GetFileNameWithoutExtension("test.txt");
            this.Title = fileName;
            StreamReader sr = new StreamReader("test.txt", Encoding.GetEncoding(1251));
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                string[] parts = str.Split(';');
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);
                int thickness = int.Parse(parts[2]);
                string background = parts[3];
                byte r = Convert.ToByte(parts[3].Substring(3, 2), 16);
                byte g = Convert.ToByte(parts[3].Substring(5, 2), 16);
                byte b = Convert.ToByte(parts[3].Substring(7, 2), 16);

                SolidColorBrush backgroundColor = new SolidColorBrush(Color.FromRgb(r, g, b));
                string line = parts[4];

                r = Convert.ToByte(parts[4].Substring(3, 2), 16);
                g = Convert.ToByte(parts[4].Substring(5, 2), 16);
                b = Convert.ToByte(parts[4].Substring(7, 2), 16);
                SolidColorBrush lineColor = new SolidColorBrush(Color.FromRgb(r, g, b));

                UserControl1 uc = new UserControl1();
                uc.WCross = thickness;
                uc.AllStar = backgroundColor;
                uc.WBrush = lineColor;
                Canvas.SetLeft(uc, x);
                Canvas.SetTop(uc, y);
                star.Children.Add(uc);
            }
            sr.Close();
        }

        private void BidingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("test.txt", false, Encoding.GetEncoding(1251));
            foreach (var item in star.Children)
            {
                if (item is UserControl1)
                {
                    double x = Canvas.GetLeft((UserControl1)item);
                    double y = Canvas.GetTop((UserControl1)item);
                    int thickness = ((UserControl1)item).WCross;
                    string background = ((UserControl1)item).AllStar.ToString();
                    string lineColor = ((UserControl1)item).WBrush.ToString();
                    string str = $"{x:0.00};{y:0.00};{thickness};{background};{lineColor}";
                    sw.WriteLine(str);

                }
            }
            sw.Close();
        }    
        
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
    {
        double x = e.GetPosition(star).X;
        double y = e.GetPosition(star).Y;
        if (x >= 0 && y >= 0)
        {
            stBar.Content = $"x={x:0} y={y:0}";
        }
        else
            stBar.Content = "Вы вышли за пределы окна!";
    }

    //ЛКМ вывод фигуры
    private void Main_MouseDoun(object sender, MouseButtonEventArgs e)
    {
        double x = e.GetPosition(star).X;
        double y = e.GetPosition(star).Y;
        UserControl1 uc = new UserControl1();
        Canvas.SetLeft(uc, x);
        Canvas.SetTop(uc, y);

        star.Children.Add(uc);
    }
    //вызов диалогового окна через меню
    private void MenuItemColor_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
        colorDialog.ShowDialog();
        System.Drawing.Color color1 = colorDialog.Color;
        Color color = Colors.Red;
        color.A = color1.A;
        color.R = color1.R;
        color.G = color1.G;
        color.B = color1.B;

        foreach (var item in star.Children)
        {
            if (item is UserControl1)
            {

                double x = Canvas.GetLeft((UserControl1)item);
                double y = Canvas.GetTop((UserControl1)item);
                ((UserControl1)item).AllStar = new SolidColorBrush(color);
            }
        }
        
    }
    //вызов диалогового окна через панель
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
        colorDialog.ShowDialog();
        System.Drawing.Color color1 = colorDialog.Color;
        Color color = Colors.Red;
        color.A = color1.A;
        color.R = color1.R;
        color.G = color1.G;
        color.B = color1.B;
        //Brush brush = new SolidColorBrush(color);
        foreach (var item in star.Children)
        {
            if (item is UserControl1)
            {

                double x = Canvas.GetLeft((UserControl1)item);
                double y = Canvas.GetTop((UserControl1)item);
                ((UserControl1)item).AllStar = new SolidColorBrush(color);
            }
        }


    }
    //о программе -вывод диалога
    private void BindingAbout_Executed(object sender, RoutedEventArgs e)
    {
            MessageBox.Show("Программист Ванслав О.И.", "О программе");
        }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
        colorDialog.ShowDialog();
        System.Drawing.Color color1 = colorDialog.Color;
        Color color = Colors.Red;
        color.A = color1.A;
        color.R = color1.R;
        color.G = color1.G;
        color.B = color1.B;

        foreach (var item in star.Children)
        {
            if (item is UserControl1)
            {

                double x = Canvas.GetLeft((UserControl1)item);
                double y = Canvas.GetTop((UserControl1)item);
                ((UserControl1)item).WBrush = new SolidColorBrush(color);
            }
        }
    }

    private void linia_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
        colorDialog.ShowDialog();
        System.Drawing.Color color1 = colorDialog.Color;
        Color color = Colors.Red;
        color.A = color1.A;
        color.R = color1.R;
        color.G = color1.G;
        color.B = color1.B;

        foreach (var item in star.Children)
        {
            if (item is UserControl1)
            {

                double x = Canvas.GetLeft((UserControl1)item);
                double y = Canvas.GetTop((UserControl1)item);
                ((UserControl1)item).WBrush = new SolidColorBrush(color);
            }
        }
    }

        private void Razmer_Click(object sender, RoutedEventArgs e)
        {

        }

    } 

       
    }
