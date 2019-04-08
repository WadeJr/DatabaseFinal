<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Recipes.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="Stylesheet" href="css/master.css" type="text/css" />
    <div class="jumbotron">
        <h1>Home</h1>
        <p class="lead">&nbsp;</p>

        <p>&nbsp;</p>
    </div>
    <div>
        <h4>Find recipe by recipe name or ingredient</h4>
        <h5>Click on recipe rid to add to your favorites</h5>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="recipe">Recipe</asp:ListItem>
            <asp:ListItem Value="ingredient">Ingredient</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />

        <asp:Button ID="recipesBtn" runat="server" OnClick="recipesBtn_Click" Text="All Recipes" Width="84px" />
        <asp:Button ID="ingredientBtn" runat="server" OnClick="ingredientBtn_Click" Text="All Ingredients" Width="105px" />

    </div>
    <div>


        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="true" Width="500px" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
      
        </asp:GridView>
         


    </div>


</asp:Content>
