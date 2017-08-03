<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS027_ExpenseEntry.aspx.cs" Inherits="HomeASP.SMS027" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Expense Entry</title>
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
    </script>
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <%--header begins--%>
            <!-- #include file="~/HtmlPages/AdminHeader.html"-->
            <%--  header ends --%>

            <div id="cmcontent">
                <%--content begin--%>
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg);height:500px;">
                        <div class="right_b" style="height: 600px; width: 965px;">
                            <div id="container_demo">
                                <div id="wrapper">
                                    <form id="login" runat="server" style="height: 450px; width: 930px; padding: 10px 15px 15px 15px; margin: 10px 0px 0px 0px">
                                        <h2>Expense Entry</h2>
                                        <div style="margin-bottom: 15px">
                                            <table id="cashTbl" runat="server" style="border-collapse:separate; border-spacing:0 10px;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabYear" CssClass="label" runat="server">Education Year*</asp:Label>

                                                       
                                                    </td>
                                                     
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:DropDownList ID="CoboYear" CssClass="dropdownlist" runat="server" AutoPostBack="false">
                                                            <asp:ListItem>Choose Education Year</asp:ListItem>
                                                            <asp:ListItem>2010 - 2011</asp:ListItem>
                                                            <asp:ListItem>2011 - 2012</asp:ListItem>
                                                            <asp:ListItem>2012 - 2013</asp:ListItem>
                                                            <asp:ListItem>2013 - 2014</asp:ListItem>
                                                            <asp:ListItem>2014 - 2015</asp:ListItem>
                                                            <asp:ListItem>2015 - 2016</asp:ListItem>
                                                            <asp:ListItem>2016 - 2017</asp:ListItem>
                                                            <asp:ListItem>2017 - 2018</asp:ListItem>
                                                            <asp:ListItem>2018 - 2019</asp:ListItem>
                                                            <asp:ListItem>2019 - 2020</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td><span style="margin-left: 2em">
                                                          <asp:Label ID="ErrorYear" runat="server" Visible="false" ForeColor="Red">Please Choose Education Year!!</asp:Label>
                                                        <asp:Label runat="server" Visible="false" ID="id"></asp:Label></span></td>
                                                    <td>
                                                        <asp:Label ID="LblExpDate" CssClass="label" runat="server">Date*</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox CssClass="datepicker textbox" ID="cashDate" Style="color: black; margin-left: 0px" runat="server" />
                                                                                                                 <asp:Label ID="ErrorDate" runat="server" Visible="false" ForeColor="Red">Please Choose Date!!</asp:Label>


                                                    </td>
                                                </tr>
                                                <tr>

                                                  

                                                    
                                                   

                                                </tr>
                                               <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errYear" ValidationGroup="group1" ControlToValidate="CoboYear" ErrorMessage="Please choose the year !!" ForeColor="Red" /></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="Label2" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errDatee" ValidationGroup="group1" ControlToValidate="cashDate" ErrorMessage="Please choose the date !!" ForeColor="Red" /></td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabExpTitle" CssClass="label" runat="server">Expense Title </asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtExpTitle" AutoPostBack="false" Style="margin-left: 0px" CssClass="textbox" runat="server" ForeColor="Black"></asp:TextBox></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="LabRe" CssClass="label" runat="server">Remark</asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:TextBox ID="TxtRe" Style="margin-left: 0px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <%--<tr class="spaceUnder">
                                                    <td>
                                                        <asp:Label ID="Label3" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="errTitle" ValidationGroup="group1" ControlToValidate="TxtExpTitle" ErrorMessage="Please enter the Expense Title !!" ForeColor="Red" /></td>
                                                    <td><span style="margin-left: 2em"></span></td>
                                                    <td>
                                                        <asp:Label ID="Label4" CssClass="Lab-format" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="Label5" CssClass="errmsg-format" runat="server"></asp:Label></td>
                                                </tr>--%>
                                            </table>
                                        </div>
                                        <div id="Div2" style="height:270px" runat="server">
                                            <asp:GridView ID="expHedList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="There is no record." AllowPaging="True" PageSize="5" OnPageIndexChanging="EqpList_PageIndexChanging" ReadOnly="false" CssClass="gridview1" OnRowCommand="expList_RowCommand" runat="server" Width="100%" CellPadding="6" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" Style="margin-top: 15px">
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
                                                    <asp:BoundField DataField="EDU_YEAR" HeaderText="Education Year" />
                                                    <asp:BoundField DataField="EXP_ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="EXP_TITLE" HeaderText="Title" />
                                                    <asp:BoundField DataField="EXP_DATE" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" />
                                                    <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDetail" runat="server" Text="Detail" CommandName="DetailCol" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                        </div>
                                        <div>
                                            <asp:Label ID="errEgd" Style="font-size: medium; color: red" runat="server" ></asp:Label>
                                           <%-- <asp:Label ID="errSMS" Font-Size="Small" ForeColor="Red" runat="server">Please Put All error sms</asp:Label>--%>
                                        </div>
                                        <div style="margin-left: 420px;">
                                            <asp:Button ID="BtnPay" ValidationGroup="group1" CssClass="btn" runat="server" Text="Save" Style="text-align: center; border-radius: 3px 3px; margin-right:15px;" OnClick="BtnSave_Click" />
                                            <asp:Button ID="BtnConfirm" ValidationGroup="group1" CssClass="btn" runat="server" Text="confirm" Style="text-align: center; border-radius: 3px 3px; margin-right:15px;" OnClick="BtnConfirm_Click" />
                                            <asp:Button ID="BtnSearch" ValidationGroup="group2" CssClass="btn" runat="server" Text="Search" Style="text-align: center; border-radius: 3px 3px;" OnClick="BtnSearch_Click" />
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

                <%-- footer begins--%>
                <!-- #include file="~/HtmlPages/Footer.html"-->
                <%-- footer ends--%>
            </div>
        </div>
    </div>
</body>
</html>

