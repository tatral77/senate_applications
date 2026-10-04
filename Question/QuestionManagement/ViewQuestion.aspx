<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewQuestion.aspx.cs" Inherits="QuestionManagement.ViewQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="container">
        <div class="row">
            <div class="col-md-3 page-header">
                <asp:Label ID="Label1" runat="server" Text="Label" style="font-size:larger;">New Question</asp:Label>  
                
            </div>
            <div class="col-md-9 page-header" style="text-align:right;">
                <asp:Button ID="AddNewBtn" runat="server" Text="Add New" class="btn btn-custom" OnClick="AddNewBtn_Click" />
            </div>
           
        </div>
        
            </div>
<br />        
<br />        <div class="container  regularDiv">
         <div class="row top-buffer">
             <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionDDL">Session No:</label>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true"  runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
              
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
       
            <div class="col-md-3">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" Required="true" class="form-control control-txt js-date" runat="server"></asp:TextBox>
            </div>
              <div class="col-md-3">
             <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
             <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Type="time" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row top-buffer">
           
            <div class="col-md-2">
                <label class="control-lbl-sm" for="QuestionDiaryNoTxt" >Question Diary No:</label>
                <asp:TextBox ID="QuestionDiaryNoTxt" ReadOnly="true" style="background-color:white" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-3">
                   <label class="control-lbl-sm">Question Diary Date:</label>
          
                <asp:TextBox ID="QuestionDiaryDateTxt" Type="Date(dd/MM/YYYY)" Required="true" class="form-control control-txt js-date" runat="server"></asp:TextBox>
            </div>
         
             <div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                        <asp:TextBox ID="DivisionTxt" Required="true" runat="server" CssClass="form-control"/> 
                        <asp:HiddenField ID="HidDivisionId" runat="server" /> 
                        
                </div>

             </div>--%>
              <div class="col-md-4">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Question Status:</label>
                <asp:DropDownList ID="QuestionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
             <div class="row top-buffer">
           
            <%-- <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorStatusDDL">Senator Status:</label>
                 <asp:DropDownList ID="SenatorStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Senator:</label>
                <div>
                        <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control"/> 
                        <asp:HiddenField ID="HidMemberId" runat="server" /> 
                </div>
                </div>
          <%--   <div class="col-md-4">
                   <label class="control-lbl-sm" for="SenatorDDL"></label>
                <div>
                 <asp:TextBox ID="NoOfQuestionsTxt" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>--%>
                   
                <div class="col-md-3">
                 <label class="control-lbl-sm" for="SenatorDDL">Group:</label>
                <asp:DropDownList  ID="GroupDDL"  class="form-control control-txt" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged" >
                <asp:ListItem Value="">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
                    <div class="col-md-4">
                <label class="control-lbl-sm" for="DivisionDDL">Division:</label>
                <asp:DropDownList ID="DivisionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="">Select</asp:ListItem>
                </asp:DropDownList>
            </div>       
               
             
</div>
         <div class="row top-buffer">
          
            
           <%--  <div class="col-md-1">
                  <label class="control-lbl-sm" for="SenatorDDL">&nbsp</label>
                 <asp:Button ID="CheckGroupBtn" runat="server" class="btn btn-custom" Text="Assign" OnClick="CheckGroupBtn_Click" />
                
               
            </div>--%>
             
              
        </div>

       
            </div>

    <br />
        <div class="container  regularDiv">
       <%-- <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm" for="SubjectMatterTxt">Subject Matter:</label>
                 <CKEditor:CKEditorControl ID="SubjectMatterTxt" BasePath="/ckeditor/" runat="server">
                 </CKEditor:CKEditorControl>
            </div>
        </div>--%>
         <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Question Text:</label>
                <textarea id="QTxt" name="QTxt" runat="server"></textarea>
               <%--<CKEditor:CKEditorControl ID="QTxt" BasePath="~/ckeditor/" ClientIDMode="Inherit" runat="server"></CKEditor:CKEditorControl>--%>
            </div>
        </div>
        </div>
    <br />
        <div class="container  regularDiv">
               <div class="col-md-12">
                   <label class="control-lbl-sm">Reply Date:</label>
                <asp:TextBox ID="ReplyDateTxt" ValidationGroup="Group1" class="form-control control-txt js-date" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-12">
                 <label class="control-lbl-sm" for="QuestionReplyTxt">Reply Text:</label>
                <%--<CKEditor:CKEditorControl ID="RepTxt" ClientIDMode="Inherit"  BasePath="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>--%>
                <textarea id="RepTxt" name="RepTxt" runat="server"></textarea>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox>
                
            </div>
        </div>
    <br />
    <div class="container">
         <div class="col-md-12" style="text-align:center">
             <asp:Button ID="UpdateQuestionBtn" runat="server" Text="Update" ValidationGroup="Group1" OnClick="UpdateQuestion_Click" class="btn btn-custom"/>
             <asp:Button ID="Button2" runat="server" Text="Print" class="btn btn-custom"/>
         </div>
    </div>
    <br />

 <script type="text/javascript">
    
         $(function () {
             $("[id$=DivisionTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetDivisionsByName") %>',
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
                    //$("[id$=GroupTxt]").val("");
                    //$("[id$=HidGroupId]").val(i.item.val);


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
                  //  $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupTxt]").val("");
                    //$("[id$=HidGroupId]").val(i.item.val);


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

        jQuery(document).ready(function () {

            jQuery('#QuestionTxt').on('keypress', function (event) {
                if (e.keyCode == 9) { // tab was pressed
                    e.preventDefault();
                    alert("Hello");

                    // get caret position/selection
                    var start = this.selectionStart;
                    end = this.selectionEnd;

                    var $this = $(this);

                    // set textarea value to: text before caret + tab + text after caret
                    $this.val($this.val().substring(0, start)
                                + "\t"
                                + $this.val().substring(end));

                    // put caret at right position again
                    this.selectionStart = this.selectionEnd = start + 1;

                    // prevent the focus lose
                    return false;
                }
            });



        });
       

        CKEDITOR.replace("QTxt");
        CKEDITOR.replace("RepTxt");



         
    </script>
     </asp:Content>
