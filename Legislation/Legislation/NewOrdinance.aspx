<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewOrdinance.aspx.cs" Inherits="Legislation.NewOrdinance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                NEW ORDINANCE
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Parliamentary Year:</label>
                <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session:</label>
                <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Date of Promulgation:</label>
                <asp:TextBox ID="DateOfPromulgationTxt" ValidationGroup="Group1" Required="true" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryTimeTxt" runat="server" ErrorMessage="Enter Promulgation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="DateOfPromulgationTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Title:</label>
                <asp:TextBox ID="TitleTxt" ValidationGroup="Group1" TextMode="Multiline" Rows="5" class="form-control small-control datepicker" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Title of Oridinance" ValidationGroup="SaveGroup" Display="None" ControlToValidate="TitleTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">
                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 99999999999999);
                    }, 0);
                },
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: 0,
                onSelect: function (dateText, inst) { }
            });
        });
    </script>
</asp:Content>
