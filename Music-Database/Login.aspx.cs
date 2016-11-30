using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Login : System.Web.UI.Page {

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

    protected void login_Authenticate(object sender, AuthenticateEventArgs e) {
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
        string message = string.Empty;

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
                    errorMessage.InnerText = message;
                    return true;
                } else {
                    passwordTextBox.Focus();
                    return false;
                }
            } else {
                errorMessage.InnerText = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\n";
                passwordTextBox.Focus();
                return false;
            }
        } catch (Exception ex) {
            passwordTextBox.Focus();
            errorMessage.InnerText = ex.Message;
        } finally {
            if (message != string.Empty) {
                errorMessage.InnerText = message;
            }
        }
        return false;
    }

    protected void btnLoginGuest_Click(object sender, EventArgs e) {
        IsGuest = true;
        login_Authenticate(null, new AuthenticateEventArgs());
    }
}