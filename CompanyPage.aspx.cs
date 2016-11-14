using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class CompanyPage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        IniCompanyPage();
    }

    protected void IniCompanyPage() {
        string companyName = Request.QueryString["companyName"];
        lblCompanyName.Text = companyName;
        gvCompanyPage.DataSource = Company.GetCompanyAlbums(companyName);
        gvCompanyPage.DataBind();
    }

    protected void gvCompanyPage_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[0].Attributes.Add("onclick", "location='AlbumPage.aspx?albumName=" + e.Row.Cells[0].Text + "'");
        e.Row.Cells[1].Attributes.Add("onclick", "location='ArtistPage.aspx?artistName=" + e.Row.Cells[1].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}