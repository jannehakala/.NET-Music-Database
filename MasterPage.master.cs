using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class MasterPage : System.Web.UI.MasterPage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            string username = (string)Session["username"];
            string usertype = (string)Session["usertype"];

            if (usertype == null) {
                usertype = "guest";
            }

            if (usertype == "admin") {
                userSettings.Attributes.Add("style", "display:default");
                userNameLink.Attributes.Add("href", "UserSettings.aspx");
            }

            if (usertype == "user") {
                userSettings.Attributes.Add("style", "display:default");
                userNameLink.Attributes.Add("href", "UserSettings.aspx");
            }

            if (usertype == "guest") {
                userSettings.Attributes.Add("style", "display:none");
                userNameLink.Attributes.Add("href", "Home.aspx");
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
    }


    protected void btnSearch_Click(object sender, EventArgs e) {
       string srcparam = txtInput.Text;

        string currentpage = (string)Session["currentpage"];
        switch (currentpage) {
            case "Artists":
                GridView gvArtist = (GridView)body.FindControl("gvArtist");
                gvArtist.DataSource = Artist.SearchArtist("%" + srcparam + "%");
                gvArtist.DataBind();
                break;
            case "Albums":
                GridView gvAlbums = (GridView)body.FindControl("gvAlbums");
                gvAlbums.DataSource = Album.SearchAlbum("%" + srcparam + "%");
                gvAlbums.DataBind();
                break;
            default:
                break; 
        }



        
        
    }
}
