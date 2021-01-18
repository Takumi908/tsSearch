using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsSearch
{
    class Books
    {

        [JsonProperty("intitle:")]   //タイトル
        public string Intitle { get; set; }

        [JsonProperty("inpublicher:")]   //出版社
        public string Inpublicher { get; set; }


        [JsonProperty("inauthor")] //著者
        public string Inauthor { get; set; }

        [JsonProperty("subject")]   //出版社
        public string Subject { get; set; }

        [JsonProperty("isbn")] //isbn
        public string Isbn { get; set; }

        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }

    }
}
