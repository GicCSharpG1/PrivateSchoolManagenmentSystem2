<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS004_StudentList.aspx.cs" Inherits="HomeASP.SMS004" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student List</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />


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
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                <h2>Student List</h2>
                                <table style="font: 16px Verdana, Helveticaall-petite-caps; color: #074959; margin:30px 0px 20px 15px">
                                    <tr>
                                        <td>&nbsp;&nbsp;Name &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="searchstuname" runat="server" CssClass="textbox" Width="160px" Height="20px"></asp:TextBox></td>
                                        <td style="width: 60px;"></td>
                                        <td>Grade &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="stulistgrade" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 60px;"></td>
                                        <td>Class Year &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="comboYear" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem>Select Year</asp:ListItem>
                                                <asp:ListItem>2001 - 2002</asp:ListItem>
                                                <asp:ListItem>2003 - 2004</asp:ListItem>
                                                <asp:ListItem>2005 - 2006</asp:ListItem>
                                                <asp:ListItem>2007 - 2008</asp:ListItem>
                                                <asp:ListItem>2009 - 2010</asp:ListItem>
                                                <asp:ListItem>2010 - 2011</asp:ListItem>
                                                <asp:ListItem>2011 - 2012</asp:ListItem>
                                                <asp:ListItem>2012 - 2013</asp:ListItem>
                                                <asp:ListItem>2013 - 2014</asp:ListItem>
                                                <asp:ListItem>2014 - 2015</asp:ListItem>
                                                <asp:ListItem>2015 - 2016</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                                <div style="padding-left: 20px;height:270px">
                                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CssClass="gridview" AllowPaging="True" PageSize="10" BorderStyle="None" BorderWidth="1px" CellSpacing="3" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record." OnPageIndexChanging="StuList_PageIndexChanging" Width="96%">
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#D2EEEA" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="ID" DataField="STUDENT_ID" SortExpression="STUDENT_ID" />
                                            <asp:BoundField HeaderText="Education Year" DataField="EDU_YEAR" SortExpression="EDU_YEAR" />
                                            <asp:BoundField HeaderText="Student Name" DataField="STUDENT_NAME" SortExpression="STUDENT_NAME" />
                                            <asp:BoundField HeaderText="Grade" DataField="GRADE_ID" SortExpression="GRADE_ID" />
                                            <asp:BoundField HeaderText="Gender" DataField="GENDER" SortExpression="GENDER" />
                                            <asp:BoundField HeaderText="Image_Path" DataField="PHOTO_PATH" SortExpression="PHOTO_PATH" />

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnStuUpdate" runat="server" Text="Edit" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnStudentUpdate_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnStuDetailSelect" runat="server" Text="Detail" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnStudentDetail_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnStuDelete" runat="server" Text="Delete" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnStudentDelete_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                   <div>
                                   <asp:Label ID="errorSeach" ForeColor="Red" Font-Size="15px" Style="float: left; margin-left: 22px;" runat="server">Please Put Error Sms here!!!</asp:Label>
                                    &nbsp;</div>
                                    <table style="margin-left: 450px;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="103px" OnClick="btnSearch_Click" CssClass="btn" Height="30px" /></td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnShowAll" runat="server" Text="Show All" Width="103px" OnClick="btnShowAll_Click" CssClass="btn" Height="30px" />
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnAdd" runat="server" Text="Student Entry" Width="122px" CssClass="btn" OnClick="btnAdd_Click1" Height="30px" />
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                   
                                
                            </form>
                            &nbsp;
                        </div>
                    </div>
                    <br />
                </div>

                <br />
                <div style="clear: both">
                    <img src="images/spaser.gif" alt="" width="1" height="1" />
                </div>
                <div class="bot"></div>
            </div>
            <!-- content ends -->

            <!-- footer begins -->
            <!-- #include file="~/HtmlPages/Footer.html" -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>
