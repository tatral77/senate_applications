<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MY.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- include libraries(jQuery, bootstrap) -->
<link href="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet"/>
<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script> 
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.js"></script> 

<!-- include summernote css/js -->
<link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.css" rel="stylesheet"/>
<script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <textarea id="QuestionTxt" name="QuestionTxt" style="height:300px" class="form-control" ValidationGroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#QuestionTxt').summernote(
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
    </div>
    </form>
</body>
</html>
