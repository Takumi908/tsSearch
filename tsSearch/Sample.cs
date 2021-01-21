using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;


namespace tsSearch
{
    class Sample
    {
        /*
        Import sys;
        Import requests;
        Import jso;

        
           public void Search() {
               string url = "https://www.googleapis.com/books/v1/volumes?q=search";
               WebRequest request = WebRequest.Create(url);
               Stream response_stream = request.GetResponse().GetResponseStream();
               StreamReader reader = new StreamReader(response_stream);
               var obj_from_json = JObject.Parse(reader.ReadToEnd());
               var recast_Title = from foo in obj_from_json["response"]["title"] where ((String)foo["name"]).Contains("町") select foo;

               foreach (var item in recast_Title) {
                   Console.WriteLine(item["name"]);
               }
               Console.ReadLine();

               static async System.Threading.Tasks.Task Main(string[] args) {

           var json = Console.ReadLine();

           var answer = new Answer();

               using (var client = new HttpClient()) {
                   var content = new StringContent(json, Encoding.UTF8, "aplication/json");

                   var httpResponse = await client.PostAsync("https://www.googleapis.com/books/v1/volumes?q=search+", content);
                   //AIzaSyBj1ahxU2BSwc0b7W_PEeQo_L7jszxuIPY APIキー
         */

        //タイトル・作者・出版社の取得
        // var volumeInfo = api.GetVolumeInfo();

        // var q = volumeInfo.Select(r => new { r.authors, r.publisher, r.title });
        // tbSearch.Items.Add(q);
        if(item.volumeInfo.publisher == null){{item.volumeInfo.publisher
    }
}else{Console.Write("出版社不明");
    }
}