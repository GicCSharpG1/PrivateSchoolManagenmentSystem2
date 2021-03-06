﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0035_StudentTimeTableEntry.aspx.cs" Inherits="HomeASP.SM_StudentTimeTableEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Student TimeTable Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentResultStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/classtimetable.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html"-->
            <!-- header ends -->

            <!-- content begin -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 500px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 480px;">
                                     <h2>Class Timetable Entry</h2>

                                <table  style="margin:31px 50px 50px 50px">
                                    <tr>
                                        <td colspan="3"><asp:Label ID="errmsgexist" runat="server" CssClass="errlable1" Text="Already Exist ! Please choose other data !" Visible="False" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="stutd_width"><asp:Label ID="Label4" CssClass="label" runat="server" Text="EDU Year"></asp:Label></td>
                                        <td><asp:DropDownList ID="ddleduyearlist" CssClass="dropdownlist" runat="server" Width="150px"  >
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
                                            
                                        <td>
                                             <asp:Label ID="errmsgeduyear" runat="server" Text="Please select required field !"  CssClass="errlable1" Visible="False" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="stutd_width"><asp:Label ID="Label3" CssClass="label" runat="server" Text="Grade*"></asp:Label></td>
                                        <td><asp:DropDownList CssClass="dropdownlist" ID="ddlentrygradelist" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Width="150px">
                                            </asp:DropDownList></td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errmsggradelist" runat="server" Text="Please select grade !"  CssClass="errlable1" Visible="False" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="stutd_width"><asp:Label ID="Label1" CssClass="label" runat="server" Text="Class*"></asp:Label></td>
                                        <td><asp:DropDownList CssClass="dropdownlist" ID="ddlentryclasslist" runat="server" AppendDataBoundItems="True" Width="150px">
                                        </asp:DropDownList></td>
                                        <td class="auto-style1"><asp:Label ID="errmsgclasslist" runat="server" Text="Please select class!"  CssClass="errlable1" Visible="False" ForeColor="red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="stutd_width"><asp:Label ID="Label2" CssClass="label" runat="server" Text="Room Teacher*"></asp:Label></td>
                                        <td><asp:DropDownList CssClass="dropdownlist" ID="ddlentryteacherlist" runat="server" AppendDataBoundItems="True" Width="150px">
                                        </asp:DropDownList></td>
                                        <td class="auto-style1"><asp:Label ID="errmsgteaacherlist" runat="server" Text="Please select Room Teacher !" CssClass="errlable1" Visible="False" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                 <tr>
                                     <td height="30px"></td>
                                      
                                 </tr>
                                    <tr>
                                       
                                        <td class="column"><asp:Button ID="btnRoomteaSave" runat="server"  Text="Save" OnClick="btnRoomteaSave_Click" CssClass="btn"/>
                                        </td>
                                        <td><asp:Button ID="btnroomteaCancel" runat="server" Text="Cancel" OnClick="btnroomteaCancel_Click" CssClass="btn"/></td>
                                    </tr>
                                </table>
                                
        <asp:GridView ID="gvRoomTeacher"  style="margin-left:auto; margin-right:auto; margin-top: 50px;"  runat="server" Width="900px" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." AllowPaging="True" 
                                   PageSize="5" OnPageIndexChanging="gvRoomTeacher_PageIndexChanging" Font-Overline="False" Font-Size="Medium" OnSelectedIndexChanged="gvRoomTeacher_SelectedIndexChanged">
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#D2EEEA" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                         <asp:BoundField HeaderText="GRADE"
                                            DataField="GRADE_ID"
                                        SortExpression="GRADE_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="ROOM"
                                            DataField="ROOM_ID"
                                        SortExpression="ROOM_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="ROOM TEACHER"
                                            DataField="ROOM_TEACHER_ID"
                                        SortExpression="ROOM_TEACHER_ID"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRoomTeacherEdit" runat="server" Text="Edit" CommandName='<%# Eval("TIMETABLE_ID") %>' OnClick="btnRoomTeaUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRoomTeacherSelect" runat="server" Text="Next" CommandName='<%# Eval("TIMETABLE_ID") %>' OnClick="btnRoomTeaNext_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                   
                                <br />
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
            <!-- #include file="~/HtmlPages/Footer.html" -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>


