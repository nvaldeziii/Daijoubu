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
    public partial class AssesmentPageN4 : ContentPage
    {
        CardAssesment JLPTN4VocabularyAssesment;
        CardAssesment JLPTN4GrammarAssesment;

        public AssesmentPageN4()
        {
            InitializeComponent();

            JLPTN4VocabularyAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserVocabCardsN4.ToList<AbstractCardTable>());
            JLPTN4GrammarAssesment = Computer.totalcardproficiency(UserDatabase.Table_UserGrammCardsN4.ToList<AbstractCardTable>());

            Bind();
        }



        void Bind()
        {
            vocabulary_learn_percent.Text = string.Format("Total Score: {0:0.00}%", JLPTN4VocabularyAssesment.TotalProficiency);
            vocabulary_total_passed.Text = string.Format("Passed Items: {0}", JLPTN4VocabularyAssesment.TotalPassed);
            vocabulary_total_failed.Text = string.Format("Failed Items: {0}", JLPTN4VocabularyAssesment.TotalFailed);
            vocabulary_total_reviewed.Text = string.Format("Total reviewed: {0} of {1}", JLPTN4VocabularyAssesment.TotalReviewed, JLPTN4VocabularyAssesment.TotalItems);

            grammar_learn_percent.Text = string.Format("Total Score: {0:0.00}%", JLPTN4GrammarAssesment.TotalProficiency);
            grammar_total_passed.Text = string.Format("Passed Items: {0}", JLPTN4GrammarAssesment.TotalPassed);
            grammar_total_failed.Text = string.Format("Failed Items: {0}", JLPTN4GrammarAssesment.TotalFailed);
            grammar_total_reviewed.Text = string.Format("Total reviewed: {0} of {1}", JLPTN4GrammarAssesment.TotalReviewed, JLPTN4GrammarAssesment.TotalItems);

            double jlptn4percent = (JLPTN4VocabularyAssesment.TotalProficiency + JLPTN4GrammarAssesment.TotalProficiency) / 2.0;
            jlptn4_learn_percent.Text = string.Format("JLPT N5 preparedness: {0:0.00}%", jlptn4percent);

            if (jlptn4percent > 70)
            {

                DisplayAlert("Alert", "You are now ready to take JLPT N4", "OK");
            }
        }
    }
}
