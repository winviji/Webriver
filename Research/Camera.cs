using System;
using System.Drawing;

using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using OpenQA.Selenium.Appium;
using System;

using NUnit.Framework;

using System.Net;


using System.Net;
namespace Research
{
    [TestFixture("Android", "Android Emulator", "4.3", "0150000", "999999", "Steven Manager", "Steven's Team2", "testemailid@testemail.com")]

    public class Camera
    {
        private AppiumDriver driver;

        private static Uri testServerAddress = new Uri("http://127.0.0.1:4723/wd/hub");//This is the local ip pointing to appium server
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(120);
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);

        DesiredCapabilities testCapabilities;
        //Environment details:

        private String platform;
        private String devicename;
        private String version;

        public Camera(String param1, String param2, String param3, String param4, String param5, String param6, String param7, String param8)
        {
            this.platform = param1;
            this.devicename = param2;
            this.version = param3;
        }
        [SetUp]
        public void Start()
        {
            testCapabilities = new DesiredCapabilities();
            testCapabilities.SetCapability(CapabilityType.BrowserName, "");
            testCapabilities.SetCapability("platformName", platform);
            testCapabilities.SetCapability("deviceName", "selendroid");
            //   testCapabilities.SetCapability("automationName", "selendroid");

            testCapabilities.SetCapability(CapabilityType.Version, version);
            testCapabilities.SetCapability("appPackage", "com.android.camera");
            testCapabilities.SetCapability("appActivity", ".Camera");
            System.Console.Write(Environment.CurrentDirectory);
            driver = new AppiumDriver(testServerAddress, testCapabilities, INIT_TIMEOUT_SEC);
            // driver = new AppiumDriver(testServerAddress, testCapabilities);
            // driver =


        }

         [Test]
        public void test()
        {
            var context = driver.GetContext();
            Assert.IsNotNull(context);


        }
    }
}
