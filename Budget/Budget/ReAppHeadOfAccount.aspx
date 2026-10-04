<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReAppHeadOfAccount.aspx.cs" Inherits="Budget.ReAppHead_OfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Styles/MainStyles.css" rel="stylesheet" />
      <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style type="text/css">
         .textboxline {
            border: none;
            border-bottom: solid thin;
            font-size: 15px;
            border-bottom-color:#000;
            height:30px;
            background-color:#fff;
            color:#000;
            font-size:11pt;
            border-radius:unset;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                <h4>
                     <asp:Label ID="fylabel" runat="server"></asp:Label>
                    
                </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <label style="font-size: small; font-weight: bold">From Head of Account:</label>
                <asp:TextBox CssClass="textboxline form-control hoafrom " ID="FromHOATxt" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidhoaFrom" runat="server" Value='' />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
                <label style="font-size: small; font-weight: bold">To Head of Account:</label>
                <asp:TextBox CssClass="textboxline form-control hoato" ID="ToHOATxt" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidhoaTo" runat="server" Value='' />
            </div>
              
            </div>
          
            <div class="row">
            <div class="col-md-4">
                <label style="font-size: small; font-weight: bold">Reappropriate Amount:</label>
                <asp:TextBox CssClass="textboxline form-control hoa" ID="AmountTxt" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">Re-Appropriation Date:</label>
                <asp:TextBox CssClass="textboxline form-control" ID="ReAppDate" runat="server"></asp:TextBox>
            </div>
         

    </div>
         <div class="row">
             
            <div class="col-md-7">
                <label style="font-size: small; font-weight: bold">Remarks:</label>
                <asp:TextBox CssClass="textboxline form-control" TextMode="MultiLine" ID="RemarksTxt" runat="server"></asp:TextBox>
            </div>
              
            </div>
        <div class="clearfix" style="margin-top: 10px;"></div>
        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="transfer" CssClass="btn btn-success" runat="server" Text="Re-Appropriate" OnClick="transfer_Click" />
            </div>
               <div class="col-md-5">
                <br />
                <asp:Label ID="err" style="font-size:11pt;color:red" runat="server"></asp:Label>
                <asp:Label ID="success" style="font-size:11pt;" runat="server"></asp:Label>
            </div>
        </div>
    </div>
     <script type="text/javascript">
        $(function () {
            $(".hoafrom").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetFromHeadOfAccountsWithBudget")%>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0] + "-- Rs." + item.split('=')[2],
                                    val: item.split('=')[1],
                                    amount: item.split('=')[2]
                                }
                            }))
                        },
                        error: function (response) {
                            alert("error");
                        },
                        failure: function (response) {
                            alert("failure");
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidhoaFrom]").val(i.item.val);
                 

                },
                minLength: 2
            });
        });
            $(function () {
            $(".hoato").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetToHeadOfAccountsWithBudget")%>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0] + "-- Rs." + item.split('=')[2],
                                    val: item.split('=')[1],
                                    amount: item.split('=')[2]
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
                    $("[id$=HidhoaTo]").val(i.item.val);
                  
                },
                minLength: 2
            });
          });
</script>
</asp:Content>
