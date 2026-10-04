<%@ Page Title="" Language="C#" MasterPageFile="~/Application.master" AutoEventWireup="true" CodeBehind="ManageMenuPages.aspx.cs" Inherits="Management.ManageMenuPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
     
    <div class="container-fluid">
         <div class="row ">
            <div class="col-md-12 page-header page-title">
                <label runat="server" id="heading1"></label>
                </div>
          </div>
      <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" ID="a" for="AllPagesLB" >Available Pages:</asp:Label>
                <asp:ListBox ID="AllPagesLB" class="form-control" runat="server" style="height:250px" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-md-6">
                
                        <table class="table table-condensed">
                          
                             <tr>
                                <td style="width:60px;padding-top:100px;">
                                    <asp:LinkButton class="btn btn-success form-control" ID="In" runat="server" style="width:50px;margin-bottom:10px;" OnClick="In_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-success form-control" ID="Out" runat="server" Text="<<" style="width:50px" OnClick="Out_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td >
                                       <asp:Label runat="server" ID="Label1" for="MenuPagesLB" >Menue Pages:</asp:Label>
                                    <asp:ListBox style="height:250px" ID="MenuPagesLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
         </div>
</div>

</asp:Content>
