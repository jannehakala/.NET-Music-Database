using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Data;

public partial class EditArtist : System.Web.UI.Page {
    int selectedId = 0 ;
    GridViewRow row;
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            IniEditArtist();
            IniDDL();
            
        }

    }

    protected void IniEditArtist() {
        gvEditArtist.DataSource = Artist.GetArtists().DefaultView;
        gvEditArtist.DataBind();
    }

    protected void IniDDL() {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectCountry.DataSource = Users.GetComboBoxCountries();
        ddlSelectCountry.DataBind();
    }


    protected void gvEditArtist_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditArtist.SelectedIndex > -1) {
            try {
                row = gvEditArtist.SelectedRow;
                txtArtistName.Text = row.Cells[1].Text;
                ddlSelectYear.Text = row.Cells[2].Text;
                ddlSelectCountry.Text = row.Cells[3].Text;
                

            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }


    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add Artist") {
                txtArtistName.Text = "";
                btnAdd.Text = "Save new Artist";
                IniDDL();

            } else if (btnAdd.Text == "Save new Artist") {
                if (txtArtistName.Text != "") {
                    string name = txtArtistName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Artist.AddArtist(name, country, year);
                    IniEditArtist();
                    IniDDL();
                    btnAdd.Text = "Add Artist";
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            }
        } catch (Exception ex) {

            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        try {
            row = gvEditArtist.SelectedRow;
            selectedId = int.Parse(row.Cells[4].Text);
            if (selectedId > 0) {
                

                Artist.DeleteArtist(selectedId);
                IniEditArtist();
                txtArtistName.Text = "";
                IniDDL();
            } else {
                lblMessages.Text = "Select Artist";
            }
            
        } catch (Exception ex) {

            lblMessages.Text = ex.Message.ToString();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e) {
        try {
            row = gvEditArtist.SelectedRow;
            selectedId = int.Parse(row.Cells[4].Text);
            if (selectedId > 0 ) {
                if (txtArtistName.Text != "") {
                    string name = txtArtistName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Artist.UpdateArtist(selectedId, name, country, year);
                    IniEditArtist();
                    txtArtistName.Text = "";
                    IniDDL();
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            }
            else {
                lblMessages.Text = "Select Artist";
            }          
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }

    }
}