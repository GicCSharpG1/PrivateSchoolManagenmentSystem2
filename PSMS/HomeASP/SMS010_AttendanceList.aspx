<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS010_AttendanceList.aspx.cs" Inherits="HomeASP.SMS010" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Attendance List</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/jquery-ui.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>

    <script type="text/javascript">
        function isOneorRound() {
            if (document.getElementById('ShDay').checked) {
                document.getElementById('lblDay').style.display = 'block';
                document.getElementById('dpDay').style.display = 'block';

                document.getElementById('lbMon').style.display = 'none';
                document.getElementById('ddlMonth').style.display = 'none';
            }
            else {
                document.getElementById('lbMon').style.display = 'block';
                document.getElementById('ddlMonth').style.display = 'block';

                document.getElementById('lblDay').style.display = 'none';
                document.getElementById('dpDay').style.display = 'none';
            }
        }
</script>

    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>

<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            
            <!-- #include file="~/HtmlPages/UserHeader.html" -->
           
            <!-- header ends -->

            <!-- content begins -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                <h2>Attendance List</h2>
                                <table>
                                    <tr>
                                        <td class="auto-style1"><span style="margin-left: 2em"></span></td>
                                        <td class="auto-style1">
                                            <asp:RadioButton runat="server" ID="ShDay" GroupName="DM" Text="Show Day" onclick="isOneorRound()" Font-Size="Medium"/></td>
                                        <td class="auto-style1"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style1">
                                            <asp:RadioButton runat="server" ID="ShMonth" GroupName="DM" Text="Show Month" onclick="isOneorRound()" Font-Size="Medium"/></td>
                                        <td class="auto-style1"><span style="margin-left: 2em"></span></td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lbEduYe" runat="server" Text="Education Year" CssClass="label" /></td>
                                        <td class="auto-style1"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlEduyr" CssClass="dropdownlist" runat="server">
                                                <asp:ListItem Text="2016 - 2017" Value="2016 - 2017" />
                                                <asp:ListItem Text="2017 - 2018" Value="2017 - 2018" />
                                                <asp:ListItem Text="2018 - 2019" Value="2018 - 2019" />
                                                <asp:ListItem Text="2019 - 2020" Value="2019 - 2020" />
                                                <asp:ListItem Text="2020 - 2021" Value="2020 - 2021" />
                                                <asp:ListItem Text="2021 - 2022" Value="2021 - 2022" />
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1"><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="lblDay" runat="server" Text="Day *" CssClass="label" />
                                        </td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox CssClass="datepicker textbox" ID="dpDay" Style="color: black; margin-left: 0px" runat="server" /></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="lbStudId" runat="server" Text="Student Id" CssClass="label" />
                                        </td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txtStudId" Style="color: black; margin-left: 0px" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1"><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="lbMon" runat="server" Text="Month*" CssClass="label" />
                                        </td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="true" CssClass="dropdownlist" OnSelectedIndexChanged="chooseMonthYear" AutoPostBack="true">
                                                <Items>
                                                    <asp:ListItem Text="Select Month" Value="" />
                                                    <asp:ListItem Text="January" Value="01" />
                                                    <asp:ListItem Text="Feburay" Value="02" />
                                                    <asp:ListItem Text="March" Value="03" />
                                                    <asp:ListItem Text="April" Value="04" />
                                                    <asp:ListItem Text="May" Value="05" />
                                                    <asp:ListItem Text="June" Value="06" />
                                                    <asp:ListItem Text="July" Value="07" />
                                                    <asp:ListItem Text="August" Value="08" />
                                                    <asp:ListItem Text="Semptember" Value="09" />
                                                    <asp:ListItem Text="October" Value="10" />
                                                    <asp:ListItem Text="novenber" Value="11" />
                                                    <asp:ListItem Text="December" Value="12" />
                                                </Items>
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Student Name*" CssClass="label" />
                                        </td>
                                        <td><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txtStuName" Style="color: black; margin-left: 0px" runat="server" /></td>
                                    </tr>
                                </table>

                                <div style="float: left; margin-bottom: 15px">
                                    <asp:Label ID="errSer" runat="server" ForeColor="Red" CssClass="errLabel"></asp:Label>
                                </div>
                                <div style="float: right; margin-bottom: 15px">
                                    <asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="Search" Style="margin-right: 35px" OnClick="btnSearch_Click" Width="76px" />
                                    <asp:Button ID="btnShoAll" CssClass="btn" runat="server" Text="Show All" Style="margin-right: 35px" OnClick="btnShoAll_Click" />
                                    <asp:Button ID="btnClear" CssClass="btn" runat="server" Text="Clear" OnClick="btnClear_Click" Style="margin-right: 25px" />
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="gvAttendanceList" AutoGenerateColumns="False" runat="server" CssClass="gridview" AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." OnPageIndexChanging="gvAttendance_PageIndexChanging">
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
                                            <%--<asp:BoundField HeaderText="Year"
                                                DataField="EDU_YEAR"
                                                SortExpression="EDU_YEAR"></asp:BoundField>--%>
                                            <%--<asp:BoundField HeaderText="Student ID"
                                                DataField="STUDENT_ID"
                                                SortExpression="STUDENT_ID"></asp:BoundField>--%>
                                            <%--<asp:BoundField HeaderText="Attendance ID"
                                                DataField="ATTENDANCE_ID"
                                                SortExpression="ATTENDANCE_ID"></asp:BoundField>--%>
                                            <asp:BoundField HeaderText="Date"
                                                DataField="ATTENDANCE_DATE"
                                                SortExpression="ATTENDANCE_DATE"></asp:BoundField>
                                            <asp:BoundField HeaderText="Morning"
                                                DataField="MORNING"
                                                SortExpression="MORNING"></asp:BoundField>
                                            <asp:BoundField HeaderText="Evening"
                                                DataField="EVENING"
                                                SortExpression="EVENING"></asp:BoundField>
                                            <%--<asp:BoundField HeaderText="Remark"
                                                DataField="REMARK"
                                                SortExpression="REMARK"></asp:BoundField>--%>
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
