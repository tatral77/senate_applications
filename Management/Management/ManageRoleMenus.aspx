<%@ Page Title="" Language="C#" MasterPageFile="~/Application.master" AutoEventWireup="true" CodeBehind="ManageRoleMenus.aspx.cs" Inherits="Management.ManageRoleMenus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-12 page-header">
                <label class="page-title" id="heading1" runat="server"></label>
            </div>
          
          
        </div>
      <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" ID="a" for="AllMenusLB" >Available Menus:</asp:Label>
                <asp:ListBox ID="AllMenusLB" class="form-control" runat="server" style="height:250px" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-md-6">
                
                        <table class="table table-condensed">
                          
                             <tr>
                                <td style="width:60px;padding-top:100px;">
                                    <asp:LinkButton class="btn btn-success form-control" ID="In" runat="server" style="width:50px;margin-bottom:10px;" OnClick="In_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-success form-control" ID="Out" runat="server" Text="<<" style="width:50px" OnClick="Out_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td >
                                    <asp:Label runat="server" ID="Label1" for="RolMenuesLB" >Role Menus:</asp:Label>
                                    <asp:ListBox style="height:250px" ID="RolMenuesLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
         </div>
</div>

</asp:Content>
