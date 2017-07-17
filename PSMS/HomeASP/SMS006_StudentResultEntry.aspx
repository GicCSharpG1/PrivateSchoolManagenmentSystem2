<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS006_StudentResultEntry.aspx.cs" Inherits="HomeASP.SMS006" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Result Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentResultStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

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
                                <h2>Student Exam Result Entry</h2>
                                <div style="float: left;padding:10px 15px 10px 15px">
                                    <asp:Label ID="errData" runat="server" CssClass="errlable1" Text="Data doesn't exist!" Visible="false"></asp:Label>
                                    <asp:Label ID="msgSuccess" runat="server" CssClass="errlable1" Text="Successfully created!" Visible="false"></asp:Label>
                                    <table id="Table1" runat="server">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="errresuyear" runat="server" CssClass="errlable1"></asp:Label></td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td colspan="2">
                                                <asp:Label ID="errresmonth" runat="server" CssClass="errlable1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" CssClass="label" runat="server">Education Year*</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlresyearlist" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                    <asp:ListItem>Choose year</asp:ListItem>
                                                    <asp:ListItem>2010-2011</asp:ListItem>
                                                    <asp:ListItem>2011-2012</asp:ListItem>
                                                    <asp:ListItem>2012-2013</asp:ListItem>
                                                    <asp:ListItem>2013-2014</asp:ListItem>
                                                    <asp:ListItem>2014-2015</asp:ListItem>
                                                    <asp:ListItem>2015-2016</asp:ListItem>
                                                    <asp:ListItem>2016-2017</asp:ListItem>
                                                    <asp:ListItem>2017-2018</asp:ListItem>
                                                    <asp:ListItem>2018-2019</asp:ListItem>
                                                    <asp:ListItem>2019-2020</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td>
                                                <asp:Label ID="Label5" CssClass="label" runat="server">Month*</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlresmonthlist" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                    <asp:ListItem>Choose month</asp:ListItem>
                                                    <asp:ListItem>January</asp:ListItem>
                                                    <asp:ListItem>February</asp:ListItem>
                                                    <asp:ListItem>March</asp:ListItem>
                                                    <asp:ListItem>April</asp:ListItem>
                                                    <asp:ListItem>Jun</asp:ListItem>
                                                    <asp:ListItem>July</asp:ListItem>
                                                    <asp:ListItem>August</asp:ListItem>
                                                    <asp:ListItem>September</asp:ListItem>
                                                    <asp:ListItem>October</asp:ListItem>
                                                    <asp:ListItem>November</asp:ListItem>
                                                    <asp:ListItem>December</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="errresgrade" runat="server" CssClass="errlable1"></asp:Label></td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td colspan="2">
                                                <asp:Label ID="errresroom" runat="server" CssClass="errlable1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" CssClass="label" runat="server">Grade*</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlgradeList" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td>
                                                <asp:Label ID="Label3" CssClass="label" runat="server">Room*</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlroomList" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSearchRes" runat="server" Text="Search" CssClass="btn" OnClick="btnSearchRes_Click"/> </td>
                                            <td> <asp:Button ID="btnSave" runat="server" Text="Export File" CssClass="btn" OnClick="BtnSave_Click" Enabled="False" /></td>
                                            <td> <asp:Button ID="btnViewExcel" runat="server" Text="Open File" CssClass="btn" OnClick="btnViewExcel_Click" Enabled="False" /></td>
                                            <td> <asp:Button ID="btnMarkSave" runat="server" Text="Exam Mark Save" CssClass="stuExambtn" OnClick="BtnMarkSave_Click" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblmsg" CssClass="label" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>      
                                <br />
                                <div id="Div3" runat="server">
                                    <asp:GridView ID="gvstdResult" runat="server" CellPadding="4" Height="196px" Width="660px" GridLines="None" ForeColor="#333333" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." OnPageIndexChanging="gvstdResult_PageIndexChanging" AutoGenerateColumns="true" AllowPaging="True" PageSize="5">
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <%--<Columns>
                                        <asp:BoundField HeaderText="ID"
                                            DataField="STUDENT_ID"
                                            SortExpression="STUDENT_ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
	                                    <asp:BoundField HeaderText="NAME"
		                                    DataField="STUDENT_NAME"
		                                    SortExpression="STUDENT_NAME"></asp:BoundField>
	                                    <asp:BoundField HeaderText="ROLL NO"
	                                    DataField="ROLL_NO"
	                                    SortExpression="ROLL_NO"></asp:BoundField>
                                            <asp:TemplateField HeaderText="" >
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject1" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject2" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject3" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject4" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject5" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject6" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnResultEdit" runat="server" Text="Edit" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnResultUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </form>
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
            <!-- #include file="~/HtmlPages/Footer.html"-->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>


