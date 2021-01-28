using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tsSearch
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow() {
            InitializeComponent();

        }
        public static string sctitle;
        public static string scauthor;
        public static string scpublisher;

            //検索ボタン押したときに実行
        private void btSearch_Click(object sender, RoutedEventArgs e) {
             sctitle = tbTitle.Text;
             scauthor = tbAuthor.Text;
             scpublisher = lbPublisher.Text;
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
           // Books.Boxdate
            
        }
            //設定
            private void btConfig_Click(object sender, RoutedEventArgs e) {
                ConfigWindow configWindow = new ConfigWindow();
                configWindow.ShowDialog();
            }
         
        private void tbTitle_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}