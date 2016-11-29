using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        string username = (string)Session["username"];
        Session["currentpage"] = "Home";
        pageHeader.InnerText = "Welcome, Guest!";

        if (username != null) {
            pageHeader.InnerText = "Welcome, " + username + "!";
        }
    }
}