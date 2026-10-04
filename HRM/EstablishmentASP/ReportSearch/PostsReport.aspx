<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="PostsReport.aspx.cs" Inherits="EstablishmentASP.ReportSearch.PostsReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
 <script>
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                    
            });
        });
      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:STUSER3ConnectionStringPosts %>" SelectCommand="SELECT [DESCRIPTION] FROM [POSTS]"></asp:SqlDataSource>
 
    <button id="search" class="btn btn-custom" data-toggle="modal" data-target="#myModal">Search Employee Posts</button>

    <div id="myModal" class="modal fade in"" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <!-- Modal content-->
                      
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Employees Posts</h4>
                            </div>
                            <div class="modal-body">
                                
                                <div class="container-fluid">
                                <div class="row"> 
                                    <div class="col-sm-4">
                                        <label class="control-label" for="Posts">Posts</label>
                                        <asp:DropDownList ID="Posts" class="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="DESCRIPTION">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="PostsTypeTxt">Posts type</label>
                                        <asp:TextBox ID="PostsTypeTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="PostsFromTxt">Posts From</label>
                                        <asp:TextBox ID="PostsFromTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                        <div class="col-sm-4">
                                        <label class="control-label" for="PostsToTxt">Posts To</label>
                                        <asp:TextBox ID="PostsToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    

                                </div> 

                                
                                   
                                  
                            </div>
            </div>
        <div class="modal-footer">
            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Button2_Click"  />
            <button id="Cancel" class="btn btn-custom" data-dismiss="modal">Cancel</button>
           
      </div>
                         </div>
 </div>
 </div>
        


    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="700px" Font-Names="Verdana" Font-Size="8pt" style="margin-left: 100px; margin-top: 20px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="ReportSearch\PostsReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSetPosts" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:STUSER3ConnectionStringPosts %>" SelectCommand="SELECT * FROM [POSTS]"></asp:SqlDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

</asp:Content>
