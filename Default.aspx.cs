using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClassesDataContext _Datalayer = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                btnCustBack_Click(sender, e);
        }
        catch( Exception ex){lblError.Text = "Error: " + ex.Message;}
    }

    #region CUSTOMER

    protected void btnCustAdd_Click(object sender, EventArgs e) //Add Customer Button
    {
        try
        {
            btnCustBack_Click(sender, e);
            divCust.Visible = true;
            lblCustomer.Text = "Add Customer";
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e) //Edit / Select Customer
    {
        try
        {
            Customer _cust = _Datalayer.Customers.First(c => c.ID.ToString() == gvCustomers.DataKeys[Convert.ToInt32(e.CommandArgument)]["ID"].ToString());
            hidCust.Value = _cust.ID.ToString();

            if (e.CommandName == "EditCustomer")
            {
                divCust.Visible = true;
                txtCustName.Text = _cust.Name;
                txtCustLat.Text = _cust.Latitude;
                txtCustLong.Text = _cust.Longitude;
                lblCustomer.Text = "Edit Customer";
                divContactsArea.Visible = false;
            }
            if (e.CommandName == "SelectCustomer")
            {
                gvContacts.Visible = true;
                btnConBack_Click(sender, e);
                divContactsArea.Visible = true;
            }
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void btnCustSave_Click(object sender, EventArgs e) //Save Customer Button
    {
        try
        {
            Customer _cust;
            if (string.IsNullOrEmpty(hidCust.Value)) //Add new Customer
            {
                _cust = new Customer();
                _Datalayer.Customers.InsertOnSubmit(_cust);
            }
            else _cust = _Datalayer.Customers.First(c => c.ID.ToString() == hidCust.Value); //Update Customer

            _cust.Name = txtCustName.Text;
            _cust.Latitude = txtCustLat.Text;
            _cust.Longitude = txtCustLong.Text;

            _Datalayer.SubmitChanges();
            btnCustBack_Click(sender, e);
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void btnCustBack_Click(object sender, EventArgs e)// Back Button
    {
        try
        {
            hidCust.Value = null;
            txtCustName.Text = "";
            txtCustLat.Text = "";
            txtCustLong.Text = "";
            divCust.Visible = false;
            divContactsArea.Visible = false;
            lblError.Text = "";

            gvCustomers.DataSource = _Datalayer.Customers.OrderBy(c => c.Name).ToList();
            gvCustomers.DataBind();
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    #endregion

    #region CONTACTS

    protected void btnAddCon_Click(object sender, EventArgs e) //Add Contact Button
    {
        try
        {
            btnConBack_Click(sender, e);
            divCon.Visible = true;
            lblContact.Text = "Add Contact";
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void gvContacts_RowCommand(object sender, GridViewCommandEventArgs e) //Edit Contact
    {
        try
        {
            CustomerContact _con = _Datalayer.CustomerContacts.First(c => c.ID.ToString() == gvContacts.DataKeys[Convert.ToInt32(e.CommandArgument)]["ID"].ToString());
            hidCon.Value = _con.ID.ToString();

            if (e.CommandName == "EditCustomer")
            {
                divCon.Visible = true;
                txtConEmail.Text = _con.Email;
                txtConName.Text = _con.Name;
                txtConNo.Text = _con.ContactNumber;
                lblContact.Text = "Edit Contact";
            }
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void btnConSave_Click(object sender, EventArgs e) //Save Contact Button
    {
        try
        {
            CustomerContact _con;
            if (string.IsNullOrEmpty(hidCon.Value)) //Add new Contact
            {
                _con = new CustomerContact();
                _Datalayer.CustomerContacts.InsertOnSubmit(_con);
            }
            else _con = _Datalayer.CustomerContacts.First(c => c.ID.ToString() == hidCon.Value); //Update Contacts

            _con.CustomerID = Convert.ToInt32(hidCust.Value);
            _con.Name = txtConName.Text;
            _con.ContactNumber = txtConNo.Text;
            _con.Email = txtConEmail.Text;

            _Datalayer.SubmitChanges();
            btnConBack_Click(sender, e);
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    protected void btnConBack_Click(object sender, EventArgs e) //Back Button
    {
        try
        {
            hidCon.Value = null;
            txtConEmail.Text = "";
            txtConName.Text = "";
            txtConNo.Text = "";
            divCon.Visible = false;
            lblError.Text = "";

            //There is no need for a stored procedure in this scenario, but here is one as requested
            gvContacts.DataSource = _Datalayer._sp_Contacts(Convert.ToInt32(hidCust.Value)).ToList();
            gvContacts.DataBind();
        }
        catch (Exception ex) { lblError.Text = "Error: " + ex.Message; }
    }

    #endregion 
}