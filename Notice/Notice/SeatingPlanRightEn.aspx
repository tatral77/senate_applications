<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatingPlanRightEn.aspx.cs" Inherits="Notice.SeatingPlanRightEn" %>

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
    <title>Right Seating Plan</title>
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
            border: 3px solid #8B4513;
            background-color: #6699CC;
            z-index: 1002;
            overflow: auto;
             border-radius: 10px;
             color:#fff;
             

        }

        body{ padding:0; margin:0; }
        .clearfix { clear: both; }
        div:nth-child(1) { top: 10px; }     
        div:nth-child(2) { top: 20px; }
        div:nth-child(3) { top: 30px; }
        div:nth-child(4) { top: 40px; }
        div:nth-child(5) { top: 50px; }
        div:nth-child(6) { top: 60px; }
        div:nth-child(7) { top: 70px; }
        div:nth-child(8) { top: 80px; }
        div:nth-child(9) { top: 90px; }
        div:nth-child(10) { top: 120px; }
        /*div:nth-of-type(odd) { background: #f1f3f4; }
        div:nth-of-type(even) { background: #fff; }*/

        .my-row { margin-right: 20px; margin-left: 20px; width: 120%; }

        .my-col{ min-width: 60px; float: left; margin-right: 10px; position: relative; }
        .chariman { font-size:18px;font-weight:bold;min-width: 60px; float: left; position: relative;margin-top:50px;}            
        .col-left {transform: rotate(-5deg);}
        .col-right {transform: rotate(5deg);}
        /*.chariman{ margin: 0px auto !important;
                    left:38%; min-height: 100px;min-width:150px; 
                    border:3px solid;padding-top:30px;text-align:center;
                    font-size:16px;
                    font-weight:bold;
                    border-radius: 10px;

        }*/
        .blank-div { width:35px; float:left; position: relative; font-weight:bold;text-align:center; }
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
                <td>
                    <asp:Label style="font-weight:bold;" ID="CurrentDate" runat="server" Text="Label"></asp:Label>
                    <div class="my-row">                        
                            
                            <div class="my-col col-right no-bdr"><div id="S100" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L100" runat="server" Text=""></asp:Label><asp:HiddenField ID="H100" runat="server" Value="" /></div><div><p>100</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S99" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L99" runat="server" ></asp:Label><asp:HiddenField ID="H99" runat="server" Value="" /></div><div><p>99</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S98" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L98" runat="server" ></asp:Label><asp:HiddenField ID="H98" runat="server" Value="" /></div><div><p>98</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S97" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L97" runat="server" ></asp:Label><asp:HiddenField ID="H97" runat="server" Value="" /></div><div><p>97</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S96" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L96" runat="server" ></asp:Label><asp:HiddenField ID="H96" runat="server" Value="" /></div><div><p>96</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S95" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L95" runat="server" ></asp:Label><asp:HiddenField ID="H95" runat="server" Value="" /></div><div><p>95</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S94" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L94" runat="server" ></asp:Label><asp:HiddenField ID="H94" runat="server" Value="" /></div><div><p>94</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S93" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L93" runat="server" ></asp:Label><asp:HiddenField ID="H93" runat="server" Value="" /></div><div><p>93</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S92" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L92" runat="server" ></asp:Label><asp:HiddenField ID="H92" runat="server" Value="" /></div><div><p>92</p></div></div>
                            <div class="blank-div">F</div>
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          
                          
                            <div class="my-col col-right no-bdr"><div id="S82" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L82" runat="server" ></asp:Label><asp:HiddenField ID="H82" runat="server" Value="" /></div><div><p>82</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S81" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L81" runat="server" ></asp:Label><asp:HiddenField ID="H81" runat="server" Value="" /></div><div><p>81</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S80" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L80" runat="server" ></asp:Label><asp:HiddenField ID="H80" runat="server" Value="" /></div><div><p>80</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S79" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L79" runat="server" ></asp:Label><asp:HiddenField ID="H79" runat="server" Value="" /></div><div><p>79</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S78" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L78" runat="server" ></asp:Label><asp:HiddenField ID="H78" runat="server" Value="" /></div><div><p>78</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S77" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L77" runat="server" ></asp:Label><asp:HiddenField ID="H77" runat="server" Value="" /></div><div><p>77</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S76" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L76" runat="server" ></asp:Label><asp:HiddenField ID="H76" runat="server" Value="" /></div><div><p>76</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S75" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L75" runat="server" ></asp:Label><asp:HiddenField ID="H75" runat="server" Value="" /></div><div><p>75</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S74" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L74" runat="server" ></asp:Label><asp:HiddenField ID="H74" runat="server" Value="" /></div><div><p>74</p></div></div>
                            <div class="blank-div">E</div>
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                         
                            
                            <div class="my-col col-right no-bdr"><div id="S64" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L64" runat="server" ></asp:Label><asp:HiddenField ID="H64" runat="server" Value="" /></div><div><p>64</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S63" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L63" runat="server" ></asp:Label><asp:HiddenField ID="H63" runat="server" Value="" /></div><div><p>63</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S62" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L62" runat="server" ></asp:Label><asp:HiddenField ID="H62" runat="server" Value="" /></div><div><p>62</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S61" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L61" runat="server" ></asp:Label><asp:HiddenField ID="H61" runat="server" Value="" /></div><div><p>61</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S60" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L60" runat="server" ></asp:Label><asp:HiddenField ID="H60" runat="server" Value="" /></div><div><p>60</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S59" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L59" runat="server" ></asp:Label><asp:HiddenField ID="H59" runat="server" Value="" /></div><div><p>59</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S58" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L58" runat="server" ></asp:Label><asp:HiddenField ID="H58" runat="server" Value="" /></div><div><p>58</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S57" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L57" runat="server" ></asp:Label><asp:HiddenField ID="H57" runat="server" Value="" /></div><div><p>57</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S56" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L56" runat="server" ></asp:Label><asp:HiddenField ID="H56" runat="server" Value="" /></div><div><p>56</p></div></div>
                          <div class="blank-div">D</div>
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                           
                           
                            <div class="my-col col-right no-bdr"><div id="S46" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L46" runat="server" ></asp:Label><asp:HiddenField ID="H46" runat="server" Value="" /></div><div><p>46</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S45" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L45" runat="server" ></asp:Label><asp:HiddenField ID="H45" runat="server" Value="" /></div><div><p>45</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S44" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L44" runat="server" ></asp:Label><asp:HiddenField ID="H44" runat="server" Value="" /></div><div><p>44</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S43" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L43" runat="server" ></asp:Label><asp:HiddenField ID="H43" runat="server" Value="" /></div><div><p>43</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S42" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L42" runat="server" ></asp:Label><asp:HiddenField ID="H42" runat="server" Value="" /></div><div><p>42</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S41" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L41" runat="server" ></asp:Label><asp:HiddenField ID="H41" runat="server" Value="" /></div><div><p>41</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S40" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L40" runat="server" ></asp:Label><asp:HiddenField ID="H40" runat="server" Value="" /></div><div><p>40</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S39" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L39" runat="server" ></asp:Label><asp:HiddenField ID="H39" runat="server" Value="" /></div><div><p>39</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S38" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L38" runat="server" ></asp:Label><asp:HiddenField ID="H38" runat="server" Value="" /></div><div><p>38</p></div></div>
                           <div class="blank-div">C</div>
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                           
                            
                            <div class="my-col col-right no-bdr"><div id="S28" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L28" runat="server" ></asp:Label><asp:HiddenField ID="H28" runat="server" Value="" /></div><div><p>28</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S27" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L27" runat="server" ></asp:Label><asp:HiddenField ID="H27" runat="server" Value="" /></div><div><p>27</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S26" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L26" runat="server" ></asp:Label><asp:HiddenField ID="H26" runat="server" Value="" /></div><div><p>26</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S25" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L25" runat="server" ></asp:Label><asp:HiddenField ID="H25" runat="server" Value="" /></div><div><p>25</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S24" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L24" runat="server" ></asp:Label><asp:HiddenField ID="H24" runat="server" Value="" /></div><div><p>24</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S23" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L23" runat="server" ></asp:Label><asp:HiddenField ID="H23" runat="server" Value="" /></div><div><p>23</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S22" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L22" runat="server" ></asp:Label><asp:HiddenField ID="H22" runat="server" Value="" /></div><div><p>22</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S21" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L21" runat="server" ></asp:Label><asp:HiddenField ID="H21" runat="server" Value="" /></div><div><p>21</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S20" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L20" runat="server" ></asp:Label><asp:HiddenField ID="H20" runat="server" Value="" /></div><div><p>20</p></div></div>
                          <div class="blank-div">B</div>
                        </div>
                        <div class="clearfix"></div>
                      <div class="my-row">
                          
                            
                            <div class="my-col col-right no-bdr"><div id="S10" class="bdr" runat="server"  onclick="ShowDetails(this)"><asp:Label ID="L10" runat="server" ></asp:Label><asp:HiddenField ID="H10" runat="server" Value="" /></div><div><p>10</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S9" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L9" runat="server" ></asp:Label><asp:HiddenField ID="H9" runat="server" Value="" /></div><div><p>9</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S8" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L8" runat="server" ></asp:Label><asp:HiddenField ID="H8" runat="server" Value="" /></div><div><p>8</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S7" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L7" runat="server" ></asp:Label><asp:HiddenField ID="H7" runat="server" Value="" /></div><div><p>7</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S6" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L6" runat="server" ></asp:Label><asp:HiddenField ID="H6" runat="server" Value="" /></div><div><p>6</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S5" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L5" runat="server" ></asp:Label><asp:HiddenField ID="H5" runat="server" Value="" /></div><div><p>5</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S4" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L4" runat="server" ></asp:Label><asp:HiddenField ID="H4" runat="server" Value="" /></div><div><p>4</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S3" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L3" runat="server" ></asp:Label><asp:HiddenField ID="H3" runat="server" Value="" /></div><div><p>3</p></div></div>
                            <div class="my-col col-right no-bdr"><div id="S2" class="bdr" runat="server" onclick="ShowDetails(this)"> <asp:Label ID="L2" runat="server" ></asp:Label><asp:HiddenField ID="H2" runat="server" Value="" /></div><div><p>2</p></div></div>
                          <div class="blank-div">A</div>
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

