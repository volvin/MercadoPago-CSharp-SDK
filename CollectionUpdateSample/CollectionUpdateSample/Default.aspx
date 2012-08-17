<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CollectionUpdateSample._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:MultiView ID="SampleMultiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="AuthView" runat="server">
            <h2>
                These are the MercadoPago Collection Update samples!
            </h2>
            <p>
                <table>
                    <tr>
                        <td><b>First, enter your MercadorPago credentials:</b></td>
                    </tr>       
                </table>
                <table>
                    <tr>
                        <td>Your client id:</td>
                        <td><asp:TextBox ID="ClientIdTxt" runat="server" Text="1982"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Your client secret:</td>
                        <td><asp:TextBox ID="ClientSecretTxt" runat="server" Text="020Gc1hFJYJQ6ttYqwsl1rs5yIimcHkX" Width="322px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="ContinueButton" runat="server" Text="Continue" onclick="ContinueButton_Click" /></td>
                    </tr>       
                </table>
            </p>
        </asp:View>
        <asp:View ID="SearchCollectionsView" runat="server">
            <h3>
                Second step: Choose one collection to change
            </h3>
            <table>
                <tr>
                    <td align="right">
                        <asp:Button ID="GoToChangeExtRefButton" runat="server" Text="Change Ext.Reference" onclick="GoToChangeExtRefButton_Click" />                        
                        <asp:Button ID="GoToCancelCollectionButton" runat="server" Text="Cancel" onclick="GoToCancelCollectionButton_Click" />                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="CollectionsGridView" runat="server" 
                            PageSize="5" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AutoGenerateSelectButton="True" 
                            onselectedindexchanged="CollectionsGridView_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                                    DataFormatString="{0:F}" />
                                <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" />
                                <asp:BoundField DataField="ExternalReference" HeaderText="ExternalReference" />
                                <asp:BoundField DataField="TotalPaidAmount" HeaderText="TotalPaidAmount" 
                                    ApplyFormatInEditMode="True" DataFormatString="{0:F2}" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BorderColor="Red" BackColor="#E2DED6" Font-Bold="True" 
                                ForeColor="#333333" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PagerPanel" Visible="false" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="PagerFrom" runat="server" Text="" /> - <asp:Label ID="PagerTo" runat="server" Text="" /> 
                            of <asp:Label ID="PagerTotal" runat="server" Text="" />
                            <asp:Button ID="FirstPageButton" runat="server" Text="<<" onclick="FirstPageButton_Click" />
                            <asp:Button ID="PageDownButton" runat="server" Text="<" onclick="PageDownButton_Click" />                        
                            <asp:Button ID="PageUpButton" runat="server" Text=">" onclick="PageUpButton_Click" />                        
                            <asp:Button ID="LastPageButton" runat="server" Text=">>" onclick="LastPageButton_Click" />
                            <asp:Button ID="RefreshPageButton" runat="server" Text="Refresh" onclick="RefreshPageButton_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="ChangeExtRefView" runat="server">
            <h3>
                Change a Collection's External Reference
            </h3>
            <p>
                <table>
                    <tr>
                        <td>Collection Id:</td>
                        <td><asp:TextBox ID="ColIdChangeExtRefText" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Enter a new ExternalReference:</td>
                        <td><asp:TextBox ID="NewExternalReferenceText" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="Button1" runat="server" Text="Change!" 
                                onclick="ChangeExternalReferenceButton_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3"><asp:Label ID="ChangeExternalReferenceResult" runat="server"></asp:Label></td>            
                    </tr>
                    <tr>
                        <td><asp:Button ID="ReturnButton1" runat="server" Text="<< Return" 
                                onclick="ReturnButton_Click" /></td>            
                    </tr>
                </table>
            </p>
        </asp:View>
        <asp:View ID="CancelCollectionView" runat="server">
            <h3>
                Cancel a Collection
            </h3>
            <p>
                <table>
                    <tr>
                        <td>Collection Id:</td>
                        <td><asp:TextBox ID="ColIdCancelColText" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="CancelCollectionButton" runat="server" Text="Cancel" 
                                onclick="CancelCollectionButton_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3"><asp:Label ID="CancelCollectionResult" runat="server" Text=""></asp:Label></td>            
                    </tr>
                    <tr>
                        <td><asp:Button ID="ReturnButton2" runat="server" Text="<< Return" 
                                onclick="ReturnButton_Click" /></td>            
                    </tr>
                </table>
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>
