using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Drawing;

public partial class Login : System.Web.UI.Page {
    Validator validator;
    protected void Page_Load(object sender, EventArgs e) {
        txtUsername.Focus();
        txtPassword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnRegisterLoginForm.ClientID + "')");
    }

    protected void btnLogin_Click(object sender, EventArgs e) {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string message = string.Empty;
        validator = new Validator();
        
        try {
            if (validator.ValidateLogin(username, password)) {

                BLLogin login = new BLLogin(username, password);
                if (login.LoginUser(out message)) {

                    Session["username"] = username;
                    if (login.CheckIfAdmin()) {
                        Session["usertype"] = "admin";
                    } else if (!login.CheckIfAdmin()) {
                        Session["usertype"] = "user";
                    } else {
                        Session["usertype"] = "guest";
                    }
                    errorMessageContainer.Style["background-color"] = "green";
                    errorMessage.InnerText = "Login was successful!";
                    lblMessage.Text = "Logging in...";
                    Response.AddHeader("REFRESH", "1;URL=Home.aspx");
                } else {
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                }
            } else {
                errorMessage.InnerText = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.";
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
            }
        } catch (Exception ex) {
            message = ex.Message;
        } finally {
            if (message != string.Empty) {
                errorMessage.InnerText = message;
            }
        }
    }
}