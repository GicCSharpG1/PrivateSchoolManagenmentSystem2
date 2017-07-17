<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS025_StaffInfoDetail.aspx.cs" Inherits="HomeASP.SMS025" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Staff Detail Page</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
     <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />
    <script language="javascript" type="text/javascript">
        function printdiv(printpage) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
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
                                 <h2>Staff Detail </h2>  
                                <div id="printArea">
                                <table style=" background-color: #7BCCB5;  margin-left:45px; margin-top:0px; width:900px;margin-bottom:10px; border:solid; border-radius:3px; font: 19px Verdana, Helveticaall-petite-caps; padding: 10px 10px 30px 30px">
                                    
                                <tr>
                                   <td colspan="5"><asp:Panel ID="Panel1" runat="server"  ></asp:Panel><br /></td>

                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" Height="152px" Width="139px"  /></td>
                                    <td colspan="3">&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblStaffName"  Text="Name " runat="server" CssClass="txtname" /><br />
                                                    
                                     &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblPosition"  Text="Position " runat="server" /> </td>
                                    
                                </tr>
<tr>
    <td></td>
</tr>


                               <tr>
                                  
                                     <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label8"  Text="NRC No" runat="server"></asp:Label></td>
                                     <td class="auto-style4"><asp:Label ID="lblNRC"  Text=" " runat="server" /></td>

                                      <td class="detailform"></td>

                                      <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label23"  Text="Education" runat="server" /></td> 
                                     <td class="auto-style4"><asp:Label ID="lblEducation"  Text=" " runat="server" /></td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label2"  Text="Staff ID" runat="server" /></td> 
                                    <td class="auto-style4"><asp:Label ID="lblstaffID"  Text=" " runat="server" /></td>

                                     <td class="detailform"></td>

                                     <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label6"  Text="Phone" runat="server" /></td> 
                                     <td class="auto-style4"><asp:Label ID="lblPhone"  Text=" " runat="server" /></td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label5"  Text="Gender" runat="server" /></td> 
                                    <td class="auto-style4"><asp:Label ID="lblGender"   Text=" " runat="server" /></td>

                                    <td class="detailform"></td>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label7" Text="DOB" runat="server" /></td> 
                                    <td class="auto-style4"><asp:Label ID="lblDOB"  Text=" " runat="server" /></td>
                                   
                                </tr>

                                <tr>
                                     <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label9" Text="Married Status" runat="server" /></td> 
                                    <td class="auto-style4"><asp:Label ID="lblStatus"  Text=" " runat="server" /></td>

                                     <td class="detailform"></td>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label25"  Text="Salary" runat="server" /></td> 
                                    <td class="auto-style4"><asp:Label ID="lblSalary"  Text=" " runat="server" /></td>
                                    
                                </tr>
                                                                    
                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="ll"  Text="Education Year" runat="server" /></td>
                                    <td class="auto-style4"><asp:Label ID="lblEduYear"  Text=" " runat="server" /></td>
                                    <td class="detailform"></td>
                                    <td class="auto-style4">&nbsp;&nbsp; <asp:Label ID="Label21"  Text="Address" runat="server" /></td> 
                                     <td class="auto-style4" rowspan="2"><asp:Label ID="lblAddress"  Text=" " runat="server" /></td>
                                </tr>
                                   

                                </table>
                               </div>
                                <table style="padding-left:150px;">
                                    <tr>
                                        <td><asp:Button ID="btnprevious" runat="server" Text="Staff List" OnClick="btnprevious_Click" CssClass="btn" /> </td>
                                        <td>
                                              &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td><asp:Button ID="btnGoentry" runat="server" Text="Edit" OnClick="btnedit_Click" CssClass="btn" /></td>
                                         <td>
                                              &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <input name="b_print" type="button" class="ipt btn" onClick="printdiv('printArea');" value=" Print "/>
                                            <%--<asp:Button ID="btnprint" runat="server" Text="Print" CssClass="btn" OnClick="btnprint_Click"/>--%> </td>
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
