<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="SiteWebThroneWars.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Forgot Password</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec.css"/>
</head>
	<body>
		<div class="Entete" align="center">
			<img src="./Images/Logo.jpg"/> <!-- A checker les dimensions ou plus grosse image -->
		</div>
		<br/>
		<br/>
		<div class="Table">
			<ul id="menu-bar">
 				<li class="active">
 					<li><a href="Page Principale.html">Accueil</a></li>
 					<li><a href="Inscription.html">Inscription</a></li>
				 	<li><a href="Stats.html">Statistiques</a></li>
				 	<li><a href="Media.html">Média</a></li>
				 </li>
			</ul>
		</div>
		<div class="FormForgot">
			<form action="sumbit" autocomplete="on"/>
  			Courriel: <input type="email" name="email" autocomplete="off"><br>
  			<input type="submit"/>
            </form>
  		</div>
  	</body>
</html>
