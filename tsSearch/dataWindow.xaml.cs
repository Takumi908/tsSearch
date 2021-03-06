﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static tsSearch.Books;
using Binding = System.Windows.Data.Binding;
using GridView = System.Windows.Controls.GridView;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.MessageBox;
using View = System.Web.UI.WebControls.View;

namespace tsSearch {
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class DataWindow {
        public DataWindow() {
            InitializeComponent();
        }

        List<string> Url = new List<string>();

        //終了
        private void edButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //メイン画面の検索ボタン押したときに実行
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            var datas = new ObservableCollection<Data>();

            
            if (Books.items != null) {
                foreach (var item in Books.items) {
                    //著者が存在しているか
                    if (item.volumeInfo.authors != null) {
                        foreach (var i in item.volumeInfo.industryIdentifiers.FindAll(f => f.identifier.Length == 13)) {
                            //ISBNコードが13桁のものを取得
                            if (i.identifier.Length == 13) {
                                Url.Add(item.volumeInfo.infoLink);
                                datas.Add(new Data() {
                                    Title = item.volumeInfo.title,
                                    Author = string.Join(",", item.volumeInfo.authors),
                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                    Isbn = i.identifier,
                                });
                                listView.ItemsSource = datas;
                            //取得出来ない場合コード不明で出力
                            } else {
                                Url.Add(item.volumeInfo.infoLink);
                                datas.Add(new Data() {
                                    Title = item.volumeInfo.title,
                                    Author = string.Join(",", item.volumeInfo.authors),
                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                    Isbn = "コード不明",
                                });
                                listView.ItemsSource = datas;
                            }
                        }
                    }
                }
                //書籍が見つからない場合、ダイアログを表示し検索画面に戻る
            } else {
                if (listView.Items.Count == 0) {
                    MessageBox.Show("該当する書籍が見つかりませんでした");
                    this.Close();
                }
            }
        }
        //詳細ボタン
        private void ulButton_Click(object sender, RoutedEventArgs e) {
            int Index = listView.SelectedIndex;
            //GoogleBooksライブラリのページへ移動
            if (Index >= 0) {
                System.Diagnostics.Process.Start(Url[Index]);
            } else {
                MessageBox.Show("選択されていません");
            }
        }
    }
}