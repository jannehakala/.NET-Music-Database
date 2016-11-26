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
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            IniEditTracks();
            IniDDL();
        }
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
        Response.Redirect("Tracks.aspx");
    }

    protected void gvEditTracks_SelectedIndexChanged(object sender, EventArgs e) {
        if (gvEditTracks.SelectedIndex > -1) {
            try {
                row = gvEditTracks.SelectedRow;
                txtTrackName.Text = row.Cells[1].Text;
                ddlSelectArtist.Text = row.Cells[2].Text;
                ddlSelectAlbum.Text = row.Cells[3].Text;
                ddlSelectYear.Text = row.Cells[4].Text;
                txtTubeLink.Text = row.Cells[5].Text;
                txtNumber.Text = row.Cells[6].Text;
                txtLength.Text = row.Cells[7].Text;
                ddlSelectGenre.Text = row.Cells[8].Text;
                
                
                
                btnAdd.Text = "Add track";
                lblMessages.Text = "Track " + row.Cells[1].Text + " selected.";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            } catch (Exception ex) {
                lblMessages.Text = ex.Message.ToString();
            }
        }
    }

    protected void gvEditTracks_RowDataBound(object sender, GridViewRowEventArgs e) {
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow) {
            for (int i = 1; i < 5; i++) {
                e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.backgroundColor='#282828';this.style.cursor='default';this.style.textDecoration='none'");
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e) {
        try {
            if (btnAdd.Text == "Add track") {
                txtTrackName.Text = string.Empty;
                btnAdd.Text = "Save new Track";
                lblMessages.Text = "Add a new track.";
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                IniDDL();
            } else if (btnAdd.Text == "Save new Track") {
                if (txtTrackName.Text != string.Empty) {
                    string name = txtTrackName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string artist = ddlSelectArtist.Text;
                    string genre = ddlSelectGenre.Text;
                    string album = ddlSelectAlbum.Text;
                    string link = txtTubeLink.Text;
                    int number = int.Parse(txtNumber.Text);
                    string length = txtLength.Text;
                    Track.AddTrack(name, artist, year, album, genre, link, number, length);
                    lblMessages.Text = "Track " + name + " added to database.";
                    btnAdd.Text = "Add track";
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
                if (txtTrackName.Text != string.Empty) {
                    string name = txtTrackName.Text;
                    int year = int.Parse(ddlSelectYear.Text);
                    string artist = ddlSelectArtist.Text;
                    string genre = ddlSelectGenre.Text;
                    string album = ddlSelectAlbum.Text;
                    string link = txtTubeLink.Text;
                    int number = int.Parse(txtNumber.Text);
                    string length = txtLength.Text;
                    Track.UpdateTrack(selectedId, name, artist, year, album, link, number, length, genre);
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
                lblMessages.Text = "Select track first.";
            }
        } catch (Exception ex) {
            lblMessages.Text = ex.Message.ToString();
        }
    }
}