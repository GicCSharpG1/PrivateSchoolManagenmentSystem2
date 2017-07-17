<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0036_StudentTimeTabledisplay.aspx.cs" Inherits="HomeASP.SM_StudentTimeTabledisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student TimeTable Display</title>
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
            <% if(Session["LOGIN_USER_LEVEL"].ToString().Equals("Admin")){ %>
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <% } 
               else{ %>
            <!-- #include file="~/HtmlPages/UserHeader.html" -->
            <% } %>
            <!-- header ends -->

            <!-- content begin -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="stutimedisplay_bot" style="background-image: url(Images/form_bg.jpg)">

                        <div class="right_b" style="height: 360px; width: 600px;">
                            <form id="timetable" runat="server">
                                <h2>Class Timetable Display</h2>
                                <table id="table_style">
                                    <tr>
                                        <td colspan="2" style="color:red;visibility:visible;" >
                                            <asp:Label ID="errSelectGrade" runat="server" CssClass="errlabel2" Text="Please select Grade !" Visible="False"></asp:Label></td>
                                        <td><span style="margin-left: 3em"></span></td>
                                        <td colspan="2" style="color:red;visibility:visible;" >
                                            <asp:Label ID="errSelectRoom" runat="server" CssClass="errlabel2" Text="Please select Room !" Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="tdisplay_width">
                                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Grade"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlstugradelist" runat="server" Height="30px" Width="160px" ForeColor="Black">
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 3em"></span></td>
                                        <td class="tdisplay_width">
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Room"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlstuclasslist" runat="server" Height="30px" Width="160px" ForeColor="Black">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn" /></td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Panel ID="Panelteacher" runat="server" Visible="False">
                                    <table style="margin-left: 10px;">
                                        <tr>
                                            <td class="stutd_width">
                                                <asp:Label ID="Label2" CssClass="label" runat="server" Text="Room Teacher"></asp:Label></td>
                                            <td><span style="margin-left: 3em"></span></td>
                                            <td>
                                                <asp:Label ID="lblroomteachname" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <%--<asp:Label ID="lblNodata" runat="server" Font-Size="Medium" ForeColor="White"></asp:Label>--%>
                                <br />
                                <asp:GridView ID="gvStuTimetable" runat="server" CellPadding="4" AutoGenerateColumns="False" PageSize="7" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record.">
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
                                        <asp:BoundField HeaderText="PERIOD"
                                            DataField="TIMETABLE_TIME"
                                            SortExpression="TIMETABLE_TIME"></asp:BoundField>
                                        <asp:BoundField HeaderText="MONDAY"
                                            DataField="MONDAY"
                                            SortExpression="MONDAY" ItemStyle-Width="142px">
                                            <ItemStyle Width="142px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="TUESDAY"
                                            DataField="TUESDAY"
                                            SortExpression="TUESDAY" ItemStyle-Width="142px">
                                            <ItemStyle Width="142px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="WEDNESDAY"
                                            DataField="WEDNESDAY"
                                            SortExpression="WEDNESDAY" ItemStyle-Width="142px">
                                            <ItemStyle Width="142px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="THURSDAY"
                                            DataField="THURSDAY"
                                            SortExpression="THURSDAY" ItemStyle-Width="142px">
                                            <ItemStyle Width="142px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="FRIDAY"
                                            DataField="FRIDAY"
                                            SortExpression="FRIDAY" ItemStyle-Width="142px">
                                            <ItemStyle Width="142px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="ID"
                                            DataField="ID"
                                            SortExpression="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>

                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </form>
                        </div>
                    </div>
                    <br />
                </div>
                <div style="clear: both">
                    <img src="images/spaser.gif" alt="" width="1" height="1" />
                </div>
                <div class="bot"></div>
            </div>
            <!-- content ends -->

            <!-- footer begins -->
            <!-- #include file="~/HtmlPages/Footer.html -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>


