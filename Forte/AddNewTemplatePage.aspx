<%@ Page Title="" Language="C#" MasterPageFile="~/ForteQuest.Master" AutoEventWireup="true" CodeBehind="AddNewTemplatePage.aspx.cs" Inherits="ForteQuest.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style32 {
            width: 258px;
        }
        .auto-style34 {
            height: 21px;
            width: 258px;
        }
        .auto-style37 {
            width: 325px;
        }
        .auto-style39 {
            height: 21px;
            width: 325px;
        }
        .auto-style46 {
            margin-left: 0px;
        }
        .auto-style47 {
            width: 284px;
        }
        .auto-style49 {
            height: 21px;
            width: 284px;
        }
        .auto-style50 {
            height: 21px;
        }
        .auto-style51 {
            height: 53px;
        }
        .auto-style52 {
            width: 284px;
            height: 28px;
        }
        .auto-style53 {
            width: 325px;
            height: 28px;
        }
        .auto-style54 {
            width: 258px;
            height: 28px;
        }
        .auto-style55 {
            width: 284px;
            height: 22px;
        }
        .auto-style56 {
            width: 325px;
            height: 22px;
        }
        .auto-style57 {
            width: 258px;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <br />
    <table class="w-100">
        <tr>
            <td class="auto-style47">
                &nbsp;</td>
            <td class="auto-style37">
                &nbsp;</td>
            <td class="auto-style32">      
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Button ID="AddNewActivity" runat="server" CssClass="btn btn-success" OnClick="AddNewActivity_Click" Text="Add New Activity" />

            </td>
            </tr>
        <tr>
            <td class="auto-style47">
                &nbsp;</td>
            <td class="auto-style37">
                &nbsp;</td>
            <td class="auto-style32">      
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <button id="modalshowbtn" type="button" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#staticBackdrop5" data-target=".bd-example-modal-lg" runat="server">
                    Select Activities for Quest
                </button>
                <!-- Modal -->

                <div class="modal fade" id="staticBackdrop5" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel5" aria-hidden="False">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="staticBackdropLabel5">Activities</h5>
                                <button id="modalclosebtn5" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <table class="w-100">

                                    <tr>
                                        <td colspan="2"><strong>Select Activities For Quest</strong></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td ><strong>RIASEC Activities</strong></td>
                                        <td ><strong>Other Activities</strong></td>
                                    </tr>
                                    <tr >
                                        <td >
                                            <asp:CheckBoxList ID="RIASEC_Activities" runat="server" DataSourceID="RIASEC" DataTextField="ActivityName" DataValueField="ActivityName">
                                            </asp:CheckBoxList>
                                            <asp:SqlDataSource ID="RIASEC" runat="server" ConnectionString="<%$ ConnectionStrings:ForteQuestXConnectionString %>" SelectCommand="SELECT DISTINCT ActivityName FROM Activities1 WHERE (ActivityType LIKE 'RIASEC')"></asp:SqlDataSource>
                                        </td>
                                        <td >
                                            <asp:CheckBoxList ID="Other_Activities" runat="server" DataSourceID="Others" DataTextField="ActivityName" DataValueField="ActivityName">
                                            </asp:CheckBoxList>
                                            <asp:SqlDataSource ID="Others" runat="server" ConnectionString="<%$ ConnectionStrings:ForteQuestXConnectionString %>" SelectCommand="SELECT DISTINCT ActivityName FROM Activities1 WHERE (ActivityType LIKE 'Others')"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    </table>  
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    <asp:Button ID="Button1" runat="server" Text="Apply" CssClass="btn btn-secondary" OnClick="ApplyBtn_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </td>
            </tr>
            <tr>
            <td class="auto-style47">
                &nbsp;</td>
            <td class="auto-style37">
                &nbsp;</td>
            <td class="auto-style32">
                &nbsp;</td>
        </tr>
            <tr>
            <td class="auto-style51" colspan="3" style="text-align:center">
                <asp:UpdatePanel ID="Subtraitup" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="TraitDropDown" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="TraitSelected" Height="35px" CssClass="btn btn-light dropdown-toggle" style="margin-left: 0px" Width="170px">
                            <asp:ListItem>Select Trait</asp:ListItem>
                            <asp:ListItem>R</asp:ListItem>
                            <asp:ListItem>I</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="SubTraitDropDown" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="SubTraitSelected" Width="200px" Height="35px" CssClass="btn btn-light dropdown-toggle">
                            <asp:ListItem>Select SubTrait</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="Weight" runat="server"></asp:Label>
                        &nbsp;&nbsp; &nbsp;

                     <button id="AddSUbtraitBtn2" runat="server" class="btn btn-dark" data-bs-target="#staticBackdrop3" data-bs-toggle="modal" data-target=".bd-example-modal-lg" type="button" visible="False">
                         +
                     </button>

                    <div class="modal fade" id="staticBackdrop3" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel3" aria-hidden="False">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title" id="staticBackdropLabel3">Add New SubTrait</h5>
                            <button id="modalclosebtn" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                          </div>
                            <div class="modal-body"> 
                                SubTrait Name:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="SubTraitNameTxt" runat="server" ></asp:TextBox>
                                <br />
                                <br />
                                SubTrait Weight:&nbsp;&nbsp;<asp:TextBox ID="SubTraitWeightTxt" runat="server" TextMode="Number"></asp:TextBox>
            
                            </div>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                              <asp:Button ID="Button4" runat="server" Text="Add" CssClass="btn btn-primary" data-bs-dismiss="modal" OnClick="AddSubtraitBtn_Click"/>
       
                           </div>
                      </div>
                    </div>
                          </div>
                        &nbsp;<asp:Button ID="RemoveSubtraitBtn" class="btn btn-dark" runat="server" OnClick="RemoveSubTraiBtn_Click" Text="-" Visible="False" Height="35px" Width="35px" />
                        <br />
                        <br />
                        <asp:DropDownList ID="Activity1DD" runat="server" AutoPostBack="True" Height="35px" CssClass="btn btn-light dropdown-toggle" Width="200px">
                            <asp:ListItem>Select Activity</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:TextBox ID="Activity1WeightageTxt" runat="server" CssClass="auto-style46" TextMode="Number" Width="104px" Height="35px"></asp:TextBox>
                        
                        <asp:Button ID="AddActivityBtn" runat="server" OnClick="AddActivityBtn_Click" Text="Add" Visible="False" CssClass="btn btn-primary" Height="35px" />
                        <br />
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="TraitDropDown" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="AddActivityBtn" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="RemoveSubtraitBtn" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="SubTraitDropDown" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>                        
                    </Triggers>

                </asp:UpdatePanel>
                </td>
        </tr>
            <tr>
            <td class="auto-style52">
                </td>
            <td class="auto-style53">
                </td>
            <td class="auto-style54">
                </td>
        </tr>
            <tr>
            <td class="auto-style55">
                </td>
            <td class="auto-style56">
                </td>
            <td class="auto-style57" aria-haspopup="True">
                </td>
        </tr>
            <tr>
            <td class="auto-style50" colspan="3" style="text-align:center">
                <asp:Button ID="SaveAllBtn" runat="server" CssClass="btn btn-danger" OnClick="SaveAllBtn_Click" Text="Save" />
                <br />
                </td>
        </tr>
            <tr>
            <td class="auto-style49" >
                &nbsp;</td>
            <td class="auto-style39" >
                &nbsp;</td>
            <td class="auto-style34" >
                &nbsp;</td>
        </tr>
            <tr>
            <td class="auto-style49" >
                &nbsp;</td>
            <td class="auto-style39" >
                &nbsp;</td>
            <td class="auto-style34" >
                &nbsp;</td>
        </tr>
            </table>

        <br />

  
    
    </asp:Content>
