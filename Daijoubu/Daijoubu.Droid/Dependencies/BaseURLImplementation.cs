using Daijoubu.Dependencies;
using Daijoubu.Droid.Dependencies;
using System;
using System.IO;
using Xamarin.Forms;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(BaseURLImplementation))]
namespace Daijoubu.Droid.Dependencies
{

    public class BaseURLImplementation : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}