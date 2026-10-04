<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="Budget.Branches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h4 class="page-header">Branches</h4>
          
        </div>

        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Branch</th>

                        </tr>
                    </thead>
                    <asp:ListView ID="BillLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label style="color:#000;font-size:12px;" ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink style="color:#000;font-size:12px;" ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%#Eval("Branchid","~/ManageBranchHeads.aspx?BID={0}")%>'><%#Eval("Description")%></asp:HyperLink>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
</asp:Content>
