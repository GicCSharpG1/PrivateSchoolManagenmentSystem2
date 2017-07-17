<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS015_StudentCashInfo.aspx.cs" Inherits="HomeASP.SMS015" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student Cash Information</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

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
            <% if (Session["LOGIN_USER_LEVEL"].ToString().Equals("Admin"))
               { %>
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <% }
               else
               { %>
            <!-- #include file="~/HtmlPages/UserHeader.html" -->
            <% } %>
            <!-- header ends -->

            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 500px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 490px;">
                                <h2>Student Cash Information</h2>
                                <div style="float: left; width: 900px; margin: 0px 15px 10px 15px; padding: 0px 15px 0px 15px;">
                                    <table id="cashTbl" runat="server">
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabStudId" CssClass="label" Style="margin-left: 0px" runat="server">ID*</asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:TextBox ID="TxtStudID" CssClass="textbox" runat="server" Style="margin-left: 0px" ForeColor="Black"></asp:TextBox></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:Label ID="Label1" CssClass="label" Style="margin-left: 0px" runat="server">Name*</asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:TextBox ID="TxtStuName" CssClass="textbox" Style="margin-left: 0px" runat="server"></asp:TextBox></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:Label ID="LblDate" CssClass="label" Style="margin-left: 0px" runat="server"> Date*</asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:TextBox CssClass="datepicker textbox" ID="cashDate" Style="color: black; margin-left: 0px" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" CssClass="Lab-format" runat="server"></asp:Label>
                                            </td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="pay" ID="rfvgradeId" ControlToValidate="TxtStudID" ErrorMessage="Please Enter Student's ID!" ForeColor="Red" /></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:Label ID="Label3" CssClass="Lab-format" runat="server"></asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="pay" ID="errName" ControlToValidate="TxtStuName" ErrorMessage="Please enter student name!" ForeColor="Red" /></td>
                                            <td><span style="margin-left: 2em"></span></td>
                                            <td>
                                                <asp:Label ID="Label4" CssClass="Lab-format" runat="server"></asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="pay" ID="errDate" ControlToValidate="cashDate" ErrorMessage="Please chose the date!" ForeColor="Red" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabGrade" CssClass="label" Style="margin-left: 0px" runat="server">Grade*</asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:DropDownList ID="CoboGrade" CssClass="dropdownlist" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="CoboSelect_Change" runat="server">
                                                    <asp:ListItem Text="--Select One ---" Value="       ">    </asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:Label ID="LabYear" CssClass="label" Style="margin-left: 0px" runat="server">Year*</asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:DropDownList ID="CoboYear" CssClass="dropdownlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CoboSelect_Change" OnTextChanged="CoboSelect_Change">
                                                    <asp:ListItem>Select Education Year</asp:ListItem>
                                                    <asp:ListItem>2011 - 2012</asp:ListItem>
                                                    <asp:ListItem>2012 - 2013</asp:ListItem>
                                                    <asp:ListItem>2013 - 2014</asp:ListItem>
                                                    <asp:ListItem>2014 - 2015</asp:ListItem>
                                                    <asp:ListItem>2015 - 2016</asp:ListItem>
                                                    <asp:ListItem>2016 - 2017</asp:ListItem>
                                                    <asp:ListItem>2017 - 2018</asp:ListItem>
                                                    <asp:ListItem>2018 - 2019</asp:ListItem>
                                                    <asp:ListItem>2019 - 2020</asp:ListItem>
                                                    <asp:ListItem>2020 - 2021</asp:ListItem>
                                                    <asp:ListItem>2021 - 2022</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr class="spaceUnder">
                                            <td>
                                                <asp:Label ID="Label5" CssClass="Lab-format" runat="server"></asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="errGrade" ControlToValidate="CoboGrade" ErrorMessage="Please choose the grade!" ForeColor="Red" /></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:Label ID="Label7" CssClass="Lab-format" runat="server"></asp:Label></td>
                                            <td><span style="margin-left: 1em"></span></td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="errYear" ControlToValidate="CoboYear" ErrorMessage="Please choose the year!" ForeColor="Red" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label runat="server" ID="alert" Style="color: red; font-size: 15px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn" Style="float: right" OnClick="btnClear_Click" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="padding: 0px 0px 0px 15px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="payPannel" runat="server" CssClass="pa-Format" GroupingText="Payment">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" CssClass="label" runat="server">Cash Type</asp:Label>
                                                            </td>
                                                            <td><span style="margin-left: 1em; color: black" />:<span style="margin-left: 1em" /></td>
                                                            <td>
                                                                <asp:Label ID="LabCashTypeVal" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" CssClass="label" Visible="false" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black" /><span style="margin-left: 1em" /></td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" CssClass="errmsg-format"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabAccNo" CssClass="label" runat="server">Account No.</asp:Label></td>
                                                            <td><span style="margin-left: 1em"></span></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAccNoVal" CssClass="textbox" Style="margin-left: 0px" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" CssClass="Lab-format" Visible="false" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em"></span></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="pay" ID="errAccNo" ControlToValidate="txtAccNoVal" ErrorMessage="Please enter Your Account Number!" ForeColor="Red" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabAmount" CssClass="label" runat="server">Amount </asp:Label></td>
                                                            <td><span style="margin-left: 1em"></span></td>
                                                            <td>
                                                                <asp:TextBox ID="TxtAmountVal" CssClass="textbox" Style="margin-left: 0px" runat="server"></asp:TextBox><br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label11" CssClass="Lab-format" Visible="false" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em"></span></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="pay" ID="errAmt" ControlToValidate="TxtAmountVal" ErrorMessage="Please enter Amount!" ForeColor="Red" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label runat="server" ID="insertComp" Style="color: red; font-size: 15px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                    <asp:Button ID="BtnPay" runat="server" ValidationGroup="pay" Text="Pay" CssClass="btn" Style="float: right" OnClick="BtnPay_Click" />
                                                </asp:Panel>
                                            </td>
                                            <td><span style="margin-left: 3em" /></td>
                                            <td>
                                                <asp:Panel ID="Panel1" runat="server" CssClass="pa-Format" GroupingText="Cash Detail">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabTtMon" CssClass="label" runat="server">Months</asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black">:</span></td>
                                                            <td>
                                                                <asp:Label ID="LabMonVal" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label12" CssClass="label" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black"></span></td>
                                                            <td>
                                                                <asp:Label ID="Label13" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabKyat" CssClass="label" runat="server">Kyats/Month</asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black">:</span></td>
                                                            <td>
                                                                <asp:Label ID="LabKyatVal" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" CssClass="label" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black"></span></td>
                                                            <td>
                                                                <asp:Label ID="Label15" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabPaid" CssClass="label" runat="server">Paid</asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black">:</span></td>
                                                            <td>
                                                                <asp:Label ID="LabPaidVal" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label16" CssClass="label" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black"></span></td>
                                                            <td>
                                                                <asp:Label ID="Label17" CssClass="label" runat="server" ForeColor="Black"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabRemain" CssClass="label" runat="server">Remain</asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black">:</span></td>
                                                            <td>
                                                                <asp:Label ID="LabRemainVal" CssClass="label" runat="server" ForeColor="Black"> </asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label18" CssClass="label" runat="server"></asp:Label></td>
                                                            <td><span style="margin-left: 1em; color: black"></span></td>
                                                            <td>
                                                                <asp:Label ID="Label19" CssClass="label" runat="server" ForeColor="Black"> </asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Label ID="ShAll" runat="server" CssClass="linklb"><a href="SMS016_StudentCashList.aspx">Show All Cash List</a></asp:Label>
                            </form>
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
