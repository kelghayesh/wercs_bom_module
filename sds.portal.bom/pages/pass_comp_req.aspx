<%@ Page Async="true" Title="Depot Client Test" Language="C#" MasterPageFile="~/_master/aspx.master" AutoEventWireup="true" CodeBehind="pass_comp_req.aspx.cs" Inherits="SDS.SDSRequest.DepotClientPage.pass_comp_req" %>
<asp:Content ID="body_content_holder" ContentPlaceHolderID="body_content_holder" runat="server">
    <div >
        <br /><br /><br />
    </div>
  

    <table border="0">
    <tr>
    <td>
        <asp:Label runat="server" valign="top">Enter a list of valid Product Keys:</asp:Label>
    </td>
    <td>
    </td>
    </tr>

    <tr>
    <td>
        <!--<textarea ID="txtGCASCodex" Width="150" runat="server" value="95413901, 95515790, 95716177, 95773437, 95912053" />-->
        <textarea style="width:250px; height:200px;" id="txtGCASCodes" runat="server" value="" />
    </td>
   
<!--
    <td valign="top">
        <label for="txtLowerLimitValidation">Formula Lower% Limit:</label>
        <input type="text" style="width:50px;" id="txtLowerLimitValidation" runat="server" value="98" disabled="disabled" /> 
        
        <br />
        <label for="txtUpperLimitValidation">Formula Upper% Limit:</label>
        <input type="text" style="width:50px;" id="txtUpperLimitValidation" runat="server" value="120" disabled="disabled" />
    </td>
-->
    </tr>
<!--
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2"><input type="checkbox" id="chkRMOnly" runat="server"/>
            <label for="chkRMOnly">Stage Raw Materials Only</label>
        </td>
    </tr>
-->
    <tr>
        <td colspan="2"></td>
    </tr>
    
    <tr>
        <td colspan="2"><input type="checkbox" id="chkAllowResultWhenBosErrors" runat="server"/>
            <label for="chkAllowResultWhenBosErrors">Allow Results with BOS Errors (applies to entire request)</label> 
        </td>
    </tr>

    <tr>
     <td colspan="2"><br />
        <asp:Button ID="cmdStageGCASFormulae" OnClick="cmdStageGCASFormulae_Click" runat="server" Text="Stage Formula" /> 

        <a href="#" class="my_controller_action" onserverclick="cmdSearchStaged_Click" runat="server">Search Staged Formula</a>

         <!-- <a href="@Url.Action("RequestQueueIndex","FormulaImportRequest", new { id = 0, productKeyList='90726028,90699482,91186728,90799531', sourceSystem='Depot' })">Search Staged SDS #2</a> -->
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
