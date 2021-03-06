﻿<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="PassUpDate.aspx.cs" Inherits="SMS.SMSAdmin.PassUpDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Pass Update</span></div>
        <div id="divErr" runat="server">
            <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
             ForeColor="Red"></asp:Label>
        </div>
            <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
            <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
        
        <asp:TextBox ID="txtpass_id" runat="server" Visible="False"></asp:TextBox>
        
      <br />  
      <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750">
        <table id="tblMain" width="750px">
        
     
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblPassNo" Text="Pass No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUpdatePassNo" runat="server" CssClass="Input" 
                                                            Readonly="True" BackColor="#E2E2E2" />
                                                    </td>
                                                   
                                                    <td>
                                                        <asp:Label ID="lblPassType" Text="Pass Type" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                    <asp:DropDownList ID="ddlAddPassType" runat="server" CssClass="Input" 
                                                        width="136px" >                                                
                                                       
                                                    </asp:DropDownList>
                                                    </td>
                                            </tr>
                                            <tr>    
                                                    <td valign="top">
                                                        <asp:Label ID="lblPassDescription" Text="Description" CssClass="Labels" 
                                                            runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtUpdatePassDescription" runat="server" CssClass="Input" 
                                                            Height="65px" Width="76%" TextMode="MultiLine" />
                                                    </td>
   
                                       <tr>
                                             <td height="70px" width="120px">&nbsp;</td>
                                       </tr>    
                                      <tr>  
               
                                                <td align="Center" colspan="4">
                                                <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)"> 
                                                <tr><td>
                                                     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" 
                                                         OnClick="btnSave_Click" Width="85px" />
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" 
                                                         OnClick="btnBackPassAdmin_Click" Width="85px" />
                                                         </td></tr>
                                                         </table>
                                                </td>
                                               
                                            </tr>
                           
                                    
                             
          
        </table>
        </asp:panel>
        <br />
   </div>
   
</asp:Content>
