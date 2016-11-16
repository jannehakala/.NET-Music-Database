using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class User : System.Web.UI.Page {
    private string user;
    Validator validator;
    protected void Page_Load(object sender, EventArgs e) {
        txtPassword.Focus();
        user = (string)Session["username"];
        userName.InnerText = user;
        txtPassword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnChangePassword.ClientID + "')");
        txtRePassword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnChangePassword.ClientID + "')");
    }

    protected void btnChangePassword_Click(object sender, EventArgs e) {
        try {
            validator = new Validator();

            string newPassword = txtPassword.Text;
            string rePassword = txtRePassword.Text;
            if (newPassword != string.Empty && rePassword != string.Empty) {
                if (validator.CheckPasswordsAreSame(newPassword, rePassword)) {
                    Users.UpdatePassword(user, newPassword);
                    lblMessages.Text = "Password updated to database. <br/> You will need to login again.";
                    Response.AddHeader("REFRESH", "2;URL=Logout.aspx");
                } else {
                    lblMessages.Text = "Passwords do not match.";
                }
            } else {
                lblMessages.Text = "Fill fields first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
    }
}