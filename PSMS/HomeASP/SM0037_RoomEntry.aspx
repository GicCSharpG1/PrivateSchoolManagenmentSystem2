<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0037_RoomEntry.aspx.cs" Inherits="HomeASP.SM0037_RoomEntry" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Room Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <%--<link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />--%>
    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>

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
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                <h2>Room Entry</h2>
                                <div style="float: left; margin-bottom: 25px; margin-left: 20px">
                                    <table style="margin-bottom: 15px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabEquipName" CssClass="label" runat="server">Room Name*</asp:Label></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:TextBox ID="TxtRoomName" CssClass="textbox" runat="server" ForeColor="Black" /></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="SaveConfirm" ControlToValidate="TxtRoomName" ErrorMessage="Please enter Room's name !!" ForeColor="Red" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabYear" CssClass="label" runat="server">Education Year*</asp:Label></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoomyearlist" CssClass="dropdownlist" runat="server" AutoPostBack="true">
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
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="SaveConfirm" ControlToValidate="ddlRoomyearlist" ErrorMessage="Please choose Education Year !!" ForeColor="Red" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnRoomSave" Text="Save" CssClass="btn" runat="server" OnClick="BtnRoomSave_Click" /></td>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="btnCancel" Text="Cancel" CssClass="btn" runat="server" OnClick="btnCancel_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="alertMsg" Font-Size="Medium" Style="margin-left: 10px; color: red"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Div2" style="margin-bottom: 25px" runat="server">
                                    <asp:GridView ID="gvRoomList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record." AllowPaging="True" PageSize="5" OnPageIndexChanging="gvRoomList_PageIndexChanging" ReadOnly="false" CssClass="gridview1" OnRowCommand="gvRoomList_RowCommand" runat="server" Width="100%" CellPadding="6" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" Style="margin-top: 15px">
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
                                            <asp:BoundField DataField="ROOM_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="ROOM_NAME" HeaderText="Name" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnRoomUpdate" runat="server" Text="Edit" CommandName="EditCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnRoomDelete" runat="server" Text="Delete" CommandName="DeleteCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
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


