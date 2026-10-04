<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageLog.aspx.cs" Inherits="Administration.Admin.ManageLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h4>
                    <label class="page-header">LOG</label></h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Log Date</th>
                        <th>Log Details</th>
                        <th>Log Table</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="LogLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                <asp:HiddenField ID="HidLogId" runat="server" Value='<%#Bind("LogId")%>' />
                                 <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Bind("LogDate")%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("Details")%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("LogTable")%> '></asp:Label></td>
                            </tr>
                        </ItemTemplate>

                        
                    </asp:ListView>

                  
                </table>


            </div>
        </div>
    </div>
</asp:Content>
