<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="QuestionManagement.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script type="text/javascript">
               function storeCur(txtMsg)
               {
                   if (txtMsg.createTextRange) 
                     txtMsg.caretPos = document.selection.createRange().duplicate();
               }
                function drag(objSource) 
                {
               this.select = objSource;
             }
                function drag.prototype.drop(objDest) 
                {
                    if (!this.dragStart) return;
                    this.dest = objDest;
                    var pt=this.option.cloneNode(true);
                    if (objDest.createTextRange && objDest.caretPos) 
                    {                             
                        var caretPos = objDest.caretPos;
                        if(caretPos.text.charAt(caretPos.text.length - 1) == '')
                        {                                   
                            caretPos.text =  pt.value;
                        }                 
                    }
                }
        function drag.prototype.setIndex() 
        {
         var i = this.select.selectedIndex;
         window.status="selectedIndex = "+i;
         if (i==-1) return;
         this.option = this.select.options[i];
         this.dragStart=true;
        }
   if (myField.selectionStart || myField.selectionStart == '0')
    {
       var startPos = myField.selectionStart;
       var endPos = myField.selectionEnd;
      myField.value = myField.value.substring(0, startPos)+ myValue
    + myField.value.substring(endPos, myField.value.length);
    } 
  else 
   {
   myField.value += myValue;
   }
          
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    Email Message:
  <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Rows="10" Columns="50"   onclick="storeCur(this);" onkeyup="storeCur(this);" onselect="storeCur(this);"></asp:TextBox>
                               
 List Values:
<asp:ListBox ID="lstParameter" runat="server"    DataTextField="db_Values" DataValueField="db_Names" onmousedown="d = new drag(this)"
onmouseup="d.drop(this.form.txtMsg)" onmouseout="if (typeof d != 'undefined') d.setIndex()"> 
      <asp:ListItem Value="1">One</asp:ListItem>
            <asp:ListItem Value="2">Two</asp:ListItem>
            <asp:ListItem Value="3">Three</asp:ListItem></asp:ListBox>
        
    </div>
    </form>
  
</body>
</html>
