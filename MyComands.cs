using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4
{
    static class MyComands
    {
        public static RoutedUICommand WCross;
        public static RoutedUICommand About;

        static MyComands()
        {
            InputGestureCollection igc = new InputGestureCollection();
            igc.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
            WCross = new RoutedUICommand("WCross", "WCross", typeof(MyComands));
            About = new RoutedUICommand("About", "About", typeof(MyComands), igc);
        }
    }
    //class MyComand
    //{
    //    public static RoutedUICommand OkButton;

    //    static void MyCommand()
    //    {
    //        InputGestureCollection igc = new InputGestureCollection();
    //        igc.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
    //        OkButton = new RoutedUICommand("My Draw Ellipse", "MyDrawEllipse", typeof(string), igc);
    //    }
    //}
}
