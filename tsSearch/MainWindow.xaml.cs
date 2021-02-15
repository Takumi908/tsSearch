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
        public static string scurl;
                                                

        //検索ボタン押したときに実行
        private void btSearch_Click(object sender, RoutedEventArgs e) {

            sctitle = tbTitle.Text;
            scauthor = tbAuthor.Text;
            scpublisher = tbPublisher.Text;
            //値がすべて空の場合か項目が二つ以上入力されてる場合エラーボックスを表示
            if ( sctitle != "" && scpublisher != "" || scauthor != "" && scpublisher != "" || sctitle != "" && scauthor != "" && scpublisher != "") {
                MessageBox.Show("入力できる項目は1つです");
            } else {
                DataWindow dataWindow = new DataWindow();
                dataWindow.ShowDialog();
            }
        }
        //設定
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }
    }
}