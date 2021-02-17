using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace tsSearch
{
    public class BooksData {
         public BooksData() {
        var datas = new ObservableCollection<Data>(); ;
        datas.Add(new Data 
        {
            Title = "秘密",
            Author = "東野圭吾",
            Publisher = "Bungeishunju/Tsai Fong Books",
            Isbn = "9784163179209",
        });
        datas.Add(new Data 
        {
            Title = "容疑者Xの献身",
            Author = "東野圭吾",
            Publisher = "Bungeishunju/Tsai Fong Books",
            Isbn = "9784167110123",
        });
        datas.Add(new Data 
        {
            Title = "か「」く「」し「」ご「」と「",
            Author = "住野よる",
            Publisher = "新潮社",
            Isbn = "PKEY:BT000046198300100101900209",
        });
    }
    public ObservableCollection<Data> datas { get; set; }
    }
}