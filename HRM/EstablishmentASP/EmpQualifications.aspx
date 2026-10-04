<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpQualifications.aspx.cs" Inherits="EstablishmentASP.EmpQualifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid regularDiv">
        <div class="sec-head">
        <h5>EDUCATION</h5>
        <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" class="btn btn-custom" />
    </div>


        <div class="row">
            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Degree Level</th>
                            <th>Discipline</th>
                            <th>Subjects</th>
                            <th>Institution</th>
                            <th>Country</th>
                            <%--<th>City</th>--%>
                            <th>Completion Year</th>
                            <th>Grade</th>
                            <th>CGPA</th>
                            <th>Percentage</th>
                            <th>Division</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                    <tr>
                        <td colspan="12">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                    <asp:ListView ID="EmpQualificationLv" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemDataBound="ItemDataBound"
                        OnItemCanceling="ItemCanceling"
                        OnItemInserting="ItemInserting"
                        OnItemCreated="ItemCreated"
                        OnItemDeleting="ItemDeleting"
                        OnItemUpdating="ItemUpdating">
                        <%--
     OnItemUpdating="ItemUpdating"
 
                        --%>

                        <ItemTemplate>
                            <tr>

                                <td>
                                    <asp:HiddenField ID="HidEmpQualificationId" runat="server" Value='<%#Bind("Emp_Qualification_Id")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%# GetDegreeLevel(Convert.ToInt32(Eval("Degree_Level_Id")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("Degree_Obtained") %>'></asp:Label></td>
                                 <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("Subjects") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Institution_Name") %>'></asp:Label></td>
                               
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("Country_Id")))%>'></asp:Label></td>
                                <%-- <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%# GetCity(Convert.ToInt32(Eval("City_Id")))%>'></asp:Label></td>--%>
                                <td style="text-align: center">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("Completion_Year")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("Grade")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Division")%>'></asp:Label></td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the qualification of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
            <tr>
                <td colspan="12">
                <asp:HiddenField ID="HidEmpQualificationId" runat="server" Value='<%#Bind("Emp_Qualification_Id")%>' />
                <asp:HiddenField ID="HidDegreeLevelId" runat="server" Value='<%#Bind("Degree_Level_Id")%>' />
                <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("Country_Id")%>' />
                <asp:HiddenField ID="HidDivision" runat="server" Value='<%#Bind("Division")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Degree Level</td>
                    <td>
                        <asp:DropDownList ID="DegreeLevelDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Degree Level" ControlToValidate="DegreeLevelDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Discipline</td>
                    <td>
                        <asp:TextBox ID="DegreeObtainedTxt" class="form-control" runat="server" Text='<%#Bind("Degree_Obtained")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="Degree Obtained" ControlToValidate="DegreeObtainedTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Subjects</td>
                    <td>
                        <asp:TextBox ID="SubjectsTxt" class="form-control" runat="server" TextMode="MultiLine" Text='<%#Bind("Subjects")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Institution Name</td>
                    <td>
                        <asp:TextBox ID="InstitutionNameTxt" class="form-control" runat="server" Text='<%#Bind("Institution_Name")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" Display="Dynamic" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CountryDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Completion Year</td>
                    <td>
                        <asp:TextBox ID="CompletionYearTxt" class="form-control" runat="server" Text='<%#Bind("Completion_Year")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Completion Year" ControlToValidate="CompletionYearTxt" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Grade</td>
                    <td>
                        <asp:TextBox ID="GradeTxt" class="form-control" runat="server" Text='<%#Bind("Grade")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">CGPA</td>
                    <td>
                        <asp:TextBox ID="CGPATxt" class="form-control" runat="server" Text='<%#Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Percentage</td>
                    <td>
                        <asp:TextBox ID="PercentageTxt" class="form-control" runat="server" Text='<%#Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Division</td>
                    <td>
                        <asp:DropDownList ID="DivisionDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Value="Not Applicable">Not Applicable</asp:ListItem>
                            <asp:ListItem Value="1st Division">1st Division</asp:ListItem>
                            <asp:ListItem Value="2nd Division">2nd Division</asp:ListItem>
                            <asp:ListItem Value="3rd Division">3rd Division</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
                        <InsertItemTemplate>
            <tr>
                <td colspan="12">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Degree Level</td>
                    <td>
                        <asp:DropDownList ID="DegreeLevelDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Degree Level" ControlToValidate="DegreeLevelDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Discipline</td>
                    <td>
                        <asp:TextBox ID="DegreeObtainedTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="Degree Obtained" ControlToValidate="DegreeObtainedTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Subjects</td>
                    <td>
                        <asp:TextBox ID="SubjectsTxt" class="form-control" runat="server" TextMode="MultiLine" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Institution Name</td>
                    <td>
                        <asp:TextBox ID="InstitutionNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" Display="Dynamic" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CountryDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Completion Year</td>
                    <td>
                        <asp:TextBox ID="CompletionYearTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Completion Year" ControlToValidate="CompletionYearTxt" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Grade</td>
                    <td>
                        <asp:TextBox ID="GradeTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">CGPA</td>
                    <td>
                        <asp:TextBox ID="CGPATxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Percentage</td>
                    <td>
                        <asp:TextBox ID="PercentageTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Division</td>
                    <td>
                        <asp:DropDownList ID="DivisionDDL" runat="server" class="form-control" AutoPostBack="True">
                            <asp:ListItem Value="Not Applicable">Not Applicable</asp:ListItem>
                            <asp:ListItem Value="1st Division">1st Division</asp:ListItem>
                            <asp:ListItem Value="2nd Division">2nd Division</asp:ListItem>
                            <asp:ListItem Value="3rd Division">3rd Division</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>

                    </asp:ListView>


                </table>
            </div>
        </div>

    </div>

</asp:Content>

