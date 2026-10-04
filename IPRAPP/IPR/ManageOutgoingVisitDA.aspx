<%@ Page Title="" Language="C#" MasterPageFile="~/OutgoingVisits.master" AutoEventWireup="true" CodeBehind="ManageOutgoingVisitDA.aspx.cs" Inherits="IPR.ManageOutgoingVisitDA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <style>
       .tableheading{
            background-color: #302c2c;
            color: #fff;
            font-weight: 500;
        }
        .country-heading{
            font-size: 10pt;
            font-weight: bold;
        }
          .table-heading{
            font-size: 10pt;
            font-weight: bold;
        }
        #wrap-div{
                background-color: #e0e0e0;
                border-radius: 5px;
                padding: 5px;
                margin-bottom: 5px;
        }

        #wrap-div .form-control {
            background-color: #fff;
        }

        .accordion-custom{
                background-color: #e0e0e0;
        }

        .total-div{
            font-size:12pt;
            font-weight:bold;
            text-align:right;
            background-color:#febe53;
            padding:5px 30px 5px 5px;
        }

        .accordion-custom button {
            color: #000;
        }

        .accordion-custom button:hover{
            background-color: #febe53;
            color: #000;
        }
        .errorLbl{
            color:red;
            font-size:9pt;
        }

    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h4><strong>Manage DA</strong></h4>
            </div>
        </div>
    <div id="wrap-div">
        <div class="row">
            <div class="col-md-3">
                <label class="caption">Country</label>
                <asp:DropDownList ID="CountryDDL" CssClass="form-control" runat="server" OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CountryDDL" runat="server" InitialValue="0" ErrorMessage="Select Country" CssClass="errorLbl" ValidationGroup="group1"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <label class="caption">Location</label>
                <asp:DropDownList ID="LocationDDL" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="caption">From Date</label>
                <asp:TextBox ID="FromDateTxt" CssClass="form-control" type="date" runat="server" required="true"></asp:TextBox>
                    <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="Enter From Date" ControlToValidate="FromDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <label class="caption">To Date</label>
                <asp:TextBox ID="ToDateTxt" CssClass="form-control" type="date"  runat="server" required="true"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="Enter To Date" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
          <%--  <div class="col-md-2">
                <label class="caption">No. of Nights</label>
                <asp:TextBox ID="NoOfNightTxt" CssClass="form-control" runat="server" type="number" required="true">1</asp:TextBox>
                <asp:RangeValidator ID="ShareTextBoxRangeValidator" MaximumValue="200" ValidationGroup="group1" runat="server" CssClass="errorLbl" ErrorMessage="Nights should be greater than 0" ControlToValidate="NoOfNightTxt" MinimumValue="1"  Display="Dynamic" ClientIDMode="Predictable"/>
            </div>--%>
            <%--<div class="col-md-2" style="visibility:hidden">
                <label class="caption">Higher Side Payment</label>
                <asp:TextBox ID="HigherSidePaymentTxt" CssClass="form-control" type="number" runat="server" required="true">0</asp:TextBox>
            </div>--%>
            <div class="col-md-2">
                <label class="caption">Arrangement Type</label>
                <asp:DropDownList ID="ArrangementTypeDDL" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <label class="caption">Facility Type</label>
                <asp:DropDownList ID="FacilityTypeDDL" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <label class="caption">Hotel Charges</label>
                <asp:TextBox ID="HotelChargesTxt" CssClass="form-control" runat="server" type="number" required="true">0</asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="caption">Early Checkin Charges</label>
                <asp:TextBox ID="EarlyCheckInChargesTxt" CssClass="form-control" runat="server" type="number" required="true">0</asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="caption">Late Checkout Charges</label>
                <asp:TextBox ID="LateCheckOutChargesTxt" CssClass="form-control" runat="server" type="number" required="true">0</asp:TextBox>
            </div>
        </div>
    </div>
        <div class="row">
             <div class="col-md-12" style="text-align:left;color:red;padding-right:30px;">
                 <asp:Label ID="ErrorLbl" style="font-size:9pt;" runat="Server" Text=""></asp:Label>
            </div>
            <table class="table table-condensed table-responsive caption">
                <tr>
                    <th><asp:CheckBox ID="CheckAllCB" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged" /> Select</th>
                    <th>Sr#</th>
                    <th>Composition of Delegation</th>
                    <th>Position</th>
                    <th>Category</th>
                    <th>Remarks</th>
                </tr>
                <asp:ListView runat="server" ID="MembersLV">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="HidSystemUserId" Value='<%#Eval("SystemUserId") %>' runat="server" />
                                <asp:HiddenField ID="HidCompositionId" Value='<%#Eval("CompositionId") %>' runat="server" />
                                <asp:HiddenField ID="HidCategoryId" Value='<%#Eval("CategoryId") %>' runat="server" />
                                <asp:HiddenField ID="HidIsChairman" Value='<%#Eval("IsChairman") %>' runat="server" />
                                <asp:CheckBox ID="SelectCB" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="VisitorNameLbl" runat="server" Text='<%#Eval("VisitorName") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="PostLabel" runat="server" Text='<%#Eval("Post") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="CategoryNameLbl" runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>
                            </td>
                               <td>
                                   <asp:TextBox ID="RemarksTxt" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
        </div>

        <div class="row">
            <div class="col-md-12" style="text-align:right">
                <asp:Button ID="SaveBtn" runat="server" Text="Save" class="btn btn-custom" OnClick="SaveBtn_Click" ValidationGroup="group1" />
            </div>
        </div>
        <hr />

        <div class="row total-div">
            <div class="col-md-2"></div>
            <div class="col-md-2">
                 <asp:Label ID="TotalLbl" runat="Server" Text="Grand Total: $ 0"></asp:Label>
            </div>
            <div class="col-md-2">
                 <asp:Label ID="CurrentyRateLbl" runat="Server" Text=""></asp:Label>
            </div>
            <div class="col-md-6">
                 <asp:Label ID="TotalPkrLbl" runat="Server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                    <asp:ListView ID="VisitLV"
                    OnItemCreated="VisitLV_ItemCreated"
                    OnItemDataBound="VisitLV_ItemDataBound"
                    OnItemInserted="VisitLV_ItemInserted"
                    OnItemUpdated="VisitLV_ItemUpdated"
                    OnItemDeleting="VisitLV_ItemDeleting"
                    runat="server">
                    <LayoutTemplate>
                        <table class="table table-condensed table-responsive" style="width:100%" runat="server">
                            <tr runat="server" id="itemPlaceholder" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>   
                            <div class="accordion accordion-custom" id="accordionExample">
                              <div class="card">
                                <div class="card-header" id="headingOne">
                                  <h2 class="mb-0">
                                    <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#<%#Container.DataItemIndex + 1%>" aria-expanded="true" aria-controls="collapseOne">
                                      <div class="row">
                                          <div class="col-md-2">
                                              <asp:HiddenField ID="HidDADetailId" Value='<%#Eval("DADetailsId") %>' runat="server" />
                                              <span class="country-heading">Country:</span>
                                              <asp:Label ID="Label1" CssClass="caption" runat="Server" Text='<%#Eval("Country") %>'></asp:Label>
                                          </div>
                                          <div class="col-md-2">
                                              <span class="country-heading">Location:</span>
                                              <asp:Label ID="FirstNameLabel" CssClass="caption" runat="Server" Text='<%#Eval("Location") %>'></asp:Label>
                                          </div>
                                          <div class="col-md-4">
                                              <span class="country-heading">Arrangement Type:</span>
                                              <asp:Label ID="Label2" CssClass="caption" runat="Server" Text='<%#Eval("Arrangement") %>'></asp:Label>
                                          </div>
                                            <div class="col-md-2">
                                              <span class="country-heading">Total:</span>
                                              <asp:Label ID="Label7" CssClass="caption" runat="Server" Text='<%#string.Concat("$ ", Eval("Total")) %>'></asp:Label>
                                          </div>
                                       
                                          <div class="col-md-2" style="text-align:right">
                                              <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                                   ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                          </div>
                                      </div>
                                    </button>
                                  </h2>
                                </div>
                               
                                <div class="container-fluid">
                                    <div id="<%#Container.DataItemIndex + 1%>" class="collapse" aria-labelledby="headingOne" data-parent="#accordionExample">
                                      <div class="card-body">
                                              <div class="row">
                                                  <div class="col-md-3">
                                                      <span class="country-heading">From Date:</span>
                                                      <asp:Label ID="lblFromDate" CssClass="caption" runat="Server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label>
                                                      <span class="country-heading">To Date:</span>
                                                      <asp:Label ID="lblToDate" CssClass="caption" runat="Server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label>
                                                  </div>
                                                  <div class="col-md-1">
                                                      <span class="country-heading">Nights:</span>
                                                      <asp:Label ID="lblNoOfNights" CssClass="caption" runat="Server" Text='<%#Eval("NoOfNights") %>'></asp:Label>
                                                  </div>
                                              <div class="col-md-2">
                                                  <span class="country-heading">Facility:</span>
                                                  <asp:Label ID="Label4" CssClass="caption" runat="Server" Text='<%#Eval("Facility") %>'></asp:Label>
                                              </div>
                                              <div class="col-md-2">
                                                  <span class="country-heading">Hotel Charges:</span>
                                                  <asp:Label ID="Label5" CssClass="caption" runat="Server" Text='<%#Eval("HotelCharges") %>'></asp:Label>
                                              </div>
                                              <div class="col-md-2">
                                                  <span class="country-heading">Early Check-In Charges:</span>
                                                  <asp:Label ID="Label6" CssClass="caption" runat="Server" Text='<%#Eval("EarlyCheckinCharges") %>'></asp:Label>
                                                  </div>
                                                   <div class="col-md-2">
                                                  <span class="country-heading">Early Check-Out Charges:</span>
                                                  <asp:Label ID="Label3" CssClass="caption" runat="Server" Text='<%#Eval("LatecheckOutCharges") %>'></asp:Label>
                                                  </div>
                                          </div>
                                          <asp:ListView ID="VisitorsLV" runat="server">
                                              <LayoutTemplate>
                                                   <div class="row caption" style="margin-right: 15px;">
                                                      <div class="col-md-3 tableheading">
                                                          <asp:Label ID="Label1" runat="Server" Text="Visitor Name" />
                                                      </div>
                                                      <div class="col-md-2 tableheading">
                                                          <asp:Label ID="FirstNameLabel" runat="Server" Text="Category" />
                                                      </div>
                                                      <div class="col-md-2 tableheading">
                                                          <asp:Label ID="TotalDALbl" runat="Server" Text="Total DA" />
                                                      </div>
                                                       <div class="col-md-5 tableheading">
                                                          <asp:Label ID="DaRemarksLbl" runat="Server" Text="Remarks" />
                                                      </div>
                                                  </div>
                                                     <div runat="server" id="itemPlaceholder" />
                                              </LayoutTemplate>
                                              <ItemTemplate>
                                                  <div class="row caption" style="margin-right: 15px;">
                                                      <div class="col-md-3">
                                                          <asp:Label ID="Label1" runat="Server" Text='<%#Eval("VisitorName") %>' />
                                                      </div>
                                                      <div class="col-md-2">
                                                          <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("Category") %>' />
                                                      </div>
                                                      <div class="col-md-2">
                                                          <asp:Label ID="LastNameLabel" runat="Server" Text='<%#string.Concat("$ ", Eval("TotalDA")) %>' />
                                                      </div>
                                                      <div class="col-md-5">
                                                          <asp:Label ID="DaRemarksLbl" runat="Server" Text='<%#Eval("DaRemarks") %>' />
                                                      </div>
                                                  </div>
                                              </ItemTemplate>
                                          </asp:ListView>
                                      </div>
                                    </div>
                                </div>

                              </div>
                            </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>

    </div>
</asp:Content>
