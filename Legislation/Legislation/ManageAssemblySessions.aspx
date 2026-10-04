<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="ManageAssemblySessions.aspx.cs" Inherits="QuestionManagement.ManageAssemblySessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">Manage Parliamentary Terms</label></h4>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                      
                        <th>Assembly Session</th>
                        <th>From Date</th>
                        <th>To Date</th>
                          <th>Parliamentary Year</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidParliamentaryTermssId" runat="server" Value='<%#Bind("AssemblySessionsId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("SessionNumber")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("ParliamentaryYear")%>'></asp:Label></td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidParliamentaryYearsId" runat="server" Value='<%#Bind("ParliamentaryYearsId")%>' />
                                      <asp:HiddenField ID="HidAssemblySessionsId" runat="server" Value='<%#Bind("AssemblySessionsId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Parliamentary Period</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="SessionNumberTxt" class="form-control" runat="server" Text='<%#Bind("SessionNumber")%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">From Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="StartDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">To Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="EndDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                           <tr>
                                               <td class="table-data">
                                                <asp:Label runat="server">Parliamentary Year</asp:Label></td>
                                               <td>
                                                   <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control control-txt" runat="server">
                                                       <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>

                    <tr>
                        <td align="left" colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                </table>


            </div>
        </div>
    </div>
</asp:Content>
