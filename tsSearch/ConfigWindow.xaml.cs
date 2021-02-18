using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tsSearch
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow() {
            InitializeComponent();
        }
        //閉じる
        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        //メイン画面のヘルプボタン押したときに実行される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            tbHelpTitle.Text = ($"*検索システムの使い方*");
            tbhelp.Text += ($"タイトル:検索したタイトルが含まれている書籍を検索する\n著者:検索した著者と一致する書籍を検索する\nISBN:検索した13桁のコードと一致する書籍を検索する"); 
            tbHelpTitle2.Text += ($"*本が見つからない場合*");
            tbhelp2.Text +=($"著者の漢字やタイトルが間違っていると、\n正確に書籍を取得出来ないことがあるので注意" );
        }
    }
}
