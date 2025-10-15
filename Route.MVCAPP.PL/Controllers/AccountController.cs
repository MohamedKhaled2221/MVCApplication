using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Route.MVCAPP.BLL.Common.Service.EmailSettings;
using Route.MVCAPP.DAL.Models.identity;
using Route.MVCAPP.PL.ViewModels.identity;

namespace Route.MVCAPP.PL.Controllers
{
    public class AccountController : Controller
    {
        #region Services
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSettings _emailSettings;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager, IEmailSettings emailSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSettings = emailSettings;
        }
        #endregion
        // Register , Login , Signout
        #region Part 4 Account Controller - Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var User = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if (User is { })
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName), "This Name is Already Exists");
                return View(registerViewModel);
            }
            User = new ApplicationUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                IsAgree = registerViewModel.IsAgree
            };
            var Result = await _userManager.CreateAsync(User, registerViewModel.Password);
            if (Result.Succeeded)
            {

                return RedirectToAction("LogIn");
            }
            foreach (var error in Result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(registerViewModel);
        }
        #endregion

        //        #region LogIn
        //        [HttpGet]
        //        public IActionResult LogIn()
        //        {
        //            return View();
        //        }

        //        [HttpPost]
        //        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest();
        //            }
        //            // 1-  Find User by Email
        //            var User = await _userManager.FindByEmailAsync(loginViewModel.Email);
        //            // 2- if User Is not null
        //            if (User is { })
        //            {
        //                // 3 - Check Password is Correct
        //                var flag = await _userManager.CheckPasswordAsync(User, loginViewModel.Password);
        //                if (flag) // Email Exists and Password is Correct
        //                {
        //                    // 4 - Login
        //                    var Result = await _signInManager.PasswordSignInAsync(User, loginViewModel.Password, loginViewModel.RememberMe, false);
        //                    if (Result.IsNotAllowed)
        //                    {

        //                        ModelState.AddModelError(string.Empty, "You are not Allowed to Login");
        //                        return View(loginViewModel);
        //                    }
        //                    if (Result.IsLockedOut)
        //                    {

        //                        ModelState.AddModelError(string.Empty, "Your Account is Locked");
        //                        return View(loginViewModel);
        //                    }
        //                    if (Result.Succeeded)
        //                    {
        //                        return RedirectToAction(nameof(HomeController.Index), "Home");
        //                    }
        //                }

        //            }

        //            // 4 - Login
        //            // 5 - if Account is allowed or locked

        //            ///else 
        //            ModelState.AddModelError(string.Empty, "Invalid Email or Password");
        //            return View(loginViewModel);
        //        }
        //        #endregion
        //        #region SignOut
        //        [HttpGet]
        //        public async new Task<IActionResult> SignOut()
        //        {
        //            // Delete Token
        //            await _signInManager.SignOutAsync();
        //            return RedirectToAction(nameof(LogIn));
        //        }
        //        #endregion
        //        #region Forget Password
        //        [HttpGet]
        //        public IActionResult ForgetPassword()
        //        {
        //            return View();
        //        }
        //        [HttpPost]
        //        public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordViewModel forgetPasswordViewModel)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var User = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Email);
        //                if (User is not null)
        //                {
        //                    // Generate URL

        //                    // Generate Token
        //                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);
        //                    var resetPassword = Url.Action("ResetPassword", "Account", new { email = forgetPasswordViewModel.Email, token = token }, Request.Scheme);
        //                    // https://localhost:7193/Account/ResetPassword?email=mo@gmail.com&token=dsfsdfdsfsdfdsfsdf
        //                    var email = new Email()
        //                    {
        //                        To = forgetPasswordViewModel.Email,
        //                        Subject = "Reset Your Password",
        //                        Body = resetPassword ?? string.Empty
        //                    };
        //                    // Send Email
        //                    _emailSettings.SendEmail(email);

        //                    return RedirectToAction("CheckYourInbox");

        //                }
        //                ModelState.AddModelError(string.Empty, "Invalid Email");


        //            }
        //            return View(forgetPasswordViewModel);
        //        }
        //        #endregion
        //        [HttpGet]
        //        public IActionResult CheckYourInbox()
        //        {
        //            return View();
        //        }
        //        [HttpGet]
        //        public IActionResult ResetPassword(string email, string token)
        //        {
        //           TempData["email"] = email;
        //            TempData["token"] = token;
        //            return View();
        //        }
        //        [HttpPost]
        //        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var email = TempData["email"] as string;
        //                var token = TempData["token"] as string;
        //                var User =await  _userManager.FindByEmailAsync(email);
        //                if (User is not null)
        //                {
        //                    var Result =await  _userManager.ResetPasswordAsync(User, token , resetPasswordViewModel.Password);
        //                    if (Result.Succeeded)
        //                    {
        //                        return RedirectToAction("LogIn");
        //                    }
        //                    foreach (var error in Result.Errors)
        //                    {
        //                        ModelState.AddModelError(string.Empty, error.Description);
        //                    }
        //                    return View(resetPasswordViewModel);
        //                }


        //            }
        //            ModelState.AddModelError(string.Empty, "Invalid Operation , Please Try again");
        //            return View(resetPasswordViewModel);
        //        }
        //    }
    }

