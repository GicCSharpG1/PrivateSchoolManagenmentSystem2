<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS006_StudentEntry.aspx.cs" Inherits="HomeASP.SMS006_StudentEntry" %>

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
                                                <asp:Label ID="Label1" CssClass="label" runat="server">Education Year</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlresyearlist" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                    <asp:ListItem>Choose year</asp:ListItem>
                                                    <asp:ListItem>2010 - 2011</asp:ListItem>
                                                    <asp:ListItem>2011 - 2012</asp:ListItem>
                                                    <asp:ListItem>2012 - 2013</asp:ListItem>
                                                    <asp:ListItem>2013 - 2014</asp:ListItem>
                                                    <asp:ListItem>2014 - 2015</asp:ListItem>
                                                    <asp:ListItem>2015 - 2016</asp:ListItem>
                                                    <asp:ListItem>2016 - 2017</asp:ListItem>
                                                    <asp:ListItem>2017 - 2018</asp:ListItem>
                                                    <asp:ListItem>2018 - 2019</asp:ListItem>
                                                    <asp:ListItem>2019 - 2020</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td>
                                                <asp:Label ID="Label5" CssClass="label" runat="server">Month</asp:Label></td>
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
                                                <asp:Label ID="Label2" CssClass="label" runat="server">Grade</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlgradeList" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                            <td><span style="margin-left: 4em;"></span></td>
                                            <td>
                                                <asp:Label ID="Label3" CssClass="label" runat="server">Room</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlroomList" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSearchRes" runat="server" Text="Search" CssClass="btn" OnClick="btnSearchRes_Click"/> </td>

                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblmsg" CssClass="label" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>      
                                <br />
                               <%-- <div id="Div3" runat="server">--%>
                                    <asp:GridView ID="gvstdResult" runat="server" CssClass="gridview" AutoGenerateColumns="false" AllowPaging="True" GridLines="None"
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
                                        <asp:BoundField DataField="STUDENT_ID" HeaderText="ID" />
                                       <asp:BoundField DataField="ROLL_NO" HeaderText="RollNo" />
                                        <asp:BoundField DataField="STUDENT_NAME" HeaderText="Name" />

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject1" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject2" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject3" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject4" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject5" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubject6" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                       <%-- <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click"/>
                               <%-- </div>--%>
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
