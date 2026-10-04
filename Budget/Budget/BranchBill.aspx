<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BranchBill.aspx.cs" Inherits="Budget.BranchBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="row">
            <div class="col-md-12 page-header" style="font-size:14pt;">
                Manage Branch Bills
                </div>
             </div>
        <div class="row">
            <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-9">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                <asp:DropDownList ID="HeadOfAccountDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
            <div class="col-md-9">
                <label class="page-title"></label>
            </div>
            <div class="col-md-3" style="text-align: right">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New Bill" class="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
          <div class="row">
            <div class="col-md-12">
                <asp:Label ID="error" style="color:red" runat="server" Text=''></asp:Label>
            </div>
        </div>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Bill Id</th>
                            <th>Vendor / Company</th>
                            <th>Vendor Number</th>
                            <th>Bill Detail</th>
                            <th>Bill Number/Date</th>
                            <th>Total Amount</th>
                            <th>Income Tax</th>
                            <th>GST</th>
                            <th>Net Amount</th>
                            <th>Cheque Number/Date</th>
                            <th>Token Number</th>
                             <th>Bill Status</th>
                            <th>Remarks</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="BillLV" runat="server"
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
                                    <asp:HiddenField ID="HidBillId" runat="server" Value='<%#Bind("BillId")%>' />
                                    <asp:HiddenField ID="HidBillTypeId" runat="server" Value='<%#Bind("BillTypeId")%>' />
                                    <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                    <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                    <asp:HiddenField ID="HidFinancialYearId" runat="server" Value='<%#Bind("FinancialYearId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                  <td>
                                    <asp:Label ID="Label27" runat="server" Text='<%#Bind("BillId")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("VendorName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("VendorNumber") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BillDescription") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("BillNumber") + " / " + GetDate(Convert.ToDateTime(Eval("BillDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("TotalAmount") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("IncomeTax") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("Gst") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Bind("NetAmount") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ChequeNumber") + " / " + GetDate(Convert.ToDateTime(Eval("ChequeDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Bind("TokenNumber") %>'></asp:Label></td>
                                      <td>
                                    <asp:Label ID="Label28" runat="server" Text='<%#Bind("BillStatusDesc") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
                                <td style="min-width:100px;">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                  <%--  <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete"  OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                    <asp:HyperLink class="btn btn-success" ID="HyperLink1" ToolTip="Details" runat="server" NavigateUrl='<%#Eval("BillId","~/PurchaseHardware.aspx?Id={0}")%>'><span class="glyphicon glyphicon-menu-right"></span></asp:HyperLink>
                                </td>
                            </tr>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td colspan="15" style="font-weight: bold; background-color: #000; color: #fff">
                                    <asp:Label ID="Label19" runat="server" Text='BILL DETAILS'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="15">
                                    <asp:HiddenField ID="HidBillId" runat="server" Value='<%#Bind("BillId")%>' />
                                    <asp:HiddenField ID="HidBillTypeId" runat="server" Value='<%#Bind("BillTypeId")%>' />
                                    <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                    <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                    <asp:HiddenField ID="HidBillStatusId" runat="server" Value='<%#Bind("BillStatusId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>
                                                <asp:Label style="font-size:14pt;font-weight:bold" ID="HiddenField1" runat="server" Text='<%#"BILL ID : " + Eval("BillId")%>' />
                                               <td style="text-align:right">
                                                    <asp:Button ID="Button1" runat="server" CommandName="new" Text="Discard Bill" class="btn btn-success" />
                                                   <asp:Button ID="Button3" runat="server" CommandName="new" Text="Change Head Of Account" class="btn btn-success" OnClick="Button1_Click" />
                                                    <asp:Button ID="Button2" runat="server" CommandName="new" Text="Move to Next Financial Year" class="btn btn-success" OnClick="Button1_Click" />
                                            </td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:DropDownList ID="HeadOfAccountDDL" style="font-size:14pt;font-weight:bold" Enabled="false" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                        <tr>


                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='Vendor / Company'></asp:Label>
                                                <asp:TextBox ValidationGroup="g3" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' ID="VendorNameTxt"  class="form-control bill" runat="server" Text='<%#Bind("VendorName")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator1" runat="server" style="color:red" ControlToValidate="VendorNameTxt" ErrorMessage="Enter Vendor Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text='Vendor Number'></asp:Label>
                                                <asp:TextBox ID="VendorNumberTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' class="form-control bill" runat="server" Text='<%#Bind("VendorNumber")%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td colspan="2">
                                                <asp:Label ID="Label12" runat="server" Text='Bill Details'></asp:Label>
                                                <asp:TextBox ID="BillDetailsTxt" ValidationGroup="g3" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' TextMode="MultiLine" class="form-control bill" runat="server" Text='<%#Bind("BillDescription")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator2" runat="server" ControlToValidate="BillDetailsTxt" style="color:red" ErrorMessage="Please Enter Bill Details" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text='Invoice Number'></asp:Label>
                                                <asp:TextBox ID="BillNumberTxt" ValidationGroup="g3" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' class="form-control bill" runat="server" Text='<%#Bind("BillNumber")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator3" runat="server" ControlToValidate="BillNumberTxt" style="color:red" ErrorMessage="Please Enter Bill/Invoice Number" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text='Invoice Date ( dd/mm/yyyy )'></asp:Label>
                                                <asp:TextBox ID="BillDateTxt" ValidationGroup="g3" type="Date" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' class="form-control bill" runat="server" Text='<%#Convert.ToDateTime(Eval("BillDate")).ToShortDateString()%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator4" runat="server" ControlToValidate="BillDateTxt" style="color:red" ErrorMessage="Please Enter Bill Date (dd/mm/yyyy)" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="Label25" runat="server" Text='Total Amount'></asp:Label>
                                                <asp:TextBox ID="TotalAmountTxt" ValidationGroup="g3" class="form-control bill" runat="server" Text='<%#Bind("TotalAmount")%>' ReadOnly='<%#(Convert.ToInt32(Eval("BillStatusId"))==4)?true:false%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator5" runat="server"  style="color:red" ControlToValidate="TotalAmountTxt" ErrorMessage="Please Enter  Bill Amount" Display="Dynamic"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="2">
                                                <asp:Label ID="Label24" runat="server" Text='Stock Register Details'></asp:Label>
                                                <asp:TextBox ID="StockRegisterTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("StockRegisterDetails")%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td colspan="2" style="text-align:right">
                                                <asp:Button ID="UpdateBillBtn"  runat="server" Text="Update Bill Details" CssClass="btn btn-success" ValidationGroup="g3" OnClick="UpdateBillBtn_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label20" runat="server" Text='SANCTION DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text='Sanction File No.'></asp:Label>
                                                <asp:TextBox ID="SanctionFileNoTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' class="form-control sanc" runat="server" Text='<%#Bind("SanctionFileNumber")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g4" ID="RequiredFieldValidator6" runat="server"  style="color:red" ControlToValidate="SanctionFileNoTxt" ErrorMessage="Please Enter  Sanction File No" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text='Sanction File Date ( dd/mm/yyyy )'></asp:Label>
                                                <asp:TextBox ID="SanctionFileDate" type="Date"   ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==2)?false:true%>' class="form-control sanc" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SanctionFileDate")))%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g4" ID="RequiredFieldValidator7" runat="server"  style="color:red" ControlToValidate="SanctionFileDate" ErrorMessage="Please Enter Sanction Date (dd/mm/yyyy)" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align:right">
                                                <asp:Button ID="UpdateSanctionBtn" runat="server" Text="Update Sanction Details" CssClass="btn btn-success" ValidationGroup="g4" OnClick="UpdateSanctionBtn_Click" />
                                            </td>
                                        </tr>

                                        </tr>

                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label18" runat="server" Text='TAX DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text='Tax: '></asp:Label>
                                                <asp:Label ID="IncomeTaxTxt"  runat="server" Text='<%#Bind("IncomeTax")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text='GST: '></asp:Label>
                                                <asp:Label ID="GstTxt"  runat="server" Text='<%#Bind("Gst")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label5" runat="server" Text='CHECK DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Net Amount:</td>
                                            <td>
                                                <asp:Label ID="NetAmountTxt"  runat="server" Text='<%#Convert.ToDouble(Eval("TotalAmount"))-Convert.ToDouble(Eval("Gst"))-Convert.ToDouble(Eval("IncomeTax"))%>'></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td>Token Number:</td>
                                            <td>
                                                <asp:Label ID="TokenNumberTxt"  runat="server" Text='<%#Bind("TokenNumber")%>'></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Cheque Number:</td>
                                            <td>
                                                <asp:Label ID="ChequeNumberTxt"  runat="server" Text='<%#Bind("ChequeNumber")%>'></asp:Label>
                                            </td>

                                        </tr>
                            </tr>
                            <tr>
                                <td>Cheque Date:</td>
                                <td>
                                    <asp:Label ID="ChequeDateTxt"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ChequeDate")))%>'></asp:Label>
                                </td>

                            </tr>
                            </tr>
                                          <tr>
                                              <td>Remarks:</td>
                                              <td>
                                                  <asp:Label ID="RemarksTxt" TextMode="MultiLine" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                                              </td>

                                          </tr>
                            <tr>
                                <td colspan="15">Action:</td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                  <%--  <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>--%>
                                </td>
                            </tr>
                            </table>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td colspan="15" style="font-weight: bold; background-color: #000; color: #fff">
                                    <asp:Label ID="Label21" runat="server" Text='BILL DETAILS'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="15">


                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label26" runat="server" Text='Head of Account'></asp:Label>
                                                <asp:DropDownList ID="HeadOfAccountDDL" runat="server" class="form-control">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator8" runat="server" InitialValue="0"  style="color:red" ControlToValidate="HeadOfAccountDDL" ErrorMessage="Please select Head of Account" Display="Dynamic"></asp:RequiredFieldValidator>

                                            </td>
                                           </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='Vendor/Company'></asp:Label>
                                                <asp:TextBox ID="VendorNameTxt" class="form-control" runat="server" Text=''></asp:TextBox><asp:HiddenField ID="HidVendorId" runat="server" Value='' />
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator1" runat="server" style="color:red" ControlToValidate="VendorNameTxt" ErrorMessage="Enter Vendor Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text='Vendor Number'></asp:Label>
                                                <asp:TextBox ID="VendorNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>

                                            </td>

                                        </tr>
                                        <tr>

                                            <td colspan="3">
                                                <asp:Label ID="Label12" runat="server" Text='Bill Details'></asp:Label>
                                                <asp:TextBox ID="BillDetailsTxt" TextMode="MultiLine" class="form-control" runat="server" Text=''></asp:TextBox>
                                                 <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator2" runat="server" ControlToValidate="BillDetailsTxt" style="color:red" ErrorMessage="Please Enter Bill Details" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <%--<tr>

                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text='Sanction File No.'></asp:Label>
                                                <asp:TextBox ID="SanctionFileNoTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text='Sanction File Date'></asp:Label>
                                                <asp:TextBox ID="SanctionFileDate" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>--%>
                                        <tr>

                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text='Invoice Number'></asp:Label>
                                                <asp:TextBox ID="BillNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator3" runat="server" ControlToValidate="BillNumberTxt" style="color:red" ErrorMessage="Please Enter Bill/Invoice Number" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text='Invoice Date ( dd/mm/yyyy )'></asp:Label>
                                                <asp:TextBox ID="BillDateTxt" type="Date" class="form-control" runat="server" Text='<%#DateTime.Now.ToShortDateString()%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator4" runat="server" ControlToValidate="BillDateTxt" style="color:red" ErrorMessage="Please Enter Bill Date (dd/mm/yyyy)" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="Label15" runat="server" Text='Total Amount'></asp:Label>
                                                <asp:TextBox ID="TotalAmountTxt" type="number" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator5" runat="server"  style="color:red" ControlToValidate="TotalAmountTxt" ErrorMessage="Please Enter  Bill Amount" Display="Dynamic"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <%--  <tr>
                                            <td colspan="3" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label18" runat="server" Text='TAX DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text='Tax'></asp:Label>
                                                <asp:TextBox ID="IncomeTaxTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text='GST'></asp:Label>
                                                <asp:TextBox ID="GstTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label25" runat="server" Text='CHECK DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Net Amount:</td>
                                            <td>
                                                <asp:TextBox ID="NetAmountTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>
                            <tr>
                                <td>Token Number:</td>
                                <td>
                                    <asp:TextBox ID="TokenNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>Cheque Number:</td>
                                <td>
                                    <asp:TextBox ID="ChequeNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                </td>

                            </tr>
                            </tr>
                                          <tr>
                                              <td>Cheque Date:</td>
                                              <td>
                                                  <asp:TextBox ID="ChequeDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                              </td>

                                          </tr>
                            </tr>
                                          <tr>
                                              <td>Remarks:</td>
                                              <td>
                                                  <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text=''></asp:TextBox>
                                              </td>

                                          </tr>


                            <tr>--%>
                                        <td colspan="15"></td>
                                        <td colspan="3">
                                            <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                           <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="insert"
                                                ToolTip="Save" ValidationGroup="g3"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
    <script type="text/javascript">
      
        $(function () {
            $("[id$='HeadOfAccountTxt']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/BudgetService.asmx/GetHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidHeadOfAccountId]").val(i.item.val);
                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=VendorNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/BudgetService.asmx/GetBranchVendorByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'9'}",//" + $('#ContentPlaceHolder1_BranchDDL').val() + "'}",
                        // data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidVendorId]").val(i.item.val);
                    $("[id$=VendorNumberTxt]").val(i.item.val2);
                },
                minLength: 1
            });
        });
          $(function () {
              $("[id$=ContentPlaceHolder1_BillLV_VendorNameTxt_0]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/BudgetService.asmx/GetBranchVendorByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'9'}",//" + $('#ContentPlaceHolder1_BranchDDL').val() + "'}",
                        // data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=ContentPlaceHolder1_BillLV_HidVendorId_0]").val(i.item.val);
                    $("[id$=ContentPlaceHolder1_BillLV_VendorNumberTxt_0]").val(i.item.val2);
                },
                minLength: 1
            });
        });
    </script>
</asp:Content>

