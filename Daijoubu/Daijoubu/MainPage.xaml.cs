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
            JapaneseDatabase.Table_Kana = database.Table<tbl_kana>().ToList();

        }
    }
}
