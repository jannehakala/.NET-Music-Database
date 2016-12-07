using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicDatabase;

public partial class EditTracks : System.Web.UI.Page {
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
            IniEditTracks();
            IniDDL();
        }
        Session["currentpage"] = "Edit";
    }

    protected void IniEditTracks() {
        gvEditTracks.DataSource = Track.GetTracks().DefaultView;
        gvEditTracks.DataBind();
        gvEditTracks.SelectedIndex = -1;
    }

    protected void IniDDL() {
        ddlSelectYear.DataSource = Users.GetComboBoxYears();
        ddlSelectYear.DataBind();
        ddlSelectYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectAlbum.DataSource = Album.GetComboBoxAlbums();
        ddlSelectAlbum.DataBind();
        ddlSelectAlbum.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectArtist.DataSource = Artist.GetComboBoxArtists();
        ddlSelectArtist.DataBind();
        ddlSelectArtist.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlSelectGenre.DataSource = Genre.GetComboBoxGenres();
        ddlSelectGenre.DataBind();
        ddlSelectGenre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        txtTrackName.Text = string.Empty;
        txtNumber.Text = string.Empty;
        txtLength.Text = string.Empty;
        txtTubeLink.Text = string.Empty;
        ddlSelectAlbum.SelectedIndex = 0;
        ddlSelectYear.SelectedIndex = 0;
        ddlSelectArtist.SelectedIndex = 0;
        ddlSelectGenre.SelectedIndex = 0;
    }


    protected void btnBack_ServerClick(object sender, EventArgs e) {
        Response.Redirect("~/Tracks.aspx");
    }

    protected void gvEditTracks_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditTracks.SelectedIndex > -1) {
            try {
                row = gvEditTracks.SelectedRow;
                txtTrackName.Text = row.Cells[1].Text;
                ddlSelectArtist.Text = row.Cells[2].Text;
                ddlSelectAlbum.Text = row.Cells[3].Text;
                ddlSelectYear.Text = row.Cells[4].Text;
                txtTubeLink.Text = "https://www.youtube.com/watch?v=" + row.Cells[5].Text;
                txtNumber.Text = row.Cells[6].Text;
                txtLength.Text = row.Cells[7].Text;
                ddlSelectGenre.Text = row.Cells[8].Text;

                btnAdd.Text = "Add a track";
                lblMessages.Text = "Track " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void gvEditTracks_RowDataBound(object sender, GridViewRowEventArgs e) {
        for (int i = 5; i < 10; i++) {
            e.Row.Cells[i].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 5; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add a track") {
      
                btnAdd.Text = "Save new track";
                lblMessages.Text = "Add a new track.";
                txtTrackName.Focus();
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                IniDDL();
            } else if (btnAdd.Text == "Save new track") {
                if (txtTrackName.Text != string.Empty && ddlSelectYear.SelectedIndex > 0 &&
                    ddlSelectArtist.SelectedIndex > 0 && ddlSelectAlbum.SelectedIndex > 0 &&
                    ddlSelectGenre.SelectedIndex > 0 && txtTubeLink.Text != string.Empty &&
                    txtNumber.Text != string.Empty && txtLength.Text != string.Empty) {
                    string name = txtTrackName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string artist = ddlSelectArtist.Text;
                    string genre = ddlSelectGenre.Text;
                    string album = ddlSelectAlbum.Text;
                    string link = txtTubeLink.Text;
                    string linkParsed = link.Substring(link.LastIndexOf('=') + 1);
                    int number = int.Parse(txtNumber.Text);
                    string length = txtLength.Text;
                    Track.AddTrack(name, artist, year, album, genre, linkParsed, number, length);
                    lblMessages.Text = "Track " + name + " added to database.";
                    btnAdd.Text = "Add a track";
                    IniEditTracks();
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
            row = gvEditTracks.SelectedRow;
            selectedId = int.Parse(row.Cells[9].Text);
            if (gvEditTracks.SelectedIndex > -1) {
                if (txtTrackName.Text != string.Empty && ddlSelectYear.SelectedIndex > 0 && 
                    ddlSelectArtist.SelectedIndex > 0 && ddlSelectAlbum.SelectedIndex > 0 && 
                    ddlSelectGenre.SelectedIndex > 0 && txtTubeLink.Text != string.Empty &&
                    txtNumber.Text != string.Empty && txtLength.Text != string.Empty) {
                    string name = txtTrackName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string artist = ddlSelectArtist.Text;
                    string genre = ddlSelectGenre.Text;
                    string album = ddlSelectAlbum.Text;
                    string link = txtTubeLink.Text;
                    string linkParsed = link.Substring(link.LastIndexOf('=') + 1);
                    int number = int.Parse(txtNumber.Text);
                    string length = txtLength.Text;
                    Track.UpdateTrack(selectedId, name, artist, year, album, linkParsed, number, length, genre);
                    lblMessages.Text = "Track " + name + " updated to database.";
                    IniEditTracks();
                    IniDDL();
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
            row = gvEditTracks.SelectedRow;
            selectedId = int.Parse(row.Cells[9].Text);
            if (gvEditTracks.SelectedIndex > -1) {
                Track.DeleteTrack(selectedId);
                lblMessages.Text = "Track deleted from the database.";
                IniEditTracks();
                IniDDL();
            } else {
                lblMessages.Text = "Select a track first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }
}