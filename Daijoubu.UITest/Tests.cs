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

        public Tests(Platform platform)
        {
            this.platform = platform;
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
                bool IsCorrect = random.Next(0, 100) < 90 ? true : false;
                if (IsCorrect)
                {

                    var c1 = app.Query("auto_btn_choice1").First().Text.ToLower();
                    //app.Flash("auto_btn_choice1");
                    var c2 = app.Query("auto_btn_choice2").First().Text.ToLower();
                    //app.Flash("auto_btn_choice2");
                    var c3 = app.Query("auto_btn_choice3").First().Text.ToLower();
                    //app.Flash("auto_btn_choice3");
                    var c4 = app.Query("auto_btn_choice4").First().Text.ToLower();
                    //app.Flash("auto_btn_choice4");

                    Console.WriteLine("answer: " + ans);
                    Console.WriteLine(string.Format("choices: {0}, {1}, {2}, {3}", c1, c2, c3, c4));
                    if (c1.Contains(ans) || ans.Contains(c1))
                    {
                        app.Tap("auto_btn_choice1");
                    }
                    else if (c2.Contains(ans) || ans.Contains(c2))
                    {
                        app.Tap("auto_btn_choice2");
                    }
                    else if (c3.Contains(ans) || ans.Contains(c3))
                    {
                        app.Tap("auto_btn_choice3");
                    }
                    else if (c4.Contains(ans) || ans.Contains(c4))
                    {
                        app.Tap("auto_btn_choice4");
                    }
                    else
                    {
                        app.Flash("auto_lbl_debug_ans");
                        //System.Threading.Thread.Sleep(3);
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
            //app.Flash();
            //act
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                string ans = app.Query("auto_lbl_debug_ans").First().Text.ToLower();
                //app.Flash("auto_lbl_debug_ans");
                bool IsCorrect = random.Next(0, 100) < 90 ? true : false;
                if (IsCorrect)
                {

                    var c1 = app.Query("auto_btn_choice1").First().Text.ToLower();
                    //app.Flash("auto_btn_choice1");
                    var c2 = app.Query("auto_btn_choice2").First().Text.ToLower();
                    //app.Flash("auto_btn_choice2");
                    var c3 = app.Query("auto_btn_choice3").First().Text.ToLower();
                    //app.Flash("auto_btn_choice3");
                    var c4 = app.Query("auto_btn_choice4").First().Text.ToLower();
                    //app.Flash("auto_btn_choice4");

                    Console.WriteLine("answer: " + ans);
                    Console.WriteLine(string.Format("choices: {0}, {1}, {2}, {3}",c1,c2,c3,c4));
                    if (c1.Contains(ans) || ans.Contains(c1))
                    {
                        app.Tap("auto_btn_choice1");
                    }
                    else if (c2.Contains(ans) || ans.Contains(c2))
                    {
                        app.Tap("auto_btn_choice2");
                    }
                    else if (c3.Contains(ans) || ans.Contains(c3))
                    {
                        app.Tap("auto_btn_choice3");
                    }
                    else if (c4.Contains(ans) || ans.Contains(c4))
                    {
                        app.Tap("auto_btn_choice4");
                    }else
                    {
                        app.Flash("auto_lbl_debug_ans");
                        //System.Threading.Thread.Sleep(3);
                        //app.Flash("auto_lbl_debug_ans");
                    }
                    app.Flash("auto_lbl_debug_ans");
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

            }

            var QuestionLabelText = app.Query().First().Text;
            var ShouldNotbe = "??";
            Assert.AreNotSame(ShouldNotbe, QuestionLabelText);

        }
    }
}

