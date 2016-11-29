using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HandleValidationError : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        Response.AddHeader("REFRESH", "3.5;URL=Home.aspx");
    }
}