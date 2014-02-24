<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="BookReviews.Admin.EditCategories" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
    <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" ItemType="BookReviews.Models.Category" SelectMethod="GridViewCategories_GetData"
        AllowPaging="true" PageSize="3" AllowSorting="true">
       <Columns>
            <asp:TemplateField HeaderText="CategoryName" SortExpression="Name">
                <ItemTemplate>
                    <%#: Item.Name %>
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

    <asp:Panel ID="EditOrCreateCategotyPanel" runat="server" Visible="false">
        <h3 ><asp:Label ID="PanelTitle" runat="server"></asp:Label></h3>
        <asp:Label id="EditOrCreateCategotyLabel" Text="Name" AssociatedControlID="EditOrCreateCategotyTextBox" runat="server" ></asp:Label>
        <asp:TextBox ID="EditOrCreateCategotyTextBox" runat="server"></asp:TextBox>
          
    
        <asp:Button ID="EditOrCreateCategotyButton" OnClick="EditOrCreateCategotyButton_Click" runat="server" />
        <asp:Button ID="CancelButton" OnClick="CancelButton_Click" Text="Cancel" CommandName="cancel" runat ="server" />
    </asp:Panel>
    <asp:Button ID="AddCategory" runat="server" OnClick="AddCategory_Click" Text="Create New"/>

</asp:Content>
