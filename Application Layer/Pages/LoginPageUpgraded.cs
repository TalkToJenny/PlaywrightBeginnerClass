using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightBeginner.Application_Layer.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;
        /* private readonly ILocator _lnkLogin;
         private readonly ILocator _usernameTextField;
         private readonly ILocator _passwordTextField;
         private readonly ILocator _signinBtn;
         private readonly ILocator _lnkDetails;
         private readonly ILocator _lnkLogout;*/
        public LoginPageUpgraded(IPage page) => _page = page;
        private ILocator _lnkLogin => _page.Locator(selector: "text=Login");
        private ILocator _usernameTextField => _page.Locator(selector: "#UserName");
        private ILocator _passwordTextField => _page.Locator(selector: "#Password");
        private ILocator _signinBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" });
        private ILocator _lnkLogout => _page.GetByRole(AriaRole.Button, new() { Name = "Logout" });

        private ILocator _employeeList => _page.GetByRole( AriaRole.Link,new() { Name = "👥 Employees" });
        //_page.Locator("a.nav-link[href='/Employee']")


        /*   _lnkLogin = _page.Locator(selector: "text=Login");
           _usernameTextField = _page.Locator(selector: "#UserName");
           _passwordTextField = _page.Locator(selector: "#Password");
           //_signinBtn = _page.Locator(selector: "text=Sign In");
           _signinBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" });
           //_lnkDetails = _page.Locator(selector: "text = 'Details'");
           //_lnkLogout = _page.Locator(selector: "text = 'Logout'");
           _lnkLogout = _page.GetByRole(AriaRole.Button, new() { Name = "Logout" });*/
        //the above will be replaced into LoginLink method declared globally
        //I can run because my locator are not the same, some with page.locator and some with page.getbyrole


        // public async Task ClickLogin() => await _lnkLogin.ClickAsync();
        /*public async Task ClickLogin()

        *//*{
            await _page.RunAndWaitForNavigationAsync(action: async () =>
            {
                await _lnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**//*Login"
            });
        }*/
        //the above tell you the page you are in using the wildcart **/Login but this format is now obselete, hence the next ClickLogin method


        /* public async Task ClickLogin()

         {
             await _lnkLogin.ClickAsync();

             await _page.WaitForURLAsync("**//*Login");
         }*/
        public async Task ClickLogin()
        {
            await Task.WhenAll(
                _page.WaitForURLAsync("**/Login"),
                _lnkLogin.ClickAsync()
            );
        }



        public async Task Login(string username, string password)
        {
            await _usernameTextField.FillAsync(username);
            await _passwordTextField.FillAsync(password);
            await _signinBtn.ClickAsync();
        }

        public async Task ClickEmployeesList() => await _employeeList.ClickAsync();
   
        
        public async Task<bool> IsLogoutTabDisplayed() => await _lnkLogout.IsVisibleAsync();
        public async Task<bool> IsEmployeesDetailDisplayed() => await _employeeList.IsVisibleAsync();

        //assertion
    }
}

