﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static tsSearch.Books;
using MessageBox = System.Windows.MessageBox;

namespace tsSearch
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class DataWindow
    {
        public DataWindow() {
            InitializeComponent();
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        }

        List<string> Url = new List<string>();


        private void rtButton_Click(object sender, RoutedEventArgs e) {

        }

        private void edButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //dataGrid.AltenatingRowBackground = system.windows/
            DataList dataList = new DataList();
            dataList.List();

            var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            var datas = new ObservableCollection<Data>();

            string checknumber = "0";
            string chTitle = "0";
            string chAuhor = "0";
            string chPublisher = "0";

            if (MainWindow.sctitle != "") {
                chTitle = "1";
            }
            if (MainWindow.scauthor != "") {
                chAuhor = "1";
            }
            if (MainWindow.scpublisher != "") {
                chPublisher = "1";
            }
            checknumber = chTitle + chAuhor + chPublisher;
            if (Books.items != null) {
                foreach (var item in Books.items) {
                    if (item.volumeInfo.industryIdentifiers != null) {
                        foreach (var i in item.volumeInfo.industryIdentifiers.FindAll(f => f.identifier.Length == 13)) {
                            if (item.volumeInfo.authors != null) {


                                switch (checknumber) {
                                    //タイトルのみ
                                    case "100":

                                        if (item.volumeInfo.title.Contains(MainWindow.sctitle)) {
                                            Url.Add(item.volumeInfo.infoLink);
                                            datas.Add(new Data()
                                            {
                                                Title = item.volumeInfo.title,
                                                Author = string.Join(",", item.volumeInfo.authors),
                                                Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                Isbn = i.identifier ?? "リンク無し",
                                            });
                                        }
                                        break;
                                    //著者
                                    case "010":
                                        if (item.volumeInfo.authors != null) {
                                            foreach (string au in item.volumeInfo.authors) {
                                                if (MainWindow.scauthor == au) {
                                                    Url.Add(item.volumeInfo.infoLink);
                                                    datas.Add(new Data()
                                                    {
                                                        Title = item.volumeInfo.title,
                                                        Author = string.Join(",", item.volumeInfo.authors),
                                                        Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                        Isbn = i.identifier,
                                                    });
                                                }
                                            }
                                        }

                                        break;
                                    //出版社
                                    case "001":
                                        if (MainWindow.scpublisher == i.identifier) {
                                            Url.Add(item.volumeInfo.infoLink);
                                            datas.Add(new Data()
                                            {
                                                Title = item.volumeInfo.title,
                                                Author = string.Join(",", item.volumeInfo.authors),
                                                Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                Isbn = i.identifier,
                                            });
                                        }
                                        break;
                                    //タイトル&著者
                                    case "110":
                                        if (item.volumeInfo.authors != null) {
                                            foreach (string au in item.volumeInfo.authors) {
                                                if (item.volumeInfo.title.Contains(MainWindow.sctitle) && MainWindow.scauthor == au) {
                                                    Url.Add(item.volumeInfo.infoLink);
                                                    datas.Add(new Data()
                                                    {
                                                        Title = item.volumeInfo.title,
                                                        Author = string.Join(",", item.volumeInfo.authors),
                                                        Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                        Isbn = i.identifier,
                                                    });
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        listView.ItemsSource = datas;
                    }
                }
                if (listView.Items.Count == 0) {
                    MessageBox.Show("該当する書籍が見つかりませんでした");
                    this.Close();
                }
            }
        }


        private void ulButton_Click(object sender, RoutedEventArgs e) {           
            int Index = listView.SelectedIndex;
            if (Index >= 0) {
                System.Diagnostics.Process.Start(Url[Index]);
            } else {
                MessageBox.Show("選択されていません");
            }
        }
    }
}
