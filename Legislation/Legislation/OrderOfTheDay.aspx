<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="OrderOfTheDay.aspx.cs"
    Inherits="Legislation.OrderOfTheDay"
    ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />

    <meta
        name="viewport"
        content="width=device-width, initial-scale=1" />

    <title>Orders of the Day</title>


    <style type="text/css">

        :root {
            --primary: #a2070f;
            --primary-dark: #79060b;
            --primary-hover: #8e070d;
            --primary-light: #f9eded;

            --gold: #b9984d;
            --gold-light: #ddd0ab;

            --text: #292723;
            --muted: #6c665b;

            --background: #f5f4f1;
            --white: #ffffff;

            --border: #ddd8cc;
        }


        * {
            box-sizing: border-box;
        }


        html,
        body {
            margin: 0;
            padding: 0;

            background: var(--background);

            color: var(--text);

            font-family: Georgia, "Times New Roman", Times, serif;
        }


        /* =====================================================
           PAGE
           ===================================================== */

        .page-wrapper {
            width: 100%;
            min-height: 100vh;
        }


        /* =====================================================
           TOP TOOLBAR
           ===================================================== */

        .viewer-toolbar {
            position: sticky;

            top: 0;

            z-index: 1000;

            display: flex;

            align-items: center;

            justify-content: space-between;

            width: 100%;

            padding: 9px 20px;

            background: #ffffff;

            border-bottom: 1px solid #ddd;

            box-shadow: 0 2px 5px rgba(0, 0, 0, .06);

            font-family: Arial, Helvetica, sans-serif;
        }


        .viewer-toolbar-title {
            color: #555;

            font-size: 13px;

            font-weight: 700;

            text-transform: uppercase;

            letter-spacing: .04em;
        }


        .viewer-toolbar-buttons {
            display: flex;

            align-items: center;

            gap: 7px;
        }


        .toolbar-button {
            display: inline-block;

            padding: 7px 15px;

            border: none;

            border-radius: 4px;

            background: var(--primary);

            color: #fff;

            font-family: Arial, Helvetica, sans-serif;

            font-size: 12px;

            font-weight: 700;

            cursor: pointer;

            text-decoration: none;
        }


        .toolbar-button:hover {
            background: var(--primary-dark);
        }


        .toolbar-secondary {
            background: #666;
        }


        .toolbar-secondary:hover {
            background: #4d4d4d;
        }


        /* =====================================================
           DOCUMENT
           ===================================================== */

        .orders-of-day {
            width: calc(100% - 40px);

            max-width: 1050px;

            margin: 28px auto 60px auto;

            padding: 35px 42px 45px 42px;

            background: var(--white);

            border: 1px solid #e2dfd6;

            box-shadow: 0 4px 18px rgba(0, 0, 0, .07);
        }


        /* =====================================================
           DOCUMENT HEADER
           ===================================================== */

        .orders-header {
            text-align: center;

            margin-bottom: 30px;
        }


        .orders-kicker {
            margin-bottom: 13px;

            color: var(--gold);

            font-size: 13px;

            font-weight: 600;

            text-transform: uppercase;

            letter-spacing: .32em;

            line-height: 1.6;
        }


        .orders-title {
            margin: 0;

            color: var(--primary);

            font-size: 42px;

            font-weight: 700;

            line-height: 1.1;
        }


        .meeting-line {
            margin-top: 17px;

            color: #4c4943;

            font-size: 18px;

            line-height: 1.55;
        }


        .meeting-line strong {
            color: #3f3b36;

            font-weight: 700;
        }


        .orders-header-rule {
            width: 100%;

            height: 4px;

            margin-top: 29px;

            background: var(--primary);
        }


        /* =====================================================
           SOURCE BUSINESS HEADER
           ===================================================== */

        .accordion-source-header {
            display: none;
        }


        /* =====================================================
           ACCORDION
           ===================================================== */

        .business-accordion {
            width: 100%;

            margin-top: 20px;
        }


        .business-panel {
            width: 100%;

            margin-bottom: 18px;

            overflow: hidden;

            border: 1px solid #cdbb89;

            border-radius: 7px;

            background: #fff;

            box-shadow: 0 2px 7px rgba(0, 0, 0, .06);
        }


        /* =====================================================
           ACCORDION HEADER
           ===================================================== */

        .business-panel-heading {
            width: 100%;

            background: var(--primary);
        }


        .business-panel-toggle {
            display: flex;

            align-items: center;

            justify-content: space-between;

            width: 100%;

            padding: 15px 18px;

            border: none;

            background: transparent;

            color: #fff;

            cursor: pointer;

            text-align: left;

            font: inherit;
        }


        .business-panel-toggle:hover {
            background: var(--primary-hover);
        }


        .business-panel-toggle:focus {
            outline: none;
        }


        .business-heading-left {
            display: flex;

            align-items: center;

            flex: 1;

            min-width: 0;
        }


        .business-collapse-icon {
            display: flex;

            align-items: center;

            justify-content: center;

            width: 25px;

            min-width: 25px;

            margin-right: 10px;

            color: #ead8a6;

            font-family: Arial, Helvetica, sans-serif;

            font-size: 16px;

            font-weight: bold;
        }


        .business-heading-text {
            min-width: 0;
        }


        .business-heading-title {
            color: #fff;

            font-size: 17px;

            font-weight: 700;

            text-transform: uppercase;

            letter-spacing: .07em;

            line-height: 1.45;
        }


        .business-heading-rule {
            color: #eeddb0;

            font-size: 14px;

            font-weight: normal;

            letter-spacing: .01em;
        }


        .business-heading-rule:not(:empty)::before {
            content: " — ";
        }


        .business-heading-right {
            display: flex;

            align-items: center;

            margin-left: 15px;

            white-space: nowrap;
        }


        /* =====================================================
           ITEM COUNT
           ===================================================== */

        .business-item-count {
            min-width: 75px;

            padding: 5px 11px;

            border-radius: 16px;

            background: #d6b767;

            color: #5e070b;

            font-family: Arial, Helvetica, sans-serif;

            font-size: 11px;

            font-weight: 700;

            text-align: center;

            text-transform: uppercase;

            letter-spacing: .02em;
        }


        /* =====================================================
           ACCORDION BODY
           ===================================================== */

        .business-panel-collapse {
            display: block;
        }


        .business-panel-collapse.collapsed {
            display: none;
        }


        .business-panel-body {
            padding: 17px 18px 3px 18px;

            border-top: 3px solid var(--gold);

            background: #fffefa;
        }


        /* =====================================================
           AGENDA ITEM
           ===================================================== */

        .agenda-list {
            width: 100%;
        }


        .agenda-item {
            width: 100%;

            margin: 0 0 14px 0;

            padding: 19px 20px 17px 20px;

            border: 1px solid var(--gold-light);

            border-radius: 5px;

            background: #fff;

            page-break-inside: avoid;
        }


        .agenda-content {
            display: grid;

            grid-template-columns: 43px minmax(0, 1fr);

            gap: 13px;

            align-items: start;
        }


        /* =====================================================
           AGENDA NUMBER
           ===================================================== */

        .agenda-number {
            display: flex;

            align-items: center;

            justify-content: center;

            width: 40px;

            height: 40px;

            border: 1px solid var(--gold);

            border-radius: 50%;

            background: #fff;

            color: var(--primary);

            font-size: 15px;

            font-weight: 700;

            line-height: 1;
        }


        /* =====================================================
           DESCRIPTION
           ===================================================== */

        .agenda-description {
            min-width: 0;

            color: var(--text);

            font-size: 17px;

            line-height: 1.55;
        }


        .agenda-description > p:first-child {
            margin: 1px 0 9px 0;

            color: #282420;

            font-size: 19px;

            font-style: normal;

            font-weight: 500;

            line-height: 1.38;
        }


        .agenda-description > p:not(:first-child) {
            margin: 0 0 10px 0;

            color: var(--muted);

            font-style: italic;
        }


        .agenda-description ul,
        .agenda-description ol {
            margin-top: 6px;

            margin-bottom: 10px;
        }


        /* =====================================================
           DESCRIPTION TABLE
           ===================================================== */

        .agenda-description table {
            width: 100%;

            margin: 10px 0;

            border-collapse: collapse;

            font-size: 14px;
        }


        .agenda-description table td,
        .agenda-description table th {
            padding: 6px 8px;

            border: 1px solid #88837a;
        }


        /* =====================================================
           ATTACHMENTS
           ===================================================== */

        .attachment-list {
            display: flex;

            flex-wrap: wrap;

            align-items: center;

            gap: 8px;

            margin-top: 13px;
        }


        .attachment-link {
            display: inline-flex;

            align-items: center;

            gap: 6px;

            padding: 5px 9px;

            border: 1px solid #ddd5be;

            border-radius: 4px;

            background: #faf8f2;

            color: var(--primary);

            font-family: Arial, Helvetica, sans-serif;

            font-size: 11px;

            font-style: normal;

            font-weight: 600;

            text-decoration: none;
        }


        .attachment-link:hover {
            border-color: var(--gold);

            background: #f6f0e0;

            color: var(--primary-dark);
        }


        .pdf-icon {
            width: 22px;

            height: 22px;

            object-fit: contain;
        }


        .attachment-empty {
            margin-top: 12px;

            color: #888178;

            font-size: 13px;

            font-style: italic;
        }


        /* =====================================================
           EMPTY ORDER
           ===================================================== */

        .empty-orders {
            margin: 35px 0;

            padding: 30px;

            border: 1px dashed #cabda0;

            border-radius: 5px;

            color: #777;

            font-family: Arial, Helvetica, sans-serif;

            font-size: 14px;

            text-align: center;
        }


        /* =====================================================
           MOBILE
           ===================================================== */

        @media screen and (max-width: 768px) {

            .viewer-toolbar {
                padding: 8px 10px;
            }


            .viewer-toolbar-title {
                font-size: 11px;
            }


            .orders-of-day {
                width: calc(100% - 16px);

                margin: 12px auto 30px auto;

                padding: 24px 13px 30px 13px;
            }


            .orders-kicker {
                font-size: 9px;

                letter-spacing: .18em;
            }


            .orders-title {
                font-size: 30px;
            }


            .meeting-line {
                font-size: 14px;
            }


            .business-panel-toggle {
                padding: 12px 11px;
            }


            .business-collapse-icon {
                margin-right: 6px;

                font-size: 14px;
            }


            .business-heading-title {
                font-size: 13px;

                letter-spacing: .03em;
            }


            .business-heading-rule {
                display: block;

                font-size: 11px;
            }


            .business-heading-rule:not(:empty)::before {
                content: "";
            }


            .business-heading-right {
                margin-left: 7px;
            }


            .business-item-count {
                min-width: 54px;

                padding: 4px 6px;

                font-size: 9px;
            }


            .business-panel-body {
                padding: 11px 8px 2px 8px;
            }


            .agenda-item {
                padding: 14px 11px;
            }


            .agenda-content {
                grid-template-columns: 37px minmax(0, 1fr);

                gap: 9px;
            }


            .agenda-number {
                width: 35px;

                height: 35px;

                font-size: 13px;
            }


            .agenda-description {
                font-size: 14px;
            }


            .agenda-description > p:first-child {
                font-size: 16px;
            }

        }


        /* =====================================================
           PRINT
           ===================================================== */

        @page {
            size: A4;

            margin: 14mm 16mm 17mm 16mm;
        }


        @media print {

            html,
            body {
                margin: 0 !important;

                padding: 0 !important;

                background: #fff !important;
            }


            .no-print {
                display: none !important;
            }


            .orders-of-day {
                width: 100% !important;

                max-width: none !important;

                margin: 0 !important;

                padding: 0 !important;

                border: none !important;

                box-shadow: none !important;
            }


            .orders-header {
                margin-bottom: 24px;
            }


            .orders-kicker {
                font-size: 9pt;
            }


            .orders-title {
                font-size: 27pt;
            }


            .meeting-line {
                font-size: 11pt;
            }


            .orders-header-rule {
                height: 2px;
            }


            .business-panel {
                margin-bottom: 13px !important;

                border: none !important;

                box-shadow: none !important;

                page-break-inside: auto;
            }


            .business-panel-heading {
                background: #fff !important;

                border-bottom: 1px solid var(--gold) !important;
            }


            .business-panel-toggle {
                padding: 7px 0 !important;

                color: #222 !important;
            }


            .business-collapse-icon {
                display: none !important;
            }


            .business-heading-title {
                color: #222 !important;

                font-size: 10pt !important;
            }


            .business-heading-rule {
                color: #555 !important;

                font-size: 9pt !important;
            }


            .business-item-count {
                border: 1px solid #aaa !important;

                background: #fff !important;

                color: #333 !important;

                font-size: 8pt !important;
            }


            .business-panel-collapse,
            .business-panel-collapse.collapsed {
                display: block !important;
            }


            .business-panel-body {
                padding: 9px 0 0 0 !important;

                border-top: none !important;

                background: #fff !important;
            }


            .agenda-item {
                margin-bottom: 10px;

                padding: 13px 15px;

                page-break-inside: avoid;
            }


            .agenda-content {
                grid-template-columns: 32px minmax(0, 1fr);

                gap: 8px;
            }


            .agenda-number {
                width: 30px;

                height: 30px;

                font-size: 9.5pt;
            }


            .agenda-description {
                font-size: 10.5pt;

                line-height: 1.43;
            }


            .agenda-description > p:first-child {
                margin-bottom: 6px;

                font-size: 12pt;
            }


            .attachment-link {
                padding: 2px 5px;

                border: none;

                background: transparent;

                color: #333;

                font-size: 8.5pt;
            }


            .pdf-icon {
                width: 17px;

                height: 17px;
            }

        }

    </style>

</head>


<body>

    <form id="form1"
        runat="server">


        <div class="page-wrapper">


            <div class="viewer-toolbar no-print">

                <div class="viewer-toolbar-title">
                    Orders of the Day
                </div>


                <div class="viewer-toolbar-buttons">

                    <button
                        type="button"
                        class="toolbar-button toolbar-secondary"
                        onclick="expandAllBusinessTypes();">

                        Expand All

                    </button>


                    <button
                        type="button"
                        class="toolbar-button"
                        onclick="printOrdersOfDay();">

                        Print

                    </button>


                    <button
                        type="button"
                        class="toolbar-button"
                        onclick="exportOrdersPdf();">

                        Export PDF

                    </button>

                </div>

            </div>


            <div id="printArea"
                class="orders-of-day">


                <div class="orders-header">

                    <div class="orders-kicker">

                        HOUSE OF THE FEDERATION · SENATE SECRETARIAT

                    </div>


                    <h1 class="orders-title">

                        Orders of the Day

                    </h1>


                    <div class="meeting-line">
                         For the meeting of the Senate to be held at
                         <span id="MeetingTimeSpan" runat="server"></span>.

                    </div>


                    <div class="orders-header-rule">
                    </div>

                </div>


                <asp:ListView
                    ID="lv"
                    runat="server"
                    OnItemDataBound="lv_ItemDataBound">


                    <LayoutTemplate>

                        <div class="agenda-list">

                            <asp:PlaceHolder
                                ID="itemPlaceholder"
                                runat="server">
                            </asp:PlaceHolder>

                        </div>

                    </LayoutTemplate>


                    <ItemTemplate>

                        <asp:Panel
                            ID="BusinessHeaderPanel"
                            runat="server"
                            CssClass="accordion-source-header">

                            <span class="source-business-type">

                                <asp:Literal
                                    ID="BusinessTypeLiteral"
                                    runat="server">
                                </asp:Literal>

                            </span>

                            <span class="source-business-rule">

                                <asp:Literal
                                    ID="BusinessRuleLiteral"
                                    runat="server">
                                </asp:Literal>

                            </span>

                        </asp:Panel>


                        <div class="agenda-item">

                            <div class="agenda-content">

                                <div class="agenda-number">

                                    <%#Container.DataItemIndex + 1%>

                                </div>


                                <div class="agenda-description">

                                    <asp:Literal
                                        ID="DescriptionLiteral"
                                        runat="server"
                                        Mode="PassThrough"
                                        Text='<%# Eval("Description") %>'>
                                    </asp:Literal>


                                    <asp:ListView
                                        ID="lvAttachments"
                                        runat="server"
                                        DataSource='<%# Eval("Attachemnts") %>'>


                                        <LayoutTemplate>

                                            <div class="attachment-list">

                                                <asp:PlaceHolder
                                                    ID="itemPlaceholder"
                                                    runat="server">
                                                </asp:PlaceHolder>

                                            </div>

                                        </LayoutTemplate>


                                        <ItemTemplate>

                                           <a
                                            href='<%# ResolveUrl(Convert.ToString(Eval("Attachment"))) %>'
                                            target="_blank"
                                            class="attachment-link"
                                            title="View Attachment">

                                            <img
                                                src='<%# ResolveUrl("~/Images/pdf-icon.png") %>'
                                                class="pdf-icon no-print"
                                                alt="PDF" />

                                            <span>
                                                View attached PDF
                                            </span>

                                        </a>

                                        </ItemTemplate>


                                        <EmptyDataTemplate>

                                            <div class="attachment-empty">

                                                No files attached.

                                            </div>

                                        </EmptyDataTemplate>


                                    </asp:ListView>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>


                    <EmptyDataTemplate>

                        <div class="empty-orders">

                            No Order of the Day items are available.

                        </div>

                    </EmptyDataTemplate>


                </asp:ListView>


            </div>


        </div>


        <script type="text/javascript">

            function cleanBusinessText(value) {

                if (!value) {
                    return '';
                }


                var container =
                    document.createElement(
                        'div'
                    );


                container.innerHTML =
                    value;


                return (
                    container.textContent
                    ||
                    container.innerText
                    ||
                    ''
                ).trim();
            }


            function createBusinessPanel(
                index,
                businessType,
                businessRule) {

                var panel =
                    document.createElement(
                        'div'
                    );


                panel.className =
                    'business-panel';


                var heading =
                    document.createElement(
                        'div'
                    );


                heading.className =
                    'business-panel-heading';


                var button =
                    document.createElement(
                        'button'
                    );


                button.type =
                    'button';


                button.className =
                    'business-panel-toggle';


                button.setAttribute(
                    'aria-expanded',
                    'true'
                );


                var left =
                    document.createElement(
                        'div'
                    );


                left.className =
                    'business-heading-left';


                var icon =
                    document.createElement(
                        'span'
                    );


                icon.className =
                    'business-collapse-icon';


                icon.innerHTML =
                    '&#9660;';


                var headingText =
                    document.createElement(
                        'div'
                    );


                headingText.className =
                    'business-heading-text';


                var title =
                    document.createElement(
                        'span'
                    );


                title.className =
                    'business-heading-title';


                title.textContent =
                    businessType;


                var rule =
                    document.createElement(
                        'span'
                    );


                rule.className =
                    'business-heading-rule';


                if (businessRule) {

                    rule.textContent =
                        businessRule;
                }


                headingText.appendChild(
                    title
                );


                headingText.appendChild(
                    rule
                );


                left.appendChild(
                    icon
                );


                left.appendChild(
                    headingText
                );


                var right =
                    document.createElement(
                        'div'
                    );


                right.className =
                    'business-heading-right';


                var count =
                    document.createElement(
                        'span'
                    );


                count.className =
                    'business-item-count';


                count.textContent =
                    '0 Items';


                right.appendChild(
                    count
                );


                button.appendChild(
                    left
                );


                button.appendChild(
                    right
                );


                heading.appendChild(
                    button
                );


                var collapse =
                    document.createElement(
                        'div'
                    );


                collapse.className =
                    'business-panel-collapse';


                collapse.id =
                    'businessCollapse_' +
                    index;


                var body =
                    document.createElement(
                        'div'
                    );


                body.className =
                    'business-panel-body';


                collapse.appendChild(
                    body
                );


                panel.appendChild(
                    heading
                );


                panel.appendChild(
                    collapse
                );


                button.onclick =
                    function () {

                        if (
                            collapse.classList.contains(
                                'collapsed'
                            )
                        ) {

                            collapse.classList.remove(
                                'collapsed'
                            );


                            icon.innerHTML =
                                '&#9660;';


                            button.setAttribute(
                                'aria-expanded',
                                'true'
                            );

                        }
                        else {

                            collapse.classList.add(
                                'collapsed'
                            );


                            icon.innerHTML =
                                '&#9658;';


                            button.setAttribute(
                                'aria-expanded',
                                'false'
                            );
                        }
                    };


                return {

                    panel: panel,

                    body: body,

                    count: count,

                    collapse: collapse,

                    icon: icon,

                    button: button
                };
            }


            function buildBusinessTypeAccordions() {

                var lists =
                    document.querySelectorAll(
                        '.agenda-list'
                    );


                for (
                    var listIndex = 0;
                    listIndex < lists.length;
                    listIndex++
                ) {

                    var agendaList =
                        lists[listIndex];


                    if (
                        agendaList.getAttribute(
                            'data-accordion-built'
                        )
                        ===
                        'true'
                    ) {

                        continue;
                    }


                    var originalChildren =
                        [];


                    for (
                        var childIndex = 0;
                        childIndex <
                        agendaList.children.length;
                        childIndex++
                    ) {

                        originalChildren.push(
                            agendaList.children[
                                childIndex
                            ]
                        );
                    }


                    if (
                        originalChildren.length
                        ===
                        0
                    ) {

                        continue;
                    }


                    var accordion =
                        document.createElement(
                            'div'
                        );


                    accordion.className =
                        'business-accordion';


                    var currentPanel =
                        null;


                    var currentBody =
                        null;


                    var currentCountElement =
                        null;


                    var currentCount =
                        0;


                    var panelIndex =
                        0;


                    function updateCount() {

                        if (
                            !currentCountElement
                        ) {

                            return;
                        }


                        if (
                            currentCount === 1
                        ) {

                            currentCountElement.textContent =
                                '1 Item';

                        }
                        else {

                            currentCountElement.textContent =
                                currentCount
                                +
                                ' Items';
                        }
                    }


                    for (
                        var i = 0;
                        i < originalChildren.length;
                        i++
                    ) {

                        var element =
                            originalChildren[i];


                        if (
                            element.classList.contains(
                                'accordion-source-header'
                            )
                        ) {

                            updateCount();


                            var businessTypeElement =
                                element.querySelector(
                                    '.source-business-type'
                                );


                            var businessRuleElement =
                                element.querySelector(
                                    '.source-business-rule'
                                );


                            var businessType =
                                businessTypeElement
                                ?
                                cleanBusinessText(
                                    businessTypeElement
                                        .innerHTML
                                )
                                :
                                '';


                            var businessRule =
                                businessRuleElement
                                ?
                                cleanBusinessText(
                                    businessRuleElement
                                        .innerHTML
                                )
                                :
                                '';


                            panelIndex++;


                            var created =
                                createBusinessPanel(
                                    panelIndex,
                                    businessType,
                                    businessRule
                                );


                            currentPanel =
                                created.panel;


                            currentBody =
                                created.body;


                            currentCountElement =
                                created.count;


                            currentCount =
                                0;


                            accordion.appendChild(
                                currentPanel
                            );


                            continue;
                        }


                        if (
                            element.classList.contains(
                                'agenda-item'
                            )
                        ) {

                            if (!currentPanel) {

                                panelIndex++;


                                var defaultPanel =
                                    createBusinessPanel(
                                        panelIndex,
                                        'OTHER BUSINESS',
                                        ''
                                    );


                                currentPanel =
                                    defaultPanel.panel;


                                currentBody =
                                    defaultPanel.body;


                                currentCountElement =
                                    defaultPanel.count;


                                currentCount =
                                    0;


                                accordion.appendChild(
                                    currentPanel
                                );
                            }


                            currentBody.appendChild(
                                element
                            );


                            currentCount++;
                        }

                    }


                    updateCount();


                    agendaList.innerHTML =
                        '';


                    agendaList.appendChild(
                        accordion
                    );


                    agendaList.setAttribute(
                        'data-accordion-built',
                        'true'
                    );
                }
            }


            function expandAllBusinessTypes() {

                var sections =
                    document.querySelectorAll(
                        '.business-panel-collapse'
                    );


                var icons =
                    document.querySelectorAll(
                        '.business-collapse-icon'
                    );


                var buttons =
                    document.querySelectorAll(
                        '.business-panel-toggle'
                    );


                for (
                    var i = 0;
                    i < sections.length;
                    i++
                ) {

                    sections[i]
                        .classList
                        .remove(
                            'collapsed'
                        );
                }


                for (
                    var j = 0;
                    j < icons.length;
                    j++
                ) {

                    icons[j].innerHTML =
                        '&#9660;';
                }


                for (
                    var k = 0;
                    k < buttons.length;
                    k++
                ) {

                    buttons[k].setAttribute(
                        'aria-expanded',
                        'true'
                    );
                }
            }


            function printOrdersOfDay() {

                expandAllBusinessTypes();


                window.setTimeout(
                    function () {

                        window.print();

                    },
                    50
                );
            }


            if (
                document.readyState ===
                'loading'
            ) {

                document.addEventListener(
                    'DOMContentLoaded',
                    function () {

                        buildBusinessTypeAccordions();

                    }
                );

            }
            else {

                buildBusinessTypeAccordions();
            }

        </script>


    </form>

    <script type="text/javascript" src="Scripts/qmspdf.js"></script>
    <script type="text/javascript">
        function exportOrdersPdf() {
            expandAllBusinessTypes();
            window.setTimeout(function () {
                QMSPdf.export('#printArea', { filename: 'Orders-of-the-Day', orientation: 'portrait', header: false, plain: true });
            }, 100);
        }
    </script>
</body>

</html>
