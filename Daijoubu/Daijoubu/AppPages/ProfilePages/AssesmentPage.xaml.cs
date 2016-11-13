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
        bool n5;
        //
        CardAssesment JLPTN5KanaAssesment;
        CardAssesment JLPTN5KatakanaAssesment;
        CardAssesment JLPTN5VocabularyAssesment;
        //
        CardAssesment JLPTN4VocabularyAssesment;
        CardAssesment JLPTN4GrammarAssesment;

        ObservableCollection<CardAssessmentComparission> Assessments;

        public AssesmentPage(CardAssesment CA, string CA_string,string CA_title,string title, bool n5 = true)
        {
            this.n5 = n5;
            InitializeComponent();
            Assessments = new ObservableCollection<CardAssessmentComparission>();

            listview_title.Text = title;

            JLPTN5KanaAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5KatakanaAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());

            Assessments.Add(new CardAssessmentComparission(CA, CA_string)
            {
                Name = CA_title
            });

            listview_assesments.HasUnevenRows = true;
            listview_assesments.ItemsSource = Assessments;

            Bind();
        }

        public AssesmentPage(bool n5 = true)
        {
            this.n5 = n5;
            InitializeComponent();
            Assessments = new ObservableCollection<CardAssessmentComparission>();
            if (n5)
            {
                listview_title.Text = "JLPT N5 Assessment";


                JLPTN5KanaAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>());
                JLPTN5KatakanaAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>());
                JLPTN5VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());

                Assessments.Add(new CardAssessmentComparission(JLPTN5KanaAssesment, "JLPTN5KanaAssesment")
                {
                    Name = "Hiragana"
                });
                Assessments.Add(new CardAssessmentComparission(JLPTN5KatakanaAssesment, "JLPTN5KatakanaAssesment")
                {
                    Name = "Katakana"
                });
                Assessments.Add(new CardAssessmentComparission(JLPTN5VocabularyAssesment, "JLPTN5VocabularyAssesment")
                {
                    Name = "Vocabulary"
                });

                

                Bind();
            }else
            {
                listview_title.Text = "JLPT N4 Assessment";
                //n4
                JLPTN4VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN4.ToList<AbstractCardTable>());
                JLPTN4GrammarAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserGrammCardsN4.ToList<AbstractCardTable>());
                Assessments.Add(new CardAssessmentComparission(JLPTN4VocabularyAssesment, "JLPTN4VocabularyAssesment")
                {
                    Name = "Vocabulary"
                });
                Assessments.Add(new CardAssessmentComparission(JLPTN4GrammarAssesment, "JLPTN4GrammarAssesment")
                {
                    Name = "Grammar"
                });
            }

            listview_assesments.HasUnevenRows = true;
            listview_assesments.ItemsSource = Assessments;
        }

        void Bind()
        {
            double percent;
            if (n5)
            {
                percent = (JLPTN5KanaAssesment.TotalProficiency + JLPTN5KatakanaAssesment.TotalProficiency + JLPTN5VocabularyAssesment.TotalProficiency) / 3.0;
            }else
            {
                percent = (JLPTN4VocabularyAssesment.TotalProficiency + JLPTN4GrammarAssesment.TotalProficiency) / 2.0;
            }

            if (n5 ? percent > ThisApp.TotalJLPTN5 : percent > ThisApp.TotalJLPTN4)
            {
                listview_title_New.TextColor = Color.Green;
            }
            else if (n5 ? percent == ThisApp.TotalJLPTN5 : percent == ThisApp.TotalJLPTN4)
            {
                listview_title_New.TextColor = Color.Gray;
            }
            else
            {
                listview_title_New.TextColor = Color.Red;
            }
            listview_title_New.Text = string.Format("{0:0.00}%", percent);
            listview_title_Old.Text = string.Format("{0:0.00}%", n5? ThisApp.TotalJLPTN5 : ThisApp.TotalJLPTN4);
            //save value
            //ThisApp.TotalJLPTN5 = jlptn5percent;

            if (percent > 70 && n5)
            {
                UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "EnableN4")] 
                    = new tbl_user_settings { info= "EnableN4", name= "EnableN4" };
                DatabaseManipulator.UpdateUserConfig("EnableN4", "True");

                DisplayAlert("Alert", "JLPT N4 quizzes are now enabled", "OK");
            }
        }
    }
}
