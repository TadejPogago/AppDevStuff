<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Froilan_AppDevLec_FinalsActivity2_2_.Default" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <rsweb:ReportViewer 
                ID="ReportViewer1" runat="server" Width="100%" 
                Height="700px" 
                AsyncRendering="false"
                SizeToReportContent="true">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
