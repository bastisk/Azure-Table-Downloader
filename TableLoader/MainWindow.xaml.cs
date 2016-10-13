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
using Microsoft.Azure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.Storage.Table;
using DataAccess;
using Microsoft.WindowsAzure;
using System.Windows.Forms;

namespace TableLoader
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LB1.Content = "Downloading rows, please wait ...";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(textBox.Text);
            String table = textBox1.Text;
            var dataFromTable = DataTable.New.ReadAzureTableLazy(storageAccount, table);
            dataFromTable.SaveCSV(textBox2.Text);
            LB1.Content = "Download completed!";

       


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            textBox2.Text = dialog.SelectedPath + "\\out.csv";
        }
    }
}
