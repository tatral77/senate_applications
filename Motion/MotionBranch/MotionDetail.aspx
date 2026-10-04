<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="MotionDetail.aspx.cs" Inherits="MotionBranch.MotionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="Summernote/summernote-pagebreak.js"></script>
    <script src="Summernote/summernote-ext-print.js"></script>
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }

        @media all {
            .page-break {
                display: none;
            }
        }

        @media print {
            .page-break {
                display: block;
                page-break-before: always;
            }
        }
        ol{
            list-style-type: lower-alpha !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                <h4>MOTION DETAILS</h4>

            </div>
        </div>

    </div>
     <div class="container regularDiv">
        <div class="row">
            <div class="col-md-1">
                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                <asp:HiddenField ID="HidMotionFile" runat="server" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="TranslateBtn" Cssclass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print" Cssclass="btn btn-custom" />
                  <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            </div>

            <div class="col-md-1">
              

                <%--  <asp:HyperLink ID="PrintNoteHL" runat="server" Target="_blank"  Text="Print Note" Cssclass="btn btn-custom"/>--%>
            </div>
            <div class="col-md-6" style="text-align:right">
                <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete record ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" />
            </div>
        </div>
    </div>

    <%--    <div id="move" class="container regularDiv" style="display: none">
        <div class="row">
            <div class="col-md-12"><b><u>Revive Motion</u></b></div>
        </div>
        <div class="row" style="margin-top: 12px;">
            <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList"
                EnableClientScript="true" Style="color: red;"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="MoveGroup" runat="server" />
            <asp:UpdatePanel ID="upSetSession" runat="server">
                <ContentTemplate>
                    <div class="col-md-2">
                        <asp:DropDownList ID="MoveAssemblySessionDDL" class="form-control small-control" ValidationGroup="MoveGroup" runat="server" AutoPostBack="true" Placeolder="Session" OnSelectedIndexChanged="MoveAssemblySessionDDL_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session No" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveAssemblySessionDDL"></asp:RequiredFieldValidator>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="col-md-2">
                <asp:TextBox Type="Number" PlaceHolder="Notice Diary No:" ID="MoveNoticeDiaryTxt" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTxt" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="MoveNoticeDateTxt"  PlaceHolder="Notice Date" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDateTxt"></asp:RequiredFieldValidator>

            </div>

        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-md-2">
                <asp:TextBox ID="MoveNoticeDiaryTimeTxt"  PlaceHolder="Notice Time" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Notice Diary Time" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <asp:Button ID="MoveMotionBtn" runat="server" Text="Revive" ValidationGroup="MoveGroup" class="btn btn-custom" OnClick="MoveMotionBtn_Click" />
            </div>
        </div>
    </div>
    <div id="defer" class="container regularDiv" style="display: none">
        <div class="row">
            <div class="col-md-12"><b><u>Defer Motion</u></b></div>
            <div class="col-md-12">
                <asp:ValidationSummary ID="ValidationSummary2" DisplayMode="BulletList"
                    EnableClientScript="true"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="DefferGroup" runat="server" />
            </div>
        </div>

        <div class="row" style="margin-top: 12px">

            <div class="col-md-2">
                <asp:DropDownList ID="DefferAssemblySessionDDL" class="form-control" runat="server" Placeolder="Session">
                    <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDefferAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session" ValidationGroup="DefferGroup" InitialValue="0" ControlToValidate="DefferAssemblySessionDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <asp:TextBox ID="DeferDateTxt" class="form-control small-control" runat="server" PlaceHolder="Defer Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDeferDateTxt" runat="server" ErrorMessage="Enter Date" ValidationGroup="DefferGroup" Display="None" ControlToValidate="DeferDateTxt"></asp:RequiredFieldValidator>

            </div>


            <div class="col-md-2">
                <asp:Button ID="DeferMotionBtn" runat="server" Text="Defer" ValidationGroup="DefferGroup" class="btn btn-custom" OnClick="DeferMotionBtn_Click" />
            </div>
            <div class="col-md-8">
                <asp:Label ID="Deferror" runat="server" Text="" Style="color: red"></asp:Label>
            </div>




        </div>
    </div>--%>
    <br />
    <div class="container  regularDiv" id="#panel">

        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:DropDownList CssClass="form-control" ID="SessionsDDL" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt">Motion ID:</label>
                <asp:TextBox ID="MotionIDTxt" ReadOnly="true" Style="background-color: white" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">File No:</label>
                <asp:TextBox ID="FileNoTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter File No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNoTxt"></asp:RequiredFieldValidator>
            </div>
            <%--   <div class="col-md-2">
                <label class="control-lbl-sm">Motion Diary No:</label>

                <asp:TextBox ID="MotionDiaryNoTxt" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>--%>
            <div class="col-md-3">

                <label class="control-lbl-sm" for="CategoryDDL">Motion Type:</label>
                <asp:DropDownList ID="MotionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Motion Week:</label>
                <asp:DropDownList ID="MotionWeekCB" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>

            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>


        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Motion Status:</label>
                <asp:DropDownList ID="MotionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="HidMotionStatusId" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Moving in House:</label>
                <asp:TextBox ID="HouseMovingDateTxt" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Discussion:</label>
                <asp:TextBox ID="DiscussionDateTxt" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Reffering to SC:</label>
                <asp:TextBox ID="RefferingDateTxt" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Mover:</label>
                <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
                <asp:Label ID="err" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <div class="col-md-1" style="margin-top: 25px">
                <asp:Button ID="AddMover" runat="server" Text=">>" class="btn btn-custom" OnClick="AddMover_Click" /><br />
                <asp:Button ID="DeleteMover" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMover_Click" />
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Motion Movers:</label>
                <asp:ListBox ID="MoversLB" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Ministry:</label>
                <asp:TextBox ID="MinistryTxt" runat="server" CssClass="form-control" />
                <asp:HiddenField ID="HidMinistryId" runat="server" />
                <asp:Label ID="err2" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMinistry" runat="server" Text=">>" class="btn btn-custom" OnClick="AddMinistry_Click" /><br />
                <asp:Button ID="DeleteMinistry" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMinistry_Click" />
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Ministries:</label>
                <asp:ListBox ID="MinistryLB" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="text-align: center">
                <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
            </div>
        </div>
    </div>
    <br />
   
    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Motion Text:</label>
                <textarea id="MotionTxt" name="QuestionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_MotionTxt').summernote(
                            {
                                toolbar: [
                                    ['pagebreak', ['pagebreak']], // The Button
                                    ['style', ['style']],
                                    ['font', ['bold', 'italic', 'underline', 'clear']],
                                    ['fontname', ['fontname']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                    ['height', ['height']],
                                    ['table', ['table']],
                                    ['insert', ['media', 'link', 'hr']],
                                    ['view', ['fullscreen', 'codeview']],
                                    ['help', ['help']],
                                    ['print', ['print']],
                                    ['fontsize', ['fontsize']],
                                ],
                                height: 300
                            });

                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Motion Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MotionTxt"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Urdu Text:</label>
            </div>

            <%-- <div class="col-md-2">
                     <asp:Button Text="Read Text" runat="server" OnClick="Upload" CssClass="form-control btn btn-success" />
                     </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <%--<CKEditor:CKEditorControl ID="QuestionTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                <textarea id="UrduTxt" name="UrduTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_UrduTxt').summernote(
                            {
                                height: 300,

                            });
                    });
                </script>
                <%--<asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="SaveGroup" Display="None"  ControlToValidate="QuestionTxt"></asp:RequiredFieldValidator>--%>

                <%--<textarea id="QuestionTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
        </div>
        <div class="row top-buffer">



            <%--  <div class="col-md-12">
                <button id="ImageButton" class="btn btn-info">View / Hide Image</button>
            </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Note:</label>
                <textarea id="NoteTxt" name="NoteTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_NoteTxt').summernote(

                            {
                                toolbar: [
                                    ['pagebreak', ['pagebreak']], // The Button
                                    ['style', ['style']],
                                    ['font', ['bold', 'italic', 'underline', 'clear']],
                                    ['fontname', ['fontname']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                    ['height', ['height']],
                                    ['table', ['table']],
                                    ['insert', ['media', 'link', 'hr']],
                                    ['view', ['fullscreen', 'codeview']],
                                    ['help', ['help']],
                                    ['print', ['print']]
                                ],
                                height: 300
                            });
                    });
                </script>
            </div>
        </div>
    </div>
    <br />

    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="page-header"><b>Status History</b></div>
                <table class="table table-hover table-striped table-responsive">
                    <thead class="thead-inverse">
                        <tr>
                            <th>Sr#</th>
                            <th>Session No</th>
                            <th>Motion Status</th>
                            <th>Status Date</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="LVStatus" runat="server">

                            <ItemTemplate>
                                <tr>
                                    <td>

                                        <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("AssemblySession")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("MotionStatus")%>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                    </td>

                                </tr>
                            </ItemTemplate>

                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

     <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="page-header"><b>Revival History</b></div>
                <table class="table table-hover table-striped table-responsive">
                    <thead class="thead-inverse">
                        <tr>
                            <th>Sr#</th>
                            <th>From Session Number</th>
                            <th>To Session Number</th>
                             <th>Previous Notice Office Diary No</th>
                            <th>Revival Date</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="LVMovement" runat="server">

                            <ItemTemplate>
                                <tr>
                                    <td>

                                        <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Eval("FromAssemblySession")%>' />
                                    </td>

                                    <td>
                                           <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Eval("ToAssemblySession")%>' />
                                        <%--<asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetSession(Convert.ToInt32(Eval("FromAssemblySession")))%>' />--%>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("NoticeOfficediaryNumber")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RevivalDate")))%>' />
                                    </td>

                                </tr>
                            </ItemTemplate>

                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $("#Movebtn").click(function (e) {
            // some actions here
            e.preventDefault();
            $("#move").toggle();
            $("#defer").hide();
        });
        $("#Defferbtn").click(function (e) {
            // some actions here
            e.preventDefault();
            $("#move").hide();
            $("#defer").toggle();
        });
        $(function () {
            $("[id$=MinistryTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
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
                    $("[id$=HidMinistryId]").val(i.item.val);
                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=DivisionTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetDivisionsByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
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
                    $("[id$=HidDivisionId]").val(i.item.val);
                    $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');


                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=MemberNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
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
                    $("[id$=HidMemberId]").val(i.item.val);
                    $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');





                },
                minLength: 1
            });
        });

        jQuery(document).ready(function () {

            jQuery('#AddNewBtn').on('click', function (event) {
                event.preventDefault();
                window.location.href = 'NewQuestion.aspx';



            });


        });


        //$("#QuestionTxt").keydown(function (e) {
        //    if (e.keyCode === 9) { // tab was pressed
        //        // get caret position/selection
        //        var start = this.selectionStart;
        //        end = this.selectionEnd;

        //        var $this = $(this);

        //        // set textarea value to: text before caret + tab + text after caret
        //        $this.val($this.val().substring(0, start)
        //                    + "\t"
        //                    + $this.val().substring(end));

        //        // put caret at right position again
        //        this.selectionStart = this.selectionEnd = start + 1;

        //        // prevent the focus lose
        //        return false;
        //    }
        //});


        //document.onkeypress = function (event) {
        //    if (event.ctrlKey && event.keyCode == 83) {
        //        event.preventDefault();
        //        document.getElementById('Button1').click();

        //    }

        //};
        //document.onkeydown = function (event) {
        //    if (event.ctrlKey && event.keyCode == 82 || event.keyCode == 114) {
        //        event.preventDefault();
        //        document.getElementById('QuestionTxt').style.alignContent = "left";;
        //    }

        //};

        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_Button1').click();
                return false;
            }
        });
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 80)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_PrintBtn').click();
                return false;
            }


        });
        $('#ContentPlaceHolder3_QuestionTxt').bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_Button1').click();
                return false;
            }


        });
        $('#ContentPlaceHolder3_QuestionTxt').bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_PrintBtn').click();
                return false;
            }


        });



    </script>




</asp:Content>

