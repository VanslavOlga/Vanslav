using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace lab2_2
{
    class MainWindow : Window
    {

        RadioButton rb1 = new RadioButton() { Content = "градусы" };
        RadioButton rb2 = new RadioButton() { Content = "радианы" };
        RadioButton rb3 = new RadioButton() { Content = "грады" };

        TextBox screen = new TextBox() { Width = 150, Height = 35 };
        Button one = new Button() { Width = 35, Height = 35 };
        Button two = new Button() { Width = 35, Height = 35 };
        Button three = new Button() { Width = 35, Height = 35 };
        Button four = new Button() { Width = 35, Height = 35 };
        Button fife = new Button() { Width = 35, Height = 35 };
        Button six = new Button() { Width = 35, Height = 35 };
        Button seven = new Button() { Width = 35, Height = 35 };
        Button eitht = new Button() { Width = 35, Height = 35 };
        Button nine = new Button() { Width = 35, Height = 35 };
        Button zero = new Button() { Width = 75, Height = 35 };
        Button point = new Button() { Width = 35, Height = 35 };

        Button plus = new Button() { Width = 35, Height = 35 };
        Button minus = new Button() { Width = 35, Height = 35 };
        Button div = new Button() { Width = 35, Height = 35 };
        Button mult = new Button() { Width = 35, Height = 35 };
        Button sin = new Button() { Width = 35, Height = 35 };
        Button cos = new Button() { Width = 35, Height = 35 };
        Button tan = new Button() { Width = 35, Height = 35 };
        Button clear = new Button() { Width = 35, Height = 35 };   
        Button rezult = new Button() { Width = 35, Height = 35 };


        int znak = 0;
        string OldZnac;

        public MainWindow()
        {
            GroupBox gb = new GroupBox();
            
            this.Title = "Калькулятор";
            this.Width = 250;
            this.Height = 300;

            Canvas canvas = new Canvas();
            this.Content = canvas;

            canvas.Children.Add(gb);
            Canvas canvas2 = new Canvas();
            gb.Content = canvas2;
            canvas2.Children.Add(rb1);
            canvas2.Children.Add(rb2);
            canvas2.Children.Add(rb3);


            Canvas.SetLeft(rb1, 20);
            Canvas.SetTop(rb1, 60);
            Canvas.SetLeft(rb2, 90);
            Canvas.SetTop(rb2, 60);
            Canvas.SetLeft(rb3, 160);
            Canvas.SetTop(rb3, 60);

            canvas.Children.Add(screen);
            Canvas.SetLeft(screen, 20);
            Canvas.SetTop(screen, 10);            
            
                zero.Content = "0";
                Canvas.SetLeft(zero, 20);
                Canvas.SetTop(zero, 210);

                point.Content = ",";
                Canvas.SetLeft(point, 100);
                Canvas.SetTop(point, 210);

                one.Content = "1";
                Canvas.SetLeft(one, 20);
                Canvas.SetTop(one, 170);

                two.Content = "2";
                Canvas.SetLeft(two, 60);
                Canvas.SetTop(two, 170);

                three.Content = "3";
                Canvas.SetLeft(three, 100);
                Canvas.SetTop(three, 170);

                four.Content = "4";
                Canvas.SetLeft(four, 20);
                Canvas.SetTop(four, 130);

                fife.Content = "5";
                Canvas.SetLeft(fife, 60);
                Canvas.SetTop(fife, 130);

                six.Content = "6";
                Canvas.SetLeft(six, 100);
                Canvas.SetTop(six, 130);

                seven.Content = "7";
                Canvas.SetLeft(seven, 20);
                Canvas.SetTop(seven, 90);

                eitht.Content = "8";
                Canvas.SetLeft(eitht, 60);
                Canvas.SetTop(eitht, 90);

                nine.Content = "9";
                Canvas.SetLeft(nine, 100);
                Canvas.SetTop(nine, 90);
            

            plus.Content = "+";
            Canvas.SetLeft(plus, 140);
            Canvas.SetTop(plus, 210);

            sin.Content = "sin";
            Canvas.SetLeft(sin, 180);
            Canvas.SetTop(sin, 210);

            minus.Content = "-";
            Canvas.SetLeft(minus, 140);
            Canvas.SetTop(minus, 170);

            cos.Content = "cos";
            Canvas.SetLeft(cos, 180);
            Canvas.SetTop(cos, 170);

            div.Content = "/";
            Canvas.SetLeft(div, 140);
            Canvas.SetTop(div, 130);

            tan.Content = "tan";
            Canvas.SetLeft(tan, 180);
            Canvas.SetTop(tan, 130);

            mult.Content = "*";
            Canvas.SetLeft(mult, 140);
            Canvas.SetTop(mult, 90);

            clear.Content = "C";
            Canvas.SetLeft(clear, 180);
            Canvas.SetTop(clear, 10);

            rezult.Content = "=";
            Canvas.SetLeft(rezult, 180);
            Canvas.SetTop(rezult, 90);

            canvas.Children.Add(zero);
            canvas.Children.Add(point);
            canvas.Children.Add(one);
            canvas.Children.Add(two);
            canvas.Children.Add(three);
            canvas.Children.Add(four);
            canvas.Children.Add(fife);
            canvas.Children.Add(six);
            canvas.Children.Add(seven);
            canvas.Children.Add(eitht);
            canvas.Children.Add(nine);
            canvas.Children.Add(plus);
            canvas.Children.Add(minus);
            canvas.Children.Add(div);
            canvas.Children.Add(mult);
            canvas.Children.Add(sin);
            canvas.Children.Add(cos);
            canvas.Children.Add(tan);
            canvas.Children.Add(clear);
            canvas.Children.Add(rezult);

            one.Click += new RoutedEventHandler(Button_Click);
            two.Click += new RoutedEventHandler(Button_Click);
            three.Click += new RoutedEventHandler(Button_Click);
            four.Click += new RoutedEventHandler(Button_Click);
            fife.Click += new RoutedEventHandler(Button_Click);
            six.Click += new RoutedEventHandler(Button_Click);
            seven.Click += new RoutedEventHandler(Button_Click);
            eitht.Click += new RoutedEventHandler(Button_Click);
            nine.Click += new RoutedEventHandler(Button_Click);
            zero.Click += new RoutedEventHandler(Button_Click);
            point.Click += new RoutedEventHandler(Button_Click);
            clear.Click += new RoutedEventHandler(clear_Click);
            plus.Click += new RoutedEventHandler(plus_Click);
            minus.Click += new RoutedEventHandler(minus_Click);
            div.Click += new RoutedEventHandler(div_Click);
            mult.Click += new RoutedEventHandler(mult_Click);
            rezult.Click += new RoutedEventHandler(result_Click);
            sin.Click += new RoutedEventHandler(sin_Click);
            cos.Click += new RoutedEventHandler(cos_Click);
            tan.Click += new RoutedEventHandler(tan_Click);

            rb1.Checked += Rb_Checked;
            rb2.Checked +=  Rb_Checked;
            rb3.Checked +=  Rb_Checked;

            rb3.IsChecked = true;

        }

        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {

            }
        }


        private double Trig(Double a)
        {
            if (rb1.IsChecked == true)
            {
                return Convert.ToInt32(OldZnac) * Math.PI / 180;
            }
            else if (rb3.IsChecked == true)
            {
                return Convert.ToInt32(OldZnac) * Math.PI / 200;
            }
            else
            {
                return a;
            }
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {


            if (rb1.IsChecked == true)
            {               
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 180;
                double c = Math.Tan(d);
                screen.Text = c.ToString();
            }
            else if (rb3.IsChecked == true)
            {
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 200;
                double c = Math.Tan(d);
                screen.Text = c.ToString();
            }
            else
            {
                double b = double.Parse(screen.Text);
                double c = Math.Tan(b);
                screen.Text = c.ToString();
            }
        }

        private void cos_Click(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {
                //double a = double.Parse(screen.Text);
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 180;
                double c = Math.Cos(d);
                screen.Text = c.ToString();
            }
            else if (rb3.IsChecked == true)
            {
                //double a = double.Parse(screen.Text);
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 200;
                double c = Math.Cos(d);
                screen.Text = c.ToString();
            }
            else
            {
                double b = double.Parse(screen.Text);
                double c = Math.Cos(b);
                screen.Text = c.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            screen.Text += b.Content.ToString();
                       
        }
        
        

        private void clear_Click(object sender, RoutedEventArgs e)
            {
                screen.Text = "";
                znak = 0;
            }
            private void plus_Click(object sender, RoutedEventArgs e)
            {
                znak = 1;
                OldZnac = screen.Text;
                screen.Text = " ";
            }
            private void minus_Click(object sender, RoutedEventArgs e)
            {
                znak = 2;
                OldZnac = screen.Text;
                screen.Text = " ";
            }

            private void div_Click(object sender, RoutedEventArgs e)
            {
                znak = 3;
                OldZnac = screen.Text;
                screen.Text = " ";
            }

            private void mult_Click(object sender, RoutedEventArgs e)
            {
                znak = 4;
                OldZnac = screen.Text;
                screen.Text = " ";
            }


        private void sin_Click(object sender, RoutedEventArgs e)
        {

            if (rb1.IsChecked == true)
            {
                //double a = double.Parse(screen.Text);
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 180;
                double c = Math.Sin(d);
                screen.Text = c.ToString();
            }
            else if (rb3.IsChecked == true)
            {
                //double a = double.Parse(screen.Text);
                OldZnac = screen.Text;
                double d = Convert.ToInt32(OldZnac) * Math.PI / 200;
                double c = Math.Sin(d);
                screen.Text = c.ToString();
            }
            else
            {
                double b = double.Parse(screen.Text);
                double c = Math.Sin(b);
                screen.Text = c.ToString();
            }
        }


        private void result_Click(object sender, RoutedEventArgs e)
            {
                int rezult;
                if (znak == 1)
                {
                    rezult = Convert.ToInt32(OldZnac) + Convert.ToInt32(screen.Text);
                    screen.Text = Convert.ToString(rezult);
                    znak = 0;
                }
                

                else if (znak == 2)
                {
                    rezult = Convert.ToInt32(OldZnac) - Convert.ToInt32(screen.Text);
                    screen.Text = Convert.ToString(rezult);
                    znak = 0;
                }
                else if (znak == 3)
                {
                    rezult = Convert.ToInt32(OldZnac) / Convert.ToInt32(screen.Text);
                    screen.Text = Convert.ToString(rezult);
                    znak = 0;
                }
                else if (znak == 4)
                {
                    rezult = Convert.ToInt32(OldZnac) * Convert.ToInt32(screen.Text);
                    screen.Text = Convert.ToString(rezult);
                    znak = 0;
                }
                
                else MessageBox.Show("Вы не выбрали действие!");

            }
        }
    }
