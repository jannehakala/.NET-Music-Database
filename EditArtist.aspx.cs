using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;
using System.Data;

public partial class EditArtist : System.Web.UI.Page {
    int selectedId = 0;
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
        gvEditArtist.SelectedIndex = -1;
    }

    protected void IniDDL() {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectCountry.DataSource = Users.GetComboBoxCountries();
        ddlSelectCountry.DataBind();
        ddlSelectCountry.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        txtArtistName.Text = string.Empty;
        ddlSelectCountry.SelectedIndex = 0;
        ddlSelectYear.SelectedIndex = 0;
    }


    protected void gvEditArtist_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditArtist.SelectedIndex > -1) {
            try {
                row = gvEditArtist.SelectedRow;
                txtArtistName.Text = row.Cells[1].Text;
                ddlSelectYear.Text = row.Cells[2].Text;
                ddlSelectCountry.Text = row.Cells[3].Text;
                btnAdd.Text = "Add artist";
                lblMessages.Text = "Artist " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add artist") {
                txtArtistName.Text = string.Empty;
                btnAdd.Text = "Save new Artist";
                lblMessages.Text = "Add new artist.";
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                IniDDL();
            } else if (btnAdd.Text == "Save new Artist") {
                if (txtArtistName.Text != string.Empty) {
                    string name = txtArtistName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Artist.AddArtist(name, country, year);
                    lblMessages.Text = "Artist " + name + " added to database.";
                    btnAdd.Text = "Add artist";
                    IniEditArtist();
                    IniDDL();
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
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
            if (gvEditArtist.SelectedIndex > -1) {
                Artist.DeleteArtist(selectedId);
                lblMessages.Text = "Artist deleted from the database.";
                txtArtistName.Text = string.Empty;
                IniEditArtist();
                IniDDL();
            } else {
                lblMessages.Text = "Select artist first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        try {
            row = gvEditArtist.SelectedRow;
            selectedId = int.Parse(row.Cells[4].Text);
            if (gvEditArtist.SelectedIndex > -1) {
                if (txtArtistName.Text != string.Empty) {
                    string name = txtArtistName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Artist.UpdateArtist(selectedId, name, country, year);
                    lblMessages.Text = "Artist " + name + " updated to database.";
                    txtArtistName.Text = string.Empty;
                    IniEditArtist();
                    IniDDL();
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            } else {
                lblMessages.Text = "Select artist first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void gvEditArtist_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[4].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 4; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnBack_ServerClick(object sender, EventArgs e) {
        Response.Redirect("Artists.aspx");
    }
}