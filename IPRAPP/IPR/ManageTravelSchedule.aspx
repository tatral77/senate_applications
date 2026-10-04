<%@ Page Title="" Language="C#" MasterPageFile="~/OutgoingVisits.master" AutoEventWireup="true" CodeBehind="ManageTravelSchedule.aspx.cs" Inherits="IPR.ManageTravelSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <style>
      .btn-custom
      {
          background-color:#302c2c;
          color:#ffff
      }
    </style>
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label id="heading" runat="server" class="page-header">TRAVEL SCHEDULE</label>
                </h4>
            </div>
            <div class="col-md-2 page-header hideadd">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Departure</th>
                        <th>Arrival</th>
                        <th>Fligh No</th>
                     <%--   <th>Flight Duration</th>--%>
                        <th class="hideall">Action</th>

                    </tr>
                    <asp:ListView ID="TravelScheduleLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemDeleting="ItemDeleting"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidTravelScheduleId" runat="server" Value='<%#Bind("TravelScheduleId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("DepCity") +" (" + Convert.ToDateTime(Eval("DepDate")).ToShortDateString() + " / " + Convert.ToDateTime(Eval("DepTime")).ToString("HH:mm")  + ")"%>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("ArrCity") +" (" + Convert.ToDateTime(Eval("ArrDate")).ToShortDateString() + " / " + Convert.ToDateTime(Eval("ArrTime")).ToString("HH:mm")   + ")" %>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("FlighNumber")%>'></asp:Label>
                                </td>
                                <%--  <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#GetDuration(Eval("DepTime").ToString(),Eval("ArrTime").ToString())%>'></asp:Label>
                                </td>--%>
                                <td class="itemCent hideall">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom hideedit" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom hidedelete" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                 
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                    <asp:HiddenField ID="HidTravelScheduleId" runat="server" Value='<%#Bind("TravelScheduleId")%>' />
                                                    <asp:HiddenField ID="HidArrCityId" runat="server" Value='<%#Bind("ArrCityId")%>' />
                                                    <asp:HiddenField ID="HidDepCityId" runat="server" Value='<%#Bind("DepCityId")%>' />
                                                <asp:Label runat="server">Departure City</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="DepCityTxt" class="form-control" runat="server" Text='<%#Bind("DepCity")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="DepCityTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Departure Date / Time</asp:Label></td>
                                            <td>Date
                                                <asp:TextBox ID="DepDateTxt" required="true"  class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("DepDate")).ToShortDateString()%>'></asp:TextBox>
                                                </td>
                                            <td>Time
                                                <asp:TextBox ID="DepTimeTxt" required="true"  class="form-control time" runat="server" Text='<%#Convert.ToDateTime(Eval("DepTime")).ToString("HH:mm")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Arrival City</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="ArrCityTxt" class="form-control" runat="server" Text='<%#Bind("ArrCity")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="ArrCityTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Arrival Date / Time</asp:Label></td>
                                            <td>Date
                                                <asp:TextBox ID="ArrDateTxt" required="true" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("ArrDate")).ToShortDateString()%>'></asp:TextBox>
                                           </td>
                                        <td>Time
                                                <asp:TextBox ID="ArrTimeTxt" required="true" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("ArrTime")).ToString("HH:mm")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Flight Number</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="FlighNumberTxt" required="true" class="form-control" runat="server" Text='<%#Eval("FlighNumber")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
                                            <td class="table-data">
                                                <asp:Label runat="server">Departure City</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="DepCityTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                 
                                                    <asp:HiddenField ID="HidDepCityId" runat="server" Value='<%#Bind("DepCityId")%>' />
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="DepCityTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Departure Date / Time</asp:Label></td>
                                            <td>Date
                                                <asp:TextBox ID="DepDateTxt" required="true"  class="form-control date" runat="server" Text=''></asp:TextBox>
                                                </td>
                                            <td>Time
                                                <asp:TextBox ID="DepTimeTxt" required="true"  class="form-control time" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Arrival City</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="ArrCityTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                  <asp:HiddenField ID="HidArrCityId" runat="server" Value='<%#Bind("ArrCityId")%>' />
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="ArrCityTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Arrival Date / Time</asp:Label></td>
                                            <td>Date
                                                <asp:TextBox ID="ArrDateTxt" required="true" class="form-control date" runat="server" Text=''></asp:TextBox>
                                           </td>
                                        <td>Time
                                                <asp:TextBox ID="ArrTimeTxt" required="true" class="form-control time" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Flight Number:</asp:Label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="FlighNumberTxt" required="true" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('input[name*=DepCityTxt]').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetCityByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
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
                    $("[id$=HidDepCityId]").val(i.item.val);
                },
                minLength: 1
            });
        });
        $(function () {
            $('input[name*=ArrCityTxt]').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetCityByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
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
                    $("[id$=HidArrCityId]").val(i.item.val);
                },
                minLength: 1
            });
        });
        $(document).ready(function () {
            $('.date').mask('00/00/0000');
        });
        $(document).ready(function () {
            $('.time').mask('00:00');
        });
    </script>
</asp:Content>
