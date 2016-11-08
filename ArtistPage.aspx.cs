using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class ArtistPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniArtistAlbums();
    }

    protected void IniArtistAlbums()
    {
        string artistName = Request.QueryString["artistName"];
        lblArtistName.Text = artistName;
        gvArtistPage.DataSource = Artist.GetArtistAlbums(artistName);
        gvArtistPage.DataBind();
    }




    protected void gvArtistPage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[0].Text + "'");
    }
}