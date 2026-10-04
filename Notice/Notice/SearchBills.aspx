<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchBills.aspx.cs" Inherits="Notice.SearchBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Panel ID="FilterPanel" runat="server" DefaultButton="SearchBtn" CssClass="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH BILLS</span>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="KeywordTxt">Keyword (title or subject)</label>
                    <asp:TextBox ID="KeywordTxt" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="BillCategoryDDL">Bill Category</label>
                    <asp:DropDownList ID="BillCategoryDDL" runat="server" CssClass="form-control small-control"></asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="DateFromTxt">From Notice Date</label>
                    <asp:TextBox ID="DateFromTxt" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="DateToTxt">To Notice Date</label>
                    <asp:TextBox ID="DateToTxt" runat="server" CssClass="form-control small-control" />
                </div>
            </div>
            <asp:Label ID="FilterError" runat="server" CssClass="nf-err" Text=""></asp:Label>
            <div class="qs-actions">
                <asp:Button ID="SearchBtn" runat="server" CssClass="btn btn-custom" Text="Search" OnClick="Search_Click" />
                <asp:Button ID="ResetBtn" runat="server" CssClass="btn btn-default" Text="Reset" OnClick="Reset_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>

    <div class="container-fluid qs-results">
        <p class="nm-count"><asp:Label ID="CountLbl" runat="server" Text=""></asp:Label></p>
        <table class="table table-hover table-striped table-responsive qs-table" style="border-collapse: collapse;">
            <thead class="thead-inverse">
                <tr>
                    <th class="m-hide">Sr#</th>
                    <th>Notice Diary Number</th>
                    <th>Notice Date</th>
                    <th>Bill Title</th>
                    <th>Subject</th>
                    <th>Bill Category</th>
                    <th class="m-hide">Origin</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <tr style='<%#(Convert.ToInt32(Eval("HouseTypesId"))==1)?"color:red":"color:green"%>'>
                            <td class="m-hide">
                                <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("BillsId")%>' />
                                <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("BillsId")%>' />
                            </td>
                            <td>
                                <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %>' />
                            </td>
                            <td class="m-block qs-justify">
                                <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black; font-size: 10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("BillsId").ToString(),Eval("HouseTypesId").ToString())%>'><%#Eval("BillTitle").ToString()%></asp:HyperLink>
                            </td>
                            <td class="m-block qs-justify">
                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Subject")%>' />
                            </td>
                            <td>
                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("BillCategories.Description")%>' />
                            </td>
                            <td class="m-hide">
                                <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("DeviceId"))==1?"Web":"Mobile"%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
        </table>
    </div>
</asp:Content>
