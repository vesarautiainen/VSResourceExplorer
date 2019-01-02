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

namespace VSResourceExplorer
{
    /// <summary>
    /// Interaction logic for CustomXamlPage.xaml
    /// </summary>
    public partial class CustomXamlPage : UserControl
    {
        public CustomXamlPage()
        {
            InitializeComponent();
        }

        private void ShowButtonClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new BaseDialogWindow();
            dialog.Title = "This is the custom dialog";

            var textBlock = new TextBlock();
            textBlock.Text = "This dialog would display the XAML from the text box on the previous page:";
            textBlock.Text += "\r\n" + "\r\n" + txtXaml.Text;
            textBlock.Width = 350;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;

            var grid = new Grid();
            grid.Children.Add(textBlock);

            dialog.Content = grid;
            dialog.ShowDialog();
        }

        private void TxtXaml_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
