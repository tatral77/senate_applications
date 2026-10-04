<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageGroups.aspx.cs" Inherits="QuestionManagement.ManageGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container container-fluid">
        <h3 class="page-header">Manage Groups</h3>
        <div class="row">
            <div class="col-md-12">
                <span class="page-header" style="font-weight:bold">Session No:</span>
                <asp:DropDownList ID="SessionDDL" class="form-control" runat="server" style="font-weight:bold" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <span class="page-header" style="font-weight:bold">Available Divisions:</span>
                <asp:ListBox ID="DivisionsCB" class="form-control" runat="server" style="height:650px" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-md-6">
                


                <div class="row">

                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tr>
                                <td colspan="2" >
                                      <span class="page-header" style="font-weight:bold">GROUP-1</span>
                                </td>
                                 </tr>
                             <tr>
                                <td style="width:60px">
                                    <asp:LinkButton class="btn btn-primary form-control" ID="OneIn" runat="server" style="width:50px" OnClick="OneIn_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-primary form-control" ID="OneOut" runat="server" Text="<<" style="width:50px" OnClick="OneOut_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ListBox ID="GroupOneLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
                    </div>


                <div class="row">

                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tr>
                                <td colspan="2" >
                                      <span class="page-header" style="font-weight:bold">GROUP-2</span>
                                </td>
                                 </tr>
                             <tr>
                                <td style="width:60px">
                                    <asp:LinkButton class="btn btn-primary form-control" ID="TwoIn" runat="server" style="width:50px" OnClick="TwoIn_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-primary form-control" ID="TwoOut" runat="server" Text="<<" style="width:50px" OnClick="TwoOut_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ListBox ID="GroupTwoLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
                    </div>


                <div class="row">

                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tr>
                                <td colspan="2" >
                                      <span class="page-header" style="font-weight:bold">GROUP-3</span>
                                </td>
                                 </tr>
                             <tr>
                                <td style="width:60px">
                                    <asp:LinkButton class="btn btn-primary form-control" ID="ThreeIn" runat="server" style="width:50px" OnClick="ThreeIn_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-primary form-control" ID="ThreeOut" runat="server" Text="<<" style="width:50px" OnClick="ThreeOut_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ListBox ID="GroupThreeLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
                    </div>


                <div class="row">

                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tr>
                                <td colspan="2" >
                                      <span class="page-header" style="font-weight:bold">GROUP-4</span>
                                </td>
                                 </tr>
                             <tr>
                                <td style="width:60px">
                                  <asp:LinkButton class="btn btn-primary form-control" ID="FourIn" runat="server" style="width:50px" OnClick="FourIn_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-primary form-control" ID="FourOut" runat="server" Text="<<" style="width:50px" OnClick="FourOut_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ListBox ID="GroupFourLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
                    </div>
                    

                <div class="row">

                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tr>
                                <td colspan="2" >
                                      <span class="page-header" style="font-weight:bold">GROUP-5</span>
                                </td>
                                 </tr>
                             <tr>
                                <td style="width:60px">
                                    <asp:LinkButton class="btn btn-primary form-control" ID="FiveIn" runat="server" style="width:50px" OnClick="FiveIn_Click" ><span class="glyphicon glyphicon-arrow-right"></span></asp:LinkButton> <br />
                                    <asp:LinkButton class="btn btn-primary form-control" ID="FiveOut" runat="server" Text="<<" style="width:50px" OnClick="FiveOut_Click" ><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:ListBox ID="GroupFiveLB" runat="server" class="form-control"></asp:ListBox>
                                </td>

                             </tr>
                        </table>
                    </div>
                    </div>




              
            </div>
        </div>


    </div>
</asp:Content>
