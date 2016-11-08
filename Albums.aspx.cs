﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Albums : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniAlbums();
    }

    protected void IniAlbums() {
        gvAlbums.DataSource = Album.GetAlbums().DefaultView;
        gvAlbums.DataBind();
    }

    protected void gvAlbums_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;

        e.Row.Cells[0].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[0].Text + "'");
        e.Row.Cells[1].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[1].Text + "'");
        e.Row.Cells[3].Attributes.Add("onclick", "location='CompanyPage.aspx?companyName=" + e.Row.Cells[3].Text + "'");
    }
}