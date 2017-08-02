<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0037_SalaryCalculationDisplay.aspx.cs" Inherits="HomeASP.SM0037_SalaryCalculationDisplay" %>

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
                                <table style="margin-left: 20px">
                                    <tr>
                                        <%--<td>
                                            <asp:Label ID="lbStaffType" CssClass="label" runat="server">Staff Type*</asp:Label></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="comboPos" AutoPostBack="true" AppendDataBoundItems="true" runat="server">
                                                <asp:ListItem Text="--Select One ---" Value="       ">    </asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 2em"></span></td>--%>
                                        <td class="td_width">
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Month*</asp:Label></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlMonth" runat="server">
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
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Education Year*"></asp:Label></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlEducation" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                                <asp:ListItem>Select Year</asp:ListItem>
                                                <asp:ListItem>2017 - 2018</asp:ListItem>
                                                <asp:ListItem>2018 - 2019</asp:ListItem>
                                                <asp:ListItem>2019 - 2020</asp:ListItem>
                                                <asp:ListItem>2020 - 2021</asp:ListItem>
                                                <asp:ListItem>2021 - 2022</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="lblErroSms" runat="server" CssClass="errLabel" Visible="False" Text="Please fill required data !!" /></td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnSearchSarlary" runat="server" Text="Search" OnClick="btnSearchSarlary_Click" /></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnShowAllSalary" runat="server" Text="Show All" OnClick="btnShowAllSalary_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblsalarybtnclick" CssClass="errlabel" runat="server" /></td>
                                    </tr>
                                </table>
                                <br />
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
                                        <asp:BoundField DataField="SALARY_ID" HeaderText="SalaryId" />
                                        <asp:BoundField DataField="STAFF_ID" HeaderText="Name" />
                                        <asp:TemplateField HeaderText="Leave<br>Time">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave<br>Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Late<br>Times">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Late<br>Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OT<br>Amount">
                                            <HeaderStyle />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Salary">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Width="85px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                                <asp:Label ID="errSMS" Font-Size="Small" ForeColor="Red" runat="server"></asp:Label>
                                <%--<div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbLeT" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtLeT" Style="color: black; margin-left: 0px" runat="server" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="lbLeAm" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtLeAm" Style="color: black; margin-left: 0px" runat="server" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="lbLaT" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtLaT" Style="color: black; margin-left: 0px" runat="server" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="lbLaAm" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtLaAm" Style="color: black; margin-left: 0px" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbOT" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtOT" Style="color: black; margin-left: 0px" runat="server" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="lbSa" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtSa" Style="color: black; margin-left: 0px" runat="server" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="lbRem" CssClass="label" runat="server" Text="Leave Time" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="textbox" ID="txtRem" Style="color: black; margin-left: 0px" runat="server" /></td>
                                        </tr>
                                    </table>
                                </div>--%>
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


