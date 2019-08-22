<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="JacobRiosMyRecipes.Presentation.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('../Resources/RecipeImage.jpg'); background-attachment:fixed; background-repeat:no-repeat; background-size:cover; background-position:center">
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="20pt" ForeColor="Black" Height="438px" Width="628px" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderStyle="Solid" BorderWidth="1px" ContinueDestinationPageUrl="~/Presentation/RecipeListForm.aspx" CancelDestinationPageUrl="~/Presentation/RecipeListForm.aspx" DisplayCancelButton="True">
            <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
            <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <SideBarButtonStyle ForeColor="White" />
            <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
        </asp:CreateUserWizard>
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
