<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageGroups.aspx.cs" Inherits="QuestionManagement.ManageGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mg-header { margin: 6px 0 16px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; }
            .mg-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .mg-header p { margin: 0; font-size: 14px; color: #6b7785; }

        .mg-session { display: flex; align-items: center; flex-wrap: wrap; background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); padding: 12px 18px; margin-bottom: 18px; }
            .mg-session label { font-size: 13px; font-weight: 600; color: #3c4858; margin: 0 12px 0 0; }
            .mg-session select { width: 160px; display: inline-block; font-weight: 600; }
            .mg-session .mg-hint { margin-left: 16px; font-size: 13px; color: #6b7785; }

        .mg-msg { margin-bottom: 14px; padding: 9px 14px; border-radius: 6px; font-size: 13px; }
            .mg-msg.ok { background: #e6f4ea; color: #23663c; border: 1px solid #c5e5cf; }
            .mg-msg.err { background: #fdecea; color: #a5281b; border: 1px solid #f3c6c1; }

        .mg-card { background: #fff; border: 1px solid #e4e9ee; border-left: 4px solid var(--g, #0c3a72); border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 16px; }
        .mg-card-title { display: flex; align-items: center; justify-content: space-between; padding: 10px 16px; background: #f8fafb; border-bottom: 1px solid #e4e9ee; border-radius: 0 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: var(--g, #0c3a72); }
        .mg-card-body { padding: 12px 16px; }
        .mg-count { display: inline-block; min-width: 26px; text-align: center; background: var(--g, #0c3a72); color: #fff; border-radius: 12px; padding: 1px 9px; font-size: 12px; letter-spacing: 0; }
        .mg-g1 { --g: #1f6fb5; } .mg-g2 { --g: #2e8b57; } .mg-g3 { --g: #c98200; } .mg-g4 { --g: #7b4fb0; } .mg-g5 { --g: #12867f; }
        .mg-avail { --g: #0c3a72; position: sticky; top: 8px; }
        .mg-avail .mg-list { height: 560px; }
        .mg-group-list { height: 150px; }
        .mg-card select option { padding: 4px 6px; }
        .mg-search { margin-bottom: 8px; }
        .mg-actions { margin-top: 10px; display: flex; gap: 8px; flex-wrap: wrap; }
        .mg-note { font-size: 12px; color: #6b7785; margin-top: 6px; }
    </style>
    <script type="text/javascript">
        $(function () {
            // number of divisions in every list
            function counts() {
                $('[data-count-for]').each(function () {
                    var lb = $('[id$=' + $(this).data('count-for') + ']')[0];
                    $(this).text(lb ? lb.options.length : 0);
                });
            }
            counts();

            // filter the available divisions while typing (options are hidden, not removed, so the page still posts correctly)
            $('#mgSearch').on('input', function () {
                var q = $.trim(this.value).toLowerCase(), shown = 0;
                $('#<%= DivisionsCB.ClientID %> option').each(function () {
                    var ok = !q || this.text.toLowerCase().indexOf(q) !== -1;
                    this.style.display = ok ? '' : 'none';
                    this.disabled = !ok;
                    if (ok) shown++;
                });
                $('#mgShown').text(q ? shown + ' match' + (shown === 1 ? '' : 'es') : '');
            });
        });

        function mgConfirmRemove(listId, group) {
            var lb = $('[id$=' + listId + ']')[0];
            var n = 0;
            if (lb) for (var i = 0; i < lb.options.length; i++) if (lb.options[i].selected) n++;
            if (!n) { alert('Select one or more divisions in Group ' + group + ' first.'); return false; }
            return confirm('Remove ' + n + ' division(s) from Group ' + group + '?');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="mg-header">
            <h3>Manage Groups</h3>
            <p>Assign the divisions (ministries) of a session to its five groups. Select one or more divisions on the left, then click <b>Add selected</b> on a group.</p>
        </div>

        <div class="mg-session">
            <label for="SessionDDL">Session No</label>
            <asp:DropDownList ID="SessionDDL" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="HintLbl" runat="server" CssClass="mg-hint" Text="Choose a session to start."></asp:Label>
        </div>

        <asp:Panel ID="MsgPnl" runat="server" Visible="false" CssClass="mg-msg">
            <asp:Literal ID="MsgLit" runat="server"></asp:Literal>
        </asp:Panel>

        <div class="row">
            <div class="col-md-5">
                <div class="mg-card mg-avail">
                    <div class="mg-card-title">
                        <span>Available divisions</span>
                        <span class="mg-count" data-count-for="DivisionsCB">0</span>
                    </div>
                    <div class="mg-card-body">
                        <input type="text" id="mgSearch" class="form-control mg-search" placeholder="Search divisions..." autocomplete="off" />
                        <asp:ListBox ID="DivisionsCB" class="form-control mg-list" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        <div class="mg-note">Hold <b>Ctrl</b> or <b>Shift</b> to select several. <span id="mgShown"></span></div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">

        <div class="mg-card mg-g1">
            <div class="mg-card-title">
                <span>Group 1</span>
                <span class="mg-count" data-count-for="GroupOneLB">0</span>
            </div>
            <div class="mg-card-body">
                <asp:ListBox ID="GroupOneLB" runat="server" class="form-control mg-group-list" SelectionMode="Multiple" Rows="7"></asp:ListBox>
                <div class="mg-actions">
                    <asp:LinkButton class="btn btn-success btn-sm" ID="OneIn" runat="server" CausesValidation="false" OnClick="OneIn_Click" ToolTip="Move the divisions selected on the left into Group 1"><span class="glyphicon glyphicon-arrow-left"></span> Add selected</asp:LinkButton>
                    <asp:LinkButton class="btn btn-default btn-sm" ID="OneOut" runat="server" CausesValidation="false" OnClick="OneOut_Click" ToolTip="Send the selected divisions back to the available list"
                        OnClientClick="return mgConfirmRemove('GroupOneLB', 1);"><span class="glyphicon glyphicon-arrow-right"></span> Remove selected</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="mg-card mg-g2">
            <div class="mg-card-title">
                <span>Group 2</span>
                <span class="mg-count" data-count-for="GroupTwoLB">0</span>
            </div>
            <div class="mg-card-body">
                <asp:ListBox ID="GroupTwoLB" runat="server" class="form-control mg-group-list" SelectionMode="Multiple" Rows="7"></asp:ListBox>
                <div class="mg-actions">
                    <asp:LinkButton class="btn btn-success btn-sm" ID="TwoIn" runat="server" CausesValidation="false" OnClick="TwoIn_Click" ToolTip="Move the divisions selected on the left into Group 2"><span class="glyphicon glyphicon-arrow-left"></span> Add selected</asp:LinkButton>
                    <asp:LinkButton class="btn btn-default btn-sm" ID="TwoOut" runat="server" CausesValidation="false" OnClick="TwoOut_Click" ToolTip="Send the selected divisions back to the available list"
                        OnClientClick="return mgConfirmRemove('GroupTwoLB', 2);"><span class="glyphicon glyphicon-arrow-right"></span> Remove selected</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="mg-card mg-g3">
            <div class="mg-card-title">
                <span>Group 3</span>
                <span class="mg-count" data-count-for="GroupThreeLB">0</span>
            </div>
            <div class="mg-card-body">
                <asp:ListBox ID="GroupThreeLB" runat="server" class="form-control mg-group-list" SelectionMode="Multiple" Rows="7"></asp:ListBox>
                <div class="mg-actions">
                    <asp:LinkButton class="btn btn-success btn-sm" ID="ThreeIn" runat="server" CausesValidation="false" OnClick="ThreeIn_Click" ToolTip="Move the divisions selected on the left into Group 3"><span class="glyphicon glyphicon-arrow-left"></span> Add selected</asp:LinkButton>
                    <asp:LinkButton class="btn btn-default btn-sm" ID="ThreeOut" runat="server" CausesValidation="false" OnClick="ThreeOut_Click" ToolTip="Send the selected divisions back to the available list"
                        OnClientClick="return mgConfirmRemove('GroupThreeLB', 3);"><span class="glyphicon glyphicon-arrow-right"></span> Remove selected</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="mg-card mg-g4">
            <div class="mg-card-title">
                <span>Group 4</span>
                <span class="mg-count" data-count-for="GroupFourLB">0</span>
            </div>
            <div class="mg-card-body">
                <asp:ListBox ID="GroupFourLB" runat="server" class="form-control mg-group-list" SelectionMode="Multiple" Rows="7"></asp:ListBox>
                <div class="mg-actions">
                    <asp:LinkButton class="btn btn-success btn-sm" ID="FourIn" runat="server" CausesValidation="false" OnClick="FourIn_Click" ToolTip="Move the divisions selected on the left into Group 4"><span class="glyphicon glyphicon-arrow-left"></span> Add selected</asp:LinkButton>
                    <asp:LinkButton class="btn btn-default btn-sm" ID="FourOut" runat="server" CausesValidation="false" OnClick="FourOut_Click" ToolTip="Send the selected divisions back to the available list"
                        OnClientClick="return mgConfirmRemove('GroupFourLB', 4);"><span class="glyphicon glyphicon-arrow-right"></span> Remove selected</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="mg-card mg-g5">
            <div class="mg-card-title">
                <span>Group 5</span>
                <span class="mg-count" data-count-for="GroupFiveLB">0</span>
            </div>
            <div class="mg-card-body">
                <asp:ListBox ID="GroupFiveLB" runat="server" class="form-control mg-group-list" SelectionMode="Multiple" Rows="7"></asp:ListBox>
                <div class="mg-actions">
                    <asp:LinkButton class="btn btn-success btn-sm" ID="FiveIn" runat="server" CausesValidation="false" OnClick="FiveIn_Click" ToolTip="Move the divisions selected on the left into Group 5"><span class="glyphicon glyphicon-arrow-left"></span> Add selected</asp:LinkButton>
                    <asp:LinkButton class="btn btn-default btn-sm" ID="FiveOut" runat="server" CausesValidation="false" OnClick="FiveOut_Click" ToolTip="Send the selected divisions back to the available list"
                        OnClientClick="return mgConfirmRemove('GroupFiveLB', 5);"><span class="glyphicon glyphicon-arrow-right"></span> Remove selected</asp:LinkButton>
                </div>
            </div>
        </div>

            </div>
        </div>

    </div>
</asp:Content>
