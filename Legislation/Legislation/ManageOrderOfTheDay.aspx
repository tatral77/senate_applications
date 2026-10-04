<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageOrderOfTheDay.aspx.cs" Inherits="Legislation.ManageOrderOfTheDay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <div class="row page-header">
            <div class="col-md-4">
                <h4>
                    <label>SESSION SITTINGS</label></h4>
            </div>
            <div class="col-md-1">
                <label>Session</label>
            </div>
            <div class="col-md-5">
                <asp:DropDownList ID="SessionDDL" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" Cssclass="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                       
                        <th>Assembly Sessions</th>
                        <th>Sitting Date</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server">
                       
                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidSessionSittingsId" runat="server" Value='<%#Bind("SessionSittingsId")%>' />
                                 <td class="itemLeft">
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Eval("AssemblySession")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Convert.ToDateTime(Eval("SittingDate")).ToShortDateString()%>'></asp:Label></td>
                               <%--  <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Convert.ToDateTime(Eval("StartTime")).ToShortTimeString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Convert.ToDateTime(Eval("EndTime")).ToShortTimeString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#(Convert.ToInt32(Eval("IsAdjourned"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>--%>
                                <td class="itemCent">
                                  <%--  <asp:LinkButton ID="editImageButton" Cssclass="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                    <asp:LinkButton OnClick="OrderOfTheDayBtn_Click" ID="OrderOfTheDayBtn" Cssclass="btn btn-custom" runat="server" Text="Create Order of The Day" CommandArgument='<%#Eval("SessionSittingsId")%>'></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" Cssclass="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>


            </div>
        </div>
    </div>
</asp:Content>
