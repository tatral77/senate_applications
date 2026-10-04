<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResolutionSummary.aspx.cs" Inherits="QuestionManagement.ResolutionSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <div class="container">
        <h4 class="page-header">Resolutions Summary</h4>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label3" runat="server" Text="From Session" for="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control" runat="server" >
                   
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                 <asp:Label ID="Label4" runat="server" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control" runat="server">
                 
                </asp:DropDownList>
            </div>
              <div class="col-md-2" style="padding-top:20px">
              <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="View Summary" onclick="Search_Click" />
            </div>
        </div>
        <table class="table">
            <tr>
                <td style="font-size: 12pt;font-weight:bold"><asp:Label  ID="TotalLabelLbl" Visible="false" runat="server" Text="Received Resolutions"></asp:Label></td>
                <td Style="font-size: 12pt;text-align:right;font-weight:bold">
                    <asp:Label  ID="TotalQuestionsLbl" runat="server"></asp:Label></td>

            </tr>

            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Style="font-size: 12pt;" ID="Label1" runat="server" Text='<%#Eval("Category") %>'></asp:Label>

                        </td>
                        <td Style="font-size: 12pt; text-align:right;">

                            <asp:Label ID="Label2"  runat="server" Text='<%#Eval("ProductCount") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>


            </asp:ListView>
        </table>
    </div>
</asp:Content>
