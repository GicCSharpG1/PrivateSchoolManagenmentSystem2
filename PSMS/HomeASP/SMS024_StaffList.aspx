<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS024_StaffList.aspx.cs" Inherits="HomeASP.SMS024" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Staff List</title>
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

            <!-- content ends -->
           <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                    <h2>Staff List</h2>
                                    <table style="font: 16px Verdana, Helveticaall-petite-caps; color: #074959; margin: 30px 0px 20px 15px">
                                        <tr>

                                            <td>&nbsp;&nbsp;Name &nbsp;</td>
                                            <td>

                                                <asp:TextBox ID="staffName" CssClass="textbox" Width="160px" Height="20px" runat="server"></asp:TextBox></td>

                                            <td style="width: 60px;"></td>

                                            <td>Staff ID &nbsp;</td>
                                            <td>&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="Staffid" runat="server" CssClass="textbox" Width="160px" Height="20px"></asp:TextBox>
                                            </td>

                                        </tr>

                                    </table>



                                    <asp:Label ID="errGrid" ForeColor="Red" Font-Size="Medium" runat="server"></asp:Label>

                                    <div style="padding-left: 20px; height: 270px">
                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CssClass="gridview" AllowPaging="True" PageSize="10" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." CellPadding="4" ForeColor="#333333" GridLines="None" Width="96%" OnPageIndexChanging="StaffList_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="White" />

                                            <Columns>
                                                <asp:TemplateField HeaderText=" No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EDU_YEAR" HeaderText="Year" Visible="false" />
                                                <asp:BoundField DataField="STAFF_ID" HeaderText="Staff ID" />
                                                <asp:BoundField DataField="POSITION_ID" HeaderText="Position" Visible="false" />
                                                <asp:BoundField DataField="STAFF_NAME" HeaderText="Staff Name" />
                                                <asp:BoundField DataField="GENDER" HeaderText="Gender" Visible="false" />
                                                <asp:BoundField DataField="PHOTO_PATH" HeaderText="Image_Path" Visible="false" />
                                                <asp:BoundField DataField="POSITION_ID" HeaderText="Position Name" />
                                                <asp:BoundField DataField="EDUCATION" HeaderText="Education" />
                                                <asp:BoundField DataField="PHONE" HeaderText="Phone" />

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnStaffUpdate" runat="server" Text="Edit" CommandName='<%# Eval("STAFF_ID") %>' OnClick="btnStaffUpdate_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnStaffDetailSelect" runat="server" Text="Detail" CommandName='<%# Eval("STAFF_ID") %>' OnClick="btnStaffDetail_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--  <asp:LinkButton ID="btnStaffDelete" runat="server" Text="Delete" CommandName='<%# Eval("STAFF_ID") %>' OnClick="btnStaffDelete_Click"></asp:LinkButton>--%>
                                                        <asp:LinkButton ID="btnStaffDelete" runat="server" Text="Delete" CommandName='<%# Eval("STAFF_ID") %>' OnClientClick="return confirm('Are you sure you want to delete ?');"
                                                            OnClick="btnStaffDelete_Click"></asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#D2EEEA" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />



                                        </asp:GridView>
                                    </div>
                                    <div>

                                        <asp:Label ID="errSearch" ForeColor="Red" Font-Size="15px" Style="float: left; margin-left: 22px;" runat="server"></asp:Label>
                                    </div>
                                    <table style="margin-left: 450px;">

                                        <tr>
                                            <td>
                                                <asp:Button ID="Clear" runat="server" Text="Clear" CssClass="btn" OnClick="Clear_Click" /></td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:Button ID="search" runat="server" Text="Search" CssClass="btn" OnClick="search_Click" /></td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:Button ID="showall" runat="server" Text="Show All" CssClass="btn" OnClick="btnShowAll_Click" /></td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <asp:Button ID="previous" runat="server" Text="New Staff Entry" CssClass="btn" OnClick="btnPrevious_Click1" Width="135px" /></td>
                                        </tr>


                                    </table>
                                </form>
                            </div>
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
