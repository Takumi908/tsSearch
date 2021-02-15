using Newtonsoft.Json;
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

namespace tsSearch
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class DataWindow {
        public DataWindow() {
            InitializeComponent();
        }

        List<string> Url = new List<string>();


        private void edButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // listView.AltenatingRowBackground = System.Windows.Media.Brushes.PaleTurquoise;

            //var consumerKey = "";
            var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            var datas = new ObservableCollection<Data>();

            if (Books.items != null) {
                foreach (var item in Books.items) {
                    //if (item.volumeInfo.industryIdentifiers != null) {
                    //  foreach (var i in item.volumeInfo.industryIdentifiers.FindAll(f => f.identifier.Length == 13)) {
                    if (item.volumeInfo.authors != null) {
                        Url.Add(item.volumeInfo.infoLink);
                        datas.Add(new Data() {
                            Title = item.volumeInfo.title,
                            Author = string.Join(",", item.volumeInfo.authors),
                            Publisher = item.volumeInfo.publisher ?? "出版社不明",
                            Isbn = item.volumeInfo.identifier ?? "コード不明",
                        });
                        listView.ItemsSource = datas;
                    }
                    //}
                    //}
                }
            }
            if (listView.Items.Count == 0) {
                MessageBox.Show("該当する書籍が見つかりませんでした");
                this.Close();
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
        public void ListViewSortingSample() {
            InitializeComponent();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            }
    }

}