<%@ Page Async="true" Title="BOM Request Generation" Language="C#" MasterPageFile="~/_master/aspx.master" AutoEventWireup="true" CodeBehind="target_bom_req.aspx.cs" Inherits="SDS.Portal.Web.pages.create_target_bom_req" %>

<asp:Content ID="body_content_holder" ContentPlaceHolderID="body_content_holder" runat="server">
    <div style="width:100%">
        <br /><br /><br />
    </div>
  

    <table style="width:100%" border="0" >
    <!--
    <tr>
    <td align="right">
        <a href="pass_comp_req.aspx">Create Simple Formula Request</a>
        <br /><br />
    </td>
    </tr>
    -->
    <tr>
    <td>
        <asp:Label valign="top">Target Formula Key:</asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <input style="width:450px;" id="txtTargetBOM" runat="server" value="" />
    </td>
    </tr>

    <tr> <td ><br /> </td></tr>

    <tr>
    <td>
        <asp:Label>List of Materials, on the format RM, Percent; (example: 90791941_DEPOT,20):</asp:Label>
    </td>
    </tr>

    <tr>
    <td>
        <textarea style="width:450px;" cols="50" rows="15" id="txtRMList" runat="server" />
            <!-- value="90791941_DEPOT,20 &#13; 91986616_DEPOT,70 &#13; EXP-19-ES7753_RANDD_CLP,10" -->
    </td>
    </tr>
    <tr>
     <td><br />
        <asp:Button ID="cmdStageBOM" OnClick="cmdStageBOM_Click" runat="server" Text="Generate BOM" /> 
    </td>

    </tr>

    </table>
    <div class="form-group">

    </div>

    <div id="PassResultDisplayDiv" runat="server"></div>

    <div>
    <asp:gridview ID="grdvPassResult" HeaderStyle-BackColor="#FFF333" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Calibri" runat="server"></asp:gridview>
    </div>

</asp:Content>
