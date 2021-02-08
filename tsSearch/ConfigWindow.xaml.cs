using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace tsSearch
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow() {
            InitializeComponent();
        }
        //閉じる
        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        //取得
        private void btGet_Click(object sender, RoutedEventArgs e) {
            var consumerKey = "";
            GoogleBooksAPI.EndPointUrl = "https://www.googleapis.com/books/v1/volumes?q=search";
            var api = new GoogleBooksAPI(consumerKey); 
            var books = api.GetBooks(); //そのまま出力(エンコードしただけ）
        }
    }
}
