<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SMS023_StaffEntry.aspx.cs" Inherits="HomeASP.SMS023" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Staff Entry</title>
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

        function validateDate(elementRef) {
            var monthDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

            var dateValue = elementRef.value;

            if (dateValue.length != 10) {
                alert('Entry must be in the format mm/dd/yy.');

                return false;
            }

            // mm/dd/yyyy format... 
            var valueArray = dateValue.split('/');

            if (valueArray.length != 3) {
                alert('Entry must be in the format mm/dd/yyyy.');

                return false;
            }

            var monthValue = parseFloat(valueArray[0]);
            var dayValue = parseFloat(valueArray[1]);
            var yearValue = parseFloat(valueArray[2]);

            if ((isNaN(monthValue) == true) || (isNaN(dayValue) == true) || (isNaN(yearValue) == true)) {
                alert('Non-numeric entry detected\nEntry must be in the format mm/dd/yyyy.');

                return false;
            }

            if (((yearValue % 4) == 0) && (((yearValue % 100) != 0) || ((yearValue % 400) == 0)))
                monthDays[1] = 29;
            else
                monthDays[1] = 28;

            if ((monthValue < 1) || (monthValue > 12)) {
                alert('Invalid month entered\nEntry must be in the format mm/dd/yyyy.');

                return false;
            }

            var monthDaysArrayIndex = monthValue - 1;
            if ((dayValue < 1) || (dayValue > monthDays[monthDaysArrayIndex])) {
                alert('Invalid day entered\nEntry must be in the format mm/dd/yyyy.');

                return false;
            }

            return true;
        }

    </script>
    <style type="text/css">
        .auto-style2 {
            width: 140px;
            height: 20px;
            font-size: 12px;
        }

        .auto-style4 {
            font: 16px Verdana, Helveticaall-petite-caps;
            color: #074959;
            width: 155px;
        }

        .auto-style5 {
            width: 135px;
        }

        .auto-style6 {
            font: 16px Verdana, Helveticaall-petite-caps;
            color: #074959;
            width: 220px;
        }

        .auto-style8 {
            width: 135px;
            height: 20px;
        }

        .auto-style9 {
            font: 16px Verdana, Helveticaall-petite-caps;
            color: #074959;
            height: 20px;
            width: 220px;
        }

        .auto-style10 {
            height: 20px;
        }

        .auto-style14 {
            width: 113px;
        }

        .auto-style15 {
            width: 113px;
            height: 20px;
            font-size: 12px;
        }
    </style>
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
                                <h2>Staff Registration</h2>
                                <table style="margin: 0px 0px 0px 50px; border-collapse: separate; border-spacing: 0 10px;">
                                    <tr>
                                        <td rowspan="5">
                                            <asp:Image runat="server" ID="staffpicture" Style="margin-left: 20px;" Height="152px" ImageUrl="~/Images/Profile.png" Width="139px" />
                                        </td>
                                        <td rowspan="5">
                                            <span style="margin-left: 4em" /></td>
                                        <td rowspan="5" class="auto-style14">
                                            <span style="margin-left: 4em" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" CssClass="label" runat="server"> Year</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="staffEduYear" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                                <asp:ListItem>Choose Education Year</asp:ListItem>
                                                <asp:ListItem>2005 - 2006</asp:ListItem>
                                                <asp:ListItem>2006 - 2007</asp:ListItem>
                                                <asp:ListItem>2007 - 2008</asp:ListItem>
                                                <asp:ListItem>2008 - 2009</asp:ListItem>
                                                <asp:ListItem>2009 - 2010</asp:ListItem>
                                                <asp:ListItem>2010 - 2011</asp:ListItem>
                                                <asp:ListItem>2011 - 2012</asp:ListItem>
                                                <asp:ListItem>2012 - 2013</asp:ListItem>
                                                <asp:ListItem>2013 - 2014</asp:ListItem>
                                                <asp:ListItem>2014 - 2015</asp:ListItem>
                                                <asp:ListItem>2015 - 2016</asp:ListItem>
                                                <asp:ListItem>2016 - 2017</asp:ListItem>
                                                <asp:ListItem>2017 - 2018</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" CssClass="label" runat="server"> Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="stfname" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" CssClass="label" runat="server">Staff Id</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="stfID" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                    </tr>
                                    <tr style="margin: 7px 7px 7px 7px;">
                                        <td>
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Position</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="posID" runat="server" CssClass="dropdownlist" ForeColor="Black" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style14"><span style="margin-left: 2em"></span></td>
                                    </tr>
                                    <tr style="margin: 7px 7px 7px 7px;">
                                        <td colspan="3">
                                            <asp:FileUpload ID="FileUpload1" runat="server" Height="32px" Style="margin-left: 25px" onchange="this.form.submit();" />
                                            <%--<asp:Button ID="photoUpload" runat="server" OnClick="photoUpload_Click" Text="Upload" CssClass="btn" Style="float: left" />--%>
                                            <%--<asp:Label ID="errphotosize" runat="server" ForeColor="Red" Font-Size="Large" Visible="false" Text="Input Image is too small. Please try again!"></asp:Label>--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" CssClass="label" runat="server">Education</asp:Label>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="education" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                    </tr>

                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td>
                                            <asp:Label ID="Label9" CssClass="label" runat="server">Gender</asp:Label></td>

                                        <td>
                                            <asp:RadioButton ID="Male" runat="server" GroupName="Gender" Text="Male" />
                                            <asp:RadioButton ID="Female" runat="server" GroupName="Gender" Text="Female" /></td>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label5" CssClass="label" runat="server">Marital</asp:Label></td>
                                        <td>
                                            <asp:RadioButton ID="Single" runat="server" GroupName="Martial Status" Text="Single" />
                                            <asp:RadioButton ID="Married" runat="server" GroupName="Martial Status" Text="Married" /></td>
                                        <td class="errorwidth">&nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td>
                                            <asp:Label ID="Label7" CssClass="label" runat="server" Width="125px">Date of birth</asp:Label></td>

                                        <td>
                                            <%--<asp:TextBox ID="dob" Style="color: black; margin-left: 0px" runat="server" onblur="validateDate(this);" />--%>
                                            <asp:TextBox ID="dob" CssClass="textbox" runat="server" onblur="validateDate(this);" ForeColor="Black"></asp:TextBox>
                                        </td>

                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label6" CssClass="label" runat="server">Salary</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="salary" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                        <td class="errorwidth">&nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td>
                                            <asp:Label ID="Label8" CssClass="label" runat="server">Phone</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="phone" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                        <td class="auto-style15"></td>
                                        <td rowspan="2">
                                            <asp:Label ID="Label10" CssClass="label" runat="server">Address</asp:Label>
                                        </td>
                                        <td rowspan="2">

                                            <%--<asp:TextBox ID="address" CssClass="textbox" runat="server" ForeColor="Black" Height="40px">--%>
                                            <asp:TextBox ID="address" TextMode="multiline" Style="resize: none" runat="server" Width="152" ForeColor="Black" />
                                        </td>
                                        <td class="errorwidth">&nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td>
                                            <asp:Label ID="Label11" CssClass="label" runat="server">NRC No.</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="nrcno" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td></td>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td align="center" colspan="3">
                                            <asp:Label ID="AllErrSMS" cssClass="errLabel" runat="server">Please put all error sms and successful sms here!!!</asp:Label></td>
                                        <td colspan="2" style="padding-top: 7px" align="right"></td>
                                    </tr>
                                </table>
                                <table style="margin-left:20px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="add" CssClass="btn" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                        </td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        <td>
                                            <asp:Button ID="update" CssClass="btn" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        <td>
                                            <asp:Button ID="showlist" runat="server" Text="Show List" OnClick="showStafflist_Click" CssClass="btn" /></td>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        <td>
                                            <asp:Button ID="cancel" CssClass="btn" runat="server" Text="Cancel" OnClick="BtnCancel_Click" /></td>
                                    </tr>
                                </table>

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
        <!-- #include file="~/HtmlPages/Footer.html"-->
        <!-- footer ends -->
    </div>
    </div>
</body>
</html>
