<%@ Page Title="" Language="C#" MasterPageFile="~/ForteQuest.Master" AutoEventWireup="true" CodeBehind="AddNewActivityPage.aspx.cs" Inherits="ForteQuest.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style35 {
            height: 31px;
        }
        .auto-style46 {
            height: 51px;
        }
        .auto-style47 {
            height: 45px;
        }
        .auto-style49 {
            height: 53px;
        }
        .auto-style60 {
            height: 19px;
        }
        .auto-style63 {
            height: 53px;
            width: 2571px;
        }
        .auto-style64 {
            height: 32px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:ScriptManager ID="sm" runat="server">
     </asp:ScriptManager>
     <table class="w-100">
        <tr>
            <td class="auto-style47" style="text-align:center"><h4><strong> Add New Activity</strong></h4></td>
        </tr>
        <tr>
            <td class="auto-style60"></td>
        </tr>
        <tr>
            <td class="auto-style35" style="text-align:center">Activity Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="ActivityNametxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ActivityNametxt" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:center" class="auto-style47">Duration (mins):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Durationtxt" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Durationtxt" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style46" style="text-align:center">
                Activity Type:
                <asp:DropDownList ID="ActivityType" runat="server" CssClass="btn btn-light dropdown-toggle">
                    <asp:ListItem>RIASEC</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style49" style="text-align:center">
                MaxScore:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="MaxScore" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="MaxScore" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:center" class="auto-style63">
                <asp:UpdatePanel ID="IsTeamup" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <br />
                        <asp:DropDownList ID="IsTeamDD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="IsTeamDD_Selected" CssClass="btn btn-light dropdown-toggle">
                            <asp:ListItem>Individual</asp:ListItem>
                            <asp:ListItem>Team</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="TeamEffort" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Team" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Team" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="IndividualEffort" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Individual" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Individual" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        &nbsp;
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="IsTeamDD" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>

        <tr>
            <td style="text-align:center" class="auto-style64">
                </td>
        </tr>

                     <tr>
                         <td style="text-align: center">
                             <asp:Button ID="SaveBtn" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="SaveBtn_Click" />
                         </td>
                     </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>


<%--<script>
$(document).ready(function ()  
{  
    $('#SaveBtn').click(function ()
     {  
        var Name, duration, MaxScore, Team, Individual;  
        Name = $("#ActivityNametxt").val();
        duration = $("#Durationtxt").val();  
        MaxScore = $("#MaxScore").val();
        Team = $("#Team").val();
        Individual = $("#Individual").val();
        if (Name == '' && duration == 0 && MaxScore == '') {
            alert("Enter All Fields");
            return false;
        }
    })  
}); 
</script>--%>
</asp:Content>
