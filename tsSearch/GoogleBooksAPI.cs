using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static tsSearch.Books;

namespace tsSearch
{

    class GoogleBooksAPI
    {
        public string ConsumerKey { get; private set; }

        public static string EndPointUrl { get; set; }
        
        public string Json { get; private set; }

        public GoogleBooksAPI(string consumerKey) {
            ConsumerKey = consumerKey;
            EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=search+author={MainWindow.scauthor}+title={MainWindow.sctitle}+publisher={MainWindow.scpublisher}&country=JP&langRestrict=ja&maxResults=40&key");
            //EndPointUrl = "https://www.googleapis.com/books/v1/volumes?q=time&printType=books&country=JP&langRestrict=ja&maxResults=40&key";
            //現在の検索条件:40件の結果を返す(10～40で変更可能)
             
        }

        public Root GetBooks() {
            
              var parm = new Dictionary<string, string>();
              parm["rdf:type"] = "books";
              parm["acl : consumerKey"] = ConsumerKey;
             
            var url = string.Format("{0}?{1}", EndPointUrl,
                string.Join("&", parm.Select(p => string.Format("{0}={1}", p.Key, p.Value))));
           
            // JSON-DLを取得する
            var client = new WebClient() {
                Encoding = System.Text.Encoding.UTF8
            };
            Json = client.DownloadString(url);
            return JsonConvert.DeserializeObject<Root>(Json);
        }
    }
}