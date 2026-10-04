<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="QuestionManagement.NewQuestion1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CKEditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4 class="page-header">New Question</h4>
            </div>
        </div>
            </div>
        <div class="container  regularDiv">
         <div class="row top-buffer">
           
            <div class="col-md-4">
                <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No:</label>
                <asp:TextBox ID="NoticeDiaryNoTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
       
            <div class="col-md-4">
                <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date:</label>
                <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
              <div class="col-md-4">
             <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time:</label>
             <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SessionDDL">Session No:</label>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" AutoPostBack="true" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
              
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="QuestionDiaryNoTxt" >Question Diary No:</label>
                <asp:TextBox ID="QuestionDiaryNoTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-4">
                   <label class="control-lbl-sm">Question Diary Date:</label>
          
                <asp:TextBox ID="QuestionDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            </div>

       


         <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="QuestionStatusDDL">Question Status:</label>
                <asp:DropDownList ID="QuestionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorStatusDDL">Senator Status:</label>
                 <asp:DropDownList ID="SenatorStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Senator:</label>
                <asp:DropDownList ID="SenatorDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="CategoryDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-4">
                <label class="control-lbl-sm" for="GroupDDL">Group No:</label>
                <asp:DropDownList ID="GroupDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged" >
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="DivisionDDL">Division:</label>
                <asp:DropDownList ID="DivisionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
</div>
            </div>
    <br />
        <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm" for="SubjectMatterTxt">Subject Matter:</label>
                 <CKEditor:CKEditorControl ID="SubjectMatterTxt" BasePath="/ckeditor/" runat="server">
                 </CKEditor:CKEditorControl>
            </div>
        </div>
         <div class="row top-buffer">
            <div class="col-md-12">
                <label class="control-lbl-sm">Question Text:</label>
                <CKEditor:CKEditorControl ID="QuestionTxt" BasePath="/ckeditor/" runat="server">
                </CKEditor:CKEditorControl>
            </div>
        </div>
        </div>
    <br />
        <div class="container  regularDiv">
               <div class="col-md-12">
                   <label class="control-lbl-sm">Reply Date:</label>
                <asp:TextBox ID="ReplyDateTxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-12">
                 <label class="control-lbl-sm" for="ReplyTxt">Reply Text:</label>
                <CKEditor:CKEditorControl ID="ReplyTxt" BasePath="/ckeditor/" runat="server">
                </CKEditor:CKEditorControl>
                
            </div>
        </div>
    <br />
    <div class="container">
         <div class="col-md-12" style="text-align:center">
             <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" class="btn btn-primary"/>
             <asp:Button ID="Button2" runat="server" Text="Print" class="btn btn-primary"/>
         </div>
    </div>
    <br />




   
   
</asp:Content>
