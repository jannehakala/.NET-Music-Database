using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class RecordCompanies : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        Session["currentpage"] = "RecordCompanies";
        IniRecordCompanies();
        string usertype = (string)Session["usertype"];
        if (usertype == "user" || usertype == "admin") {
            btnEdit.Attributes.Add("style", "display:default");
        } else {
            btnEdit.Attributes.Add("style", "display:none");
        }
    }

    protected void IniRecordCompanies() {
        try {
            gvRecordCompanies.DataSource = Company.GetCompanies().DefaultView;
            gvRecordCompanies.DataBind();
        } catch (Exception ex) {
            lblMessages.Text = ex.Message;
        }
        
    }

    protected void gvRecordCompanies_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[3].Visible = false;

        e.Row.Attributes.Add("onclick", "location='CompanyPage.aspx?companyName=" + e.Row.Cells[0].Text + "'");

        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
        }
    }
}