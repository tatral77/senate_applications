<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="Notice.LeaveApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h4>Member Leave Application</h4>
            </div>
        </div>
    </div>
    <br />
    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <%--<asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />--%>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Sitting Day:</label>
                <asp:DropDownList ID="SittingDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="SittingDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Leave Type:</label>
                <asp:DropDownList ID="LeaveTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="LeaveTypeDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt">Notice Diary Number:</label>
                <asp:TextBox ID="NoticeDiaryNumberTxt" ReadOnly="true" Style="background-color: white" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Type="time" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="control-lbl-sm">Member Name:</label>
                <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
                <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter Senator Name" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>
            </div>
              <div class="col-md-2">
                <label class="control-lbl-sm">Leave Start Date:</label>
                <asp:TextBox ID="LeaveStartDateTxt" Required="true" runat="server" CssClass="form-control small-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Start Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="LeaveStartDateTxt"></asp:RequiredFieldValidator>
            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm">Leave End Date:</label>
                <asp:TextBox ID="LeaveEndDateTxt" Required="true" runat="server" CssClass="form-control small-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Start Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="LeaveEndDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm">Is Session Leave:</label>
                <asp:CheckBox ID="IsSessionLeaveCB" runat="server" CssClass="form-control small-control" />
            </div>
        </div>
    </div>

    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-2">
                <label class="control-lbl-sm">Attach Image File:</label>
            </div>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
            </div>
        </div>
    </div>
    <div class="container  regularDiv">

        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Leave Purpose:</label>
                <textarea id="PurposeTxt" name="MotionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_PurposeTxt').summernote(
                            {
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Motion Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="PurposeTxt"></asp:RequiredFieldValidator>

            </div>
        </div>
        <br />
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Comments:</label>
                <textarea id="CommentsTxt" name="CommentsTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_CommentsTxt').summernote(
                            {
                                height: 300,

                            });
                    });
                </script>
            </div>
        </div>


        <div class="container">
            <div class="col-md-12" style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="SaveGroup" CssClass="btn btn-custom" />
            </div>
        </div>
    </div>

    <br />

    <script type="text/javascript">

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
                        url: '<%=ResolveUrl("~/service.asmx/GetEmployeeName") %>',
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
