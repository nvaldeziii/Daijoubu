using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class AssesmentPage : ContentPage
    {
        CardAssesment JLPTN5KanaAssesment       ;
        CardAssesment JLPTN5KatakanaAssesment   ;
        CardAssesment JLPTN5VocabularyAssesment;

        public AssesmentPage()
        {
            InitializeComponent();

            JLPTN5KanaAssesment       = Computer.totalcardproficiency(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5KatakanaAssesment   = Computer.totalcardproficiency(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>());
            JLPTN5VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());

            Bind();
        }

        void Bind()
        {
            hiragana_learn_percent.Text = string.Format("Total Proficiency: {0:0.00}%", JLPTN5KanaAssesment.TotalProficiency);
            hiragana_total_passed.Text = string.Format("Total Passed: {0}", JLPTN5KanaAssesment.TotalPassed);
            hiragana_total_failed.Text = string.Format("Total Failed Items: {0}", JLPTN5KanaAssesment.TotalFailed);
            hiragana_total_reviewed.Text = string.Format("Total reviewed: {0} of {1}", JLPTN5KanaAssesment.TotalReviewed, JLPTN5KanaAssesment.TotalItems);
            

            katakana_learn_percent.Text = string.Format("Total Proficiency: {0:0.00}%", JLPTN5KatakanaAssesment.TotalProficiency);
            katakana_total_passed.Text = string.Format("Total Passed: {0}", JLPTN5KatakanaAssesment.TotalPassed);
            katakana_total_failed.Text = string.Format("Total Failed Items: {0}", JLPTN5KatakanaAssesment.TotalFailed);
            katakana_total_reviewed.Text = string.Format("Total reviewed: {0} of {1}", JLPTN5KatakanaAssesment.TotalReviewed, JLPTN5KatakanaAssesment.TotalItems);
            

            vocabulary_learn_percent.Text = string.Format("Total Proficiency: {0:0.00}%", JLPTN5VocabularyAssesment.TotalProficiency);
            vocabulary_total_passed.Text = string.Format("Total Passed: {0}", JLPTN5VocabularyAssesment.TotalPassed);
            vocabulary_total_failed.Text = string.Format("Total Failed Items: {0}", JLPTN5VocabularyAssesment.TotalFailed);
            vocabulary_total_reviewed.Text = string.Format("Total reviewed: {0} of {1}", JLPTN5VocabularyAssesment.TotalReviewed, JLPTN5VocabularyAssesment.TotalItems);

            double jlptn5percent = (JLPTN5KanaAssesment.TotalProficiency + JLPTN5KatakanaAssesment.TotalProficiency + JLPTN5VocabularyAssesment.TotalProficiency) / 3.0;
            jlptn5_learn_percent.Text = string.Format("JLPT N5 preparedness: {0:0.00}%", jlptn5percent);
        }
    }
}
