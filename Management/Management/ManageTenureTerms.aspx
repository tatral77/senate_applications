<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageTenureTerms.aspx.cs" Inherits="Management.ManageTenureTerms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label runat="server" ID="headinglbl" class="page-header page-title"></label></h4>
            </div>
            <div class="col-md-3 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-success" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Parliamentary Term</th>
                         <th>From</th>
                         <th>To</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidParliamentaryTenureTermsId" runat="server" Value='<%#Bind("ParliamentaryTenureTermId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Description")%>'></asp:Label></td>
                                  <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToDateTime(Eval("FromDate")).ToShortDateString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Convert.ToDateTime(Eval("ToDate")).ToShortDateString()%>'></asp:Label></td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                       <asp:HiddenField ID="HidParliamentaryTenureTermsId" runat="server" Value='<%#Bind("ParliamentaryTenureTermId")%>' />
                                    <asp:HiddenField ID="HidParliamentaryTermId" runat="server" Value='<%#Bind("ParliamentaryTermId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server">Parliamentary Term</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ParliamentaryTermDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                              <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server">Parliamentary Term</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ParliamentaryTermDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </InsertItemTemplate>
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
