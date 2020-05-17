# Scout
Scout is a .NET assembly used to perform recon on hosts during a pentest. Specifically, this was created as a way to check a host before laterally moving to it.

A lot of the checks for Scout were sourced from [SeatBelt](https://github.com/GhostPack/Seatbelt), a great project for situational awareness when you initially land on a computer. 

_Note: You have to be an administrator on the remote machine to run scout against it_

Example Output: 

```
PS C:\Users\Administrator\Desktop> .\scout.exe dc01
[i] Running Scout against dc01..
[======== PROCESSES ========]
PID             Name
1604            ismserv
4808            vmtoolsd
2132            dfssvc
3948            taskhostw
2020            ShellExperienceHost
4052            svchost
1376            svchost
2552            explorer
304             svchost
1908            svchost
3724            ApplicationFrameHost
832             svchost
1472            svchost
1792            dns
2112            MsMpEng
2668            regedit
1036            svchost
928             dwm
2104            VGAuthService
1568            svchost
604             lsass
2740            dllhost
3916            RuntimeBroker
704             svchost
596             services
1236            vmacthlp
2960            WmiPrvSE
4304            ServerManager
2124            SearchUI
264             smss
476             csrss
4712            SystemSettings
2076            svchost
2716            vds
468             wininit
3140            MpCmdRun
356             csrss
248             svchost
1208            spoolsv
776             svchost
880             svchost
3856            sihost
2092            vmtoolsd
552             winlogon
2916            msdtc
3864            svchost
2616            WmiPrvSE
1508            dfsrs
8               Microsoft.ActiveDirectory.WebServices
4               System
964             svchost
0               Idle

[======== SERVICES ========]
Active Directory Web Services: Running
AllJoyn Router Service: Stopped
Application Layer Gateway Service: Stopped
Application Identity: Stopped
Application Information: Stopped
Application Management: Stopped
App Readiness: Stopped
Microsoft App-V Client: Stopped
AppX Deployment Service (AppXSVC): Stopped
Windows Audio Endpoint Builder: Stopped
Windows Audio: Stopped
ActiveX Installer (AxInstSV): Stopped
Base Filtering Engine: Running
Background Intelligent Transfer Service: Stopped
Background Tasks Infrastructure Service: Running
Computer Browser: Stopped
Bluetooth Support Service: Stopped
Connected Devices Platform Service: Running
Certificate Propagation: Stopped
Client License Service (ClipSVC): Stopped
COM+ System Application: Running
CoreMessaging: Running
Cryptographic Services: Running
Offline Files: Stopped
DCOM Server Process Launcher: Running
DataCollectionPublishingService: Stopped
Optimize drives: Stopped
Device Association Service: Stopped
Device Install Service: Stopped
DevQuery Background Discovery Broker: Stopped
DFS Namespace: Running
DFS Replication: Running
DHCP Client: Running
DHCP Server: Running
Microsoft (R) Diagnostics Hub Standard Collector Service: Stopped
Connected User Experiences and Telemetry: Running
Device Management Enrollment Service: Stopped
dmwappushsvc: Stopped
DNS Server: Running
DNS Client: Running
Wired AutoConfig: Stopped
Diagnostic Policy Service: Running
Device Setup Manager: Running
DS Role Server: Stopped
Data Sharing Service: Stopped
Extensible Authentication Protocol: Stopped
Encrypting File System (EFS): Stopped
Embedded Mode: Stopped
Enterprise App Management Service: Stopped
Windows Event Log: Running
COM+ Event System: Running
Function Discovery Provider Host: Stopped
Function Discovery Resource Publication: Stopped
Windows Font Cache Service: Running
Windows Camera Frame Server: Stopped
Group Policy Client: Running
Human Interface Device Service: Stopped
HV Host Service: Stopped
Windows Mobile Hotspot Service: Stopped
IKE and AuthIP IPsec Keying Modules: Stopped
IP Helper: Running
Intersite Messaging: Running
Kerberos Key Distribution Center: Running
Microsoft Key Distribution Service: Stopped
CNG Key Isolation: Running
KDC Proxy Server service (KPS): Stopped
KtmRm for Distributed Transaction Coordinator: Stopped
Server: Running
Workstation: Running
Geolocation Service: Running
Windows License Manager Service: Running
Link-Layer Topology Discovery Mapper: Stopped
TCP/IP NetBIOS Helper: Running
Local Session Manager: Running
Downloaded Maps Manager: Stopped
Windows Firewall: Running
Distributed Transaction Coordinator: Running
Microsoft iSCSI Initiator Service: Stopped
Windows Installer: Stopped
Network Connectivity Assistant: Stopped
Network Connection Broker: Running
Netlogon: Running
Network Connections: Stopped
Network List Service: Running
Network Setup Service: Stopped
Net.Tcp Port Sharing Service: Stopped
Microsoft Passport Container: Stopped
Microsoft Passport: Stopped
Network Location Awareness: Running
Network Store Interface Service: Running
Active Directory Domain Services: Running
File Replication: Stopped
Program Compatibility Assistant Service: Running
Performance Counter DLL Host: Stopped
Phone Service: Stopped
Performance Logs & Alerts: Stopped
Plug and Play: Running
IPsec Policy Agent: Stopped
Power: Running
Printer Extensions and Notifications: Stopped
User Profile Service: Running
Quality Windows Audio Video Experience: Stopped
Remote Access Auto Connection Manager: Stopped
Remote Access Connection Manager: Stopped
Routing and Remote Access: Stopped
Remote Registry: Running
Radio Management Service: Stopped
RPC Endpoint Mapper: Running
Remote Procedure Call (RPC) Locator: Stopped
Remote Procedure Call (RPC): Running
Resultant Set of Policy Provider: Stopped
Special Administration Console Helper: Stopped
Security Accounts Manager: Running
Smart Card: Stopped
Smart Card Device Enumeration Service: Stopped
Task Scheduler: Running
Smart Card Removal Policy: Stopped
Secondary Logon: Stopped
System Event Notification Service: Running
Sensor Data Service: Stopped
Sensor Service: Stopped
Sensor Monitoring Service: Stopped
Remote Desktop Configuration: Stopped
Internet Connection Sharing (ICS): Stopped
Shell Hardware Detection: Running
Microsoft Storage Spaces SMP: Running
SNMP Trap: Stopped
Print Spooler: Running
Software Protection: Stopped
SSDP Discovery: Stopped
Secure Socket Tunneling Protocol Service: Stopped
State Repository Service: Running
Windows Image Acquisition (WIA): Stopped
Storage Service: Running
Spot Verifier: Stopped
Microsoft Software Shadow Copy Provider: Stopped
Superfetch: Stopped
System Events Broker: Running
Touch Keyboard and Handwriting Panel Service: Stopped
Telephony: Stopped
Remote Desktop Services: Stopped
Themes: Running
Storage Tiers Management: Stopped
Tile Data model server: Running
Time Broker: Running
Distributed Link Tracking Client: Stopped
Windows Modules Installer: Stopped
Auto Time Zone Updater: Stopped
User Access Logging Service: Running
User Experience Virtualization Service: Stopped
Interactive Services Detection: Stopped
Remote Desktop Services UserMode Port Redirector: Stopped
UPnP Device Host: Stopped
User Manager: Running
Update Orchestrator Service for Windows Update: Running
Credential Manager: Running
Virtual Disk: Running
VMware Alias Manager and Ticket Service: Running
Hyper-V Guest Service Interface: Stopped
Hyper-V Heartbeat Service: Stopped
Hyper-V Data Exchange Service: Stopped
Hyper-V Remote Desktop Virtualization Service: Stopped
Hyper-V Guest Shutdown Service: Stopped
Hyper-V Time Synchronization Service: Stopped
Hyper-V PowerShell Direct Service: Stopped
Hyper-V Volume Shadow Copy Requestor: Stopped
VMware Tools: Running
VMware Snapshot Provider: Stopped
VMware Physical Disk Helper Service: Running
VMware CAF AMQP Communication Service: Stopped
VMware CAF Management Agent Service: Stopped
Volume Shadow Copy: Stopped
Windows Time: Running
WalletService: Stopped
Windows Biometric Service: Stopped
Windows Connection Manager: Running
Diagnostic Service Host: Stopped
Diagnostic System Host: Running
Windows Defender Network Inspection Service: Stopped
Windows Event Collector: Stopped
Windows Encryption Provider Host Service: Stopped
Problem Reports and Solutions Control Panel Support: Stopped
Windows Error Reporting Service: Stopped
Still Image Acquisition Events: Stopped
Windows Defender Service: Running
WinHTTP Web Proxy Auto-Discovery Service: Running
Windows Management Instrumentation: Running
Windows Remote Management (WS-Management): Running
Windows Insider Service: Stopped
Microsoft Account Sign-in Assistant: Stopped
WMI Performance Adapter: Stopped
Portable Device Enumerator Service: Stopped
Windows Push Notifications System Service: Running
Windows Search: Stopped
Windows Update: Stopped
Windows Driver Foundation - User-mode Driver Framework: Running
Xbox Live Auth Manager: Stopped
Xbox Live Game Save: Stopped
CDPUserSvc_7155e: Running
Sync Host_7155e: Running
Contact Data_7155e: Stopped
User Data Storage_7155e: Stopped
User Data Access_7155e: Stopped
Windows Push Notifications User Service_7155e: Stopped

[======== POWERSHELL SETTINGS ========]
PowerShell v2 Version: 2.0
PowerShell v5 Version: 5.1.14393.0

[-------- Transcription Settings --------]
No Transcription Settings Found.

[-------- Module Logging Settings --------]
No Module Logging Settings Found.

[-------- Scriptblock Logging Settings --------]
No Script Block Settings Found.

[======== .NET VERSIONS ========]
 4.6.01586
 4.6.01586

[======== AUDIT SETTINGS ========]
No Audit Settings Found

[======== WEF SETTINGS ========]
No WEF Settings Found
```