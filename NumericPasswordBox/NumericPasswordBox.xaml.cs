using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NumericPasswordBox
{
    public sealed partial class NumericPasswordBox : UserControl
    {       
        private string _passwordChar = "●";

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(NumericPasswordBox), new PropertyMetadata(null));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(NumericPasswordBox), new PropertyMetadata(null));

        public NumericPasswordBox()
        {
            this.InitializeComponent();
            ((FrameworkElement)Content).DataContext = this;
        }

        private void PasswordBox_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            Password = GetNewPasscode(Password, e);
            PasswordBox.Text = Regex.Replace(Password, @".", _passwordChar);
            PasswordBox.SelectionStart = !string.IsNullOrEmpty(PasswordBox.Text) ? PasswordBox.Text.Length : 0;
        }

        private string GetNewPasscode(string oldPasscode, KeyRoutedEventArgs keyEventArgs)
        {
            string newPasscode = string.Empty;
            switch (keyEventArgs.Key)
            {
                case VirtualKey.Number0:
                    newPasscode = oldPasscode + "0";
                    break;
                case VirtualKey.Number1:
                    newPasscode = oldPasscode + "1";
                    break;
                case VirtualKey.Number2:
                    newPasscode = oldPasscode + "2";
                    break;
                case VirtualKey.Number3:
                    newPasscode = oldPasscode + "3";
                    break;
                case VirtualKey.Number4:
                    newPasscode = oldPasscode + "4";
                    break;
                case VirtualKey.Number5:
                    newPasscode = oldPasscode + "5";
                    break;
                case VirtualKey.Number6:
                    newPasscode = oldPasscode + "6";
                    break;
                case VirtualKey.Number7:
                    newPasscode = oldPasscode + "7";
                    break;
                case VirtualKey.Number8:
                    newPasscode = oldPasscode + "8";
                    break;
                case VirtualKey.Number9:
                    newPasscode = oldPasscode + "9";
                    break;
                case VirtualKey.Back:
                    if (oldPasscode.Length > 0)
                    {
                        newPasscode = oldPasscode.Substring(0, oldPasscode.Length - 1);
                    }
                    break;
                default:
                    //others
                    newPasscode = oldPasscode;
                    break;
            }
            return newPasscode;
        }
    }
}
