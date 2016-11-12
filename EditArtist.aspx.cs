using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Data;

public partial class EditArtist : System.Web.UI.Page
{
    int selectedId = 0;
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


    protected void gvEditArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvEditArtist.SelectedIndex > -1)
        {
            try
            {
                GridViewRow row = gvEditArtist.SelectedRow;
                txtArtistName.Text = row.Cells[1].Text;
                ddlSelectYear.Text = row.Cells[2].Text;
                ddlSelectCountry.Text = row.Cells[3].Text;
                //selectedId = int.Parse(row.Cells[4].Text);
                selectedId = Convert.ToInt32(row.Cells[4].Text);
                lblMessages.Text = selectedId.ToString();
                
           
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void gvEditArtist_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = gvEditArtist.Rows[e.NewSelectedIndex];
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtArtistName.Text != "")
        {
            try
            {
                string name = txtArtistName.Text;
                int year = int.Parse(ddlSelectYear.Text);
                string country = ddlSelectCountry.Text;
                Artist.AddArtist(name, country, year);
                IniEditArtist();
            }
            catch (Exception ex)
            {

                lblMessages.Text = ex.Message.ToString();
            }
        }
        
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Artist.DeleteArtist(selectedId);
            IniEditArtist();
        }
        catch (Exception ex)
        {

            lblMessages.Text = ex.Message.ToString();
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string name = txtArtistName.Text;
            int year = Convert.ToInt32(ddlSelectYear.Text);
            string country = ddlSelectCountry.ToString();
            Artist.UpdateArtist(89, name, country, year);
            IniEditArtist();
        }
        catch (Exception ex)
        {

            lblMessages.Text = ex.Message.ToString();
        }
      
    }
}