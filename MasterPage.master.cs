using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class MasterPage : System.Web.UI.MasterPage {
    protected void Page_Load(object sender, EventArgs e) {

        string username = (string)Session["username"];
        string usertype = (string)Session["usertype"];
        string currentpage = (string)Session["currentpage"];

        if (usertype == null) {
            usertype = "guest";
        }

        if (usertype == "admin") {
            users.Attributes.Add("style", "display:default");
        }

        if (usertype == "user") {
            users.Attributes.Add("style", "display:default");
        }

        if (usertype == "guest") {
            users.Attributes.Add("style", "display:none");
        }

        if (username != null && usertype == "admin" || usertype == "user") {
            btnLogin.Attributes.Add("style", "display:none");
            btnSignUp.Attributes.Add("style", "display:none");
            btnLogout.Attributes.Add("style", "display:default");
            loggedAs.InnerText = username;
        } else {
            btnLogin.Attributes.Add("style", "display:default");
            btnSignUp.Attributes.Add("style", "display:default");
            btnLogout.Attributes.Add("style", "display:none");
            loggedAs.InnerText = "Guest";
        }

    }




    protected void btnSearch_Click(object sender, EventArgs e) {

        string srcparam = txtInput.Text;
        
        string cp = (string)Session["currentpage"];
        switch (cp) {
            case "Artist":
                Artist.SearchArtist(srcparam);
               
                break;
            case "Album":
                Album.SearchAlbum(srcparam);
                break;
            default:
               
                break;
        }

        
        

    }
}
