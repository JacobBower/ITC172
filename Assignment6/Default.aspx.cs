using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    DonationClass d = new DonationClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable table = d.GetDonors();
            DropDownList1.DataSource = table;
            DropDownList1.DataTextField = "PersonLastName";
            DropDownList1.DataValueField = "PersonKey";
            DropDownList1.DataBind();
        }
    }
    protected void btnDonate_Click(object sender, EventArgs e)
    {
        DonationClass d = new DonationClass();
        int personkey = int.Parse(DropDownList1.SelectedValue.ToString());
        d.WriteDonation(personkey, decimal.Parse(TextBox1.Text));
        TextBox1.Text="";
        TextBox1.Focus();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DataTable table = d.GetDonationTotal();
        GridView1.DataSource = table;
        GridView1.DataBind();

    }
}