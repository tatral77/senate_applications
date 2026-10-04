<%@ Page Title="" Language="C#"  MasterPageFile="~/Main.Master" validateRequest="false" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="QuestionManagement.NewQuestion1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">     
   <script src="summernote/summernote.js"></script>
       <link href="Summernote/summernote.css" rel="stylesheet" />      
    <script src="Scripts/jquery.mask.js"></script>
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
           
    </style>
           
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
        <ContentTemplate>

        
        <div class="container">
        <div class="row">
            <div class="col-md-10 page-header"><h4>NEW QUESTION</h4></div>
            <div class="col-md-2 page-header">
                <asp:Button ID="AddNewBtn" runat="server" Text="Add New" class="btn btn-custom" OnClick="AddNewBtn_Click"/>
            </div>
           
        </div>
        
            </div>
<br />        <div class="container  regularDiv" id="#panel">
         <div class="row top-buffer">
               <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                             EnableClientScript="true"
                             HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
               <div class="col-md-3">
               <label class="control-lbl-sm" for="SessionTxt">Question ID:</label>               
                 <asp:TextBox  ID="QuestionIdTxt" class="form-control small-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-3">
                           <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                        <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control"  runat="server"  Placeolder="Session">
                            <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                        </asp:DropDownList>

                    </div>
            <div class="col-md-3 bootst">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None"  ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>

                          </div>
       
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt"   ValidationGroup="Group1" Required="true" class="form-control small-control date js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" style="color:red" Text=""></asp:Label>
               <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>

                      </div>
              <div class="col-md-3 bootstrap-timepicker">
             <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
             <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>

                           </div>
        </div>

        <div class="row top-buffer">
           
           <%-- <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionIDTxt" >Question ID:</label>
                <asp:TextBox ID="QuestionIDTxt" ReadOnly="true" style="background-color:white" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>--%>
             <div class="col-md-2">
                   <label class="control-lbl-sm">Question Diary No:</label>
          
                <asp:TextBox ID="QuestionDiaryNoTxt" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-2">



               
                   <label class="control-lbl-sm" for="CategoryDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1" >
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>
               
                       </div>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Senator:</label>
                
                        <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control"/> 
                        <asp:HiddenField ID="HidMemberId" runat="server" /> 
                    <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter Senator Name" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>
  
                            </div>
         

            
           <%--   <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Question Status:</label>--%>
                <%--<asp:DropDownList ID="QuestionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>--%>
                 <%-- <asp:TextBox ID="QuestionStatus" Enabled="false" runat="server" CssClass="form-control" Text="Under Process"/> 
            </div>--%>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                        <asp:TextBox ID="DivisionTxt" Required="true" runat="server" CssClass="form-control small-control"/> 
                        <asp:HiddenField ID="HidDivisionId" runat="server" /> 
                        
                </div>

             </div>
                        
            </div>
             <div class="row top-buffer">
           
            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorStatusDDL">Senator Status:</label>
                 <asp:DropDownList ID="SenatorStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
            
                </div>
          <%--   <div class="col-md-4">
                   <label class="control-lbl-sm" for="SenatorDDL"></label>
                <div>
                 <asp:TextBox ID="NoOfQuestionsTxt" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>--%>
                   
               <%-- <div class="col-md-3">
                 <label class="control-lbl-sm" for="SenatorDDL">Group:</label>--%>
             <%--   <asp:DropDownList  ID="GroupDDL"  class="form-control control-txt" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged" >
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="rfvGroupDDL" runat="server" ErrorMessage="Select Group" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="GroupDDL"></asp:RequiredFieldValidator>--%>
                     <%-- <asp:TextBox ID="GroupTxt" Required="true" runat="server" CssClass="form-control"/> 
                        <asp:HiddenField ID="HidGroupId" runat="server" /> 
                             </div>--%>
               <%--     <div class="col-md-4">
                <label class="control-lbl-sm" for="DivisionDDL">Division:</label>
                <asp:DropDownList ID="DivisionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="DivisionDDL_SelectedIndexChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="rfvDivisionDDL" runat="server" ErrorMessage="Select Division" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="DivisionDDL"></asp:RequiredFieldValidator>

                                 </div>  --%>
    
                 <div class="row">
                     <div class="col-md-12" style="text-align:center"> 
                         <asp:Label ID="Error" runat="server" style="color:red"></asp:Label> </div>    </div> 
              
             
</div>
            </ContentTemplate>
    </asp:UpdatePanel>
         <div class="row top-buffer">
          
            
           <%--  <div class="col-md-1">
                  <label class="control-lbl-sm" for="SenatorDDL">&nbsp</label>
                 <asp:Button ID="CheckGroupBtn" runat="server" class="btn btn-custom" Text="Assign" OnClick="CheckGroupBtn_Click" />
                
               
            </div>--%>
             
              
        </div>

       
           

    <br />
    <div class="container">
       
    </div>
        <div class="container  regularDiv">
              <div class="row top-buffer">
              <div class="col-md-7"><label class="control-lbl-sm">English Text:</label></div>
                <div class="col-md-3">
                     <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" Cssclass="btn btn-custom" style="width:250px;" data-scan="true" />

                </div>
                 <div class="col-md-2">
                     <asp:Button Text="Read Text" Visible="false" runat="server" OnClick="Upload" CssClass="form-control btn btn-success" />
                     </div>
            </div>
            <div class="row top-buffer">
            <div class="col-md-12">
                
                 <%--<CKEditor:CKEditorControl ID="QuestionTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                  <textarea id="QuestionTxt" name="QuestionTxt" style="height:300px" class="form-control" ValidationGroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_QuestionTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                    .attr('cellpadding', 12)
                                    .attr('cellspacing', 0)
                                    .attr('border', 1)
                                    .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                    .css('borderColor', '#000')
                                    .css('padding', '5px');
                                },
                               height:300
                            });
                    });
                    </script>
                      <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="SaveGroup" Display="None"  ControlToValidate="QuestionTxt"></asp:RequiredFieldValidator>

                          <%--<textarea id="QuestionTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
            </div>
              <div class="row top-buffer">
              <div class="col-md-7"><label class="control-lbl-sm">Urdu Text:</label></div>
                </div>
               <div class="row top-buffer">
            <div class="col-md-12">
                
                 <%--<CKEditor:CKEditorControl ID="QuestionTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                  <textarea id="UrduTxt" name="UrduTxt" style="height:300px" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder3_UrduTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 300
                            });
                    });
                </script>

                          <%--<textarea id="QuestionTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
            </div>
        </div>
       
  
    <br />
    <div class="container">
         <div class="col-md-12" style="text-align:center">
             <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click"  class="btn btn-custom"/>
             <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" Cssclass="btn btn-custom" OnClick="PrintBtn_Click"/>
         </div>
    </div>
              
    <br />

 <script type="text/javascript">

                $('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
                template: false,
                showInputs: false,
                defaultTime: false,
                minuteStep: 5
            });



     $(document).ready(function () {
         $('.date').mask('00/00/0000');
     });
   

         $(function () {
             $("[id$=DivisionTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>',
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
                    $("[id$=HidDivisionId]").val(i.item.val);
                    $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');


                },
                minLength: 1
            });
         });

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
                    $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');





                },
                minLength: 1
            });
          });
    
     jQuery(document).ready(function () {

         jQuery('#AddNewBtn').on('click', function (event) {
             event.preventDefault();
             window.location.href = 'NewQuestion.aspx';



         });


     });
  

     //$("#QuestionTxt").keydown(function (e) {
     //    if (e.keyCode === 9) { // tab was pressed
     //        // get caret position/selection
     //        var start = this.selectionStart;
     //        end = this.selectionEnd;

     //        var $this = $(this);

     //        // set textarea value to: text before caret + tab + text after caret
     //        $this.val($this.val().substring(0, start)
     //                    + "\t"
     //                    + $this.val().substring(end));

     //        // put caret at right position again
     //        this.selectionStart = this.selectionEnd = start + 1;

     //        // prevent the focus lose
     //        return false;
     //    }
     //});
    

     //document.onkeypress = function (event) {
     //    if (event.ctrlKey && event.keyCode == 83) {
     //        event.preventDefault();
     //        document.getElementById('Button1').click();
             
     //    }

     //};
     //document.onkeydown = function (event) {
     //    if (event.ctrlKey && event.keyCode == 82 || event.keyCode == 114) {
     //        event.preventDefault();
     //        document.getElementById('QuestionTxt').style.alignContent = "left";;
     //    }

     //};

     $(document).bind('keydown', function (e) {
         if (e.ctrlKey && (e.which == 83)) {
             e.preventDefault();
             document.getElementById('ContentPlaceHolder3_Button1').click();
             return false;
         }
     });
     $(document).bind('keydown', function (e) {
         if (e.ctrlKey && (e.which == 80)) {
             e.preventDefault();
             document.getElementById('ContentPlaceHolder3_PrintBtn').click();
             return false;
         }


     });
     $('#ContentPlaceHolder3_QuestionTxt').bind('keydown', function (e) {
         if (e.ctrlKey && (e.which == 83)) {
             e.preventDefault();
             document.getElementById('ContentPlaceHolder3_Button1').click();
             return false;
         }


     });
     $('#ContentPlaceHolder3_QuestionTxt').bind('keydown', function (e) {
         if (e.ctrlKey && (e.which == 83)) {
             e.preventDefault();
             document.getElementById('ContentPlaceHolder3_PrintBtn').click();
             return false;
         }


     });

    

    </script>
          
   
   
</asp:Content>
