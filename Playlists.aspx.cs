using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Playlists : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {

            try {
                IniDDL();

                string albumName = Request.QueryString["albumName"];
                string trackName = Request.QueryString["trackName"];
                string youtubeCode = "";
                string selectedPlaylist = Request.QueryString["playlist"];

                if (selectedPlaylist != string.Empty) {
                    ddlPlaylistNames.SelectedValue = selectedPlaylist;
                } else {
                    ddlPlaylistNames.SelectedIndex = 0;
                }
                
                youtubeCode = Track.GetTrackTubepath(trackName);

                youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml"));
                gvPlaylist.DataSource = ds;
                gvPlaylist.DataBind();

            } catch (Exception ex) {
                lblMessages.Text = ex.Message;
            }
        }
    }

    protected void IniDDL() {
        ArrayList list = new ArrayList();

        string path = Server.MapPath("~/App_Data/");

        foreach (string playlist in Directory.GetFiles(path, "*.xml").Select(Path.GetFileNameWithoutExtension)) {
            list.Add(playlist);
        }

        ddlPlaylistNames.DataSource = list;
        ddlPlaylistNames.DataBind();
    }

    protected void gvPlaylist_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[0].Attributes.Add("onclick", "location='Playlists.aspx?trackName=" + e.Row.Cells[0].Text + "&albumName=" + e.Row.Cells[2].Text + "&playlist=" + ddlPlaylistNames.SelectedValue + "'");
        e.Row.Cells[1].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[1].Text + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[2].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }


    protected void ddlPlaylistNames_SelectedIndexChanged(object sender, EventArgs e) {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml"));
        gvPlaylist.DataSource = ds;
        gvPlaylist.DataBind();
    }

    protected void btnDeletePlaylist_Click(object sender, EventArgs e) {
        try {
            File.Delete(Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml"));
            IniDDL();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
    }
}