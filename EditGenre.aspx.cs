using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class EditGenre : System.Web.UI.Page {
    int selectedId = 0;
    GridViewRow row;
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            IniEditGenre();
        }
    }

    protected void IniEditGenre() {
        gvEditGenre.DataSource = Genre.GetGenres();
        gvEditGenre.DataBind();
    }

    protected void btnBack_ServerClick(object sender, EventArgs e) {
        Response.Redirect("Genres.aspx");
    }

    protected void gvEditGenre_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditGenre.SelectedIndex > -1) {
            try {
                row = gvEditGenre.SelectedRow;
                txtGenreName.Text = row.Cells[1].Text;
                btnAdd.Text = "Add a genre";
                lblMessages.Text = "Genre " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void gvEditGenre_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[2].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 2; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add a genre") {
                txtGenreName.Text = string.Empty;
                btnAdd.Text = "Save new genre";
                lblMessages.Text = "Add a new genre.";
                txtGenreName.Focus();
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            } else if (btnAdd.Text == "Save new genre") {
                if (txtGenreName.Text != string.Empty) {
                    string name = txtGenreName.Text;
                    Genre.AddGenre(name);
                    lblMessages.Text = "Genre " + name + " added to database.";
                    btnAdd.Text = "Add a genre";
                    IniEditGenre();
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
            row = gvEditGenre.SelectedRow;
            selectedId = int.Parse(row.Cells[2].Text);
            if (gvEditGenre.SelectedIndex > -1) {
                if (txtGenreName.Text != string.Empty) {
                    string name = txtGenreName.Text;
                    Genre.UpdateGenre(selectedId, name);
                    lblMessages.Text = "Genre " + name + " updated to database.";
                    txtGenreName.Text = string.Empty;
                    IniEditGenre();
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            } else {
                lblMessages.Text = "Select a genre first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        try {
            row = gvEditGenre.SelectedRow;
            selectedId = int.Parse(row.Cells[2].Text);
            if (gvEditGenre.SelectedIndex > -1) {
                Genre.DeleteGenre(selectedId);
                lblMessages.Text = "Genre deleted from the database.";
                txtGenreName.Text = string.Empty;
                IniEditGenre();
            } else {
                lblMessages.Text = "Select a genre first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }
}