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
         

        //タイトル・作者・出版社の取得
        // var volumeInfo = api.GetVolumeInfo();

        // var q = volumeInfo.Select(r => new { r.authors, r.publisher, r.title });
        // tbSearch.Items.Add(q);
        if(item.volumeInfo.publisher == null){{item.volumeInfo.publisher
    }
}else{Console.Write("出版社不明");
*/
        ////                foreach (var item in Books.items) {
        ////                //タイトル
        ////                tbSearch.Text += ($"{item.volumeInfo.title} ");
        ////                //作者
        ////                if (item.volumeInfo.authors != null) {
        ////                    tbSearch.Text += ($"{string.Join(",", item.volumeInfo.authors)} ");
        ////                } else {
        ////                    Console.Write("作者無し");
        ////                }
        ////                //出版社
        ////                tbSearch.Text += ($"{item.volumeInfo.publisher}") +"\n";
        ////            }
        ///

        /*
         *       //著者が空ではない場合実行
                    if (item.volumeInfo.authors != null) {
                        //リストの著者をauに入れている
                        foreach (string au in item.volumeInfo.authors) {
                            //numberが０のときに実行
                            if (checknumber == 0) {
                                //著者のみが入力されている場合実行
                                if (MainWindow.sctitle == "" && MainWindow.scauthor != "" && MainWindow.scpublisher == "") {
                                    //著者が一致したものを取得                             
                                    if (MainWindow.scauthor == au) {
                                        Url.Add(item.volumeInfo.infoLink);
                                        datas.Add(new Data() {
                                            Title = item.volumeInfo.title,
                                            Author = string.Join(",", item.volumeInfo.authors),
                                            Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                            Isbn = i.identifier,
                                        });
                                    }
                                }
                                checknumber = 1;
                            } else {
                                Url.Add(item.volumeInfo.infoLink);
                                datas.Add(new Data() {
                                    Title = item.volumeInfo.title,
                                    Author = string.Join(",", item.volumeInfo.authors),
                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                    Isbn = i.identifier
                                });
                            }

                                if (checknumber == 0) {
                                //タイトルのみが入力されてる場合
                                if (MainWindow.sctitle != "" && MainWindow.scauthor == "" && MainWindow.scpublisher == "") {
                                    //タイトルが含まれている書籍を取得  
                                    if (item.volumeInfo.title.Contains(MainWindow.sctitle)) {
                                        Url.Add(item.volumeInfo.infoLink);
                                        datas.Add(new Data() {
                                            Title = item.volumeInfo.title,
                                            Author = string.Join(",", item.volumeInfo.authors),
                                            Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                            Isbn = i.identifier,
                                        });
                                    }
                                } else {
                                    Url.Add(item.volumeInfo.infoLink);
                                    datas.Add(new Data() {
                                        Title = item.volumeInfo.title,
                                        Author = string.Join(",", item.volumeInfo.authors),
                                        Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                        Isbn = i.identifier
                                    });
                                }
                                checknumber = 1;
                            }

                            if (checknumber == 0) {
                                //出版社のみが入力されてる場合
                                if (MainWindow.sctitle == "" && MainWindow.scauthor == "" && MainWindow.scpublisher != "") {
                                    Url.Add(item.volumeInfo.infoLink);
                                    datas.Add(new Data() {
                                        Title = item.volumeInfo.title,
                                        Author = string.Join(",", item.volumeInfo.authors),
                                        Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                        Isbn = i.identifier,
                                    });
                                } else {
                                    Url.Add(item.volumeInfo.infoLink);
                                    datas.Add(new Data() {
                                        Title = item.volumeInfo.title,
                                        Author = string.Join(",", item.volumeInfo.authors),
                                        Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                        Isbn = i.identifier,
                                    });
                                }
                                checknumber = 1;
                            }

                        }
                        checknumber = 0;
                    }
                   
        */
        /*
                                         //タイトル&著者
                                case "110":
                                    if (item.volumeInfo.authors != null) {
                                        foreach (string au in item.volumeInfo.authors) {
                                            if (item.volumeInfo.title.Contains(MainWindow.sctitle) && MainWindow.scauthor == au) {
                                                Url.Add(item.volumeInfo.infoLink);
                                                datas.Add(new Data()
                                                {
                                                    Title = item.volumeInfo.title,
                                                    Author = string.Join(",", item.volumeInfo.authors),
                                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                    Isbn = i.identifier,
                                                });
                                            }
                                        }
                                    }
                                    break;
                                //タイトル&出版社   
                                case "101":
                                    if (item.volumeInfo.title.Contains(MainWindow.sctitle) && MainWindow.scpublisher == item.volumeInfo.publisher) {
                                        Url.Add(item.volumeInfo.infoLink);
                                        datas.Add(new Data()
                                        {
                                            Title = item.volumeInfo.title,
                                            Author = string.Join(",", item.volumeInfo.authors),
                                            Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                            Isbn = i.identifier,
                                        });
                                    }

                                    break;
                                //著者&出版社
                                case "011":
                                    if (item.volumeInfo.authors != null) {
                                        foreach (string au in item.volumeInfo.authors) {
                                            if (MainWindow.scauthor == au && MainWindow.scpublisher == item.volumeInfo.publisher) {
                                                Url.Add(item.volumeInfo.infoLink);
                                                datas.Add(new Data()
                                                {
                                                    Title = item.volumeInfo.title,
                                                    Author = string.Join(",", item.volumeInfo.authors),
                                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                    Isbn = i.identifier,
                                                });
                                            }
                                        }
                                    }
                                    break;
                                //すべて
                                case "111":
                                    if (item.volumeInfo.authors != null) {
                                        foreach (string au in item.volumeInfo.authors) {
                                            if (item.volumeInfo.title.Contains(MainWindow.sctitle) && MainWindow.scauthor == au && MainWindow.scpublisher == item.volumeInfo.publisher) {
                                                Url.Add(item.volumeInfo.infoLink);
                                                datas.Add(new Data()
                                                {
                                                    Title = item.volumeInfo.title,
                                                    Author = string.Join(",", item.volumeInfo.authors),
                                                    Publisher = item.volumeInfo.publisher ?? "出版社不明",
                                                    Isbn = i.identifier,
                                                });
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    } 
         
         */
    }
}
