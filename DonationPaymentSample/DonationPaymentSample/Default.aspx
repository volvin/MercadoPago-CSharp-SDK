<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DonationPaymentSample._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="http://mp-tools.mlstatic.com/buttons/render.js"></script>
    <script type="text/jscript">
        function GetPreference() {
            var amount;
            if (document.getElementById("<% = Radio10.ClientID %>").checked) {
                amount = 10;
            }
            else {
                amount = 20;
            }
            var f = document.getElementById("<% = Email.ClientID %>");
            var email = document.getElementById("<% = Email.ClientID %>").value;
            var json = "{amount: " + amount + ", email: \"" + email + "\"}";
            CallServer(json, "");
        }
        function ReceiveServerData(arg, context) {
            openCheckout(arg);
        }
	    function openCheckout(url) {
		    document.getElementById('RunLightButton').openMPCheckout(url);	
	    }
    </script>
    <h2>
        Donations
    </h2>
    <p>
        <asp:Image ID="DonationImage" runat="server" Height="79px" Width="277px" />
        <asp:RadioButton ID="Radio10" runat="server" Checked="True" Font-Bold="True" 
            Font-Size="Large" Text="10" GroupName="Amount" />
        <asp:RadioButton ID="Radio20" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="20" GroupName="Amount" />
    </p>
    <h3>
        <asp:Label ID="DonationTitle" runat="server"></asp:Label>
    </h3>
    <p>
        <asp:Label ID="DonationDescription" runat="server"></asp:Label>
    </p>
    <p>
        Your email address: 
        <asp:TextBox ID="Email" runat="server" Width="311px"></asp:TextBox>
    </p>
    <p align="center">
        <asp:Button ID="RunStandardButton" runat="server" Text="Pay with Standard Checkout" 
            onclick="RunStandardButton_Click" style="text-align: center" />
    </p>
    <p align="center">
        <input type="button" id="RunLightButton" name="MP-payButton" mp-mode="modal-lite" 
            value="Pay with LightBox Checkout" onclick="GetPreference()"/>
    </p>
</asp:Content>