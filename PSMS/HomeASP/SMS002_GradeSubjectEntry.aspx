<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS002_GradeSubjectEntry.aspx.cs" Inherits="HomeASP.SMS002" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Grade&Subject Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/styles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/GradeSubjectStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
  <script type="text/javascript">  function allowOnlyNumber(evt) {
      var charCode = (evt.which) ? evt.which : event.keyCode
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
          alert("Only Number Allowed!");
          return false;
      } else {
          return true;
      }
  }
      </script>
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html"-->
            <!-- header ends -->

            <!-- content begins -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 1140px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 1100px;" autocomplete="off">
                                <h2>Grade And Subject Entry</h2>
                                   
                                <table style="border-collapse:separate; border-spacing:0 10px;">
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="lblEduYear1" CssClass="label" runat="server"  Text="Education Year"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="eduYearGrade" CssClass="dropdownlist" runat="server" >
                                                <asp:ListItem Text="Select Year" Value="Select Year" />
                                                <asp:ListItem Text="2011 - 2012" Value="2011 - 2012" />
                                                <asp:ListItem Text="2012 - 2013" Value="2012 - 2013" />
                                                <asp:ListItem Text="2013 - 2014" Value="2013 - 2014" />
                                                <asp:ListItem Text="2014 - 2015" Value="2014 - 2015" />
                                                <asp:ListItem Text="2015 - 2016" Value="2015 - 2016" />
                                                <asp:ListItem Text="2016 - 2017" Value="2016 - 2017" />
                                                <asp:ListItem Text="2017 - 2018" Value="2017 - 2018" />
                                                <asp:ListItem Text="2018 - 2019" Value="2018 - 2019" />
                                                <asp:ListItem Text="2019 - 2020" Value="2019 - 2020" />
                                                <asp:ListItem Text="2020 - 2021" Value="2020 - 2021" />
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="id" CssClass="label" runat="server" Text="ID"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="gradeId" CssClass="textbox" runat="server" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                        </td>
                                        <td>
 <%--<asp:Label runat="server" ID="alertMsg" Font-Size="Medium" style="margin-left:10px;color:red"></asp:Label>--%>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errEduYear1" Visible="false" Text="Please Choose Education Year!" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errGradeId" Visible="false" ForeColor="Red" Text="Please Enter Grade Id!" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="grade" CssClass="label" runat="server" Text="Grade"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="gradeName" CssClass="textbox" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="lblPrice" CssClass="label" runat="server" Text="Price"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="price" CssClass="textbox" runat="server" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errGradeName" Visible="false" Text="Please Enter Grade Name!" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errPrice" Visible="false" Text="Please Enter Price!" ForeColor="Red" />
                                        </td>
                                    </tr>--%>
                                    </table>
                                <table>
                                    <tr>
                                        <td width="30"></td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnAdd" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnShowAll" runat="server" Text="Show All" OnClick="btnSelect_Click" />
                                        </td>
                                           <td class="auto-style1">
                                            <asp:Label ID="errgrade1" runat="server" Text="Please input required field!" CssClass="errlable1" Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td class="auto-style1">
                                            <asp:Label ID="Label1" runat="server" Text="This ID is already saved!" CssClass="errlable1" Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div class="GSgridview" style="padding-left: 20px;height:100px">
                                    <asp:GridView ID="gridViewGrade" AutoGenerateColumns="False" class="GSgridview" runat="server" BorderColor="#1DA18C" AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record."  OnPageIndexChanging="gridViewGrade_PageIndexChanging">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Year"
                                                DataField="EDU_YEAR"
                                                SortExpression="EDU_YEAR"></asp:BoundField>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="GRADE_ID"
                                                SortExpression="GRADE_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Grade"
                                                DataField="GRADE_NAME"
                                                SortExpression="GRADE_NAME"></asp:BoundField>
                                            <asp:BoundField HeaderText="Price"
                                                DataField="MONTHLY_FEE"
                                                SortExpression="PRICE"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnGradeEdit" runat="server" Text="Edit" CommandName='<%# Eval("GRADE_ID") %>' OnClick="btnUpdate_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnGradeDelete" runat="server" Text="Delete" CommandName='<%# Eval("GRADE_ID") %>' OnClick="btnDelete_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#D2EEEA" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>
                                </div>
                                <%-- <hr style="width:auto"/>--%>
                                <table style="border-collapse:separate; border-spacing:0 10px;">
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="lblEduYear2" CssClass="label" runat="server" Text="Education Year"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="eduYearSubject" CssClass="dropdownlist" runat="server">
                                                <asp:ListItem Text="Select Year" Value="Select Year" />
                                                <asp:ListItem Text="2011 - 2012" Value="2011 - 2012" />
                                                <asp:ListItem Text="2012 - 2013" Value="2012 - 2013" />
                                                <asp:ListItem Text="2013 - 2014" Value="2013 - 2014" />
                                                <asp:ListItem Text="2014 - 2015" Value="2014 - 2015" />
                                                <asp:ListItem Text="2015 - 2016" Value="2015 - 2016" />
                                                <asp:ListItem Text="2016 - 2017" Value="2016 - 2017" />
                                                <asp:ListItem Text="2017 - 2018" Value="2017 - 2018" />
                                                <asp:ListItem Text="2018 - 2019" Value="2018 - 2019" />
                                                <asp:ListItem Text="2019 - 2020" Value="2019 - 2020" />
                                                <asp:ListItem Text="2020 - 2021" Value="2020 - 2021" />
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="ID"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="subjectId" CssClass="textbox" runat="server" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="subject" CssClass="label" runat="server" Text="Subject"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="subjectName" CssClass="textbox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errEduYear2" Text="Please Choose Edu Year!" Visible="false" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errSubjectId" Visible="false" Text="Please enter Suject ID!" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errSubjectName" Visible="false" Text="Please enter Subject Name!" ForeColor="Red" />
                                        </td>
                                    </tr>--%>
                                    </table>
                                    <Table>
                                    <tr><td width="30"></td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="subjectAdd" runat="server" Text="Save" OnClick="btnAddSubject_Click" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="subjectShowAll" runat="server" Text="Show All" OnClick="btnSelectSubject_Click" />
                                        </td>
                                       
                                           <td >
                                            <asp:Label ID="Label5" runat="server" Text="Please input required field!"  Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td class="auto-style1">
                                            <asp:Label ID="Label6" runat="server" Text="This ID is already saved!" CssClass="errlable1" Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div class="GSgridview" style="padding-left: 20px;height:100px">
                                    <asp:GridView ID="gridViewSubject" AutoGenerateColumns="False"  class="GSgridview"  runat="server"  AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="There is no data" OnPageIndexChanging="gridViewSubject_PageIndexChanging" >
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Year"
                                                DataField="EDU_YEAR"
                                                SortExpression="EDU_YEAR"></asp:BoundField>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="SUBJECT_ID"
                                                SortExpression="SUBJECT_ID" ></asp:BoundField>
                                            <asp:BoundField HeaderText="Subject"
                                                DataField="SUBJECT_NAME"
                                                SortExpression="SUBJECT_NAME"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnSubjectEdit" runat="server" Text="Edit" CommandName='<%# Eval("SUBJECT_ID") %>' OnClick="btnUpdateSubject_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnSubjectDelete" runat="server" Text="Delete" CommandName='<%# Eval("SUBJECT_ID") %>' OnClick="btnDeleteSubject_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#D2EEEA" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>





                                </div >
                                
                                <table style="border-collapse:separate; border-spacing:0 10px;">
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="lblEduYear3" CssClass="label" runat="server" Text="Education Year"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="eduYearGradeSubject" CssClass="dropdownlist" runat="server">
                                                <asp:ListItem Text="Select Year" Value="Select Year" />
                                                <asp:ListItem Text="2011 - 2012" Value="2011 - 2012" />
                                                <asp:ListItem Text="2012 - 2013" Value="2012 - 2013" />
                                                <asp:ListItem Text="2013 - 2014" Value="2013 - 2014" />
                                                <asp:ListItem Text="2014 - 2015" Value="2014 - 2015" />
                                                <asp:ListItem Text="2015 - 2016" Value="2015 - 2016" />
                                                <asp:ListItem Text="2016 - 2017" Value="2016 - 2017" />
                                                <asp:ListItem Text="2017 - 2018" Value="2017 - 2018" />
                                                <asp:ListItem Text="2018 - 2019" Value="2018 - 2019" />
                                                <asp:ListItem Text="2019 - 2020" Value="2019 - 2020" />
                                                <asp:ListItem Text="2020 - 2021" Value="2020 - 2021" />
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="ID"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="gradeSubjectId" CssClass="textbox" runat="server" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Grade"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="gradeList" runat="server" ForeColor="Black" CssClass="dropdownlist" AutoPostBack="false" ></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errEduYear3" Visible="false" Text="Please Choose Edu Year!" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errGradeSubjectId" Visible="false" Text="Please enter ID!" ForeColor="Red" />
                                        </td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errGradeList" Visible="false" Text="Please Choose Grade!" ForeColor="Red" />
                                        </td>
                                    </tr>--%>
                                   </table>
                                <table>
                                    <tr><td style="width:30px;height:60px;"></td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="gradeSubjectAdd" runat="server" Text="Save" OnClick="btnAddGradeSubject_Click" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="gradeSubjectShowAll" runat="server" Text="Show All" OnClick="btnSelectGradeSubject_Click"  />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errorSubandGrade" runat="server" Text="Please input required field!"  Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                          <td class="auto-style1">
                                            <asp:Label ID="Label8" runat="server" Text="This ID is already saved!" CssClass="errlable1" Visible="False" ForeColor="Red"></asp:Label>
                                        </td>
                                     
                                    </tr>
                                </table>
                               
                                <div class="selectSubject" style="padding-left: 20px;height:100px">
                                    <asp:Label runat="server" ID="errSubjectList" Visible="false" ForeColor="Red" Text="Please Choose Subject!" Font-Size="12px" />
                                    
                                    <div style="width: 320px; height: 100px; overflow:auto;">
                                    <asp:GridView ID="subjectGridView" AutoGenerateColumns="false" runat="server" BackColor="#1C5E55" Width="300px" Visible="true" ForeColor="White">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-CssClass="template-checkbox" HeaderStyle-CssClass="template-checkbox">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="selectedSubject" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Subject"
                                                DataField="SUBJECT_NAME"
                                                SortExpression="SUBJECT_NAME" ItemStyle-CssClass="template-checkbox" HeaderStyle-CssClass="template-checkbox"></asp:BoundField>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="SUBJECT_ID"
                                                SortExpression="SUBJECT_ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                        </div>

                                </div>
                                <div class="GSgridview" style="padding-left: 20px">
                                    <asp:GridView ID="gradeSubjectGridView" AutoGenerateColumns="False" runat="server" class="GSgridview" AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="There is no data" OnPageIndexChanging="gridViewGradeSubject_PageIndexChanging" OnSelectedIndexChanged="gradeSubjectGridView_SelectedIndexChanged1" >
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField ReadOnly="True"
                                                HeaderText="Year" InsertVisible="False"
                                                DataField="EDU_YEAR"
                                                SortExpression="EDU_YEAR"></asp:BoundField>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="ID" SortExpression="ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Grade"
                                                DataField="GRADE_ID" SortExpression="GRADE_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Subject"
                                                DataField="SUBJECT_ID_LIST" SortExpression="SUBJECT_ID_LIST"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnGradeSubjectEdit" runat="server" Text="Edit" CommandName='<%# Eval("ID") %>' OnClick="btnUpdateGradeSubject_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnGradeSubjectDelete" runat="server" Text="Delete" CommandName='<%# Eval("ID") %>' OnClick="btnDeleteGradeSubject_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#D2EEEA" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- content ends -->

            <!-- footer begins -->
            <!-- #include file="~/HtmlPages/Footer.html"-->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>
