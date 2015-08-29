<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Modelo.aspx.cs" Inherits="GMQA.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        O modelo
    </h2>
    <div>
        O modelo parte do princípio que existem três macroatividades que acontecem em 
        qualquer projeto de software. Além disso, o modelo define
        <asp:HyperLink ID="hlPontosMinimos" runat="server" NavigateUrl="~/Pmme.aspx">pontos mínimos de medição</asp:HyperLink>
        .</div>
    <p>
        <asp:Image ID="Image1" runat="server" Height="412px" 
            ImageUrl="~/images/modelo.png" Width="565px" />
    </p>
</asp:Content>
