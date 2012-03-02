<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="IPNClientSample._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        IPN Client Sample 
    </h2>
    <p>
        To run this sample navigate the page with the <b>id=[your payment id]</b> parameter.
    </p>
    <p>
        <b>E.g. http://yourdomain.com/thispage.aspx?id=12345667890</b>
    </p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
