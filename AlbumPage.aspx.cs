using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
public partial class AlbumPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniAlbumPage();
    }

    protected void IniAlbumPage()
    {
        string albumName = Request.QueryString["albumName"];
        lblAlbumName.Text = albumName;
        gvAlbumPage.DataSource = Album.GetAlbumTracks(albumName);
        gvAlbumPage.DataBind();

        albumImage.ImageUrl = Album.GetImageUrl(albumName);
    }

    
}