<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page Principale.aspx.cs" Inherits="SiteWebThroneWars.Page_Principale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
<title>Throne Wars -Projet FinDec - Page Principale</title>
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

				<div class="DescTele">
					<div class="Description">
					<h1>Description</h1>
					<p>
						Jeu de stratégie tour-à-tour, pour 2 joueurs. Chaque joueur commence avec 4 personnages qu’il peut faire évoluer après chaque combats, avec de l’expérience acquise par ennemi vaincu et ils peuvent aussi utiliser le magasin du jeu pour acheter de l’équipement. Chacun des personnages du joueur possèdent des habilités/classes différentes (magicien, guerrier, archer, prêtre, etc). Le but de la partie est de vaincre tous les personnages de l’adversaire.
					</p></br></br></br></br></br>

					</div>
					<div class="Telechargement">
						<h3>Téléchargement</h3>
						<p>Client de téléchargement à venir</p>
					</div>
					
				</div>
						<div class="Membres">
								<h2>Équipe</h2>
								<p>Daren-Ken St-Laurent</p>
									<img src="./Images/Daren.jpg" width="200" height="200"/>
								<p>Francis Côté</p>
									<img src="./Images/Tattoo.jpg" width="200" height="200"/>
								<p>Charles Hunter-Roy</p>
									<img src="./Images/Charles.jpg" width="200" height="200" />
								<p>Alexis Lalonde</p>
									<img src="./Images/Alexis2.jpg" width="200" height="200" />
							</div>
				
						
				
							
</body>
</html>
