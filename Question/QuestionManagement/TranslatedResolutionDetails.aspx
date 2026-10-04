<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="TranslatedResolutionDetails.aspx.cs" Inherits="QuestionManagement.TranslatedResolutionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="move" class="container regularDiv" style="display: none">
        <div class="row">

            <div class="col-md-12"><b><u>Move Resolution</u></b></div>

        </div>
        <div class="row" style="margin-top: 12px;">
            <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList"
                EnableClientScript="true" Style="color: red;"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="MoveGroup" runat="server" />
            <asp:UpdatePanel ID="upSetSession" runat="server">
                <ContentTemplate>
                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="MoveAssemblySessionDDL">Session No:</label>
                        <asp:DropDownList ID="MoveAssemblySessionDDL" class="form-control small-control" ValidationGroup="MoveGroup" runat="server">
                            <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session No" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveAssemblySessionDDL"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="MoveNoticeDiaryTxt">Notice Diary No:</label>
                        <asp:TextBox Type="Number" PlaceHolder="Notice Diary No:" ID="MoveNoticeDiaryTxt" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTxt" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="MoveNoticeDateTxt">Notice Date:</label>
                        <asp:TextBox ID="MoveNoticeDateTxt" PlaceHolder="Notice Date" ValidationGroup="MoveGroup" Required="true" class="form-control small-control js-date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMoveNoticeDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDateTxt"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="MoveNoticeDiaryTimeTxt">Notice Time</label>
                        <asp:TextBox ID="MoveNoticeDiaryTimeTxt" PlaceHolder="Notice Time" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Notice Time" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="MoveResDiaryNoTxt">Resolution Diary No:</label>
                        <asp:TextBox ID="MoveResDiaryNoTxt" PlaceHolder="Resolution Diary No:" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Resolution Diary No:" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveResDiaryNoTxt"></asp:RequiredFieldValidator>

                    </div>




                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="col-md-2">
                <br />
                <asp:Button ID="MoveResolutionBtn" runat="server" Text="Move" ValidationGroup="MoveGroup" class="btn btn-custom" OnClick="MoveResolutionBtn_Click" />

                <input type="submit" id="CancelBtn" value="Cancel" formnovalidate class="btn btn-custom">
            </div>





        </div>
    </div>




    <div class="container">
        <div class="row">
            <div class="col-md-4 page-header">
                <h4>RESOLUTION DETAILS</h4>

            </div>
            <div class="col-md-8 " style="text-align:right">
                <button id="Movebtn" class="btn btn-custom">Move</button>
                  <asp:Button ID="TranslateBtn" Cssclass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                 <asp:Button ID="ApprovedBtn" Cssclass="btn btn-custom" runat="server" Text="Approve" OnClick="ApprovedBtn_Click" />
                  <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>
            <%--   <div class="col-md-9 page-header" style="text-align:right;">
                <asp:Button ID="AddNewBtn" runat="server" Text="Add New" class="btn btn-custom" OnClick="AddNewBtn_Click" />
            </div>--%>
        </div>

    </div>
    <br />
    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />
                <%-- <asp:DropDownList ID="SessionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                   </asp:DropDownList>--%>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice  Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>

            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2 bootstrap-timepicker">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Colour Res. No:</label>
                <asp:TextBox ID="ResolutionNoTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>

            </div>

        </div>

        <div class="row top-buffer">

            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionIDTxt">Resolution ID:</label>
                <asp:TextBox ID="ResolutionIDTxt" ReadOnly="true" Style="background-color: white" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm">Resolution Diary No:</label>

                <asp:TextBox ID="ResolutionDiaryNoTxt" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>


            <div class="col-md-4">




                <label class="control-lbl-sm" for="CategoryDDL">Resolution Type:</label>
                <asp:DropDownList ID="ResolutionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Resolution Status:</label>
                <asp:HiddenField ID="HidResolutionStatusId" runat="server" />
                <asp:DropDownList ID="ResolutionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
            </div>


        </div>
        <div class="row top-buffer">

            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Moving in House:</label>
                <asp:TextBox ID="HouseMovingDateTxt" runat="server" CssClass="form-control js-date" />
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Discussion:</label>
                <asp:TextBox ID="DiscussionDateTxt" runat="server" CssClass="form-control js-date" />
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Passing:</label>
                <asp:TextBox ID="PassingDateTxt" runat="server" CssClass="form-control js-date" />
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
                <label class="control-lbl-sm" for="SenatorDDL">Resolution Submitters:</label>

                <asp:ListBox ID="MoversLB" runat="server" class="form-control" placeholder="Members"></asp:ListBox>


            </div>


        </div>




        <div class="row">
            <div class="col-md-12" style="text-align: center">
                <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
            </div>
        </div>


    </div>

     <div class="container" style="margin-top:5px;margin-bottom:5px;">
        <div class="row"><div class="col-lg-6">
              <label class="control-lbl-sm" for="SenatorDDL">Urdu Motion:</label>
              <asp:CheckBox ID="UrduCB" runat="server" Checked="false"></asp:CheckBox>
                         </div></div>
        
    </div>




    <br />
    <div class="container">
    </div>
    <div class="container  regularDiv">

        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Resolution Text:</label>
                <textarea id="ResolutionTxt" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_ResolutionTxt').summernote(
                            {
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Resolution Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>

            </div>
        </div>
         <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Urdu Text:</label>
                <textarea id="UrduText" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_UrduText').summernote(
                            {
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Urdu Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="UrduText"></asp:RequiredFieldValidator>

            </div>
        </div>
           <div class="row top-buffer">
            <div class="col-md-12" id="imagediv">
                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank" ></asp:HyperLink>
               <%-- <asp:Image ID="QuestionImage" AlternateText="No Image" ClientIDMode="Static" runat="server" Width="500px" Height="500px" />--%>
            </div>
          <%--  <div class="col-md-12">
                <button id="ImageButton" class="btn btn-info">View / Hide Image</button>
            </div>--%>
        </div>

    </div>


    <br />
    <div class="container">
        <div class="col-md-10" style="text-align: left">
            <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />


            <%--<asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" Cssclass="btn btn-custom" OnClick="PrintBtn_Click"/>--%>
            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print" Cssclass="btn btn-custom" />
        </div>
        <div class="col-md-2" style="text-align: right">
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete Resolution');" />
        </div>
    </div>

    <br />

    <script type="text/javascript">
        $('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
            template: false,
            showInputs: false,
            defaultTime: false,
            minuteStep: 5
        });
        $("#Movebtn").click(function (e) {
            // some actions here
            e.preventDefault();
            $("#move").toggle();
            $("#Movebtn").hide();
        });
        $("#CancelBtn").click(function (e) {
            // some actions here
            e.preventDefault();
            $("#move").toggle();
            $("#Movebtn").show();
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
                document.getElementById('ContentPlaceHolder3_PrintHL').click();
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
        $('#ContentPlaceHolder3_QTxt').bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_PrintHL').click();
                return false;
            }


        });



    </script>




</asp:Content>
