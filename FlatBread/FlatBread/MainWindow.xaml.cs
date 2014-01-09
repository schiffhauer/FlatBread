namespace FlatBread
{
    using System.IO;
    using System.Text;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileBrowseBtnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt, .csv)|*.txt;*.csv",
                Multiselect = false
            };

            var result = dlg.ShowDialog();

            if (result != true)
            {
                return;
            }

            var filename = string.Join(";", dlg.FileNames);
            this.FilenameTbx.Text = filename;
        }

        private void QuoteEncloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var inputFile = FilenameTbx.Text;
            var stringBuilder = new StringBuilder();

            foreach (var line in File.ReadAllLines(inputFile))
            {
                stringBuilder.AppendLine(string.Format("\"{0}\"", string.Join("\",\"", line.Split(','))));
            }

            File.WriteAllText(string.Format(@"{0}\Output.csv", Path.GetDirectoryName(inputFile)), stringBuilder.ToString());
        }
    }
}
