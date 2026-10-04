<%@ Page Title="Create Order of the Day"
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="CreateOrderOfTheDay.aspx.cs"
    Inherits="Legislation.CreateOrderOfTheDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="CustomScripts/jquery.min.js"></script>
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />

    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />

    <style type="text/css">

        .order-page {
            padding-top: 15px;
            padding-bottom: 30px;
        }

        .order-card {
            background: #ffffff;
            border: 1px solid #e5e5e5;
            border-radius: 8px;
            margin-bottom: 20px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08);
            overflow: hidden;
        }

        .order-card-header {
            background: #C19A6B;
            color: #ffffff;
            padding: 14px 20px;
            font-size: 18px;
            font-weight: 600;
        }

        .order-card-body {
            padding: 20px;
        }

        .form-row {
            margin-bottom: 15px;
        }

        .form-label {
            font-weight: 600;
            color: #333333;
            padding-top: 8px;
        }

        .form-control {
            border-radius: 4px;
            min-height: 36px;
        }

        .form-control:focus {
            border-color: #a2070f;
            box-shadow: 0 0 0 2px rgba(162, 7, 15, 0.10);
        }

        .btn-order-primary {
            background-color: #C19A6B;
            border: 1px solid #C19A6B;
            color: #ffffff;
            min-width: 100px;
            border-radius: 4px;
            padding: 7px 16px;
            font-weight: 600;
        }

        .btn-order-primary:hover,
        .btn-order-primary:focus {
            background-color: #85060c;
            border-color: #85060c;
            color: #ffffff;
        }

        .btn-order-edit {
            background-color: #f0ad4e;
            border: 1px solid #eea236;
            color: #ffffff;
            border-radius: 4px;
            padding: 5px 12px;
            margin-right: 4px;
        }

        .btn-order-edit:hover {
            background-color: #ec971f;
            color: #ffffff;
        }

        .btn-order-delete {
            background-color: #d9534f;
            border: 1px solid #d43f3a;
            color: #ffffff;
            border-radius: 4px;
            padding: 5px 12px;
        }

        .btn-order-delete:hover {
            background-color: #c9302c;
            color: #ffffff;
        }

        .btn-order-update {
            background-color: #5cb85c;
            border: 1px solid #4cae4c;
            color: #ffffff;
            border-radius: 4px;
            padding: 5px 12px;
            margin-right: 4px;
        }

        .btn-order-update:hover {
            background-color: #449d44;
            color: #ffffff;
        }

        .btn-order-cancel {
            background-color: #777777;
            border: 1px solid #666666;
            color: #ffffff;
            border-radius: 4px;
            padding: 5px 12px;
        }

        .btn-order-cancel:hover {
            background-color: #5e5e5e;
            color: #ffffff;
        }

        .order-table-wrapper {
            overflow-x: auto;
        }

        .order-table {
            width: 100%;
            margin-bottom: 0;
            border-collapse: collapse;
        }

        .order-table thead th {
            background-color: #B18F6A;
            color: #ffffff;
            vertical-align: middle;
            border: 1px solid #8e060d;
            padding: 11px 8px;
            font-size: 13px;
            white-space: nowrap;
        }

        .order-table tbody td {
            vertical-align: middle !important;
            border: 1px solid #dddddd;
            padding: 9px 8px !important;
            font-size: 13px;
        }

        .order-table tbody tr:nth-child(even) {
            background-color: #fafafa;
        }

        .order-table tbody tr:hover {
            background-color: #fff4f4;
        }

        .edit-row {
            background-color: #fff8e8 !important;
        }

        .sitting-link {
            color: #a2070f !important;
            font-weight: 600;
            text-decoration: none;
        }

        .sitting-link:hover {
            color: #76050a !important;
            text-decoration: underline;
        }

        .status-badge {
            display: inline-block;
            padding: 5px 10px;
            border-radius: 15px;
            font-size: 11px;
            font-weight: 600;
            min-width: 65px;
            text-align: center;
        }

        .status-active {
            background-color: #dff0d8;
            color: #3c763d;
            border: 1px solid #c6e9b8;
        }

        .status-inactive {
            background-color: #f2dede;
            color: #a94442;
            border: 1px solid #ebcccc;
        }

        .section-title {
            margin: 0;
        }

        .section-description {
            color: #777777;
            font-size: 13px;
            margin-top: 4px;
        }

        .action-cell {
            white-space: nowrap;
            min-width: 145px;
        }

        .sr-cell {
            width: 60px;
            text-align: center;
        }

        .status-cell {
            width: 95px;
            text-align: center;
        }

        .empty-state {
            text-align: center;
            padding: 30px !important;
            color: #777777;
            font-size: 14px;
        }

        @media (max-width: 767px) {

            .form-label {
                padding-top: 0;
                margin-bottom: 5px;
            }

            .order-card-body {
                padding: 15px;
            }

            .order-card-header {
                font-size: 16px;
            }
        }

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container order-page">

        <div class="order-card">

            <div class="order-card-header">
                Create Order of the Day
            </div>

            <div class="order-card-body">

                <div class="row form-row">

                    <div class="col-md-2 col-sm-3">
                        <label class="form-label">Session Sitting</label>
                    </div>

                    <div class="col-md-8 col-sm-9">

                        <asp:DropDownList
                            ID="SessionSittingDDL"
                            runat="server"
                            CssClass="form-control">
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="row form-row">

                    <div class="col-md-2 col-sm-3">
                        <label class="form-label">Order of the Day Type</label>
                    </div>

                    <div class="col-md-8 col-sm-9">

                        <asp:DropDownList
                            ID="ODTypeDDL"
                            runat="server"
                            CssClass="form-control">
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="row form-row">

                    <div class="col-md-2 col-sm-3">
                        <label class="form-label">Main Description</label>
                    </div>

                    <div class="col-md-8 col-sm-9">

                        <asp:TextBox
                            ID="MainDescriptionTxt"
                            runat="server"
                            CssClass="form-control"
                            Text="Main Order of The day">
                        </asp:TextBox>

                    </div>

                </div>

                <div class="row form-row">

                    <div class="col-md-2 col-sm-3">
                        <label class="form-label">Supplementary Description</label>
                    </div>

                    <div class="col-md-8 col-sm-9">

                        <asp:TextBox
                            ID="SupplimentaryDescriptionTxt"
                            runat="server"
                            CssClass="form-control"
                            Text="Supplimentary Order of The day">
                        </asp:TextBox>

                    </div>

                </div>

                <div class="row">

                    <div class="col-md-offset-2 col-md-8 col-sm-offset-3 col-sm-9">

                        <asp:Button
                            ID="AddBtn"
                            runat="server"
                            Text="Add Order"
                            CssClass="btn btn-order-primary"
                            OnClick="AddBtn_Click" />

                    </div>

                </div>

            </div>

        </div>


        <div class="order-card">

            <div class="order-card-header">

                <div class="section-title">
                    Order of the Days
                </div>

            </div>

            <div class="order-card-body" style="padding: 0;">

                <div class="order-table-wrapper">

                    <table class="table order-table">

                        <thead>

                            <tr>
                                <th class="sr-cell">Sr. No.</th>
                                <th>Sitting Day</th>
                                <th>OD Type</th>
                                <th>Main Description</th>
                                <th>Supplementary Description</th>
                                <th class="status-cell">Status</th>
                                <th>Action</th>
                            </tr>

                        </thead>

                        <tbody>

                            <asp:ListView
                                runat="server"
                                ID="lv"
                                OnItemDeleting="lv_ItemDeleting"
                                OnItemEditing="lv_ItemEditing"
                                OnItemCanceling="lv_ItemCanceling"
                                OnItemUpdating="lv_ItemUpdating"
                                OnItemDataBound="lv_DataBound">

                                <ItemTemplate>

                                    <tr>

                                        <td class="sr-cell">

                                            <asp:Label
                                                ID="SrNo"
                                                runat="server"
                                                Text='<%# Container.DataItemIndex + 1 %>'>
                                            </asp:Label>

                                            <asp:HiddenField
                                                ID="HidOrderOfDaysId"
                                                runat="server"
                                                Value='<%# Eval("OrderOfDaysId") %>' />

                                        </td>

                                        <td>

                                            <asp:HyperLink
                                                ID="OrderLink"
                                                runat="server"
                                                CssClass="sitting-link"
                                                Target="_blank"
                                                NavigateUrl='<%# GetLink(Eval("OrderOfDaysId").ToString()) %>'
                                                Text='<%# Eval("SittingDayDescription") %>'>
                                            </asp:HyperLink>

                                        </td>

                                        <td>

                                            <asp:Label
                                                ID="OrderTypeLbl"
                                                runat="server"
                                                Text='<%# Eval("OrderOfTheDayType") %>'>
                                            </asp:Label>

                                        </td>

                                        <td>

                                            <asp:Label
                                                ID="MainDescriptionLbl"
                                                runat="server"
                                                Text='<%# Eval("MainOrderDescription") %>'>
                                            </asp:Label>

                                        </td>

                                        <td>

                                            <asp:Label
                                                ID="SupplementaryDescriptionLbl"
                                                runat="server"
                                                Text='<%# Eval("SupplementaryOrderDesc") %>'>
                                            </asp:Label>

                                        </td>

                                        <td class="status-cell">

                                            <span class='<%# GetActiveCss(Eval("IsActive")) %>'>
                                                <%# GetActiveText(Eval("IsActive")) %>
                                            </span>

                                        </td>

                                        <td class="action-cell">

                                            <asp:Button
                                                ID="EditBtn"
                                                runat="server"
                                                Text="Edit"
                                                CommandName="edit"
                                                CssClass="btn btn-order-edit btn-sm" />

                                            <asp:Button
                                                ID="DeleteBtn"
                                                runat="server"
                                                Text="Delete"
                                                CommandName="delete"
                                                CssClass="btn btn-order-delete btn-sm"
                                                OnClientClick="return confirm('Are you sure you want to delete this Order of the Day?');" />

                                        </td>

                                    </tr>

                                </ItemTemplate>


                                <EditItemTemplate>

                                    <tr class="edit-row">

                                        <td class="sr-cell">

                                            <asp:Label
                                                ID="SrNo"
                                                runat="server"
                                                Text='<%# Container.DataItemIndex + 1 %>'>
                                            </asp:Label>

                                            <asp:HiddenField
                                                ID="HidOrderOfDaysId"
                                                runat="server"
                                                Value='<%# Eval("OrderOfDaysId") %>' />

                                            <asp:HiddenField
                                                ID="HidSessionSittingsId"
                                                runat="server"
                                                Value='<%# Eval("SessionSittingsId") %>' />

                                            <asp:HiddenField
                                                ID="HidOrderOfDayTypesId"
                                                runat="server"
                                                Value='<%# Eval("OrderOfDayTypesId") %>' />

                                            <asp:HiddenField
                                                ID="HidIsActive"
                                                runat="server"
                                                Value='<%# Eval("IsActive") %>' />

                                        </td>

                                        <td>

                                            <asp:Label
                                                ID="DescriptionTxt"
                                                runat="server"
                                                CssClass="form-control"
                                                Text='<%# Eval("SittingDayDescription") %>'>
                                            </asp:Label>

                                        </td>

                                        <td>

                                            <asp:DropDownList
                                                ID="EditODTypeDDL"
                                                runat="server"
                                                CssClass="form-control">
                                            </asp:DropDownList>

                                        </td>

                                        <td>

                                            <asp:TextBox
                                                ID="MainOrderDescriptionTxt"
                                                runat="server"
                                                CssClass="form-control"
                                                Text='<%# Bind("MainOrderDescription") %>'>
                                            </asp:TextBox>

                                        </td>

                                        <td>

                                            <asp:TextBox
                                                ID="SupplementaryOrderDescTxt"
                                                runat="server"
                                                CssClass="form-control"
                                                Text='<%# Bind("SupplementaryOrderDesc") %>'>
                                            </asp:TextBox>

                                        </td>

                                        <td>

                                            <asp:DropDownList
                                                ID="IsActiveDDL"
                                                runat="server"
                                                CssClass="form-control">

                                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>

                                            </asp:DropDownList>

                                        </td>

                                        <td class="action-cell">

                                            <asp:Button
                                                ID="UpdateBtn"
                                                runat="server"
                                                Text="Update"
                                                CommandName="update"
                                                CssClass="btn btn-order-update btn-sm" />

                                            <asp:Button
                                                ID="CancelBtn"
                                                runat="server"
                                                Text="Cancel"
                                                CommandName="cancel"
                                                CssClass="btn btn-order-cancel btn-sm"
                                                CausesValidation="false" />

                                        </td>

                                    </tr>

                                </EditItemTemplate>


                                <EmptyDataTemplate>

                                    <tr>
                                        <td colspan="7" class="empty-state">
                                            No Order of the Day records found.
                                        </td>
                                    </tr>

                                </EmptyDataTemplate>

                            </asp:ListView>

                        </tbody>

                    </table>

                </div>

            </div>

        </div>

    </div>

</asp:Content>