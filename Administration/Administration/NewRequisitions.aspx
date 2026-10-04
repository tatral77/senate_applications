<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewRequisitions.aspx.cs" Inherits="Administration.NewRequisitions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <div class="row page-header">
            <div class="col-md-12">

                <h4>
                    <label>NEW REQUESTS</label></h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Employee Name</th>
                        <th>Requisition Id</th>
                        <th>Requisition Date</th>
                        <th>Month/Year</th>
                        <th>Items</th>
                    </tr>
                    <asp:listview id="RequisitionItemsLV" runat="server">
                    <ItemTemplate>
                            <tr>
                                <td class="itemCent">.
                                    <asp:HiddenField ID="HidRequisitionId" runat="server" Value='<%#Bind("RequisitionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td class="itemCent">
                                         <asp:HyperLink class="details-link" ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("RequisitionId","~/ManageRequisitionItems.aspx?Id={0}")%>'><%#Eval("EmployeeName")%></asp:HyperLink>
                                <td class="itemCent">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("RequisitionId")%>' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetLongDate(Convert.ToDateTime(Eval("RequisitionDate")))%>'/>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Eval("ReqMonth") + " / "  + Eval("ReqYear")  %>'></asp:Label></td>
                                   <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Items")%>'></asp:Label></td>
                            </tr>
                    </ItemTemplate>
                    </asp:listview>
                </table>
            </div>
        </div>
        </div>
     
</asp:Content>
