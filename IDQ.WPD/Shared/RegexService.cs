using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace IDQ.WPF.Shared
{
    public class RegexService
    {

        public static void regexNumbers(object sender, TextCompositionEventArgs e)
        {
            if (e != null)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }
        public static void regexNegativeNumbers(object sender, TextCompositionEventArgs e)
        {
            if (e != null)
            {
                Regex regex = new Regex("-?[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }

        public static void regexDouble(object sender, TextCompositionEventArgs e)
        {/*
            if (e != null)
            {
                Regex regex = new Regex(@"^-?\d(.\d+)?[^.]");
                //var testBol = Regex.Matches(e.Text, @"\.").Count > 1;
                e.Handled = regex.IsMatch(e.Text);
            }
            //e.Handled = Decimal.TryParse(e.Text, out _);
            */
            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !(regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)) && !(e.Text.IndexOf(".") > 0 || e.Text.IndexOf(".") != e.Text.IndexOf(".")));

        }
    }
}
