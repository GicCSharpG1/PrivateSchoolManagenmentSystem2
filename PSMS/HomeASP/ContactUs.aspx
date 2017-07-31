<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="HomeASP.ContactUs" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Equipment Title Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
     <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
   

    <%--<script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>--%>
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
                                        
                <div style="text-align:center;">
                     <div style="width:50%; margin:0 auto; text-align:left;">
                            
                            <asp:Table runat="server" HorizontalAlign="Left">
                                <asp:TableRow ID="tableRow0" runat="server">
                                    <asp:TableCell runat="server"><h3>Global Innovation Consulting Inc.</h3></asp:TableCell>
                                </asp:TableRow>
                                 <asp:TableRow ID="TableRow1" runat="server">
                                     <asp:TableCell ID="TableCell1" runat="server"> BR Ryogoku 2 Bldg 2F, 1-21-10 Midori, Sumida ward,</asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow2" runat="server">
                                     <asp:TableCell>Tokyo 130-0021 Japan</asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow3" runat="server">
                                     <asp:TableCell> E-mail : marketing@gicjp.com</asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow4" runat="server">
                                     <asp:TableCell><h3>Contact Us</h3> </asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow5" runat="server">
                                     <asp:TableCell>  TEL : +81-3-5600-8880</asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow6" runat="server">
                                     <asp:TableCell>FAX : +81-3-5669-0955</asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow ID="TableRow7" runat="server"></asp:TableRow>
                                 <asp:TableRow ID="TableRow8" runat="server"></asp:TableRow>

                           </asp:Table>
      </div>
                            
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
