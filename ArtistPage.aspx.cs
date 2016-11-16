using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class ArtistPage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniArtistAlbums();
    }

    protected void IniArtistAlbums() {
        try {
            string artistName = Request.QueryString["artistName"];
            lblArtistName.Text = artistName;
            gvArtistPage.DataSource = Artist.GetArtistAlbums(artistName);
            gvArtistPage.DataBind();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
        
    }

    protected void gvArtistPage_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[0].Attributes.Add("onclick", "location = 'AlbumPage.aspx?albumName=" + e.Row.Cells[0].Text + "'");
        e.Row.Cells[2].Attributes.Add("onclick", "location='CompanyPage.aspx?companyName=" + e.Row.Cells[2].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}