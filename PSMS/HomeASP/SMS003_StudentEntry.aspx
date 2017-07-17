<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS003_StudentEntry.aspx.cs" Inherits="HomeASP.SMS003" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>

   
    <script type="text/javascript">
        $(function () {
            $(".studentdate").datepicker();

        });
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
        .auto-style16
        {
            font: 16px Verdana, Helveticaall-petite-caps;
            color: #074959;
            height: 20px;
        }
        .auto-style17
        {
            width : 190px;
            height: 20px;
            font-size: 10px;
        }
        </style>

</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html"-->
            <!-- header ends -->

            <!-- content ends -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 595px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 555px;">
                                <h2>Student Registration</h2>
                                <table style="margin: 0px 0px 0px 50px;border-collapse:separate; border-spacing:0 10px;">
                                    <tr>
                                        <td rowspan="5">
                                            <asp:Image runat="server" ID="studentpicture" Style="margin-left: 20px;" Height="152px" ImageUrl="~/Images/Profile.png" Width="139px" />
                                        </td>
                                        <td rowspan="5">
                                            <span style="margin-left: 4em" /></td>
                                        <td rowspan="5" class="auto-style14">
                                            <span style="margin-left: 4em" /></td>
                                    </tr>
                                    <tr >
                                        <td style="margin: 7px 7px 7px 7px;" class="label">
                                            <asp:Label ID="EduY" CssClass="label" runat="server">Education Year</asp:Label><asp:Label ID="Label27" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td style="margin: 7px 7px 7px 7px;">
                                            <asp:DropDownList ID="education" runat="server" ForeColor="Black" CssClass="dropdownlist">
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
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td style="margin: 7px 7px 7px 7px;" class="label">
                                            <asp:Label ID="Label1" CssClass="label" runat="server">Student Id</asp:Label><asp:Label ID="Label24" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td style="margin: 7px 7px 7px 7px;">
                                            <asp:TextBox ID="stuid" runat="server" CssClass="textbox" ForeColor="Black"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td style="margin: 7px 7px 7px 7px;" class="label">
                                            <asp:Label ID="Label2" CssClass="label" runat="server">Name</asp:Label><asp:Label ID="Label23" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td style="margin: 7px 7px 7px 7px;">
                                            <asp:TextBox ID="stuname" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="margin: 7px 7px 7px 7px;">
                                        <td class="label">
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Grade</asp:Label><asp:Label ID="Label25" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="grade" runat="server" ForeColor="Black" CssClass="dropdownlist"></asp:DropDownList>
                                        </td>
                                        <td class="auto-style14"><span style="margin-left: 2em"></span></td>
                                    </tr>
                                    <tr style="margin: 7px 7px 7px 7px;">
                                        <td colspan="3">
                                            <asp:FileUpload ID="FileUpload1" runat="server" Height="32px" Style="margin-left: 25px" onchange="this.form.submit();" />
                                            <%--<asp:Button ID="photoUpload" runat="server" OnClick="photoUpload_Click" Text="Upload" CssClass="btn" Style="float: left" />--%>
                                            <%--<asp:Label ID="errphotosize" runat="server" ForeColor="Red" Font-Size="Large" Visible="false" Text="Input Image is too small. Please try again!"></asp:Label>--%>
                                        </td>
                                        <td class="label">
                                            <asp:Label ID="Label4" CssClass="label" runat="server">Father Name</asp:Label><asp:Label ID="Label26" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="father" runat="server" BorderStyle="Ridge" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td class="auto-style4"> Room<asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:DropDownList ID="roomid" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="label">
                                            <asp:Label ID="Label6" CssClass="label" runat="server">Mother Name</asp:Label><asp:Label ID="Label16" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:TextBox ID="mother" runat="server" BorderStyle="Ridge" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="auto-style2"></td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td class="auto-style4">
                                            <asp:Label ID="Label7" CssClass="label" runat="server">Roll No.</asp:Label><asp:Label ID="Label17" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:TextBox ID="rollno" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="auto-style15">
                                            &nbsp;</td>
                                        <td class="label">
                                            <asp:Label ID="Label8" CssClass="label" runat="server">Contact Phone</asp:Label><asp:Label ID="Label18" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="phone" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td class="auto-style4">
                                            <asp:Label ID="Label9" CssClass="label" runat="server">Gender</asp:Label><asp:Label ID="Label19" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:RadioButton ID="Male" runat="server" GroupName="Gender" Text="Male" />
                                            <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="Gender" />
                                        </td>
                                        <td class="auto-style15">
                                            &nbsp;</td>
                                        <td class="auto-style9">
                                            <asp:Label ID="Label10" CssClass="label" runat="server">Address</asp:Label><asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="address" runat="server" BorderStyle="Ridge" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="errorwidth">
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;" >
                                        <td class="auto-style16">
                                            <asp:Label ID="Label11" CssClass="label" runat="server">Date of Birth</asp:Label><asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                        <td class="auto-style8">
                                            <asp:TextBox CssClass="studentdate textbox" ID="dob" Style="color: black" runat="server" AutoPostBack="false" />
                                        </td>
                                        <td class="auto-style10">
                                            </td>
                                        <td class="auto-style10">
                                            <asp:Label ID="Label12" CssClass="label" runat="server">Email</asp:Label></td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="email" runat="server" CssClass="textbox" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox>
                                        </td>
                                        <td class="auto-style17">
                                            </td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td class="auto-style4">
                                            <asp:Label ID="Label13" CssClass="label" runat="server">Phone</asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:TextBox ID="stuphone" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="auto-style15"></td>
                                        <td class="auto-style6">
                                            <asp:Label ID="Label14" CssClass="label" runat="server">Password</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="password" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="errorwidth">
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        <td class="auto-style4" colspan="1">
                                            <asp:Label ID="Label15" CssClass="label" runat="server">NRC No.</asp:Label></td>
                                        <td class="auto-style5">
                                            <asp:TextBox ID="nrcno" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td><asp:RegularExpressionValidator ID="regexNRC" runat="server" ControlToValidate="nrcno" ValidationExpression="^[0-9]{1,2}[/][a-zA-Z]{3,9}[(][N,P,A,E,Y][)][0-9]{6,8}$" ForeColor="Red">Wrong Nrc!</asp:RegularExpressionValidator></td>
                                        <td class="label">
                                            <asp:Label ID="Label22" CssClass="label" runat="server">Cash Type</asp:Label><asp:Label ID="Label28" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="cashtype" runat="server" ForeColor="Black" CssClass="dropdownlist" OnSelectedIndexChanged="cashtype_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>Select Cash Type</asp:ListItem>
                                                <asp:ListItem>Annually</asp:ListItem>
                                                <asp:ListItem>Monthly</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="padding: 7px 7px 7px 7px;">
                                        
                                        <td colspan="3" align="center"><asp:Label ID="AllErrSMS" style="font-size:15px;color:red" runat="server" Font-Bold="True"></asp:Label></td>
                                        <td colspan="2" style="padding-top: 7px" align="right">
                                            <asp:RadioButton ID="firstmonth" runat="server" GroupName="cash2" Text="1 Month" />
                                            <asp:RadioButton ID="thirdmonth" runat="server" GroupName="cash2" Text="3 Month" />
                                            <asp:RadioButton ID="fourmonth" runat="server" GroupName="cash2" Text="4 Month" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  colspan="5" style="padding-left:300px">
                                            <asp:Button ID="save" runat="server" Text="Save " OnClick="saved_Click" CssClass="btn" Height="31px" style="margin-right:7px;" />
                                            <asp:Button ID="showlist" runat="server" Text="Show List" OnClick="showlist_Click" CssClass="btn" Height="30px" style="margin-right:7px;" />
                                            <asp:Button ID="Update" runat="server" Text="Update" OnClick="btnupdate_Click" CssClass="btn" Height="30px" style="margin-right:7px;" />
                                            <asp:Button ID="clear" runat="server" Text="Clear" OnClick="clear_Click" CssClass="btn" Height="30px" style="margin-right:7px;" />
                                        </td>

                                    </tr>
                                </table>
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
