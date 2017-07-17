<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS016_StudentCashList.aspx.cs" Inherits="HomeASP.SMS016" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Cash List</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    
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
                        <div class="right_b" style="height: 500px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                        <h2>Student Cash List</h2>
                                        <div>
                                            <table id="cashTbl" style="margin-left: 15px" runat="server">
                                                <tr class="spaceUnder">
                                                    <td>
                                                        <asp:Label ID="LabStudId" CssClass="label" runat="server">ID*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtStudID" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="LabStuName" CssClass="label" runat="server">Name*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="LabStuNameVal" CssClass="textbox" runat="server" Enabled="false"></asp:TextBox></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="LabYear" CssClass="label" runat="server">Year*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:DropDownList ID="CoboYear" CssClass="dropdownlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CoboSelect_Change">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>2007 - 2008</asp:ListItem>
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
                                                </tr>
                                            </table>
                                        </div>

                                        <div style="margin: 20px 70px 20px 0px; float: right">
                                            
                                            <asp:Label ID="errSeach" ForeColor="Red" Font-Size="Medium" Style="float: left" runat="server"></asp:Label>
                                            <asp:Button ID="btnShowAll" Text="Show All" Color="Black" CssClass="btn" ForeColor="#333333" runat="server" OnClick="showAll_Click" />&nbsp&nbsp&nbsp&nbsp
                                            <span style="margin-left: 3em"></span>
                                            <asp:Button ID="btnSearch" Text="Search" Style="float: right" Color="Black" CssClass="btn" ForeColor="#333333" runat="server" OnClick="search_Click" />
                                        </div>
                                        <div id="Div2" class="gridDiv" runat="server">
                                            <asp:GridView ID="cashList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="This student has not been cash." CssClass="gridview" AllowPaging="True" PageSize="5" OnRowCommand="cashList_RowCommand" runat="server" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" OnPageIndexChanging="cashList_PageIndexChanging">
                                                <AlternatingRowStyle Wrap="False" BackColor="White" />
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#D2EEEA" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />

                                                <Columns>
                                                    <asp:BoundField DataField="EDU_YEAR" HeaderText="Education Year" Visible="false"/>
                                                    <asp:BoundField DataField="CASH_ID" HeaderText="Cash Id"/>
                                                    <asp:BoundField DataField="STUDENT_ID" HeaderText="Student Id" />
                                                    <asp:BoundField DataField="CASH_TITLE" HeaderText="Cash Title" />
                                                    <asp:BoundField DataField="CASH_DATE" HeaderText="Cash Date" />
                                                    <asp:BoundField DataField="ACCOUNT_NO" HeaderText="Account No" />
                                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDetail" runat="server" Text="Detail" CommandName="DetailCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <br />
                                            <asp:Label ID="alertMsg" ForeColor="Red" Font-Size="Medium" runat="server"></asp:Label>
                                        </div>
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

