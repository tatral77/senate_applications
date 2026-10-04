<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSeatingPlan.aspx.cs" Inherits="Notice.ManageSeatingPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <script src="CustomScripts/jquery.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
<%--  <link href="./Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="CustomScripts/jquery-ui.min.js"></script>
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />
    <meta charset="UTF-8" />
<%--    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />--%>
    <title>Seating Plan</title>
    <script type="text/javascript">
        function ShowDetails(div) {
            var memberid = document.getElementById(div.id).firstChild.id;
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
            document.getElementById('SeatNumber').innerText = div.getElementById("H1212").value;
            document.getElementById('HidSeatNumber').value = div.id;         
        }
        function CloseDetails() {
            document.getElementById('light').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }



    </script>
    <style type="text/css">

        .black_overlay {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }
        div{
            padding:0px;
            margin:0px;
        }

        .white_content {
            display: none;
            position: absolute;
            top: 25%;
            left: 25%;
            width: 50%;
            height: 20%;
            padding: 16px;
            border: 2px solid #000;
            background-color: #98FB98;
            z-index: 1002;
            overflow: auto;
        }




        div:nth-child(1) {
            top: 90px;
        }

        div:nth-child(2) {
            top: 80px;
        }

        div:nth-child(3) {
            top: 70px;
        }

        div:nth-child(4) {
            top: 60px;
        }

        div:nth-child(5) {
            top: 50px;
        }

        div:nth-child(6) {
            top: 40px;
        }

        div:nth-child(7) {
            top: 30px;
        }

        div:nth-child(8) {
            top: 20px;
        }

        div:nth-child(9) {
            top: 10px;
        }

        div:nth-child(10) {
            top: 10px;
        }

        div:nth-child(11) {
            top: 10px;
        }

        div:nth-child(12) {
            top: 20px;
        }

        div:nth-child(13) {
            top: 30px;
        }

        div:nth-child(14) {
            top: 40px;
        }

        div:nth-child(15) {
            top: 50px;
        }

        div:nth-child(16) {
            top: 60px;
        }

        div:nth-child(17) {
            top: 70px;
        }

        div:nth-child(18) {
            top: 80px;
        }

        div:nth-child(19) {
            top: 90px;
        }

           

        div:nth-of-type(even) {
            background: #fff;
        }

        .my-row {
            margin-right: 20px;
            margin-left: 20px;
            width: 100%;
        }

        .bdr {
            border: 1px solid #000;
            border-radius: 10px;
            font-size: 11px;
            min-height: 60px;
            min-width:55px;
            text-align: center;
            position: fixed;
            word-wrap:break-word;
            font-weight:bold;
        }

        .my-col, .chariman {
            position: relative;
            width: 65px;
            padding-right: 5px;
            padding-left: 5px;
            float: left;
            margin-right: 10px;
            position: relative;
        }

        .my-col-left {
            transform: rotate(-5deg);
        }

        .my-col-right {
            transform: rotate(5deg);
        }

        .my-row2-height {
            min-height: 20px;
            margin-top: 3px;
            margin-right: 10px;
            background-color: transparent !important;
            font-weight: bold;
            text-align: right;
        }

        .chariman {
            margin: 0px auto !important;
            left: 45%;
            min-height: 50px;
            border: 2px solid #8f8f8f;
        }

        body {
            padding: 0;
            margin: 0;
        }

        .clearfix {
            clear: both;
        }

        .blank-div {
            width: 35px;
            float: left;
            position: relative;
            /* border:1px solid black; */
            color: transparent;
        }
    </style>
</head>

<body>
    <form runat="server" id="f1">


        <div id="light" class="white_content">
            <table>
                <tr><th>Seat Number:<asp:Label ID="SeatNumber" runat="server"></asp:Label></th></tr>
                <tr>
                    <td>Member Name</td>
                    <td> <asp:TextBox ID="MemberNameTxt" runat="server" Style="width:250px;">

                         </asp:TextBox>
                        <asp:HiddenField ID="HidSeatNumber" runat="server" />
                        <asp:HiddenField ID="HidMemberId" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="anassignbtn" runat="server" Text="Un Assign" />
                         <asp:Button ID="savebtn" runat="server" Text="Save" OnClick="savebtn_Click" />
                         <asp:Button ID="cancelbtn" runat="server" Text="Cancel" OnClientClick="CloseDetails()" />
                    </td>
                </tr>
            </table>
              
        </div>
        <div id="fade" class="black_overlay"></div>



        <table style="min-width: 120%">
            <tr>
                <td style="min-width: 100%">
                    <div class="my-row">
                        <div id="F109" title="This is tooltip" runat="server" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F108" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F107" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F106" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F105" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F104" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F103" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                       </div>
                        <div id="F102" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F101" class="my-col bdr my-col-left" onclick="ShowDetails(this)">
                            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="blank-div">c</div>

                            <div id="F100" title="This is tooltip" runat="server" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F99" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F98" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F97" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F96" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F95" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F94" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                       </div>
                        <div id="F93" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div id="F92" class="my-col bdr my-col-right" onclick="ShowDetails(this)">
                            <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                        </div>                    
                       
                    </div>
                    <div class="clearfix"></div>
                    <div class="my-row">
                        <div class="my-row2-height my-col my-col-left">109</div>
                        <div class="my-row2-height my-col my-col-left">108</div>
                        <div class="my-row2-height my-col my-col-left">107</div>
                        <div class="my-row2-height my-col my-col-left">106</div>
                        <div class="my-row2-height my-col my-col-left">105</div>
                        <div class="my-row2-height my-col my-col-left">104</div>
                        <div class="my-row2-height my-col my-col-left">103</div>
                        <div class="my-row2-height my-col my-col-left">102</div>
                        <div class="my-row2-height my-col my-col-left">101</div>
                        <div class="blank-div">c</div>
                        <div class="my-row2-height my-col my-col-right">100</div>
                        <div class="my-row2-height my-col my-col-right">99</div>
                        <div class="my-row2-height my-col my-col-right">98</div>
                        <div class="my-row2-height my-col my-col-right">97</div>
                        <div class="my-row2-height my-col my-col-right">96</div>
                        <div class="my-row2-height my-col my-col-right">95</div>
                        <div class="my-row2-height my-col my-col-right">94</div>
                        <div class="my-row2-height my-col my-col-right">93</div>
                        <div class="my-row2-height my-col my-col-right">92</div>
                    </div>
                    <div class="clearfix"></div>
                    <%-- <div class="my-row">
                                <div id="1" class="my-col bdr my-col-left">First</div>
                                <div id="2" class="my-col bdr my-col-left">Second</div>
                                <div id="3" class="my-col bdr my-col-left">Third</div>
                                <div id="4" class="my-col bdr my-col-left">Fourth</div>
                                <div id="5" class="my-col bdr my-col-left">Fifth</div>
                                <div id="6" class="my-col bdr my-col-left">Sixth</div>
                                <div id="7" class="my-col bdr my-col-left">Seventh</div>
                                <div id="8" class="my-col bdr my-col-left">Eighth</div>
                                <div id="9" class="my-col bdr my-col-left">Ninth</div>
                                <div class="blank-div">c</div>
                                <div id="10" class="my-col bdr my-col-right">One</div>
                                <div id="11" class="my-col bdr my-col-right">Two</div>
                                <div id="12" class="my-col bdr my-col-right">Three</div>
                                <div id="13" class="my-col bdr my-col-right">Four</div>
                                <div id="14" class="my-col bdr my-col-right">Five</div>
                                <div id="15" class="my-col bdr my-col-right">Six</div>
                                <div id="16" class="my-col bdr my-col-right">Seven</div>
                                <div id="17" class="my-col bdr my-col-right">Eight</div>
                                <div id="18" class="my-col bdr my-col-right">Nine</div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="my-row">
                                <div class="my-row2-height my-col my-col-left">18</div>
                                <div class="my-row2-height my-col my-col-left">17</div>
                                <div class="my-row2-height my-col my-col-left">16</div>
                                <div class="my-row2-height my-col my-col-left">15</div>
                                <div class="my-row2-height my-col my-col-left">14</div>
                                <div class="my-row2-height my-col my-col-left">13</div>
                                <div class="my-row2-height my-col my-col-left">12</div>
                                <div class="my-row2-height my-col my-col-left">11</div>
                                <div class="my-row2-height my-col my-col-left">10</div>
                                <div class="blank-div">c</div>
                                <div class="my-row2-height my-col my-col-right">9</div>
                                <div class="my-row2-height my-col my-col-right">8</div>
                                <div class="my-row2-height my-col my-col-right">7</div>
                                <div class="my-row2-height my-col my-col-right">6</div>
                                <div class="my-row2-height my-col my-col-right">5</div>
                                <div class="my-row2-height my-col my-col-right">4</div>
                                <div class="my-row2-height my-col my-col-right">3</div>
                                <div class="my-row2-height my-col my-col-right">2</div>
                                <div class="my-row2-height my-col my-col-right">1</div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="my-row">
                                    <div id="1" class="my-col bdr my-col-left">First</div>
                                    <div id="2" class="my-col bdr my-col-left">Second</div>
                                    <div id="3" class="my-col bdr my-col-left">Third</div>
                                    <div id="4" class="my-col bdr my-col-left">Fourth</div>
                                    <div id="5" class="my-col bdr my-col-left">Fifth</div>
                                    <div id="6" class="my-col bdr my-col-left">Sixth</div>
                                    <div id="7" class="my-col bdr my-col-left">Seventh</div>
                                    <div id="8" class="my-col bdr my-col-left">Eighth</div>
                                    <div id="9" class="my-col bdr my-col-left">Ninth</div>
                                    <div class="blank-div">c</div>
                                    <div id="10" class="my-col bdr my-col-right">One</div>
                                    <div id="11" class="my-col bdr my-col-right">Two</div>
                                    <div id="12" class="my-col bdr my-col-right">Three</div>
                                    <div id="13" class="my-col bdr my-col-right">Four</div>
                                    <div id="14" class="my-col bdr my-col-right">Five</div>
                                    <div id="15" class="my-col bdr my-col-right">Six</div>
                                    <div id="16" class="my-col bdr my-col-right">Seven</div>
                                    <div id="17" class="my-col bdr my-col-right">Eight</div>
                                    <div id="18" class="my-col bdr my-col-right">Nine</div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="my-row">
                                    <div class="my-row2-height my-col my-col-left">18</div>
                                    <div class="my-row2-height my-col my-col-left">17</div>
                                    <div class="my-row2-height my-col my-col-left">16</div>
                                    <div class="my-row2-height my-col my-col-left">15</div>
                                    <div class="my-row2-height my-col my-col-left">14</div>
                                    <div class="my-row2-height my-col my-col-left">13</div>
                                    <div class="my-row2-height my-col my-col-left">12</div>
                                    <div class="my-row2-height my-col my-col-left">11</div>
                                    <div class="my-row2-height my-col my-col-left">10</div>
                                    <div class="blank-div">c</div>
                                    <div class="my-row2-height my-col my-col-right">9</div>
                                    <div class="my-row2-height my-col my-col-right">8</div>
                                    <div class="my-row2-height my-col my-col-right">7</div>
                                    <div class="my-row2-height my-col my-col-right">6</div>
                                    <div class="my-row2-height my-col my-col-right">5</div>
                                    <div class="my-row2-height my-col my-col-right">4</div>
                                    <div class="my-row2-height my-col my-col-right">3</div>
                                    <div class="my-row2-height my-col my-col-right">2</div>
                                    <div class="my-row2-height my-col my-col-right">1</div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="my-row">
                                        <div id="1" class="my-col bdr my-col-left">First</div>
                                        <div id="2" class="my-col bdr my-col-left">Second</div>
                                        <div id="3" class="my-col bdr my-col-left">Third</div>
                                        <div id="4" class="my-col bdr my-col-left">Fourth</div>
                                        <div id="5" class="my-col bdr my-col-left">Fifth</div>
                                        <div id="6" class="my-col bdr my-col-left">Sixth</div>
                                        <div id="7" class="my-col bdr my-col-left">Seventh</div>
                                        <div id="8" class="my-col bdr my-col-left">Eighth</div>
                                        <div id="9" class="my-col bdr my-col-left">Ninth</div>
                                        <div class="blank-div">c</div>
                                        <div id="10" class="my-col bdr my-col-right">One</div>
                                        <div id="11" class="my-col bdr my-col-right">Two</div>
                                        <div id="12" class="my-col bdr my-col-right">Three</div>
                                        <div id="13" class="my-col bdr my-col-right">Four</div>
                                        <div id="14" class="my-col bdr my-col-right">Five</div>
                                        <div id="15" class="my-col bdr my-col-right">Six</div>
                                        <div id="16" class="my-col bdr my-col-right">Seven</div>
                                        <div id="17" class="my-col bdr my-col-right">Eight</div>
                                        <div id="18" class="my-col bdr my-col-right">Nine</div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="my-row">
                                        <div class="my-row2-height my-col my-col-left">18</div>
                                        <div class="my-row2-height my-col my-col-left">17</div>
                                        <div class="my-row2-height my-col my-col-left">16</div>
                                        <div class="my-row2-height my-col my-col-left">15</div>
                                        <div class="my-row2-height my-col my-col-left">14</div>
                                        <div class="my-row2-height my-col my-col-left">13</div>
                                        <div class="my-row2-height my-col my-col-left">12</div>
                                        <div class="my-row2-height my-col my-col-left">11</div>
                                        <div class="my-row2-height my-col my-col-left">10</div>
                                        <div class="blank-div">c</div>
                                        <div class="my-row2-height my-col my-col-right">9</div>
                                        <div class="my-row2-height my-col my-col-right">8</div>
                                        <div class="my-row2-height my-col my-col-right">7</div>
                                        <div class="my-row2-height my-col my-col-right">6</div>
                                        <div class="my-row2-height my-col my-col-right">5</div>
                                        <div class="my-row2-height my-col my-col-right">4</div>
                                        <div class="my-row2-height my-col my-col-right">3</div>
                                        <div class="my-row2-height my-col my-col-right">2</div>
                                        <div class="my-row2-height my-col my-col-right">1</div>
                                    </div>--%>
                    <div class="clearfix"></div>
                    <div class="my-row">
                        <div class="chariman">CHAIRMAN</div>
                    </div>
                </td>
            </tr>
        </table>
        <script type="text/javascript">
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
               
                },
                minLength: 1
            });
          });
        </script>
    </form>
</body>
</html>
