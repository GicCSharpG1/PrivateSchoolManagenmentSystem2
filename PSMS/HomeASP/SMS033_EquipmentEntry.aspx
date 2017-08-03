<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS033_EquipmentEntry.aspx.cs" Inherits="HomeASP.SMS033" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Equipment Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $(".datetextbox").datepicker();
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 65px;
            height: 46px;
        }
        .auto-style2 {

            width: 26px;
        }
        .auto-style3 {
            width: 22px;
        }
        .auto-style4 {
            height: 46px;
        }
        .auto-style5 {
            width: 26px;
            height: 46px;
        }
        .auto-style6 {
            width: 22px;
            height: 46px;
        }
    </style>
</head>
<body style="background-image: url(Images/bg.jpg)">
    <div id="main_bot" style="background-image: url(Images/bottom.gif)">
        <div id="main" style="background-image: url(Images/top.gif)">

            <!-- header begins -->
            <!-- #include file="~/HtmlPages/AdminHeader.html" -->
            <!-- header ends -->

            <!-- content begin -->
            <div id="cmcontent">
                <div id="cmright">
                    <div class="cmtit_bot" style="background-image: url(Images/form_bg.jpg)">
                        <div class="right_b" style="height: 500px; width: 1000px;">
                            <form id="centerForm" runat="server"  style="height: 470px;">
                                <h2>Equipment Entry</h2>
                                <table  style="border-collapse:separate; border-spacing:0 10px;padding-left:10px">
                                    <%--<tr>
                                        <td colspan="4">
                                            <asp:Label ID="errExitmsg" CssClass="errlabel" runat="server"></asp:Label></td>
                                    </tr>--%>
                                    <tr>
                                        <td class="auto-style4">
                                            <asp:Label ID="Label3" CssClass="label" runat="server">Education Year</asp:Label></td>
                                        <td class="auto-style5"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style4">
                                            <asp:DropDownList ID="CoboYear1" CssClass="dropdownlist" runat="server" AutoPostBack="true">
                                                <asp:ListItem>Select Year</asp:ListItem>
                                                <asp:ListItem>2010 - 2011</asp:ListItem>
                                                <asp:ListItem>2011 - 2012</asp:ListItem>
                                                <asp:ListItem>2012 - 2013</asp:ListItem>
                                                <asp:ListItem>2013 - 2014</asp:ListItem>
                                                <asp:ListItem>2014 -  2015</asp:ListItem>
                                                <asp:ListItem>2015 - 2016</asp:ListItem>
                                                <asp:ListItem>2016 - 2017</asp:ListItem>
                                                <asp:ListItem>2017 - 2018</asp:ListItem>
                                                <asp:ListItem>2018 - 2019</asp:ListItem>
                                                <asp:ListItem>2019 - 2020</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td class="auto-style5"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style4">
                                            <asp:Label ID="Label6" CssClass="label" runat="server">Date</asp:Label></td>
                                        <td class="auto-style5"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style4">
                                            <asp:TextBox CssClass="datetextbox textbox" ID="EqpDate" runat="server"/></td>
                                        <td class="auto-style6"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style4">
                                            <asp:Label ID="LabEqpName" CssClass="label" runat="server">Equipment Name</asp:Label></td>
                                        <td class="auto-style5"><span style="margin-left: 1em"></span></td>
                                        <td class="auto-style4">
                                            <asp:DropDownList ID="CoboEquipName" CssClass="dropdownlist" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
                                                <asp:ListItem Value="  " Text="    "></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td class="auto-style1" style="text-align: center">
                                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/SMS014_EquipmentTitleEntry.aspx" runat="server" Style="text-align: center">Entry</asp:HyperLink></td>
                                    </tr>
                                    <%--<tr>
                                        <td colspan="2">
                                            <asp:Label ID="errYear" CssClass="errlabel" runat="server"></asp:Label></td>
                                        <td class="auto-style1"><span style="margin-left: 3em"></span></td>
                                        <td colspan="2">
                                            <asp:Label ID="errDate" CssClass="errlabel" runat="server"></asp:Label></td>
                                    </tr>--%>
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="LabQty" CssClass="label" runat="server">Quantity</asp:Label></td>
                                        <td class="auto-style2"><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox ID="TxtQty" CssClass="textbox" AutoPostBack="true" OnTextChanged="removeErrorMsg" runat="server"></asp:TextBox></td>
                                         <td class="auto-style2"><span style="margin-left: 1em"><asp:Label ID="errQty" cssClass="errLabel" runat="server"></asp:Label></span>
                                             </td>
                                         <td>
                                            <asp:Label ID="LabType" CssClass="label" runat="server">Type</asp:Label></td>
                                        <td class="auto-style2"><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox ID="TxtType" CssClass="textbox" runat="server"/></td>
                                        <td class="auto-style3"><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:Label ID="LabRemark" CssClass="label" runat="server">Remark</asp:Label></td>
                                        <td class="auto-style2"><span style="margin-left: 1em"></span></td>
                                        <td>
                                            <asp:TextBox ID="TxtRemark" CssClass="textbox" runat="server"></asp:TextBox> </td>
                                        
                                    </tr>
                                    <%--<tr>
                                        <td colspan="2">
                                            <asp:Label ID="errEqN" CssClass="errlabel" runat="server"></asp:Label></td>
                                        <td class="auto-style1"><span style="margin-left: 3em"></span></td>
                                        <td colspan="2">
                                            <asp:Label ID="errQty" CssClass="errlabel" runat="server"></asp:Label><asp:Label ID="errNum" CssClass="errlabel" runat="server"></asp:Label></td>

                                    </tr>--%>
                                </table>

                                <div id="Div2" runat="server" style="padding: 10px 10px 10px 10px; height: 270px">
                                    <asp:GridView ID="EqpList" class="gridview" runat="server" CellPadding="4" GridLines="None"
                                        ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." OnPageIndexChanging="EqpList_PageIndexChanging" PageSize="5" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
                                        <AlternatingRowStyle Wrap="False" BackColor="White" />
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
                                        <Columns>
                                            <asp:BoundField HeaderText="DATE"
                                                DataField="DATE"
                                                SortExpression="DATE" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                            <asp:BoundField HeaderText="EQUIPMENT"
                                                DataField="EQUIPMENT_ID"
                                                SortExpression="EQUIPMENT_ID"></asp:BoundField>
                                            <asp:BoundField HeaderText="QUANTITY"
                                                DataField="QUANTITY"
                                                SortExpression="QUANTITY"></asp:BoundField>
                                            <asp:BoundField HeaderText="TYPE"
                                                DataField="TYPE"
                                                SortExpression="TYPE"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="BtnUpdate" runat="server" Text="Edit" CommandName='<%# Eval("ID") %>' OnClick="btnEquipmentEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="BtnDelete" runat="server" Text="Delete" CommandName='<%# Eval("ID") %>' OnClick="btnEquipmentDelete_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="errYear" ControlToValidate="TxtQty" ErrorMessage="Please enter Quantity" cssClass="errLabel"></asp:RequiredFieldValidator>--%>
                                    <asp:Label ID="errorSeach" cssClass="errLabel" runat="server"></asp:Label>
                                    <asp:Label ID="alertMsg" cssClass="errLabel" runat="server"></asp:Label>
                                     
                                  <%--  <asp:RequiredFieldValidator runat="server" ID="errQty" ControlToValidate="TxtQty" ErrorMessage="Please Choose " cssClass="errLabel"></asp:RequiredFieldValidator>--%>
                                    &nbsp;
                                </div>
                                <div style="padding-left:670px">
                                    <asp:Button ID="BtnSave" Text="Save" runat="server" CssClass="btn" OnClick="btnSave_Click" />
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="BtnCancel_Click" style="margin-left:15px"/>
                                    <br />
                                </div>
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

