using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Xml.Linq;
using System.IO;

public partial class Tracks : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniTracks();
    }

    protected void IniTracks() {
        gvTracks.DataSource = Track.GetTracks().DefaultView;
        gvTracks.DataBind();
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

    protected void btnOk_Click(object sender, ImageClickEventArgs e) {
        //Do Work

        mpeAddToPlaylist.Hide();
    }

    protected void gvTracks_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvTracks.SelectedIndex > -1) {
            try {
                GridViewRow row;
                row = gvTracks.SelectedRow;
                string track = row.Cells[1].Text;
                string artist = row.Cells[2].Text;
                string album = row.Cells[3].Text;
                string year = row.Cells[4].Text;
                lblMessages.Text = track + artist + album + year;

                mpeAddToPlaylist.Show();


                string path = Server.MapPath("~/App_Data/playlist.xml");

                if (!File.Exists(path)) {
                    XDocument doc = new XDocument(new XElement("playlist",
                                                 new XElement("track",
                                                     new XElement("Track", track),
                                                     new XElement("Artist", artist),
                                                     new XElement("Album", album),
                                                     new XElement("Year", year))));

                    doc.Save(path);
                } else {
                    XDocument xDoc = XDocument.Load(path);
                    xDoc.Root.Add(new XElement("track",
                                                new XElement("Track", track),
                                                     new XElement("Artist", artist),
                                                     new XElement("Album", album),
                                                     new XElement("Year", year)));
                    xDoc.Save(path);
                }





            } catch (Exception ex) {

            }
        }
    }
}