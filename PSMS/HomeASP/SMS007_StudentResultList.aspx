<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS007_StudentResultList.aspx.cs" Inherits="HomeASP.SMS007" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Result List</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentResultStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            height: 42px;
        }
    </style>

</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">
            <!-- header begins -->
            <% if(Session["LOGIN_USER_LEVEL"].ToString().Equals("Admin")){ %>
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <% } 
               else{ %>
            <!-- #include file="~/HtmlPages/UserHeader.html" -->
            <% } %>
            <!-- header ends -->

            <!-- content begins -->
           <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                               <h2>Student Result List</h2>
                                <table id="table_style" runat="server">
                                    <tr>
                                        <td colspan="2" style="color: red ;visibility: visible;"><asp:Label ID="errresultyr" CssClass="errlabel" runat="server"></asp:Label></td>
                                        <td><span style="margin-left: 3em"></span></td>
                                        <td colspan="2" style="color: red ;visibility: visible;"><asp:Label ID="errresultmonth"  CssClass="errlabel" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="td_width" style="color: red ;visibility: visible;">
                                         <asp:Label ID="Label1" CssClass="label" runat="server">Education Year</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlYearList" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                <asp:ListItem>Select Year</asp:ListItem>
                                                <asp:ListItem>2010-2011</asp:ListItem>
                                                <asp:ListItem>2011-2012</asp:ListItem>
                                                <asp:ListItem>2012-2013</asp:ListItem>
                                                <asp:ListItem>2013-2014</asp:ListItem>
                                                <asp:ListItem>2014-2015</asp:ListItem>
                                                <asp:ListItem>2015-2016</asp:ListItem>
                                                <asp:ListItem>2016-2017</asp:ListItem>
                                                <asp:ListItem>2017-2018</asp:ListItem>
                                                <asp:ListItem>2018-2019</asp:ListItem>
                                                <asp:ListItem>2019-2020</asp:ListItem>
                                            </asp:DropDownList></td>
                                         <td><span style="margin-left: 2em"></span></td>
                                        <td class="td_width"><asp:Label ID="Label2" CssClass="label" runat="server">Month</asp:Label>
                                            </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMonthList" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem>Select Month</asp:ListItem>
                                                <asp:ListItem>January</asp:ListItem>
                                                <asp:ListItem>February</asp:ListItem>
                                                <asp:ListItem>March</asp:ListItem>
                                                <asp:ListItem>April</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>July</asp:ListItem>
                                                <asp:ListItem>August</asp:ListItem>
                                                <asp:ListItem>September</asp:ListItem>
                                                <asp:ListItem>October</asp:ListItem>
                                                <asp:ListItem>November</asp:ListItem>
                                                 <asp:ListItem>December</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="color: red ;visibility: visible;"><asp:Label ID="errresultgrade" CssClass="errlabel" runat="server"></asp:Label></td>
                                        <td><span style="margin-left: 3em"></span></td>
                                        <td colspan="2" style="color: red ;visibility: visible;"><asp:Label ID="errresultroom"  CssClass="errlabel" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Grade</asp:Label></td>
                                        
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlresultgrade" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1"><span style="margin-left: 3em"></span></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label4" runat="server" CssClass="label">Room</asp:Label></td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlresultroom" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Button ID="Button1" runat="server" Text="Search" OnClick="BtnSearch_Click" CssClass="btn" /></td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblmsg" CssClass="label" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                             <br />  
                            <asp:GridView ID="stdResultGiv" runat="server" CellPadding="4" GridLines="None" PageSize="5"
                                ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." OnPageIndexChanging="stdResultGiv_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False">
                                <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#D2EEEA" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                        <asp:BoundField HeaderText="ID"
                                            DataField="STUDENT_ID"
                                            SortExpression="STUDENT_ID"  Visible="true" ReadOnly="true">
                                        </asp:BoundField>
	                                    <asp:BoundField HeaderText="NAME"
		                                    DataField="STUDENT_NAME"
		                                    SortExpression="STUDENT_NAME" ReadOnly="true"></asp:BoundField>
	                                    <asp:BoundField HeaderText="ROLL NO"
	                                    DataField="ROLL_NO"
	                                    SortExpression="ROLL_NO" ReadOnly="true"></asp:BoundField>
                                            <asp:TemplateField HeaderText="" >
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject1" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject2" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject3" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject4" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject5" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsubject6" runat="server" AutoPostBack="true" CssClass="marktextbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnResultEdit" runat="server" Text="Edit" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnResultUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnResultDetail" runat="server" Text="Detail" CommandName='<%# Eval("STUDENT_ID") %>' OnClick="btnResultDetail_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                            </asp:GridView> 
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
