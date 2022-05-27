using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoNuts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoffeePage : Page
    {
        string roast = "";
        string sweet = "";
        string cream = "";
        public CoffeePage()
        {
            this.InitializeComponent();
        }

        private void rstBlack_Click(object sender, RoutedEventArgs e)
        {
            roast = "black";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void rstMed_Click(object sender, RoutedEventArgs e)
        {
            roast = "medium";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void swtNon_Click(object sender, RoutedEventArgs e)
        {
            sweet = "no sugar";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void swtSug_Click(object sender, RoutedEventArgs e)
        {
            sweet = "sugar";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void crmNon_Click(object sender, RoutedEventArgs e)
        {
            cream = "no milk";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void crmSpec_Click(object sender, RoutedEventArgs e)
        {
            cream = "1,5% milk";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }

        private void crmMilk_Click(object sender, RoutedEventArgs e)
        {
            cream = "milk";
            kafe.Text = "Coffee: " + roast + ", " + sweet + ", " + cream;
        }
    }
}
