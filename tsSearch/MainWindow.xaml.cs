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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

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
            //値がすべて空の場合エラーボックスを表示
            sctitle = tbTitle.Text;
            scauthor = tbAuthor.Text;
            scpublisher = tbPublisher.Text;
            if (sctitle == "" && scauthor == "" && scpublisher == "") {
                MessageBox.Show("値が空です");
            } else {
                SearchWindow searchWindow = new SearchWindow();
                searchWindow.ShowDialog();
            }
        }
        //設定
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DataWindow dataWindow = new DataWindow();
            dataWindow.ShowDialog();
        }
    }
}