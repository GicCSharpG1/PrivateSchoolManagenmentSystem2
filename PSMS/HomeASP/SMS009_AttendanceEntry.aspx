<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS009_AttendanceEntry.aspx.cs" Inherits="HomeASP.SMS009" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Attendance Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/AttendanceStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/jquery-ui.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 612px;
        }
    </style>
</head>

<body style="background-image: url(Images/bg.jpg);">
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
                                <h2>Attendance Entry</h2>
                                <table style="border-collapse: separate; border-spacing: 0 10px; margin: 0px 10px 0px 15px">
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="year" runat="server" Text="Education Year*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="eduYearGrade" CssClass="dropdownlist" runat="server">
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
                                                <asp:ListItem Text="2021 - 2022" Value="2021 - 2022" />
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="grade" runat="server" Text="Grade*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="gradeList" runat="server" AppendDataBoundItems="true" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="room" runat="server" Text="Room*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="roomList" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="column">
                                            <asp:Label ID="date" runat="server" Text="Date" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox CssClass="datepicker textbox" ID="attendDate" runat="server" Enabled="false" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="errReqData" runat="server" CssClass="errLabel"></asp:Label>
                                <br />
                                <div class="table-responsive" style="padding: 10px 15px 10px 15px; height: 190px">
                                    <asp:GridView ID="gridViewAttendance" AutoGenerateColumns="false" runat="server" CssClass="gridview" BorderColor="#1DA18C" AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="There is no data" OnPageIndexChanging="gvAttendance_PageIndexChanging">
                                        <AlternatingRowStyle BackColor="White" />
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
                                        <Columns>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="STUDENT_ID"
                                                SortExpression="STUDENT_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Name"
                                                DataField="STUDENT_NAME"
                                                SortExpression="STUDENT_NAME"></asp:BoundField>
                                            <asp:BoundField HeaderText="Roll no"
                                                DataField="ROLL_NO"
                                                SortExpression="ROLL_NO"></asp:BoundField>
                                            <asp:TemplateField HeaderText="AM" ItemStyle-CssClass="template-checkbox">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="AM" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PM" ItemStyle-CssClass="template-checkbox">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="PM" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                                <table>
                                    <tr>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td><asp:Button class="btn" ID="btnCheckAM" runat="server" Text="Check(AM)" OnClick="btnCheckAllAM_Click" Width="100px" /></td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td><asp:Button class="btn" ID="btnCheckPM" runat="server" Text="Check(PM)" OnClick="btnCheckAllPM_Click" Width="115px" /></td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td><asp:Button class="btn" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Width="74px" /></td>
                                        </tr>
                                    </table>
                                    <div style="float:right">
                                        <asp:Label  ID="ShAll" runat="server" CssClass="linklb"><a href="SMS010_AttendanceList.aspx">Show Attendance List</a></asp:Label>
                                    </div>
                                    <div style="float:left">
                                        <asp:Label runat="server" ID="errSms" CssClass="errLabel" ForeColor="Red" Height="20px" />
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

