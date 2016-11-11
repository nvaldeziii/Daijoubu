using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Daijoubu.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        AISettings ai_setting;

        public Tests(Platform platform)
        {
            this.platform = platform;
            ai_setting = new AISettings();
            //ai_setting.ItemsToTake = 108;
            ai_setting.Intellegence = 85;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

       [Test]
       public void DebugTest()
        {
            app.Tap("auto_navigation");
            app.Tap("auto_navigation");
            app.Tap("auto_navigation");
            app.Tap("auto_navigation");
        }

        [Test]
        public void MultipleChoice_hiragana_UITest()
        {
            //arrange
            //app.DragCoordinates(10, 800, 650, 800);
            app.Back();
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            app.Tap("auto_btn_hiragana_quiz");

            //act
            MultipleChoiceTest();

        }
        [Test]
        public void MultipleChoice_katakana_UITest()
        {
            //arrange
            //app.DragCoordinates(10, 800, 650, 800);
            app.Back();
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            app.Tap("auto_btn_katakana_quiz");

            //act
            MultipleChoiceTest();
        }
        [Test]
        public void MultipleChoice_vocabulary_UITest()
        {
            //arrange
            //app.DragCoordinates(10, 800, 650, 800);
            app.Back();
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            app.Tap("auto_btn_vocabulary_quiz");

            //act
            MultipleChoiceTest();
        }


        void MultipleChoiceTest()
        {
            //act
            var random = new Random();
            for (int i = 0; i < ai_setting.ItemsToTake; i++)
            {
                Console.WriteLine(string.Format("========>> Test Count: {0}/{1}", i, ai_setting.ItemsToTake));
                string ans = app.Query("auto_lbl_debug_ans").First().Text.ToLower();
                //app.Flash("auto_lbl_debug_ans");
                var roll = random.Next(0, 100);
                bool IsCorrect = roll < ai_setting.Intellegence ? true : false;

                Console.WriteLine("=============>> Roll: " + roll + "%");
                Console.WriteLine("======>> Correctness: " + IsCorrect);
                
                if (IsCorrect)
                {
                    if (app.Query("auto_btn_choice1").First().Text.ToLower() == ans)
                    {
                        app.Tap("auto_btn_choice1");
                    }
                    else if (app.Query("auto_btn_choice2").First().Text.ToLower() == ans)
                    {
                        app.Tap("auto_btn_choice2");
                    }
                    else if (app.Query("auto_btn_choice3").First().Text.ToLower() == ans)
                    {
                        app.Tap("auto_btn_choice3");
                    }
                    else if (app.Query("auto_btn_choice4").First().Text.ToLower() == ans)
                    {
                        app.Tap("auto_btn_choice4");
                    }
                    else
                    {
                        //app.Flash("auto_lbl_debug_ans");
                    }
                }
                else
                {
                    if (app.Query("auto_btn_choice1").First().Text.ToLower() != ans)
                    {
                        app.Tap("auto_btn_choice1");
                    }
                    else
                    {
                        app.Tap("auto_btn_choice2");
                    }
                }
                System.Threading.Thread.Sleep(ai_setting.Delay);
                //app.Flash("auto_lbl_debug_ans");

            }

            var QuestionLabelText = app.Query().First().Text;
            var ShouldNotbe = "??";
            Assert.AreNotSame(ShouldNotbe, QuestionLabelText);
        }

        [Test]
        public void Stress_UITest()
        { 
            ai_setting.ItemsToTake = 200;
            MultipleChoice_hiragana_UITest();

            //go back to homepage
            app.Back(); app.Back(); app.Back(); app.Back();
            //back at homepage
            MultipleChoice_katakana_UITest();
            app.Back(); app.Back(); app.Back(); app.Back();
            MultipleChoice_vocabulary_UITest();
            app.Back(); app.Back(); app.Back();
        }

        void ManualTapNavigationBack(int count)
        {
            for(int i =0; i < count; i++)
            {
                app.TapCoordinates(ai_setting.DrawerLocationX, ai_setting.DrawerLocationY);
                System.Threading.Thread.Sleep(ai_setting.Delay);
            }
        }
    }
}

