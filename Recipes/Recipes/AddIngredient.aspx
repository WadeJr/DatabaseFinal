﻿<%@ Page Title="Add Ingredient" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddIngredient.aspx.cs" Inherits="Recipes.AddIngredient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="Stylesheet" href="css/master.css" type="text/css" />
    <div class="jumbotron">
        <h1>Add Ingredient</h1>

        <p class="lead">&nbsp;</p>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back</asp:LinkButton>
        <p>&nbsp;</p>
    </div>
     <div>
         <asp:TextBox ID="ingredient" runat="server"></asp:TextBox>
        <asp:Button ID="addIngredientBtn" runat="server" Text="Add Ingredient" OnClick="addIngredientBtn_Click" />

    </div>
    <div>
         <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
