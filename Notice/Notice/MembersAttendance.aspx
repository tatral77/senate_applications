<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MembersAttendance.aspx.cs" Inherits="Notice.MembersAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="text-align:left">
                 <h4>
                    <label runat="server" id="heading">MEMBERS ATTENDANCE</label></h4>
            </div>
            <div class="col-md-6" style="text-align:right">
                <asp:Button runat="server" Cssclass="btn btn-custom" ID="SaveBtn" Text="Save" OnClick="SaveBtn_Click" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Member Name</th>
                        <th>Attendance</th>
     
                    </tr>
                    <asp:ListView ID="ListView1" 
                        OnItemCreated="ItemCreated"
                        OnItemDataBound="ItemDataBound"
                     
                        runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidMemberId" runat="server" Value='<%#Bind("MemberId")%>' />
                                <asp:HiddenField ID="HidAttendanceStatusId" runat="server" Value='<%#Bind("AttendanceStatusId")%>' />
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt"  runat="server" Text='<%#Eval("MemberName")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:DropDownList CssClass="form-control" ID="AttendanceDDL"  runat="server">

                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
