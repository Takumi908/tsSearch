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
        public ObservableCollection<data> Data { get; }

           //コンストラクタ(データ入力)
        public DataList() {
            var consumerKey = "AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY";
            // var consumerKey = "";
            var api = new GoogleBooksAPI(consumerKey);
            var Books = api.GetBooks();
            int checknumber = 0;
            
                foreach (var item in Books.items) {
                  foreach (string i in item.volumeInfo.authors) {                   
                    Data = new ObservableCollection<data> {
                    new data { Title =item.volumeInfo.title ,Author = i, Publisher = item.volumeInfo.publisher  },
                    };
                  }
                }
            }
        }
    }
}
