﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0037_SalaryCalculationDisplay.aspx.cs" Inherits="HomeASP.SM0037_SalaryCalculationDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Salary Calculation</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/classtimetable.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
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
                                <h2>Salary Display</h2>
                                <table id="table_style">
                                    <tr>
                                        <td colspan="3"></td>
                                        <td>
                                            <asp:Label ID="lblerrorsalary" runat="server" CssClass="errlable1" Visible="False">Please select month !</asp:Label></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td colspan="2">
                                            <asp:Label ID="lblerroryear" runat="server" CssClass="errlable1" Visible="False" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddltypelist" runat="server">
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
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="EDU Year"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="education" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                                <asp:ListItem>Select Education Year</asp:ListItem>
                                                <asp:ListItem>2011 - 2012</asp:ListItem>
                                                <asp:ListItem>2012 - 2013</asp:ListItem>
                                                <asp:ListItem>2013 - 2014</asp:ListItem>
                                                <asp:ListItem>2014 - 2015</asp:ListItem>
                                                <asp:ListItem>2015 - 2016</asp:ListItem>
                                                <asp:ListItem>2016 - 2017</asp:ListItem>
                                                <asp:ListItem>2017 - 2018</asp:ListItem>
                                                <asp:ListItem>2018 - 2019</asp:ListItem>
                                                <asp:ListItem>2019 - 2020</asp:ListItem>
                                                <asp:ListItem>2020 - 2021</asp:ListItem>
                                                <asp:ListItem>2021 - 2022</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnSearchSarlary" runat="server" Text="Search" OnClick="btnSearchSarlary_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblsalarybtnclick" CssClass="errlabel" runat="server" /></td>
                                    </tr>
                                </table>
                                <br />
                                <asp:GridView ID="gvsalarylist" runat="server" CssClass="gridview" AutoGenerateColumns="false" AllowPaging="True" GridLines="None"
                                        PageSize="6" ShowHeaderWhenEmpty="true">
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
                                        <asp:BoundField DataField="SALARY_ID" HeaderText="SalaryId" />
                                        <asp:BoundField DataField="STAFF_ID" HeaderText="Name" />
                                        <asp:BoundField DataField="LEAVE_TIMES" HeaderText="Leave times" />
                                        <asp:BoundField DataField="LEAVE_AMOUNT" HeaderText="Leave Deduction" />
                                        <asp:BoundField DataField="LATE_TIMES" HeaderText="Late times" />
                                        <asp:BoundField DataField="LEAVE_AMOUNT" HeaderText="Late Deduction" />
                                        <asp:BoundField DataField="OT_AMOUNT" HeaderText="OT Pay" />
                                        <asp:BoundField DataField="SALARY_AMOUNT" HeaderText="TotalSalary" />
                                        <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                    </Columns>
                                </asp:GridView>
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

