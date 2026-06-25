using NUnit.Framework;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;

namespace PlaywrightBeginner
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync(url: "http://www.eaapp.somee.com");
            /*await Page.GotoAsync(url: "http://www.eaapp.somee.com", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.DOMContentLoaded
            });*/

            //for instance, wait for the network option idle is full achieved, then you specify as per above or
            //waituntil the dom content is loaded WaitUntilState.DOMContentLoaded
        }

        [Test]
        public async Task Test1()
        {
            //Page.SetDefaultTimeout(10); //this will fail because the in-built auto wait is about 3000ms and 10 is way too less
            /*using var playwright = await Playwright.CreateAsync(); 
            //the red line under CreateAsync is because the class has inherited the PageTest microsoft playwright NUnit page test
            //and the playwright test already implemented the create async for us
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var page = await browser.NewPageAsync(); //all these is no longer required*/
            //the red line under page can be resolved using capital letter Page
            await Page.ClickAsync(selector: "text=Login");
          /*  var lnkLogin = Page.Locator(selector: "text=Login");
            await lnkLogin.ClearAsync();*/
            /* await Page.ScreenshotAsync(new PageScreenshotOptions
             {
                 Path = "EAApp.jpg"
             }
             );*/
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "User Name" }).FillAsync("admin");
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync(); 
            //await Page.ScreenshotAsync(new() { Path = "AfterLogin.jpg" });
            //var isExist = await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).IsVisibleAsync();
            //Assert.IsTrue(isExist);
            //since we are now using NUnit, you can use the expect to assert your test
            await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Logout" })).ToBeVisibleAsync();
            /* await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Logout" })).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
             {
                 Timeout = 5000
             });*/
            //To increase the time visibility from the 3000ms tp 5000ms, use the above to state it

        }
        
    }
}