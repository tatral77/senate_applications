<%@ Page Title="" Language="C#" MasterPageFile="~/OutgoingVisits.master" AutoEventWireup="true" CodeBehind="OutgoingVisitDocuments.aspx.cs" Inherits="IPR.OutgoingVisitDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="row">
        <div class="col-md-9">
            <h4>
                <label id="heading" runat="server" class="page-header">D.A Sanction</label></h4>
        </div>
        <div class="col-md-2 page-header hideadd">
            <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <table class="table table-condensed caption">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Sanction Date</th>
                        <th>File No</th>
                        <th>Subject</th>
                        <th>Moved By</th>
                        <th>Expenditure Incurred On</th>
                        <%--<th>Transport Charges</th>--%>
                        <th>Action</th>
                    </tr>
                </thead>
                <asp:ListView ID="SanctionLV" runat="server"
                    OnItemEditing="ItemEditing"
                    OnItemInserting="ItemInserting"
                    OnItemCanceling="ItemCanceling"
                    OnItemDeleting="ItemDeleting"
                    OnItemUpdating="ItemUpdating">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="HidSanctionId" runat="server" Value='<%#Bind("SanctionId")%>' />
                            <td class="itemCent">
                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                            </td>

                            <td class="itemLeft">
                                <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToDateTime(Eval("SanctionDate")).ToShortDateString()%>'></asp:Label>
                            </td>
                            <td class="itemLeft">
                                <asp:Label ID="Label4" runat="server" Text='<%#Bind("FileNo")%>'></asp:Label>
                            </td>
                            <td class="itemLeft">
                                <asp:Label ID="Label5" runat="server" Text='<%#Bind("Subject")%>'></asp:Label>
                            </td>
                            <td class="itemLeft">
                                <asp:Label ID="Label7" runat="server" Text='<%#Bind("MovedBy")%>'></asp:Label>
                            </td>
                            <td class="itemLeft">
                                <asp:Label ID="Label2" runat="server" Text='<%#Bind("IncurredOn")%>'></asp:Label>
                            </td>
                            <%--<td class="itemLeft">
                                <asp:Label ID="Label3" runat="server" Text='<%#Bind("TransportCharges")%>'></asp:Label>
                            </td>--%>
                            <td class="itemCent hideall">
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom hideedit" runat="server" CommandName="edit" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom hidedelete" runat="server" CommandName="delete" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                 <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#GetPrintLink(Eval("SanctionId").ToString())%>'  class="btn btn-custom" runat="server"  
                                 ToolTip="Print">Print</span></asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <tr>
                            <td colspan="7">
                                <asp:HiddenField ID="HidSanctionId" runat="server" Value='<%#Bind("SanctionId")%>' />
                                <table class="table table-condensed table-data">
                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Sanction Date</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="SanctionDateTxt" class="form-control" runat="server" Text='<%#Bind("SanctionDate")%>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="SanctionDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Sanction Date"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">File No</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="FileNoTxt" class="form-control" runat="server" Text='<%#Bind("FileNo")%>'></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Moved By</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="MovedByTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("MovedBy")%>'></asp:TextBox>
                                        </td>
                                    </tr>

                                         <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Subject</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="SubjectTxt" class="form-control" runat="server" Text='<%#Bind("Subject")%>'></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Incurred On</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="IncurredOnTxt" class="form-control" runat="server" Text='<%#Bind("IncurredOn")%>'></asp:TextBox>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td class="table-data"><asp:Label runat="server">Rule No</asp:Label></td>
                                        <td><asp:TextBox ID="RuleNoTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("RuleNo")%>'></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td class="table-data"><asp:Label runat="server">Head of Account</asp:Label></td>
                                        <td><asp:TextBox ID="HeadOfAccountTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td colspan="3">
                                            <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
                                        <td class="table-data">
                                            <asp:Label runat="server">Santion Date</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="SanctionDateTxt" class="form-control" runat="server" Text=""></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="SanctionDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Sanction Date"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">File No</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="FileNoTxt" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Moved By</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="MovedByTxt" TextMode="MultiLine" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Subject</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="SubjectTxt" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="table-data">
                                            <asp:Label runat="server">Incurred On</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="IncurredOnTxt" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="table-data"><asp:Label runat="server">Rule No</asp:Label></td>
                                        <td><asp:TextBox ID="RuleNoTxt" TextMode="MultiLine" class="form-control" runat="server" Text=""></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="table-data"><asp:Label runat="server">Head of Account</asp:Label></td>
                                        <td><asp:TextBox ID="HeadOfAccountTxt" TextMode="MultiLine" class="form-control" runat="server" Text="01-General Public Service-011 Executive and Legislative Organs, Financial and Fiscal Affairs, External Affairs-0111 Executive and Legislative Organs-
011101 Parliamentary/Legislative Affairs-ID 1931-Secretariat-A038 General-A03813- Daily Allowance on Official Visit Abroad."></asp:TextBox></td>
                                    </tr>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                <asp:LinkButton class="btn btn-custom" ID="LinkButton3" runat="server" CommandName="insert"
                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
</asp:Content>
