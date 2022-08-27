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

namespace _17_2
{
    /// <summary>
    /// Логика взаимодействия для Colorindex.xaml
    /// </summary>
    public partial class Colorindex : System.Windows.Controls.UserControl
    {
        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        private static readonly RoutedEvent ColorChangedEvent;

        public Colorindex()
        {
            InitializeComponent();
        }
        static Colorindex()
        {
            //Регистрация свойств зависимости
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(Colorindex)),
                new FrameworkProoertyMetadata(Colors.Black, new PagesChangedCallback(onColorChanged));
            RedProperty = DependencyProperty.Register("Color", typeof(byte), typeof(Colorindex)),
                new FrameworkProoertyMetadata(Colors.Black, new PagesChangedCallback(OnColor-RGBChanged));
            GreenProperty = DependencyProperty.Register("Color", typeof(byte), typeof(Colorindex)),
                new FrameworkProoertyMetadata(Colors.Black, new PagesChangedCallback(OnColor-RGBChanged));
            BlueProperty = DependencyProperty.Register("Color", typeof(byte), typeof(Colorindex)),
                new FrameworkProoertyMetadata(Colors.Black, new PagesChangedCallback(OnColor-RGBChanged));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>, typeof(Colorindex)); 
        }
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (Byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (Byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        private static void OnClorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Colorindex colorPicker = (Colorindex)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Colorindex colorindex = (Colorindex)sender;
            colorindex.Red = newColor.R;
            colorindex.Green = newColor.G;
            colorindex.Blue = newColor.B;

            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(colorindex.Color, newColor);
            args.RoutedEvent = ColorChangedEvent;
            colorindex.RaiseEvent(args);
        }
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); } 
        }
    }
}
