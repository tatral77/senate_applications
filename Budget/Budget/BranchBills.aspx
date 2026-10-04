<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="BranchBills.aspx.cs" Inherits="Budget.BranchBills" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
         <div class="row">
             <div class="col-md-12">
                <label class="page-header"style="font-size: 12pt;">Manage Branches Bills</label>
               
            </div>
             </div>
        <div class="row">
             <div class="col-md-2">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">Branch</label>
                <asp:DropDownList ID="BranchDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
       
         <div class="col-md-5">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                 <asp:DropDownList ID="HeadOfAccountDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
              <div class="col-md-2">
                <label style="font-size: small; font-weight: bold">Bill Status</label>
                <asp:DropDownList ID="StatusDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="StatusDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             </div>
         <div class="row" style="margin-top:10px;">
            <div class="col-md-12" >
                <label class="page-title"></label>
            </div>
          <%--  <div class="col-md-2" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New Bill" class="btn btn-success" OnClick="Button1_Click" />

            </div>--%>
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
                            <th>ID</th>
                            <th>Head of Account</th>
                           
                            <th>Vendor / Company</th>
                            <th>Vendor Number</th>
                            
                            <th>Bill Number/Date</th>
                            <th>Total Amount</th>
                            <th>Income Tax</th>
                            <th>GST</th>
                            <th>Net Amount</th>
                            <th>Cheque Number/Date</th>
                            <th>Token Number</th>
                             <th>Bill Status</th>
                            <th>Branch</th>
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
                            <tr style="font-weight:bold">
                                <td>
                                 <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                  <td>
                                    <asp:Label ID="Label27" runat="server" Text='<%#"BID: " + Eval("BillId")%>'></asp:Label></td>
                                  <td colspan="12">
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BillDescription") %>'></asp:Label></td>
                            </tr>
                            <tr style="border-bottom:double">
                               
                                    <asp:HiddenField ID="HidBillId" runat="server" Value='<%#Bind("BillId")%>' />
                                    <asp:HiddenField ID="HidBillTypeId" runat="server" Value='<%#Bind("BillTypeId")%>' />
                                    <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                    <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                    <asp:HiddenField ID="HidFinancialYearId" runat="server" Value='<%#Bind("FinancialYearId")%>' />
                                  <td>
                                    <asp:Label ID="Label30" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                                 <td>
                                    <asp:Label ID="Label29" runat="server" Text='<%#Eval("HeadOfAccount")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("VendorName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("VendorNumber") %>'></asp:Label></td>
                              
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("BillNumber") + " / " + GetDate(Convert.ToDateTime(Eval("BillDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("TotalAmount"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("IncomeTax") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("Gst") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("NetAmount"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ChequeNumber") + " / " + GetDate(Convert.ToDateTime(Eval("ChequeDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Bind("TokenNumber") %>'></asp:Label></td>
                                      <td>
                                    <asp:Label ID="Label28" runat="server" Text='<%#Bind("BillStatusDesc") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text='<%#Bind("BranchName") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
                                <td style="min-width:100px;">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                 <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete"  OnClientClick="return confirm('Are you sure you want to delete the Bill.\nBill sent to AGPR and will not be deleted.');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    <asp:HyperLink class="btn btn-success" ID="HyperLink1" ToolTip="Details" runat="server" NavigateUrl='<%#Eval("BillId","~/PurchaseHardware.aspx?Id={0}")%>'><span class="glyphicon glyphicon-menu-right"></span></asp:HyperLink>
                                    <asp:HyperLink class="btn btn-success" ID="HyperLink2" ToolTip="Details" runat="server" NavigateUrl='<%#Eval("BillId","~/BillDocuments.aspx?Id={0}")%>'><span class="glyphicon glyphicon-file"></span></asp:HyperLink>
                                </td>
                            </tr>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td colspan="14" style="font-weight: bold; background-color: #000; color: #fff">
                                    <asp:Label ID="Label19" runat="server" Text='BILL DETAILS'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="14">
                                    <asp:HiddenField ID="HidBillId" runat="server" Value='<%#Bind("BillId")%>' />
                                    <asp:HiddenField ID="HidBillTypeId" runat="server" Value='<%#Bind("BillTypeId")%>' />
                                    <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                    <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                    <asp:HiddenField ID="HidBillStatusId" runat="server" Value='<%#Bind("BillStatusId")%>' />
                                    <table class="table table-condensed table-data">
                                         <tr>
                                            <td colspan="2">
                                                <asp:Label style="font-size:14pt;font-weight:bold" ID="HiddenField1" runat="server" Text='<%#"BILL ID : " + Eval("BillId")%>' />
                                               
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
                                                <asp:Label ID="Label4" style="font-weight:bold" runat="server" Text='Vendor / Company :'></asp:Label>
                                                <%--<asp:TextBox ID="VendorNameTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Bind("VendorName")%>'></asp:TextBox>--%>
                                                <asp:Label ID="TextBox1"  runat="server" Text='<%#Bind("VendorName")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" style="font-weight:bold" runat="server" Text='Vendor Number :'></asp:Label>
                                                <%--<asp:TextBox ID="VendorNumberTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Bind("VendorNumber")%>'></asp:TextBox>--%>
                                                <asp:Label ID="VendorNumberTxt"   runat="server" Text='<%#Bind("VendorNumber")%>'></asp:Label>

                                            </td>

                                        </tr>
                                        <tr>

                                            <td colspan="2">
                                                <asp:Label ID="Label12" runat="server" style="font-weight:bold" Text='Bill Details :'></asp:Label>
                                                <%--<asp:TextBox ID="BillDetailsTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("BillDescription")%>'></asp:TextBox>--%>
                                                <asp:Label ID="BillDetailsTxt"  runat="server" Text='<%#Bind("BillDescription")%>'></asp:Label>
                                            </td>

                                        </tr>
                                      
                                        <tr>

                                            <td>
                                                <asp:Label ID="Label13" style="font-weight:bold" runat="server" Text='Invoice Number :'></asp:Label>
                                                <%--<asp:TextBox ID="BillNumberTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Bind("BillNumber")%>'></asp:TextBox>--%>
                                                <asp:Label ID="BillNumberTxt"  runat="server" Text='<%#Bind("BillNumber")%>'></asp:Label>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label14" style="font-weight:bold" runat="server" Text='Invoice Date ( dd/mm/yyyy ) :'></asp:Label>
                                                <%--<asp:TextBox ID="BillDateTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("BillDate")).ToShortDateString()%>'></asp:TextBox>--%>
                                                <asp:Label ID="BillDateTxt"  runat="server" Text='<%#Convert.ToDateTime(Eval("BillDate")).ToShortDateString()%>'></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="Label25" style="font-weight:bold" runat="server" Text='Total Amount :'></asp:Label>
                                                <%--<asp:TextBox ID="TotalAmountTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Bind("TotalAmount")%>'></asp:TextBox>--%>
                                                <asp:Label ID="TotalAmountTxt"  runat="server" Text='<%#Bind("TotalAmount")%>'></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="2">
                                                <asp:Label ID="Label24" style="font-weight:bold" runat="server" Text='Stock Register Details :'></asp:Label>
                                                <%--<asp:TextBox ID="StockRegisterTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("StockRegisterDetails")%>'></asp:TextBox>--%>
                                                <asp:Label ID="StockRegisterTxt"  runat="server" Text='<%#Bind("StockRegisterDetails")%>'></asp:Label>

                                            </td>

                                        </tr>
                                           <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label20" runat="server" Text='SANCTION DETAILS'></asp:Label></td>
                                        </tr>
                                          <tr>

                                            <td>
                                                <asp:Label ID="Label22" style="font-weight:bold" runat="server" Text='Sanction File No. :'></asp:Label>
                                                <%--<asp:TextBox ID="SanctionFileNoTxt" ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' class="form-control" runat="server" Text='<%#Bind("SanctionFileNumber")%>'></asp:TextBox>--%>
                                                <asp:Label ID="SanctionFileNoTxt"  runat="server" Text='<%#Bind("SanctionFileNumber")%>'></asp:Label>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label23" style="font-weight:bold" runat="server" Text='Sanction File Date ( dd/mm/yyyy ) :'></asp:Label>
                                                <%--<asp:TextBox ReadOnly='<%#(Convert.ToInt32(Eval("GeneratedBy"))==1)?false:true%>' ID="SanctionFileDate" class="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SanctionFileDate")))%>'></asp:TextBox>--%>
                                                <asp:Label  ID="SanctionFileDate"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SanctionFileDate")))%>'></asp:Label>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label18" runat="server" Text='TAX DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text='Tax'></asp:Label>
                                                <asp:TextBox ID="IncomeTaxTxt" class="form-control" runat="server" Text='<%#Bind("IncomeTax")%>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text='GST'></asp:Label>
                                                <asp:TextBox ID="GstTxt" class="form-control" runat="server" Text='<%#Bind("Gst")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #000; color: #fff">
                                                <asp:Label ID="Label5" runat="server" Text='CHECK DETAILS'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Net Amount:</td>
                                            <td>
                                                <asp:Label ID="NetAmountTxt" class="form-control" runat="server" Text='<%#Eval("NetAmount")%>'></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td>Token Number:</td>
                                            <td>
                                                <asp:TextBox ID="TokenNumberTxt" class="form-control" runat="server" Text='<%#Bind("TokenNumber")%>'></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Cheque Number:</td>
                                            <td>
                                                <asp:TextBox ID="ChequeNumberTxt" class="form-control" runat="server" Text='<%#Bind("ChequeNumber")%>'></asp:TextBox>
                                            </td>

                                        </tr>
                            </tr>
                            <tr>
                                <td>Cheque Date ( dd/mm/yyyy ):</td>
                                <td>
                                    <asp:TextBox ID="ChequeDateTxt" class="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ChequeDate")))%>'></asp:TextBox>
                                </td>

                            </tr>
                            </tr>
                                          <tr>
                                              <td>Remarks:</td>
                                              <td>
                                                  <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                              </td>

                                          </tr>
                             <tr>
                                <td colspan="13"><asp:Label ID="err" runat="server"></asp:Label></td>
                               
                            </tr>
                            <tr>
                                <td>Action:</td>
                                <td style="text-align:right">
                                   
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                     <asp:Button ID="SendToAgprBtn" runat="server" Text="Send to AGPR" CssClass="btn btn-success" OnClick="SendToAgprBtn_Click" />
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save">Save Details</asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>

                                </td>
                            </tr>
                            </table>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td colspan="13" style="font-weight: bold; background-color: #000; color: #fff">
                                    <asp:Label ID="Label21" runat="server" Text='BILL DETAILS'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="13">


                                    <table class="table table-condensed table-data">
                                        <tr>
                                           <%--   <td>
                                                <asp:Label ID="Label27" runat="server" Text='Branch'></asp:Label>
                                                <asp:DropDownList ID="BranchDDL" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged1">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text='Head of Account'></asp:Label>
                                                <asp:DropDownList ID="HeadOfAccountDDL" runat="server" class="form-control">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>--%>

                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='Vendor / Company'></asp:Label>
                                                <asp:TextBox ID="VendorNameTxt" class="form-control" runat="server" Text=''></asp:TextBox><asp:HiddenField ID="HidVendorId" runat="server" Value='' />
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
                                            </td>

                                        </tr>
                                        <%--<tr>

                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text='Sanction File No.'></asp:Label>
                                                <asp:TextBox ID="SanctionFileNoTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text='Sanction File Date'></asp:Label>
                                                <asp:TextBox ID="SanctionFileDate" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>--%>
                                        <tr>

                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text='Invoice Number'></asp:Label>
                                                <asp:TextBox ID="BillNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>



                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text='Invoice Date'></asp:Label>
                                                <asp:TextBox ID="BillDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="Label15" runat="server" Text='Total Amount'></asp:Label>
                                                <asp:TextBox ID="TotalAmountTxt" class="form-control" runat="server" Text=''></asp:TextBox>

                                            </td>
                                        </tr>
                                           <tr>
                                                <td colspan="13">
                                                    <asp:Label ID="err" class="form-control" runat="server"></asp:Label>
                                                    
                                                </td>
                               
                                            </tr>
                                        <tr>
                                        <td colspan="10">Action:</td>
                                        <td colspan="3">
                                            <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                            <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="insert"
                                                ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
                $("[id$='$HeadOfAccountTxt']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetHeadOfAccountByName") %>',
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
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetBranchVendorByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'" + $('#ContentPlaceHolder1_BranchDDL').val() + "'}",
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
</script>

</asp:Content>
