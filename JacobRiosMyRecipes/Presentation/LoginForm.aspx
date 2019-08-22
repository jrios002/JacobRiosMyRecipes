<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="JacobRiosMyRecipes.Presentation.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('../Resources/RecipeImage.jpg'); background-attachment:fixed; background-repeat:no-repeat; background-size:cover; background-position:center">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Names="Monotype Corsiva" Font-Size="X-Large" Text="Please Login or click "></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="Cyan" NavigateUrl="~/Presentation/RecipeListForm.aspx">here </asp:HyperLink>
        <asp:Label ID="Label2" runat="server" Font-Names="Monotype Corsiva" Font-Size="X-Large" Text="to continue as guest."></asp:Label>
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Login ID="Login1" runat="server" CreateUserText="Please Register Here if you do not have an account." CreateUserUrl="~/Presentation/RegistrationForm.aspx" DestinationPageUrl="~/Presentation/RecipeListForm.aspx" Height="184px" Width="499px" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Monotype Corsiva" Font-Size="20pt" ForeColor="#333333" TextLayout="TextOnTop" TitleText="My Recipes Log In" OnLoggedIn="Login1_LoggedIn" >
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <ValidatorTextStyle Font-Names="Monotype Corsiva" Font-Overline="False" Font-Strikeout="False" />
        </asp:Login>
        <br />
        <br />
        <br />
        <br />
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Monotype Corsiva" Font-Size="20pt" Height="114px" style="margin-top: 0px" Width="494px">
            <SubmitButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <SuccessTextStyle Font-Bold="True" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:PasswordRecovery>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
        
    </form>
</body>
</html>
