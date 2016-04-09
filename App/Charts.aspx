<%@ Page Title="Charts" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Charts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Charts</h1>

    <div class="chart">
        <canvas id="canvas" height="450" width="600"></canvas>
    </div>
</asp:Content>
