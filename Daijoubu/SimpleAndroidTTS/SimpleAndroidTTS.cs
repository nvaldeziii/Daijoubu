/*
 * most of the definition in this class came from monodroid-samples
 * located in github.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Runtime;

using Java.Lang;

//required for activity class
using Android.App;

//Text to speech essentials
using Android.Speech.Tts;
using Android.Content;
using Java.Util;

//library for array adapter
using Android.Widget;

namespace SimpleTTS
{
    public struct SettingSimpleTTS
    {
        TextToSpeech TTS;
        float rate, pitch;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">set all settings to true or false</param>
        public SettingSimpleTTS(ref TextToSpeech tts)
        {
            TTS = tts;
            //this disables checking if a language is installed
            BypasslanguageCheck = false;

            rate = pitch = 1;
            Pitch = 1;
            Rate = 1;
        }

        public bool BypasslanguageCheck;

        // set the speed and pitch
        // note: 1 sounds normal
        public float Pitch {
            set
            {
                pitch = value;
                TTS.SetPitch(pitch);
            }
            get
            {
                return pitch;
            }
        }
        public float Rate
        {
            set
            {
                rate = value;
                TTS.SetSpeechRate(rate);
            }
            get
            {
                return rate;
            }
        }
    }

    public class SimpleAndroidTTS : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        //initializations
        private TextToSpeech textToSpeech;
        Context context;
#pragma warning disable CS0414
        private readonly int MyCheckCode = 101, NeedLang = 103;
#pragma warning restore CS0414
        private Locale lang;

        private List<string> AvailableLanguage;

        private Activity Caller;//we'll usually set this as the one that calls this class;

        public SettingSimpleTTS Settings;

        public SimpleAndroidTTS(Activity a)
        {
            //we'll set the context as the activity that calls this class
            Caller = a;
            SetContext(Caller);

            // set up the TextToSpeech object
            // third parameter is the speech engine to use
            textToSpeech = new TextToSpeech(context, this, "com.google.android.tts");

            //init tts settings
            Settings = new SettingSimpleTTS(ref textToSpeech);

            //make sure to get the languages first
            AvailableLanguage = GetLanguages();

           
            // set up the speech to use the default langauge
            // if a language is not available, then the default language is used.
            lang = Java.Util.Locale.Default;
            textToSpeech.SetLanguage(lang);
       
        }

        public void Speak(string text)
        {
            // if there is nothing to say, don't say it
            if (!string.IsNullOrEmpty(text))
            {
#pragma warning disable CS0618 // Type or member is obsolete
                textToSpeech.Speak(text, QueueMode.Flush, null);
#pragma warning restore CS0618 // Type or member is obsolete
            }

        }

        public void SpeakDefault(string text)
        {
            // if there is nothing to say, don't say it
            if (!string.IsNullOrEmpty(text))
            {
                textToSpeech.SetLanguage(Locale.Default);
#pragma warning disable CS0618 // Type or member is obsolete
                textToSpeech.Speak(text, QueueMode.Flush, null);
#pragma warning restore CS0618 // Type or member is obsolete
                textToSpeech.SetLanguage(lang);
            }

        }

        /// <summary>
        ///  This is mandatory.
        ///  I am not sure but they usually pass the button as context
        ///  as per example in monodroid-samples
        ///     -get the context - easiest way is to obtain it from an on screen gadget
        ///     - context = btnSayIt.Context;
        /// </summary>
        /// <param name="c"> pass the button/activity that triggers tts? maybe </param>
        public void SetContext(Context c)
        {
            context = c;
        }

        /// <summary>
        /// Uses SimpleSpinnerDropDownItem as resource id
        /// </summary>
        /// <returns> Language list in Array adapter form </returns>
        public ArrayAdapter<string> GetLanguagesAdapter()
        {
            // change Android.Resource.Layout.SimpleSpinnerDropDownItem
            // in the future for a different usecase
            var adapter = new ArrayAdapter<string>(context, Android.Resource.Layout.SimpleSpinnerDropDownItem, AvailableLanguage);

            return adapter;
        }

        /// <summary>
        /// this gets the available language
        /// </summary>
        /// <returns> available language in local device </returns>
        public List<string> GetLanguages()
        {
            var langAvailable = new List<string> { "Default" };

            // our spinner only wants to contain the languages supported by the tts and ignore the rest
            var localesAvailable = Locale.GetAvailableLocales().ToList();
            foreach (var locale in localesAvailable)
            {
                LanguageAvailableResult res = textToSpeech.IsLanguageAvailable(locale);
                switch (res)
                {
                    case LanguageAvailableResult.Available:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryVarAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                }

            }
            langAvailable = langAvailable.OrderBy(t => t).Distinct().ToList();
            return langAvailable;
        }

        /// <summary>
        /// directly set language using locale class
        /// example: locale.Default
        /// </summary>
        /// <param name="l"> pass the locale class with language </param>
        public void SetLanguage(Locale l)
        {
            lang = l;
            textToSpeech.SetLanguage(lang);
            CheckInstalledVoices();
        }

        /// <summary>
        /// pass this in a spinner delegate or other you can think of
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetLanguage(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            lang = Java.Util.Locale.GetAvailableLocales().FirstOrDefault(t => t.DisplayLanguage == AvailableLanguage[(int)e.Id]);
            CheckInstalledVoices();
        }

        /// <summary>
        /// create intent to check the TTS has this language installed
        /// </summary>
        private void CheckInstalledVoices()
        {
            if (Settings.BypasslanguageCheck == false)
            {
                // create intent to check the TTS has this language installed
                var checkTTSIntent = new Intent();
                checkTTSIntent.SetAction(TextToSpeech.Engine.ActionCheckTtsData);
                Caller.StartActivityForResult(checkTTSIntent, NeedLang);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            // if we get an error, default to the default language
            if (status == OperationResult.Error)
                textToSpeech.SetLanguage(Java.Util.Locale.Default);
            // if the listener is ok, set the lang
            if (status == OperationResult.Success)
                textToSpeech.SetLanguage(lang);
        }

        /// <summary>
        /// checks whether tts engine is talking
        /// </summary>
        public bool IsSpeaking
        {
            get
            {
                return textToSpeech.IsSpeaking;
            }
        }

        /*
         * make sure to override OnActivityResult on the calling class
         * 
                private readonly int MyCheckCode = 101, NeedLang = 103;
                protected override void OnActivityResult(int req, Result res, Intent data)
                {
                    if (req == NeedLang)
                    {
                        // we need a new language installed
                        var installTTS = new Intent();
                        installTTS.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
                        StartActivity(installTTS);
                    }
                }
         */
    }


}
