<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatingPlan.aspx.cs" Inherits="Notice.SeatingPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="CustomScripts/jquery-ui.min.js"></script>
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
              <div class="row">
            <div class="col-md-10 page-header">
                <h4>SEAT MANAGEMENT </h4>

            </div>
        

        </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="Member"></asp:Label>

                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:HiddenField ID="HidMemberId" runat="server" />
                </div>
            </div>
            <div class="top-buffer"></div>
             <div class="row">
                  <div class="col-md-2">
                   
                </div>
                <div class="col-md-1">
                    <asp:Button ID="Button1" CssClass="btn-primary" runat="server" Text="Assign" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="Button2" CssClass="btn-primary" runat="server" Text="Un-Assign" />
                </div>
            </div>
        </div>

    </form>
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
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
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
</body>
</html>
