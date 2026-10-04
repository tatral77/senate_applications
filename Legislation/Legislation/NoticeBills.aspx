<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticeBills.aspx.cs" Inherits="Legislation.NoticeBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Bills received from Notice Office</h3>
            <table class="table table-hover table-striped table-responsive" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>Notice Diary Number</th>
                        <th >Notice Date</th>
                        <th>Bill Title</th>
                         <th>Subject</th>
                        <th>Bill Category</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">

                        <ItemTemplate>
                            <tr style='<%#(Convert.ToInt32(Eval("HouseTypesId"))==1)?"color:red":"color:green"%>'>
                                <td>
                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                            
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("BillsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("BillsId")%>' />
                                </td>
                              
                                <td >
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %>' />
                                </td>
                                  <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black;font-size:10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("BillsId").ToString(),Eval("HouseTypesId").ToString())%>'><%#Eval("BillTitle").ToString()%></asp:HyperLink>
                                </td>
                                  <td>
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Subject")%>' />
                                </td>
                               <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("BillCategories.Description")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
   
    </div>
</asp:Content>
