﻿using FinalProject_LMS.Models;
using FinalProject_LMS.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_LMS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public AccountController()
        {
        }


        public ActionResult AllStudents(string searchName, bool Assending = true, string SortOn = null)
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;


            List<AllStudentsView> studentsList = new List<AllStudentsView>();
            var users = db.Users.ToList();
            if (searchName == null && SortOn == null)
            {
                users = db.Users.Where(u => u.CourseId != null).ToList();
            }
            else if (searchName != null)
            {
                users = db.Users.Where(u => u.CourseId != null).Where(u => u.Name.Contains(searchName)).ToList();
            }

            else if (SortOn == "Name")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.Name).ToList();
            }
            else if (SortOn == "Email")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.Name).ToList();
            }

            else if (SortOn == "CourseId")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.CourseId).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.CourseId).ToList();
            }





            foreach (var s in users)
            {
                var Course = db.Courses.Single(c => c.Id == s.CourseId);
                studentsList.Add(new AllStudentsView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    CourseName = Course.Name


                }
                    );

            }

            return View(studentsList);

        }
        public ActionResult SearchStudents(string searchName, bool Assending = true, string SortOn = null)
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;



            List<AllStudentsView> studentsList = new List<AllStudentsView>();
            var users = db.Users.ToList();
            if (searchName == null && SortOn == null)
            {
                users = db.Users.Where(u => u.CourseId != null).ToList();
            }
            else if (searchName != null)
            {
                users = db.Users.Where(u => u.CourseId != null).Where(u => u.Name.Contains(searchName)).ToList();
            }

            else if (SortOn == "Name")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.Name).ToList();
            }
            else if (SortOn == "Email")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.Name).ToList();
            }

            else if (SortOn == "CourseId")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId != null).OrderBy(u => u.CourseId).ToList();
                else
                    users = db.Users.Where(u => u.CourseId != null).OrderByDescending(u => u.CourseId).ToList();
            }





            foreach (var s in users)
            {
                var Course = db.Courses.Single(c => c.Id == s.CourseId);
                studentsList.Add(new AllStudentsView()
                {
                    Name = s.Name,
                    Email = s.Email,
                    CourseName = Course.Name


                }
                    );

            }

            return View(studentsList);

        }
        public ActionResult SearchTeachers(string searchName, bool Assending = true, string SortOn = null)
        {

            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;


            List<AllTeachersView> teachersList = new List<AllTeachersView>();
            var users = db.Users.ToList();
            if (searchName == null && SortOn == null)
            {
                users = db.Users.Where(u => u.CourseId == null).ToList();
            }
            else if (searchName != null)
            {
                users = db.Users.Where(u => u.CourseId == null).Where(u => u.Name.Contains(searchName)).ToList();
            }

            else if (SortOn == "Name")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId == null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId == null).OrderByDescending(u => u.Name).ToList();
            }
            else if (SortOn == "Email")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId == null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId == null).OrderByDescending(u => u.Name).ToList();
            }







            foreach (var s in users)
            {

                teachersList.Add(new AllTeachersView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email



                }
                    );

            }


          

            return View(teachersList);


        }


        public ActionResult AllTeachers(string searchName, bool Assending = true, string SortOn = null)
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;


            List<AllTeachersView> teachersList = new List<AllTeachersView>();
            var users = db.Users.ToList();
            if (searchName == null && SortOn == null)
            {
                users = db.Users.Where(u => u.CourseId == null).ToList();
            }
            else if (searchName != null)
            {
                users = db.Users.Where(u => u.CourseId == null).Where(u => u.Name.Contains(searchName)).ToList();
            }

            else if (SortOn == "Name")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId == null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId == null).OrderByDescending(u => u.Name).ToList();
            }
            else if (SortOn == "Email")
            {
                if (Assending == true)
                    users = db.Users.Where(u => u.CourseId == null).OrderBy(u => u.Name).ToList();
                else
                    users = db.Users.Where(u => u.CourseId == null).OrderByDescending(u => u.Name).ToList();
            }







            foreach (var s in users)
            {

                teachersList.Add(new AllTeachersView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email



                }
                    );

            }



            return View(teachersList);

        }




        //public ActionResult Edit(string id = "")
        //{
        //    var UserId = User.Identity.GetUserId();
        //    var user = db.Users.Single(u => u.Id == UserId);
        //    ViewBag.UserName = user.Name;

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser TheUser = db.Users.Find(id);
        //    if (TheUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    EditViewModel model = new EditViewModel()
        //    {
        //        Id = TheUser.Id,
        //        Name = TheUser.Name,
        //        Email = TheUser.Email

        //    };
        //    return View(model);
        //}

        //// POST: Account/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Email,Name")] EditViewModel  TheUser)
        //{
        //    var UserId = User.Identity.GetUserId();
        //    var user = db.Users.Single(u => u.Id == UserId);
        //    ViewBag.UserName = user.Name;
        //    ApplicationUser ModifiedUser = new ApplicationUser()
        //    {
        //        Name = TheUser.Name,
        //        Email = TheUser.Email


        //    };
        //    if (ModelState.IsValid)
        //    {

        //        try
        //        {
        //            db.Entry(ModifiedUser).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
        //                }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(TheUser);
        //}



        // GET: Account/Details/5
        public ActionResult Details(string id="")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser   user = db.Users .Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            RegisterViewModel model = new RegisterViewModel()
            {
                Id = id,
                Name =  user.Name,
                Email = user.Email 
            };

            return View(model);
        }




























        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            Session["UserName"] = null;
            return View();
        }
        //
        //
        // POST: /Account/Login

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;
            Session["UserName"] = user.Name;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:

                    return RedirectToAction("HomePage", "Account");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    //return RedirectToAction("HomePage", "Account");
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }


        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register

        [Authorize(Roles = "Teacher")]
        public ActionResult Register(int? k)
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == UserId);
            ViewBag.UserName = user.Name;

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            RegisterViewModel model = new RegisterViewModel
            {
                Kind = k
            };
            return View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email, CourseId = model.CourseId };
                var result = await UserManager.CreateAsync(user, model.Password);
                var userStore = new UserStore<ApplicationUser>(db);


                if (result.Succeeded)
                {
                    //var userId = User.Identity.GetUserId();
                    //var currentUser = db.Users.Single(u => u.Id == userId);
                    //var oldUser = new ApplicationUser()
                    //{
                    //    Name = currentUser.Name,
                    //    UserName = currentUser.UserName,
                    //    Email = currentUser.Email,
                    //    PasswordHash = currentUser.PasswordHash


                    //};
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home", new { k = model.Kind });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}