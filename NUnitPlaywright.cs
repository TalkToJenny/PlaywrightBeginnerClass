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
        }

        [Test]
        public async Task Test1()
        {
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
           /* await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "EAApp.jpg"
            }
            );*/
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "User Name" }).FillAsync("admin");
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync(); ;
            //await Page.ScreenshotAsync(new() { Path = "AfterLogin.jpg" });
            //var isExist = await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).IsVisibleAsync();
            //Assert.IsTrue(isExist);
            //since we are now using NUnit, you can use the expect to assert your test
            await Expect(Page.GetByRole(AriaRole.Button,new() { Name = "Logout" })).ToBeVisibleAsync();
        }
    }
}