﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SiteWebThroneWars.Page_Principale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
<title>Throne Wars -Projet FinDe<a href="default.aspx">default.aspx</a>c - Page Principale</title>
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
 					<li><a href="default.aspx">Accueil</a></li>
 					<li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
				 	<li><a href="Recherche.aspx">Recherche Joueur</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
			</div>

				<div class="DescTele">
					<div class="Description">
					<h1>Description</h1>
					<p>
						Throne Wars est un jeu de stratégie fantastique tour-par-tour impliquant 2 joueurs opposés dont le but 
                        est d’éliminer tous les personnages du joueur adverse. 
                        Une équipe est composée de 4 personnages pouvant être membre d’une des classes suivantes : 
                        Guerrier, Archer, Magicien et Prêtre. 
                        Chaque classe possède des habiletés et statistiques différentes. 
                        Les personnages possèdent leur propre inventaire et ceux-ci peuvent évoluer de niveau au fil des 
                        parties pour ainsi débloquer de nouvelles habiletés. 
                        Les joueurs possèdent, eux aussi, un inventaire et peuvent affecter des items à leurs personnages pour les préparer avant la partie.
                    </p>
                        <br />
                    <p style="text-align:center">
                        Supervisé par Francois Jean
                    </p>
					

					</div>
					<div class="Telechargement">
						<h3>Téléchargement</h3>
						<p>Client de téléchargement à venir</p>
					</div>
					
				</div>
						<div class="Membres">
								<h2>Équipe</h2>
								<a href="mailto:Daren@thronewars.ca" target="_top">Daren Ken St-Laurent</a><br />
									<img src="./Images/Daren.jpg" width="200" height="200"/><br /><br />
								<a href="mailto:Francis@thronewars.ca" target="_top">Francis Côté</a><br />
									<img src="./Images/Tattoo.jpg" width="200" height="200"/><br /><br />
								<a href="mailto:Charles@thronewars.ca" target="_top">Charles Hunter-Roy</a><br />
									<img src="./Images/Charles1.jpg" width="200" height="200" /><br /><br />
								<a href="mailto:Alexis@thronewars.ca" target="_top">Alexis Lalonde</a><br />
									<img src="./Images/Alexis2.jpg" width="200" height="200" /><br /><br />
							</div>						
</body>
</html>
