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
using Bl = BusinessLayer.BusinessLayer;
namespace WpfHtmlTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Bl bl = new Bl();
        private string headFromTextBox = "";
        private string bodyFromTextBox = "";
        private string currentHtmlTableText = "";
        private void HeadersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            headFromTextBox = HeadersTextBox.Text;
            UpdateTable(headFromTextBox,bodyFromTextBox);
        }
        private void BodyRTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            bodyFromTextBox = StringFromRichTextBox(BodyRTB);
            UpdateTable(headFromTextBox,bodyFromTextBox);
        }

        private void UpdateTable(string head, string body)
        {
            string htmlText = bl.makeTableFromTextBoxes(head, body);
            PreviewWB.NavigateToString(bl.makeTableFromTextBoxes(head, body));
            currentHtmlTableText = htmlText;
            UpdateRichTextBox(CodeRTB, htmlText);
        }
        private void UpdateTable(string filepath)
        {
            string htmlText =bl.makeTable(filepath);
            PreviewWB.NavigateToString(htmlText);
            currentHtmlTableText = htmlText;
            UpdateRichTextBox(CodeRTB, htmlText);
        }

        public void UpdateRichTextBox(RichTextBox rtb, string content)
        {
            rtb.SelectAll();
            rtb.Selection.Text = content;
        }

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );
            return textRange.Text;
        }

        private void LoadCSVButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTable(@CsvFilePathTextBox.Text);
        }

        private void CsvSaveButton_Click(object sender, RoutedEventArgs e)
        {
            bl.WriteHtml(CsvSaveTextBox.Text, currentHtmlTableText);
        }
    }
}
