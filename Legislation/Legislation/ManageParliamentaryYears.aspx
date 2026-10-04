<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageParliamentaryYears.aspx.cs" Inherits="Legislation.ManageParliamentaryYears" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">MANAGE PARLIAMENTARY YEARS</label></h4>
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
                        <th>Parliamentary Years</th>
                        <th>From Date</th>
                        <th>To Date</th>
                        <th>Parliamentary Tenure</th>
                        <th>Active</th>
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

                                <asp:HiddenField ID="HidParliamentaryYearsId" runat="server" Value='<%#Bind("ParliamentaryYearsId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("ParliamentaryYear")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="ParliamentaryTermTxt" runat="server" Text='<%#Bind("ParliamentaryTenure")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
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
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:HiddenField ID="HidParliamentaryYearsId" runat="server" Value='<%#Bind("ParliamentaryYearsId")%>' />
                                                <asp:HiddenField ID="HidParliamentaryTenuresId" runat="server" Value='<%#Bind("ParliamentaryTenuresId")%>' />
                                                <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                                <asp:Label runat="server">Parliamentary Tenure</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ParliamentaryTenureDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="table-data">

                                                <asp:Label runat="server">Parliamentary Year</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ParliamentaryYearTxt" class="form-control" runat="server" Text='<%#Bind("ParliamentaryYear")%>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="Label">From Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Label">To Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>'></asp:TextBox></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>

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
                        <InsertItemTemplate>

                            <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Parliamentary Tenure</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ParliamentaryTenureDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="0">SELECT</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Parliamentary Year</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ParliamentaryYearTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">From Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">To Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                        <tr>

                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>

                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>

                                        <tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
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
