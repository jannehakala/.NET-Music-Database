using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Playlists : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/App_Data/playlist.xml"));
        gvPlaylist.DataSource = ds;
        gvPlaylist.DataBind();
    }
}