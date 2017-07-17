<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS001_UserCreate.aspx.cs" Inherits="HomeASP.SMS001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS User Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
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
                                <h2>User Entry</h2>
                                <table>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="uname" runat="server" Text="UserName*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="txtUname" runat="server" CssClass="textbox"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUname" ErrorMessage="Please Enter User Name!" ForeColor="Red" ValidationGroup="group1"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="password" runat="server" Text="Password*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                                            <input type="checkbox" onchange="document.getElementById('txtPassword').type = this.checked ? 'text' : 'password'">
                                            Show password
                                            <br />
                                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password!" ForeColor="Red" ValidationGroup="group1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="cpassword" runat="server" Text="Confirmed Password*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:TextBox TextMode="Password" ID="txtCpassword" runat="server" CssClass="textbox"></asp:TextBox>
                                            <input type="checkbox" onchange="document.getElementById('txtCpassword').type = this.checked ? 'text' : 'password'">
                                            Show password
                                            <br />                                            
                                            <asp:RequiredFieldValidator runat="server" ID="rfvCPassword" ControlToValidate="txtCpassword" ErrorMessage="Please Enter Confirm Password!" ForeColor="Red" ValidationGroup="group1"/>
                                            <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="txtPassword" controltocompare="txtCpassword" operator="Equal" type="String" errormessage="Password and Confirm Password are different!" ForeColor="Red" ValidationGroup="group1" />  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column">
                                            <asp:Label ID="level" runat="server" Text="User Level*" CssClass="label"></asp:Label>
                                        </td>
                                        <td class="column">
                                            <asp:DropDownList ID="ddlUserLevel" runat="server" DataTextField="User Level" CssClass="dropdownlist">
                                                <asp:ListItem>Select Level</asp:ListItem>
                                                <asp:ListItem>User</asp:ListItem>
                                                <asp:ListItem>Admin</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator runat="server" ID="rfvUserType" InitialValue="Select Level" ControlToValidate="ddlUserLevel" ErrorMessage="Please Choose User Type!" ForeColor="Red" ValidationGroup="group1"/>
                                        </td>
                                    </tr>
                                    </table>
                                <table>
                                    <tr>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnAdd" ValidationGroup="group1" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnUpdate" ValidationGroup="group1" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click" CausesValidation="false" />
                                        </td>
                                        <td class="column">
                                            <asp:Button class="btn" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errExist" Visible="false" ForeColor="Red" Text="Data Already Exists!" /><br />
                                <div class="table-responsive">
                                    <asp:GridView ID="GridViewUser" runat="server" AutoGenerateColumns="false" class="gridview" BorderColor="#1DA18C" AllowPaging="True" PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="There is no data" OnPageIndexChanging="GridViewUser_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField HeaderText="ID"
                                                DataField="USER_ID"
                                                SortExpression="USER_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="User Name"
                                                DataField="USER_NAME"
                                                SortExpression="USER_NAME"></asp:BoundField>
                                            <asp:BoundField HeaderText="User Level"
                                                DataField="USER_TYPE"
                                                SortExpression="USER_TYPE"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnUserUpdate" runat="server" Text="Edit" CommandName='<%# Eval("USER_ID") %>' OnClick="btnEdit_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnUserDelete" runat="server" Text="Delete" CommandName='<%# Eval("USER_ID") %>' OnClick="btnDelete_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
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
