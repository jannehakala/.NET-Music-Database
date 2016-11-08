﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Genres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniGenres();
    }

    protected void IniGenres()
    {
        gvGenres.DataSource = Genre.GetGenres().DefaultView;
        gvGenres.DataBind();

    }


    protected void gvGenres_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
}