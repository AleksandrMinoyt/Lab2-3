using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2_3
{
    class CommandList
    {
        public static RoutedUICommand Exit { get; set; }
        public static RoutedCommand SelectColor { get; set; }

        public static RoutedCommand FontUp { get; set; }

        public static RoutedCommand FontDown { get; set; }
        public static RoutedCommand FontBold { get; set; }
        public static RoutedCommand FontItalic { get; set; }
        public static RoutedCommand FontLow { get; set; }


        static CommandList()
        {
            InputGestureCollection inputsExit = new InputGestureCollection();
            inputsExit.Add(new KeyGesture(Key.X, ModifierKeys.Alt, "Alt+X"));
            Exit = new RoutedUICommand("Выход", "Exit", typeof(CommandList), inputsExit);

            InputGestureCollection inputsSelectColor = new InputGestureCollection();
            inputsSelectColor.Add(new KeyGesture(Key.X, ModifierKeys.Alt, "Alt+U"));
            SelectColor = new RoutedCommand("SelectColor", typeof(CommandList), inputsSelectColor);

            FontUp = new RoutedCommand();
            FontDown = new RoutedCommand();
            FontBold = new RoutedCommand();
            FontItalic = new RoutedCommand();
            FontLow = new RoutedCommand();
        }


    }
}
