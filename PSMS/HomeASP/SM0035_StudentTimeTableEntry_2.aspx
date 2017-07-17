<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0035_StudentTimeTableEntry_2.aspx.cs" Inherits="HomeASP.SM_StudentTimeTableEntry_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student TimeTable Entry_2</title>
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
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <!-- header ends -->

            <div id="cmcontent">
                <div id="cmright">
                    <div class="stutimeentry_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 360px; width: 600px;">
                            <form id="timetable" runat="server">
                                <h2>Class Timetable Entry</h2>
                                <table id="table_style">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltimegrade" CssClass="label" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lbltimeroom" CssClass="label" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Period"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlperiodlist" runat="server">
                                                <asp:ListItem>Period 1</asp:ListItem>
                                                <asp:ListItem>Period 2</asp:ListItem>
                                                <asp:ListItem>Period 3</asp:ListItem>
                                                <asp:ListItem>Period 4</asp:ListItem>
                                                <asp:ListItem>Period 5</asp:ListItem>
                                                <asp:ListItem>Period 6</asp:ListItem>
                                                <asp:ListItem>Period 7</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>

                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="MON"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlmonsublist" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errmonlist" runat="server" Text="Please select subject !" CssClass="errlable1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="TUE"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddltuesublist" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errtuelist" runat="server" Text="Please select subject !" CssClass="errlable1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="WED"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlwedsublist" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errwedlist" runat="server" Text="Please select subject !" CssClass="errlable1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="THU"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlthusublist" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errthulist" runat="server" Text="Please select subject !" CssClass="errlable1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label6" CssClass="label" runat="server" Text="FRI"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlfrisublist" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errfrilist" runat="server" Text="Please select subject !" CssClass="errlable1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btntimedetailAdd" runat="server" OnClick="btntimedetailAdd_Click" Text="Save" CssClass="btn" /></td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" OnClick="btntimedetailcancel_Click" Text="Cancel" CssClass="btn" /></td>



                                    </tr>
                                </table>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;
                                <br />
                                <asp:GridView ID="gvtimedetail" runat="server" CellPadding="4" AutoGenerateColumns="False" GridLines="None"
                                    ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." AllowPaging="True" PageSize="4" OnPageIndexChanging="gvtimedetail_PageIndexChanging">
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
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnTimeDetailEdit" runat="server" Text="Edit" CommandName='<%# Eval("ID") %>' OnClick="btnTimeDetailUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnTimeDetailDelete" runat="server" Text="Delete" CommandName='<%# Eval("ID") %>' OnClick="btnTimeDetailDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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







