<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="NoticeQuestionDetails.aspx.cs" Inherits="QuestionManagement.NoticeQuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Summernote/summernote-bs4.js"></script>
    <link href="Summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="Summernote/summernote-lite.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>

    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
        .sim-card { background: #fff; border: 1px solid #e4e9ee; border-left: 4px solid #1f6fb5; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 18px; }
            .sim-card.sim-warn { border-left-color: #e69500; }
            .sim-card.sim-danger { border-left-color: #c0392b; }
            .sim-card.sim-ok { border-left-color: #2e8b57; }
        .sim-head { padding: 12px 18px; display: flex; align-items: center; flex-wrap: wrap; border-bottom: 1px solid #e4e9ee; background: #f8fafb; border-radius: 6px 6px 0 0; }
        .sim-title { font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; margin-right: 12px; }
        .sim-summary { font-size: 14px; font-weight: 600; color: #1f2d3d; }
        .sim-tools { margin-left: auto; display: flex; align-items: center; }
            .sim-tools label { font-size: 12px; color: #6b7785; font-weight: 600; margin: 0 6px 0 0; }
            .sim-tools select { width: 90px; display: inline-block; margin-right: 8px; }
        .sim-body { padding: 4px 18px 10px; }
        .sim-note { font-size: 12px; color: #6b7785; padding: 8px 0 0; }
        .sim-table { margin-bottom: 0; }
            .sim-table th { font-size: 11px; text-transform: uppercase; color: #6b7785; letter-spacing: .04em; }
            .sim-table td { font-size: 13px; vertical-align: top !important; }
        .sim-score { min-width: 64px; }
            .sim-score b { display: block; font-size: 16px; }
            .sim-bar { height: 5px; background: #e8edf2; border-radius: 3px; overflow: hidden; margin-top: 3px; }
            .sim-bar span { display: block; height: 100%; }
        .sim-high b { color: #c0392b; } .sim-high .sim-bar span { background: #c0392b; }
        .sim-mid b { color: #b87400; } .sim-mid .sim-bar span { background: #e69500; }
        .sim-low b { color: #1f6fb5; } .sim-low .sim-bar span { background: #1f6fb5; }
        .sim-preview { color: #3c4858; }
        .sim-common { font-size: 11px; color: #6b7785; margin-top: 3px; }
        .sim-card.sim-busy .sim-summary { opacity: .55; }

        /* file preview beside the editor */
        .qf-card { position: sticky; top: 8px; background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 20px; }
        .qf-head { padding: 9px 12px; background: #f8fafb; border-bottom: 1px solid #e4e9ee; border-radius: 6px 6px 0 0; display: flex; align-items: center; flex-wrap: wrap; }
        .qf-title { font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; margin-right: auto; }
        .qf-tools { display: flex; align-items: center; flex-wrap: wrap; }
            .qf-tools .btn { padding: 2px 8px; margin-left: 4px; }
            .qf-tools .qf-zoom { font-size: 12px; color: #6b7785; min-width: 42px; text-align: center; }
        .qf-view { height: calc(100vh - 120px); min-height: 420px; overflow: auto; background: #eef1f5; position: relative; }
        .qf-stage { position: relative; margin: 0 auto; }
        .qf-stage img { max-width: none; user-select: none; }
        .qf-view iframe { width: 100%; height: 100%; border: 0; background: #fff; }
        .qf-empty { padding: 40px 20px; text-align: center; color: #6b7785; font-size: 13px; }

        /* Read Text bar */
        .ocr-bar { display: flex; align-items: center; flex-wrap: wrap; background: #f3f7fc; border: 1px solid #d5e2f2; border-radius: 6px; padding: 10px 14px; margin: 8px 0 12px; }
        .ocr-info { flex: 1 1 260px; font-size: 13px; color: #3c4858; }
            .ocr-info b { color: #0c3a72; }
        .ocr-hint { display: block; font-size: 12px; color: #6b7785; margin-top: 2px; }
        .ocr-tools { display: flex; align-items: center; }
            .ocr-tools select { width: 110px; display: inline-block; margin-right: 8px; }
        .ocr-status { flex-basis: 100%; font-size: 12px; margin-top: 8px; }
            .ocr-status.ok { color: #2e7d4f; }
            .ocr-status.err { color: #c0392b; }
            .ocr-status.busy { color: #6b7785; }
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
            <div class="col-md-5 page-header" style="text-align: right">
                <%--  <button id="Movebtn" class="btn btn-custom">Revive</button>
                <button id="Defferbtn" class="btn btn-custom">Defer</button>--%>
                <asp:Button ID="TranslateBtn" Cssclass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>


        </div>

        <div class="row">
            <div class="col-md-1" style="text-align: left">
                <asp:Button ID="UpdateQuestionBtn" runat="server" ValidationGroup="UpdateGroup" Text="Update" OnClick="UpdateQuestion_Click" class="btn btn-custom" />
                <%--<asp:Button ID="Button1" runat="server" Text="Update" ValidationGroup="UpdateGroup" OnClick="UpdateQuestion_Click" class="btn btn-custom"/>--%>
            </div>
            <div class="col-md-1">
                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank"></asp:HyperLink>
                <asp:HiddenField ID="hidFileurl" runat="server" />
            </div>
            <div class="col-md-4" style="text-align: left">
                <asp:TextBox  PlaceHolder="Previous Question ID:" ID="PreviousQuestionsIdTxt" ValidationGroup="ReviveGroup" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Question ID" ValidationGroup="ReviveGroup" Display="Dynamic" Style="color: red" ControlToValidate="PreviousQuestionsIdTxt"></asp:RequiredFieldValidator>
                <div class="alert alert-danger" id="prviousIdError" runat="server" visible="false"></div>
                <div id="prevAutoNote" class="text-info" style="display: none; font-size: 12px; margin-top: 4px"></div>
            </div>
            <div class="col-md-1" style="text-align: left">
                <asp:Button ID="RevivedBtn" runat="server" ValidationGroup="ReviveGroup" Text="Revive" OnClick="RevivedBtn_Click" class="btn btn-info" />

                <%--  <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print" Cssclass="btn btn-custom" />

              <asp:HyperLink ID="PrintUrduHL" runat="server" Target="_blank" Text="Print Urdu" Cssclass="btn btn-custom" />--%>
            </div>
               <div class="col-md-1" style="text-align: left">
                <asp:Button ID="DuplicateBtn" runat="server" ValidationGroup="ReviveGroup" Text="Duplicate" OnClick="DuplicateBtn_Click" class="btn btn-info" />
                </div>
            <div class="col-md-4" style="text-align: right">
                <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete Question ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" />
            </div>
        </div>
    </div>
    <br />
    <%-- Similar questions in the current and previous 10 sessions. Checks the text while it is being typed. --%>
    <div class="container">
        <div id="simCard" class="sim-card">
            <div class="sim-head">
                <span class="sim-title">Similar questions &middot; current + previous 10 sessions</span>
                <span id="simSummary" class="sim-summary">Type or paste the question text below - similar questions will appear here automatically.</span>
                <div class="sim-tools">
                    <label for="simThreshold">Minimum match</label>
                    <select id="simThreshold" class="form-control small-control">
                        <option value="40">40%</option>
                        <option value="50" selected="selected">50%</option>
                        <option value="60">60%</option>
                        <option value="70">70%</option>
                        <option value="80">80%</option>
                    </select>
                    <button type="button" id="simCheckBtn" class="btn btn-default">Check now</button>
                </div>
            </div>
            <div class="sim-body" id="simBody" style="display: none">
                <table class="table table-hover sim-table">
                    <thead>
                        <tr>
                            <th>Match</th>
                            <th>QID</th>
                            <th>Session</th>
                            <th>Submitted by</th>
                            <th>Question</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="simRows"></tbody>
                </table>
                <div class="sim-note">"Use ID" copies the question number into the <b>Previous Question ID</b> box above, so you can Revive it or mark this one as Duplicate.</div>
            </div>
        </div>
    </div>
    <br />
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
                <asp:DropDownList ID="AssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                </asp:DropDownList>
                <asp:HiddenField ID="DeviceId" runat="server" />
                <%--<asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />--%>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Office Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ReadOnly="true" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" Required="true" class="form-control small-control js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
                <asp:TextBox ID="NoticeDiaryTimeTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionDiaryNoTxt">Question Diary No:</label>
                <asp:TextBox ID="QuestionDiaryNoTxt" Style="background-color: white" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>

            </div>
         <%--   <div class="col-md-2 bootstrap-timepicker">
                <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Priority:</label>
                <asp:CheckBox ID="PriorityCB" class="form-control small-control" runat="server"></asp:CheckBox>

            </div>--%>
        </div>

        <div class="row top-buffer">

            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt">Assigned Question ID:</label>
                <asp:TextBox ID="QuestionIDTxt" Style="background-color: white" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuestionDiaryNoTxt" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>

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
            <%--   <div class="col-md-4">
                <asp:HiddenField ID="HidQuestionStatusId" runat="server" />
                <label class="control-lbl-sm" for="QuestionStatusDDL">Question Status:</label>

                <asp:DropDownList ID="QuestionStatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvQuestionStatusDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="QuestionStatusDDL"></asp:RequiredFieldValidator>

            </div>--%>
        </div>
        <div class="row top-buffer">

            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorStatusDDL">Senator Status:</label>
                 <asp:DropDownList ID="SenatorStatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>--%>

            <%--   <div class="col-md-4">
                   <label class="control-lbl-sm" for="SenatorDDL"></label>
                <div>
                 <asp:TextBox ID="NoOfQuestionsTxt" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>--%>

         <%--   <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Group:</label>
                <asp:DropDownList ID="GroupDDL" class="form-control small-control" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGroupDDL" runat="server" ErrorMessage="Select Group" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="GroupDDL"></asp:RequiredFieldValidator>

            </div>--%>
              <div class="col-md-6">
                <label class="control-lbl-sm" for="SenatorDDL">Senator:</label>

                <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control" />
                <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter member Name" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>

                <asp:HiddenField ID="HidMemberId" runat="server" />
                <asp:HiddenField ID="HidCurrentMemberId" runat="server" />

            </div>
            <div class="col-md-6">
                <label class="control-lbl-sm" for="DivisionDDL">Division:</label>
               <%-- <asp:DropDownList ID="DivisionDDL" class="form-control small-control" AutoPostBack="true" OnSelectedIndexChanged="DivisionDDL_SelectedIndexChanged" Required="true" runat="server" ValidationGroup="UpdateGroup">
                    <asp:ListItem Value="">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDivisionDDL" runat="server" ErrorMessage="Select Division" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="DivisionDDL"></asp:RequiredFieldValidator>--%>
                 <asp:TextBox ID="DivisionTxt" Required="true" runat="server" CssClass="form-control small-control"/> 
                 <asp:HiddenField ID="HidDivisionId" runat="server" /> 
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


    <div class="container qf-wrap">
    <div class="row">
    <div class="col-md-5" id="qfPane">
        <div class="qf-card" id="qfCard">
            <div class="qf-head">
                <span class="qf-title">Attached file</span>
                <div class="qf-tools">
                    <span id="qfImageTools">
                        <button type="button" class="btn btn-default btn-sm" id="qfZoomOut" title="Zoom out">&minus;</button>
                        <span class="qf-zoom" id="qfZoomLbl">Fit</span>
                        <button type="button" class="btn btn-default btn-sm" id="qfZoomIn" title="Zoom in">+</button>
                        <button type="button" class="btn btn-default btn-sm" id="qfFit" title="Fit to width">Fit</button>
                        <button type="button" class="btn btn-default btn-sm" id="qfRotL" title="Rotate left">&#8634;</button>
                        <button type="button" class="btn btn-default btn-sm" id="qfRotR" title="Rotate right">&#8635;</button>
                    </span>
                    <a class="btn btn-default btn-sm" id="qfOpen" target="_blank" href="#" title="Open in a new tab">Open &#8599;</a>
                    <button type="button" class="btn btn-default btn-sm" id="qfHide" title="Hide the file and use the full width">Hide</button>
                </div>
            </div>
            <div class="qf-view" id="qfView"></div>
        </div>
    </div>
    <div class="col-md-7" id="qfEditor">
    <div class="regularDiv">
        <div class="ocr-bar">
            <div class="ocr-info">
                <b>Question text</b> &mdash; read it from the attached file, or type it yourself.
                <span class="ocr-hint">Reading works best on clear printed text. Handwriting is often read wrongly, so type it while looking at the file. Always check the result.</span>
            </div>
            <div class="ocr-tools">
                <button type="button" class="btn btn-default btn-sm" id="qfShow" style="display: none; margin-right: 8px">Show file</button>
                <select id="ocrLang" class="form-control small-control" title="Language of the text in the file">
                    <option value="eng">English</option>
                    <option value="urd">Urdu</option>
                </select>
                <button type="button" class="btn btn-info" id="ocrBtn">Read Text</button>
            </div>
            <div class="ocr-status" id="ocrStatus"></div>
        </div>
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
            <div class="col-md-6" style="text-align: right">
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
                                height: 300

                            });
                    });
                </script>

            </div>
        </div>

    </div>
    </div>
    </div>
    </div>
    <br />

    <br />
    <br />
    <script type="text/javascript">
        function useAsPrevious(id) {
            var box = $("[id$=PreviousQuestionsIdTxt]");
            box.val(id).focus();
            $('html, body').animate({ scrollTop: box.offset().top - 120 }, 250);
            return false;
        }

        // ---- Attached file preview + Read Text (OCR) ------------------------------------
        (function () {
            var file = ($('[id$=hidFileurl]').val() || '').trim();
            var m = /[?&]QuestionsId=(\d+)/i.exec(location.search);
            var questionId = m ? parseInt(m[1], 10) : 0;
            var ext = file ? file.split('?')[0].split('.').pop().toLowerCase() : '';
            var isPdf = ext === 'pdf';
            var isImage = /^(jpe?g|png|gif|bmp|webp)$/.test(ext);
            var $view = $('#qfView');
            var zoom = 1, rot = 0, natW = 0, natH = 0, $img = null, $stage = null;

            $('#qfOpen').attr('href', file || '#');
            if (!file) $('#qfOpen').hide();

            function layout() {
                if (!$img || !natW) return;
                var boxW = Math.max(200, $view.width() - 6);
                var w = Math.round(boxW * zoom), h = Math.round(w * natH / natW);
                var swap = rot % 180 !== 0;
                $stage.css({ width: swap ? h : w, height: swap ? w : h });
                var t = rot === 0 ? 'none'
                      : rot === 90 ? 'translate(' + h + 'px,0) rotate(90deg)'
                      : rot === 180 ? 'translate(' + w + 'px,' + h + 'px) rotate(180deg)'
                      : 'translate(0,' + w + 'px) rotate(270deg)';
                $img.css({ position: 'absolute', left: 0, top: 0, width: w, height: h, transformOrigin: '0 0', transform: t });
                $('#qfZoomLbl').text(zoom === 1 ? 'Fit' : Math.round(zoom * 100) + '%');
            }

            if (!file) {
                $view.html('<div class="qf-empty">No file is attached to this question.</div>');
                $('#qfImageTools').hide();
            } else if (isPdf) {
                $view.html('<iframe title="Attached file" src="' + file.replace(/"/g, '&quot;') + '#toolbar=1&navpanes=0&view=FitH"></iframe>');
                $('#qfImageTools').hide();
            } else if (isImage) {
                $stage = $('<div class="qf-stage"></div>').appendTo($view);
                $img = $('<img alt="Attached file" />').appendTo($stage);
                $img.on('load', function () { natW = this.naturalWidth; natH = this.naturalHeight; layout(); });
                $img.attr('src', file);
                $(window).on('resize', layout);
                $('#qfZoomIn').on('click', function () { zoom = Math.min(zoom * 1.25, 6); layout(); });
                $('#qfZoomOut').on('click', function () { zoom = Math.max(zoom / 1.25, 0.3); layout(); });
                $('#qfFit').on('click', function () { zoom = 1; layout(); });
                $('#qfRotR').on('click', function () { rot = (rot + 90) % 360; layout(); });
                $('#qfRotL').on('click', function () { rot = (rot + 270) % 360; layout(); });
            } else {
                $view.html('<div class="qf-empty">This kind of file cannot be shown here.<br />Use <b>Open</b> to view it in a new tab.</div>');
                $('#qfImageTools').hide();
            }

            $('#qfHide').on('click', function () {
                $('#qfPane').hide();
                $('#qfEditor').removeClass('col-md-7').addClass('col-md-12');
                $('#qfShow').show();
            });
            $('#qfShow').on('click', function () {
                $('#qfPane').show();
                $('#qfEditor').removeClass('col-md-12').addClass('col-md-7');
                $('#qfShow').hide();
                layout();
            });

            // ---- Read Text ----
            var $btn = $('#ocrBtn'), $status = $('#ocrStatus');
            function status(kind, text) { $status.removeClass('ok err busy').addClass(kind).text(text); }
            function editor(sel) { return $(sel); }
            function getHtml(sel) { try { return editor(sel).summernote('code'); } catch (e) { return editor(sel).val() || ''; } }
            function setHtml(sel, html) { try { editor(sel).summernote('code', html); } catch (e) { editor(sel).val(html); } }
            function plain(html) { return $('<div>').html(html || '').text().replace(/\s+/g, ' ').trim(); }

            $btn.on('click', function () {
                if (!file) { status('err', 'There is no file attached to read.'); return; }
                if (!isPdf && !isImage) { status('err', 'This kind of file cannot be read. Please type the text.'); return; }
                var lang = $('#ocrLang').val();
                var target = lang === 'urd' ? '#ContentPlaceHolder3_UrduTxt' : '#ContentPlaceHolder3_QTxt';
                $btn.prop('disabled', true).text('Reading...');
                status('busy', 'Reading text from the file - this can take up to a minute...');
                $.ajax({
                    url: 'NoticeQuestionDetails.aspx/ReadQuestionText',
                    type: 'POST', dataType: 'json', contentType: 'application/json; charset=utf-8', timeout: 180000,
                    data: JSON.stringify({ questionId: questionId, language: lang, rotation: isImage ? rot : 0 }),
                    success: function (res) {
                        var r = res.d;
                        if (!r || !r.Success) { status('err', (r && r.Message) || 'The file could not be read. Please type the text.'); return; }
                        var existing = getHtml(target);
                        if (plain(existing)) {
                            if (confirm('The ' + (lang === 'urd' ? 'Urdu' : 'English') + ' text box already has text.\n\nOK = replace it with the text read from the file\nCancel = add the new text below the existing text'))
                                setHtml(target, r.Html);
                            else
                                setHtml(target, existing + r.Html);
                        } else {
                            setHtml(target, r.Html);
                        }
                        status('ok', 'Text read from ' + r.Pages + ' page(s). Please check it carefully against the file and correct any mistakes.');
                    },
                    error: function () { status('err', 'Reading failed or took too long. Please type the text.'); },
                    complete: function () { $btn.prop('disabled', false).text('Read Text'); }
                });
            });
        })();

        // ---- Live similar-question check ------------------------------------------------
        // Reads the question text from the editor, waits until typing pauses, then asks the
        // server (NoticeQuestionDetails.aspx/CheckSimilar) for similar questions - no copy/paste needed.
        (function () {
            var lastChecked = null, lastSeen = null, seq = 0;
            var $card = $('#simCard'), $summary = $('#simSummary'), $body = $('#simBody'), $rows = $('#simRows');

            function esc(s) { return $('<div>').text(s == null ? '' : String(s)).html(); }
            function editorText() {
                try { return $('#ContentPlaceHolder3_QTxt').summernote('code'); }
                catch (e) { return $('#ContentPlaceHolder3_QTxt').val() || ''; }
            }
            function scoreClass(n) { return n >= 80 ? 'sim-high' : n >= 60 ? 'sim-mid' : 'sim-low'; }
            function state(kind, message) {
                $card.removeClass('sim-ok sim-warn sim-danger');
                if (kind) $card.addClass('sim-' + kind);
                $summary.text(message);
            }

            // ---- Autofill "Previous Question ID" when a very close match (likely duplicate) is found ----
            // Only fills an empty box, never replaces something the user typed or chose, and takes back its own
            // value if the text is edited so that the match disappears. Nothing is revived or marked duplicate
            // until the user clicks Revive or Duplicate.
            var AUTOFILL_MIN = 80, autoId = null, userTyped = false;
            $(document).on('input', '[id$=PreviousQuestionsIdTxt]', function () { userTyped = true; autoId = null; $('#prevAutoNote').hide(); });
            function autofill(best) {
                var $p = $('[id$=PreviousQuestionsIdTxt]'), cur = $.trim($p.val()), $note = $('#prevAutoNote');
                if (userTyped) return;
                if (best && best.Score >= AUTOFILL_MIN) {
                    if (!cur || cur === '0' || cur === String(autoId)) {
                        $p.val(best.QuestionsId);
                        autoId = best.QuestionsId;
                        $p.css('background-color', '#fff8d6');
                        setTimeout(function () { $p.css('background-color', ''); }, 1800);
                        $note.text('Filled automatically with QID ' + best.QuestionsId + ' (' + best.Score + '% match). Change or clear it if this is not a duplicate.').show();
                    }
                } else if (autoId !== null && cur === String(autoId)) {
                    $p.val('');
                    autoId = null;
                    $note.hide();
                }
            }

            function render(r) {
                var m = r.Matches || [];
                if (r.TextTooShort) {
                    autofill(null);
                    $body.hide();
                    state('', 'Type or paste the question text below - similar questions will appear here automatically.');
                    return;
                }
                if (!m.length) {
                    autofill(null);
                    $body.hide();
                    state('ok', 'No similar question found (' + $('#simThreshold').val() + '% or more)');
                    return;
                }
                autofill(m[0]);
                var top = m[0].Score, html = '';
                for (var i = 0; i < m.length; i++) {
                    var q = m[i];
                    html += '<tr>' +
                        '<td class="sim-score ' + scoreClass(q.Score) + '"><b>' + q.Score + '%</b><div class="sim-bar"><span style="width:' + q.Score + '%"></span></div></td>' +
                        '<td>' + q.QuestionsId + '</td>' +
                        '<td>' + esc(q.SessionNumber) + '</td>' +
                        '<td>' + esc(q.MoverName) + '</td>' +
                        '<td><div class="sim-preview">' + esc(q.Preview) + '</div><div class="sim-common">Common words: ' + esc(q.CommonWords) + '</div></td>' +
                        '<td>' + esc(q.Status) + '</td>' +
                        '<td style="white-space:nowrap"><a class="btn btn-default btn-xs" target="_blank" href="QuestionDetails.aspx?QuestionsId=' + q.QuestionsId + '">Open</a> ' +
                        '<a class="btn btn-info btn-xs" href="#" onclick="return useAsPrevious(' + q.QuestionsId + ');">Use ID</a></td></tr>';
                }
                $rows.html(html);
                $body.show();
                state(top >= 80 ? 'danger' : 'warn',
                    m.length + ' similar question(s) found' + (top >= 80 ? ' - possible duplicate' : '') + ', best match ' + top + '%');
            }

            function run() {
                var text = editorText(), my = ++seq;
                lastChecked = text;
                $card.addClass('sim-busy');
                $.ajax({
                    url: 'NoticeQuestionDetails.aspx/CheckSimilar',
                    type: 'POST', dataType: 'json', contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ text: text, threshold: parseInt($('#simThreshold').val(), 10) }),
                    success: function (res) { if (my === seq) render(res.d); },
                    error: function () { if (my === seq) { $body.hide(); state('', 'Could not check for similar questions right now.'); } },
                    complete: function () { if (my === seq) $card.removeClass('sim-busy'); }
                });
            }

            // Editor plugins differ between pages, so watch the text instead of relying on one editor event:
            // when it has stopped changing for one tick (about a second) and differs from the last check, run.
            setInterval(function () {
                var t = editorText();
                if (t === lastSeen && t !== lastChecked) run();
                lastSeen = t;
            }, 1000);

            $('#simCheckBtn').on('click', run);
            $('#simThreshold').on('change', run);
            $(window).on('load', function () { setTimeout(run, 400); });
        })();
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

