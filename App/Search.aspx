<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron banner">
        <h1>Zoekresultaten voor de zoekterm: '<%: query %>'</h1>
        <div class="field_container">
            <form method="post" id="search_func" autocomplete="off" action="Default.aspx">
                <input id="search_ac" runat="server" name="search" class="search_ac" placeholder="Vul een adres in..." autofocus="autofocus" onfocus="this.value = this.value;" />
                <div class="btn_container">
                    <button class="search_btn">
                        <span class="glyphicon glyphicon-search"></span>
                    </button>
                </div>
                <div class="search_dropdown">
                    <p class="hidden">Er zijn geen zoekresultaten.</p>
                </div>
            </form>
        </div>
    </div>

    <div class="row">
        <section class="col-md-12">
            <%
                if (results != null && results.Count > 0)
                {
                    foreach (Street result in results)
                    { %>
                        <article class="search_result">
                            <a href="/Street.aspx?hid=<%: result.ID %>" class="search_container">
                                <h2><%: result.Name %></h2>
                                <p class="intro_text"><%: result.Intro %></p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>
                        </article>
                <%  
                    }
                } else { %>
                    <h2>Er zijn geen resultaten gevonden.</h2>
                <% } %>
        </section>
    </div>
</asp:Content>

