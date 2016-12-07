using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class EditAlbums : System.Web.UI.Page {
    int selectedId = 0;
    GridViewRow row;

    public override void ProcessRequest(HttpContext context) {
        try {
            base.ProcessRequest(context);
        } catch (HttpRequestValidationException ex) {
            context.Response.Redirect("HandleValidationError.aspx");
        }

    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            IniEditAlbums();
            IniDDL();
        }
        Session["currentpage"] = "Edit";
    }

    protected void IniEditAlbums() {
        gvEditAlbums.DataSource = Album.GetAlbums().DefaultView;
        gvEditAlbums.DataBind();
        gvEditAlbums.SelectedIndex = -1;
    }

    protected void IniDDL() {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectArtist.DataSource = Artist.GetComboBoxArtists();
        ddlSelectArtist.DataBind();
        ddlSelectCompany.DataSource = Company.GetComboBoxCompanies();
        ddlSelectCompany.DataBind();
        ddlSelectArtist.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        txtAlbumName.Text = string.Empty;
        ddlSelectArtist.SelectedIndex = 0;
        ddlSelectYear.SelectedIndex = 0;
        ddlSelectCompany.SelectedIndex = 0;
        txtImageLink.Text = string.Empty;
    }

    protected void gvEditAlbums_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditAlbums.SelectedIndex > -1) {
            try {
                row = gvEditAlbums.SelectedRow;
                txtAlbumName.Text = row.Cells[1].Text;
                ddlSelectArtist.Text = row.Cells[2].Text;
                ddlSelectYear.Text = row.Cells[3].Text;
                ddlSelectCompany.Text = row.Cells[4].Text;
                txtImageLink.Text = row.Cells[5].Text;
                btnAdd.Text = "Add an album";
                lblMessages.Text = "Album " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void gvEditAlbums_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 5; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnBack_ServerClick(object sender, EventArgs e) {
        Response.Redirect("~/Albums.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add an album") {
                txtAlbumName.Text = string.Empty;
                btnAdd.Text = "Save new album";
                lblMessages.Text = "Add a new album.";
                txtAlbumName.Focus();
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                IniDDL();
            } else if (btnAdd.Text == "Save new album") {
                if (txtAlbumName.Text != string.Empty && ddlSelectArtist.SelectedIndex > 0 && 
                    ddlSelectYear.SelectedIndex > 0 && ddlSelectCompany.SelectedIndex > 0) {
                    string name = txtAlbumName.Text;
                    string artist = ddlSelectArtist.Text;
                    string company = ddlSelectCompany.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string imglink = txtImageLink.Text;
                    if (imglink == string.Empty) {
                        imglink = "http://student.labranet.jamk.fi/~H3298/empty_cd.png";
                    }
                    
                    Album.AddAlbum(name, artist, company, year, imglink);
                    lblMessages.Text = "Album " + name + " added to database.";
                    btnAdd.Text = "Add an album";
                    IniEditAlbums();
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
            row = gvEditAlbums.SelectedRow;
            selectedId = int.Parse(row.Cells[6].Text);
            if (gvEditAlbums.SelectedIndex > -1) {
                if (txtAlbumName.Text != string.Empty && ddlSelectArtist.SelectedIndex > 0 
                    && ddlSelectYear.SelectedIndex > 0 && ddlSelectCompany.SelectedIndex > 0) {
                    string name = txtAlbumName.Text;
                    string artist = ddlSelectArtist.Text;
                    string company = ddlSelectCompany.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string imglink = txtImageLink.Text;
                    if (imglink == string.Empty) {
                        imglink = "http://student.labranet.jamk.fi/~H3298/empty_cd.png";
                    }

                    Album.UpdateAlbum(selectedId, name, artist, company, year, imglink);
                    lblMessages.Text = "Album " + name + " updated to database.";
                    txtAlbumName.Text = string.Empty;
                    IniEditAlbums();
                    IniDDL();
                } else {
                    lblMessages.Text = "Fill fields first.";
                }
            } else {
                lblMessages.Text = "Select an album first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        try {
            row = gvEditAlbums.SelectedRow;
            selectedId = int.Parse(row.Cells[6].Text);
            if (gvEditAlbums.SelectedIndex > -1) {
                Album.DeleteAlbum(selectedId);
                lblMessages.Text = "Album deleted from the database.";
                txtAlbumName.Text = string.Empty;
                IniEditAlbums();
                IniDDL();
            } else {
                lblMessages.Text = "Select an album first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }
}