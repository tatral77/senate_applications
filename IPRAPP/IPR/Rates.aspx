<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rates.aspx.cs" Inherits="IPR.Rates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     .btn-custom
      {
          background-color:#302c2c;
          color:#ffff
      }
    </style>
     <div class="container container-fluid">
        <div class="row page-header">
            <div class="col-md-10">
                <h4>
                    <label id="heading" runat="server"></label></h4>
            </div>
            
            <div class="col-md-2 hideadd">
               
                <label style="font-size:small ;color:forestgreen;font-weight:normal" id="sucess" runat="server"></label>
            </div>
        </div>
        <div class="row">
              <div class="col-md-4">
                  <label id="Label2" >Rate List</label>
                    <asp:dropdownlist ID="RateListDDL" CssClass="form-control" runat="server">
                        <asp:ListItem Value="1">F.1 (10) R-10/2006 Dated 30 December 2006</asp:ListItem>
                    </asp:dropdownlist>
            </div>
            <div class="col-md-7"></div>
            <div class="col-md-1">
                <br />
                 <asp:Button ID="Button1" CssClass="btn btn-custom" runat="server" Text="Save" OnClick="Button1_Click"/>
                 
            </div>
        </div>
            <div class="row" style="margin-top:10px;">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Location</th>
                         <th>CAT-I</th>
                         <th>CAT-II</th>
                         <th>CAT-III</th>
                         <th>CAT-IV</th>
                    </tr>
                    <asp:ListView ID="LocationLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidLocationId" runat="server" Value='<%#Bind("LocationId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                      <asp:Label ID="Label1" runat="server" Text='<%#Bind("LocationName")%>'></asp:Label></td>
                                  <td class="itemLeft">
                                      <asp:TextBox ID="Cat1" Type="number" required="true" CssClass="form-control" runat="server" Text='<%#GetRate(Convert.ToInt32(Eval("LocationId")),1)%>'></asp:TextBox></td>
                                  <td class="itemLeft">
                                      <asp:TextBox ID="Cat2" Type="number" required="true"  CssClass="form-control" runat="server" Text='<%#GetRate(Convert.ToInt32(Eval("LocationId")),2)%>'></asp:TextBox></td>
                                  <td class="itemLeft">
                                      <asp:TextBox ID="Cat3" Type="number" required="true"  CssClass="form-control" runat="server" Text='<%#GetRate(Convert.ToInt32(Eval("LocationId")),3)%>'></asp:TextBox></td>
                                  <td class="itemLeft">
                                      <asp:TextBox ID="Cat4" Type="number" required="true" CssClass="form-control" runat="server" Text='<%#GetRate(Convert.ToInt32(Eval("LocationId")),4)%>'></asp:TextBox></td>
                             
                            </tr>
                        </ItemTemplate>
               
                </asp:ListView>
                     </table>
                

            </div>
        </div>
    </div>
</asp:Content>
