; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B03103B4-7670-4474-A778-9252E2B6AA8A}
AppName=�������
AppVersion=1.0
;AppVerName=������� 1.0
AppPublisher=sagitov.pro
AppPublisherURL=http://sagitov.pro/
AppSupportURL=http://sagitov.pro/
AppUpdatesURL=http://sagitov.pro/
DefaultDirName={pf}\�������
DefaultGroupName=�������
AllowNoIcons=yes
OutputDir=D:\Git\C#\Notepad
OutputBaseFilename=Setup_Notepad
Compression=lzma
SolidCompression=yes

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Git\C#\Notepad\Notepad\bin\Debug\Notepad.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Git\C#\Notepad\Notepad\bin\Debug\favic.ico"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\�������"; Filename: "{app}\Notepad.exe"
Name: "{group}\{cm:UninstallProgram,�������}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\�������"; Filename: "{app}\Notepad.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Notepad.exe"; Description: "{cm:LaunchProgram,�������}"; Flags: nowait postinstall skipifsilent

