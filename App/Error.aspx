<%@ Page Title="404" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron banner">
        <h1>404 - Pagina niet gevonden</h1>
        <p class="subtext">U bent naar een pagina genavigeerd die niet bestaat. Hieronder kunt u naar een straat zoeken.</p>
        <div class="field_container">
            <form method="post" action="Default.aspx">
                <input type="text" id="search" runat="server" name="search" placeholder="Vul een adres in..." autofocus />
                <div class="btn_container">
                    <button class="search_btn">
                        <span class="glyphicon glyphicon-search"></span>
                    </button>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

