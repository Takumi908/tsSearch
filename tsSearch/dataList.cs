using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsSearch
{
    class DataList
    {
      //  public ObservableCollection<Data> Data { get; set; }

        //コンストラクタ(データ入力)
        public void List() {
            var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            int checknumber = 0;

            foreach (var item in Books.items) {
                if (item.volumeInfo.authors != null) {
                    foreach (string i in item.volumeInfo.authors) {

                        DataWindow dataWindow = new DataWindow();
                        if (MainWindow.scauthor == i) {
                            Data data = new Data();
                            data.Title = item.volumeInfo.title;
                            data.Author = i;
                            data.Publisher = item.volumeInfo.publisher;
                            data.Isbn = null;
                            data.BookUrl = null;
                        }
                        // dataWindow.listView.Items.Add(data);
                    }
                }
            }
        }
    }
}
