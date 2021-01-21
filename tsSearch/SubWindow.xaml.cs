﻿using System;
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

namespace tsSearch {
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchWindow : Window {
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
            //var list = Item.Tostring<int>

            var Books = api.GetBooks();
            //tbSearch.Text = api.Json; //そのままテキスト出力
            //string text = string.Join(",", Items);

            foreach (var item in Books.items) {
                tbSearch.Text = ($"{item.volumeInfo.title} {string.Join(",", item.volumeInfo.authors)} {item.volumeInfo.publisher}");
            }
        }
    }
}