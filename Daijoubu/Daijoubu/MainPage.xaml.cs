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
            database.CreateTable<tbl_vocabulary_N5>();
            JapaneseDatabase.Table_Vocabulary_N5 = database.Table<tbl_vocabulary_N5>().ToList();
            JapaneseDatabase.Table_Kana = database.Table<tbl_kana>().ToList();

        }
    }
}
