; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{DCCA69B6-E1EE-471B-91DC-2E5E50C89CB3}
AppName=Throne Wars
AppVersion=0.004
;AppVerName=Throne Wars 0.002
AppPublisher=Coll�ge Lionel-Groulx
AppPublisherURL=http://www.thronewars.ca
AppSupportURL=http://www.thronewars.ca
AppUpdatesURL=http://www.thronewars.ca
DefaultDirName={pf}\Throne Wars
DefaultGroupName=Throne Wars
AllowNoIcons=yes
OutputDir=C:\inetpub\Throne\SiteWeb\Downloads
OutputBaseFilename=Thronewars_Setup
SetupIconFile=C:\ThroneWarsServer\ThroneWars\Assets\Textures\icon.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\ThroneWarsOutput\ThroneWars.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\ThroneWarsOutput\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Throne Wars"; Filename: "{app}\ThroneWars.exe"
Name: "{group}\{cm:ProgramOnTheWeb,Throne Wars}"; Filename: "http://www.thronewars.ca"
Name: "{group}\{cm:UninstallProgram,Throne Wars}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Throne Wars"; Filename: "{app}\ThroneWars.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\ThroneWars.exe"; Description: "{cm:LaunchProgram,Throne Wars}"; Flags: nowait postinstall skipifsilent

