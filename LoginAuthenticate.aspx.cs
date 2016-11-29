using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class LoginAuthenticate : System.Web.UI.Page {

    Validator validator;
    TextBox usernameTextBox;
    TextBox passwordTextBox;
    bool IsGuest;

    protected void Page_Load(object sender, EventArgs e) {

        usernameTextBox = (TextBox)loginAuthenticate.FindControl("UserName");
        passwordTextBox = (TextBox)loginAuthenticate.FindControl("Password");
        usernameTextBox.Focus();


        IsGuest = false;
    }

    protected void login1_Authenticate(object sender, AuthenticateEventArgs e) {
        if (IsGuest) {
            loginAuthenticate.UserName = "guest";
            if (AuthenticateUser("guest", "guestguest")) {
                Session["username"] = "guest";
                FormsAuthentication.RedirectFromLoginPage(loginAuthenticate.UserName, true);
            }
        } else if ((loginAuthenticate.UserName != string.Empty) && (loginAuthenticate.Password != string.Empty)) {
            if (AuthenticateUser(loginAuthenticate.UserName, loginAuthenticate.Password)) {
                Session["username"] = loginAuthenticate.UserName;
                FormsAuthentication.RedirectFromLoginPage(loginAuthenticate.UserName, true);
            }
        } else {
            loginAuthenticate.BackColor = System.Drawing.Color.Orange;
        }
    }

    protected bool AuthenticateUser(string username, string password) {
        validator = new Validator();
        string message = "";

        try {
            if (validator.ValidateLogin(username, password)) {

                BLLogin login = new BLLogin(username, password);
                if (login.LoginUser(out message)) {
                    if (username == "guest") {
                        Session["usertype"] = "guest";
                    } else if (login.CheckIfAdmin()) {
                        Session["usertype"] = "admin";
                    } else {
                        Session["usertype"] = "user";
                    }
                    return true;
                } else {
                    loginAuthenticate.FailureText = "Username or password is invalid.";
                    passwordTextBox.Focus();
                    return false;
                }
            } else {
                loginAuthenticate.FailureText = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.";
                return false;
            }

        } catch (Exception ex) {
            loginAuthenticate.FailureText = ex.Message;
        }
        return false;
    }

    protected void btnLoginGuest_Click(object sender, EventArgs e) {
        IsGuest = true;
        login1_Authenticate(null, new AuthenticateEventArgs());

    }
}