<%@ Page Async="true" Title="BOM Request Result" Language="C#" MasterPageFile="~/_master/aspx.master" AutoEventWireup="true" CodeBehind="target_bom_result.aspx.cs" Inherits="SDS.Portal.Web.pages.target_bom_result" %>
<asp:Content ID="body_content_holder" ContentPlaceHolderID="body_content_holder" runat="server">
    <meta http-equiv="refresh" content="10">
    <div style="width:100%">
        <br /><br /><br />
    </div>

    <div>
        <br />
        <!-- <a href="javascript:window.location.reload(true)"> Click here to refresh page</a> -->
        <input type="button" value="Refresh Page" onClick="window.location.reload();">
        &nbsp;
        <input type="button" id="cmdStartDTE" runat="server" Value="Restart DTE" onserverclick="cmdStartDTE_click" /> 
        <br /><br />
        <asp:Label runat="server" ID="lblBOMResultLabel"></asp:Label> 
        <br />
    </div>

    <div>
    <asp:gridview ID="grdvTargetBOMHeaderResult" HeaderStyle-BackColor="#FFF333" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Calibri" runat="server"></asp:gridview>
    </div>

    <div style="width:100%">
        <br /><br /><br />
    </div>

    <div>
    <asp:gridview ID="grdvTargetBOMDetailErrorResult" HeaderStyle-BackColor="#FFF333" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Calibri" runat="server"></asp:gridview>
    </div>

    <div> 
        <!-- <input type="button" id="cmdProcessBOMRequest" runat="server" Value="Re-Process Request" onserverclick="cmdProcessBOMRequest_click" />  -->
        <input type="hidden" id="htmlRequestId" runat="server" value="0" />
        <input type="hidden" id="htmlTargetFormulaKey" runat="server" value="" />
    </div>

    <div>
        <br />
        <a href="target_bom_req.aspx">Create Another BOM Request</a>
        <br /><br />
    </div>

</asp:Content>
