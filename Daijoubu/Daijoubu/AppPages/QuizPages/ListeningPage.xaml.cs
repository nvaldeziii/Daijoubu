using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class ListeningPage : ContentPage
    {
        public ListeningPage()
        {
            InitializeComponent();
            InitializeEvents();
        }

        void InitializeEvents()
        {
            this.img_speaker.GestureRecognizers.Add(new TapGestureRecognizer
             {
                 Command = new Command(() =>
                 {
                     DependencyService.Get<ITextToSpeech>().Speak(this.edittext_tts_input.Text);
                 }),
                 NumberOfTapsRequired = 1
             });

        }
    }
}
