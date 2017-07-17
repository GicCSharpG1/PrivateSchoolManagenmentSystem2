<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="HomeASP._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

    <!-- Start WOWSlider.com HEAD section -->
    <link rel="stylesheet" type="text/css" href="engine1/style.css" />
    <script type="text/javascript" src="engine1/jquery.js"></script>
    <!-- End WOWSlider.com HEAD section -->
</head>
<body style="background-image: url(Images/bgg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">
            <!-- header begins -->
            <div id="header" style="background-image: url(Images/big.jpg)">
                <div id="buttons" style="background-image: url(Images/bg_but.jpg)">
                    <nav class="menu">
                        <h1 style="font-family: 'edwardian Script ITC'; text-transform: none; color: #0F3135; font-variant: normal; font-style: normal; font-weight: bold; font-size: 45px; position: relative;vertical-align:central;text-align:center; line-height:50px; text-decoration: none;">Private School Management System</h1>
                    </nav>
                </div>
                <div id="logo">
                    <!-- Start WOWSlider.com BODY section -->
                    <div id="wowslider-container1">
                        <div class="ws_images">
                            <ul id="uList" runat="server">
                                <li>
                                    <img src="data1/images/kid.jpg" alt="kid" title="kid" id="wows1_0" /></li>
                                <li>
                                    <img src="data1/images/kid0.jpg" alt="kid0" title="kid0" id="wows1_1" /></li>
                                <li>
                                    <img src="data1/images/kid1.jpg" alt="kid1" title="kid1" id="wows1_2" /></li>
                                <li>
                                    <img src="data1/images/kid3.jpg" alt="kid3" title="kid3" id="wows1_3" /></li>
                                <li>
                                    <img src="data1/images/kid4.png" alt="kid4" title="kid4" id="wows1_4" /></li>
                                <li>
                                    <img src="data1/images/kid5.jpg" alt="kid5" title="kid5" id="wows1_5" /></li>
                                <li>
                                    <img src="data1/images/kid6.jpg" alt="kid6" title="kid6" id="wows1_6" /></li>
                                <li>
                                    <img src="data1/images/kid7.jpg" alt="kid7" title="kid7" id="wows1_7" /></li>
                                <li><a href="http://wowslider.com">
                                    <img src="data1/images/kid8.jpg" alt="wow slider" title="kid8" id="wows1_8" /></a></li>
                                <li>
                                    <img src="data1/images/kid9.jpg" alt="kid9" title="kid9" id="wows1_9" /></li>
                            </ul>
                        </div>
                        <div class="ws_bullets">
                            <div>
                                <a href="#" title="kid"><span>
                                    <img src="data1/tooltips/kid.jpg" alt="kid" />1</span></a>
                                <a href="#" title="kid0"><span>
                                    <img src="data1/tooltips/kid0.jpg" alt="kid0" />2</span></a>
                                <a href="#" title="kid1"><span>
                                    <img src="data1/tooltips/kid1.jpg" alt="kid1" />3</span></a>
                                <a href="#" title="kid3"><span>
                                    <img src="data1/tooltips/kid3.jpg" alt="kid3" />4</span></a>
                                <a href="#" title="kid4"><span>
                                    <img src="data1/tooltips/kid4.png" alt="kid4" />5</span></a>
                                <a href="#" title="kid5"><span>
                                    <img src="data1/tooltips/kid5.jpg" alt="kid5" />6</span></a>
                                <a href="#" title="kid6"><span>
                                    <img src="data1/tooltips/kid6.jpg" alt="kid6" />7</span></a>
                                <a href="#" title="kid7"><span>
                                    <img src="data1/tooltips/kid7.jpg" alt="kid7" />8</span></a>
                                <a href="#" title="kid8"><span>
                                    <img src="data1/tooltips/kid8.jpg" alt="kid8" />9</span></a>
                                <a href="#" title="kid9"><span>
                                    <img src="data1/tooltips/kid9.jpg" alt="kid9" />10</span></a>
                            </div>
                        </div>
                        <div class="ws_script" style="position: absolute; left: -99%"><a href="http://wowslider.com">jquery slider</a> by WOWSlider.com v8.7</div>
                        <div class="ws_shadow"></div>
                    </div>
                    <script type="text/javascript" src="engine1/wowslider.js"></script>
                    <script type="text/javascript" src="engine1/script.js"></script>
                    <!-- End WOWSlider.com BODY section -->
                </div>
            </div>
            <!-- header ends -->

            <!-- content begins -->
            <div id="content" style="background-image: url(Images/content.gif)">
                <div id="content_top" style="background-image: url(Images/left_top.gif)">
                    <div id="content_bot" style="background-image: url(Images/left_bot.gif)">
                        <div id="right">
                            <div class="tit_bot" style="background-image: url(Images/right_bg.jpg)">
                                <div class="right_b" style="height: 360px; width: 650px;">
                                    <div id="container_demo">
                                        <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                                        <a class="hiddenanchor" id="toregister"></a>
                                        <a class="hiddenanchor" id="tologin"></a>
                                        <div id="wrapper">

                                            <form id="login" runat="server">
                                                <h2>Log In</h2>
                                                <fieldset id="inputs">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="errorMsg" Visible="false" Text="Username and Password are not correct!" ForeColor="Red" /><br />                                                   
                                                    <asp:TextBox runat="server" id="userName" type="text" placeholder="Username" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="userName" ErrorMessage="Please Enter User Name!" ForeColor="Red" />
                                                    <asp:TextBox runat="server" id="password" type="password" placeholder="Password" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="password" ErrorMessage="Please Enter Password!" ForeColor="Red" />
                                                </fieldset>
                                                <fieldset id="actions">
                                                    <asp:Button runat="server" type="submit" id="submit" Text="Log in" onClick="login_Click" />
                                                    <a href="#">Forgot your password?</a><%--<a href="">Register</a>--%>
                                                </fieldset>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                        <div id="left">
                            <h3>About as</h3>
                            <div class="right_b">
                                <span class="col_b">Until recently, education in most western countries has been almost fully administered and paid by central governments. </span>
                                <br />
                                PSMS is a clean and modern school administration and management software option which covers everything from exams and assignments to budgeting and detail information for all staffs. The system was developed using ASP.NET, so can easily customize the code to school’s needs.
                            </div>
                            <div class="read">
                                <a href="#">
                                    <img src="images/b_read.gif" alt="" /></a>
                            </div>
                            <br />
                            <div class="right_b">
                                <span class="col_b">PSMS is easy for teachers to learn and use and it’s compatible with most operating systems and browsers. </span>
                                <br />
                                PSMS School may also present a challenge to teachers who have never worked with school administration software before, as some claim it is not immediately intuitive to use. PSMS offers unlimited administration and student logins to use their system, along with unlimited courses and batches.                                
                            </div>
                            <div class="read">
                                <a href="#">
                                    <img src="images/b_read.gif" alt="" /></a>
                            </div>
                            <br />
                        </div>
                        <br />
                        <div style="clear: both">
                            <img src="images/spaser.gif" alt="" width="1" height="1" />
                        </div>
                        <div class="bot"></div>
                    </div>
                </div>
            </div>
            <!-- content ends -->

            <!-- footer begins -->
            <!-- #include file="~/HtmlPages/Footer.html" -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>

