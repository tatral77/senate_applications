<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSavings.aspx.cs" Inherits="Administration.ManageSavings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-12 page-header" >
                <h4>Head of Account Savings</h4>
            </div>
            <div class="col-md-7">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                <asp:DropDownList ID="HeadOfAccountDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Head of Account" ValidationGroup="g1" ControlToValidate="HeadOfAccountDDL" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
              <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">Amount</label>
                <asp:TextBox ID="AmountTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Amount" ValidationGroup="g1" ControlToValidate="AmountTxt" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
           
            <div class="col-md-10" style="text-align: right">
                <asp:Button ID="SavingBtn" ValidationGroup="g1" runat="server" CommandName="new" Text="Saving" class="btn btn-success" OnClick="SavingBtn_Click"  />
                <asp:Button ID="SurrenderBtn" ValidationGroup="g1" runat="server" CommandName="new" Text="Surrender" class="btn btn-success" OnClick="SurrenderBtn_Click" />
            </div>
        </div>
          <div class="row">
            <div class="col-md-12">
                <asp:Label ID="error" style="color:red" runat="server" Text=''></asp:Label>
            </div>
        </div>
          <div class="row">
            <div class="col-md-12">
                 <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Amount</th>
                        <th>Saving Date</th>
                    </tr>
                    <asp:ListView ID="SavingLV" runat="server">
                       
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("Amount")%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToDateTime(Eval("SavingDate")).ToShortDateString()%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        </asp:ListView>
                     </table>
            </div>
        </div>
</div>
</asp:Content>
