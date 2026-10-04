<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="EstablishmentASP.ImageUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div id="myModal" class="modal fade in"" role="dialog">
                    <div class="modal-dialog modal-sm">
                        <!-- Modal content-->
                      
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Search Employees</h4>
                            </div>
                            <div class="modal-body">
                             </div>
        <div class="modal-footer">
            <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:Button runat="server" type="button" Text="Save" class="btn btn-default" data-dismiss="modal"></asp:Button>
            <asp:Button class="btn btn-custom" ID="Button3" runat="server" Text="Reset" />
      </div>
                         </div>
 </div>
        
 </div>
    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
</asp:Content>
