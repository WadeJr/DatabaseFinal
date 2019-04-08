<%@ Page Title="Recipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Recipes.Recipe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="Stylesheet" href="css/master.css" type="text/css" />
    <div class="jumbotron">
        <h1>Recipe: <%= Recipes.Recipe.recipeName%></h1>
        <p class="lead">&nbsp;</p>

        <p>&nbsp;</p>
    </div>
    <div>
    


        <asp:Button ID="addBtn" runat="server" Text="Add to Favorites" Width="129px" OnClick="addBtn_Click" />
        <asp:Button ID="deleteBtn" runat="server" Text="Delete Recipe" Width="138px" OnClick="deleteBtn_Click" />

    </div>
    <div>


        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="true" Width="500px">
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
