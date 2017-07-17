<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS022_ClassTimetableDisplay.aspx.cs" Inherits="HomeASP.SMS022" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS ClassTimeTable Display</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/classtimetable.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link rel="stylesheet" href="styles/jquery-ui.css">
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".textbox").datepicker();
        });
    </script>
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">
            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <!-- header ends -->

            <!-- content begin -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                <h2>Teacher Timetable</h2>
                                <table id="table_style">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="errTeacherSearch" runat="server" Text=" * Please enter date or select Teacher !" class="errlable1" Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <label class="label">Date</label></td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txtdate" runat="server" AutoPostBack="true" /></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td class="td_width">
                                            <asp:Label ID="lbteacher" runat="server" Text="Teacher" class="label"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlteacherlist" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList></td>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="btnteacher_Click" CssClass="btn" /></td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <asp:GridView ID="gvresultlist" runat="server" CssClass="gridview" CellPadding="4" EmptyDataText="There is no record." ShowHeaderWhenEmpty="True" GridLines="None" ForeColor="#333333" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="White" />
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
                                    <Columns>
                                        <asp:BoundField HeaderText="GRADE"
                                            DataField="GRADE_ID"
                                            SortExpression="GRADE_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="DATE"
                                            DataField="DAY"
                                            SortExpression="DAY"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 1"
                                            DataField="PERIOD1"
                                            SortExpression="PERIOD1"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 2"
                                            DataField="PERIOD2"
                                            SortExpression="PERIOD2"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 3"
                                            DataField="PERIOD3"
                                            SortExpression="PERIOD3"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 4"
                                            DataField="PERIOD4"
                                            SortExpression="PERIOD4"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 5"
                                            DataField="PERIOD5"
                                            SortExpression="PERIOD5"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 6"
                                            DataField="PERIOD6"
                                            SortExpression="PERIOD6"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 7"
                                            DataField="PERIOD7"
                                            SortExpression="PERIOD7"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <br />
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
            <!-- #include file="~/HtmlPages/Footer.html" -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>

