<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewMBMotion.aspx.cs" Inherits="Notice.NewMBMotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
   
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
           
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3 page-header">
                <h4>NEW MOTION</h4>
            </div>
            <div class="col-md-9 page-header" style="text-align: right;">
                <asp:Button ID="AddNewBtn" runat="server" Text="Add New" class="btn btn-custom" OnClick="AddNewBtn_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
             <div class="col-md-12">
                <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
             </div>
            </div>

            <div class="row top-buffer">
               <div class="col-md-3">
                    <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                    <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HidSessionNumber" runat="server" />
                </div>
             <%--   <div class="col-md-3">
                    <label class="control-lbl-sm" for="SessionTxt">File No:</label>
                    <asp:TextBox  ID="FileNoTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter File No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNoTxt"></asp:RequiredFieldValidator>
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
             

                <div class="col-md-4">
                    <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                    <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                    <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt js-date" runat="server"></asp:TextBox>
                    <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                </div>
           
            <div class="col-md-4">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Type="time" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
           </div>
        <div class="row top-buffer">
        
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Mover:</label>
                <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control"  />
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


    </div>
        <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-2">
                <label class="control-lbl-sm">Attach Image File:</label></div>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload1" runat="server" Cssclass="btn btn-custom" Style="width: 250px;" data-scan="true" />
            </div>
            <%-- <div class="col-md-2">
                     <asp:Button Text="Read Text" runat="server" OnClick="Upload" CssClass="form-control btn btn-success" />
                     </div>--%>
        </div>
    </div>

    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">English Text:</label></div>
          <%--  <div class="col-md-3">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-primary " data-scan="true" />

            </div>
            <div class="col-md-2">
                <asp:Button Text="Read Text" runat="server" OnClick="Upload" CssClass="form-control btn btn-primary" />
            </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <textarea id="MotionTxt" name="MotionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_MotionTxt').summernote(
                            {
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Motion Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MotionTxt"></asp:RequiredFieldValidator>

            </div>
        </div>

          <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Urdu Text:</label></div>

            <%-- <div class="col-md-2">
                     <asp:Button Text="Read Text" runat="server" OnClick="Upload" CssClass="form-control btn btn-success" />
                     </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <%--<CKEditor:CKEditorControl ID="QuestionTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                <textarea id="UrduTxt" name="QuestionTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
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
    </div>
 
    <div class="container">
        <div class="col-md-12" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" ValidationGroup="SaveGroup" Cssclass="btn btn-custom" />
            <%--<asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" CssClass="btn btn-custom" OnClick="PrintBtn_Click" />--%>
        </div>
    </div>

          <br />  
    <script type="text/javascript">


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
