<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatingPlanLeftEn.aspx.cs" Inherits="Notice.SeatingPlanLeftEn" %>

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
    <link rel="stylesheet" href="styles/fontStyle.css"/>
    <title>Left Seating Plan</title>
    <script type="text/javascript">

        function ShowDetails(temp) {
            var id=temp.id.substr(1);
             document.getElementById('light').style.display = 'block';
             document.getElementById('SeatNumber').innerText = id;
             document.getElementById('HidSeatNumber').value = id;
             document.getElementById('MemberNameTxt').value = document.getElementById('L'+ id).innerText;
             document.getElementById('HiMemberId').value = document.getElementById('H' + id).value;

        }
        function showtooltip(temp) {
            var id = temp.id.substr(1);
           

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
            top: 5px;
            left: 25%;
            width: 40%;
            height: 50%;
            padding: 5px;
            border: 2px solid #8B4513;
            z-index: 1002;
            overflow: auto;
             border-radius: 10px;
             color:#fff;
             

        }

        body{ padding:0; margin:0;margin-left:1.4in;}
        .clearfix { clear: both; }
         div:nth-child(1) { top: 120px; }
        div:nth-child(2) { top: 90px; }
        div:nth-child(3) { top: 80px; }
        div:nth-child(4) { top: 70px; }
        div:nth-child(5) { top: 60px; }
        div:nth-child(6) { top: 50px; }
        div:nth-child(7) { top: 40px; }
        div:nth-child(8) { top: 30px; }
        div:nth-child(9) { top: 20px; }
        div:nth-child(10) { top: 10px; }
        /*div:nth-child(11) { top: 10px; }
        div:nth-child(12) { top: 10px; }
        div:nth-child(13) { top: 20px; }
        div:nth-child(14) { top: 30px; }
        div:nth-child(15) { top: 40px; }
        div:nth-child(16) { top: 50px; }
        div:nth-child(17) { top: 60px; }
        div:nth-child(18) { top: 70px; }
        div:nth-child(19) { top: 80px; }
        div:nth-child(20) { top: 90px; }*/
        /*div:nth-of-type(odd) { background: #f1f3f4; }
        div:nth-of-type(even) { background: #fff; }*/

        .my-row { margin-right: 20px; margin-left: 20px; text-align:right;width: 120%;  }

        .my-col{ min-width: 60px; float: left; margin-right: 10px; position: relative; }
        .chariman { min-width: 60px;font-size:18px;font-weight:bold; float: right; position:center;margin-right:250px;margin-top:50px; }    
            
        .col-left {transform: rotate(-5deg);}
        .col-right {transform: rotate(5deg);}
        /*.chariman{ margin: 0px auto !important;
                    margin-left:2%; min-height: 100px;min-width:150px; 
                    border:3px solid;padding-top:30px;text-align:center;
                    font-size:16px;
                    font-weight:bold;
                    border-radius: 10px;

        }*/
        .blank-div { width:40px;margin-right:5px; float:left; position: relative; font-weight:bold;text-align:center; }
        .no-bdr {
            border: none;
            text-align: center;
            /*position: fixed;*/
        }

    .bdr{
        
         border: 1px solid #000;
        border-radius: 10px;
        min-height: 80px;
        font-size: 12px;
        width:100px;
        padding:3px;
        font-weight:bold;
         align-items: center;
            align-content: center;
       

        
    }
    .no-bdr p{
        margin-top:5px;
        font-weight:bold;
    }
    span
    {
        vertical-align:central;
    }
    .row{
        margin-right: 1px!important; margin-left: 1px!important;
    }
    </style>
</head>

<body>
    <form runat="server" id="f1">
    
        <table>
         
            <tr>
                <td >
                     <asp:Label style="font-weight:bold;" ID="CurrentDate" runat="server" Text="Label"></asp:Label>
                    <div class="my-row">
                             <div class="blank-div">F</div>
                            <div class="my-col col-left no-bdr urdu"><div id="S109" class="bdr" runat="server" onmouseover="showtooltip(this)" onclick="ShowDetails(this)"><asp:Label ID="L109" runat="server"></asp:Label><asp:HiddenField ID="H109" runat="server"/></div><div><p>109</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S108" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L108" runat="server" ></asp:Label> <asp:HiddenField ID="H108" runat="server" Value="" /></div><div><p>108</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S107" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L107" runat="server" ></asp:Label><asp:HiddenField ID="H107" runat="server" Value="" /></div><div><p>107</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S106" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L106" runat="server" ></asp:Label><asp:HiddenField ID="H106" runat="server" Value="" /></div><div><p>106</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S105" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L105" runat="server" ></asp:Label><asp:HiddenField ID="H105" runat="server" Value="" /></div><div><p>105</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S104" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L104" runat="server" ></asp:Label><asp:HiddenField ID="H104" runat="server" Value="" /></div><div><p>104</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S103" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L103" runat="server" ></asp:Label><asp:HiddenField ID="H103" runat="server" Value="" /></div><div><p>103</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S102" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L102" runat="server" ></asp:Label><asp:HiddenField ID="H102" runat="server" Value="" /></div><div><p>102</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S101" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L101" runat="server" ></asp:Label><asp:HiddenField ID="H101" runat="server" Value="" /></div><div><p>101</p></div></div>
                           
                         
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          <div class="blank-div">E</div>
                            <div class="my-col col-left no-bdr"><div id="S91" class="bdr" runat="server" onclick="ShowDetails(this)"><asp:Label ID="L91" runat="server"></asp:Label><asp:HiddenField ID="H91" runat="server"/></div><div><p>91</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S90" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L90" runat="server" ></asp:Label> <asp:HiddenField ID="H90" runat="server" Value="" /></div><div><p>90</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S89" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L89" runat="server" ></asp:Label><asp:HiddenField ID="H89" runat="server" Value="" /></div><div><p>89</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S88" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L88" runat="server" ></asp:Label><asp:HiddenField ID="H88" runat="server" Value="" /></div><div><p>88</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S87" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L87" runat="server" ></asp:Label><asp:HiddenField ID="H87" runat="server" Value="" /></div><div><p>87</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S86" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L86" runat="server" ></asp:Label><asp:HiddenField ID="H86" runat="server" Value="" /></div><div><p>86</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S85" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L85" runat="server" ></asp:Label><asp:HiddenField ID="H85" runat="server" Value="" /></div><div><p>85</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S84" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L84" runat="server" ></asp:Label><asp:HiddenField ID="H84" runat="server" Value="" /></div><div><p>84</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S83" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L83" runat="server" ></asp:Label><asp:HiddenField ID="H83" runat="server" Value="" /></div><div><p>83</p></div></div>
                            
                         
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          <div class="blank-div">D</div>
                            <div class="my-col col-left no-bdr"><div id="S73" class="bdr" runat="server" onclick="ShowDetails(this)"><asp:Label ID="L73" runat="server"></asp:Label><asp:HiddenField ID="H73" runat="server"/></div><div><p>73</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S72" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L72" runat="server" ></asp:Label> <asp:HiddenField ID="H72" runat="server" Value="" /></div><div><p>72</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S71" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L71" runat="server" ></asp:Label><asp:HiddenField ID="H71" runat="server" Value="" /></div><div><p>71</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S70" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L70" runat="server" ></asp:Label><asp:HiddenField ID="H70" runat="server" Value="" /></div><div><p>70</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S69" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L69" runat="server" ></asp:Label><asp:HiddenField ID="H69" runat="server" Value="" /></div><div><p>69</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S68" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L68" runat="server" ></asp:Label><asp:HiddenField ID="H68" runat="server" Value="" /></div><div><p>68</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S67" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L67" runat="server" ></asp:Label><asp:HiddenField ID="H67" runat="server" Value="" /></div><div><p>67</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S66" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L66" runat="server" ></asp:Label><asp:HiddenField ID="H66" runat="server" Value="" /></div><div><p>66</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S65" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L65" runat="server" ></asp:Label><asp:HiddenField ID="H65" runat="server" Value="" /></div><div><p>65</p></div></div>
                            
                           
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                            <div class="blank-div">C</div>
                            <div class="my-col col-left no-bdr"><div id="S55" class="bdr" runat="server" onclick="ShowDetails(this)"><asp:Label ID="L55" runat="server"></asp:Label><asp:HiddenField ID="H55" runat="server"/></div><div><p>55</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S54" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L54" runat="server" ></asp:Label> <asp:HiddenField ID="H54" runat="server" Value="" /></div><div><p>54</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S53" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L53" runat="server" ></asp:Label><asp:HiddenField ID="H53" runat="server" Value="" /></div><div><p>53</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S52" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L52" runat="server" ></asp:Label><asp:HiddenField ID="H52" runat="server" Value="" /></div><div><p>52</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S51" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L51" runat="server" ></asp:Label><asp:HiddenField ID="H51" runat="server" Value="" /></div><div><p>51</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S50" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L50" runat="server" ></asp:Label><asp:HiddenField ID="H50" runat="server" Value="" /></div><div><p>50</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S49" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L49" runat="server" ></asp:Label><asp:HiddenField ID="H49" runat="server" Value="" /></div><div><p>49</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S48" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L48" runat="server" ></asp:Label><asp:HiddenField ID="H48" runat="server" Value="" /></div><div><p>48</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S47" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L47" runat="server" ></asp:Label><asp:HiddenField ID="H47" runat="server" Value="" /></div><div><p>47</p></div></div>
                          
                           
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          <div class="blank-div">B</div>
                            <div class="my-col col-left no-bdr"><div id="S37" class="bdr" runat="server" onclick="ShowDetails(this)"><asp:Label ID="L37" runat="server" Text=""></asp:Label><asp:HiddenField ID="H37" runat="server"/></div><div><p>37</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S36" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L36" runat="server" ></asp:Label> <asp:HiddenField ID="H36" runat="server" Value="" /></div><div><p>36</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S35" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L35" runat="server" ></asp:Label><asp:HiddenField ID="H35" runat="server" Value="" /></div><div><p>35</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S34" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L34" runat="server" ></asp:Label><asp:HiddenField ID="H34" runat="server" Value="" /></div><div><p>34</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S33" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L33" runat="server" ></asp:Label><asp:HiddenField ID="H33" runat="server" Value="" /></div><div><p>33</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S32" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L32" runat="server" ></asp:Label><asp:HiddenField ID="H32" runat="server" Value="" /></div><div><p>32</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S31" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L31" runat="server" ></asp:Label><asp:HiddenField ID="H31" runat="server" Value="" /></div><div><p>31</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S30" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L30" runat="server" ></asp:Label><asp:HiddenField ID="H30" runat="server" Value="" /></div><div><p>30</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S29" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L29" runat="server" ></asp:Label><asp:HiddenField ID="H29" runat="server" Value="" /></div><div><p>29</p></div></div>
                            
                           
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          <div class="blank-div">A</div>
                            <div class="my-col col-left no-bdr"><div id="S19" class="bdr" runat="server" onclick="ShowDetails(this)"><asp:Label ID="L19" runat="server"></asp:Label><asp:HiddenField ID="H19" runat="server"/></div><div><p>19</p></div>                          </div>
                            <div class="my-col col-left no-bdr"><div id="S18" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L18" runat="server" ></asp:Label> <asp:HiddenField ID="H18" runat="server" Value="" /></div><div><p>18</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S17" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L17" runat="server" ></asp:Label><asp:HiddenField ID="H17" runat="server" Value="" /></div><div><p>17</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S16" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L16" runat="server" ></asp:Label><asp:HiddenField ID="H16" runat="server" Value="" /></div><div><p>16</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S15" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L15" runat="server" ></asp:Label><asp:HiddenField ID="H15" runat="server" Value="" /></div><div><p>15</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S14" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L14" runat="server" ></asp:Label><asp:HiddenField ID="H14" runat="server" Value="" /></div><div><p>14</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S13" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L13" runat="server" ></asp:Label><asp:HiddenField ID="H13" runat="server" Value="" /></div><div><p>13</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S12" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L12" runat="server" ></asp:Label><asp:HiddenField ID="H12" runat="server" Value="" /></div><div><p>12</p></div></div>
                            <div class="my-col col-left no-bdr"><div id="S11" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L11" runat="server" ></asp:Label><asp:HiddenField ID="H11" runat="server" Value="" /></div><div><p>11</p></div></div>
                            
                          
                        </div>
                         <div class="clearfix"></div>
                                    <div class="my-row">
                                        <div class="chariman">C H A I R M A N</div>
                                    </div>

    </td>
            </tr>

        </table>
   </form>   
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

