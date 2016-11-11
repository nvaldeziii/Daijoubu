using Daijoubu.AppControls;
using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class AssesmentPage : ContentPage
    {
        CardAssesment JLPTN5KanaAssesment;
        CardAssesment JLPTN5KatakanaAssesment;
        CardAssesment JLPTN5VocabularyAssesment;

        ObservableCollection<CardAssessmentComparission> Assessments;

        public AssesmentPage()
        {
            InitializeComponent();
            Assessments = new ObservableCollection<CardAssessmentComparission>();

            JLPTN5KanaAssesment       = Computer.totalcardproficiency(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5KatakanaAssesment   = Computer.totalcardproficiency(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());

            Assessments.Add(new CardAssessmentComparission(JLPTN5KanaAssesment, "JLPTN5KanaAssesment") {
                Name = "Hiragana"
            });
            Assessments.Add(new CardAssessmentComparission(JLPTN5KatakanaAssesment, "JLPTN5KatakanaAssesment"){
                Name = "Katakana"
            });
            Assessments.Add(new CardAssessmentComparission(JLPTN5VocabularyAssesment, "JLPTN5VocabularyAssesment")
            {
                Name = "Vocabulary"
            });

            listview_assesments.HasUnevenRows = true;
            listview_assesments.ItemsSource = Assessments;

            Bind();
        }

        void Bind()
        {

            double jlptn5percent = (JLPTN5KanaAssesment.TotalProficiency + JLPTN5KatakanaAssesment.TotalProficiency + JLPTN5VocabularyAssesment.TotalProficiency) / 3.0;
            if (jlptn5percent != ThisApp.TotalJLPTN5)
            {
                //jlptn5_learn_percent.Text = string.Format("JLPT N5 preparedness: From {0:0.00}% to {1:0.00}%", ThisApp.TotalJLPTN5, jlptn5percent);
            }else
            {
                //jlptn5_learn_percent.Text = string.Format("JLPT N5 preparedness: {0:0.00}%", jlptn5percent);
            }

            //save value
            //ThisApp.TotalJLPTN5 = jlptn5percent;

            if (jlptn5percent > 70)
            {
                UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "EnableN4")] 
                    = new tbl_user_settings { info= "EnableN4", name= "EnableN4" };
                DatabaseManipulator.UpdateUserConfig("EnableN4", "True");

                DisplayAlert("Alert", "JLPT N4 quizzes are now enabled", "OK");
            }
        }
    }
}
