<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NoticeResolutionDetail.aspx.cs" Inherits="QuestionManagement.NoticeResolutionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <style>
        .nrd-header { margin: 6px 0 18px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .nrd-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .nrd-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .nrd-header .nrd-header-actions { float: right; margin-top: 4px; }

        .nrd-toolbar {
            background: #fff;
            border: 1px solid #e4e9ee;
            border-radius: 6px;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            padding: 12px 16px;
            margin-bottom: 20px;
            display: flex;
            flex-wrap: wrap;
            align-items: center;
        }
            .nrd-toolbar .nrd-group { display: flex; align-items: center; margin: 4px 16px 4px 0; }
            .nrd-toolbar .nrd-group .btn, .nrd-toolbar .nrd-group input { margin-right: 8px; }
            .nrd-toolbar .nrd-divider { width: 1px; align-self: stretch; background: #e4e9ee; margin: 0 16px 0 0; }
            .nrd-toolbar .nrd-revive-id { width: 220px; display: inline-block; }
            .nrd-toolbar .nrd-shortcut { margin-left: auto; font-size: 12px; color: #6b7785; }

        .nrd-card {
            background: #fff;
            border: 1px solid #e4e9ee;
            border-radius: 6px;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            margin-bottom: 20px;
        }
        .nrd-card-title {
            padding: 11px 18px;
            border-bottom: 1px solid #e4e9ee;
            background: #f8fafb;
            border-radius: 6px 6px 0 0;
            font-size: 12px;
            font-weight: 700;
            letter-spacing: .08em;
            text-transform: uppercase;
            color: #0c3a72;
        }
        .nrd-card-body { padding: 16px 18px 6px; }
            .nrd-card-body .form-group { margin-bottom: 14px; }
            .nrd-card-body label { font-size: 13px; font-weight: 600; color: #3c4858; margin-bottom: 4px; }
            .nrd-card-body .form-control[readonly] { background: #f3f6f8; }
            .nrd-card-body select[multiple], .nrd-card-body .nrd-movers { min-height: 84px; }

        .nrd-error { color: #c0392b; font-size: 13px; text-align: center; margin-bottom: 10px; }
        .nrd-urdu-label { color: #6b7785; font-weight: 400; margin-left: 6px; }
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

        <div class="nrd-header">
            <div class="nrd-header-actions">
                <asp:Button ID="TranslateBtn" CssClass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                <asp:Label ID="Label2" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>
            <h3>Resolution Details</h3>
            <p>Notice Office resolution &middot; review, edit and process</p>
        </div>

        <div class="nrd-toolbar">
            <div class="nrd-group">
                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                <asp:HiddenField ID="HidResolutionFile" runat="server" />
            </div>
            <div class="nrd-divider"></div>
            <div class="nrd-group">
                <asp:TextBox PlaceHolder="Previous Resolution ID" ID="PreviousResolutionIdTxt" ValidationGroup="ReviveGroup" class="form-control nrd-revive-id" runat="server"></asp:TextBox>
                <asp:Button ID="RevivedBtn" runat="server" ValidationGroup="ReviveGroup" Text="Revive" OnClick="RevivedBtn_Click" class="btn btn-info" />
                <asp:Button ID="DuplicateBtn" runat="server" ValidationGroup="ReviveGroup" Text="Duplicate" OnClick="DuplicateBtn_Click" class="btn btn-info" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Resolution ID" ValidationGroup="ReviveGroup" Display="Dynamic" Style="color: red" ControlToValidate="PreviousResolutionIdTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="nrd-shortcut">Ctrl + S to save</div>
        </div>
        <div class="alert alert-danger" id="prviousIdError" runat="server" visible="false"></div>

        <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
            EnableClientScript="true"
            HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />

        <div class="nrd-card">
            <div class="nrd-card-title">Notice Office Details</div>
            <div class="nrd-card-body">
                <div class="row">
                    <div class="col-md-3 form-group">
                        <label for="SessionDDL">Session No</label>
                        <asp:DropDownList ID="SessionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryNoTxt">Notice Office Diary No</label>
                        <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" class="form-control control-txt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryDateTxt">Notice Office Diary Date</label>
                        <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt js-date" runat="server"></asp:TextBox>
                        <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryTimeTxt">Notice Office Diary Time</label>
                        <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>

        <div class="nrd-card">
            <div class="nrd-card-title">Resolution Information</div>
            <div class="nrd-card-body">
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label for="ResolutionTypeDDL">Resolution Type</label>
                        <asp:DropDownList ID="ResolutionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="ResolutionStatusDDL">Resolution Status</label>
                        <asp:DropDownList ID="ResolutionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5 form-group">
                        <label for="MoversLB">Resolution Movers</label>
                        <asp:ListBox ID="MoversLB" runat="server" class="form-control nrd-movers" placeholder="Members"></asp:ListBox>
                    </div>
                </div>
                <div class="nrd-error">
                    <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row" id="qfRow">
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
        <div class="nrd-card">
            <div class="nrd-card-title">Resolution Text</div>
            <div class="nrd-card-body">
        <div class="ocr-bar">
            <div class="ocr-info">
                <b>Resolution text</b> &mdash; read it from the attached file, or type it yourself.
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
                <div class="form-group">
                    <label>English Text</label>
                    <textarea id="ResolutionTxt" name="QuestionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder3_ResolutionTxt').summernote(
                                {
                                    height: 300
                                });
                        });
                    </script>
                    <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Urdu Text <asp:Label ID="UrduLbl" class="text-danger nrd-urdu-label" Visible="false" runat="server"></asp:Label></label>
                    <textarea id="UrduTxt" name="UrduTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder3_UrduTxt').summernote(
                                {
                                    height: 300,

                                });
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
        </div>
    </div>

<script type="text/javascript">
        // ---- Attached file preview + Read Text (OCR) ------------------------------------
        (function () {
            var file = ($('[id$=HidResolutionFile]').val() || '').trim();
            var m = /[?&]ResolutionId=(\d+)/i.exec(location.search);
            var resolutionId = m ? parseInt(m[1], 10) : 0;
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
                $view.html('<div class="qf-empty">No file is attached to this resolution.</div>');
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
                var target = lang === 'urd' ? '#ContentPlaceHolder3_UrduTxt' : '#ContentPlaceHolder3_ResolutionTxt';
                $btn.prop('disabled', true).text('Reading...');
                status('busy', 'Reading text from the file - this can take up to a minute...');
                $.ajax({
                    url: 'NoticeResolutionDetail.aspx/ReadResolutionText',
                    type: 'POST', dataType: 'json', contentType: 'application/json; charset=utf-8', timeout: 180000,
                    data: JSON.stringify({ resolutionId: resolutionId, language: lang, rotation: isImage ? rot : 0 }),
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
