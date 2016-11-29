using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        Session.Remove("username");
        Session.Remove("usertype");
        loggedOutText.InnerText = "You have been logged out. See you again :)";
        Response.AddHeader("REFRESH", "1;URL=Login.aspx");
        FormsAuthentication.SignOut();
    }
}