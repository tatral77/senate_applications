<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" CodeBehind="NewMember.aspx.cs" Inherits="QuestionManagement.NewMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Panel ID="AddPanel" runat="server" DefaultButton="Save" CssClass="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-user"></span> NEW MEMBER</span>
            <button type="button" class="btn btn-default btn-sm qs-more-toggle" data-toggle="collapse" data-target="#nmAdd"><span class="glyphicon glyphicon-chevron-down"></span> Show / hide</button>
        </div>
        <div class="panel-body">
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="g1" CssClass="text-danger" DisplayMode="BulletList" HeaderText="Please correct the following:" runat="server" />
            <div id="nmAdd" class="collapse in">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="LblName" runat="server" CssClass="small-label" AssociatedControlID="EmpName" Text="Member Name"></asp:Label>
                        <asp:TextBox ID="EmpName" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" Text="Required" CssClass="text-danger small" ErrorMessage="Member Name" ControlToValidate="EmpName" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="LblUrdu" runat="server" CssClass="small-label" AssociatedControlID="UrduName" Text="Urdu Name"></asp:Label>
                        <asp:TextBox ID="UrduName" runat="server" class="form-control urdu-text" dir="rtl"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="LblGender" runat="server" CssClass="small-label" AssociatedControlID="GenderDDL" Text="Gender"></asp:Label>
                        <asp:DropDownList ID="GenderDDL" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="Required" CssClass="text-danger small" runat="server" ErrorMessage="Select Gender" ControlToValidate="GenderDDL" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="LblTenure" runat="server" CssClass="small-label" AssociatedControlID="AssemblyDDL" Text="Member Tenure"></asp:Label>
                        <asp:DropDownList ID="AssemblyDDL" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="Required" CssClass="text-danger small" runat="server" ErrorMessage="Select Tenure" ControlToValidate="AssemblyDDL" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LblStatus" runat="server" CssClass="small-label" AssociatedControlID="MemberStatusDDL" Text="Member Status"></asp:Label>
                        <asp:DropDownList ID="MemberStatusDDL" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="Required" CssClass="text-danger small" runat="server" ErrorMessage="Select Status" ControlToValidate="MemberStatusDDL" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LblParty" runat="server" CssClass="small-label" AssociatedControlID="PoliticalPartyDDL" Text="Political Party"></asp:Label>
                        <asp:DropDownList ID="PoliticalPartyDDL" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" Text="Required" CssClass="text-danger small" runat="server" ErrorMessage="Select Political Party" ControlToValidate="PoliticalPartyDDL" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LblElection" runat="server" CssClass="small-label" AssociatedControlID="ElectionTypeDDL" Text="Election Type"></asp:Label>
                        <asp:DropDownList ID="ElectionTypeDDL" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="Required" CssClass="text-danger small" runat="server" ErrorMessage="Select Election Type" ControlToValidate="ElectionTypeDDL" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="LblMinister" runat="server" CssClass="small-label" AssociatedControlID="IsMinisterCB" Text="Is Minister"></asp:Label>
                        <asp:CheckBox ID="IsMinisterCB" runat="server" class="form-control" Checked="false" />
                    </div>
                </div>
            </div>
            <div class="qs-actions">
                <asp:Button ID="Save" runat="server" class="btn btn-custom" Text="Save Member" OnClick="Save_Click" ValidationGroup="g1" />
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="SearchBtn" CssClass="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH MEMBERS</span>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="SrNso" runat="server" CssClass="small-label" AssociatedControlID="SearchNameTxt" Text="Member Name (English or Urdu)"></asp:Label>
                    <asp:TextBox ID="SearchNameTxt" runat="server" class="form-control" placeholder="e.g. Ali Khan"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label6" runat="server" CssClass="small-label" AssociatedControlID="SearchStatusDDL" Text="Member Status"></asp:Label>
                    <asp:DropDownList ID="SearchStatusDDL" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label7" runat="server" CssClass="small-label" AssociatedControlID="SearchTenureDDL" Text="Tenure"></asp:Label>
                    <asp:DropDownList ID="SearchTenureDDL" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label8" runat="server" CssClass="small-label" AssociatedControlID="SearchPartyDDL" Text="Party"></asp:Label>
                    <asp:DropDownList ID="SearchPartyDDL" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="qs-actions">
                <asp:Button ID="SearchBtn" runat="server" class="btn btn-custom" Text="Search" OnClick="Search_Click" />
                <asp:Button ID="ResetBtn" runat="server" class="btn btn-default" Text="Reset" OnClick="Reset_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>

    <div class="container-fluid qs-results">
        <p class="nm-count"><asp:Label ID="ResultCountLbl" runat="server" Text="Use the filters above and press Search to list members."></asp:Label></p>
        <table class="table table-hover table-striped table-responsive qs-table">
            <tr>
                <th class="m-hide">Sr#</th>
                <th>Member Name</th>
                <th>Urdu Name</th>
                <th>Party</th>
                <th>Current Tenure</th>
                <th>Status</th>
                <th class="m-hide">Questions</th>
                <th>Action</th>
            </tr>

            <asp:ListView ID="MembersLv"
                OnItemEditing="ItemEditing"
                OnItemCanceling="ItemCanceling"
                OnItemUpdating="ItemUpdating"
                OnItemDataBound="ItemDataBound"
                OnItemCreated="ItemCreated"
                runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="m-hide">
                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '>
                                <asp:HiddenField ID="HidMemberId" runat="server" Value='<%#Bind("MemberId")%>' />
                                <asp:HiddenField ID="HidPartyId" runat="server" Value='<%#Bind("NoOfQuestions")%>' />
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("MemberName") %>'></asp:Label></td>
                        <td class="urdu-text">
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("UrduName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Party") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("MemberTenure") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("MemberStatus") %>'></asp:Label></td>
                        <td class="m-hide">
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("NoOfQuestions") %>'></asp:Label></td>
                        <td>
                            <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                            <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td colspan="8" class="nm-edit">
                            <asp:HiddenField ID="HidMemberId" runat="server" Value='<%#Bind("MemberId")%>' />
                            <asp:HiddenField ID="HidPartyId" runat="server" Value='<%#Bind("PartyId")%>' />
                            <asp:HiddenField ID="HidMemberStatusId" runat="server" Value='<%#Bind("MemberStatusId")%>' />
                            <asp:HiddenField ID="HidMemberTenureId" runat="server" Value='<%#Bind("MemberTenureId")%>' />
                            <div class="row">
                                <div class="col-md-4">
                                    <span class="small-label">Member Name</span>
                                    <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control" Text='<%#Bind("MemberName") %>'></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <span class="small-label">Member Urdu Name</span>
                                    <asp:TextBox ID="MemberUrduNameTxt" runat="server" CssClass="form-control urdu-text" dir="rtl" Text='<%#Bind("UrduName") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <span class="small-label">Tenure</span>
                                    <asp:DropDownList ID="LVTenureDDL" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <span class="small-label">Status</span>
                                    <asp:DropDownList ID="LVStatusDDL" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <span class="small-label">Party</span>
                                    <asp:DropDownList ID="LVPartyDDL" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="nm-edit-actions">
                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" AlternateText="update" CommandName="update"
                                    ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                                <asp:LinkButton ID="cancelImageButton" class="btn btn-default" runat="server" AlternateText="cancel" CommandName="cancel"
                                    ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span> Cancel</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>
