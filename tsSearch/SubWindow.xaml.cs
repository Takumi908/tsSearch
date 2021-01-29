using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace tsSearch
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow() {
            InitializeComponent();
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {

        }

        private void rtButton_Click(object sender, RoutedEventArgs e) {

        }

        private void edButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

          
           var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            var api = new GoogleBooksAPI(consumerKey);
            //GoogleBooksAPI.EndPointUrl += ($"+title={MainWindow.sctitle}");
            GoogleBooksAPI.EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=search+title={MainWindow.sctitle}+author={MainWindow.scauthor}=time&printType=books&country=JP&langRestrict=ja&maxResults=40&key");
            var Books = api.GetBooks();


            //出力
            foreach (var item in Books.items) {
                //タイトル
                tbSearch.Text += ($"{item.volumeInfo.title} ");
                //作者
                if (item.volumeInfo.authors != null) {
                    tbSearch.Text += ($"{string.Join(",", item.volumeInfo.authors)} ");
                } else {
                    Console.Write("作者無し");
                }
                //出版社
                tbSearch.Text += ($"{item.volumeInfo.publisher}") + "\n";

            }
        }
    }
}