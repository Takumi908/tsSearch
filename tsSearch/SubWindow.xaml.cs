using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // var consumerKey = "";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            int checknumber = 0;
            //出力  



            foreach (var item in Books.items) {
                /*
         if (item.volumeInfo.title == null || item.volumeInfo.authors == null) {
             MessageBox.Show("取得できませんでした");
             this.Close();
         } else {   }
         */           //numberが０のときに実行
                if (checknumber == 0) {
                    // 入力ボックスの著者が空ではなく取得先の著者がnullではない場合ture
                    if (MainWindow.scauthor != "" && item.volumeInfo.authors != null) {
                        //著者が一致した書籍を取得  
                        foreach (string i in item.volumeInfo.authors) {
                            if (MainWindow.scauthor == i) {

                                //タイトル
                                tbSearch.Text += ($"{item.volumeInfo.title}  ");

                                //作者
                                if (item.volumeInfo.authors != null) {
                                    tbSearch.Text += ($"{string.Join(",", item.volumeInfo.authors)}  ");
                                }

                                //出版社                                    
                                if (item.volumeInfo.publisher != null) {

                                    tbSearch.Text += ($"{item.volumeInfo.publisher} \n");
                                } else {
                                    tbSearch.Text += ($" 出版社不明 \n");
                                }
                                checknumber = 1;
                            }
                        }
                    }
                }   
                if (checknumber == 0) {
                    // タイトルが空ではない場合
                    if (MainWindow.sctitle != "") {
                        //タイトルが含まれている書籍を取得  
                        //   if (MainWindow.sctitle == item.volumeInfo.title) {
                        if (item.volumeInfo.title.Contains(MainWindow.sctitle)) {

                            //タイトル
                            tbSearch.Text += ($"{item.volumeInfo.title}  ");

                            //作者
                            if (item.volumeInfo.authors != null) {
                                tbSearch.Text += ($"{string.Join(",", item.volumeInfo.authors)}  ");
                            }

                            //出版社                                    
                            if (item.volumeInfo.publisher != null) {

                                tbSearch.Text += ($"{item.volumeInfo.publisher} \n");
                            } else {
                                tbSearch.Text += ($" 出版社不明 \n");
                            }
                            checknumber = 1;
                        }
                    }
                }
                if (checknumber == 0) {
                    // 出版社が空ではない場合
                    if (MainWindow.scpublisher != "") {
                        //出版社が一致した書籍を取得  
                        if (MainWindow.scpublisher == item.volumeInfo.publisher) {

                            //タイトル
                            tbSearch.Text += ($"{item.volumeInfo.title}  ");

                            //作者
                            if (item.volumeInfo.authors != null) {
                                tbSearch.Text += ($"{string.Join(",", item.volumeInfo.authors)}  ");
                            }

                            //出版社                                    
                            if (item.volumeInfo.publisher != null) {

                                tbSearch.Text += ($"{item.volumeInfo.publisher} \n");
                            } else {
                                tbSearch.Text += ($" 出版社不明 \n");
                            }
                            checknumber = 1;
                        }
                    }
                }
                //numberリセット
                checknumber = 0;
            }
            //書籍が見つからなかった時戻る
            if (tbSearch.Text == "") {
                MessageBox.Show("該当する書籍が見つかりませんでした");
                this.Close();
            }
        }
    }
}
