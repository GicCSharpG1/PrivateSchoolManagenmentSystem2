<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM0037_PositionEntry.aspx.cs" Inherits="HomeASP.SM0037_PositionEntry" %>

<!-- Layout -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS Equipment Title Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
     <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/StudentStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link href="styles/CashStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
   

    <%--<script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>--%>
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
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                        <h2>Position Entry</h2>
                                        <div style="float: left; margin-bottom: 25px; margin-left: 20px">
                                            <table style="margin-bottom: 15px; margin-left:30px; font: 19px Verdana, Helveticaall-petite-caps; color: #074959; padding-left: 7px">
                                              <tr>
                                                  <td>
                                                      &nbsp;Education Year* 
                                                  </td>

                                                  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                  <td>
                                                    <asp:DropDownList ID="poEducation" runat="server" ForeColor="Black" CssClass="dropdownlist">
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
                                                 <td> <asp:Label ID="ErrorYear" runat="server" Visible="false" ForeColor="Red">Please Choose Education Year!!</asp:Label></td>
                                              </tr>  
                                               
                                               <tr>
                                                   <td>
                                                       &nbsp;Position Name*
                                                   </td>
                                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                   <td>
                                                       <asp:TextBox ID="poName" runat="server" ForeColor="Black" CssClass="textbox"></asp:TextBox>
                                                   </td>
                                                    <td>  <asp:Label ID="ErrorPosition" runat="server" Visible="false" ForeColor="Red">Please Enter Position Name!!</asp:Label></td>

                                                   <td><asp:Label ID="LabelID" CssClass="label" Visible="false" runat="server">ID</asp:Label></td>
                                               </tr>
                                                
                                                     
                                            </table>
                                            <div style="margin-left: 30px;">
                                                <asp:Button ID="BtnEquipSave" ValidationGroup="SaveConfirm" Text="Save" CssClass="btn" runat="server" OnClick="save_Click" />
                                                <asp:Button ID="btnConfirm" ValidationGroup="SaveConfirm" Text="Cancel" CssClass="btn" Style="margin-left: 15px" runat="server" OnClick="confirm_Click" />
                                            </div>
                                            <br /><br />
                                            <asp:Label runat="server" ID="alertMsg" Font-Size="Medium"  style="margin-left:10px;color:red"></asp:Label>
                                        </div>
                                        <div id="Div2" style="margin-bottom: 25px; margin-left:30px" runat="server">
                                            <asp:GridView ID="PosMstList" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No expense entry!!" AllowPaging="True" PageSize="5" OnPageIndexChanging="PosList_PageIndexChanging" ReadOnly="false" CssClass="gridview1" OnRowCommand="PosList_RowCommand" runat="server" Width="70%" CellPadding="6" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3" Style="margin-top: 15px">
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
                                                    <asp:BoundField DataField="POSITION_ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="POSITION_NAME" HeaderText="Position Name" />
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

                <!-- footer begins -->
                <!-- #include file="~/HtmlPages/Footer.html" -->
                <!-- footer ends -->
            </div>
        </div>
    </div>
</body>
</html>
