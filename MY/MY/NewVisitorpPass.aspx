<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="NewVisitorpPass.aspx.cs" Inherits="MY.NewVisitorpPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .row {
            margin-top: 5px;
        }

        .sm-control {
            font-size: 10pt;
            height: 30px;
        }
        .lbl-rt{
            text-align:right;
        }
          .lbl-lt{
            text-align:left;
        }
    </style>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="margin-top:0px;">
            <div class="col-md-12">
                <h4 class="page-header" style="margin-top:0px;">New Entry Pass</h4>
                <asp:HiddenField ID="HidPassId" runat="server" Value="0" />
                <asp:Label ID="CopyNoticeLbl" runat="server"></asp:Label>
            </div>
        </div>
         <div class="row">
            <div class="col-md-2 sm-control lbl-rt">
                Visit Purpose:
            </div>
            <div class="col-md-10">
                <asp:TextBox ID="VisitPurposeTxt" Style="font-size: 10pt" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="Enter Visit Purpose" runat="server" ErrorMessage="Enter Visit Purpose" ControlToValidate="VisitPurposeTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 sm-control lbl-rt">
                Pass Date:
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="PassDateTxt" class="form-control sm-control datepicker js-date"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="Enter Pass Date" runat="server" ErrorMessage="Enter Pass Date" ControlToValidate="PassDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
       
            <div class="col-md-2 sm-control  lbl-rt">
                Branch:
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="BranchDDL" runat="server" class="form-control sm-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator5" Text="Select Branch" runat="server" ErrorMessage="Select Branch" ControlToValidate="BranchDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
        </div>
       
        <div class="row">
            <div class="col-md-2 sm-control lbl-rt">
                Visit Type:
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="PassTypeDDL" runat="server" class="form-control  sm-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-2 sm-control lbl-rt">
                Visitor Organization:
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="CompanyNameTxt" ClientIDMode="Static" class="form-control sm-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidCompanyId" runat="server" Value="0" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 sm-control lbl-rt">
                Visit From:
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="FromDateTxt"  ClientIDMode="Static" class="form-control sm-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="FromDateTxtVal" Text="Enter From Date" runat="server" ErrorMessage="Enter From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2 sm-control lbl-rt">
                Visit To:
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="ToDateTxt" ClientIDMode="Static" class="form-control sm-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="ToDateTxtVal" Text="Enter To Date" runat="server" ErrorMessage="Enter To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 sm-control lbl-rt">
                Allow OFF days:
            </div>
            <div class="col-md-4">
                <asp:CheckBox ID="SaturdayCB" Text="Saturday" runat="server" CssClass="sm-control" />
                <asp:CheckBox ID="SundayCB" Text="Sunday" runat="server" CssClass="sm-control" />
            </div>
             <div class="col-md-2 sm-control lbl-rt">
                Active:
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control sm-control">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <%--  <div class="row">
            <div class="col-md-2 sm-control">
                Vehicle Type (if any):
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="VehicleTypeDDL" runat="server">
                   
                </asp:DropDownList>
            </div>
               <div class="col-md-2 sm-control">
                Vehicle Reg. No.:
            </div>
            <div class="col-md-4">
                 <asp:TextBox ID="VehicleRegNo" class="form-control sm-control" runat="server"></asp:TextBox>
            </div>
        </div>--%>
       <%-- <div class="row">
            <div class="col-md-2 sm-control">
                Remarks:
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control sm-control" runat="server"></asp:TextBox>
            </div>
        </div>--%>
       
      
 
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-8">
                        <h4>Visitors</h4>
                         <asp:Label ID="viitorserror" style="color:red" runat="server" Text="Please enter visitors."  Visible="false"></asp:Label>
                    </div>

                    <div class="col-md-4" style="text-align: right">
                        <br />
                        <asp:Button class="btn btn-custom" ID="AddVisitorBtn" runat="server" CommandName="new" Text="Add Visitor" OnClick="AddVisitorBtn_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <table class="table table-hover table-striped" style="font-size: 10pt">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>Visitor Name</th>
                                    <th>CNIC</th>
                                    <th>Details ( Vehicle etc )</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:ListView ID="LV" runat="server"
                                    OnItemEditing="ItemEditing"
                                    OnItemCanceling="ItemCanceling"
                                    OnItemDeleting="ItemDeleting"
                                    OnItemInserting="ItemInserting"
                                    OnItemUpdating="ItemUpdating">
                                    <ItemTemplate>
                                        <tr class="sm-control">
                                            <td>
                                                <asp:HiddenField ID="HidVisitorId" runat="server" Value='<%#Bind("VisitorId")%>' />
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                            <td>
                                                <asp:Label ID="VisitorName" runat="server" Text='<%#Bind("VisitorName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text='<%#Bind("Cnic")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>
                                            <td>
                                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                                    ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <tr style="font-size: 10pt">
                                            <td colspan="7">
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Bind("VisitorId")%>' />
                                                <table class="table table-condensed">
                                                      <tr>
                                                        <td class="sm-control">CNIC</td>
                                                        <td>
                                                            <asp:TextBox ID="CnicTxt" ClientIDMode="Static" class="form-control sm-control" runat="server" Text='<%#Bind("Cnic")%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Enter CNIC" ControlToValidate="CnicTxt" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                             <asp:HiddenField ID="HidVisitorCnic" runat="server" Value='' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="sm-control">Visitor Name</td>
                                                        <td>
                                                            <asp:TextBox ID="VisitorNameTxt" ClientIDMode="Static" class="form-control sm-control" runat="server" Text='<%#Bind("VisitorName")%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Visitor Name" ControlToValidate="VisitorNameTxt" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                             <asp:HiddenField ID="HidVisitorName" runat="server" Value='' />
                                                             <asp:HiddenField ID="HidVisitorId" runat="server" Value='<%#Bind("VisitorId")%>' />
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td class="sm-control">Details ( Vehicle etc )</td>
                                                        <td class="sm-control">
                                                            <asp:TextBox ID="DetailsTxt" class="form-control sm-control" TextMode="MultiLine" runat="server" Text='<%#Eval("Details")%>'></asp:TextBox>
                                                        <td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                                ToolTip="Save" ValidationGroup="Group2"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                        </td>
                                                    </tr>

                                                </table>

                                            </td>
                                        </tr>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <tr style="font-size: 10pt">
                                            <td colspan="7">
                                                <table class="table table-condensed">
                                                      <tr>
                                                        <td class="sm-control">CNIC</td>
                                                        <td>
                                                            <asp:TextBox ID="CnicTxt" ClientIDMode="Static" class="form-control sm-control" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Enter CNIC" ControlToValidate="CnicTxt" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                             <asp:HiddenField ID="HidVisitorCnic" runat="server" Value='' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="sm-control">Visitor Name</td>
                                                        <td>
                                                            <asp:TextBox ID="VisitorNameTxt" ClientIDMode="Static" class="form-control sm-control" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Enter Visitor Name" ControlToValidate="VisitorNameTxt" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                            <asp:HiddenField ID="HidVisitorName" runat="server" Value='' />
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td class="sm-control">Details ( Vehicle etc )</td>
                                                        <td>
                                                            <asp:TextBox ID="DetailsTxt" class="form-control sm-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                        <td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" class="btn btn-custom" runat="server" CommandName="cancel"
                                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                            <asp:LinkButton class="btn btn-custom" ID="LinkButton2" runat="server" CommandName="insert"
                                                                ToolTip="Save" ValidationGroup="Group2"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </InsertItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="3">No Data Found</td>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:ListView>


                            </tbody>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="col-md-12" style="text-align: right">
            <br />
            <asp:Button class="btn btn-custom" ID="SavePassBtn" ValidationGroup="Group1" runat="server" Text="Save and Print Pass" OnClick="SavePassBtn_Click" />
        </div>
          </div>
        <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <script src="scripts/jquery.mask.min.js"></script>

        <script>
            //$(function () {
            //    $(".datepicker").datepicker();
            //});
            //On Page Load.
            $(function () {
                SetAutoCompleteCnic();
                SetAutoCompleteName();
                $(".datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: 0,
                    onSelect: function (dateText, inst) { }
                });
                $('#CnicTxt').mask('00000-0000000-0');
            });
            //On UpdatePanel Refresh.
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        SetAutoCompleteCnic();
                        SetAutoCompleteName();
                    }
                });
            };
          
            function SetAutoCompleteCnic() {
                $("[id$=CnicTxt]").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/vms.asmx/GetVisitorByCNIC") %>',
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('=')[2],
                                        vname: item.split('=')[0],
                                        cnic: item.split('=')[1]
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
                        $("[id$=HidVisitorCnic]").val(i.item.cnic);
                        $("[id$=VisitorNameTxt]").val(i.item.vname);

                    },
                    minLength: 3
                });
            }
            function SetAutoCompleteName () {
                $("[id$=VisitorNameTxt]").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/vms.asmx/GetVisitorByName") %>',
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('=')[2],
                                        cnic: item.split('=')[1],
                                        vname: item.split('=')[0]
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
                        $("[id$=HidVisitorName]").val(i.item.vname);
                        $("[id$=CnicTxt]").val(i.item.cnic);
                       
                    },
                    minLength: 3
                });
             }

            $(function () {
                $("[id$=CompanyNameTxt]").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/WebService1.asmx/GetCompanies") %>',
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('=')[1],
                                        val: item.split('=')[0],
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
                        $("[id$=HidCompanyId]").val(i.item.val);
                    },
                    minLength: 1
                });
            });

        </script>
</asp:Content>
