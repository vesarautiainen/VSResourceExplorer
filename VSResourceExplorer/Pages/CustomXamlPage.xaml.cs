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

            var button = new Button();
            button.Content = "Test Button";
            button.Width = 95;
            button.Height = 35;

            var stackPanel = new StackPanel();
            stackPanel.Children.Add(button);

            dialog.Content = stackPanel;
            dialog.ShowDialog();
        }

        private void TxtXaml_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
