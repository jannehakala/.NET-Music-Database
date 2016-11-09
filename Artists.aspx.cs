using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class Artists : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniArtist();
        //Repeater1.DataSource = GenerateEditLinks();
        //Repeater1.DataBind();
    }

    protected void IniArtist() {
        gvArtist.DataSource = Artist.GetArtists().DefaultView;
        gvArtist.DataBind();

        

    }

    protected void gvArtist_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[3].Visible = false;

        e.Row.Cells[0].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[0].Text + "'");
    }

    protected List<String> GenerateEditLinks()
    {
        try
        {
            List<String> rows = new List<string>();
            foreach (var item in gvArtist.Rows)
            {
                rows.Add(gvArtist.ID);
            }
            return rows;
        }
        catch (Exception ex)
        {
             
            throw ex;
        }
       
    }

}