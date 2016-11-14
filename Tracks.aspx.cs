using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Tracks : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniTracks();
    }

    protected void IniTracks() {
        gvTracks.DataSource = Track.GetTracks().DefaultView;
        gvTracks.DataBind();
    }

    protected void gvTracks_RowDataBound(object sender, GridViewRowEventArgs e) {
        for (int i = 4; i < 9; i++) {
            e.Row.Cells[i].Visible = false;
        }

        e.Row.Cells[0].Attributes.Add("onclick", "location='AlbumPage.aspx?trackName=" + e.Row.Cells[0].Text + "&albumName=" + e.Row.Cells[2].Text + "'");
        e.Row.Cells[1].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[1].Text + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[2].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}