<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintSeatingPlan.aspx.cs" Inherits="Notice.PrintSeatingPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="CustomScripts/jquery-ui.min.js"></script>
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />
    <title>Manage Seating Plan</title>
    <script type="text/javascript">

        //function ShowDetails(temp) {
        //    var id = temp.id.substr(1);
        //    document.getElementById('light').style.display = 'block';
        //    document.getElementById('SeatNumber').innerText = id;
        //    document.getElementById('HidSeatNumber').value = id;
        //    document.getElementById('MemberNameTxt').value = document.getElementById('L' + id).innerText;
        //    document.getElementById('HidMemberId').value = document.getElementById('H' + id).value;
        //    document.getElementById('txtCardColor').style.backgroundColor = temp.style.backgroundColor;
        //    document.getElementById('SeatColour').value = "white";

        //}
        function showtooltip(temp) {
            var id = temp.id.substr(1);
           

        }

        function CloseDetails() {
            document.getElementById('light').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }
    </script>
   <style type="text/css">
        body {
            /*background-color:#FFE4C4;*/
        }

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

        .white_content {
            display: none;
            position: absolute;
            top: 5px;
            left: 25%;
            width: 40%;
            height: 60%;
            padding: 5px;
            border: 3px solid #8B4513;
            background-color: #F5F5F5;
            z-index: 1002;
            overflow: auto;
            border-radius: 10px;
            color: #000;
        }

        body {
            padding: 0;
            margin: 0;
        }

        .clearfix {
            clear: both;
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

        .no-bdr {
            border: none;
            text-align: center;
            /*position: fixed;*/
        }

        .bdr {
           /* border: 0px none rgba(100, 100, 100, 0);
            box-shadow: inset -1px -1px 20px 0px rgba(240, 240, 240, 0.3), inset 1px 1px 24px 0px;*/
            border: 1px solid #000;
            border-radius: 10px;
            min-height: 100px;
            font-size: 16px;
            width: 80px;
            padding: 3px;
            font-weight: bold;
            align-items: center;
            align-content: center;
            /*  background-color:#6699FF;*/
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
        .bdr span {
            font-family: 'Jameel Noori Nastaliq', 'Noto Nastaliq Urdu', serif;
            direction: rtl;
            font-size: 19px;
            line-height: 1.35;
        }
    </style>
</head>

<body>
    <form runat="server" id="f1">

     <div id="light" class="white_content">
         <div class="container-fluid">
             <div class="row">
                 <div class="col-sm-12">
                    <h3 style="text-align:center;font-weight:bold">MANAGE SEAT</h3>
                  </div>
             </div>
               <div class="row">
                 <div class="col-sm-8" style="margin-top:10px;"> <asp:Label ID="Label18" style="font-weight:bold;font-size:16px;" runat="server" Text="SEAT NUMBER:"></asp:Label>
                        <asp:Label ID="SeatNumber" style="font-weight:bold;font-size:16px;" runat="server" Text=""></asp:Label>
                          <asp:HiddenField ID="HidSeatNumber" runat="server" />
                 </div>
          </div>         
         <div class="row" style="margin-top:10px;">
                 <div class="col-sm-8"><asp:Label ID="Label19" style="font-weight:bold" runat="server" Text="Member Name:"></asp:Label>      
                    <asp:TextBox ID="MemberNameTxt" style="font-weight:bold;color:#000;font-family:'Jameel Noori Nastaliq','Noto Nastaliq Urdu',serif;font-size:19px;" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:HiddenField ID="HidMemberId" runat="server" />

          </div>
             <div class="clearfix"></div>
          <div class="row" style="margin-top:10px;">
                 <div class="col-sm-8">
                     <asp:Button ID="SaveBtn" runat="server" Text="Assign" class="btn btn-primary" OnClick="SaveBtn_Click" />
                     <asp:Button ID="UnAssignBtn" runat="server" Text="Un-Assign" class="btn btn-primary" style="margin-left:5px;" OnClick="UnAssignBtn_Click" />
                     <asp:Button ID="Button3" runat="server" Text="Cancel" OnClientClick="CloseDetails()" class="btn btn-primary" style="margin-left:5px;"/>
                 </div>
       
             </div>
    </div>
    </div>
<%--         
   <a href="javascript:void(0)" onclick="CloseDetails()">Close</a>--%>
    </div>
       
        <br />
        <div style="margin-left:50px;">
             <asp:Label ID="updatedon" runat="server" style="font-weight:bold" ></asp:Label><br />
        </div>
        
        <table>
                <tr>
                    <td colspan="2">
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S109" class="bdr" runat="server" onmouseover="showtooltip(this)" onclick="ShowDetails(this)">
                                    <asp:Label ID="L109" runat="server"></asp:Label><asp:HiddenField ID="H109" runat="server" />
                                    <asp:HiddenField ID="C109" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>109</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S108" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L108" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H108" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>108</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S107" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L107" runat="server"></asp:Label><asp:HiddenField ID="H107" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>107</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S106" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L106" runat="server"></asp:Label><asp:HiddenField ID="H106" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>106</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S105" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L105" runat="server"></asp:Label><asp:HiddenField ID="H105" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>105</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S104" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L104" runat="server"></asp:Label><asp:HiddenField ID="H104" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>104</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S103" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L103" runat="server"></asp:Label><asp:HiddenField ID="H103" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>103</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S102" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L102" runat="server"></asp:Label><asp:HiddenField ID="H102" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>102</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S101" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L101" runat="server"></asp:Label><asp:HiddenField ID="H101" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>101</p>
                                </div>
                            </div>
                            <div class="blank-div">F</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S100" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L100" runat="server" Text=""></asp:Label><asp:HiddenField ID="H100" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>100</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S99" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L99" runat="server"></asp:Label><asp:HiddenField ID="H99" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>99</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S98" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L98" runat="server"></asp:Label><asp:HiddenField ID="H98" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>98</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S97" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L97" runat="server"></asp:Label><asp:HiddenField ID="H97" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>97</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S96" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L96" runat="server"></asp:Label><asp:HiddenField ID="H96" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>96</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S95" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L95" runat="server"></asp:Label><asp:HiddenField ID="H95" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>95</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S94" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L94" runat="server"></asp:Label><asp:HiddenField ID="H94" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>94</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S93" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L93" runat="server"></asp:Label><asp:HiddenField ID="H93" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>93</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S92" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L92" runat="server"></asp:Label><asp:HiddenField ID="H92" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>92</p>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S91" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L91" runat="server"></asp:Label><asp:HiddenField ID="H91" runat="server" />
                                </div>
                                <div>
                                    <p>91</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S90" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L90" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H90" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>90</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S89" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L89" runat="server"></asp:Label><asp:HiddenField ID="H89" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>89</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S88" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L88" runat="server"></asp:Label><asp:HiddenField ID="H88" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>88</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S87" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L87" runat="server"></asp:Label><asp:HiddenField ID="H87" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>87</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S86" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L86" runat="server"></asp:Label><asp:HiddenField ID="H86" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>86</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S85" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L85" runat="server"></asp:Label><asp:HiddenField ID="H85" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>85</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S84" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L84" runat="server"></asp:Label><asp:HiddenField ID="H84" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>84</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S83" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L83" runat="server"></asp:Label><asp:HiddenField ID="H83" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>83</p>
                                </div>
                            </div>
                            <div class="blank-div">E</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S82" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L82" runat="server"></asp:Label><asp:HiddenField ID="H82" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>82</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S81" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L81" runat="server"></asp:Label><asp:HiddenField ID="H81" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>81</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S80" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L80" runat="server"></asp:Label><asp:HiddenField ID="H80" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>80</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S79" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L79" runat="server"></asp:Label><asp:HiddenField ID="H79" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>79</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S78" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L78" runat="server"></asp:Label><asp:HiddenField ID="H78" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>78</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S77" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L77" runat="server"></asp:Label><asp:HiddenField ID="H77" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>77</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S76" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L76" runat="server"></asp:Label><asp:HiddenField ID="H76" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>76</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S75" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L75" runat="server"></asp:Label><asp:HiddenField ID="H75" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>75</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S74" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L74" runat="server"></asp:Label><asp:HiddenField ID="H74" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>74</p>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S73" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L73" runat="server"></asp:Label><asp:HiddenField ID="H73" runat="server" />
                                </div>
                                <div>
                                    <p>73</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S72" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L72" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H72" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>72</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S71" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L71" runat="server"></asp:Label><asp:HiddenField ID="H71" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>71</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S70" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L70" runat="server"></asp:Label><asp:HiddenField ID="H70" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>70</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S69" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L69" runat="server"></asp:Label><asp:HiddenField ID="H69" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>69</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S68" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L68" runat="server"></asp:Label><asp:HiddenField ID="H68" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>68</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S67" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L67" runat="server"></asp:Label><asp:HiddenField ID="H67" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>67</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S66" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L66" runat="server"></asp:Label><asp:HiddenField ID="H66" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>66</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S65" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L65" runat="server"></asp:Label><asp:HiddenField ID="H65" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>65</p>
                                </div>
                            </div>
                            <div class="blank-div">D</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S64" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L64" runat="server"></asp:Label><asp:HiddenField ID="H64" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>64</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S63" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L63" runat="server"></asp:Label><asp:HiddenField ID="H63" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>63</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S62" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L62" runat="server"></asp:Label><asp:HiddenField ID="H62" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>62</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S61" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L61" runat="server"></asp:Label><asp:HiddenField ID="H61" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>61</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S60" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L60" runat="server"></asp:Label><asp:HiddenField ID="H60" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>60</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S59" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L59" runat="server"></asp:Label><asp:HiddenField ID="H59" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>59</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S58" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L58" runat="server"></asp:Label><asp:HiddenField ID="H58" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>58</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S57" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L57" runat="server"></asp:Label><asp:HiddenField ID="H57" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>57</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S56" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L56" runat="server"></asp:Label><asp:HiddenField ID="H56" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>56</p>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S55" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L55" runat="server"></asp:Label><asp:HiddenField ID="H55" runat="server" />
                                </div>
                                <div>
                                    <p>55</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S54" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L54" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H54" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>54</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S53" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L53" runat="server"></asp:Label><asp:HiddenField ID="H53" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>53</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S52" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L52" runat="server"></asp:Label><asp:HiddenField ID="H52" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>52</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S51" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L51" runat="server"></asp:Label><asp:HiddenField ID="H51" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>51</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S50" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L50" runat="server"></asp:Label><asp:HiddenField ID="H50" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>50</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S49" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L49" runat="server"></asp:Label><asp:HiddenField ID="H49" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>49</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S48" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L48" runat="server"></asp:Label><asp:HiddenField ID="H48" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>48</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S47" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L47" runat="server"></asp:Label><asp:HiddenField ID="H47" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>47</p>
                                </div>
                            </div>
                            <div class="blank-div">C</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S46" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L46" runat="server"></asp:Label><asp:HiddenField ID="H46" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>46</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S45" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L45" runat="server"></asp:Label><asp:HiddenField ID="H45" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>45</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S44" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L44" runat="server"></asp:Label><asp:HiddenField ID="H44" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>44</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S43" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L43" runat="server"></asp:Label><asp:HiddenField ID="H43" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>43</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S42" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L42" runat="server"></asp:Label><asp:HiddenField ID="H42" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>42</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S41" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L41" runat="server"></asp:Label><asp:HiddenField ID="H41" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>41</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S40" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L40" runat="server"></asp:Label><asp:HiddenField ID="H40" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>40</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S39" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L39" runat="server"></asp:Label><asp:HiddenField ID="H39" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>39</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S38" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L38" runat="server"></asp:Label><asp:HiddenField ID="H38" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>38</p>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S37" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L37" runat="server" Text=""></asp:Label><asp:HiddenField ID="H37" runat="server" />
                                </div>
                                <div>
                                    <p>37</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S36" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L36" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H36" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>36</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S35" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L35" runat="server"></asp:Label><asp:HiddenField ID="H35" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>35</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S34" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L34" runat="server"></asp:Label><asp:HiddenField ID="H34" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>34</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S33" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L33" runat="server"></asp:Label><asp:HiddenField ID="H33" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>33</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S32" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L32" runat="server"></asp:Label><asp:HiddenField ID="H32" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>32</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S31" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L31" runat="server"></asp:Label><asp:HiddenField ID="H31" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>31</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S30" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L30" runat="server"></asp:Label><asp:HiddenField ID="H30" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>30</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S29" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L29" runat="server"></asp:Label><asp:HiddenField ID="H29" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>29</p>
                                </div>
                            </div>
                            <div class="blank-div">B</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S28" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L28" runat="server"></asp:Label><asp:HiddenField ID="H28" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>28</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S27" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L27" runat="server"></asp:Label><asp:HiddenField ID="H27" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>27</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S26" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L26" runat="server"></asp:Label><asp:HiddenField ID="H26" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>26</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S25" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L25" runat="server"></asp:Label><asp:HiddenField ID="H25" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>25</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S24" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L24" runat="server"></asp:Label><asp:HiddenField ID="H24" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>24</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S23" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L23" runat="server"></asp:Label><asp:HiddenField ID="H23" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>23</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S22" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L22" runat="server"></asp:Label><asp:HiddenField ID="H22" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>22</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S21" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L21" runat="server"></asp:Label><asp:HiddenField ID="H21" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>21</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S20" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L20" runat="server"></asp:Label><asp:HiddenField ID="H20" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>20</p>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="my-row">
                            <div class="my-col col-left no-bdr">
                                <div id="S19" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L19" runat="server"></asp:Label><asp:HiddenField ID="H19" runat="server" />
                                </div>
                                <div>
                                    <p>19</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S18" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L18" runat="server"></asp:Label>
                                    <asp:HiddenField ID="H18" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>18</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S17" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L17" runat="server"></asp:Label><asp:HiddenField ID="H17" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>17</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S16" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L16" runat="server"></asp:Label><asp:HiddenField ID="H16" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>16</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S15" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L15" runat="server"></asp:Label><asp:HiddenField ID="H15" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>15</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S14" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L14" runat="server"></asp:Label><asp:HiddenField ID="H14" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>14</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S13" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L13" runat="server"></asp:Label><asp:HiddenField ID="H13" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>13</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S12" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L12" runat="server"></asp:Label><asp:HiddenField ID="H12" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>12</p>
                                </div>
                            </div>
                            <div class="my-col col-left no-bdr">
                                <div id="S11" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L11" runat="server"></asp:Label><asp:HiddenField ID="H11" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>11</p>
                                </div>
                            </div>
                            <div class="blank-div">A</div>
                            <div class="my-col col-right no-bdr">
                                <div id="S10" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L10" runat="server"></asp:Label><asp:HiddenField ID="H10" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>10</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S9" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L9" runat="server"></asp:Label><asp:HiddenField ID="H9" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>9</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S8" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L8" runat="server"></asp:Label><asp:HiddenField ID="H8" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>8</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S7" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L7" runat="server"></asp:Label><asp:HiddenField ID="H7" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>7</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S6" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L6" runat="server"></asp:Label><asp:HiddenField ID="H6" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>6</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S5" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L5" runat="server"></asp:Label><asp:HiddenField ID="H5" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>5</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S4" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L4" runat="server"></asp:Label><asp:HiddenField ID="H4" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>4</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S3" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L3" runat="server"></asp:Label><asp:HiddenField ID="H3" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>3</p>
                                </div>
                            </div>
                            <div class="my-col col-right no-bdr">
                                <div id="S2" class="bdr" runat="server" onclick="ShowDetails(this)">
                                    <asp:Label ID="L2" runat="server"></asp:Label><asp:HiddenField ID="H2" runat="server" Value="" />
                                </div>
                                <div>
                                    <p>2</p>
                                </div>
                            </div>
                        </div>

                    </td>
                </tr>

            </table>
           
                <table style="width:20%">
                <tr>
                    <td style="display: flex; align-content: center; align-items: center;">
                        <div class="chariman">C H A I R M A N</div>
                    </td>
                </tr>
                </table>
         <div style="display:flex;flex-direction:column;align-content:end;align-items:end;margin-right:250px;">
             <div style="width:20%">
                  
                <table class="table table-condensed table-responsive">
                    <tr>
                        <th colspan="5" style="text-align:left;font-weight:bold;margin-bottom:5px">LEGENDS</th>
                    </tr>
                            <tr>
                                <td style="background-color:#90EE90!important">Green</td><td>Treasury</td>
                                 <td style="background-color:#FF6347!important">Red</td><td>Oppostion</td>
                            </tr>
                           

                            <tr>
                                <td style="background-color:#6495ED!important">Blue</td><td>Independant</td>
                                <td style="background-color:#FFA500!important">Orange</td><td>Minister</td>
                            </tr>
                          
                            <tr>
                                <td style="background-color:#D3D3D3!important">Gray</td><td>Temporary</td>
                           
                                <td style="background-color:#f7dc6f!important">Yellow</td><td>Request</td>
                            </tr>
                        </table>
            </div>
             </div>
   </form>   
     <script type="text/javascript">
      
       $(window).bind("load", function() { 
           window.print();
       });
            $(function () {
                $("[id$=MemberNameTxt]").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/Service.asmx/GetSeatEmployeeName") %>',
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
                    $("[id$=HidMemberId]").val(i.item.val);
               
                },
                minLength: 1
            });
          });
        </script>                  
</body>

</html>
