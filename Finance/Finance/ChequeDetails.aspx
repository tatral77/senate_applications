<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChequeDetails.aspx.cs" Inherits="Finance.ChequeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
      <div class="row">
            <div class="col-md-8">
                <asp:Label ID="header" CssClass="page-header" runat="server"></asp:Label>
            </div>
             <div class="col-md-2">
                 <asp:Button ID="SaveBtn" CssClass="btn btn-success" runat="server" Text="Update Cheque Details" OnClick="SaveBtn_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div Id="err" runat="server" style="color:red;margin-top:10px;"></div>
                  <div Id="success" runat="server" style="color:green;margin-top:10px;"></div>
            </div>
        </div>
        <br /><br />
        
         <div class="row">
            <div class="col-md-12">
                 <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Member Name</th>
                            <th>Salary Category</th>
                             <th>Salary Active</th>
                             <th>Cheque Number</th>
                             <th colspan="2"></th>
                        </tr>
                    </thead>
                   
                    <asp:ListView ID="MembersLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMemberId" runat="server" Value='<%#Bind("MemberId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("MemberSalCategory")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("SalaryStatus"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                               <td>
                                    <asp:TextBox class="form-control" ID="ChequeNoTxt" runat="server" Text='<%#Eval("ChequeNumber")%>'></asp:TextBox>
                                </td>
                               <%--  <td>
                                    <asp:TextBox class="form-control" ID="ChequeDate" runat="server" Text=''></asp:TextBox>
                                </td>--%>
                            </tr>

                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
         </div>
</div>
</asp:Content>
