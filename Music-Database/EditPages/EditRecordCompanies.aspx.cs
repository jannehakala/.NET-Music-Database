using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class EditRecordCompanies : System.Web.UI.Page {
    int selectedId = 0;
    GridViewRow row;
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            IniEditRecordCompanies();
            IniDDL();
        }
    }

    protected void IniEditRecordCompanies() {
        gvEditRecordCompanies.DataSource = Company.GetCompanies().DefaultView;
        gvEditRecordCompanies.DataBind();
        gvEditRecordCompanies.SelectedIndex = -1;
    }

    protected void IniDDL() {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectCountry.DataSource = Users.GetComboBoxCountries();
        ddlSelectCountry.DataBind();
        ddlSelectCountry.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        txtCompanyName.Text = string.Empty;
        ddlSelectCountry.SelectedIndex = 0;
        ddlSelectYear.SelectedIndex = 0;
    }


    protected void gvEditRecordCompanies_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditRecordCompanies.SelectedIndex > -1) {
            try {
                row = gvEditRecordCompanies.SelectedRow;
                txtCompanyName.Text = row.Cells[1].Text;
                ddlSelectCountry.Text = row.Cells[2].Text;
                ddlSelectYear.Text = row.Cells[3].Text;
                btnAdd.Text = "Add a company";
                lblMessages.Text = "Company " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add a company") {
                txtCompanyName.Text = string.Empty;
                btnAdd.Text = "Save new company";
                lblMessages.Text = "Add a new company.";
                txtCompanyName.Focus();
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                IniDDL();
            } else if (btnAdd.Text == "Save new company") {
                if (txtCompanyName.Text != string.Empty && ddlSelectYear.SelectedIndex > 0 
                    && ddlSelectCountry.SelectedIndex > 0) {
                    string name = txtCompanyName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Company.AddCompany(name, country, year);
                    lblMessages.Text = "Company " + name + " added to database.";
                    btnAdd.Text = "Add a company";
                    IniEditRecordCompanies();
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

    protected void btnSave_Click(object sender, EventArgs e) {
        try {
            row = gvEditRecordCompanies.SelectedRow;
            selectedId = int.Parse(row.Cells[4].Text);
            if (gvEditRecordCompanies.SelectedIndex > -1) {
                if (txtCompanyName.Text != string.Empty && ddlSelectYear.SelectedIndex > 0
                    && ddlSelectCountry.SelectedIndex > 0) {
                    string name = txtCompanyName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string country = ddlSelectCountry.Text;
                    Company.UpdateCompany(selectedId, name, country, year);
                    lblMessages.Text = "Company " + name + " updated to database.";
                    txtCompanyName.Text = string.Empty;
                    IniEditRecordCompanies();
                    IniDDL();
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            } else {
                lblMessages.Text = "Select a company first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        try {
            row = gvEditRecordCompanies.SelectedRow;
            selectedId = int.Parse(row.Cells[4].Text);
            if (gvEditRecordCompanies.SelectedIndex > -1) {
                Company.DeleteCompany(selectedId);
                lblMessages.Text = "Company deleted from the database.";
                txtCompanyName.Text = string.Empty;
                IniEditRecordCompanies();
                IniDDL();
            } else {
                lblMessages.Text = "Select a company first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void gvEditRecordCompanies_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[4].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 4; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnBack_ServerClick(object sender, EventArgs e) {
        Response.Redirect("~/RecordCompanies.aspx");
    }
}