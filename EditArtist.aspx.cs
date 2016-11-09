using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class EditArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IniEditArtist();
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectCountry.DataSource = Users.GetComboBoxCountries();
        ddlSelectCountry.DataBind();
    }

    protected void IniEditArtist()
    {
        gvEditArtist.DataSource = Artist.GetArtists().DefaultView;
        gvEditArtist.DataBind();
    }


}