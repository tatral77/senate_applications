<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NoticeMotionDetail.aspx.cs" Inherits="MotionBranch.NoticeMotionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-md-12 page-header">
                <h4>MOTION DETAILS</h4>
            </div>
        </div>
        
    </div>
     <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-1">
                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                <asp:HiddenField ID="HidMotionFile" runat="server" />
            </div>
            <div class="col-md-4" style="text-align: left">
             <asp:TextBox Type="Number" PlaceHolder="Previous Motion ID:" ID="PreviousMotionIdTxt" ValidationGroup="ReviveGroup"  class="form-control small-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Motion ID" ValidationGroup="ReviveGroup" Display="Dynamic" style="color:red" ControlToValidate="PreviousMotionIdTxt"></asp:RequiredFieldValidator>
             <div class="alert alert-danger" id="prviousIdError" runat="server" visible="false"></div>
            </div>
             <div class="col-md-1" style="text-align: left">
                <asp:Button ID="RevivedBtn" runat="server" ValidationGroup="ReviveGroup" Text="Revive" OnClick="RevivedBtn_Click" class="btn btn-info" />
            </div>
        <div class="col-md-6" style="text-align: right">
            <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            <asp:Button ID="TranslateBtn" Cssclass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
              <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
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
                <%--  <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                 <asp:HiddenField ID="HidSessionNumber" runat="server" />--%>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>

        </div>

        <div class="row top-buffer">
            <div class="col-md-4">
               <label class="control-lbl-sm" for="CategoryDDL">Motion Type:</label>
                <asp:DropDownList ID="MotionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
               
                       </div>
              <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Motion Status:</label>
                     <asp:DropDownList ID="MotionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
            </div>
            </div>
          <div class="row top-buffer">
            <%--  <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt" >Motion ID:</label>
                <asp:TextBox ID="MotionIDTxt" ReadOnly="true" style="background-color:white" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>--%>
            <%--  <div class="col-md-2">
                   <label class="control-lbl-sm">Motion Diary No:</label>
          
                <asp:TextBox ID="MotionDiaryNoTxt" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>--%>


            <%--   <div class="col-md-4">



               
                   <label class="control-lbl-sm" for="CategoryDDL">Motion Type:</label>
                <asp:DropDownList ID="MotionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
               
                       </div>
              <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Motion Status:</label>
                     <asp:DropDownList ID="MotionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
            </div>--%>


            <%--             </div>--%>
            <%--  <div class="row top-buffer">
            
            <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Moving in House:</label>
                 <asp:TextBox ID="HouseMovingDateTxt" runat="server" CssClass="form-control"/> 
            </div>
         <div class="col-md-3">
                  <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Discussion:</label>
                 <asp:TextBox ID="DiscussionDateTxt"  runat="server" CssClass="form-control"/>  
            </div>
         <div class="col-md-3">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Date of Reffering to SC:</label>
                 <asp:TextBox ID="RefferingDateTxt" runat="server" CssClass="form-control"/> 
            </div>
            </div>--%>

              <div class="col-md-4">
                        <label class="control-lbl-sm" for="SenatorDDL">Mover:</label>

                        <asp:TextBox ID="MemberNameTxt"  runat="server" CssClass="form-control" />
                        <asp:HiddenField ID="HidMemberId" runat="server" />
                        <asp:Label ID="err" runat="server" Text="" style="color:red"></asp:Label>
                    </div>
                     <div class="col-md-1" style="margin-top:25px">
                         <asp:Button ID="AddMover" runat="server" Text=">>" class="btn btn-custom" OnClick="AddMover_Click"/><br />
                         <asp:Button ID="DeleteMover" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMover_Click"/>
                     </div>
                      <div class="col-md-4">
                        <label class="control-lbl-sm"  for="SenatorDDL" >Motion Movers:</label>

                          <asp:ListBox ID="MoversLB" runat="server" class="form-control" placeholder="Members">
                        
                          </asp:ListBox>
                       

                    </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="text-align: center">
                <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
            </div>
        </div>
    </div>

    <br />
   
          <%--  <div class="col-md-2">
                <label class="control-lbl-sm">Change File:</label>

            </div>
            <div class="col-md-4">
                <asp:FileUpload ID="FileUpload1" runat="server" Cssclass="btn btn-custom" Style="width: 250px;" />
            </div>--%>
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
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MotionTxt"></asp:RequiredFieldValidator>

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

    </div>

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
