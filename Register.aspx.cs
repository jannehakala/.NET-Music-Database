using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Register : System.Web.UI.Page {
    Validator validator;
    protected void Page_Load(object sender, EventArgs e) {
        txtUsername.Focus();
        txtPassword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnRegisterLoginForm.ClientID + "')");
    }

    protected void btnRegisterLoginForm_Click(object sender, EventArgs e) {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string repassword = txtRePassword.Text;
        string message = "";
        validator = new Validator();

        try {
            if (validator.ValidateRegister(username, password, repassword)) {

                BLRegister register = new BLRegister(username, password);
                if (register.RegisterUser(out message)) {
                    errorMessageContainer.Style["background-color"] = "green";
                    errorMessage.InnerText = "Registration was successful!";
                    lblMessage.Text = "Registering...";
                    Response.AddHeader("REFRESH", "1.5;URL=Login.aspx");
                } else {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                    txtUsername.Focus();
                }
            } else {
                errorMessage.InnerText = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtUsername.Focus();
            }
        } catch (Exception ex) {
            message = ex.Message;
        } finally {
            if (message != "") {
                errorMessage.InnerText = message;
            }
        }
    }
}
