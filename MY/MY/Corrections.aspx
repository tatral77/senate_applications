<%@ Page Title="" Language="C#" validateRequest="false" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Corrections.aspx.cs" Inherits="MY.Corrections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!-- include libraries(jQuery, bootstrap) -->
<%--<link href="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet"/>
<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script> 
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.js"></script> --%>

<!-- include summernote css/js -->
<link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.css" rel="stylesheet"/>
<script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.12/summernote.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">CORRECTIONS</label>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="NewCorrectionBtn" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="NewCorrectionBtn_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
             <p>NOTE: Corrections and updates can be submitted here or can be submitted on paper to Supervisor HRM Database. Please provide complete information to update. Some changes will be updated after verification from HRM Branch. </p>
                <table class="table table-hover table-striped table-condensed table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Correction</th>
                            <th>Date</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="CorrectionLV" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemCanceling="ItemCanceling"
                            OnItemUpdating="ItemUpdating"
                            OnItemInserting="ItemInserting"
                            OnItemDeleting="ItemDeleting">

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidCorrectionId" runat="server" Value='<%#Bind("CorrectionId") %>' />
                                        <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td style='width:50%;<%#Convert.ToInt32(Eval("Solved"))==1?"margin-top:10px;margin-bottom:10px;color:#006400":"color:#990000"%>'>
                                        <asp:Label ID="DesignationLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("CorrectionTxt") %>' />
                                    </td>
                                   
                                    <td>
                                        <asp:Label ID="PostedFrom" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CorrectionDate")))%>' />
                                    </td>
                                     <td>
                                        <asp:Label ID="BranchLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Convert.ToInt32(Eval("Solved"))==1?"Processed":"Under-Process"%>' />
                                    </td>
                                    
                                    <td style='<%#Convert.ToInt32(Eval("Solved"))==1?"display:none":"normal"%>'>
                                        <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                    </td>

                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <table class="table table-condensed table-data">
                                            <asp:HiddenField ID="HidCorrectionId" runat="server" Value='<%#Bind("CorrectionId") %>' />
                                            <asp:HiddenField ID="StatusId" runat="server" Value='<%#Bind("Solved") %>' />
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Correction</asp:Label></td>
                                                <td>
                                                    <textarea ID="CorrectionTxt" class="form-control control-txt" runat="server" Value='<%#Eval("CorrectionTxt") %>'></textarea>
                                                       <script>
                    $(document).ready(function () {
                        $('textarea').summernote(
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
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Date</asp:Label></td>
                                                <td>
                                                    <asp:Label ID="DateLbl" class="control-txt" runat="server" Text='<%#Bind("CorrectionDate")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Relation</asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label1" class="control-txt" runat="server" Text='<%#Convert.ToInt32(Eval("Solved"))==1?"Solved":"Under-Process"%>'></asp:Label></td>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <table class="table table-condensed table-data">
                                             <tr>
                                                <td>
                                                    <asp:Label runat="server">Correction</asp:Label></td>
                                                <td>
                                                    <textarea ID="CorrectionTxt" class="form-control control-txt" runat="server" Value=''></textarea>
                                                       <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_CorrectionLV_CorrectionTxt').summernote(
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                                        ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </InsertItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
