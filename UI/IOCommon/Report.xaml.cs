using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
namespace IOCommon
{
    /// <summary>
    /// Report.xaml 的交互逻辑
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
          
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            var sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.FileName = Title;
            sfd.DefaultExt = "rtf";
            sfd.Filter = "RTF 文件 (*.rtf))|*.rtf";
            sfd.RestoreDirectory = false;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = sfd.OpenFile()) != null)
                {                    
                    TextRange documentTextRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                    documentTextRange.Save(myStream,DataFormats.Rtf);
                    myStream.Close();
                }               
            }
        }
        private void Print(object sender, RoutedEventArgs e)
        {
           var dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {                
                dialog.PrintDocument(((IDocumentPaginatorSource)RichTextBox.Document).DocumentPaginator, Title);
            }
        }
    }
}
