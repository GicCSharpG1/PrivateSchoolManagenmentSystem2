<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS005_StudentDetail.aspx.cs" Inherits="HomeASP.SMS005" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student Detail</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
     <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    
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
                                 <h2>Student Detail</h2>  
                                <table style=" background-color: #7BCCB5;padding: 10px 10px 15px 30px; margin:0px 35px 10px 35px; width:920px; border:solid; border-radius:3px; font: 19px Verdana, Helveticaall-petite-caps;">
                                    
                                <tr>
                                   <td colspan="5"><asp:Panel ID="Panel1" runat="server"></asp:Panel><br /></td>

                                </tr>
                                    
                                <tr>
                                    <td>
                                    &nbsp;&nbsp;<asp:Image ID="picturebox" runat="server" Height="152px" Width="139px" /></td>
                                    <td colspan="3"> &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblName" Text="Name " runat="server" CssClass="txtname" /> <br />
                                                     &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblClass" Text="Show Education Year " runat="server" CssClass="txtyear"/></td>
                                     

                                </tr>

                              
                                
                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;Grade </td> 
                                     <td class="auto-style4"><asp:Label ID="lblGrade" Text=": Show " runat="server" /></td>

                                     <td class="detailform"></td>

                                     <td class="auto-style4">&nbsp;&nbsp;Father Name </td> 
                                    <td class="auto-style4"><asp:Label ID="lblFather" Text=": Show " runat="server" /></td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;ID </td> 
                                     <td class="auto-style4"><asp:Label ID="lblID" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>

                                    <td class="auto-style4">&nbsp;&nbsp;Mother Name </td> 
                                     <td class="auto-style4"><asp:Label ID="lblMother" Text=": Show  " runat="server" /></td>

                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;Room </td>
                                     <td class="auto-style4"><asp:Label ID="lblRoom" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>

                                     <td class="auto-style4">&nbsp;&nbsp;Contact Phone </td> 
                                     <td class="auto-style4"><asp:Label ID="lblCphone" Text=": Show  " runat="server" /></td>
                                     
                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;Roll No </td> 
                                     <td class="auto-style4"><asp:Label ID="lblRoll" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>

                                    <td class="auto-style4">&nbsp;&nbsp;Email </td> 
                                     <td class="auto-style4"><asp:Label ID="lblEmail" Text=": Show  " runat="server" /></td>

                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;Gender </td>
                                     <td class="auto-style4"><asp:Label ID="lblGender" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>

                                    <td class="auto-style4">&nbsp;&nbsp;Password </td> 
                                     <td class="auto-style4"><asp:Label ID="lblPwd" Text=": Show  " runat="server" /></td>
                                </tr>

                                <tr>

                                    <td class="auto-style4">&nbsp;&nbsp;Date of Birth </td> 
                                     <td class="auto-style4"><asp:Label ID="lbldob" Text=": Show  " runat="server" /></td>

                                      <td class="detailform"></td>
                                       <td class="auto-style4">&nbsp;&nbsp;CashType </td> 
                                     <td class="auto-style4"><asp:Label ID="lblCashtype" Text=": Show  " runat="server" /></td>
                                </tr>

                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;Phone No </td>
                                    <td class="auto-style4"><asp:Label ID="lblPhone" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>
                                    <td class="auto-style4">&nbsp;&nbsp;Cash Month </td> 
                                     <td class="auto-style4"><asp:Label ID="lblCashMonth" Text=": Show  " runat="server" /></td>


                                </tr>
                                                                      
                                <tr>
                                    <td class="auto-style4">&nbsp;&nbsp;NRC_No </td> 
                                     <td class="auto-style4"><asp:Label ID="lblNrc" Text=": Show  " runat="server" /></td>

                                     <td class="detailform"></td>
                                    
                                    <td class="auto-style4">&nbsp;&nbsp;Address </td> 
                                   
                                   <td class="auto-style4"><asp:Label ID="lblAddress" runat="server" Text=": Show  " /></td>

                                </tr>
                               </table>
                                <table style="padding-left:150px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnprevious" runat="server" Text="Previous" OnClick="btnprevious_Click" CssClass="btn" />
                                        </td>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnedit" runat="server" Text="Edit" Width="101px" OnClick="btnedit_Click" CssClass="btn" />
                                        </td>
                                        <td>
                                              &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnprint" runat="server" Text="Print" Width="101px" CssClass="btn" OnClick="btnprint_Click"/>
                                        </td>
                                     </tr>
                                </table>
                                
                                
                               

                            </form>

                            </div>
                    </div>
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
