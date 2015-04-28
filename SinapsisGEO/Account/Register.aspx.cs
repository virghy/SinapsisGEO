using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace SinapsisGEO.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
            

            // Get the UserId of the just-added user
            MembershipUser newUser = Membership.GetUser(RegisterUser.UserName);

            Guid newUserId = (Guid)newUser.ProviderUserKey;


            using (DAL.SinapsisEntities db = new DAL.SinapsisEntities())
            {
                DAL.UsersInfo usr = new DAL.UsersInfo();
                usr.UserId = newUserId;
                usr.UserName = newUser.UserName;
                usr.Nombre = ((TextBox)this.RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtNombre")).Text;
                usr.Apellido = ((TextBox)this.RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtApellido")).Text;
                db.UsersInfoes.Add(usr);
                db.SaveChanges();
            }

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/Account/register";
            }
            Response.Redirect(continueUrl);
        }
    }
}