<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS021_ClassTimetableEntry.aspx.cs" Inherits="HomeASP.SMS021" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>PSMS ClassTimeTable Entry</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="styles/HomeStyle.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/CommonStyles.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/classtimetable.css" rel="stylesheet" title="Default Styles" media="screen" type="text/css" />
    <link href="styles/LoginStyles.css" rel="Stylesheet" title="Default Styles" media="screen" type="text/css" />

    <link rel="stylesheet" href="styles/jquery-ui.css" />
    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".textbox").datepicker();
        });        
    </script>
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
                        <div class="right_b" style="height: 520px; width: 965px; clear: both">
                            <form id="centerForm" runat="server" style="height: 485px;">
                                 <h2>Teacher Timetable Entry</h2>
                                <table class="table_style" style="margin:15px">
                                    <%--<tr>
                                        <td colspan="2" class="td_width">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="validatorgrade" runat="server" ControlToValidate="ddltimegradelist" ErrorMessage="Please select grade !" InitialValue="0" CssClass="errlabel"></asp:RequiredFieldValidator></td>
                                        <td><span style="margin-left: 5em"></span></td>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="validatorteacher" runat="server" ControlToValidate="ddlTeacherList" ErrorMessage="Please select teacher !" InitialValue="0" CssClass="errlabel"></asp:RequiredFieldValidator></td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Grade*" Width="100px"></asp:Label></td>
                                       
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddltimegradelist" runat="server" AppendDataBoundItems="True" ForeColor="#003300" OnSelectedIndexChanged="ddltimegradelist_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 5em"></span></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Teacher*"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlTeacherList" runat="server" ForeColor="Black" AppendDataBoundItems="True">
                                            </asp:DropDownList></td>

                                    </tr>
                                    <%--<tr>
                                        <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="validatorsubject" runat="server" ControlToValidate="ddlsubjectlist" ErrorMessage="Please select subject !" InitialValue="0" CssClass="errlabel"></asp:RequiredFieldValidator></td>
                                        <td><span style="margin-left: 5em"></span></td>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="validatoreduyear" runat="server" ControlToValidate="ddleduyearlist" ErrorMessage="Please select Edu Year !" InitialValue="Select Edu Year" CssClass="errlabel"></asp:RequiredFieldValidator></td>
                                    </tr>--%>
                                    <tr>
                                        <td class="td_width">
                                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Subject*"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlsubjectlist" runat="server" AutoPostBack="True" Enabled="False" ForeColor="Black">
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 5em"></span></td>
                                        <td class="edutd_width">
                                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="Education Year*"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddleduyearlist" runat="server">
                                                <asp:ListItem>Select Edu Year</asp:ListItem>
                                                <asp:ListItem>2011 - 2012</asp:ListItem>
                                                <asp:ListItem>2012 - 2013</asp:ListItem>
                                                <asp:ListItem>2013 - 2014</asp:ListItem>
                                                <asp:ListItem>2014 - 2015</asp:ListItem>
                                                <asp:ListItem>2015 - 2016</asp:ListItem>
                                                <asp:ListItem>2016 - 2017</asp:ListItem>
                                                <asp:ListItem>2017 - 2018</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                       
                                    </tr>
                                </table>
                                <table class="table_style" style="margin:15px">
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="rfvTimetableDate" runat="server" ControlToValidate="txttimetabledate" ErrorMessage="Please select Date !" CssClass="errlabel" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Date"></asp:Label></td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txttimetabledate" Style="color: black" runat="server" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="auto-style1">
                                            <asp:CustomValidator ID="cvPeriod" runat="server" OnServerValidate="ValidatePeriod"
                                                ErrorMessage="Please Select at least one period!" CssClass="errlabel" ForeColor="red"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label6" CssClass="label" runat="server" Text="Period 1"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass1" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td><span style="margin-left: 60px" /></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label10" CssClass="label" runat="server" Text="Period 5" Width="130px"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass5" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style4"></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label7" CssClass="label" runat="server" Text="Period 2"></asp:Label></td>
                                        <td class="auto-style1">
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass2" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td><span style="margin-left: 2em" /></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label11" CssClass="label" runat="server" Text="Period 6"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass6" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label8" CssClass="label" runat="server" Text="Period 3"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass3" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td><span style="margin-left: 2em" /></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label12" CssClass="label" runat="server" Text="Period 7"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass7" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="td_width">
                                            <asp:Label ID="Label9" CssClass="label" runat="server" Text="Period 4"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList CssClass="dropdownlist" ID="ddlclass4" runat="server">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td class="auto-style2"></td>
                                       
                                        <td class="auto-style2">

                                           
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Button1_Click" CssClass="btn" />
                                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Visible="False" CssClass="btn" /></td>
                                        <td class="auto-style2">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Button2_Click" CssClass="btn" CausesValidation="false" /></td>
                                    </tr>
                                </table>
                                
                                <asp:GridView ID="dvtimetable" runat="server" CssClass="gridview" GridLines="None" AllowPaging="True" PageSize="5"
                                    DataKeyNames="ID" OnRowDeleting="Delete" OnSelectedIndexChanging="Edit" OnPageIndexChanging="dvtimetable_PageIndexChanging" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="There is no record." CellPadding="4" ForeColor="#333333">
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
                                        <asp:BoundField HeaderText="GRADE"
                                            DataField="GRADE_ID"
                                            SortExpression="GRADE_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="TEACHER"
                                            DataField="TEACHER_ID"
                                            SortExpression="TEACHER_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="DATE"
                                            DataField="DAY"
                                            SortExpression="DAY"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 1"
                                            DataField="PERIOD1"
                                            SortExpression="PERIOD1"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 2"
                                            DataField="PERIOD2"
                                            SortExpression="PERIOD2"></asp:BoundField>
                                        <asp:BoundField HeaderText="PERIOD 3"
                                            DataField="PERIOD3"
                                            SortExpression="PERIOD3"></asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="true" ShowSelectButton="true" />
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
            <!-- #include file="~/HtmlPages/Footer.html" -->
            <!-- footer ends -->
        </div>
    </div>
</body>
</html>

