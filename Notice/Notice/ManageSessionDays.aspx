<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSessionDays.aspx.cs" Inherits="Notice.ManageSessionDays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-4">
                <h4>
                    <label>SESSION SITTINGS</label></h4>
            </div>
            <div class="col-md-1">
                <label>Session</label>
            </div>
            <div class="col-md-5">
                <asp:DropDownList ID="SessionDDL" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" Cssclass="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                       
                        <th>Assembly Sessions</th>
                        <th>Sitting Date</th>
                        <th>Start Time</th>
                        <th>End Time</th>
                        <th>Prorogued</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidSessionSittingsId" runat="server" Value='<%#Bind("SessionSittingsId")%>' />
                                 <td class="itemLeft">
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Eval("AssemblySession")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Convert.ToDateTime(Eval("SittingDate")).ToShortDateString()%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Convert.ToDateTime(Eval("StartTime")).ToShortTimeString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Convert.ToDateTime(Eval("EndTime")).ToShortTimeString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#(Convert.ToInt32(Eval("IsAdjourned"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" Cssclass="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton OnClick="MarkAttendanceBtn_Click" ID="MarkAttendanceBtn" Cssclass="btn btn-custom" runat="server" Text="Attendance" CommandArgument='<%#Eval("SessionSittingsId")%>'></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" Cssclass="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                         <asp:HiddenField ID="HidSessionSittingsId" runat="server" Value='<%#Bind("SessionSittingsId")%>' />
                                        <asp:HiddenField ID="HidIsAdjourned" runat="server" Value='<%#Bind("IsAdjourned")%>' />
                                        <asp:HiddenField ID="HidAssembliesSessionId" runat="server" Value='<%#Bind("AssembliesSessionId")%>' />
                                        
                                          <tr>
                                            <td class="table-data">Session</td>
                                            <td>
                                                <asp:DropDownList ID="SessionDDL" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">Adjourned</td>
                                            <td>
                                                <asp:CheckBox class="form-control" ID="IsAdjournedCB" runat="server" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Sitting Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="SittingDateTxt" class="form-control js-date" Text='<%#Convert.ToDateTime(Eval("SittingDate")).ToShortDateString() %>' runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Start Time</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="StartTimeTxt" class="form-control" Text='<%#Convert.ToDateTime(Eval("StartTime")).ToShortTimeString() %>' runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">End Time</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="EndTimeTxt" class="form-control" Text='<%#Convert.ToDateTime(Eval("EndTime")).ToShortTimeString() %>' runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" Cssclass="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton Cssclass="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                         <tr>
                                            <td class="table-data">Session</td>
                                            <td>
                                                <asp:DropDownList ID="SessionDDL" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">Adjourned</td>
                                            <td>
                                                <asp:CheckBox class="form-control" ID="IsAdjournedCB" runat="server" />
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Sitting Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="SittingDateTxt" class="form-control js-date"  runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Start Time</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="StartTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">End Time</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="EndTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" Cssclass="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton Cssclass="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </InsertItemTemplate>
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
