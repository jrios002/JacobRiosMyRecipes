<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsForm.aspx.cs" Inherits="JacobRiosMyRecipes.Presentation.DetailsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('../Resources/RecipeImage.jpg'); background-attachment:fixed; background-repeat:no-repeat; background-size:cover; background-position:center">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:LoginView ID="LoginView1" runat="server" EnableTheming="True">
            <AnonymousTemplate>
                <span style="font-family: 'Monotype Corsiva'; font-size: x-large; font-style: normal; font-weight: normal; color: #000000;" />
                Hello Guest! Please <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Login " LogoutPageUrl="~/Presentation/RecipeListForm.aspx" ForeColor="Cyan" LogoutAction="Redirect" /> to view your Favorites!!
            </AnonymousTemplate>
            <LoggedInTemplate>
                <span style="font-family: 'Monotype Corsiva'; font-size: x-large; font-style: normal; font-weight: normal; color: #000000;" />
                Hello <asp:LoginName ID="LoginName1" runat="server" /> &nbsp;welcome back!
                <asp:LoginStatus ID="LoginStatus2" runat="server" ForeColor="Cyan" LogoutAction="Redirect" LogoutPageUrl="~/Presentation/RecipeListForm.aspx" OnLoggedOut="LoginStatus2_LoggedOut" /><br />
                <a href="ChangePasswordForm.aspx" style="color: #00FFFF">Change Password</a>
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="EditModeLabel" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Yellow" Text="Recipe Display is in Edit Mode!"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="LabelBox" runat="server" BackColor="Transparent" BorderStyle="None" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="XX-Large" ForeColor="White" Width="345px"></asp:TextBox>
        <br />
        <br />
        <asp:Image ID="RecipeImage" runat="server" Height="250" Width="360"/>
        <br />
        <br />
        <asp:Label ID="IngredientsLabel" runat="server" Text="Ingredients" ForeColor="White"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="InstructionsLabel" runat="server" Text="Instructions" ForeColor="White"></asp:Label>
        <br />
        <asp:TextBox ID="IngredientsBox" placeholder="Ingredient Details Will Be Here." runat="server" Height="400px" Width="320px" TextMode="MultiLine"></asp:TextBox>
&nbsp;
        <asp:TextBox ID="InstructionsBox" placeholder="Instruction Details Will Be Here." runat="server" Height="400px" Width="320px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" Text="Update" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="AddToFavButton" runat="server" Text="Add To Favorites" OnClick="AddToFavButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="Delete From Recipes" OnClick="DeleteButton_Click" OnClientClick="return confirm('Delete Recipe?');"/>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="SaveBtn" runat="server" OnClick="SaveBtn_Click" Text="Save Updates" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Cancel Updates" />
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
