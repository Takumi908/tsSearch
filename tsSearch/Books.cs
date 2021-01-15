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
        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("id")]   //ID
        public string Id { get; set; }

        [JsonProperty("title")]   //タイトル
        public string Title { get; set; }

        [JsonProperty("publicher")]   //出版社
        public string publicher { get; set; }

        [JsonProperty("pageCount")]  //価格
        public int pageCount { get; set; }

        [JsonProperty("amount")]
        public int amount { get; set; }
    }
}
