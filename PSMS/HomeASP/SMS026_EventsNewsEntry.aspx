<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS026_EventsNewsEntry.aspx.cs" Inherits="HomeASP._SMS026" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Metamorphosis PSMS Home</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link rel="stylesheet" href="styles/jquery-ui.css">
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>

</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">
            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html"-->
            <!-- header ends -->

            <!-- content begins-->
            <!-- header ends -->

            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                <h2>Events And News Entry</h2>
                                <table style="margin: 0px 0px 0px 50px; border-collapse: separate; border-spacing: 0 10px;">
                                    <tr>
                                        <td rowspan="6">
                                            <asp:Image runat="server" ID="staffpicture" Style="margin-left: 20px;" Height="152px" ImageUrl="~/Images/Profile.png" Width="139px" /><br />
                                            <asp:FileUpload ID="FileUpload1" runat="server" Height="32px" Style="margin-left: 25px" onchange="this.form.submit();" />
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="News" runat="server" GroupName="Type" Text="News" /></td>
                                        <td>
                                            <asp:RadioButton ID="Event" runat="server" GroupName="Type" Text="Event" /></td>
                                    </tr>
                                    <tr>
                                        <td align="right">Education Year*</td>
                                        <td>
                                            <asp:DropDownList ID="enEducation" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                                <asp:ListItem>Choose Education Year</asp:ListItem>
                                                <asp:ListItem>2001 - 2002</asp:ListItem>
                                                <asp:ListItem>2002 - 2003</asp:ListItem>
                                                <asp:ListItem>2003 - 2004</asp:ListItem>
                                                <asp:ListItem>2004 - 2005</asp:ListItem>
                                                <asp:ListItem>2005 - 2006</asp:ListItem>
                                                <asp:ListItem>2007 - 2008</asp:ListItem>
                                                <asp:ListItem>2008 - 2009</asp:ListItem>
                                                <asp:ListItem>2009 - 2010</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date*<asp:TextBox CssClass="datepicker textbox" ID="edate" Style="color: black" runat="server" />
                                        </td>
                                        <td style="width: 162px; height: 21px;">*<asp:DropDownList ID="grade" runat="server" ForeColor="Black" CssClass="dropdownlist">
                                            <asp:ListItem>Choose Grade</asp:ListItem>
                                            <asp:ListItem>Grade 1</asp:ListItem>
                                            <asp:ListItem>Grade 2</asp:ListItem>
                                            <asp:ListItem>Grade 3</asp:ListItem>
                                            <asp:ListItem>Grade 4</asp:ListItem>
                                            <asp:ListItem>Grade 5</asp:ListItem>
                                            <asp:ListItem>Grade 6</asp:ListItem>
                                            <asp:ListItem>Grade 7</asp:ListItem>
                                            <asp:ListItem>Grade 8</asp:ListItem>
                                            <asp:ListItem>Grade 9</asp:ListItem>
                                            <asp:ListItem>Grade 10</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>Name*<asp:TextBox ID="name" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox></td>

                                        <td>*<asp:DropDownList ID="room" runat="server" ForeColor="Black" OnSelectedIndexChanged="room_SelectedIndexChanged" CssClass="dropdownlist">
                                            <asp:ListItem>Choose Room</asp:ListItem>
                                            <asp:ListItem>A</asp:ListItem>
                                            <asp:ListItem>B</asp:ListItem>
                                            <asp:ListItem>C</asp:ListItem>
                                            <asp:ListItem>D</asp:ListItem>
                                            <asp:ListItem>E</asp:ListItem>
                                            <asp:ListItem>F</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="add" runat="server" Text="Save" OnClick="add_Click" Width="100px" CssClass="btn" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnConfirm" ValidationGroup="SaveConfirm" Text="Canel" CssClass="btn" Style="margin-left: 15px" runat="server" OnClick="confirm_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                    <asp:Label runat="server" ID="errSmsDa" CssClass="errLabel"></asp:Label>
                                    <asp:Label runat="server" ID="LabelID" CssClass="errLabel" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="errSmsRe" CssClass="errLabel"></asp:Label>

                                </div>
                                <div style="margin-left: 20px; height: 270px" class="gridfont ">
                                    <asp:GridView ID="gridViewEvent" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record." AllowPaging="True" PageSize="5" OnPageIndexChanging="EventNews_PageIndexChanging" ReadOnly="false" CssClass="gridview" OnRowCommand="EventNews_RowCommand" runat="server" Width="95%" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" Style="margin-top: 15px">

                                        <AlternatingRowStyle Wrap="False" BackColor="White" />
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#D2EEEA" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        <Columns>


                                            <asp:BoundField HeaderText="Edu Year" DataField="EDU_YEAR"></asp:BoundField>
                                            <asp:BoundField HeaderText="ID" DataField="ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Date" DataField="DATE"></asp:BoundField>
                                            <asp:BoundField HeaderText="Name" DataField="NAME"></asp:BoundField>
                                            <asp:BoundField HeaderText="Grade ID" DataField="GRADE_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Room ID" DataField="ROOM_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="Type" DataField="TYPE"></asp:BoundField>
                                            <asp:BoundField HeaderText="Photo" DataField="PHOTO_PATH"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnUpdate" runat="server" Text="Edit" CommandName="EditCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
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
                                     <div>
                                    
                                </div>
                                    <br />
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
                <div id="footer" style="background-image: url(Images/footer.jpg)">
                    Copyright  2010. Designed by <a href="http://www.metamorphozis.com/" title="Flash Templates">Flash Templates</a><br />
                    <a href="#">Privacy Policy</a> | <a href="#">Terms of Use</a> | <a href="http://validator.w3.org/check/referer" title="This page validates as XHTML 1.0 Transitional">
                        <abbr title="eXtensible HyperText Markup Language">XHTML</abbr></a> | <a href="http://jigsaw.w3.org/css-validator/check/referer" title="This page validates as CSS">
                            <abbr title="Cascading Style Sheets">CSS</abbr></a>
                </div>
                <!-- footer ends -->
            </div>
        </div>
    </div>
</body>
</html>
