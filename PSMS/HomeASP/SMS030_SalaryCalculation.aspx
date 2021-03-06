﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS030_SalaryCalculation.aspx.cs" Inherits="HomeASP.SMS030" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Salary Calculation</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/classtimetable.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

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
                                <h2>Salary Calculation</h2>
                                <table style="margin-left: 20px">
                                    <tr>
                                        <td colspan="3"></td>
                                        <td>
                                            <asp:Label ID="lblerrorsalary" runat="server" CssClass="errLable1" Visible="False">Please select month !</asp:Label></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td colspan="2">
                                            <asp:Label ID="lblerroryear" runat="server" CssClass="errLable1" Visible="False" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddltypelist" runat="server">
                                                <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                                <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Month</asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlmonthList" runat="server">
                                                <asp:ListItem Value="0">Choose  Month</asp:ListItem>
                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Education Year"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddleduyearlist" runat="server">
                                                <asp:ListItem>Choose Year</asp:ListItem>
                                                <asp:ListItem>2001 - 2002</asp:ListItem>
                                                <asp:ListItem>2002 - 2003</asp:ListItem>
                                                <asp:ListItem>2003 - 2004</asp:ListItem>
                                                <asp:ListItem>2004 - 2005</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table style="margin-left: 20px">
                                    <tr>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnSearchSarlary" runat="server" Text="Search" OnClick="btnSearchSarlary_Click" /></td>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnExportSalary" runat="server" Text="Export File" Enabled="False" OnClick="ExportToExcel" /></td>
                                        <td>
                                            <asp:Button ID="btnViewExcel" runat="server" Text="Open File" CssClass="btn" OnClick="btnViewExcel_Click" Enabled="False" /></td>
                                        <td>
                                            <asp:Button ID="btnMarkSave" runat="server" Text="Salary Save & Show" CssClass="btn" OnClick="BtnSalarySave_Click" Enabled="False" /></td>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:Label ID="lblsalarybtnclick" CssClass="errLabel" ForeColor="Blue" runat="server" /></td>
                                    </tr>
                                </table>
                                <br />
                                <div class="gridDiv">
                                    <asp:GridView ID="gvsalarylist" runat="server" CssClass="gridview" AutoGenerateColumns="false" AllowPaging="True" GridLines="None"
                                        PageSize="6" ShowHeaderWhenEmpty="true" OnPageIndexChanging="gvsalarylist_PageIndexChanging">
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
                                            <asp:BoundField DataField="SALARY_ID" HeaderText="Salary Id" />
                                            <asp:BoundField DataField="YEAR" HeaderText="Year" />
                                            <asp:BoundField DataField="MONTH" HeaderText="Month" />
                                            <asp:BoundField DataField="STAFF_ID" HeaderText="Staff Id" />
                                            <asp:BoundField DataField="LEAVE_TIMES" HeaderText="Leave Times" />
                                            <asp:BoundField DataField="LEAVE_AMOUNT" HeaderText="Leave Amount" />
                                             <asp:BoundField DataField="LATE_TIMES" HeaderText="Late Times" />
                                            <asp:BoundField DataField="LATE_AMOUNT" HeaderText="Late Amount" />
                                            <asp:BoundField DataField="OT_AMOUNT" HeaderText="OT Amount" />
                                             <asp:BoundField DataField="SALARY_AMOUNT" HeaderText="Salary" />
                                             <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDetail" runat="server" Text="Detail" CommandName="DetailCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
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

