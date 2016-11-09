using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        string username = (string)Session["username"];

        if (username != "") {
            pageHeader.InnerText = "Welcome, " + Session["username"].ToString() + "!";
        }else {
            pageHeader.InnerText = "Welcome, Guest!";    
        }
    }
}