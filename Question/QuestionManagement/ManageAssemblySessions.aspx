<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageAssemblySessions.aspx.cs" Inherits="QuestionManagement.ManageAssemblySessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        .ms-card { border-radius: 12px; }
        .ms-card .panel-heading { font-weight: 700; letter-spacing: .5px; color: var(--brand-dark); }
        .ms-lbl { display: block; margin-bottom: 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .ms-fact { margin-bottom: 14px; }
        .ms-fact .ms-val { font-size: 20px; font-weight: 700; color: var(--brand-dark); }
        .ms-card .form-control { width: 100%; }
        .ms-hint { color: #6b7a8c; font-size: 12.5px; margin-top: 4px; }
        .ms-picker { border: 1px solid var(--line); border-radius: 10px; background: #f9fbfd; padding: 10px; }
        .ms-picker-tools { display: flex; flex-wrap: wrap; gap: 6px; align-items: center; margin-bottom: 8px; }
        .ms-picker-tools .form-control { flex: 1 1 140px; min-width: 120px; }
        .ms-picker-count { margin-left: auto; font-weight: 700; color: var(--brand-dark); }
        .ms-list { max-height: 260px; overflow-y: auto; }
        .ms-list ul { list-style: none; margin: 0; padding: 0; display: flex; flex-wrap: wrap; }
        .ms-list li { width: 50%; position: relative; }
        .ms-list label { display: block; margin: 3px 4px; padding: 7px 10px 7px 32px; position: relative; font-weight: 600; background: #fff; border: 1px solid var(--line); border-radius: 8px; cursor: pointer; }
        .ms-list input[type=checkbox] { position: absolute; left: 14px; top: 50%; margin: -6px 0 0; z-index: 1; }
        .ms-list label:hover { border-color: var(--brand); }
        .ms-list label.on { background: #e8f2fd; border-color: var(--brand); color: var(--brand-dark); }
        .ms-actions { display: flex; gap: 8px; flex-wrap: wrap; margin-top: 6px; }
        .ms-confirm { border-radius: 12px; }
        @media (max-width: 767px) { .ms-list li { width: 100%; } .ms-actions .btn { flex: 1; } }
    </style>
    <script type="text/javascript">
        $(function () {
            var $q = $('#<%= BusinessDDL.ClientID %>'), $r = $('#<%= ResolutionsDDL.ClientID %>'), $m = $('#<%= MotionsDDL.ClientID %>');
            var $box = $('#<%= BusinessSessionsdiv.ClientID %>'), $list = $('#<%= BusinessSessionsLB.ClientID %>');

            function checks() { return $list.find('input[type=checkbox]'); }
            function refresh() {
                var n = 0;
                checks().each(function () {
                    $(this).closest('li').find('label').toggleClass('on', this.checked);
                    if (this.checked) { n++; }
                });
                $('#msCount').text(n + ' selected');
            }
            function toggle() {
                if ($q.val() === '1' || $m.val() === '1' || $r.val() === '1') { $box.show(); } else { $box.hide(); }
            }
            $q.on('change', toggle);
            $r.on('change', toggle);
            $m.on('change', toggle);
            $list.on('change', 'input[type=checkbox]', refresh);
            $('#msAll').on('click', function () { checks().filter(':visible').prop('checked', true); refresh(); });
            $('#msNone').on('click', function () { checks().prop('checked', false); refresh(); });
            $('#msFilter').on('input', function () {
                var term = $.trim($(this).val()).toLowerCase();
                $list.find('li').each(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(term) > -1);
                });
            });
            toggle();
            refresh();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Panel ID="MessagePnl" runat="server" Visible="false" CssClass="alert alert-success" role="alert">
        <span class="glyphicon glyphicon-info-sign"></span>&nbsp;<asp:Label ID="MessageLbl" runat="server" Font-Bold="true"></asp:Label>
    </asp:Panel>

    <div class="row">
        <div class="col-md-4">
            <div class="panel panel-default ms-card">
                <div class="panel-heading"><span class="glyphicon glyphicon-calendar"></span> CURRENT SESSION</div>
                <div class="panel-body">
                    <div class="ms-fact">
                        <span class="ms-lbl">Legislative Year</span>
                        <asp:Label ID="LegislativeYear" runat="server" CssClass="ms-val" Text="Session" />
                        <asp:HiddenField ID="HidParliamentaryYearId" runat="server" />
                    </div>
                    <div class="ms-fact">
                        <span class="ms-lbl">Session No</span>
                        <asp:Label ID="AssemblySessionLbl" runat="server" CssClass="ms-val" Text="" />
                        <asp:HiddenField ID="HidAssemblySessionId" runat="server" />
                    </div>
                    <div class="ms-fact">
                        <label class="ms-lbl" for="<%= CalledByDDL.ClientID %>">Session Type</label>
                        <asp:DropDownList ID="CalledByDDL" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="Government">Government</asp:ListItem>
                            <asp:ListItem Value="Requisition">Requisition</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="ms-fact">
                        <label class="ms-lbl" for="<%= StartDateTxt.ClientID %>">Start Date</label>
                        <asp:TextBox CssClass="form-control js-date" ID="StartDateTxt" runat="server"></asp:TextBox>
                    </div>
                    <div class="ms-fact">
                        <label class="ms-lbl" for="<%= EndDateTxt.ClientID %>">Prorogation Date</label>
                        <asp:TextBox ID="EndDateTxt" CssClass="form-control js-date" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-8">
            <div class="panel panel-default ms-card">
                <div class="panel-heading"><span class="glyphicon glyphicon-transfer"></span> WHAT HAPPENS TO PENDING BUSINESS</div>
                <div class="panel-body">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="SaveGroup" DisplayMode="BulletList" ForeColor="Red" />
                    <div class="row">
                        <div class="col-sm-4 ms-fact">
                            <label class="ms-lbl" for="<%= BusinessDDL.ClientID %>">Questions</label>
                            <asp:DropDownList ID="BusinessDDL" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                <asp:ListItem Value="2">Lapse</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select whether Questions are carried forward or lapsed" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BusinessDDL"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4 ms-fact">
                            <label class="ms-lbl" for="<%= MotionsDDL.ClientID %>">Motions</label>
                            <asp:DropDownList ID="MotionsDDL" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                <asp:ListItem Value="2">Lapse</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select whether Motions are carried forward or lapsed" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionsDDL"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4 ms-fact">
                            <label class="ms-lbl" for="<%= ResolutionsDDL.ClientID %>">Resolutions</label>
                            <asp:DropDownList ID="ResolutionsDDL" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                <asp:ListItem Value="2">Lapse</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select whether Resolutions are carried forward or lapsed" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionsDDL"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div id="BusinessSessionsdiv" runat="server" class="ms-fact" style="display: none">
                        <span class="ms-lbl">Sessions whose business is carried forward</span>
                        <div class="ms-picker">
                            <div class="ms-picker-tools">
                                <input type="text" id="msFilter" class="form-control input-sm" placeholder="Find a session..." autocomplete="off" />
                                <button type="button" id="msAll" class="btn btn-default btn-sm">Select all</button>
                                <button type="button" id="msNone" class="btn btn-default btn-sm">Clear</button>
                                <span id="msCount" class="ms-picker-count">0 selected</span>
                            </div>
                            <div class="ms-list">
                                <asp:CheckBoxList ID="BusinessSessionsLB" runat="server" RepeatLayout="UnorderedList"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="ms-hint">Business still pending in the ticked sessions moves into the new session. Sessions carried into the current session are ticked for you.</div>
                    </div>

                    <div class="ms-actions">
                        <asp:Button ID="Prorogue1" runat="server" CssClass="btn btn-custom" Text="Prorogue Session" OnClick="Prorogue1_Click" ValidationGroup="SaveGroup" />
                    </div>
                </div>
            </div>

            <div class="panel panel-warning ms-confirm" id="confirmdiv" runat="server">
                <div class="panel-heading"><span class="glyphicon glyphicon-warning-sign"></span> CONFIRM PROROGATION</div>
                <div class="panel-body">
                    <p>Are you sure you want to prorogue the session?</p>
                    <p><asp:Label ID="confirmlabel" runat="server" Text="" Font-Bold="true"></asp:Label></p>
                    <div class="ms-actions">
                        <asp:Button ID="ProrogueBtn" CssClass="btn btn-custom" runat="server" Text="Yes, Prorogue Session" OnClick="ProrogueBtn_Click" UseSubmitBehavior="false" OnClientClick="this.disabled = true; this.value = 'Prorogating...'; return true;" />
                        <asp:Button ID="NoBtn" CssClass="btn btn-default" runat="server" Text="No" OnClick="NoBtn_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
