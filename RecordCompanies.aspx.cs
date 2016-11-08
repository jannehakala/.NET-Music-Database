using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class RecordCompanies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniRecordCompanies();
    }

    protected void IniRecordCompanies()
    {
        gvRecordCompanies.DataSource = Company.GetCompanies().DefaultView;
        gvRecordCompanies.DataBind();
    }

    protected void gvRecordCompanies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[3].Visible = false;
    }
}