<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Recipes._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="Stylesheet" href="css/master.css" type="text/css" />
    <div class="jumbotron">
        <h1>Log In</h1>
        <p class="lead">&nbsp;</p>

        <p>&nbsp;</p>
    </div>

            <div class="login" >
            Username:<br />
            <asp:TextBox ID="username" runat="server" required></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server" required TextMode="Password"></asp:TextBox>
            <br />
             <br />
            <asp:Button CssClass ="btn" ID="loginBtn" runat="server" Text="Log In" Height="35px" Width="109px" OnClick="loginBtn_Click" />
                &nbsp;
                <asp:Button CssClass ="btn"  ID="signUpBtn" runat="server" Text="Sign Up" OnClick="signUpBtn_Click" />
        </div>

</asp:Content>
