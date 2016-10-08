using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.Padding = -50;
            var database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<tbl_kana>();

            database.Execute("insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,\"ju\",\"ぢゅ\",\"ヂュ\");");
            if (database.Table<tbl_kana>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var new_row = new tbl_kana();
                new_row.Id =1;
                new_row.katakana="2";
                new_row.hiragana="3";
                new_row.romaji="4";
                database.Insert(new_row);
            }


            //var map = database.GetMapping<tbl_kana>();
           // var table = database.Query<tbl_kana>("select * from tbl_kana", null);
            var table = database.Table<tbl_kana>();
            List<tbl_kana> KanaTable = new List<tbl_kana>();
            foreach (var item in table)
            {
               
                var row = new tbl_kana();
                row.Id = item.Id;
                row.hiragana = item.hiragana;
                row.katakana = item.katakana;
                row.romaji = item.romaji;

                KanaTable.Add(row);
            }

            

        }
    }
}
