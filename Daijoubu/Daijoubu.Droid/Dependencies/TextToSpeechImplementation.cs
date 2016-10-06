using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Speech.Tts;
using Xamarin.Forms;
using Daijoubu.Dependencies;
using Daijoubu.Droid.Dependencies;
using SimpleTTS;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace Daijoubu.Droid.Dependencies
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech/*, TextToSpeech.IOnInitListener*/
    {
        SimpleAndroidTTS TextToSpeechInstance;
        SettingSimpleTTS TextToSpeechSettings;

        public TextToSpeechImplementation()
        {
            
            var context = Forms.Context; // useful for many Android SDK features

            TextToSpeechInstance = new SimpleAndroidTTS((Activity)context);
            TextToSpeechSettings = new SettingSimpleTTS();


            TextToSpeechSettings.BypasslanguageCheck = false;
            TextToSpeechInstance.Settings = TextToSpeechSettings;

            TextToSpeechInstance.SetLanguage(Java.Util.Locale.Japanese);
            //var x = tts.GetLanguagesAdapter();
            //speaker = new TextToSpeech(context, this);
            //speaker.SetLanguage(Java.Util.Locale.Japanese);
        }

        public void Speak(string text)
        {
            TextToSpeechInstance.Speak(text);
        }
    }
}