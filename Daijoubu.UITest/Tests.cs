using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Drawing;

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
        public void MultipleChoiceUITest()
        {
            //arrange
            app.DragCoordinates(10, 800, 650, 800);
            //app.TapCoordinates(50, 115);
            app.Tap("auto_SideMenuButton_Quiz");
            app.Tap("auto_btn_multiple");
            //act
            app.Tap("auto_btn_choice1");

        }
    }
}

