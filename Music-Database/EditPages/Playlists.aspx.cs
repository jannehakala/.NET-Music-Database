using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Xml.Linq;
using System.Xml.XPath;

public partial class Playlists : System.Web.UI.Page {
    private string youtubeCode = string.Empty;
    private string trackName = string.Empty;
    private GridViewRow row;

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            Init();
        }
    }

    protected void Init() {
        youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
        try {
            IniDDL();
            InitGridView();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
    }

    protected void InitGridView() {

        try {
            if (ddlPlaylistNames.Items.Count > 0) {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml"));
                gvPlaylist.DataSource = ds;
                gvPlaylist.DataBind();
            } else {
                lblMessages.Text = "Add a playlist from Tracks -page.";
                gvPlaylist.DataBind();
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
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

        string selectedPlaylist = Request.QueryString["playlist"];

        if (selectedPlaylist != string.Empty) {
            ddlPlaylistNames.SelectedValue = selectedPlaylist;
        } else {
            ddlPlaylistNames.SelectedIndex = 0;
        }
    }

    protected void gvPlaylist_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[1].Attributes.Add("onclick", "location='Playlists.aspx?trackName=" + e.Row.Cells[1].Text + "&albumName=" + e.Row.Cells[3].Text + "&playlist=" + ddlPlaylistNames.SelectedValue + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[2].Text + "'");
        e.Row.Cells[3].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[3].Text + "'");
        trackName = Request.QueryString["trackName"];
        lblTrackName.Text = trackName;
        youtubeCode = Track.GetTrackTubepath(trackName);
        youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[4].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            e.Row.Cells[0].Attributes.Add("onmouseover", "this.style.backgroundColor='#CA171B';this.style.cursor='default';this.style.textDecoration='underline'");
            e.Row.Cells[0].Attributes.Add("onmouseout", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
        gvPlaylist.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    }


    protected void ddlPlaylistNames_SelectedIndexChanged(object sender, EventArgs e) {
        lblMessages.Text = string.Empty;
        string path = Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml");
        if (File.Exists(path)) {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            gvPlaylist.DataSource = ds;
            gvPlaylist.DataBind();
        } else {
            lblMessages.Text = "Playlist has been deleted.";
            IniDDL();
        }
    }

    protected void btnDeletePlaylist_Click(object sender, EventArgs e) {
        DeletePlaylist();
    }

    protected void btnAddPlaylist_Click(object sender, EventArgs e) {
        Response.Redirect("Tracks.aspx");
    }

    protected void gvPlaylist_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvPlaylist.SelectedIndex > -1) {

            string track = string.Empty;

            row = gvPlaylist.SelectedRow;

            track = row.Cells[1].Text;
            string path = Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml");
            XDocument xDoc = XDocument.Load(path);
            xDoc.XPathSelectElements(@"//track[Track='" + track + "']").Remove();
            bool exists = xDoc.Descendants("track").Any();
            if (exists) {
                xDoc.Save(path);
                InitGridView();
            } else {
                DeletePlaylist();
            }  
        }
    }

    protected void DeletePlaylist() {
        try {
            if (ddlPlaylistNames.Items.Count < 1) {
                btnDeletePlaylist.Enabled = false;
                lblMessages.Text = "There are no playlists to delete.";
            } else {
                File.Delete(Server.MapPath("~/App_Data/" + ddlPlaylistNames.SelectedValue + ".xml"));
                youtubeCode = string.Empty;
                youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
                lblTrackName.Text = string.Empty;
                Init();
                lblMessages.Text = "Playlist deleted successfully.";
                InitGridView();
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
    }
}