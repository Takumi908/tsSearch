using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tsSearch
{

    class GoogleBooksAPI
    {
        public string ConsumerKey { get; private set; }

        public string EndPointUrl { get; private set; }

        public string Json { get; private set; }

        public GoogleBooksAPI(string consumerKey) {
            ConsumerKey = consumerKey;
            EndPointUrl = "https://www.googleapis.com/books/v1/volumes?q=search";

        }

        public IEnumerable<Books> GetBooks() {

            var parm = new Dictionary<string, string>();
            parm["rdf:type"] = "odpt : TrainInformation";
            parm["acl : consumerKey"] = ConsumerKey;

            var url = string.Format("{0}?{1}", EndPointUrl,
                string.Join("&", parm.Select(p => string.Format("{0}={1}", p.Key, p.Value))));

            // JSON-DLを取得する
            var client = new WebClient() {
                Encoding = System.Text.Encoding.UTF8
            };
            Json = client.DownloadString(url);

            return JsonConvert.DeserializeObject<Books[]>(Json);
        }
    }
}