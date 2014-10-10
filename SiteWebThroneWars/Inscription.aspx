<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="SiteWebThroneWars.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Inscription</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec.css"/>
</head>
<body>
		<div class="Entete">
			<img src="./Images/Logo_Grand.png" style="max-height:100%; max-width:100%;"/> <!-- A checker les dimensions ou plus grosse image -->
		</div>
		<br/>
		<br/>
		<div class="Table">
			<ul id="menu-bar">
 				<li class="active">
 					<li><a href="Page Principale.aspx">Accueil</a></li>
 					<li><a href="Inscription.aspx">Inscription</a></li>
				 	<li><a href="Stats2.aspx">Statistiques</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
		</div>
		<div class="Inscription">
		<form runat="server" action="Inscription.aspx" autocomplete="on">
  			<label>Nom d'utilisateur</label>
                <asp:Textbox ID="username" TextMode="SingleLine" runat="server"/><br/>
  			<label>Mot de passe</label>
                <asp:TextBox id="password" TextMode="password" runat="server"/><br/>
  			<label>Confirmer mot de passe</label>
                <asp:TextBox id="cpassword" TextMode="password" runat="server"/><br />
            <label>Courriel</label>
                <asp:Textbox ID="email" TextMode="SingleLine" runat="server"/><br/>
  			<label>Confirmer courriel</label>
                <asp:Textbox ID="cemail" TextMode="SingleLine" runat="server"/><br/>
            
            
            <asp:Button Text="Valider" onClick="inscriptionJoueur_Click" runat="server"/>
		</form>
          
			<a href="ForgotPass.aspx">Mot de passe oublié?</a>
		</div>
</body>
</html>

