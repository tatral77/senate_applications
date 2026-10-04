<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpDisciplinaryActions.aspx.cs" Inherits="EstablishmentASP.EmpDisciplinaryActions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <label class="page-header page-title">DISCIPLINARY ACTION</label>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" class="btn btn-custom" />

            </div>
        </div>


        <div class="row">
            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Ref-Id</th>
                            <th>Disciplinary Action</th>
                            <th>Date</th>
                            <th>Post</th>
                            <th>BPS</th>
                            <%--<th>From Date</th>
<th>To Date</th>--%>
                            <th>Final Action</th>
                            <th>Date</th>
                            <th style="width:20%">Details</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                    <tr>
                        <td colspan="10">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                    <asp:ListView ID="DisciplinaryActionLV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemCreated="ItemCreated"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemDataBound="ItemDataBound"
                        OnItemUpdating="ItemUpdating"
                        OnItemDeleting="ItemDeleting">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidDisciplinaryActionId" runat="server" Value='<%#Bind("DisciplinaryActionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="HiddenField1" runat="server" Text='<%#Bind("DisciplinaryActionId")%>' /></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("DisciplinaryActionType")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ActionDate"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("POST")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
                                <%-- <td><asp:Label ID="Label5" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label6" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label></td>--%>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("FinalActionType")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FinalActionDate"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("Details") %>'></asp:Label></td>

                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
            <tr>
                <td colspan="10">
                <asp:HiddenField ID="HidDisciplinaryActionId" runat="server" Value='<%#Bind("DisciplinaryActionId")%>' />
                <asp:HiddenField ID="HidDisciplinaryActionTypeId" runat="server" Value='<%#Bind("DisciplinaryActionTypeId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidFinalActionTypeId" runat="server" Value='<%#Bind("FinalActionTypeId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Disciplinary Action</td>
                    <td>
                        <asp:DropDownList ID="DiscipActionDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Disciplinary Action" ControlToValidate="DiscipActionDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="OnDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ActionDate"))) %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="On Date" Display="Dynamic" ControlToValidate="OnDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Display="Dynamic" Operator="DataTypeCheck" Text="*" ControlToValidate="OnDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="False">
                                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action</td>
                    <td>
                        <asp:DropDownList ID="ActionTypeDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Action Taken" ControlToValidate="ActionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="FinalActionDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FinalActionDate"))) %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Details")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
                        <InsertItemTemplate>
            <tr>
                <td colspan="10">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Disciplinary Action</td>
                    <td>
                        <asp:DropDownList ID="DiscipActionDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Disciplinary Action" ControlToValidate="DiscipActionDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="OnDateTxt" class="form-control js-date" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="On Date" ControlToValidate="OnDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" ValidationGroup="Group1" Display="Dynamic" ControlToValidate="OnDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="False">
                                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action</td>
                    <td>
                        <asp:DropDownList ID="ActionTypeDDL" runat="server" class="form-control" AutoPostBack="False"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Action Taken" ControlToValidate="ActionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="FinalActionDateTxt" class="form-control js-date" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>

                    </asp:ListView>


                </table>
            </div>
        </div>


        <div class="row">
            <div class="col-md-10">
                <label class="page-header page-title-Small">PENALTY DETAILS</label>
            </div>
            <div class="col-md-2 page-header" style="text-align: right">
                <asp:Button ID="Button2" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newPenalty_Click" />
            </div>
        </div>
        <div id="Penalty">
            <table class="table table-hover table-striped table-data">
                <thead style="text-align: center">
                    <tr>
                        <th>Sr#</th>
                        <th>Ref-Id</th>
                        <th>Penalty Type</th>
                        <th>Date</th>
                        <th>Details</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>

                    <asp:ListView ID="PenaltyLV" runat="server"
                        OnItemCreated="Penalty_ItemCreated"
                        OnItemInserting="Penalty_ItemInserting"
                        OnItemEditing="Penalty_ItemEditing"
                        OnItemDataBound="Penalty_ItemDataBound"
                        OnItemDeleting="Penalty_ItemDeleting"
                        OnItemCanceling="Penalty_ItemCanceling"
                        OnItemUpdating="Penalty_ItemUpdating">


                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidPenaltyId" runat="server" Value='<%#Bind("PenaltyId") %>' />
                                    <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td>
                                    <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("DisciplinaryActionId") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("PenaltyType")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PenaltyDate")))%>' />
                                </td>
                                <%-- <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PenaltyTo")))%>' />
                        </td>--%>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                                </td>


                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>

                            </tr>
                        </ItemTemplate>


                        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Penalty Type</td>
                    <td>
                        <asp:DropDownList ID="PenaltyTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Penalty Date</td>
                    <td>
                        <asp:TextBox ID="PenaltyDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Penalty Date" ControlToValidate="PenaltyDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PenaltyDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='' Height="121px" TextMode="MultiLine" Width="333px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>
                        <EditItemTemplate>
            <tr>
                <td colspan="6">
                <asp:HiddenField ID="HidPenaltyId" runat="server" Value='<%#Bind("PenaltyId") %>' />
                <asp:HiddenField ID="HidPenaltyTypeId" runat="server" Value='<%#Bind("PenaltyTypeId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:Label ID="ReferenceIdTxt" runat="server" Text='<%#Bind("DisciplinaryActionId") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Penalty Type</td>
                    <td>
                        <asp:DropDownList ID="PenaltyTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action From</td>
                    <td>
                        <asp:TextBox ID="PenaltyDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PenaltyDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Penalty Date" ControlToValidate="PenaltyDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PenaltyDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Remarks</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Remarks")%>' Height="121px" TextMode="MultiLine" Width="333px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td>
                                    <b>No Final Action details found.</b>

                                </td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>


                    <tr>
                        <td colspan="6">
                            <asp:ValidationSummary ID="ValidationSummary2"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</asp:Content>
