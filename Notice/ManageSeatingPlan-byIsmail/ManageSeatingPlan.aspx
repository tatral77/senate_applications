<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSeatingPlan.aspx.cs" Inherits="Notice.ManageSeatingPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>Seating Plan</title>
    <script type="text/javascript">
        function ShowDetails(div) {
            var memberid = document.getElementById(div.id).firstChild.id;
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
            document.getElementById('SeatNumber').innerText = "Seat Number- (" + div.id + ")" + div.innerText + memberid;

$("#id1:first-child").attr("id")

            ;
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
        .white_content {
            display: none;
            position: absolute;
            top: 25%;
            left: 25%;
            width: 50%;
            height: 50%;
            padding: 16px;
            border: 2px solid #000;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }

        body{ padding:0; margin:0; }
        .clearfix { clear: both; }

        div:nth-child(1) { top: 90px; }
        div:nth-child(2) { top: 80px; }
        div:nth-child(3) { top: 70px; }
        div:nth-child(4) { top: 60px; }
        div:nth-child(5) { top: 50px; }
        div:nth-child(6) { top: 40px; }
        div:nth-child(7) { top: 30px; }
        div:nth-child(8) { top: 20px; }
        div:nth-child(9) { top: 10px; }
        div:nth-child(10) { top: 10px; }
        div:nth-child(11) { top: 10px; }
        div:nth-child(12) { top: 20px; }
        div:nth-child(13) { top: 30px; }
        div:nth-child(14) { top: 40px; }
        div:nth-child(15) { top: 50px; }
        div:nth-child(16) { top: 60px; }
        div:nth-child(17) { top: 70px; }
        div:nth-child(18) { top: 80px; }
        div:nth-child(19) { top: 90px; }
        /*div:nth-of-type(odd) { background: #f1f3f4; }
        div:nth-of-type(even) { background: #fff; }*/

        .my-row { margin-right: 20px; margin-left: 20px; width: 100%; }

        .my-col,
        .chariman { position: relative; min-width: 60px; float: left; margin-right: 10px; position: relative; }
            
        .col-left {transform: rotate(-5deg);}
        .col-right {transform: rotate(5deg);}
        .chariman{ margin: 0px auto !important; left:45%; min-height: 50px; border:2px solid #8f8f8f; }
        .blank-div { width:35px; float:left; position: relative; color: transparent; }
        .no-bdr {
            border: none;
            text-align: center;
            /*position: fixed;*/
        }

    .bdr{
        border: 1px solid #000;
        border-radius: 10px;
        min-height: 50px;
        font-size: 10px;
    }
    .no-bdr p{
        margin-top:5px;
        font-weight:bold;
    }
    </style>
</head>

<body>
    <form runat="server" id="f1">
     <div id="light" class="white_content">
         <asp:Label ID="SeatNumber" runat="server" Text=""></asp:Label>  
   <a href="javascript:void(0)" onclick="CloseDetails()">Close</a>
    </div>
    <div id="fade" class="black_overlay"></div>
                    <div class="my-row">
                            <%--<div id="1" class="my-col bdr col-left" onclick="ShowDetails(this)"><span id="H23" class="hidden">First</span>
                                <p>1</p>
                            </div>--%>
                            <div class="my-col col-left no-bdr"><div id="109" class="bdr" onclick="ShowDetails(this)"><span id="H23" class="hidden">First</span></div><div><p>109</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="108" class="bdr">Second</div><div><p>108</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="107" class="bdr">Third</div><div><p>107</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="106" class="bdr">Fourth</div><div><p>106</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="105" class="bdr">Fifth</div><div><p>105</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="104" class="bdr">Sixth</div><div><p>104</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="103" class="bdr">Seventh</div><div><p>103</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="102" class="bdr">Eighth</div><div><p>102</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="101" class="bdr">Ninth</div><div><p>101</p></div></div>
                            <div class="blank-div">c</div>
                            <div class="my-col col-right no-bdr"><div id="100" class="bdr" onclick="ShowDetails(this)"><span id="H23" class="hidden">One</span></div><div><p>100</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="99" class="bdr">Two</div><div><p>99</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="98" class="bdr">Three</div><div><p>98</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="97" class="bdr">Four</div><div><p>97</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="96" class="bdr">Five</div><div><p>96</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="95" class="bdr">Six</div><div><p>95</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="94" class="bdr">Seven</div><div><p>94</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="93" class="bdr">Eight</div><div><p>93</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="92" class="bdr">Nine</div><div><p>92</p></div></div>
                        </div>
                        <div class="clearfix"></div>




<!-- 
    
                    Remaining Rows go here... 
    
    
    -->

                                    <div class="clearfix"></div>
                                    <div class="my-row">
                                        <div class="chariman">chariman</div>
                                    </div>
   </form>                     
</body>
</html>