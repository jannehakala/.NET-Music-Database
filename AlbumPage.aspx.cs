﻿using System;
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


        lblAlbumInfo.Text = "from artist <a href='ArtistPage.aspx?artistName=" + array[0] + "' id='link'>" + "<span style='color:black';>" + array[0] + "</span></a>" +
            " \u2022 " + array[1] + " \u2022 \n" + array[2] + " tracks, " + length;
        

        lblTrackName.Text = trackName;

        gvAlbumPage.DataSource = Album.GetAlbumTracks(albumName);
        gvAlbumPage.DataBind();

        albumImage.ImageUrl = Album.GetImageUrl(albumName);

        youtubeCode = Track.GetTrackTubepath(trackName);

        youtubeVideo.Attributes["src"] = "https://www.youtube.com/embed/" + youtubeCode + "?rel=0&autoplay=1";
    }

    protected void gvAlbumPage_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[1].Attributes.Add("onclick", "location='AlbumPage.aspx?trackName=" + e.Row.Cells[1].Text + "&albumName=" + albumName + "'");
    }
}