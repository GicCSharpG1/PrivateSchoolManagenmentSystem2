<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS008_StudentResultDetail.aspx.cs" Inherits="HomeASP.SMS008" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student Result Detail</title>
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
                                 <h2>Student Result Detail</h2>
                                <div>
                                    <fieldset>
                                        <table id="table_style" runat="server">
                                        <tr>
                                            <td><asp:Label ID="Label1" runat="server" Text="EDU Year" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl1" runat="server" Text=":" CssClass="label"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblresultyear" runat="server" Text="AAAAAAAAAA" CssClass="label" ></asp:Label>
                                            </td>
                                             <td><span style="margin-left: 5em"></span></td>
                                            <td class="td_width"><asp:Label ID="Label2" runat="server" Text="Month" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl2" runat="server" Text=":" CssClass="label"/></td>
                                            <td><asp:Label ID="lblresultmonth" runat="server" Text="AAAAAAAAAA" CssClass="label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="td_width"><asp:Label ID="Label3" runat="server" Text="Name" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl3" runat="server" Text=":" CssClass="label"/></td>
                                            <td>
                                                <asp:Label ID="lblresultName" runat="server" Text="AAAAAAAAAA" CssClass="label"></asp:Label>
                                            </td>
                                            <td><span style="margin-left: 5em"></span></td>
                                            <td class="auto-style1"><asp:Label ID="Label4" runat="server" Text="Roll No" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl4" runat="server" Text=":" CssClass="label"/></td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblresultroll" runat="server" Text="AAAAAAAAAA" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1"><asp:Label ID="Label5" runat="server" Text="Grade" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl5" runat="server" Text=":" CssClass="label"/></td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblresultgrade" runat="server" Text="AAAAAAAAAA" CssClass="label"></asp:Label>
                                            </td>
                                            <td><span style="margin-left: 5em"></span></td>
                                            <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="Room" CssClass="label" ></asp:Label></td>
                                            <td><asp:Label ID="lbl6" runat="server" Text=":" CssClass="label"/></td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblresultclass" runat="server" Text="AAAAAAAAAA" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    </fieldset>
                                    <br />
                                  <asp:Table ID="tblShowResult" runat="server" BorderStyle="Solid" Height="22px" Width="551px">
                                      <asp:TableHeaderRow>
                                          <asp:TableHeaderCell ID="DataHeader" BackColor="#006666" ForeColor="White" Font-Size="16px" Text="Subject"></asp:TableHeaderCell>
                                          <asp:TableHeaderCell ID="TableHeaderCell2" BackColor="#006666" ForeColor="White" Font-Size="16px" Text="Mark"></asp:TableHeaderCell>
                                          <asp:TableHeaderCell ID="TableHeaderCell1" BackColor="#006666" ForeColor="White" Font-Size="16px" Text="Grade"></asp:TableHeaderCell>
                                      </asp:TableHeaderRow>
                                    </asp:Table>
                                    <br />
                                    <asp:Button ID="btnBackList" runat="server" Text="Back" CssClass="btn" style="margin-left:20px" OnClick="btnBackList_Click" />
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


