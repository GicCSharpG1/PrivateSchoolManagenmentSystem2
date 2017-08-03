<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS029_ExpenseDetail.aspx.cs" Inherits="HomeASP.SMS029" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Expense Detail</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <!-- header ends -->

            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg);height:495px">
                        <div class="right_b" style="height: 600px; width: 965px;">
                            <div id="container_demo">
                                <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                                <a class="hiddenanchor" id="toregister"></a>
                                <a class="hiddenanchor" id="tologin"></a>
                                <div id="wrapper">
                                    <form id="login" runat="server" style="height: 440px; width: 930px; padding: 20px 15px 15px 15px; margin: 10px 0px 0px 0px">
                                        <h2>Expense Detail</h2>
                                        <div style="margin-bottom: 20px" class="spaceUnder">
                                            <table id="cashTbl" style="border-collapse:separate; border-spacing:0 10px;" runat="server">
                                                <tr class="spaceUnder">
                                                    <td>
                                                        <asp:Label ID="LabYear" CssClass="label" runat="server">Year*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:DropDownList ID="CoboYear" CssClass="dropdownlist" Style="margin-left: 0px" runat="server" AutoPostBack="true">
                                                            <asp:ListItem>Choose Education Year</asp:ListItem>
                                                            <asp:ListItem>2010-2011</asp:ListItem>
                                                            <asp:ListItem>2011-2012</asp:ListItem>
                                                            <asp:ListItem>2012-2013</asp:ListItem>
                                                            <asp:ListItem>2013-2014</asp:ListItem>
                                                            <asp:ListItem>2014-2015</asp:ListItem>
                                                            <asp:ListItem>2015-2016</asp:ListItem>
                                                            <asp:ListItem>2016-2017</asp:ListItem>
                                                            <asp:ListItem>2017-2018</asp:ListItem>
                                                            <asp:ListItem>2018-2019</asp:ListItem>
                                                            <asp:ListItem>2019-2020</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                         <asp:Label ID="ErroRYear"  ForeColor="Red" runat="server">Choose Education Year!</asp:Label>
                                                        <span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="LblExpId" CssClass="label" runat="server">Expance ID</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="txtExpIDVal" CssClass="textbox" Style="margin-left: 0px" runat="server" ForeColor="Black"></asp:TextBox></td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="lbYear" runat="server"></asp:Label></td>

                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="LbExpID" Style="color: black" runat="server" /></td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabExpSubTitle" CssClass="label" runat="server">Description </asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtExpSubTitle" CssClass="textbox" Style="margin-left: 0px" runat="server" ForeColor="Black"></asp:TextBox></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                       
                                                        <asp:Label ID="LblAmt" CssClass="label" runat="server">Amount</asp:Label>
                                                         
                                                    </td>
                                                    <td>
                                                     
                                                        <span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtAmt" CssClass="textbox" Style="margin-left: 0px" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Label ID="errNum" runat="server" Style="color: red; margin-left: 5px"></asp:Label></td>
                                                </tr>
                                                <%--<tr class="spaceUnder">
                                                    <td>
                                                        <asp:Label ID="Label1" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errTT" ValidationGroup="saveCon" ControlToValidate="TxtExpSubTitle" ErrorMessage="Please enter Description" ForeColor="Red" /></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="Label2" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errAmm" ValidationGroup="saveCon" ControlToValidate="TxtAmt" ErrorMessage="Please enter the amount !!" ForeColor="Red" /></td>
                                                </tr>--%>
                                            </table>
                                        </div>
                                        <div id="Div2" style="height: 270px" runat="server">
                                            <asp:GridView ID="expDetList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record." AllowPaging="true" PageSize="5" OnRowCommand="gv_RowCommand" OnPageIndexChanging="expDetList_PageIndexChanging" CssClass="gridview1" runat="server" Width="100%" CellPadding="6" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" ShowFooter="True" OnSelectedIndexChanged="expDetList_SelectedIndexChanged">
                                                <AlternatingRowStyle Wrap="False" BackColor="White" />
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
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="Id" />
                                                    <asp:BoundField DataField="EXP_SUB_TITLE" HeaderText="Sub Title" />
                                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                                                    <asp:BoundField DataField="CR_DT_TM" HeaderText="" Visible="false" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandName="EditCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
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
                                        <div>
                                            <asp:Label ID="errSMS" CssClass="label" runat="server"></asp:Label></div>
                                        <div style="margin-left: 450px;">
                                            <asp:Button ID="BtnPay" CssClass="btn" style="margin-right:15px;" ValidationGroup="saveCon" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                            <asp:Button ID="BtnConfirm" CssClass="btn" ValidationGroup="saveCon" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />
                                        </div>
                                        <div style="float: left">
                                            <asp:Label ID="temp" Font-Size="Medium" ForeColor="Red" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </form>
                                </div>
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

