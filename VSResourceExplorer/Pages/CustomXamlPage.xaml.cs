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
        private string exampleXamlInString;

        public CustomXamlPage()
        {
            InitializeComponent();
            CreateExampleXaml();
        }

        private void CreateExampleXaml()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(60, 40, 20, 20);

            TextBlock text1 = new TextBlock();
            text1.Margin = new Thickness(0, 20, 0, 20);
            text1.SetResourceReference(TextBlock.StyleProperty, VsResourceKeys.TextBlockEnvironment200PercentFontSizeStyleKey);
            const string V1 = "This TextBlock uses 200 % environment font style!";
            text1.Text = V1;
            stackPanel.Children.Add(text1);

            TextBlock text2 = new TextBlock();
            text2.Margin = new Thickness(0, 20, 0, 40);
            text2.SetResourceReference(TextBlock.StyleProperty, VsResourceKeys.TextBlockEnvironmentBoldStyleKey);
            const string V2 = "This TextBlock uses bold environment font style!";
            text2.Text = V2;
            stackPanel.Children.Add(text2);

            // Create the Button.
            Button exampleButton = new Button();
            exampleButton.Height = 50;
            exampleButton.Width = 300;
            exampleButton.Background =  Brushes.AliceBlue;

            TextBlock buttonTextBlock = new TextBlock();
            const string V = "Button with 133% env font";
            buttonTextBlock.Text = V;
            buttonTextBlock.SetResourceReference(TextBlock.StyleProperty, VsResourceKeys.TextBlockEnvironment133PercentFontSizeStyleKey);
            stackPanel.Children.Add(exampleButton);

            exampleButton.Content = buttonTextBlock;

            // Save the Button to a string.
            exampleXamlInString = XamlWriter.Save(stackPanel);
            txtXaml.Text = exampleXamlInString;
        }


        private void ShowButtonClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new BaseDialogWindow();
            dialog.Title = "XAML Preview";

            // wrap textbox XAML to Grid
            string wrappedComponent = "<ContentControl xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">";
            wrappedComponent += txtXaml.Text.ToString();
            wrappedComponent += "</ContentControl>";
            
            System.IO.StringReader stringReader = new System.IO.StringReader(wrappedComponent);
            XmlReader xmlReader = XmlReader.Create(stringReader);

            try
            {
                ContentControl exampleGrid = (ContentControl)XamlReader.Load(xmlReader);

                dialog.Content = exampleGrid;
                dialog.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "XAML parse error");
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
