<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MemberLeaveRequest.aspx.cs" Inherits="Notice.MemberLeaveRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="text-align: left">
                <h4>
                    <label runat="server" id="heading">MEMBERS LEAVES</label></h4>
            </div>
            <%-- <div class="col-md-6" style="text-align:right">
                <asp:Button runat="server" Cssclass="btn btn-custom" ID="SaveBtn" Text="Save" OnClick="SaveBtn_Click" />
            </div>--%>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Member Name</th>
                        <th>Submission Date</th>
                        <th>Session Number</th>
                        <th>Approval Date</th>
                        <th>Is Session Leave</th>
                        <th>Purpose</th>
                        <th>Leave Type</th>
                        <th>Start Date</th>
                        <th>End date</th>
                        <th>Notice Comments</th>
                        <th>Action</th>


                    </tr>
                    <asp:ListView ID="LeavesLV"
                        OnItemEditing="LeavesLV_ItemEditing"
                        OnItemCreated="LeavesLV_ItemCreated"
                        OnItemDataBound="LeavesLV_ItemDataBound"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="LeavesLV_ItemUpdating"
                        runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidLeaveApplicationId" runat="server" Value='<%#Bind("LeaveApplicationId")%>' />
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SubmissionDate")))%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("SessionNumber")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label8" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ApprovalDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Convert.ToInt32(Eval("IsSessionLeave"))==1?"Yes":"No"%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("Purpose")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("LeaveType")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("NoticeComments")%>'></asp:Label></td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" AlternateText="edit" CommandName="edit"
                                        ImageUrl="~/images/edit.png" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%--  <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td colspan="10">
                                    <asp:HiddenField ID="HidLeaveApplicationId" runat="server" Value='<%#Bind("LeaveApplicationId")%>' />
                                    <asp:HiddenField ID="HidLeaveTypeId" runat="server" Value='<%#Bind("LeaveTypeId")%>' />
                                    <asp:HiddenField ID="HidIsSessionLeave" runat="server" Value='<%#Bind("IsSessionLeave")%>' />

                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>Member Name:</td>
                                            <td>
                                                <asp:Label ID="CourseNameTxt" class="form-control" runat="server" Text='<%#Bind("MemberName")%>'></asp:Label>
                                        </tr>
                                        <tr>
                                            <td>Submission Date:</td>
                                            <td>
                                                <asp:Label ID="Label9" class="form-control" runat="server" Text='<%#Bind("SubmissionDate")%>'></asp:Label>
                                        </tr>
                                         <tr>
                                            <td>Session Number:</td>
                                            <td>
                                                <asp:Label ID="Label12" class="form-control" runat="server" Text='<%#Bind("SessionNumber")%>'></asp:Label>
                                        </tr>
                                        <tr>
                                            <td class="table-data">Is Session Leave</td>
                                            <td>
                                                   <asp:Label ID="Label3" CssClass="form-control" runat="server" Text='<%#Convert.ToInt32(Eval("IsSessionLeave"))==1?"Yes":"No"%>'></asp:Label></td>
                                             <%--   <asp:CheckBox Enabled="false" CssClass="form-control" ID="IsSessionCB" runat="server" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Purpose</td>
                                            <td>
                                                <asp:Label ID="Purposelbl" class="form-control" runat="server" Text='<%#Bind("Purpose")%>'></asp:Label>
                                        </tr>
                                        <tr>
                                            <td>Leave Type:</td>
                                            <td>
                                                <asp:Label ID="InstitutionNameTxt" class="form-control" runat="server" Text='<%#Bind("LeaveType")%>'></asp:Label>
                                        </tr>
                                      <tr>
                                        <td class="itemLeft">
                                            Start Date:</td>
                                            <td><asp:Label ID="Label6" runat="server" class="form-control" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                         <td class="itemLeft">
                                             End Date:</td>
                                           <td><asp:Label ID="Label13" runat="server" class="form-control" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:Label></td>
                                        </tr>
                                            <tr>
                                                <td>Notice Comments</td>
                                                <td>
                                                    <asp:TextBox ID="NoticeCommentsTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("NoticeComments")%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Approval date</td>
                                                <td>
                                                    <asp:TextBox ID="ApprovalDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ApprovalDate")))%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdTxtLeft">Action:</td>
                                                <td class="altLeft">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" AlternateText="cancel" CommandName="cancel"
                                                        ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" AlternateText="update" CommandName="update"
                                                        ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                </td>
                                            </tr>
                                    </table>
                                </td>
                            </tr>
                        </EditItemTemplate>
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
