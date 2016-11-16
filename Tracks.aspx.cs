using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Xml.Linq;
using System.IO;
using System.Collections;

public partial class Tracks : System.Web.UI.Page {

    private string track;
    private string artist;
    private string album;
    private string year;
    private GridViewRow row;

    protected void Page_Load(object sender, EventArgs e) {
        IniTracks();
        ddlPlaylistNames.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    }

    protected void IniTracks() {

        try {
            gvTracks.DataSource = Track.GetTracks().DefaultView;
            gvTracks.DataBind();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
       
    }

    protected void gvTracks_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvTracks.SelectedIndex > -1) {
            ArrayList list = new ArrayList();

            string path = Server.MapPath("~/App_Data/");

            foreach (string playlist in Directory.GetFiles(path, "*.xml").Select(Path.GetFileNameWithoutExtension)) {
                list.Add(playlist);
            }

            ddlPlaylistNames.DataSource = list;
            ddlPlaylistNames.DataBind();

            txtFileName.Text = string.Empty;
            lblMessages.Text = string.Empty;
            lblMessagePopUp.Text = string.Empty;
            mpeAddToPlaylist.Show();
        }

    }

    protected void btnCreate_Click(object sender, EventArgs e) {
        string newFile = txtFileName.Text;

        row = gvTracks.SelectedRow;
        track = row.Cells[1].Text;
        artist = row.Cells[2].Text;
        album = row.Cells[3].Text;
        year = row.Cells[4].Text;

        string path = Server.MapPath("~/App_Data/" + newFile + ".xml");
        try {

            if (newFile != string.Empty) {
                if (!File.Exists(path)) {
                    XDocument doc = new XDocument(new XElement("playlist",
                                                 new XElement("track",
                                                     new XElement("Track", track),
                                                     new XElement("Artist", artist),
                                                     new XElement("Album", album),
                                                     new XElement("Year", year))));

                    doc.Save(path);
                    lblMessages.Text = "Created playlist " + newFile + " and track " + track + " added to list.";
                } else {
                    mpeAddToPlaylist.Show();
                    lblMessagePopUp.Text = newFile + " alredy exists.";
                }
            } else {
                mpeAddToPlaylist.Show();
                lblMessagePopUp.Text = "Give your playlist a name.";
            }
        } catch (Exception ex) {
            lblMessagePopUp.Text = ex.Message;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {

        string selected = ddlPlaylistNames.SelectedValue;

        row = gvTracks.SelectedRow;
        track = row.Cells[1].Text;
        artist = row.Cells[2].Text;
        album = row.Cells[3].Text;
        year = row.Cells[4].Text;

        string path = Server.MapPath("~/App_Data/" + selected + ".xml");
        try {
            if (File.Exists(path)) {

                XDocument xDoc = XDocument.Load(path);
                xDoc.Root.Add(new XElement("track",
                                            new XElement("Track", track),
                                                 new XElement("Artist", artist),
                                                 new XElement("Album", album),
                                                 new XElement("Year", year)));
                xDoc.Save(path);
                lblMessages.Text = "Track " + track + " added to playlist " + selected;
            } else {
                mpeAddToPlaylist.Show();
                lblMessagePopUp.Text = "File is missing.";
            }
        } catch (Exception ex) {
            lblMessagePopUp.Text = ex.Message;
        }

    }
    protected void btnCancelAdd_Click(object sender, EventArgs e) {
        mpeAddToPlaylist.Hide();
    }

    protected void gvTracks_RowDataBound(object sender, GridViewRowEventArgs e) {
        for (int i = 5; i < 10; i++) {
            e.Row.Cells[i].Visible = false;
        }

        e.Row.Cells[1].Attributes.Add("onclick", "location='AlbumPage.aspx?trackName=" + e.Row.Cells[1].Text + "&albumName=" + e.Row.Cells[3].Text + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[2].Text + "'");
        e.Row.Cells[3].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[3].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[4].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            e.Row.Cells[0].Attributes.Add("onmouseover", "this.style.backgroundColor='#ACCB12';this.style.cursor='default';this.style.textDecoration='underline'");
            e.Row.Cells[0].Attributes.Add("onmouseout", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}
