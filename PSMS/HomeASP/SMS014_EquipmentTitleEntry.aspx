 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS014_EquipmentTitleEntry.aspx.cs" Inherits="HomeASP.SMS014" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Equipment Title Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <!-- header ends -->

            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 600px; width: 965px;">
                            <div id="container_demo">
                                <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                                <a class="hiddenanchor" id="toregister"></a>
                                <a class="hiddenanchor" id="tologin"></a>
                                <div id="wrapper">
                                    <form id="login" runat="server" style="height: 500px; width: 930px; padding: 20px 15px 15px 15px; margin: 50px 0px 0px 0px">
                                        <h2>Equipment Title Entry</h2>
                                        <div style="float: left; margin-bottom: 25px; margin-left: 20px">
                                            <table style="margin-bottom: 15px;">
                                                <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="LabEquipId" CssClass="label" runat="server">ID*</asp:Label></td>
                                                    <td><span style="margin-left: 1em; color: black" /><span style="margin-left: 1em" /></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtEquipID" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errYear" ControlToValidate="TxtEquipID" ErrorMessage="Please enter ID !!" ForeColor="Red" /></td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabEquipName" CssClass="label" runat="server">Name*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtEqpName" CssClass="textbox" runat="server" ForeColor="Black" /></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="SaveConfirm" ControlToValidate="TxtEqpName" ErrorMessage="Please enter Equipment's name !!" ForeColor="Red" /></td>
                                                </tr>
                                                <tr style="height: 15px"></tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabYear" CssClass="label" runat="server">Year*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:DropDownList ID="CoboYear" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                            <asp:ListItem></asp:ListItem>
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
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="SaveConfirm" ControlToValidate="TxtEqpName" ErrorMessage="Please choose Education Year !!" ForeColor="Red" /></td>
                                                    <td><asp:Label ID="LabelID" CssClass="label" Visible="false" runat="server">ID</asp:Label></td>
                                                </tr>
                                            </table>
                                            <div style="margin-left: 30px;">
                                                <asp:Button ID="BtnEquipSave" ValidationGroup="SaveConfirm" Text="Save" CssClass="btn" runat="server" OnClick="save_Click" />
                                                <asp:Button ID="btnConfirm" ValidationGroup="SaveConfirm" Text="Confirm" CssClass="btn" Style="margin-left: 15px" runat="server" OnClick="confirm_Click" />
                                            </div>
                                            <br />
                                            <asp:Label runat="server" ID="alertMsg" Font-Size="Medium" style="margin-left:10px;color:red"></asp:Label>
                                        </div>
                                        <div id="Div2" style="margin-bottom: 25px" runat="server">
                                            <asp:GridView ID="eqpMstList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No expense entry!!" AllowPaging="True" PageSize="5" OnPageIndexChanging="EqpList_PageIndexChanging" ReadOnly="false" CssClass="gridview1" OnRowCommand="expList_RowCommand" runat="server" Width="100%" CellPadding="6" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" Style="margin-top: 15px">
                                                <AlternatingRowStyle Wrap="False" BackColor="White" />
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
                                                    <asp:BoundField DataField="EDU_YEAR" HeaderText="Education Year" />
                                                    <asp:BoundField DataField="EQUIPMENT_ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="EQUIPMENT_NAME" HeaderText="Name" />
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
    </div>
</body>
</html>

