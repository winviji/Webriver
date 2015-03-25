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

    public class Research
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

        public Research(String param1, String param2, String param3, String param4, String param5, String param6, String param7, String param8)
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
            testCapabilities.SetCapability("appPackage", "com.android.settings");
            testCapabilities.SetCapability("appActivity", ".Settings");
            System.Console.Write(Environment.CurrentDirectory);
            driver = new AppiumDriver(testServerAddress, testCapabilities, INIT_TIMEOUT_SEC);
           // driver = new AppiumDriver(testServerAddress, testCapabilities);
           // driver =
                

        }

        [Test]
        public void test()
        {
           // driver.LaunchApp();
            var context = driver.GetContext();

            
            Assert.IsNotNull(context);
            System.Threading.Thread.Sleep(5000);
            //System.Collections.Generic.List<string> con = driver.GetContexts();
            //for (int i = 0; i < con.Count;i++ )
            //{
            //    System.Console.WriteLine("Context : " + con[i]);
            //    if (con[i].Contains("WEBVIEW"))
            //    {
            //        driver.SetContext(con[i]);
            //        System.Console.Write("Webview found");
            //    }
            //}
            
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> we =driver.FindElementsByXPath(".//android.widget.TextView");
            TouchAction act = new TouchAction(driver);
            Boolean found = false;
            foreach(AppiumWebElement element in we)
            {
                //System.Console.WriteLine("Element found"+element.Text);
                if (element.Text.Equals("Date & time"))
                {
                    //  System.Drawing.Point a = element.Location.  
                    element.Click();
                    found = true;
                    break;
                }
            }
            if(found == false)
            {
                    //Scroll down
                    act.Press(x:50, y:1160).Wait(1000).MoveTo(50,140).Release().Perform();
                   
                    System.Threading.Thread.Sleep(3000);
                    we = driver.FindElementsByXPath(".//android.widget.TextView");
                    System.Threading.Thread.Sleep(5000);
                    
                
            }
            we = driver.FindElementsByXPath(".//android.widget.TextView");
            foreach (AppiumWebElement element in we)
            {
               // System.Console.WriteLine("Element found" + element.Text);
                if (element.Text.Equals("Date & time"))
                {
                    //  System.Drawing.Point a = element.Location.  
                    element.Click();
                    break;
                }
            }


            System.Threading.Thread.Sleep(5000);

            //Uncheck the Automatic date and time checkboxes

            we = driver.FindElementsByXPath(".//android.widget.CheckBox");
            String enabled = we[0].GetAttribute("checked");
            System.Console.WriteLine(enabled);
            if(enabled.Equals(false))
            {
                we[0].Click();

            }
            enabled = we[1].GetAttribute("checked");
            System.Console.WriteLine(enabled);
            if (enabled.Equals(false))
            {
                we[1].Click();

            }

            //Set time

            we = driver.FindElementsByXPath(".//android.widget.TextView");
            foreach(IWebElement element in we)
            {
                if(element.Text.Equals("Set time"))
                {
                    element.Click();
                    break;
                }
            }
            we = driver.FindElementsByXPath(".//android.widget.NumberPicker");
            we[0].SendKeys("2");
            we[1].SendKeys("20");

            driver.FindElementById("android:id/button1").Click();


            //   System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> we = driver.FindElementsByClassName("android.widget.TextView");
        }


        [TearDown]
        public void quit()
        {
            driver.Quit();
        }
    }
}
