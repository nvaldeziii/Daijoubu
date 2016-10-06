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
            var table = database.Table<Table_Kana>();
            List<Table_Kana> KanaTable = new List<Table_Kana>();
            foreach (var item in table)
            {
                var row = new Table_Kana();
                row.Id = item.Id;
                row.hiragana = item.hiragana;
                row.katakana = item.katakana;
                row.romaji = item.romaji;

                KanaTable.Add(row);
            }
            

        }
    }
}
