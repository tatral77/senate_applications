<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageFundCenteres.aspx.cs" Inherits="Budget.ManageFundCenteres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <label class="page-header page-title">FUND CENTERS</label>
            </div>
           <%-- <div class="col-md-2 page-header" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" class="btn btn-success" />

            </div>--%>
        </div>

        <%--   <div class="row">
           <div class="col-md-4">
               <label style="font-size:small;font-weight:bold">Parliamentary Year</label>
               <asp:DropDownList ID="ParliamentaryYearDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="1">2018-2019</asp:ListItem></asp:DropDownList>
           </div>
            <div class="col-md-4">
                <label style="font-size:small;font-weight:bold">Visits</label>
               <asp:DropDownList ID="VisitsDDL" AutoPostBack="true" OnSelectedIndexChanged="VisitsDDL_SelectedIndexChanged" runat="server" class="form-control">
                   <asp:ListItem  Value="1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Upcoming</asp:ListItem>
                    <asp:ListItem  Value="3">Previous</asp:ListItem>
               </asp:DropDownList>
           </div>
       </div>--%>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Fund Center</th>
                            <th>Allocated Amount</th>
                            <th>Remaining Amount</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                   
                    <asp:ListView ID="LV" runat="server"
                      >
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidFinancialYearId" runat="server" Value='<%#Bind("FundCenterId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#GetLink(Convert.ToInt32(Eval("FundCenterId")))%>'><%#Eval("FundCenter") %></asp:HyperLink>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="HyperLink2" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("FundCenterAmount")))%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Remaining")))%>'></asp:Label>
                                </td>
                                
                                <td>
                                   <%-- <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                   <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>

                        </ItemTemplate>

                      

                    </asp:ListView>


                </table>
            </div>
        </div>

    </div>
</asp:Content>
