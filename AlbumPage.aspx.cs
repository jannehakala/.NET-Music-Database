using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
public partial class AlbumPage : System.Web.UI.Page {
    protected string albumName = "";
    protected void Page_Load(object sender, EventArgs e) {
        IniAlbumPage();
    }

    protected void IniAlbumPage() {
        albumName = Request.QueryString["albumName"];
        string trackName = Request.QueryString["trackName"];
        string youtubeCode = "";

        lblAlbumName.Text = albumName;

        List<string> array = Album.GetAlbumInfo(albumName);

        string length = array[3].ToString();
        length = length.Substring(1);

        artistLink.Text = array[0];
        artistLink.NavigateUrl = "ArtistPage.aspx?artistName=" + array[0];

        lblAlbumInfo.Text = "\u2022 " + array[1] + " \u2022 \n" + array[2] + " tracks, " + length;

        lblTrackName.Text = trackName;

        gvAlbumPage.DataSource = Album.GetAlbumTracks(albumName);
        gvAlbumPage.DataBind();

        albumImage.ImageUrl = Album.GetImageUrl(albumName);

        youtubeCode = Track.GetTrackTubepath(trackName);

        youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
    }

    protected void gvAlbumPage_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[1].Attributes.Add("onclick", "location='AlbumPage.aspx?trackName=" + e.Row.Cells[1].Text + "&albumName=" + albumName + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[0].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}