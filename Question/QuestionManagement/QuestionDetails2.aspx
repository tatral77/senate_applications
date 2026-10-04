<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" EnableViewState="true" ValidateRequest="false" AutoEventWireup="true" CodeBehind="QuestionDetails2.aspx.cs" Inherits="QuestionManagement.QuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Summernote/summernote-bs4.js"></script>
    <link href="Summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="Summernote/summernote-lite.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="Summernote/summernote-ext-print.js"></script>
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-md-7 page-header">
                <h4>QUESTION DETAILS</h4>

            </div>
            <%--Move and Defer Questions--%>
            <div class="col-md-5 page-header" style="text-align:right">
                 <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank" ></asp:HyperLink>
                <button id="Movebtn"  class="btn btn-custom">Revive</button>
                <button id="Defferbtn" class="btn btn-custom">Defer</button>
                <asp:Button ID="TranslateBtn" Cssclass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
            </div>

        </div>
    </div>

    <div id="move" class="container regularDiv" style="display: none">
        <div class="row">
            <div class="col-md-12"><b><u>Revive Question</u></b></div>

        </div>
        <div class="row" style="margin-top: 12px;">
            <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList"
                EnableClientScript="true" Style="color: red;"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="MoveGroup" runat="server" />
            <asp:UpdatePanel ID="upSetSession" runat="server">
                <ContentTemplate>
                    <div class="col-md-2">
                           <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                        <asp:DropDownList ID="MoveAssemblySessionDDL" class="form-control small-control" ValidationGroup="MoveGroup" runat="server" AutoPostBack="true" Placeolder="Session" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
                            <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session No" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveAssemblySessionDDL"></asp:RequiredFieldValidator>

                    </div>

                    <div class="col-md-2">
                        <label class="control-lbl-sm" for="SessionTxt">Group:</label>
                        <asp:DropDownList ID="MoveGroupsDDL" AutoPostBack="true" class="form-control small-control" ValidationGroup="MoveGroup" runat="server" OnSelectedIndexChanged="MoveGroupDDL_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Select Group</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveGroupsDDL" runat="server" Display="None" ControlToValidate="MoveGroupsDDL" ErrorMessage="Select Group" ValidationGroup="MoveGroup" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-4">
                        <label class="control-lbl-sm" for="SessionTxt">Division:</label>
                        <asp:DropDownList ID="MoveDivisionDDL" AutoPostBack="true" class="form-control small-control" runat="server" ValidationGroup="MoveGroup">
                            <asp:ListItem Value="0">Select Division</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveDivisionDDL" runat="server" Display="None" ControlToValidate="MoveDivisionDDL" ErrorMessage="Select Division" ValidationGroup="MoveGroup" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Notice Diary No:</label>
                <asp:TextBox Type="Number" PlaceHolder="Notice Diary No:" ID="MoveNoticeDiaryTxt" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTxt" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Notice Diary Date:</label>
                <asp:TextBox ID="MoveNoticeDateTxt" PlaceHolder="Notice Date" ValidationGroup="MoveGroup" Required="true" class="form-control small-control js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDateTxt"></asp:RequiredFieldValidator>

            </div>

        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Notice Diary Time:</label>
                <asp:TextBox ID="MoveNoticeDiaryTimeTxt" PlaceHolder="Notice Time" ValidationGroup="MoveGroup" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Notice Diary Time" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Question Status:</label>
                <asp:DropDownList ID="MoveQuestionStatusDDL" class="form-control small-control" runat="server" OnSelectedIndexChanged="MoveGroupDDL_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Select Status</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMoveQuestionStatusDDL" runat="server" Display="None" ErrorMessage="Select Status" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveQuestionStatusDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Question Diary No:</label>
                <asp:TextBox Type="Number" PlaceHolder="Question Diary No:" ID="MoveQuestionDiaryTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveQuestionDiaryTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="MoveQuestionBtn" runat="server" Text="Revive" ValidationGroup="MoveGroup" class="btn btn-custom" OnClick="MoveQuestionBtn_Click" />
            </div>
        </div>
    </div>
    <div id="defer" class="container regularDiv" style="display: none">
        <div class="row">
            <div class="col-md-12"><b><u>Defer Question</u></b></div>
            <div class="col-md-12">
                <asp:ValidationSummary ID="ValidationSummary2" DisplayMode="BulletList"
                    EnableClientScript="true"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="DefferGroup" runat="server" />
            </div>
        </div>

        <div class="row" style="margin-top: 12px">

            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:DropDownList ID="DefferAssemblySessionDDL" class="form-control" runat="server" Placeolder="Session">
                    <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDefferAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session" ValidationGroup="DefferGroup" InitialValue="0" ControlToValidate="DefferAssemblySessionDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Deffer Date:</label>
                <asp:TextBox ID="DeferDateTxt" class="form-control small-control js-date" runat="server" PlaceHolder="Defer Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDeferDateTxt" runat="server" ErrorMessage="Enter Date" ValidationGroup="DefferGroup" Display="None" ControlToValidate="DeferDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="DeferBtn" runat="server" Text="Defer" ValidationGroup="DefferGroup" class="btn btn-custom" OnClick="DeferQuestionBtn_Click" />
            </div>
            <div class="col-md-8">
                <asp:Label ID="Deferror" runat="server" Text="" Style="color: red"></asp:Label>
            </div>




        </div>
    </div>

   

    <div class="container" style="margin-bottom:5px;font-weight:bold">
         <div class=row>
          <div class="col-md-6" style="text-align:left">
              <asp:Label ID="InsertedByLbl" class="control-lbl-sm"  runat="server"></asp:Label>
        </div>
         <div class="col-md-6" style="text-align:right">
              <asp:Label ID="UpdatedByLbl" class="control-lbl-sm"  runat="server"></asp:Label>
        </div>
    </div>
        </div>
         <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-12">
                <asp:Label ID="errorlbl" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="UpdateGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Office Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" Required="true" ReadOnly="true" class="form-control small-control js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" ReadOnly="true" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2 bootstrap-timepicker">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Priority:</label>
                <asp:CheckBox ID="PriorityCB" class="form-control small-control" runat="server"></asp:CheckBox>

            </div>
        </div>

        <div class="row top-buffer">

            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt">Question ID:</label>
                <asp:TextBox ID="QuestionIDTxt" ReadOnly="true" Style="background-color: white" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestionDiaryNoTxt" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionDiaryNoTxt">Question Diary No:</label>
                <asp:TextBox ID="QuestionDiaryNoTxt" Style="background-color: white" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>

            <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>

            </div>
            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                        <asp:TextBox ID="DivisionTxt" Required="true" runat="server" CssClass="form-control"/> 
                        <asp:HiddenField ID="HidDivisionId" runat="server" /> 
                        
                </div>

             </div>--%>
            <div class="col-md-4">
                <asp:HiddenField ID="HidQuestionStatusId" runat="server" />
                <label class="control-lbl-sm" for="QuestionStatusDDL">Question Status:</label>

                <asp:DropDownList ID="QuestionStatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvQuestionStatusDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="QuestionStatusDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm">Reply Date:</label>
                <asp:TextBox ID="ReplyDateTxt" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" class="form-control small-control js-date" runat="server"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvReplyDateTxt" runat="server" ErrorMessage="Enter Reply Date" ValidationGroup="UpdateGroup" Display="None"  ControlToValidate="ReplyDateTxt"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="row top-buffer">

            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorStatusDDL">Senator Status:</label>
                 <asp:DropDownList ID="SenatorStatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Senator:</label>
                <div>
                    <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control" />
                    <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter member Name" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>

                    <asp:HiddenField ID="HidMemberId" runat="server" />
                    <asp:HiddenField ID="HidCurrentMemberId" runat="server" />

                </div>
            </div>
            <%--   <div class="col-md-4">
                   <label class="control-lbl-sm" for="SenatorDDL"></label>
                <div>
                 <asp:TextBox ID="NoOfQuestionsTxt" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>--%>

            <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Group:</label>
                <asp:DropDownList ID="GroupDDL" class="form-control small-control" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGroupDDL" runat="server" ErrorMessage="Select Group" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="GroupDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="DivisionDDL">Division:</label>
                <asp:DropDownList ID="DivisionDDL" class="form-control small-control" Required="true" runat="server" ValidationGroup="UpdateGroup">
                    <asp:ListItem Value="">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDivisionDDL" runat="server" ErrorMessage="Select Division" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="DivisionDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="row">
                <div class="col-md-12" style="text-align: center">
                    <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
                </div>
            </div>

        </div>
        <div class="row top-buffer">


            <%--  <div class="col-md-1">
                  <label class="control-lbl-sm" for="SenatorDDL">&nbsp</label>
                 <asp:Button ID="CheckGroupBtn" runat="server" class="btn btn-custom" Text="Assign" OnClick="CheckGroupBtn_Click" />
                
               
            </div>--%>
        </div>


    </div>


    <div class="container  regularDiv">
        <%-- <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm" for="SubjectMatterTxt">Subject Matter:</label>
                 <CKEditor:CKEditorControl ID="SubjectMatterTxt" BasePath="/ckeditor/" runat="server">
                 </CKEditor:CKEditorControl>
            </div>
        </div>--%>
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">English Text:</label>
                <%--<textarea id="QTxt" name="QTxt" runat="server"></textarea>--%>
                <%--<CKEditor:CKEditorControl ID="QTxt1" BasePath="~/ckeditor/" ClientIDMode="Inherit" ValidationGroup="UpdateGroup" runat="server" CausesValidation="False"></CKEditor:CKEditorControl>--%>
                <asp:RequiredFieldValidator ID="rfvQTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QTxt"></asp:RequiredFieldValidator>
                <textarea id="QTxt" name="QTxt" style="height: 300px;" class="form-control" rows="10" runat="server" required="required"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_QTxt').summernote(
                            {
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
                                toolbar: [
                                    ['pagebreak', ['pagebreak']], // The Button
                                    ['style', ['style']],
                                    ['font', ['bold', 'italic', 'underline', 'clear']],
                                    ['fontname', ['fontname']],
                                    ['fontsize', ['fontsize']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                    ['height', ['height']],
                                    ['table', ['table']],
                                    ['insert', ['media', 'link', 'hr']],
                                    ['view', ['fullscreen', 'codeview']],
                                    ['help', ['help']],
                                    ['print', ['print']],


                                ],
                                height: 300

                            });
                    });
                </script>

            </div>
        </div>
           <div class="row top-buffer">
            <div class="col-md-4">
                 <label class="control-lbl-sm">Urdu Text:</label>
                </div>
                <div class="col-md-6" style="text-align:right">
                    <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
                </div>
               
               </div>
        <div class="row top-buffer">
            <div class="col-md-12">
               
                <%--<textarea id="QTxt" name="QTxt" runat="server"></textarea>--%>
                <%--<CKEditor:CKEditorControl ID="QTxt1" BasePath="~/ckeditor/" ClientIDMode="Inherit" ValidationGroup="UpdateGroup" runat="server" CausesValidation="False"></CKEditor:CKEditorControl>--%>
                <textarea id="UrduTxt" name="UrduTxt" style="height: 300px;" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_UrduTxt').summernote(
                            {
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
                                toolbar: [
                                    ['pagebreak', ['pagebreak']], // The Button
                                    ['style', ['style']],
                                    ['font', ['bold', 'italic', 'underline', 'clear']],
                                    ['fontname', ['fontname']],
                                    ['fontsize', ['fontsize']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                    ['height', ['height']],
                                    ['table', ['table']],
                                    ['insert', ['media', 'link', 'hr']],
                                    ['view', ['fullscreen', 'codeview']],
                                    ['help', ['help']],



                                ],
                                height: 300

                            });
                    });
                </script>

            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12" id="imagediv">
               
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
            <asp:Button ID="UpdateQuestionBtn" runat="server" ValidationGroup="UpdateGroup" Text="Update" OnClick="UpdateQuestion_Click" class="btn btn-custom" />
            <%--<asp:Button ID="Button1" runat="server" Text="Update" ValidationGroup="UpdateGroup" OnClick="UpdateQuestion_Click" class="btn btn-custom"/>--%>
            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print" Cssclass="btn btn-custom" />
              <asp:HyperLink ID="PrintUrduHL" runat="server" Target="_blank" Text="Print Urdu" Cssclass="btn btn-custom" />
            <asp:HiddenField ID="HidQuestionFile" runat="server" />
        </div>
        <div class="col-md-2" style="text-align: right">
            <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete Question ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" />
        </div>
    </div>

    <br />
    <div class="container  regularDiv">
        <%--<div class="col-md-12">
                   <label class="control-lbl-sm">Reply Date:</label>
                <asp:TextBox ID="ReplyDateTxt"  Type="Date(dd/MM/YYYY)" ValidationGroup="Group1"  class="form-control small-control" runat="server"></asp:TextBox>
            </div>--%>
        <div class="col-md-12">
            <label class="control-lbl-sm" for="RepTxt">Reply:</label>
            <%--<CKEditor:CKEditorControl ID="RepTxt1" ClientIDMode="Inherit"   BasePath="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>--%>
            <textarea id="RepTxt" name="RepTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
            <script>
                $(document).ready(function () {
                    $('#ContentPlaceHolder3_RepTxt').summernote(
                        {

                            height: 200
                        });
                });
            </script>

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
                            <th>Question Status</th>
                            <th>Status Date</th>
                            <th>User</th>

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
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' />
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                    </td>
                                     <td>
                                        <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
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
                            <th>User</th>

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
                                     <td>
                                        <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
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
                <div class="page-header"><b>Defer History</b></div>
                <table class="table table-hover table-striped table-responsive">
                    <thead class="thead-inverse">
                        <tr>
                            <th>Sr#</th>
                            <th>Defered to Session No</th>
                            <th>Defered on</th>
                             <th>Defered by</th>
                            <th>User</th>
                            <th>Action</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="DeferLv" runat="server"
                            OnItemDeleting="ItemDeleting">

                            <ItemTemplate>
                                <tr>
                                    <td>

                                        <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        <asp:HiddenField ID="HidDeferId" runat="server" Value='<%#Eval("DeferId")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetSession(Convert.ToInt32(Eval("AssemblySessionId")))%>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DeferDate")))%>' />
                                    </td>
                                     <td>
                                        <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    </td>

                                </tr>
                            </ItemTemplate>

                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <br />

    <script type="text/javascript">
        $('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
            template: false,
            showInputs: false,
            minuteStep: 5
        });
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

</asp:Content>
