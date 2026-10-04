<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmploymentDetails.aspx.cs" Inherits="EstablishmentASP.EmploymentDetails" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">

    <div class="nf-head"><h4>EMPLOYMENT DETAILS</h4></div>
    <div class="container-fluid">
        <div class="pi-card">
            <h5>Service Details</h5>
            <div class="pi-grid">
                <div class="pi-f"><label>Personnel Number</label>
                <asp:TextBox ID="PersonalNoTxt" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="pi-f"><label>File Number</label>
                <asp:TextBox ID="FileNo" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="pi-f"><label>Main Head</label>
                <asp:DropDownList ID="EmpPoolDDL" class="form-control" runat="server">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="pi-f"><label>Appointment Mode</label>
                <asp:DropDownList ID="AppointmentModeDDL" class="form-control" runat="server">
                </asp:DropDownList>
                </div>
                <div class="pi-f"><label>Quota</label>
                <asp:DropDownList ID="QuotaDDL" class="form-control" runat="server">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="pi-f"><label>Govt Service Entry Date</label>
                <asp:TextBox ID="GovtSrvEntry" class="form-control js-date" runat="server"></asp:TextBox>
                </div>
                <div class="pi-f"><label>Employment in Senate</label>
                <asp:TextBox ID="SenEntry" class="form-control js-date" runat="server"></asp:TextBox>
                </div>
                <div class="pi-f"><label>Seniority Number</label>
                <asp:TextBox ID="SeniorityNumber" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="pi-f"><label>Previous Leave Credit</label>
                <asp:TextBox ID="PrevLeaveCreditTxt" required="true" type="number" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="pi-actions">
            <asp:Button ID="Button3" class="btn btn-custom" runat="server" Text="Save" OnClick="Savebtn_Click" />
        </div>

    </div>
    <div class="top-buffer"></div>
    <div class="container-fluid">
        <%-------------------------------------------------------------------------REGULAR EMPLOYMENT--%>

        <div class="col-md-12">
            <div class="regularDiv">
                <div class="sec-head"><h5>REGULAR EMPLOYMENT</h5><asp:Button ID="Button1" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newLinkButton_Click" /></div>
                <div id="regular">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Ref-Id</th>
                                <th>Post</th>
                                <th>BPS</th>
                                <th>Post Status</th>
                                <th>Gazetted</th>
                                <%-- <th>Employment Status</th>--%>
                                <th>Appointment Date</th>
                                <th>Current Status</th>
                                <th>Status Date</th>
                                <th>Is Current</th>
                                  <th>Details</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:ListView ID="RegularEmploymentLV"
                                        OnItemCreated="RegularEmploymentLV_ItemCreated"
                                        OnItemInserting="RegularEmploymentLV_ItemInserting"
                                        OnItemCanceling="RegularEmploymentLV_ItemCanceling"
                                        OnItemEditing="RegularEmploymentLV_ItemEditing"
                                        OnItemDataBound="RegularEmploymentLV_ItemDataBound"
                                        OnItemUpdating="RegularEmploymentLV_ItemUpdating"
                                        OnItemDeleting="RegularEmploymentLV_ItemDeleting"
                                        runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="itemCent">
                                                    <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                                                    <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("BPS")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#Eval("PostStatus")%>' />
                                                </td>
                                                <td>

                                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                                                </td>
                                                <%--  <td>
                           <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("EmploymentStatus")%>' />
                        </td>--%>

                                                <td>
                                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                                                </td>

                                                <td>
                                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("CurrentStatus")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsCurrent"))=="1")?"Yes":"No"%>' />
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label21" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
                                                </td>

                                                <td>
                                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record? WARNING---Probation details related to this employment will also be deleted.');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                                </td>

                                            </tr>
                                        </ItemTemplate>

                                        <EditItemTemplate>
            <tr>
                <td colspan="12">
                <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId") %>' />
                <asp:HiddenField ID="HidBpsId" runat="server" Value='<%#Bind("BpsId") %>' />
                <asp:HiddenField ID="HidPostStatusId" runat="server" Value='<%#Bind("PostStatusId")%>' />
                <asp:HiddenField ID="HidEmploymentStatusId" runat="server" Value='<%#Bind("EmploymentStatusId")%>' />
                <asp:HiddenField ID="HidIsGazetted" runat="server" Value='<%#Bind("IsGazetted") %>' />
                <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsCurrent") %>' />
                <asp:HiddenField ID="HidCurrentStatusId" runat="server" Value='<%#Bind("CurrentStatusId") %>' />
                <asp:HiddenField ID="HidIsCurrent" runat="server" Value='<%#Bind("IsCurrent") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post5" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PostTypeValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="PostStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Gazetted</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="GazettedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Date</td>
                    <td>
                        <asp:TextBox ID="EmploymentDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment Date" ControlToValidate="EmploymentDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status</td>
                    <td>
                        <asp:DropDownList ID="CurrentStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="CurrentStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status Date</td>
                    <td>
                        <asp:TextBox ID="CurrentStatusDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment Date" ControlToValidate="CurrentStatusDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Current</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsCurrentCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" TextMode="MultiLine" runat="server" Text='<%#Eval("Remarks")%>' />
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
                <td colspan="12">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Gazetted</td>
                    <td>
                        <asp:CheckBox ID="IsGazetted" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Appointment Date</td>
                    <td>
                        <asp:TextBox ID="AppointmentDateTxt" ng-model="appointmentdate" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="AppointmentDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="AppointmentDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status</td>
                    <td>
                        <asp:DropDownList ID="CurrentStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" TextMode="MultiLine" runat="server" Text='<%#Eval("Remarks")%>' />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status Date</td>
                    <td>
                        <asp:TextBox ID="CurrentStatusDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Current Status Date" ControlToValidate="CurrentStatusDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="CurrentStatusDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Current</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsCurrentCB" runat="server" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <tr>
                                <td colspan="12">

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







                <%-------------------------------------------------------------------------PROBATION-----------------------------------------------------%>
                <%--<div class="col-md-12">--%>

                <div class="sec-head"><h5>PROBATION DETAILS</h5><asp:Button ID="Button2" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newProbation_Click" /></div>
                <div id="Probation">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Ref-Id</th>
                                <th>Probation Type</th>
                                <th>Probation From</th>
                                <th>Probation To</th>
                                <th>Details</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="ProbationLV" runat="server"
                                OnItemCreated="Probation_ItemCreated"
                                OnItemInserting="Probation_ItemInserting"
                                OnItemEditing="Probation_ItemEditing"
                                OnItemDataBound="Probation_ItemDataBound"
                                OnItemDeleting="Probation_ItemDeleting"
                                OnItemCanceling="Probation_ItemCanceling"
                                OnItemUpdating="Probation_ItemUpdating">


                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:HiddenField ID="HidProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("EmploymentHistId") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ProbationType")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                                        </td>
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
                <td colspan="7">
                <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Probation Type</td>
                    <td>
                        <asp:DropDownList ID="ProbationTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Probation From" ControlToValidate="ProbationFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ProbationFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Probation To" ControlToValidate="ProbationToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ProbationToTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
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
                <td colspan="7">
                <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistId") %>' />
                <asp:HiddenField ID="HidProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                <asp:HiddenField ID="HidProbationTypeId" runat="server" Value='<%#Bind("ProbationTypeId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Probation Type</td>
                    <td>
                        <asp:DropDownList ID="ProbationTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='<%#Bind("EmploymentHistId") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ProbationFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ProbationToTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
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
                                            <b>No probation details found.</b>

                                        </td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>


                            <tr>
                                <td colspan="7">
                                    <asp:ValidationSummary ID="ValidationSummary1"
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




                <%-------------------------------------------------------------------------DEPUTATION OUT / LIEN-----------------------------------------------------%>

                <div class="sec-head"><h5>DEPUTATION OUT / LIEN</h5><asp:Button ID="Button7" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newEmploymentOut_Click" /></div>
                <div id="DeputedOutn">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Employment Out Type</th>
                                <th>From Date</th>
                                <th>From Post</th>
                                <th>To Date</th>
                                <th>To Post</th>
                                <th>Is-Extended</th>
                                <th>Is-Active</th>
                                <th>Details</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="EmploymentOutLV" runat="server"
                                OnItemCreated="EmploymentOut_ItemCreated"
                                OnItemInserting="EmploymentOut_ItemInserting"
                                OnItemEditing="EmploymentOut_ItemEditing"
                                OnItemDataBound="EmploymentOut_ItemDataBound"
                                OnItemDeleting="EmploymentOut_ItemDeleting"
                                OnItemCanceling="EmploymentOut_ItemCanceling"
                                OnItemUpdating="EmploymentOut_ItemUpdating">


                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:HiddenField ID="HidEmploymentOutId" runat="server" Value='<%#Bind("EmploymentOutId") %>' />

                                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("EmploymentOutType")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label18" class="table-data" runat="server" Text='<%#Eval("InPostDesc") + " (" + GetBps(Convert.ToInt32(Eval("InBps"))) + ")" %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" class="table-data" runat="server" Text='<%#Eval("OutPostDesc") + " (" + GetBps(Convert.ToInt32(Eval("OutBps"))) + ")" %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsExtended"))=="1")?"Yes":"No"%>' /></td>
                                        <td>
                                            <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsActive"))=="1")?"Yes":"No"%>' /></td>
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
                <td colspan="10">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Employment Out Type</td>
                    <td>
                        <asp:DropDownList ID="EmploymentTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="EmploymentFromTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment From" ControlToValidate="EmploymentFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Display="Dynamic" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" Type="Date" ValidationGroup="Group1" Display="Dynamic" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Out BPS</td>
                    <td>
                        <asp:DropDownList ID="OutBpsDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Out Post</td>
                    <td>
                        <asp:DropDownList ID="OutPostDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="EmploymentToTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="EmploymentToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment To" ControlToValidate="EmploymentToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Repatriate BPS</td>
                    <td>
                        <asp:DropDownList ID="InBPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Repatriate Post</td>
                    <td>
                        <asp:DropDownList ID="InPOSTDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Extension</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="ExtensionCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Active</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsActiveCB" runat="server" />
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
                <td colspan="10">
                <asp:HiddenField ID="HidEmploymentOutId" runat="server" Value='<%#Bind("EmploymentOutId") %>' />
                <asp:HiddenField ID="HidEmploymentOutTypeId" runat="server" Value='<%#Bind("EmploymentOutTypeId") %>' />
                <asp:HiddenField ID="HidOutBps" runat="server" Value='<%#Bind("OutBps") %>' />
                <asp:HiddenField ID="HidOutPost" runat="server" Value='<%#Bind("OutPost") %>' />
                <asp:HiddenField ID="HidInBps" runat="server" Value='<%#Bind("InBps") %>' />
                <asp:HiddenField ID="HidInPost" runat="server" Value='<%#Bind("InPost") %>' />
                <asp:HiddenField ID="HidIsExtended" runat="server" Value='<%#Bind("IsExtended") %>' />
                <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Employment Out Type</td>
                    <td>
                        <asp:DropDownList ID="EmploymentTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment From</td>
                    <td>
                        <asp:TextBox ID="EmploymentFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="EmploymentFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Display="Dynamic" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" Type="Date" ValidationGroup="Group1" Display="Dynamic" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Out BPS</td>
                    <td>
                        <asp:DropDownList ID="OutBpsDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Out Post</td>
                    <td>
                        <asp:DropDownList ID="OutPostDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment To</td>
                    <td>
                        <asp:TextBox ID="EmploymentToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="EmploymentToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment To" ControlToValidate="EmploymentToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Repatriate BPS</td>
                    <td>
                        <asp:DropDownList ID="InBPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Repatriate Post</td>
                    <td>
                        <asp:DropDownList ID="InPOSTDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Extension</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="ExtensionCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Active</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsActiveCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
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
                                            <b>No Employment Out details found.</b>

                                        </td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>


                            <tr>
                                <td colspan="10">
                                    <asp:ValidationSummary ID="ValidationSummary5"
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





                <div class="sec-head"><h5>RETIREMENT DETAILS</h5><asp:Button ID="Button4" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newEmpRetirement_Click" /></div>
                <div id="Retirement">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Retirement Type</th>
                                <th>Date</th>
                                <th>Retirement Mode</th>
                                <th>Details</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="RetirementLV" runat="server"
                                OnItemCreated="EmpRetirement_ItemCreated"
                                OnItemInserting="EmpRetirement_ItemInserting"
                                OnItemEditing="EmpRetirement_ItemEditing"
                                OnItemDataBound="EmpRetirement_ItemDataBound"
                                OnItemDeleting="EmpRetirement_ItemDeleting"
                                OnItemCanceling="EmpRetirement_ItemCanceling"
                                OnItemUpdating="EmpRetirement_ItemUpdating">


                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:HiddenField ID="HidEmpRetirementId" runat="server" Value='<%#Bind("EmpRetirementId") %>' />

                                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("RetirementType")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RetirementDate")))%>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label12" class="table-data" runat="server" Text='<%#Eval("RetirementMode")%>' /></td>
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
                    <td class="table-data">Retirement Type</td>
                    <td>
                        <asp:DropDownList ID="RetirementTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Retirement Date</td>
                    <td>
                        <asp:TextBox ID="RetirementDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Retirement Date" ControlToValidate="RetirementDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="RetirementDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Retirement Mode</td>
                    <td>
                        <asp:DropDownList ID="RetirementModeDDL" class="form-control" runat="server"> </asp:DropDownList>
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
                <asp:HiddenField ID="HidEmpRetirementId" runat="server" Value='<%#Bind("EmpRetirementId") %>' />
                <asp:HiddenField ID="HidRetirementTypeId" runat="server" Value='<%#Bind("RetirementTypeId") %>' />
                <asp:HiddenField ID="HidRetirementModeId" runat="server" Value='<%#Bind("RetirementModeId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Retirement Type</td>
                    <td>
                        <asp:DropDownList ID="RetirementTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Retirement Date</td>
                    <td>
                        <asp:TextBox ID="RetirementDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RetirementDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Retirement Date" ControlToValidate="RetirementDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="RetirementDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Retirement Mode</td>
                    <td>
                        <asp:DropDownList ID="RetirementModeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Eval("Remarks")%>' Height="121px" TextMode="MultiLine" Width="333px" />
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
                                            <b>No Retirements details found.</b>

                                        </td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>


                            <tr>
                                <td colspan="6">
                                    <asp:ValidationSummary ID="ValidationSummary6"
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
        </div>
    </div>

    <div class="col-md-12">
        <div class="regularDiv">
            <div class="sec-head"><h5>OTHER EMPLOYMENT</h5><asp:Button ID="Button6" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="newOtherEmpl_Click" /></div>
            <table class="table table-hover table-striped table-data">
                <thead style="text-align: center">
                    <tr>
                        <th>Sr#</th>
                        <th>Ref. Id</th>
                        <th>Empl-Type</th>
                        <th>Contract Type</th>
                        <th>Post</th>
                        <th>BPS</th>
                        <th>Post Status</th>
                        <th>Gazetted</th>
                        <th>Empl-From</th>
                        <th>Empl-To</th>
                        <%--  <th>Details</th>--%>
                        <th>Current Status</th>
                        <th>Status Date</th>
                        <th>Details</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>

                    <asp:ListView ID="OtherEmploymentLV"
                        OnItemCreated="OtherEmploymentLV_ItemCreated"
                        OnItemInserting="OtherEmploymentLV_ItemInserting"
                        OnItemCanceling="OtherEmploymentLV_ItemCanceling"
                        OnItemEditing="OtherEmploymentLV_ItemEditing"
                        OnItemDataBound="OtherEmploymentLV_ItemDataBound"
                        OnItemUpdating="OtherEmploymentLV_ItemUpdating"
                        OnItemDeleting="OtherEmploymentLV_ItemDeleting"
                        runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                                    <asp:HiddenField ID="HidEmploymentTypeId" runat="server" Value='<%#Bind("EmploymentStatusId") %>' />
                                    <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label14" class="table-data" runat="server" Text='<%#Eval("EmploymentStatus")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label13" class="table-data" runat="server" Text='<%#Eval("Quota")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("BPS")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#Eval("PostStatus")%>' />
                                </td>
                                <td>

                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                                </td>


                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label15" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                                </td>
                                <%-- <td>
                           <asp:Label ID="Label16" class="table-data" runat="server" Text='<%#Eval("Details")%>' />
                        </td>--%>

                                <td>
                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("CurrentStatus")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label17" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
                                </td>

                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record? WARNING---Probation details related to this employment will also be deleted.');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                </td>

                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
            <tr>
                <td colspan="14">
                <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                <asp:HiddenField ID="HidEmploymentStatusId" runat="server" Value='<%#Bind("EmploymentStatusId") %>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId") %>' />
                <asp:HiddenField ID="HidQuotaId" runat="server" Value='<%#Bind("QuotaId") %>' />
                <asp:HiddenField ID="HidBpsId" runat="server" Value='<%#Bind("BpsId") %>' />
                <asp:HiddenField ID="HidPostStatusId" runat="server" Value='<%#Bind("PostStatusId")%>' />
                <asp:HiddenField ID="HidIsGazetted" runat="server" Value='<%#Bind("IsGazetted") %>' />
                <asp:HiddenField ID="HidCurrentStatusId" runat="server" Value='<%#Bind("CurrentStatusId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Employment Type</td>
                    <td>
                        <asp:DropDownList ID="EmploymentTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post5" ControlToValidate="EmploymentTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Contract Type</td>
                    <td>
                        <asp:DropDownList ID="QuotaDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post5" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PostTypeValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="PostStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Gazetted</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="GazettedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Date</td>
                    <td>
                        <asp:TextBox ID="EmploymentDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment Date" ControlToValidate="EmploymentDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="EmploymentDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator6" Display="Dynamic" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status</td>
                    <td>
                        <asp:DropDownList ID="CurrentStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="CurrentStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status Date</td>
                    <td>
                        <asp:TextBox ID="CurrentStatusDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment Date" ControlToValidate="CurrentStatusDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator7" Display="Dynamic" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="CurrentStatusDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" Display="Dynamic" class="form-control" runat="server" Text='<%#Eval("Remarks")%>' Height="121px" TextMode="MultiLine" Width="333px" />
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
                <td colspan="14">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Employment Type</td>
                    <td>
                        <asp:DropDownList ID="EmploymentTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post5" ControlToValidate="EmploymentTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Contract Type</td>
                    <td>
                        <asp:DropDownList ID="QuotaDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Gazetted</td>
                    <td>
                        <asp:CheckBox ID="IsGazetted" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Employment Date</td>
                    <td>
                        <asp:TextBox ID="AppointmentDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="AppointmentDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator7" Display="Dynamic" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="AppointmentDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator8" Display="Dynamic" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status</td>
                    <td>
                        <asp:DropDownList ID="CurrentStatusDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="CurrentStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Current Status Date</td>
                    <td>
                        <asp:TextBox ID="CurrentStatusDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="CurrentStatusDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator9" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="CurrentStatusDateTxt" Display="Dynamic" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" runat="server" class="form-control" Text='' Height="121px" TextMode="MultiLine" Width="333px" />
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
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="14">
                                    <b>No Other Emloyment details found.</b>

                                </td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>


                    <tr>
                        <td colspan="14">

                            <asp:ValidationSummary ID="ValidationSummary3"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
                        </td>
                    </tr>
                </tbody>
            </table>







            <%-------------------------------------------------------------------------OTHER EMPLOYMENT EXTENSION DETAILS--%>

            <div class="sec-head"><h5>EXTENSION DETAILS</h5><asp:Button ID="newContract" class="btn btn-custom" runat="server" Text="Add New" OnClick="newExtension_Click" /></div>
            <div id="contract">
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref. Id</th>

                            <th>Extended To</th>
                            <th>Details</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="ExtensionLV" runat="server"
                            OnItemCreated="Extension_ItemCreated"
                            OnItemInserting="Extension_ItemInserting"
                            OnItemEditing="Extension_ItemEditing"
                            OnItemDataBound="Extension_ItemDataBound"
                            OnItemDeleting="Extension_ItemDeleting"
                            OnItemCanceling="Extension_ItemCanceling"
                            OnItemUpdating="Extension_ItemUpdating">


                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">
                                        <asp:HiddenField ID="HidExtensionId" runat="server" Value='<%#Bind("ExtensionId") %>' />
                                        <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ExtendedTo")))%>' />
                                    </td>

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
                <td colspan="5">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Extended To</td>
                    <td>
                        <asp:TextBox ID="ExtendedToTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Extended To" ControlToValidate="ExtendedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator9" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ExtendedToTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
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
                            <EditItemTemplate>
            <tr>
                <td colspan="5">
                <asp:HiddenField ID="HidExtensionId" runat="server" Value='<%#Bind("ExtensionId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Extended To</td>
                    <td>
                        <asp:TextBox ID="ExtendedToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ExtendedTo")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Extended To" ControlToValidate="ExtendedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator9" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ExtendedToTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
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
                                        <b>No probation details found.</b>

                                    </td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>


                        <tr>
                            <td colspan="5">
                                <asp:ValidationSummary ID="ValidationSummary4"
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
    </div>







    <script type="text/javascript">
        $(function () {

            $("[id$=AppointmentDateTxt]").change(function () {
                $("[id$=ProbationFromTxt]").val($("[id$=AppointmentDateTxt]").val());
                $("[id$=CurrentStatusDateTxt]").val($("[id$=AppointmentDateTxt]").val());

            });



        });
    </script>
</asp:Content>
