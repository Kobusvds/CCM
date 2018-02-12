<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Contact Management</title>
    <link href="k2.css" rel="stylesheet" />
</head>
<body class="bg-light-grey">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidCust" runat="server" />
    <asp:HiddenField ID="hidCon" runat="server" />

    <!-- HEADER -->
    <div class="p-3 bg-white s-2">Customer Contact Manager</div>

    <!-- BODY -->
    <div class="container-fluid pt-3" align="center">
        <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red" /><br/>

        <!-- CUSTOMERS -->
        <div class="d-inline-flex flex-row flex-wrap">
            <div class="p-3">

                <!-- CUSTOMERS GRID -->
                <b>Customers</b> 
                <asp:Button ID="btnCustAdd" runat="server" CssClass="btn btn-sm btn-dark ml-2" Text="Add Customer" OnClick="btnCustAdd_Click" />
                <asp:GridView ID="gvCustomers" runat="server" CssClass="tbl s-2 my-3" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvCustomers_RowCommand" 
                    EmptyDataText="No Customers to see here">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:ButtonField CommandName="EditCustomer" Text="Edit" ControlStyle-CssClass="btn-grid a-l" />
                        <asp:ButtonField CommandName="RemoveCustomer" Text="Remove" ControlStyle-CssClass="btn-grid a-l" />
                        <asp:ButtonField CommandName="SelectCustomer" Text="Select" ControlStyle-CssClass="btn-grid a-l" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="p-3">

                <!-- CUSTOMERS FORM -->
                <div id="divCust" runat="server" class="card s-2" visible="false">
                    <div class="card-header"><asp:Label ID="lblCustomer" runat="server" Text="Add Customer" /></div>
                    <div class="card-body a-l">
                        Name
                        <asp:TextBox ID="txtCustName" runat="server" CssClass="form-control form-control-sm s-2 mb-2" />
                        Latituse
                        <asp:TextBox ID="txtCustLat" runat="server" CssClass="form-control form-control-sm s-2 mb-2" />
                        Longitude
                        <asp:TextBox ID="txtCustLong" runat="server" CssClass="form-control form-control-sm s-2" />
                    </div>
                    <div class="card-footer a-r">
                        <asp:Button ID="btnCustSave" runat="server" CssClass="btn btn-sm" Text="Save" OnClick="btnCustSave_Click" />
                        <asp:Button ID="btnCustBack" runat="server" CssClass="btn btn-sm" Text="Back" OnClick="btnCustBack_Click" />
                    </div>
                </div>
            </div>
        </div>
        
        <br />

        <!-- CONTACTS -->
        <div id="divContactsArea" runat="server" class="d-inline-flex flex-row flex-wrap" visible="false">
            <div class="p-3">

                <!-- CONTACTS GRID -->
                <b>Contacts</b>
                <asp:Button ID="btnAddCon" runat="server" CssClass="btn btn-sm btn-dark ml-2" Text="Add Contact" OnClick="btnAddCon_Click" />
                <asp:GridView ID="gvContacts" runat="server" CssClass="tbl s-2 my-3" AutoGenerateColumns="False" DataKeyNames="ID" 
                    EmptyDataText="No Contacts to see here" OnRowCommand="gvContacts_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Number" />
                        <asp:ButtonField CommandName="EditContact" Text="Edit" ControlStyle-CssClass="btn-grid a-l" />
                        <asp:ButtonField CommandName="RemoveContact" Text="Remove" ControlStyle-CssClass="btn-grid a-l" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="p-3">

                <!-- CONTACTS FORM -->
                <div id="divCon" runat="server" class="card s-2" visible="false">
                    <div class="card-header"><asp:Label ID="lblContact" runat="server" Text="Add Contact" /></div>
                    <div class="card-body a-l">
                        Name
                        <asp:TextBox ID="txtConName" runat="server" CssClass="form-control form-control-sm s-2 mb-2" />
                        Email
                        <asp:TextBox ID="txtConEmail" runat="server" CssClass="form-control form-control-sm s-2 mb-2" TextMode="Email" />
                        Contact Number
                        <asp:TextBox ID="txtConNo" runat="server" CssClass="form-control form-control-sm s-2" TextMode="Number" />
                    </div>
                    <div class="card-footer a-r">
                        <asp:Button ID="btnConSave" runat="server" CssClass="btn btn-sm" Text="Save" OnClick="btnConSave_Click" />
                        <asp:Button ID="btnConBack" runat="server" CssClass="btn btn-sm" Text="Back" OnClick="btnConBack_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    </form>
</body>
</html>