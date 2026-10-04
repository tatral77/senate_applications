<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSittingPlan.aspx.cs" Inherits="Notice.ManageSittingPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />


    <link href="./CustomScripts/jquery-ui.css.css" rel="stylesheet" />
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/jquery-confirm.min.css" rel="stylesheet" />
    <%--https://craftpip.github.io/jquery-confirm/--%>
    
    <script src="https://cdn.tailwindcss.com"></script>
    <script src="./CustomScripts/jquery.min.js"></script>
    <script src="./CustomScripts/jquery-ui.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Javascript/jquery-confirm.min.js"></script>


    <title>Manage Seating Plan</title>

    <style type="text/css">
        body{
            background-color:skyblue;
        }

        .black_overlay {
            display: none;
            position: fixed !important;
            top: 0 !important;
            left: 0 !important;
            width: 100%;
            height: 100%;
            background-color: rgba(15, 23, 42, .55);
            backdrop-filter: blur(2px);
            z-index: 1000;
            opacity: 0;
            transition: opacity .18s ease;
        }
        .black_overlay.show { display: block; opacity: 1; }

        .white_content,
        .seat-modal {
            display: none;
            position: fixed !important;
            top: 50% !important;
            left: 50% !important;
            transform: translate(-50%, -50%) scale(.96);
            width: 420px;
            max-width: 92vw;
            max-height: 88vh;
            padding: 0;
            border: 0;
            background-color: #fff;
            z-index: 1001;
            overflow: auto;
            border-radius: 14px;
            color: #000;
            box-shadow: 0 20px 45px rgba(0,0,0,.28), 0 4px 14px rgba(0,0,0,.14);
            opacity: 0;
            transition: opacity .18s ease, transform .18s ease;
        }
        .white_content.show,
        .seat-modal.show {
            display: block;
            opacity: 1;
            transform: translate(-50%, -50%) scale(1);
        }
        .seat-modal .sm-head {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 10px;
            padding: 16px 20px;
            background-image: linear-gradient(135deg, #1f2d3d, #0c3a72);
            color: #fff;
            border-radius: 14px 14px 0 0;
        }
        .seat-modal .sm-head h3 {
            margin: 0;
            font-size: 16px;
            font-weight: 700;
            letter-spacing: .03em;
            display: flex;
            align-items: center;
            gap: 10px;
        }
        .seat-modal .sm-seat-badge {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            min-width: 32px;
            height: 30px;
            padding: 0 8px;
            background-color: rgba(255,255,255,.16);
            border-radius: 8px;
            font-weight: 700;
            font-size: 14px;
        }
        .seat-modal .sm-close {
            background: transparent;
            border: 0;
            color: #fff;
            font-size: 22px;
            line-height: 1;
            cursor: pointer;
            opacity: .8;
            padding: 0 2px;
        }
        .seat-modal .sm-close:hover { opacity: 1; }
        .seat-modal .sm-body { padding: 20px; }
        .seat-modal .sm-group { margin-bottom: 16px; }
        .seat-modal .sm-group:last-child { margin-bottom: 0; }
        .seat-modal .sm-group label {
            display: block;
            font-size: 12px;
            font-weight: 700;
            color: #5b6773;
            text-transform: uppercase;
            letter-spacing: .03em;
            margin-bottom: 5px;
        }
        .seat-modal .sm-footer {
            display: flex;
            justify-content: flex-end;
            gap: 8px;
            padding: 14px 20px;
            background-color: #f6f8fb;
            border-top: 1px solid #e9edf2;
            border-radius: 0 0 14px 14px;
        }
        .jconfirm .jconfirm-box {
            border-radius: 14px !important;
            box-shadow: 0 20px 45px rgba(0,0,0,.28), 0 4px 14px rgba(0,0,0,.14) !important;
            font-family: 'Segoe UI', Tahoma, Arial, sans-serif;
        }
        .jconfirm .jconfirm-title-c {
            font-weight: 700;
            letter-spacing: .02em;
        }
        .jconfirm .jconfirm-content {
            margin-top: 8px;
        }
        .jconfirm .jconfirm-buttons button {
            border-radius: 8px !important;
            font-weight: 600;
            padding: 7px 16px !important;
        }
        body {
            padding: 0;
            margin: 0;
        }

        .clearfix {
            clear: both;
        }

        .my-row > div:nth-child(1) {
            top: 90px;
        }

        .my-row > div:nth-child(2) {
            top: 80px;
        }

        .my-row > div:nth-child(3) {
            top: 70px;
        }

        .my-row > div:nth-child(4) {
            top: 60px;
        }

        .my-row > div:nth-child(5) {
            top: 50px;
        }

        .my-row > div:nth-child(6) {
            top: 40px;
        }

        .my-row > div:nth-child(7) {
            top: 30px;
        }

        .my-row > div:nth-child(8) {
            top: 20px;
        }

        .my-row > div:nth-child(9) {
            top: 10px;
        }

        .my-row > div:nth-child(10) {
            top: 10px;
        }

        .my-row > div:nth-child(11) {
            top: 10px;
        }

        .my-row > div:nth-child(12) {
            top: 20px;
        }

        .my-row > div:nth-child(13) {
            top: 30px;
        }

        .my-row > div:nth-child(14) {
            top: 40px;
        }

        .my-row > div:nth-child(15) {
            top: 50px;
        }

        .my-row > div:nth-child(16) {
            top: 60px;
        }

        .my-row > div:nth-child(17) {
            top: 70px;
        }

        .my-row > div:nth-child(18) {
            top: 80px;
        }

        .my-row > div:nth-child(19) {
            top: 90px;
        }
        /*div:nth-of-type(odd) { background: #f1f3f4; }
        div:nth-of-type(even) { background: #fff; }*/

        .my-row {
            margin-right: 20px;
            margin-left: 20px;
            width: 100%;
            align-content: center;
        }

        .my-col,
        .chariman {
            min-width: 60px;
            float: left;
            margin-right: 10px;
            position: relative;
        }

        .ui-autocomplete {
            cursor: default;
            z-index: 2000 !important;
            max-height: 260px;
            overflow-y: auto;
            overflow-x: hidden;
        }

        .col-left {
            transform: rotate(-5deg);
        }

        .col-right {
            transform: rotate(5deg);
        }

        .chariman {
            margin: auto !important;
            min-height: 100px;
            min-width: 150px;
            border: 3px solid;
            padding-top: 30px;
            text-align: center;
            font-size: 16px;
            font-weight: bold;
            border-radius: 10px;
        }

        .blank-div {
            width: 35px;
            float: left;
            position: relative;
            font-weight: bold;
            text-align: center;
        }

        .modal-dialog {
            height: 40%
        }

        .modal-content {
            height: 50%
        }

        .modal-body {
            height: 100%;
            overflow: auto
        }

        .no-bdr {
            border: none;
            text-align: center;
            /*position: fixed;*/
        }

        [draggable=true] {
            cursor: move;
        }

        .resizable {
            overflow: scroll;
            resize: both;
            max-width: 300px;
            max-height: 460px;
            border: 1px solid black;
            min-width: 50px;
            min-height: 50px;
            background-color: skyblue;
        }
        @font-face {
            font-family: 'Jameel Noori Nastaliq';
            src: url('fonts/JameelNooriNastaleeqRegular.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
            font-display: swap;
        }
        @font-face {
            font-family: 'Noto Nastaliq Urdu';
            src: url('fonts/NotoNastaliqUrduDraft.woff2') format('woff2'),
                url('fonts/NotoNastaliqUrduDraft.woff') format('woff'),
                url('fonts/NotoNastaliqUrduDraft.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
            font-display: swap;
        }
        .bdr > span:not(.seat-no-badge) {
            font-family: 'Jameel Noori Nastaliq', 'Noto Nastaliq Urdu', serif;
            direction: rtl;
            font-size: 19px;
            line-height: 1.35;
        }
        .urdu-text {
              font-family: 'Jameel Noori Nastaliq', 'Noto Nastaliq Urdu', serif;
              direction: rtl;
              text-align: right;
              font-size: 1.4rem; /* Nastaliq font requires slightly larger font-size for readability */
              line-height: 2.2;  /* Requires extra vertical space for tall character ascenders/descenders */
            }
        .bdr {
            cursor: move;
            position: relative;
            border: 1px solid rgba(0, 0, 0, .12);
            border-radius: 10px;
            min-height: 100px;
            width: 80px;
            padding: 3px;
            font-weight: 700;
            font-size: 15px;
            line-height: 1.2;
            background-image: linear-gradient(180deg, rgba(255,255,255,.55) 0%, rgba(255,255,255,.12) 45%, rgba(0,0,0,.06) 100%);
            box-shadow:
                inset 0 1px 0 rgba(255,255,255,.65),
                inset 0 -3px 5px rgba(0,0,0,.16),
                0 1px 0 rgba(255,255,255,.5),
                0 5px 8px rgba(0,0,0,.18),
                0 1px 2px rgba(0,0,0,.10);
            align-items: center;
            align-content: center;
            transition: transform 0.15s ease, box-shadow 0.15s ease;
            color:black;
            margin-bottom:20px;
            overflow: visible;
        }
        .bdr:hover {
            transform: translateY(-2px) scale(1.04);
            box-shadow:
                inset 0 1px 0 rgba(255,255,255,.7),
                inset 0 -3px 5px rgba(0,0,0,.16),
                0 8px 14px rgba(0,0,0,.22),
                0 2px 4px rgba(0,0,0,.12);
            z-index: 20;
        }
        .bdr:active {
            transform: translateY(1px) scale(.98);
            box-shadow:
                inset 0 2px 5px rgba(0,0,0,.28),
                inset 0 -1px 0 rgba(255,255,255,.4),
                0 1px 2px rgba(0,0,0,.15);
        }
        .legend-swatch {
            border: 1px solid rgba(0, 0, 0, .12) !important;
            border-radius: 10px !important;
            background-image: linear-gradient(180deg, rgba(255,255,255,.55) 0%, rgba(255,255,255,.12) 45%, rgba(0,0,0,.06) 100%);
            box-shadow:
                inset 0 1px 0 rgba(255,255,255,.65),
                inset 0 -3px 5px rgba(0,0,0,.16),
                0 1px 0 rgba(255,255,255,.5),
                0 5px 8px rgba(0,0,0,.18),
                0 1px 2px rgba(0,0,0,.10);
            padding: 8px 14px !important;
        }
      .seat-no-badge {
    position: absolute;
    top: -10px;        /* Moves half of the 20px circle above the top edge */
    right: -5px;      /* Moves half of the 20px circle past the right edge */
    width: 30px;
    height: 30px;
    background-image: linear-gradient(145deg, #4b5568, #232833);
    color: #ffffff;
    border-radius: 50%; /* Makes it a circle */
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 12px;
    font-weight: bold;
    pointer-events: none;
    z-index: 2;
    border: 1px solid rgba(0, 0, 0, .25);
    box-shadow:
        inset 0 1px 1px rgba(255,255,255,.35),
        inset 0 -1px 2px rgba(0,0,0,.4),
        0 2px 3px rgba(0,0,0,.35);
}
        .no-bdr p {
            margin-top: 5px;
            font-weight: bold;
        }

        span {
            vertical-align: central;
        }

        .row {
            margin-right: 1px !important;
            margin-left: 1px !important;
        }

        table, th, td {
            margin-left: auto;
            margin-right: auto;
            border-collapse: collapse;
        }


        .context-menu {
            display: none;
            position: absolute;
            z-index: 10;
        }
    </style>
    <script type="text/javascript">
        //      DRAG DROP--------------------------------------------
        function onDragStart(event) {
            event
                .dataTransfer
                .setData('text/plain', event.target.id);

            //event
            //    .currentTarget
            //    .style
            //    .backgroundColor = 'yellow';
        }
        function onDragOver(event) {
            event.preventDefault();
        }
        function onDrop(event) {

            const targetid = event.target.id;  //Control on which droped
            const sourceid = event
                .dataTransfer
                .getData('text');

            var targetspanid = "L" + targetid.substr(1);
            var sourcespanid = "L" + sourceid.substr(1);

            var targethiddenid = "H" + targetid.substr(1);
            var sourcehiddenid = "H" + sourceid.substr(1);

            var targetdivid = "S" + targetid.substr(1);
            var sourcedivid = "S" + sourceid.substr(1);

            var targetseatid = targetid.substr(1);
            var sourceseatid = sourceid.substr(1);

            var sourceMemberId = document.getElementById(sourcehiddenid).value.split('-')[0];
            var targetMemberId = document.getElementById(targethiddenid).value.split('-')[0];

            var sourceMemberName = document.getElementById(sourcespanid).innerText;
            var TargetMemberName = document.getElementById(targetspanid).innerText;

            var sourceMemberColor = document.getElementById(sourcehiddenid).value.split('-')[1];
            var targetMemberColor = document.getElementById(targethiddenid).value.split('-')[1];

            var fromWho = sourceMemberName ? sourceMemberName : 'Seat ' + sourceseatid;
            var toWho = TargetMemberName ? TargetMemberName : 'Seat ' + targetseatid;

            $.confirm({
                type: 'blue',
                icon: 'glyphicon glyphicon-transfer',
                title: 'Move seat ' + sourceseatid + ' &rarr; ' + targetseatid,
                content:
                    '<div style="text-align:left;font-size:13px;line-height:1.6">' +
                    '<b>' + fromWho + '</b> (seat ' + sourceseatid + ') is being dropped onto ' +
                    '<b>' + toWho + '</b> (seat ' + targetseatid + ').<br><br>' +
                    '<b>Swap</b> exchanges both seats.<br>' +
                    '<b>Move</b> moves ' + fromWho + ' into seat ' + targetseatid + ' and clears seat ' + sourceseatid + '.' +
                    '</div>',
                buttons: {
                    Swap: {
                        btnClass: 'btn-primary',
                        action: function () {
                            SaveSeat(sourceseatid, targetseatid, sourceMemberId, targetMemberId, sourceMemberColor, targetMemberColor, "Swap");
                        }
                    },
                    Move: {
                        btnClass: 'btn-warning',
                        action: function () {
                            SaveSeat(sourceseatid, targetseatid, sourceMemberId, 0, sourceMemberColor, targetMemberColor, "Move");
                        }
                    },
                    Cancel: {
                        btnClass: 'btn-default',
                        action: function () { }
                    }
                }
            });




            //var message_alert = $('<p>Choose action?</p>').dialog({
            //    buttons: {
            //        "Swap": function () {

            //            message_alert.dialog('close');
            //        },
            //        "Assign": function () {
            //            SaveSeat(sourceseatid, targetseatid, sourceMemberId, targetMemberId, sourceMemberColor, targetMemberColor, "Assign");
            //            message_alert.dialog('close');
            //        },
            //        "Cancel": function () {
            //            //alert('you clicked on cancel');
            //            message_alert.dialog('close');
            //        }
            //    }
            //});

        }
    </script>
</head>

<body>
    <form runat="server" id="f1">

        <!-- initially hidden right-click menu -->
        <section id="context">
            <!-- Context Menu -->
            <div class="context-menu">
                <div  class="bg-white w-48 h-auto border border-gray-300 rounded-lg flex flex-col text-md py-4 px-2 text-gray-600 shadow-lg">
                    <div class="flex hover:bg-gray-100 py-1 px-2 rounded cursor-pointer">
                        <div class="w-5 text-gray-900">
                            <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" viewBox="0 0 24 24">
                                <path fill-rule="evenodd" d="M8.586 2.586A2 2 0 0 1 10 2h4a2 2 0 0 1 2 2v2h3a1 1 0 1 1 0 2v12a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V8a1 1 0 0 1 0-2h3V4a2 2 0 0 1 .586-1.414ZM10 6h4V4h-4v2Zm1 4a1 1 0 1 0-2 0v8a1 1 0 1 0 2 0v-8Zm4 0a1 1 0 1 0-2 0v8a1 1 0 1 0 2 0v-8Z" clip-rule="evenodd" />
                            </svg>
                        </div>
                        <div class="ml-4">
                            <asp:Button runat="server" ID="UnAssign" Text="Un-Assign"  OnClick="UnAssignBtn_Click" /></div>
                    </div>
                    <%-- <hr class="my-3 border-gray-300" />
                     <div class="flex flex-col hover:bg-gray-100 py-1 px-2 rounded cursor-pointer">
                        <div class="text-gray-900">
                             <asp:Label ID="Label4" Style="font-weight: bold; width: 50%" runat="server" Text="Change Colour:"></asp:Label>
                    <asp:DropDownList ID="ContextSeatColour" runat="server" CssClass="form-control">
                        <asp:ListItem Value="white">White</asp:ListItem>
                        <asp:ListItem Value="#90EE90">Green: Treasury</asp:ListItem>
                        <asp:ListItem Value="#FF6347">Red: Opposition</asp:ListItem>
                        <asp:ListItem Value="#87CEFA">Blue: Independant</asp:ListItem>
                        <asp:ListItem Value="#FFA500">Orange : Minister</asp:ListItem>
                        <asp:ListItem Value="#D3D3D3">Gray: Request</asp:ListItem>
                    </asp:DropDownList>

                        </div>
                         <div class="flex flex-col">
                        <div class="ml-4">
                            <asp:Label ID="Label2" Style="font-weight: bold; width: 50%" runat="server" Text="Select Member:"></asp:Label>
                             <asp:TextBox ID="MemberNameTxt2" Style="font-weight: bold; color: #000; width:auto" runat="server" CssClass="form-control ui-autocomplete"></asp:TextBox>

                        </div>
                         <div class="mt-16">
                                <asp:Button runat="server" ID="Button1" Text="Assign" CommandArgument="2" OnClick="SaveBtn_Click" CssClass="btn btn-success" /></div>
                         </div>
                         </div>--%>
                    </div>
                </div>
           
            <!-- Context Menu -->
        </section>
        <div id="lightOverlay" class="black_overlay" onclick="CloseDetails(event);"></div>
        <div id="light" class="white_content seat-modal">
            <div class="sm-head">
                <h3>Manage seat
                    <span class="sm-seat-badge">
                        <asp:Label ID="SeatNumber" runat="server" Text=""></asp:Label>
                    </span>
                </h3>
                <button type="button" class="sm-close" onclick="CloseDetails(event);" aria-label="Close">&times;</button>
            </div>
            <div class="sm-body">
                <asp:Label ID="Label1" Style="display: none" runat="server" Text="SEAT NUMBER:"></asp:Label>
                <asp:HiddenField ID="HidSeatNumber" runat="server" />
                <div class="sm-group">
                    <asp:Label ID="Label3" runat="server" Text="Colour" AssociatedControlID="SeatColour"></asp:Label>
                    <asp:DropDownList ID="SeatColour" runat="server" CssClass="form-control seat-colour-ddl">
                        <asp:ListItem Value="white" Style="background-color:#ffffff;color:#2c2c2a;">White</asp:ListItem>
                        <asp:ListItem Value="#90EE90" Style="background-color:#90EE90;color:#0b3d0b;">Green: Treasury</asp:ListItem>
                        <asp:ListItem Value="#FF6347" Style="background-color:#FF6347;color:#ffffff;">Red: Opposition</asp:ListItem>
                        <asp:ListItem Value="#6495ED" Style="background-color:#6495ED;color:#ffffff;">Blue: Independant</asp:ListItem>
                        <asp:ListItem Value="#FFA500" Style="background-color:#FFA500;color:#3d2600;">Orange : Minister</asp:ListItem>
                        <asp:ListItem Value="#D3D3D3" Style="background-color:#D3D3D3;color:#333333;">Gray: Temporary</asp:ListItem>
                        <asp:ListItem Value="#f7dc6f" Style="background-color:#f7dc6f;color:#4a3b00;">Yellow: Request</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="sm-group">
                    <asp:Label ID="Label19" runat="server" Text="Member name" AssociatedControlID="MemberNameTxt"></asp:Label>
                    <asp:TextBox ID="MemberNameTxt" Style="font-weight: bold; color: #000; width: 100%; font-family: 'Jameel Noori Nastaliq', 'Noto Nastaliq Urdu', serif; font-size: 19px;" runat="server" CssClass="form-control ui-autocomplete"></asp:TextBox>
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                </div>
            </div>
            <div class="sm-footer">
                <asp:Button ID="Button3" runat="server" UseSubmitBehavior="false" OnClientClick="CloseDetails();" class="btn btn-default" Text="Cancel"></asp:Button>
                <asp:Button ID="UnAssignBtn" runat="server" Text="Un-Assign" class="btn btn-warning" OnClick="UnAssignBtn_Click" />
                <asp:Button ID="SaveBtn" runat="server" Text="Assign" class="btn btn-primary" OnClick="SaveBtn_Click" />
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td style="font-size: 14px; font-weight: bold; color: #000; text-align: left">
                        <asp:HyperLink ID="LinkButton1" Target="_blank" runat="server" NavigateUrl="~/SeatingPlan-LT.aspx">Print Left Plan (URDU)</asp:HyperLink></td>
                    <td style="font-size: 14px; font-weight: bold; color: #000; text-align: right">
                        <asp:HyperLink ID="LinkButton2" Target="_blank" runat="server" NavigateUrl="~/SeatingPlan-RT.aspx">Print Right Plan (URDU)</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; font-weight: bold;">
                        <asp:HyperLink ID="HyperLink3" Target="_blank" runat="server" NavigateUrl="~/PrintSeatingPlan.aspx">Print Seating Plan (Urdu)</asp:HyperLink><br />
                        <asp:HyperLink ID="HyperLink4" Target="_blank" runat="server" NavigateUrl="~/PrintSeatingPlanEng.aspx">Print Seating Plan (English)</asp:HyperLink><br />
                         <asp:HyperLink ID="HyperLink5" Target="_blank" runat="server" NavigateUrl="~/BlankSeatingPlanPrint.aspx">Print Seating Plan (Blank)</asp:HyperLink><br />
                        <asp:Label ID="updatedon" runat="server" Style="font-weight: bold"></asp:Label><br />
                        <asp:Button ID="UnAssignAllSeatsBtn" runat="server" OnClientClick="if (!confirm('Are you sure you want un-assign all seats?')) return false;" Text="Un-Assign All Seats" class="btn btn-danger" Style="margin-left: 5px;" OnClick="UnAssignAllSeatsBtn_Click" />
                        <asp:Button ID="ClearColoursBtn" runat="server" OnClientClick="if (!confirm('Are you sure you want un-assign all colours?')) return false;" Text="Un-Assign Colours" class="btn btn-success" Style="margin-left: 5px;" OnClick="ClearColoursBtn_Click" />

                    </td>
                </tr>
                <tr>
                    <td style="font-size: 14px; font-weight: bold; color: #000; text-align: left">
                        <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl="~/SeatingPlanLeftEn.aspx">Print Left Plan (ENGLISH)</asp:HyperLink></td>
                    <td style="font-size: 14px; font-weight: bold; color: #000; text-align: right">
                        <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" NavigateUrl="~/SeatingPlanRightEn.aspx">Print Right Plan (ENGLISH)</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>
                    <div style="display:flex;flex-direction:column;align-content:end;align-items:end;">
             <div style="width:60%">
                  
                <table class="table table-condensed table-responsive" style="border-collapse:separate;border-spacing:8px;">
                    <tr>
                        <th colspan="5" style="text-align:left;font-weight:bold;margin-bottom:5px">LEGENDS</th>
                    </tr>
                    <tr>

                                <td class="legend-swatch" style="background-color:#90EE90!important;text-align:center;font-weight:bold;">Treasury</td>

                                <td class="legend-swatch" style="background-color:#FF6347!important;text-align:center;font-weight:bold;">Oppostion</td>

                                <td class="legend-swatch" style="background-color:#6495ED!important;text-align:center;font-weight:bold;">Independant</td>

                                <td class="legend-swatch" style="background-color:#FFA500!important;text-align:center;font-weight:bold;">Minister</td>

                                <td class="legend-swatch" style="background-color:#D3D3D3!important;text-align:center;font-weight:bold;">Temporary</td>
                                <td class="legend-swatch" style="background-color:#f7dc6f!important;text-align:center;font-weight:bold;">Request</td>
                            </tr>
                        </table>
            </div>
             </div>
                        </td>
    </tr>

                <tr>
                <td style="width: 100%" colspan="2">
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S109" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onmouseover="showtooltip(this)" onclick="ShowDetails(this)">
                <span class="seat-no-badge">109</span>
                <asp:Label ID="L109" runat="server"></asp:Label><asp:HiddenField ID="H109" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S108" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">108</span>
                <asp:Label ID="L108" runat="server"></asp:Label>
                <asp:HiddenField ID="H108" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S107" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">107</span>
                <asp:Label ID="L107" runat="server"></asp:Label><asp:HiddenField ID="H107" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S106" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">106</span>
                <asp:Label ID="L106" runat="server"></asp:Label><asp:HiddenField ID="H106" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S105" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">105</span>
                <asp:Label ID="L105" runat="server"></asp:Label><asp:HiddenField ID="H105" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S104" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">104</span>
                <asp:Label ID="L104" runat="server"></asp:Label><asp:HiddenField ID="H104" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S103" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">103</span>
                <asp:Label ID="L103" runat="server"></asp:Label><asp:HiddenField ID="H103" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S102" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">102</span>
                <asp:Label ID="L102" runat="server"></asp:Label><asp:HiddenField ID="H102" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S101" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">101</span>
                <asp:Label ID="L101" runat="server"></asp:Label><asp:HiddenField ID="H101" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">F</div>
        <div class="my-col col-right no-bdr">
            <div id="S100" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">100</span>
                <asp:Label ID="L100" runat="server" Text=""></asp:Label><asp:HiddenField ID="H100" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S99" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">99</span>
                <asp:Label ID="L99" runat="server"></asp:Label><asp:HiddenField ID="H99" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S98" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">98</span>
                <asp:Label ID="L98" runat="server"></asp:Label><asp:HiddenField ID="H98" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S97" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">97</span>
                <asp:Label ID="L97" runat="server"></asp:Label><asp:HiddenField ID="H97" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S96" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">96</span>
                <asp:Label ID="L96" runat="server"></asp:Label><asp:HiddenField ID="H96" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S95" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">95</span>
                <asp:Label ID="L95" runat="server"></asp:Label><asp:HiddenField ID="H95" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S94" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">94</span>
                <asp:Label ID="L94" runat="server"></asp:Label><asp:HiddenField ID="H94" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S93" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">93</span>
                <asp:Label ID="L93" runat="server"></asp:Label><asp:HiddenField ID="H93" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S92" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">92</span>
                <asp:Label ID="L92" runat="server"></asp:Label><asp:HiddenField ID="H92" runat="server" Value="" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S91" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">91</span>
                <asp:Label ID="L91" runat="server"></asp:Label><asp:HiddenField ID="H91" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S90" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">90</span>
                <asp:Label ID="L90" runat="server"></asp:Label>
                <asp:HiddenField ID="H90" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S89" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">89</span>
                <asp:Label ID="L89" runat="server"></asp:Label><asp:HiddenField ID="H89" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S88" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">88</span>
                <asp:Label ID="L88" runat="server"></asp:Label><asp:HiddenField ID="H88" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S87" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">87</span>
                <asp:Label ID="L87" runat="server"></asp:Label><asp:HiddenField ID="H87" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S86" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">86</span>
                <asp:Label ID="L86" runat="server"></asp:Label><asp:HiddenField ID="H86" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S85" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">85</span>
                <asp:Label ID="L85" runat="server"></asp:Label><asp:HiddenField ID="H85" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S84" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">84</span>
                <asp:Label ID="L84" runat="server"></asp:Label><asp:HiddenField ID="H84" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S83" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">83</span>
                <asp:Label ID="L83" runat="server"></asp:Label><asp:HiddenField ID="H83" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">E</div>
        <div class="my-col col-right no-bdr">
            <div id="S82" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">82</span>
                <asp:Label ID="L82" runat="server"></asp:Label><asp:HiddenField ID="H82" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S81" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">81</span>
                <asp:Label ID="L81" runat="server"></asp:Label><asp:HiddenField ID="H81" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S80" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">80</span>
                <asp:Label ID="L80" runat="server"></asp:Label><asp:HiddenField ID="H80" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S79" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">79</span>
                <asp:Label ID="L79" runat="server"></asp:Label><asp:HiddenField ID="H79" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S78" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">78</span>
                <asp:Label ID="L78" runat="server"></asp:Label><asp:HiddenField ID="H78" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S77" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">77</span>
                <asp:Label ID="L77" runat="server"></asp:Label><asp:HiddenField ID="H77" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S76" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">76</span>
                <asp:Label ID="L76" runat="server"></asp:Label><asp:HiddenField ID="H76" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S75" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">75</span>
                <asp:Label ID="L75" runat="server"></asp:Label><asp:HiddenField ID="H75" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S74" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">74</span>
                <asp:Label ID="L74" runat="server"></asp:Label><asp:HiddenField ID="H74" runat="server" Value="" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S73" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">73</span>
                <asp:Label ID="L73" runat="server"></asp:Label><asp:HiddenField ID="H73" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S72" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">72</span>
                <asp:Label ID="L72" runat="server"></asp:Label>
                <asp:HiddenField ID="H72" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S71" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">71</span>
                <asp:Label ID="L71" runat="server"></asp:Label><asp:HiddenField ID="H71" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S70" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">70</span>
                <asp:Label ID="L70" runat="server"></asp:Label><asp:HiddenField ID="H70" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S69" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">69</span>
                <asp:Label ID="L69" runat="server"></asp:Label><asp:HiddenField ID="H69" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S68" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">68</span>
                <asp:Label ID="L68" runat="server"></asp:Label><asp:HiddenField ID="H68" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S67" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">67</span>
                <asp:Label ID="L67" runat="server"></asp:Label><asp:HiddenField ID="H67" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S66" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">66</span>
                <asp:Label ID="L66" runat="server"></asp:Label><asp:HiddenField ID="H66" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S65" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">65</span>
                <asp:Label ID="L65" runat="server"></asp:Label><asp:HiddenField ID="H65" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">D</div>
        <div class="my-col col-right no-bdr">
            <div id="S64" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">64</span>
                <asp:Label ID="L64" runat="server"></asp:Label><asp:HiddenField ID="H64" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S63" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">63</span>
                <asp:Label ID="L63" runat="server"></asp:Label><asp:HiddenField ID="H63" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S62" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">62</span>
                <asp:Label ID="L62" runat="server"></asp:Label><asp:HiddenField ID="H62" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S61" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">61</span>
                <asp:Label ID="L61" runat="server"></asp:Label><asp:HiddenField ID="H61" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S60" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">60</span>
                <asp:Label ID="L60" runat="server"></asp:Label><asp:HiddenField ID="H60" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S59" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">59</span>
                <asp:Label ID="L59" runat="server"></asp:Label><asp:HiddenField ID="H59" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S58" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">58</span>
                <asp:Label ID="L58" runat="server"></asp:Label><asp:HiddenField ID="H58" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S57" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">57</span>
                <asp:Label ID="L57" runat="server"></asp:Label><asp:HiddenField ID="H57" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S56" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">56</span>
                <asp:Label ID="L56" runat="server"></asp:Label><asp:HiddenField ID="H56" runat="server" Value="" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S55" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">55</span>
                <asp:Label ID="L55" runat="server"></asp:Label><asp:HiddenField ID="H55" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S54" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">54</span>
                <asp:Label ID="L54" runat="server"></asp:Label>
                <asp:HiddenField ID="H54" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S53" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">53</span>
                <asp:Label ID="L53" runat="server"></asp:Label><asp:HiddenField ID="H53" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S52" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">52</span>
                <asp:Label ID="L52" runat="server"></asp:Label><asp:HiddenField ID="H52" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S51" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">51</span>
                <asp:Label ID="L51" runat="server"></asp:Label><asp:HiddenField ID="H51" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S50" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">50</span>
                <asp:Label ID="L50" runat="server"></asp:Label><asp:HiddenField ID="H50" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S49" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">49</span>
                <asp:Label ID="L49" runat="server"></asp:Label><asp:HiddenField ID="H49" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S48" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">48</span>
                <asp:Label ID="L48" runat="server"></asp:Label><asp:HiddenField ID="H48" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S47" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">47</span>
                <asp:Label ID="L47" runat="server"></asp:Label><asp:HiddenField ID="H47" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">C</div>
        <div class="my-col col-right no-bdr">
            <div id="S46" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">46</span>
                <asp:Label ID="L46" runat="server"></asp:Label><asp:HiddenField ID="H46" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S45" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">45</span>
                <asp:Label ID="L45" runat="server"></asp:Label><asp:HiddenField ID="H45" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S44" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">44</span>
                <asp:Label ID="L44" runat="server"></asp:Label><asp:HiddenField ID="H44" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S43" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">43</span>
                <asp:Label ID="L43" runat="server"></asp:Label><asp:HiddenField ID="H43" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S42" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">42</span>
                <asp:Label ID="L42" runat="server"></asp:Label><asp:HiddenField ID="H42" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S41" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">41</span>
                <asp:Label ID="L41" runat="server"></asp:Label><asp:HiddenField ID="H41" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S40" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">40</span>
                <asp:Label ID="L40" runat="server"></asp:Label><asp:HiddenField ID="H40" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S39" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">39</span>
                <asp:Label ID="L39" runat="server"></asp:Label><asp:HiddenField ID="H39" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S38" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">38</span>
                <asp:Label ID="L38" runat="server"></asp:Label><asp:HiddenField ID="H38" runat="server" Value="" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S37" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">37</span>
                <asp:Label ID="L37" runat="server" Text=""></asp:Label><asp:HiddenField ID="H37" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S36" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">36</span>
                <asp:Label ID="L36" runat="server"></asp:Label>
                <asp:HiddenField ID="H36" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S35" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">35</span>
                <asp:Label ID="L35" runat="server"></asp:Label><asp:HiddenField ID="H35" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S34" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">34</span>
                <asp:Label ID="L34" runat="server"></asp:Label><asp:HiddenField ID="H34" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S33" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">33</span>
                <asp:Label ID="L33" runat="server"></asp:Label><asp:HiddenField ID="H33" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S32" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">32</span>
                <asp:Label ID="L32" runat="server"></asp:Label><asp:HiddenField ID="H32" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S31" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">31</span>
                <asp:Label ID="L31" runat="server"></asp:Label><asp:HiddenField ID="H31" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S30" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">30</span>
                <asp:Label ID="L30" runat="server"></asp:Label><asp:HiddenField ID="H30" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S29" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">29</span>
                <asp:Label ID="L29" runat="server"></asp:Label><asp:HiddenField ID="H29" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">B</div>
        <div class="my-col col-right no-bdr">
            <div id="S28" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">28</span>
                <asp:Label ID="L28" runat="server"></asp:Label><asp:HiddenField ID="H28" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S27" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">27</span>
                <asp:Label ID="L27" runat="server"></asp:Label><asp:HiddenField ID="H27" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S26" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">26</span>
                <asp:Label ID="L26" runat="server"></asp:Label><asp:HiddenField ID="H26" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S25" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">25</span>
                <asp:Label ID="L25" runat="server"></asp:Label><asp:HiddenField ID="H25" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S24" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">24</span>
                <asp:Label ID="L24" runat="server"></asp:Label><asp:HiddenField ID="H24" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S23" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">23</span>
                <asp:Label ID="L23" runat="server"></asp:Label><asp:HiddenField ID="H23" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S22" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">22</span>
                <asp:Label ID="L22" runat="server"></asp:Label><asp:HiddenField ID="H22" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S21" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">21</span>
                <asp:Label ID="L21" runat="server"></asp:Label><asp:HiddenField ID="H21" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S20" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">20</span>
                <asp:Label ID="L20" runat="server"></asp:Label><asp:HiddenField ID="H20" runat="server" Value="" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="my-row">
        <div class="my-col col-left no-bdr">
            <div id="S19" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">19</span>
                <asp:Label ID="L19" runat="server"></asp:Label><asp:HiddenField ID="H19" runat="server" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S18" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">18</span>
                <asp:Label ID="L18" runat="server"></asp:Label>
                <asp:HiddenField ID="H18" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S17" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">17</span>
                <asp:Label ID="L17" runat="server"></asp:Label><asp:HiddenField ID="H17" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S16" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">16</span>
                <asp:Label ID="L16" runat="server"></asp:Label><asp:HiddenField ID="H16" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S15" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">15</span>
                <asp:Label ID="L15" runat="server"></asp:Label><asp:HiddenField ID="H15" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S14" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">14</span>
                <asp:Label ID="L14" runat="server"></asp:Label><asp:HiddenField ID="H14" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S13" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">13</span>
                <asp:Label ID="L13" runat="server"></asp:Label><asp:HiddenField ID="H13" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S12" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">12</span>
                <asp:Label ID="L12" runat="server"></asp:Label><asp:HiddenField ID="H12" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-left no-bdr">
            <div id="S11" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">11</span>
                <asp:Label ID="L11" runat="server"></asp:Label><asp:HiddenField ID="H11" runat="server" Value="" />
            </div>
        </div>
        <div class="blank-div">A</div>
        <div class="my-col col-right no-bdr">
            <div id="S10" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">10</span>
                <asp:Label ID="L10" runat="server"></asp:Label><asp:HiddenField ID="H10" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S9" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">9</span>
                <asp:Label ID="L9" runat="server"></asp:Label><asp:HiddenField ID="H9" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S8" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">8</span>
                <asp:Label ID="L8" runat="server"></asp:Label><asp:HiddenField ID="H8" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S7" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">7</span>
                <asp:Label ID="L7" runat="server"></asp:Label><asp:HiddenField ID="H7" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S6" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">6</span>
                <asp:Label ID="L6" runat="server"></asp:Label><asp:HiddenField ID="H6" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S5" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">5</span>
                <asp:Label ID="L5" runat="server"></asp:Label><asp:HiddenField ID="H5" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S4" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">4</span>
                <asp:Label ID="L4" runat="server"></asp:Label><asp:HiddenField ID="H4" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S3" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">3</span>
                <asp:Label ID="L3" runat="server"></asp:Label><asp:HiddenField ID="H3" runat="server" Value="" />
            </div>
        </div>
        <div class="my-col col-right no-bdr">
            <div id="S2" class="bdr" draggable="true" ondragstart="onDragStart(event);" ondrop="onDrop(event);" ondragover="onDragOver(event);" runat="server" onclick="ShowDetails(this)">
                <span class="seat-no-badge">2</span>
                <asp:Label ID="L2" runat="server"></asp:Label><asp:HiddenField ID="H2" runat="server" Value="" />
            </div>
        </div>
    </div>
</td>
                </tr>

            </table>
            <table>
                <tr>
                    <td style="display: flex; align-content: center; align-items: center;">
                        <div class="chariman">C H A I R M A N</div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        var menu = document.querySelector(".context-menu");
        var menuState = 0;
        var contextMenuActive = "block";
        // Turns the custom context menu on.
        function toggleMenuOn() {
            if (menuState !== 1) {
                menuState = 1;
                menu.classList.add(contextMenuActive);

                //var id = temp.id.substr(1);
                //document.getElementById('light').style.display = 'block';
                ////$('#myModal2').modal('show');
                //document.getElementById('SeatNumber').innerText = id;
                //document.getElementById('HidSeatNumber').value = id;
                //document.getElementById('MemberNameTxt').value = document.getElementById('L' + id).innerText;
                //var id = document.getElementById('H' + id).value;
                //var arr = id.split("-");
                //document.getElementById('HidMemberId').value = arr[0];
                //document.getElementById('SeatColour').value = arr[1];
                //document.getElementById('SeatColour').style.backgroundColor = temp.style.backgroundColor;
            }
        }
        // Turns the custom context menu off.
        function toggleMenuOff() {
            if (menuState !== 0) {
                menuState = 0;
                menu.classList.remove(contextMenuActive);
            }
        }
        // Get the position of the right-click in window and returns the X and Y coordinates
        function getPosition(e) {
            var posx = 0;
            var posy = 0;

            if (!e) var e = window.event;

            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            } else if (e.clientX || e.clientY) {
                posx =
                    e.clientX +
                    document.body.scrollLeft +
                    document.documentElement.scrollLeft;
                posy =
                    e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
            }

            return {
                x: posx,
                y: posy
            };
        }
        // Position the Context Menu in right position.
        function positionMenu(e) {
            let clickCoords = getPosition(e);
            let clickCoordsX = clickCoords.x;
            let clickCoordsY = clickCoords.y;

            let menuWidth = menu.offsetWidth + 4;
            let menuHeight = menu.offsetHeight + 4;

            let windowWidth = window.innerWidth;
            let windowHeight = window.innerHeight;

            if (windowWidth - clickCoordsX < menuWidth) {
                menu.style.left = windowWidth - menuWidth + "px";
            } else {
                menu.style.left = clickCoordsX + "px";
            }

            if (windowHeight - clickCoordsY < menuHeight) {
                menu.style.top = windowHeight - menuHeight + "px";
            } else {
                menu.style.top = clickCoordsY + "px";
            }
        }
        // Event Listener for window ContextMenu Event - When Right Click is clicked
        //var divelement = document.getElementsByClassName("bdr");
        //document.addEventListener("contextmenu", function (event) {
        //    event.preventDefault();
        //    toggleMenuOn();
        //    positionMenu(event);
        //});

        $(function () {
            $(".bdr").bind("contextmenu", function (event) {
                document.getElementById("HidSeatNumber").value = event.target.id.substr(1);
                //alert(event.target.id);
                event.preventDefault();
                toggleMenuOn();
                positionMenu(event);
            });
        });
        //document.body.addEventListener("click", function (evt) {
        //    toggleMenuOff();
        //});
        // Event Listener for Close Context Menu when outside of menu clicked
        document.addEventListener("click", (e) => {
            var button = e.which || e.button;
            var input = e.which || e.input;
            if (input === 1) {}
            if (button === 1) {
                toggleMenuOff();
            }
        });

        // Close Context Menu on Esc key press
        window.onkeyup = function (e) {
            if (e.keyCode === 27) {
                toggleMenuOff();
                CloseDetails();
            }
        }
        function ShowDetails(temp) {
            var id = temp.id.substr(1);
            document.getElementById('light').classList.add('show');
            document.getElementById('lightOverlay').classList.add('show');
            document.getElementById('SeatNumber').innerText = id;
            document.getElementById('HidSeatNumber').value = id;
            document.getElementById('MemberNameTxt').value = document.getElementById('L' + id).innerText;
            var id = document.getElementById('H' + id).value;
            var arr = id.split("-");
            document.getElementById('HidMemberId').value = arr[0];
            document.getElementById('SeatColour').value = arr[1];
            document.getElementById('SeatColour').style.backgroundColor = temp.style.backgroundColor;
        }
        function showtooltip(temp) {
            var id = temp.id.substr(1);
        }
        function SaveSeat(SourceSeat, TargetSeat, SourceMember, TargetMember, SourceMemberColor, TargetMemberColor, Action) {
            $.ajax({
                type: "POST",
                url: "ManageSittingPlan.aspx/SaveSeat",
                data: JSON.stringify({
                    SourceSeat: parseInt(SourceSeat, 10) || 0,
                    TargetSeat: parseInt(TargetSeat, 10) || 0,
                    SourceMember: parseInt(SourceMember, 10) || 0,
                    TargetMember: parseInt(TargetMember, 10) || 0,
                    SourceMemberColor: SourceMemberColor || "",
                    TargetMemberColor: TargetMemberColor || "",
                    Action: Action
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response && response.d === 0) {
                        alert("The seat change could not be saved. Please try again.");
                        return;
                    }
                    location.reload();
                },
                error: function (xhr) {
                    var msg = "Could not save the seat change.";
                    try {
                        var parsed = JSON.parse(xhr.responseText);
                        if (parsed && parsed.Message) msg += "\n\n" + parsed.Message;
                    } catch (ex) { }
                    alert(msg);
                }
            });
        }
        function GetMemberSeats() {
            $.ajax({
                url: 'ManageSittingPlan.aspx/GetMemberSeats',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",

                success: function (response) {
                    if (response != null && response.d != null) {
                        var data = response;
                        alert(typeof (data)); //it comes out to be string 
                        //we need to parse it to JSON 
                        data = $.parseJSON(data);
                        $(data).each(function (index, seat) {
                            document.getElementById("S" + seat.SeatNumber).style.backgroundColor = seat.SeatColour;
                            document.getElementById("L" + seat.SeatNumber).innerText = seat.MemberUrduName;
                            document.getElementById("H" + seat.SeatNumber).value = seat.SystemUsersId + "-" + seat.SeatColour;

                        });
                    }
                },

                error: function (err) {
                    alert(err);
                }
            });
        }
        function CloseDetails(e) {
            document.getElementById('light').classList.remove('show');
            document.getElementById('lightOverlay').classList.remove('show');
            if (e && e.preventDefault) e.preventDefault();
        }
        $(function () {
            $("#SeatColour").change(function () {
                this.style.backgroundColor = this.value;
            });
        });

        $(function () {
            $("#ContextSeatColour").change(function () {
                this.style.backgroundColor = this.value;
            });
        });

        $(function () {
            $("[id$=MemberNameTxt2]").autocomplete({
                appendTo: "body",
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetSeatEmployeeName") %>',
                        data: JSON.stringify({ prefix: request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map((data && data.d) || [], function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
                                }
                            }))
                        },
                        error: function (xhr) {
                            console.error("GetSeatEmployeeName failed:", xhr.status, xhr.responseText);
                            response([]);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidMemberId]").val(i.item.val);

                },
                minLength: 1
            });
           });
        $(function () {
            $("[id$=MemberNameTxt]").autocomplete({
                appendTo: "body",
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetSeatEmployeeName") %>',
                        data: JSON.stringify({ prefix: request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map((data && data.d) || [], function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
                                }
                            }))
                        },
                        error: function (xhr) {
                            console.error("GetSeatEmployeeName failed:", xhr.status, xhr.responseText);
                            response([]);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidMemberId]").val(i.item.val);

                },
                minLength: 1
            });
        });
    </script>
</body>

</html>
