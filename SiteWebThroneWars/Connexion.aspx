<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="SiteWebThroneWars.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css" />
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
   <form runat="server" action="Inscription.aspx" autocomplete="on">
    <script type="text/javascript">
        function MessageBoxErreur(textadaptatif) {
            $(document).ready(function () {
                swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "I'm sad" });
            });
        }
        </script>
    <div class="Entete">
        <img src="./Images/Logo_Grand.png" style="max-height: 100%; max-width: 100%;" />
        <!-- A checker les dimensions ou plus grosse image -->
    </div>
    <br />
    <br />
    <div class="Table">
        <ul id="menu-bar">
            <li class="active">
                <li><a href="Page Principale.aspx">Accueil</a></li>
                <li><a href="Inscription.aspx">Inscription</a></li>
                <li><a href="Connexion.aspx">Connexion</a></li>
                <li><a href="Recherche.aspx">Recherche Joueur</a></li>
                <li><a href="Media.aspx">Média</a></li>
            </li>
        </ul>
    </div>

        <div class="Inscription">
            <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur</asp:Label>
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" /><br />
            <asp:Label ID="passwordLB" runat="server">Mot de Passe</asp:Label>
            <asp:TextBox ID="password" TextMode="password" runat="server" /><br />
            <asp:Button Text="Se connecter" OnClick="Connexion_Click" runat="server" /><br />
            <a href="ForgotPass.aspx">Mot de passe oublié?</a><br />
            <a href="ForgetUsername.aspx">Nom d'utilisateur oublié?</a><br />
            <a href="ChangePassword.aspx">Changer son mot de passe</a>
        </div>
        <div class="Leaderboard">
            <asp:Table ID="table" runat="server" GridLines="Both">
                <asp:TableHeaderRow runat="server" ForeColor="Red">
                    <asp:TableHeaderCell>Position</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nom d'utilisateur</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Victoires</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Défaites</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <div class="Stats">
            <asp:Label runat="server">Nom utilisateur</asp:Label>
            <input type="text" name="Username" disabled="disabled" />
            <asp:Label runat="server">XP</asp:Label>
            <input type="text" name="XP" disabled="disabled" /><br />
            <br />
            <br />
            <label>Personnage 1</label>
            <input type="text" name="Player1" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer1" disabled="disabled" /><br />
            <label>Personnage 2</label>
            <input type="text" name="Player2" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer2" disabled="disabled" /><br />
            <label>Personnage 3</label>
            <input type="text" name="Player3" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer3" disabled="disabled" /><br />
            <label>Personnage 4</label>
            <input type="text" name="Player4" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer4" disabled="disabled" /><br />
        </div>
    </form>
</body>
</html>
