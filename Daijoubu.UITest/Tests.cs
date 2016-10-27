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
        public void MultipleChoice_hiragana_UITest()
        {
            //arrange
            //app.DragCoordinates(10, 800, 650, 800);
            app.TapCoordinates(50, 115);
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            app.Tap("auto_btn_hiragana_quiz");
            //act
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                string ans = app.Query("auto_lbl_debug_ans").First().Text.ToLower();
                //app.Flash("auto_lbl_debug_ans");
                bool IsCorrect = random.Next(0, 100) < ai_setting.Intellegence ? true : false;
                Console.WriteLine("Correctness: " + IsCorrect);
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
                        app.Flash("auto_lbl_debug_ans");
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
                app.Flash("auto_lbl_debug_ans");
            }

            var QuestionLabelText = app.Query().First().Text;
            var ShouldNotbe = "??";
            Assert.AreNotSame(ShouldNotbe, QuestionLabelText);

        }
        [Test]
        public void MultipleChoice_katakana_UITest()
        {
            //arrange
            //app.DragCoordinates(10, 800, 650, 800);
            app.TapCoordinates(50, 115);
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            app.Tap("auto_btn_katakana_quiz");
            //act
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                string ans = app.Query("auto_lbl_debug_ans").First().Text.ToLower();
                //app.Flash("auto_lbl_debug_ans");
                bool IsCorrect = random.Next(0, 100) < ai_setting.Intellegence ? true : false;
                Console.WriteLine("Correctness: " + IsCorrect);
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
                        app.Flash("auto_lbl_debug_ans");
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
                app.Flash("auto_lbl_debug_ans");

            }

            var QuestionLabelText = app.Query().First().Text;
            var ShouldNotbe = "??";
            Assert.AreNotSame(ShouldNotbe, QuestionLabelText);
        }
    }
}

