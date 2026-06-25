using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightBeginner.Application_Layer.Pages
{
  public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _lnkLogin;
        private readonly ILocator _usernameTextField;
        private readonly ILocator _passwordTextField;
        private readonly ILocator _signinBtn;
        private readonly ILocator _lnkDetails;
        private readonly ILocator _lnkLogout;
        public LoginPage(IPage page)
        {
           _page = page;
            _lnkLogin = _page.Locator(selector: "text=Login");
            _usernameTextField = _page.Locator(selector: "#UserName");
            _passwordTextField = _page.Locator(selector: "#Password");
            //_signinBtn = _page.Locator(selector: "text=Sign In");
            _signinBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" });
            //_lnkDetails = _page.Locator(selector: "text = 'Details'");
            //_lnkLogout = _page.Locator(selector: "text = 'Logout'");
            _lnkLogout = _page.GetByRole(AriaRole.Button, new() { Name = "Logout" });
        }

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();
        public async Task Login(string username, string password)
        {
            await _usernameTextField.FillAsync(username);
            await _passwordTextField.FillAsync(password);
            await _signinBtn.ClickAsync();
        }

        public async Task<bool> IsLogoutTabDisplayed() => await _lnkLogout.IsVisibleAsync();
     
        //assertion
    }
}
