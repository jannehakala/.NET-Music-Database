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
                playlists.Attributes.Add("style", "display:default");
                userSettings.Attributes.Add("style", "display:default");
                userNameLink.Attributes.Add("href", "UserSettings.aspx");
            }

            if (usertype == "user") {
                playlists.Attributes.Add("style", "display:default");
                userSettings.Attributes.Add("style", "display:default");
                userNameLink.Attributes.Add("href", "UserSettings.aspx");
            }

            if (usertype == "guest") {
                playlists.Attributes.Add("style", "display:none");
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
                loggedAs.InnerText = "guest";
            }
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e) {
        string srcparam = txtInput.Text;

        string currentpage = (string)Session["currentpage"];
        switch (currentpage) {
            case "Artists":
                GridView gvArtist = (GridView)body.FindControl("gvArtist");
                Label lblArtist = (Label)body.FindControl("lblMessages");
                gvArtist.DataSource = Artist.SearchArtist("%" + srcparam + "%");
                gvArtist.DataBind();
                if (gvArtist.Rows.Count == 0) {
                    lblArtist.Text = string.Format("Nothing found");
                }
                break;
            case "Albums":
                GridView gvAlbums = (GridView)body.FindControl("gvAlbums");
                Label lblAlbum = (Label)body.FindControl("lblMessages");
                gvAlbums.DataSource = Album.SearchAlbum("%" + srcparam + "%");
                gvAlbums.DataBind();
                if (gvAlbums.Rows.Count == 0) {
                    lblAlbum.Text = string.Format("Nothing found");
                }
                break;
            case "Tracks":
                GridView gvTracks = (GridView)body.FindControl("gvTracks");
                Label lblTracks = (Label)body.FindControl("lblMessages");
                gvTracks.DataSource = Track.SearchTrack("%" + srcparam + "%");
                gvTracks.DataBind();
                if (gvTracks.Rows.Count == 0) {
                    lblTracks.Text = string.Format("Nothing found");
                }
                break;
            case "Genres":
                GridView gvGenres = (GridView)body.FindControl("gvGenres");
                Label lblGenres = (Label)body.FindControl("lblMessages");
                gvGenres.DataSource = Genre.SearchGenre("%" + srcparam + "%");
                gvGenres.DataBind();
                if (gvGenres.Rows.Count == 0) {
                    lblGenres.Text = string.Format("Nothing found");
                }
                break;
            case "RecordCompanies":
                GridView gvRecordCompanies = (GridView)body.FindControl("gvRecordCompanies");
                Label lblCompany = (Label)body.FindControl("lblMessages");
                gvRecordCompanies.DataSource = Company.SearchCompanies("%" + srcparam + "%");
                gvRecordCompanies.DataBind();
                if (gvRecordCompanies.Rows.Count == 0) {
                    lblCompany.Text = string.Format("Nothing found");
                }
                break;
            case "Home":
                Response.Redirect("Artists.aspx");
                break;
            case "About":
                Response.Redirect("Artists.aspx");
                break;

            default:
                break;
        }
    }
}
