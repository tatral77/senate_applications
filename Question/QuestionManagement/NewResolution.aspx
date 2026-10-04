<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewResolution.aspx.cs" Inherits="QuestionManagement.NewResolution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <link href="Styles/notonastaliqurdudraft.css" rel="stylesheet" />
     <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-3 page-header">
                <h4>NEW RESOLUTION</h4>
            </div>
            <div class="col-md-9 page-header" style="text-align: right;">
                <asp:Button ID="AddNewBtn" runat="server" Text="Add New" class="btn btn-custom" OnClick="AddNewBtn_Click" />
            </div>
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
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>

            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
                <div class="col-md-2 bootstrap-timepicker">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm">Resolution Diary No:</label>
                <asp:TextBox ID="ResolutionDiaryNoTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Resolution diary number" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionDiaryNoTxt"></asp:RequiredFieldValidator>
            </div>

        </div>

        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Resolution Type:</label>
                <asp:DropDownList ID="ResolutionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
            </div>
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
                <label class="control-lbl-sm" for="SenatorDDL">Resolution Movers:</label>

                <asp:ListBox ID="MoversLB" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
                
            </div>
         </div>
      

        </div>

    <div class="container" style="margin-top:5px;margin-bottom:5px;">
        <div class="row"><div class="col-lg-6">
              <label class="control-lbl-sm" for="SenatorDDL">Urdu Resolution:</label>
              <asp:CheckBox ID="UrduCB" runat="server" Checked="false"></asp:CheckBox>
                         </div></div>
        
    </div>
    <div class="container  regularDiv">
          <div class="row top-buffer">
              <div class="col-md-7"><label class="control-lbl-sm">Resolution Text:</label></div>
                <div class="col-md-3">
                     <asp:FileUpload ID="FileUpload1" runat="server" Cssclass="btn btn-success " data-scan="true" />

                </div>
                 <div class="col-md-2">
                     <asp:Button Text="Read Text" runat="server" OnClick="Upload" CssClass="form-control btn btn-success" />
                     </div>
            </div>
        <div class="row top-buffer">
            <div class="col-md-12">
                
                <textarea id="ResolutionTxt" name="ResolutionTxt" style="height: 300px;font-family: 'Noto Nastaliq Urdu Draft', 'Times New Roman';" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" ></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_ResolutionTxt').summernote(
                            {
                                height: 300,
                                toolbar: [
                                              ['style', ['style']],
                                              ['style', ['bold', 'italic', 'underline', 'clear']],
                                              ['fontname', ['fontname']],
                                              ['color', ['color']],
                                              ['para', ['ul', 'ol', 'paragraph']],
                                              ['insert', ['table']],
                                              ['insert', ['link', 'picture', 'video', 'hr']],
                                              ['view', ['fullscreen', 'codeview', 'help']]
                                ]
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Resolution Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>

            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="col-md-12" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" ValidationGroup="SaveGroup" class="btn btn-custom" />
            <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" Cssclass="btn btn-custom" OnClick="PrintBtn_Click" />
        </div>
    </div>


    <script type="text/javascript">
        $('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
            template: false,
            showInputs: false,
            defaultTime: false,
            minuteStep: 5
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
                        url: '<%=ResolveUrl("~/Service.asmx/GetMemberMinisterByName") %>',
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
