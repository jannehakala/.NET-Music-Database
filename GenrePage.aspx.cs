using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class GenrePage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniGenrePage();
    }

    protected void IniGenrePage() {

        try {
            string genreName = Request.QueryString["genreName"];
            lblGenreName.Text = genreName;
            gvGenrePage.DataSource = Genre.GetGenreTracks(genreName);
            gvGenrePage.DataBind();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
        
    }

    protected void gvGenrePage_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[0].Attributes.Add("onclick", "location='AlbumPage.aspx?trackName=" + e.Row.Cells[0].Text + "&albumName=" + e.Row.Cells[2].Text + "'");
        e.Row.Cells[1].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[1].Text + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[2].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[3].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}