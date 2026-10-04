<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    ValidateRequest="false"
    MaintainScrollPositionOnPostBack="true"
    CodeBehind="OrderOfDayBusiness.aspx.cs"
    Inherits="Legislation.OrderOfDayBusiness" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <script src="CustomScripts/jquery.min.js"></script>

    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />

    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />


    <style type="text/css">

        :root {
            --senate-green: #C19A6B;
            --senate-green-hover: #d3b67d;
            --senate-gold: #b79a58;
            --senate-gold-light: #d8cfb3;
            --senate-text: #282a26;
            --senate-muted: #6f685b;
            --panel-bg: #f7f7f5;
            --panel-border: #deded8;
        }


        /* =====================================================
           GENERAL
           ===================================================== */

        .orders-page {
            width: 100%;
        }

        .orders-of-day {
            width: calc(100% - 30px);
            max-width: 980px;
            margin: 24px auto 50px auto;
            background: #fff;
            color: var(--senate-text);
            font-family: Georgia, "Times New Roman", Times, serif;
        }


        /* =====================================================
           COMPACT ADD SECTION
           ===================================================== */

        .agenda-admin {
            width: calc(100% - 30px);
            max-width: 980px;
            margin: 10px auto 15px auto;
            padding: 10px 12px;
            box-sizing: border-box;
            background: var(--panel-bg);
            border: 1px solid var(--panel-border);
            border-radius: 5px;
            font-family: Arial, Helvetica, sans-serif;
        }

        .agenda-admin-title {
            margin-bottom: 8px;
        }

        .agenda-admin-title h4 {
            margin: 0;
            color: #333;
            font-size: 14px;
            font-weight: 700;
        }

        .admin-grid {
            display: grid;
            grid-template-columns: minmax(250px, 1fr) 120px;
            gap: 7px 10px;
            align-items: end;
        }

        .admin-field label {
            display: block;
            margin: 0 0 3px 0;
            color: #555;
            font-size: 10px;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: .04em;
        }

        .admin-field .form-control {
            height: 30px;
            padding: 4px 7px;
            font-size: 13px;
        }

        .admin-description {
            grid-column: 1 / -1;
        }

        .admin-description .note-editor {
            margin-bottom: 0 !important;
        }

        .admin-description .note-toolbar {
            padding: 2px 4px !important;
        }

        .admin-description .note-btn {
            padding: 2px 6px !important;
        }

        .admin-description .note-editable {
            min-height: 85px !important;
            padding: 6px 8px !important;
            font-size: 13px;
            line-height: 1.35;
        }

        .admin-bottom-row {
            grid-column: 1 / -1;
            display: flex;
            align-items: end;
            justify-content: space-between;
            gap: 10px;
        }

        .admin-attachment {
            flex: 1;
            min-width: 0;
        }

        .admin-attachment .form-control {
            height: 30px;
            padding: 3px 7px;
            font-size: 12px;
        }

        .admin-help {
            display: block;
            margin-top: 2px;
            color: #777;
            font-size: 10px;
        }

        .admin-buttons {
            white-space: nowrap;
        }

        .admin-buttons .btn {
            min-width: 75px;
            height: 30px;
            padding: 4px 10px;
        }

        .agenda-list-heading {
            width: calc(100% - 30px);
            max-width: 980px;
            margin: 5px auto;
            font-family: Arial, Helvetica, sans-serif;
            color: #666;
            font-size: 12px;
            font-weight: 700;
        }


        /* =====================================================
           DOCUMENT HEADER
           ===================================================== */

        .orders-header {
            text-align: center;
            padding: 15px 0 0 0;
            margin-bottom: 30px;
        }

        .orders-kicker {
            margin-bottom: 14px;
            color: var(--senate-gold);
            font-size: 13px;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: .34em;
            line-height: 1.5;
        }

        .orders-title {
            margin: 0;
            color: var(--senate-green);
            font-size: 42px;
            font-weight: 700;
            line-height: 1.1;
        }

        .meeting-line {
            margin-top: 17px;
            color: #4c4a45;
            font-size: 18px;
            line-height: 1.5;
        }

        .meeting-line strong {
            color: #45423d;
            font-weight: 700;
        }

        .orders-header-rule {
            height: 3px;
            margin-top: 31px;
            background: var(--senate-green);
        }


        /* =====================================================
           ORIGINAL BUSINESS HEADER
           USED AS SOURCE FOR ACCORDION
           ===================================================== */

        .accordion-source-header {
            display: none;
        }


        /* =====================================================
           BUSINESS TYPE ACCORDION
           ===================================================== */

        .business-accordion {
            margin-top: 18px;
        }

        .business-panel {
            margin-bottom: 18px !important;
            overflow: hidden;
            border: 1px solid #bda96f !important;
            border-radius: 7px !important;
            background: #000000;
            box-shadow: 0 2px 7px rgba(0,0,0,.07);
        }

        .business-panel-heading {
            padding: 0 !important;
            border: 0 !important;
            background: var(--senate-green) !important;
        }

        .business-panel-toggle {
            display: flex !important;
            align-items: center;
            justify-content: space-between;
            width: 100%;
            padding: 14px 17px;
            box-sizing: border-box;
            color: #000000 !important;
            text-decoration: none !important;
            cursor: pointer;
        }

        .business-panel-toggle:hover,
        .business-panel-toggle:focus {
            color: #000000 !important;
            background: var(--senate-green-hover);
            text-decoration: none !important;
            outline: none;
        }

        .business-heading-left {
            display: flex;
            align-items: center;
            flex: 1;
            min-width: 0;
        }

        .business-heading-text {
            min-width: 0;
        }

        .business-collapse-icon {
            width: 24px;
            min-width: 24px;
            margin-right: 8px;
            color: #d9c483;
            font-size: 12px;
        }

        .business-heading-title {
            color: #2f281b;
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: 17px;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: .08em;
            line-height: 1.4;
        }

        .business-heading-rule {
            color: #2f281b;
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: 14px;
            font-weight: 400;
            letter-spacing: .02em;
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

        .business-item-count {
            min-width: 72px;
            padding: 5px 11px;
            box-sizing: border-box;
            border-radius: 15px;
            background: #c9ac63;
            color: #17382f;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: 700;
            text-align: center;
            text-transform: uppercase;
            letter-spacing: .02em;
        }

        .business-panel-body {
            padding: 16px 17px 3px 17px !important;
            border-top: 3px solid var(--senate-gold) !important;
            background: #fcfcfa;
        }


        /* =====================================================
           AGENDA
           ===================================================== */

        .agenda-list {
            width: 100%;
        }

        .agenda-item {
            width: 100%;
            box-sizing: border-box;
            margin: 0 0 14px 0;
            padding: 18px 20px;
            border: 1px solid var(--senate-gold-light);
            border-radius: 5px;
            background: #fff;
            page-break-inside: avoid;
        }

        .agenda-content {
            display: grid;
            grid-template-columns: 42px minmax(0, 1fr);
            gap: 13px;
            align-items: start;
        }

        .agenda-number {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 40px;
            height: 40px;
            box-sizing: border-box;
            border: 1px solid #c6ab68;
            border-radius: 50%;
            background: #fff;
            color: var(--senate-green);
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: 15px;
            font-weight: 700;
        }

        .agenda-description {
            min-width: 0;
            color: var(--senate-text);
            font-family: Georgia, "Times New Roman", Times, serif;
            font-size: 17px;
            line-height: 1.52;
        }

        .agenda-description > p:first-child {
            margin: 1px 0 9px 0;
            color: #252721;
            font-size: 19px;
            font-style: normal;
            line-height: 1.35;
        }

        .agenda-description > p:not(:first-child) {
            margin: 0 0 10px 0;
            color: var(--senate-muted);
            font-style: italic;
        }

        .agenda-description table {
            width: 100%;
            margin: 8px 0;
            border-collapse: collapse;
            font-size: 14px;
        }

        .agenda-description table td,
        .agenda-description table th {
            padding: 5px 7px;
            border: 1px solid #8e8a7f;
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
            gap: 5px;
            color: #5f5a4f;
            font-size: 13px;
            font-style: italic;
            text-decoration: none;
        }

        .attachment-link:hover {
            color: var(--senate-green);
            text-decoration: underline;
        }

        .pdf-icon {
            width: 24px;
            height: 24px;
            object-fit: contain;
        }

        .attachment-empty {
            margin-top: 13px;
            color: #4f4b43;
            font-size: 15px;
            font-style: italic;
        }


        /* =====================================================
           NORMAL ACTIONS
           ===================================================== */

        .agenda-actions {
            margin-top: 12px;
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
        }


        /* =====================================================
           EDIT FORM
           ===================================================== */

        .edit-item {
            margin: 0 0 15px 0;
            padding: 16px;
            border: 2px solid #c5a85d;
            border-radius: 7px;
            background: #fafaf7;
            font-family: Arial, Helvetica, sans-serif;
            scroll-margin-top: 40px;
        }

        .edit-heading {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 12px;
            padding-bottom: 8px;
            border-bottom: 1px solid #ddd5bd;
        }

        .edit-heading-title {
            color: var(--senate-green);
            font-size: 15px;
            font-weight: 700;
        }

        .edit-heading-small {
            color: #777;
            font-size: 11px;
        }

        .edit-label {
            margin-bottom: 4px;
            color: #555;
            font-size: 11px;
            font-weight: 700;
            text-transform: uppercase;
        }

        .edit-item .form-control {
            font-size: 13px;
        }

        .edit-description-editor {
            min-height: 120px;
        }

        .edit-attachment-section {
            margin-top: 14px;
            padding: 12px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background: #fff;
        }

        .edit-attachment-section-title {
            margin-bottom: 8px;
            color: #444;
            font-size: 12px;
            font-weight: 700;
            text-transform: uppercase;
        }

        .edit-attachment-list {
            overflow: hidden;
            border: 1px solid #e3e3e3;
            border-radius: 4px;
        }

        .edit-attachment-item {
            display: flex;
            align-items: center;
            gap: 10px;
            padding: 8px 10px;
            border-bottom: 1px solid #eee;
            background: #fff;
        }

        .edit-attachment-item:last-child {
            border-bottom: none;
        }

        .edit-attachment-icon {
            flex: 0 0 24px;
        }

        .edit-attachment-icon img {
            width: 22px;
            height: 22px;
        }

        .edit-attachment-name {
            flex: 1;
            min-width: 0;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            font-size: 12px;
        }

        .edit-attachment-name a {
            color: #345e52;
        }

        .remove-attachment {
            margin: 0 !important;
            color: #a60000 !important;
            font-size: 12px !important;
            font-weight: 400 !important;
            text-transform: none !important;
            white-space: nowrap;
            cursor: pointer;
        }

        .remove-attachment input {
            margin-right: 4px;
            vertical-align: middle;
        }

        .no-edit-attachments {
            padding: 8px 10px;
            color: #888;
            font-size: 12px;
            font-style: italic;
        }

        .edit-new-attachment {
            margin-top: 12px;
        }

        .edit-new-attachment .form-control {
            height: 34px;
            padding: 4px 7px;
        }

        .edit-upload-help {
            display: block;
            margin-top: 4px;
            color: #777;
            font-size: 11px;
        }

        .edit-buttons {
            margin-top: 15px;
            text-align: right;
        }

        .edit-buttons .btn {
            min-width: 90px;
        }


        /* =====================================================
           MOBILE
           ===================================================== */

        @media screen and (max-width: 768px) {

            .agenda-admin,
            .agenda-list-heading,
            .orders-of-day {
                width: calc(100% - 20px);
            }

            .admin-grid {
                grid-template-columns: 1fr;
            }

            .admin-description,
            .admin-bottom-row {
                grid-column: 1;
            }

            .admin-bottom-row {
                display: block;
            }

            .admin-buttons {
                margin-top: 8px;
                text-align: right;
            }

            .orders-kicker {
                font-size: 10px;
                letter-spacing: .20em;
            }

            .orders-title {
                font-size: 30px;
            }

            .meeting-line {
                font-size: 15px;
            }

            .business-panel-toggle {
                padding: 11px 12px;
            }

            .business-heading-title {
                font-size: 13px;
                letter-spacing: .04em;
            }

            .business-heading-rule {
                display: block;
                font-size: 11px;
            }

            .business-heading-rule:not(:empty)::before {
                content: "";
            }

            .business-heading-right {
                margin-left: 8px;
            }

            .business-item-count {
                min-width: 55px;
                padding: 4px 7px;
                font-size: 9px;
            }

            .business-panel-body {
                padding: 11px 9px 2px 9px !important;
            }

            .agenda-item {
                padding: 15px 12px;
            }

            .agenda-content {
                grid-template-columns: 38px minmax(0, 1fr);
                gap: 10px;
            }

            .agenda-number {
                width: 36px;
                height: 36px;
                font-size: 13px;
            }

            .agenda-description {
                font-size: 15px;
            }

            .agenda-description > p:first-child {
                font-size: 17px;
            }
        }


        /* =====================================================
           PRINT
           ===================================================== */

        @page {
            size: A4;
            margin: 15mm 16mm 18mm 16mm;
        }

        @media print {

            html,
            body {
                margin: 0 !important;
                padding: 0 !important;
                background: #fff !important;
            }

            body * {
                visibility: hidden;
            }

            #printArea,
            #printArea * {
                visibility: visible;
            }

            #printArea {
                position: absolute;
                left: 0;
                top: 0;
                width: 100% !important;
                max-width: none !important;
                margin: 0 !important;
                padding: 0 !important;
            }

            .no-print {
                display: none !important;
            }

            .business-accordion .panel-collapse {
                display: block !important;
                height: auto !important;
            }

            .business-panel {
                margin-bottom: 13px !important;
                border: 0 !important;
                box-shadow: none !important;
            }

            .business-panel-heading {
                background: #fff !important;
                border-bottom: 1px solid #b79a58 !important;
            }

            .business-panel-toggle {
                padding: 7px 0 !important;
                color: #222 !important;
            }

            .business-heading-title {
                color: #222 !important;
                font-size: 10pt !important;
            }

            .business-heading-rule {
                color: #555 !important;
                font-size: 9pt !important;
            }

            .business-collapse-icon {
                display: none !important;
            }

            .business-item-count {
                border: 1px solid #aaa !important;
                background: #fff !important;
                color: #333 !important;
                font-size: 8pt !important;
            }

            .business-panel-body {
                padding: 10px 0 0 0 !important;
                border-top: 0 !important;
                background: #fff !important;
            }

            .orders-header {
                padding-top: 0;
                margin-bottom: 26px;
            }

            .orders-kicker {
                font-size: 10pt;
            }

            .orders-title {
                font-size: 28pt;
            }

            .meeting-line {
                font-size: 12pt;
            }

            .agenda-item {
                padding: 14px 16px 13px 16px;
                margin-bottom: 11px;
                page-break-inside: avoid;
            }

            .agenda-number {
                width: 31px;
                height: 31px;
                font-size: 10pt;
            }

            .agenda-content {
                grid-template-columns: 33px minmax(0, 1fr);
                gap: 9px;
            }

            .agenda-description {
                font-size: 10.5pt;
                line-height: 1.45;
            }

            .agenda-description > p:first-child {
                margin-bottom: 6px;
                font-size: 12.5pt;
            }
        }

    </style>

</asp:Content>


<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="container orders-page">


        <div class="agenda-admin no-print">

            <div class="agenda-admin-title">

                <h4>
                    ADD AGENDA ITEM
                </h4>

            </div>


            <div class="admin-grid">

                <div class="admin-field">

                    <label>
                        Business Type
                    </label>

                    <asp:DropDownList
                        ID="BusinessTypeDDL"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>

                </div>


                <div class="admin-field">

                    <label>
                        Sort Order
                    </label>

                    <asp:TextBox
                        ID="SortOrderTxt"
                        runat="server"
                        TextMode="Number"
                        CssClass="form-control"
                        Text="1">
                    </asp:TextBox>

                </div>


                <div class="admin-field admin-description">

                    <label>
                        Description
                    </label>

                    <textarea
                        id="DescriptionTxt"
                        name="DescriptionTxt"
                        class="form-control"
                        rows="3"
                        runat="server"></textarea>


                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="DescriptionTxt"
                        ErrorMessage="Enter Description Text"
                        ValidationGroup="SaveGroup"
                        Display="None">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="admin-bottom-row">

                    <div class="admin-field admin-attachment">

                        <label>
                            Attachments
                        </label>

                        <asp:FileUpload
                            ID="BusinessAttachments"
                            runat="server"
                            CssClass="form-control"
                            AllowMultiple="true" data-scan="true" />

                        <span class="admin-help">
                            Multiple PDF files can be selected.
                        </span>

                    </div>


                    <div class="admin-buttons">

                        <asp:Button
                            ID="PrintBtn"
                            runat="server"
                            Text="View"
                            CssClass="btn btn-warning"
                            CausesValidation="false"
                            OnClientClick="window.open('OrderOfTheDay.aspx', '_blank'); return false;" />


                        <asp:Button
                            ID="AddAgenda"
                            runat="server"
                            Text="Add"
                            CssClass="btn btn-custom"
                            ValidationGroup="SaveGroup"
                            OnClick="AddAgenda_Click" />

                    </div>

                </div>

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

                    <span id="MeetingTimeSpan" runat="server"></span>

                   

                </div>

                <div class="orders-header-rule">
                </div>

            </div>


            <asp:ListView
                ID="lv"
                runat="server"
                DataKeyNames="OrderOfDayBusinessId"
                OnItemEditing="lv_ItemEditing"
                OnItemUpdating="lv_ItemUpdating"
                OnItemCanceling="lv_ItemCanceling"
                OnItemDeleting="lv_ItemDeleting"
                OnItemDataBound="lv_ItemDataBound"
                OnItemCreated="ItemCreated">

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
                                            No files attached to this point.
                                        </div>

                                    </EmptyDataTemplate>

                                </asp:ListView>

                                 <div style="text-align:right">Sort Order: <asp:Literal
                                    ID="Literal1"
                                    runat="server"
                                    Mode="PassThrough"
                                    Text='<%# Eval("SortOrder") %>'>
                                </asp:Literal></div>
                            </div>

                        </div>


                        <div class="agenda-actions no-print">

                            <asp:LinkButton
                                ID="EditButton"
                                runat="server"
                                CommandName="Edit"
                                CausesValidation="false"
                                CssClass="btn btn-xs btn-primary">

                                <span class="glyphicon glyphicon-edit"></span>
                                Edit

                            </asp:LinkButton>


                            <asp:LinkButton
                                ID="DeleteButton"
                                runat="server"
                                CommandName="Delete"
                                CausesValidation="false"
                                CssClass="btn btn-xs btn-danger"
                                OnClientClick="return confirm('Are you sure you want to delete this agenda item?');">

                                <span class="glyphicon glyphicon-trash"></span>
                                Delete

                            </asp:LinkButton>

                        </div>

                    </div>

                </ItemTemplate>


                <EditItemTemplate>

                    <div class="accordion-source-header">

                        <span class="source-business-type">
                            <%# Eval("BusinessTypesDescription") %>
                        </span>

                        <span class="source-business-rule">
                            <%# Eval("BusinessRule") %>
                        </span>

                    </div>


                    <div id="activeEditItem"
                        class="edit-item no-print">

                        <div class="edit-heading">

                            <div class="edit-heading-title">
                                EDIT AGENDA ITEM
                            </div>

                            <div class="edit-heading-small">
                                Agenda No. <%# Eval("SortOrder") %>
                            </div>

                        </div>


                        <div class="row">

                            <div class="col-md-8">

                                <div class="edit-label">
                                    Business Type
                                </div>

                                <asp:DropDownList
                                    ID="EditBusinessTypeDDL"
                                    runat="server"
                                    CssClass="form-control">
                                </asp:DropDownList>

                            </div>


                            <div class="col-md-4">

                                <div class="edit-label">
                                    Sort Order
                                </div>

                                <asp:TextBox
                                    ID="EditSortOrderTxt"
                                    runat="server"
                                    TextMode="Number"
                                    CssClass="form-control"
                                    Text='<%# Eval("SortOrder") %>'>
                                </asp:TextBox>

                            </div>

                        </div>


                        <div class="row"
                            style="margin-top:12px;">

                            <div class="col-md-12">

                                <div class="edit-label">
                                    Description
                                </div>

                                <asp:TextBox
                                    ID="EditDescriptionTxt"
                                    runat="server"
                                    TextMode="MultiLine"
                                    Rows="6"
                                    CssClass="form-control edit-description-editor"
                                    Text='<%# Eval("Description") %>'>
                                </asp:TextBox>

                            </div>

                        </div>


                        <div class="edit-attachment-section">

                            <div class="edit-attachment-section-title">
                                Existing Attachments
                            </div>


                            <asp:ListView
                                ID="lvEditAttachments"
                                runat="server"
                                DataSource='<%# Eval("Attachemnts") %>'>

                                <LayoutTemplate>

                                    <div class="edit-attachment-list">

                                        <asp:PlaceHolder
                                            ID="itemPlaceholder"
                                            runat="server">
                                        </asp:PlaceHolder>

                                    </div>

                                </LayoutTemplate>


                                <ItemTemplate>

                                    <div class="edit-attachment-item">

                                        <asp:HiddenField
                                            ID="AttachmentPathHidden"
                                            runat="server"
                                            Value='<%# Eval("Attachment") %>' />


                                        <div class="edit-attachment-icon">

                                            <img
                                                src='<%# ResolveUrl("~/Images/pdf-icon.png") %>'
                                                alt="PDF" />

                                        </div>


                                        <div class="edit-attachment-name">

                                            <a
                                                href='<%# ResolveUrl(Convert.ToString(Eval("Attachment"))) %>'
                                                target="_blank">

                                                <%#
                                                    System.IO.Path.GetFileName(
                                                        Convert.ToString(
                                                            Eval("Attachment")
                                                        )
                                                    )
                                                %>

                                            </a>

                                        </div>


                                        <label class="remove-attachment">

                                            <asp:CheckBox
                                                ID="RemoveAttachmentChk"
                                                runat="server" />

                                            Remove

                                        </label>

                                    </div>

                                </ItemTemplate>


                                <EmptyDataTemplate>

                                    <div class="no-edit-attachments">
                                        No existing attachments.
                                    </div>

                                </EmptyDataTemplate>

                            </asp:ListView>


                            <div class="edit-new-attachment">

                                <div class="edit-label">
                                    Add New Attachments
                                </div>

                                <asp:FileUpload
                                    ID="EditBusinessAttachments"
                                    runat="server"
                                    CssClass="form-control"
                                    AllowMultiple="true" data-scan="true" />

                                <span class="edit-upload-help">
                                    Select one or more PDF files. Existing files remain unless Remove is selected.
                                </span>

                            </div>

                        </div>


                        <div class="edit-buttons">

                            <asp:LinkButton
                                ID="UpdateButton"
                                runat="server"
                                CommandName="Update"
                                CausesValidation="false"
                                CssClass="btn btn-success">

                                <span class="glyphicon glyphicon-ok"></span>
                                Update

                            </asp:LinkButton>


                            <asp:LinkButton
                                ID="CancelButton"
                                runat="server"
                                CommandName="Cancel"
                                CausesValidation="false"
                                CssClass="btn btn-default">

                                <span class="glyphicon glyphicon-remove"></span>
                                Cancel

                            </asp:LinkButton>

                        </div>

                    </div>

                </EditItemTemplate>

            </asp:ListView>

        </div>

    </div>


    <script type="text/javascript">

        function initializeOrderEditors() {

            var $addEditor =
                $('#ContentPlaceHolder1_DescriptionTxt');


            if ($addEditor.length > 0 &&
                !$addEditor.hasClass('summernote-initialized')) {

                $addEditor.addClass(
                    'summernote-initialized'
                );


                $addEditor.summernote({

                    height: 90,

                    toolbar: [

                        [
                            'style',
                            [
                                'bold',
                                'italic',
                                'underline'
                            ]
                        ],

                        [
                            'para',
                            [
                                'ul',
                                'ol',
                                'paragraph'
                            ]
                        ],

                        [
                            'insert',
                            [
                                'table'
                            ]
                        ],

                        [
                            'view',
                            [
                                'codeview'
                            ]
                        ]

                    ]

                });
            }


            $('.edit-description-editor').each(
                function () {

                    var $editor =
                        $(this);


                    if (!$editor.hasClass(
                        'summernote-initialized')) {

                        $editor.addClass(
                            'summernote-initialized'
                        );


                        $editor.summernote({

                            height: 140,

                            toolbar: [

                                [
                                    'style',
                                    [
                                        'bold',
                                        'italic',
                                        'underline'
                                    ]
                                ],

                                [
                                    'para',
                                    [
                                        'ul',
                                        'ol',
                                        'paragraph'
                                    ]
                                ],

                                [
                                    'insert',
                                    [
                                        'table'
                                    ]
                                ],

                                [
                                    'view',
                                    [
                                        'codeview'
                                    ]
                                ]

                            ]

                        });
                    }
                });
        }


        function cleanBusinessText(value) {

            if (!value) {
                return '';
            }


            return $.trim(
                $('<div>')
                    .html(value)
                    .text()
            );
        }


        function createBusinessPanel(
            accordionId,
            index,
            businessType,
            businessRule) {

            var collapseId =
                accordionId +
                '_collapse_' +
                index;


            var $panel =
                $('<div>')
                    .addClass(
                        'panel panel-default business-panel'
                    );


            var $heading =
                $('<div>')
                    .addClass(
                        'panel-heading business-panel-heading'
                    )
                    .attr(
                        'role',
                        'tab'
                    );


            var $toggle =
                $('<a>')
                    .addClass(
                        'business-panel-toggle'
                    )
                    .attr(
                        'role',
                        'button'
                    )
                    .attr(
                        'data-toggle',
                        'collapse'
                    )
                    .attr(
                        'href',
                        '#' + collapseId
                    )
                    .attr(
                        'aria-expanded',
                        'true'
                    )
                    .attr(
                        'aria-controls',
                        collapseId
                    );


            var $left =
                $('<div>')
                    .addClass(
                        'business-heading-left'
                    );


            var $icon =
                $('<span>')
                    .addClass(
                        'glyphicon glyphicon-chevron-down business-collapse-icon'
                    );


            var $headingText =
                $('<div>')
                    .addClass(
                        'business-heading-text'
                    );


            var $title =
                $('<span>')
                    .addClass(
                        'business-heading-title'
                    )
                    .text(
                        businessType
                    );


            var $rule =
                $('<span>')
                    .addClass(
                        'business-heading-rule'
                    );


            if (businessRule) {

                $rule.text(
                    businessRule
                );
            }


            $headingText
                .append(
                    $title
                )
                .append(
                    $rule
                );


            $left
                .append(
                    $icon
                )
                .append(
                    $headingText
                );


            var $right =
                $('<div>')
                    .addClass(
                        'business-heading-right'
                    );


            var $count =
                $('<span>')
                    .addClass(
                        'business-item-count'
                    )
                    .text(
                        '0 Items'
                    );


            $right.append(
                $count
            );


            $toggle
                .append(
                    $left
                )
                .append(
                    $right
                );


            $heading.append(
                $toggle
            );


            var $collapse =
                $('<div>')
                    .attr(
                        'id',
                        collapseId
                    )
                    .addClass(
                        'panel-collapse collapse in'
                    )
                    .attr(
                        'role',
                        'tabpanel'
                    );


            var $body =
                $('<div>')
                    .addClass(
                        'panel-body business-panel-body'
                    );


            $collapse.append(
                $body
            );


            $panel
                .append(
                    $heading
                )
                .append(
                    $collapse
                );


            $panel.data(
                'business-body',
                $body
            );


            $panel.data(
                'business-count',
                $count
            );


            return $panel;
        }


        function buildBusinessTypeAccordions() {

            $('.agenda-list').each(
                function (listIndex) {

                    var $agendaList =
                        $(this);


                    if ($agendaList.hasClass(
                        'business-accordion-built')) {

                        return;
                    }


                    var $children =
                        $agendaList.children();


                    if ($children.length === 0) {

                        return;
                    }


                    var accordionId =
                        'businessAccordion_' +
                        listIndex +
                        '_' +
                        new Date().getTime();


                    var $accordion =
                        $('<div>')
                            .attr(
                                'id',
                                accordionId
                            )
                            .addClass(
                                'panel-group business-accordion'
                            )
                            .attr(
                                'role',
                                'tablist'
                            );


                    var currentPanel = null;
                    var currentBody = null;
                    var currentType = '';
                    var currentRule = '';
                    var currentCount = 0;
                    var panelIndex = 0;


                    function updateCurrentCount() {

                        if (!currentPanel) {
                            return;
                        }


                        var $count =
                            currentPanel.data(
                                'business-count'
                            );


                        if (!$count) {
                            return;
                        }


                        if (currentCount === 1) {

                            $count.text(
                                '1 Item'
                            );

                        } else {

                            $count.text(
                                currentCount +
                                ' Items'
                            );

                        }
                    }


                    $children.each(
                        function () {

                            var $element =
                                $(this);


                            if ($element.hasClass(
                                'accordion-source-header')) {


                                updateCurrentCount();


                                var businessType =
                                    cleanBusinessText(
                                        $element
                                            .find(
                                                '.source-business-type'
                                            )
                                            .html()
                                    );


                                var businessRule =
                                    cleanBusinessText(
                                        $element
                                            .find(
                                                '.source-business-rule'
                                            )
                                            .html()
                                    );


                                if (
                                    currentPanel &&
                                    currentType === businessType &&
                                    currentRule === businessRule
                                ) {

                                    $element.remove();

                                    return;
                                }


                                panelIndex++;


                                currentType =
                                    businessType;


                                currentRule =
                                    businessRule;


                                currentCount =
                                    0;


                                currentPanel =
                                    createBusinessPanel(
                                        accordionId,
                                        panelIndex,
                                        businessType,
                                        businessRule
                                    );


                                currentBody =
                                    currentPanel.data(
                                        'business-body'
                                    );


                                $accordion.append(
                                    currentPanel
                                );


                                $element.remove();

                                return;
                            }


                            if (
                                $element.hasClass(
                                    'agenda-item'
                                )
                                ||
                                $element.hasClass(
                                    'edit-item'
                                )
                            ) {

                                if (!currentPanel) {

                                    panelIndex++;


                                    currentType =
                                        'OTHER BUSINESS';


                                    currentRule =
                                        '';


                                    currentCount =
                                        0;


                                    currentPanel =
                                        createBusinessPanel(
                                            accordionId,
                                            panelIndex,
                                            currentType,
                                            currentRule
                                        );


                                    currentBody =
                                        currentPanel.data(
                                            'business-body'
                                        );


                                    $accordion.append(
                                        currentPanel
                                    );
                                }


                                currentBody.append(
                                    $element
                                );


                                currentCount++;

                                return;
                            }


                            if (currentBody) {

                                currentBody.append(
                                    $element
                                );
                            }

                        }
                    );


                    updateCurrentCount();


                    $agendaList
                        .empty()
                        .append(
                            $accordion
                        )
                        .addClass(
                            'business-accordion-built'
                        );


                    $accordion
                        .find(
                            '.panel-collapse'
                        )
                        .on(
                            'shown.bs.collapse',
                            function () {

                                $(this)
                                    .prev(
                                        '.business-panel-heading'
                                    )
                                    .find(
                                        '.business-collapse-icon'
                                    )
                                    .removeClass(
                                        'glyphicon-chevron-right'
                                    )
                                    .addClass(
                                        'glyphicon-chevron-down'
                                    );

                            }
                        );


                    $accordion
                        .find(
                            '.panel-collapse'
                        )
                        .on(
                            'hidden.bs.collapse',
                            function () {

                                $(this)
                                    .prev(
                                        '.business-panel-heading'
                                    )
                                    .find(
                                        '.business-collapse-icon'
                                    )
                                    .removeClass(
                                        'glyphicon-chevron-down'
                                    )
                                    .addClass(
                                        'glyphicon-chevron-right'
                                    );

                            }
                        );

                }
            );
        }


        function scrollToActiveEditItem() {

            window.setTimeout(
                function () {

                    var editItem =
                        document.getElementById(
                            'activeEditItem'
                        );


                    if (!editItem) {

                        return;
                    }


                    var $collapse =
                        $(editItem)
                            .closest(
                                '.panel-collapse'
                            );


                    if ($collapse.length > 0) {

                        $collapse
                            .addClass('in')
                            .css(
                                'height',
                                'auto'
                            );
                    }


                    editItem.scrollIntoView({

                        behavior: 'auto',

                        block: 'center'

                    });

                },
                100
            );
        }


        function initializeOrdersPage() {

            initializeOrderEditors();

            buildBusinessTypeAccordions();


            if (
                document.getElementById(
                    'activeEditItem'
                )
            ) {

                scrollToActiveEditItem();
            }
        }


        $(document).ready(
            function () {

                initializeOrdersPage();

            }
        );


        if (
            typeof (Sys) !== 'undefined'
            &&
            Sys.WebForms
            &&
            Sys.WebForms.PageRequestManager
        ) {

            Sys.WebForms.PageRequestManager
                .getInstance()
                .add_endRequest(
                    function () {

                        initializeOrdersPage();

                    }
                );
        }


        function printOrdersOfDay() {

            $('.business-accordion .panel-collapse')
                .addClass('in')
                .css(
                    'height',
                    'auto'
                );


            window.print();
        }

    </script>

</asp:Content>