using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Tracks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniTracks();
    }

    protected void IniTracks()
    {
        gvTracks.DataSource = Track.GetTracks().DefaultView;
        gvTracks.DataBind();
    }

    protected void gvTracks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 4; i < 9; i++)
        {
            e.Row.Cells[i].Visible = false;
        }
    }
}