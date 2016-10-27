using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GUI_Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
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
            for(int i = 0; i < 100; i++)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        app.Tap("auto_btn_choice1");
                        break;
                    case 2:
                        app.Tap("auto_btn_choice2");
                        break;
                    case 3:
                        app.Tap("auto_btn_choice3");
                        break;
                    case 4:
                        app.Tap("auto_btn_choice4");
                        break;
                    default:
                        throw new Exception();
                }
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
                switch (random.Next(1, 4))
                {
                    case 1:
                        app.Tap("auto_btn_choice1");
                        break;
                    case 2:
                        app.Tap("auto_btn_choice2");
                        break;
                    case 3:
                        app.Tap("auto_btn_choice3");
                        break;
                    case 4:
                        app.Tap("auto_btn_choice4");
                        break;
                    default:
                        throw new Exception();
                }
            }

            var QuestionLabelText = app.Query().First().Text;
            var ShouldNotbe = "??";
            Assert.AreNotSame(ShouldNotbe, QuestionLabelText);

        }
    }
}

