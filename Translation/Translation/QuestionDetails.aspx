<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" EnableViewState="true" ValidateRequest="false" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="Translation.QuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="./Summernote/summernote.css" rel="stylesheet" />
    <link href="./Summernote/summernote-bs4.css" rel="stylesheet" />
    <link href="Summernote/summernote-lite.css" rel="stylesheet" />
      
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
        #imgdiv {
                overflow: auto;
                max-width: 800px;  
                max-height: 600px; 
                }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="container-fluid">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row  page-header">
            <div class="col-md-8">
                <h4>QUESTION DETAILS   </h4>
                <asp:Label ID="QuestionIdLabel" runat="server"></asp:Label>
            </div>
                <div class="col-md-4">
                  <br />
                    <asp:Button ID="SaveBtn" CssClass="btn btn-success" runat="server" Text="Save Translated Text" OnClick="SaveBtn_Click" />
                    <asp:Button ID="FinalizeBtn" CssClass="btn btn-danger" runat="server" Text="Finalize Translation" OnClick="FinalizeBtn_Click" />
                   <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank"></asp:HyperLink>
                  </div>
        </div>
    </div>
   
    <div class="container-fluid  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-6">
                <div id="urdudiv" runat="server" visible="false">
                <label class="control-lbl-sm">Urdu Text:</label>
                <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
                <textarea id="UrduTxt" name="UrduTxt" style="height: 300px;" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_UrduTxt').summernote(
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
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');



                                },
                                height: 300

                            });
                    });
                </script>
              </div>
            <div id="imgdiv" runat="server" visible="false" style="overflow-y:scroll;height:700px;">
                <asp:Image ID="QuestionImage" AlternateText="No Image" ClientIDMode="Static" runat="server" width="100%"  />
            </div>
             <div id="pdfDiv" runat="server" visible="false">
            </div>
            </div>

            <div class="col-md-6">
             <%--   <div id="imagediv">
                     <%-- <asp:Image ID="QuestionImage" AlternateText="No Image" ClientIDMode="Static" runat="server" Width="500px" Height="500px" />
                </div>--%>

                <label class="control-lbl-sm">English Text:</label>
                <asp:RequiredFieldValidator ID="rfvQTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="UpdateGroup" Display="Dynamic" ControlToValidate="QTxt"></asp:RequiredFieldValidator>
                <textarea id="QTxt" name="QTxt" style="height: 300px;" class="form-control" rows="10" runat="server" required="required"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_QTxt').summernote(
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
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 300
                            });
                    });
                </script>
            </div>
        </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12" style="text-align: right">
                <asp:Label ID="Label1" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>

        </div>
     <br />

    <script type="text/javascript">
        //$('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
        //    template: false,
        //    showInputs: false,
        //    minuteStep: 5
        //});
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
                    //$("[id$=GroupTxt]").val("");
                    //$("[id$=HidGroupId]").val(i.item.val);


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
                    //  $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupTxt]").val("");
                    //$("[id$=HidGroupId]").val(i.item.val);


                },
                minLength: 1
            });
        });

        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_UpdateQuestionBtn').click();
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
        $('#ContentPlaceHolder3_QTxt').bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_UpdateQuestionBtn').click();
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
        $("#ImageButton").click(function (e) {
            e.preventDefault();
            $("#imagediv").toggle(500);
        });


    </script>



    <script src="./Summernote/summernote.min.js"></script>
    <script src="./Summernote/summernote-bs4.js"></script>
    <script src="./Summernote/summernote-lite.js"></script>
     <script src="Summernote/summernote-ext-print.js"></script>


</asp:Content>
