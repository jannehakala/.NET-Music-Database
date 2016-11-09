using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class NewArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectCountry.DataSource = Users.GetComboBoxCountries();
        ddlSelectCountry.DataBind();
    }
}