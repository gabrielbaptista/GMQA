<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GMQA._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Bem-vindo ao portal do GMQA!</h2>
    <div>
       O modelo GMQA surgiu de uma pesquisa científica dedicada a estudar questões 
        relativas à produção de software. O fruto desse trabalho é justamente o portal 
        aqui apresentado. Nos links acima você encontrará diversas informações sobre o 
        modelo e terá condições de entrar em contato para esclarecimento de dúvidas!
    </div>
    
    <p>
        <asp:Image ID="imgGMQA" runat="server" ImageUrl="~/images/GMQA.png" 
            style="text-align: center" />
    </p>
       
</asp:Content>
