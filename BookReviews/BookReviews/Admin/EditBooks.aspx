<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="BookReviews.Admin.EditBooks" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Edit Books</h1>
    <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" ItemType="BookReviews.Models.Book" SelectMethod="GridViewBooks_GetData"
        AllowPaging="true" PageSize="5" AllowSorting="true">
       <Columns>
          
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <%#: Item.Author %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <%#: Item.ISBN %>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Web Site" SortExpression="SiteURL">
                <ItemTemplate>
                    <%#: Item.SiteURL %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                <ItemTemplate>
                    <%#: Item.Category.Name %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" CommandArgument="<%# Item.Id %>" />
                   <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" CommandArgument="<%# Item.Id %>" />
                </ItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>
     <asp:Panel ID="BookPanel" runat="server" Visible="false">
        <h3 ><asp:Label ID="PanelTitle" runat="server"></asp:Label></h3>
        <asp:Label id="TitleLabel" Text="Title" AssociatedControlID="TitleTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox><br />
        <asp:Label id="AuthorLabel" Text="Author" AssociatedControlID="AuthorTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="AuthorTextBox" runat="server"></asp:TextBox><br />
        <asp:Label ID="ISBN" Text="ISBN" AssociatedControlID="ISBNTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="ISBNTextBox" runat="server"></asp:TextBox><br />
        <asp:Label ID="UrlLabel" Text="WebSite" AssociatedControlID="UrlTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="UrlTextBox" runat="server"></asp:TextBox><br />
          <asp:Label id="DescrLabel" Text="Description" AssociatedControlID="DescrTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="DescrTextBox" TextMode="multiline" Columns="35" Rows="5" runat="server"></asp:TextBox><br />
        <asp:Label id="CategoryLabel" Text="Title" AssociatedControlID="CategoryDropDownList" runat="server" ></asp:Label>
        <asp:DropDownList ID="CategoryDropDownList" runat="server"
            DataValueField="Id" 
            DataTextField="Name">
        </asp:DropDownList><br />
        <asp:Button ID="EditOrCreateBook" OnClick="EditOrCreateBook_Click" runat="server" />
        <asp:Button ID="CancelButton" OnClick="CancelButton_Click" Text="Cancel" runat="server" />
    </asp:Panel>
    <asp:Button ID="AddBook" runat="server" OnClick="AddBook_Click" Text="Create New"/>
</asp:Content>
