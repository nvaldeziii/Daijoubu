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
        string IBaseUrl.Get()
        {
            return "file:///android_asset/";
        }
    }
}