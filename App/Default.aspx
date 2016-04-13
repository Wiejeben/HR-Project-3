﻿<%@ Page Title="Homepage" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron banner">
        <h1>Op zoek naar een straat?</h1>
        <div class="field_container">
            <form method="post" action="Default.aspx">
                <input type="text" id="search_ac" runat="server" name="search" class="search_ac" placeholder="Vul een adres in..." autofocus="autofocus" />
                <div class="btn_container">
                    <button class="search_btn">
                        <span class="glyphicon glyphicon-search"></span>
                    </button>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

