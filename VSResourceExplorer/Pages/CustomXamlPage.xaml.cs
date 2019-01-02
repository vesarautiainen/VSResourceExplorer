using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.VisualStudio.Shell;

namespace VSResourceExplorer
{
    /// <summary>
    /// Interaction logic for CustomXamlPage.xaml
    /// </summary>
    public partial class CustomXamlPage : UserControl
    {
        private string exampleButtonInString;

        public CustomXamlPage()
        {
            InitializeComponent();
            CreateExampleButton();
        }

        private void CreateExampleButton()
        {
            // Create the Button.
            Button originalButton = new Button();
            originalButton.Height = 50;
            originalButton.Width = 150;
            originalButton.Background =  Brushes.AliceBlue;

            TextBlock buttonTextBlock = new TextBlock();
            const string V = "Example button!!";
            buttonTextBlock.Text = V;
            buttonTextBlock.SetResourceReference(TextBlock.StyleProperty, VsResourceKeys.TextBlockEnvironment133PercentFontSizeStyleKey);
            originalButton.Content = buttonTextBlock;

            // Save the Button to a string.
            exampleButtonInString = XamlWriter.Save(originalButton);
            txtXaml.Text = exampleButtonInString;
        }

        private void ShowButtonClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new BaseDialogWindow();
            dialog.Title = "XAML Preview";

            // Load the button
            System.IO.StringReader stringReader = new System.IO.StringReader(txtXaml.Text);
            XmlReader xmlReader = XmlReader.Create(stringReader);

            try
            {
                Button exampleButton = (Button)XamlReader.Load(xmlReader);
                var grid = new Grid();
                grid.Children.Add(exampleButton);

                dialog.Content = grid;
                dialog.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error in XAML parsing");
            }
            finally
            {
   
            }
    
        }

        private void TxtXaml_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
