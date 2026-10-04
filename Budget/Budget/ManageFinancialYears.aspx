<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageFinancialYears.aspx.cs" Inherits="Budget.ManageFinancialYears" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">FINANCIAL YEARS</label>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" class="btn btn-success" />

            </div>
        </div>

        <%--   <div class="row">
           <div class="col-md-4">
               <label style="font-size:small;font-weight:bold">Parliamentary Year</label>
               <asp:DropDownList ID="ParliamentaryYearDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="1">2018-2019</asp:ListItem></asp:DropDownList>
           </div>
            <div class="col-md-4">
                <label style="font-size:small;font-weight:bold">Visits</label>
               <asp:DropDownList ID="VisitsDDL" AutoPostBack="true" OnSelectedIndexChanged="VisitsDDL_SelectedIndexChanged" runat="server" class="form-control">
                   <asp:ListItem  Value="1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Upcoming</asp:ListItem>
                    <asp:ListItem  Value="3">Previous</asp:ListItem>
               </asp:DropDownList>
           </div>
       </div>--%>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Financial Year</th>
                            <th>From Date</th>
                            <th>To Date</th>
                            <th>Demand Number</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                    <asp:ListView ID="FinancialYearsLV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemCreated="ItemCreated"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemDataBound="ItemDataBound"
                        OnItemUpdating="ItemUpdating">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidFinancialYearId" runat="server" Value='<%#Bind("FinancialYearId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("FinancialYearId","~/ManageFundCenteres.aspx?FY={0}")%>'><%#Eval("FinancialYear")%></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label></td>
                                  <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("DemandNumber")%>'></asp:Label></td>
                                <td>
                                    
                                  <%--<asp:HyperLink class="btn btn-success" ID="HyperLink2" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("FinancialYearId","~/HeadOfAccountsList.aspx?FY={0}")%>'>Head of Accounts</asp:HyperLink>  --%>
                                
                               <%-- <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                <%--    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="9">
                                    <asp:HiddenField ID="HidFinancialYearId" runat="server" Value='<%#Bind("FinancialYearId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>Visit Title:</td>
                                            <td>
                                                <asp:TextBox ID="FinancialYearTxt" class="form-control" runat="server" Text='<%#Bind("FinancialYear")%>'></asp:TextBox>
                                        </tr>

                                        <td>From Date:</td>
                                        <td>
                                            <asp:TextBox ID="FromDateTxt" class="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:TextBox>
                                            <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="FromDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </tr>
                            <tr>
                                <td>To Date:</td>
                                <td>
                                    <asp:TextBox ID="ToDateTxt" class="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </tr>
                               <tr>
                                <td>Demand Number:</td>
                                <td>
                                    <asp:TextBox ID="DemandNumberTxt" class="form-control" runat="server" Text='<%#Eval("DemandNumber") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Demand Number" ControlToValidate="DemandNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </tr>


                            <tr>
                                <td>Action:</td>
                                <td class="altCent">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                            </tr>
                            </table>
</td>
</tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <tr>
                                    <td colspan="9">
                                        <table class="table table-condensed table-data">
                                            <tr>
                                                <td>Financial Year:</td>
                                                <td>
                                                    <asp:TextBox ID="FinancialYearTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </tr>
                                            <tr>
                                                <td>From Date:</td>
                                                <td>
                                                    <asp:TextBox ID="FromDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                    <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="FromDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                            </tr>
                                            <tr>
                                                <td>To Date:</td>
                                                <td>
                                                    <asp:TextBox ID="ToDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                            </tr>
                                              <tr>
                                <td>Demand Number:</td>
                                <td>
                                    <asp:TextBox ID="DemandNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Demand Number" ControlToValidate="DemandNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </tr>
                                            <tr>
                                                
                                                <td>Action:</td>
                                                <td class="altCent">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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

    </div>
</asp:Content>
