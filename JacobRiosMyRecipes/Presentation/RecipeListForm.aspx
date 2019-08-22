<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeListForm.aspx.cs" Inherits="JacobRiosMyRecipes.Presentation.RecipeListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .CssStyle1 {
            color:blue;
            font-size:x-large;
            font:bold;
            font-family:'Monotype Corsiva';
        }

        .CssStyle2 {
            color:white;
            font-size:xx-large;
            font:bold;
            font-family:'Monotype Corsiva';
        }
    </style>
</head>
<body style="background-image: url('../Resources/RecipeImage.jpg'); background-attachment:fixed; background-repeat:no-repeat; background-size:cover; background-position:center">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:LoginView ID="LoginView1" runat="server" EnableTheming="True">
            <AnonymousTemplate>
                <span style="font-family: 'Monotype Corsiva'; font-size: x-large; font-style: normal; font-weight: normal; color: #000000;" />
                Hello Guest! Please <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Login " LogoutPageUrl="~/Presentation/RecipeListForm.aspx" ForeColor="Cyan" /> to view your Favorites!!
            </AnonymousTemplate>
            <LoggedInTemplate>
                <span style="font-family: 'Monotype Corsiva'; font-size: x-large; font-style: normal; font-weight: normal; color: #000000;" />
                Hello <asp:LoginName ID="LoginName1" runat="server" /> &nbsp;welcome back!
                <asp:LoginStatus ID="LoginStatus2" runat="server" ForeColor="Cyan" OnLoggedOut="LoginStatus2_LoggedOut" /><br />
                <a href="ChangePasswordForm.aspx" style="color: #00FFFF">Change Password</a>
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <br />
        <br />
        <br />
        &nbsp;
        <asp:Button ID="AddRecipeButton" runat="server" Font-Bold="True" Font-Size="Medium" Text="Add Recipe" OnClick="AddRecipeButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="FavListButton" runat="server" Font-Bold="True" Font-Size="Medium" Text="View Favorites List" Width="230px" OnClick="FavListButton_Click1" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:GridView ID="RecipeGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." OnRowCommand="GridView1_RowCommand" BackColor="White" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" HorizontalAlign="Left">
            
            <HeaderStyle BackColor="Black" ForeColor="White"></HeaderStyle>
            
            <AlternatingRowStyle BackColor="#999999" />
            <Columns>
                <asp:TemplateField HeaderText="Recipe List" SortExpression="Id" HeaderStyle-CssClass="CssStyle2">   
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<% #Eval("Id") %>'>
                        </asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgPreview" ImageUrl='<%# "ImageHandler.ashx?imgID="+ Eval("Id") %>' OnClick="imgPreview_Click" CommandArgument='<%# Bind("Id") %>' runat="server" Height="240px" Width="360px" />
                        <div style="text-align:center">
                            <asp:LinkButton ID="ViewRecipe" runat="server" CssClass="CssStyle1" CommandName="view" CommandArgument='<%# Bind("Id") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                        </div>                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecipeDatabaseConnectionString1 %>" DeleteCommand="DELETE FROM [RecipeTable] WHERE [Id] = @Id" InsertCommand="INSERT INTO [RecipeTable] ([Name], [Ingredients], [Instructions]) VALUES (@Name, @Ingredients, @Instructions)" SelectCommand="SELECT [Id], [Name], [Ingredients], [Instructions] FROM [RecipeTable]" UpdateCommand="UPDATE [RecipeTable] SET [Name] = @Name, [Ingredients] = @Ingredients, [Instructions] = @Instructions WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Ingredients" Type="String" />
                <asp:Parameter Name="Instructions" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Ingredients" Type="String" />
                <asp:Parameter Name="Instructions" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
