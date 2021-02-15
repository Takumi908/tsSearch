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
            // EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=search+title+{MainWindow.sctitle}=author+{MainWindow.scauthor}=isbn+{MainWindow.scpublisher}&country=JP&langRestrict=ja&maxResults=40&key");
            EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=search&key");

             //タイトルのみ
            if (MainWindow.sctitle != "" && MainWindow.scauthor == "") {
                EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=intitle:{MainWindow.sctitle}&country=JP&maxResults=40&key");
            }//著者のみ
            else if (MainWindow.scauthor != "" && MainWindow.sctitle == "") {
                EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=inauthor:{MainWindow.scauthor}&filter=paid-ebooks&printType=books&maxResults=40&key");
            }//タイトルと著者
            else if (MainWindow.sctitle != "" && MainWindow.scauthor != "") {
                EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=intitle:{MainWindow.sctitle}+inauthor:{MainWindow.scauthor}&maxResults=40&country=JP&key");
            }//ISBN
            if (MainWindow.sctitle == "" && MainWindow.scauthor == "" && MainWindow.scpublisher != "") {
                EndPointUrl = ($"https://www.googleapis.com/books/v1/volumes?q=isbn+{MainWindow.scpublisher}&country=JP&key");
            }
        }

        public Root GetBooks() {
            
              var parm = new Dictionary<string, string>();
          //    parm["rdf:type"] = "books";
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