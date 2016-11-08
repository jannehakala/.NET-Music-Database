using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniAlbums();
    }

    protected void IniAlbums()
    {
        gvAlbums.DataSource = Album.GetAlbums().DefaultView;
        gvAlbums.DataBind();        
    }

    protected void gvAlbums_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
    }
}