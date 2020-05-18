# Scout
Scout is a .NET assembly used to perform recon on hosts during a pentest. Specifically, this was created as a way to check a host before laterally moving to it.

A lot of the checks for Scout were sourced from [SeatBelt](https://github.com/GhostPack/Seatbelt), a great project for situational awareness when you initially land on a computer. 

_Note: You have to be an administrator on the remote machine to run scout against it_

Example Output: 

```
PS C:\> .\scout.exe dc01                                                               
[i] Running Scout against dc01..
[======== PROCESSES ========]
PID             Name
3724            ApplicationFrameHost
476             csrss
356             csrss
1508            dfsrs
2132            dfssvc
2740            dllhost
1792            dns
928             dwm
2552            explorer
0               Idle
1604            ismserv
3676            LockAppHost
788             LogonUI
604             lsass
8               Microsoft.ActiveDirectory.WebServices
2916            msdtc
2112            MsMpEng [Windows Defender AV]
2668            regedit [REGISTRY EDITOR]
3916            RuntimeBroker
2124            SearchUI
4304            ServerManager
596             services
2020            ShellExperienceHost
3856            sihost
264             smss
1208            spoolsv
704             svchost
880             svchost
964             svchost
776             svchost
1036            svchost
1568            svchost
1472            svchost
1376            svchost
1908            svchost
304             svchost
832             svchost
2076            svchost
3864            svchost
248             svchost
4               System
4712            SystemSettings
3948            taskhostw
3760            taskhostw
2716            vds
2104            VGAuthService
1236            vmacthlp
2092            vmtoolsd
4808            vmtoolsd
468             wininit
552             winlogon
2616            WmiPrvSE


[======== SERVICES ========]

|-------- Running Services --------|
ADWS: Active Directory Web Services
BFE: Base Filtering Engine
BrokerInfrastructure: Background Tasks Infrastructure Service
CDPSvc: Connected Devices Platform Service
CDPUserSvc_7155e: CDPUserSvc_7155e
COMSysApp: COM+ System Application
CoreMessagingRegistrar: CoreMessaging
CryptSvc: Cryptographic Services
DcomLaunch: DCOM Server Process Launcher
Dfs: DFS Namespace
DFSR: DFS Replication
Dhcp: DHCP Client
DHCPServer: DHCP Server
DiagTrack: Connected User Experiences and Telemetry
DNS: DNS Server
Dnscache: DNS Client
DPS: Diagnostic Policy Service
DsmSvc: Device Setup Manager
EventLog: Windows Event Log
EventSystem: COM+ Event System
FontCache: Windows Font Cache Service
gpsvc: Group Policy Client
iphlpsvc: IP Helper
IsmServ: Intersite Messaging
Kdc: Kerberos Key Distribution Center
KeyIso: CNG Key Isolation
LanmanServer: Server
LanmanWorkstation: Workstation
lfsvc: Geolocation Service
LicenseManager: Windows License Manager Service
lmhosts: TCP/IP NetBIOS Helper
LSM: Local Session Manager
MpsSvc: Windows Firewall
MSDTC: Distributed Transaction Coordinator
NcbService: Network Connection Broker
Netlogon: Netlogon
netprofm: Network List Service
NlaSvc: Network Location Awareness
nsi: Network Store Interface Service
NTDS: Active Directory Domain Services
OneSyncSvc_7155e: Sync Host_7155e
PcaSvc: Program Compatibility Assistant Service
PlugPlay: Plug and Play
Power: Power
ProfSvc: User Profile Service
RemoteRegistry: Remote Registry
RpcEptMapper: RPC Endpoint Mapper
RpcSs: Remote Procedure Call (RPC)
SamSs: Security Accounts Manager
Schedule: Task Scheduler
SENS: System Event Notification Service
ShellHWDetection: Shell Hardware Detection
Spooler: Print Spooler
StateRepository: State Repository Service
StorSvc: Storage Service
SystemEventsBroker: System Events Broker
Themes: Themes
tiledatamodelsvc: Tile Data model server
TimeBrokerSvc: Time Broker
UALSVC: User Access Logging Service
UserManager: User Manager
UsoSvc: Update Orchestrator Service for Windows Update
VaultSvc: Credential Manager
vds: Virtual Disk
VGAuthService: VMware Alias Manager and Ticket Service
VMTools: VMware Tools
VMware Physical Disk Helper Service: VMware Physical Disk Helper Service
W32Time: Windows Time
Wcmsvc: Windows Connection Manager
WinDefend: Windows Defender Service
Winmgmt: Windows Management Instrumentation
WinRM: Windows Remote Management (WS-Management)
WpnService: Windows Push Notifications System Service
wudfsvc: Windows Driver Foundation - User-mode Driver Framework

|-------- Other Services --------|
AJRouter: AllJoyn Router Service (Stopped)
ALG: Application Layer Gateway Service (Stopped)
AppIDSvc: Application Identity (Stopped)
Appinfo: Application Information (Stopped)
AppMgmt: Application Management (Stopped)
AppReadiness: App Readiness (Stopped)
AppVClient: Microsoft App-V Client (Stopped)
AppXSvc: AppX Deployment Service (AppXSVC) (Stopped)
AudioEndpointBuilder: Windows Audio Endpoint Builder (Stopped)
Audiosrv: Windows Audio (Stopped)
AxInstSV: ActiveX Installer (AxInstSV) (Stopped)
BITS: Background Intelligent Transfer Service (Stopped)
Browser: Computer Browser (Stopped)
bthserv: Bluetooth Support Service (Stopped)
CertPropSvc: Certificate Propagation (Stopped)
ClipSVC: Client License Service (ClipSVC) (Stopped)
CscService: Offline Files (Stopped)
DcpSvc: DataCollectionPublishingService (Stopped)
defragsvc: Optimize drives (Stopped)
DeviceAssociationService: Device Association Service (Stopped)
DeviceInstall: Device Install Service (Stopped)
DevQueryBroker: DevQuery Background Discovery Broker (Stopped)
diagnosticshub.standardcollector.service: Microsoft (R) Diagnostics Hub Standard Collector Service (Stopped)
DmEnrollmentSvc: Device Management Enrollment Service (Stopped)
dmwappushservice: dmwappushsvc (Stopped)
dot3svc: Wired AutoConfig (Stopped)
DsRoleSvc: DS Role Server (Stopped)
DsSvc: Data Sharing Service (Stopped)
Eaphost: Extensible Authentication Protocol (Stopped)
EFS: Encrypting File System (EFS) (Stopped)
embeddedmode: Embedded Mode (Stopped)
EntAppSvc: Enterprise App Management Service (Stopped)
fdPHost: Function Discovery Provider Host (Stopped)
FDResPub: Function Discovery Resource Publication (Stopped)
FrameServer: Windows Camera Frame Server (Stopped)
hidserv: Human Interface Device Service (Stopped)
HvHost: HV Host Service (Stopped)
icssvc: Windows Mobile Hotspot Service (Stopped)
IKEEXT: IKE and AuthIP IPsec Keying Modules (Stopped)
KdsSvc: Microsoft Key Distribution Service (Stopped)
KPSSVC: KDC Proxy Server service (KPS) (Stopped)
KtmRm: KtmRm for Distributed Transaction Coordinator (Stopped)
lltdsvc: Link-Layer Topology Discovery Mapper (Stopped)
MapsBroker: Downloaded Maps Manager (Stopped)
MSiSCSI: Microsoft iSCSI Initiator Service (Stopped)
msiserver: Windows Installer (Stopped)
NcaSvc: Network Connectivity Assistant (Stopped)
Netman: Network Connections (Stopped)
NetSetupSvc: Network Setup Service (Stopped)
NetTcpPortSharing: Net.Tcp Port Sharing Service (Stopped)
NgcCtnrSvc: Microsoft Passport Container (Stopped)
NgcSvc: Microsoft Passport (Stopped)
NtFrs: File Replication (Stopped)
PerfHost: Performance Counter DLL Host (Stopped)
PhoneSvc: Phone Service (Stopped)
PimIndexMaintenanceSvc_7155e: Contact Data_7155e (Stopped)
pla: Performance Logs & Alerts (Stopped)
PolicyAgent: IPsec Policy Agent (Stopped)
PrintNotify: Printer Extensions and Notifications (Stopped)
QWAVE: Quality Windows Audio Video Experience (Stopped)
RasAuto: Remote Access Auto Connection Manager (Stopped)
RasMan: Remote Access Connection Manager (Stopped)
RemoteAccess: Routing and Remote Access (Stopped)
RmSvc: Radio Management Service (Stopped)
RpcLocator: Remote Procedure Call (RPC) Locator (Stopped)
RSoPProv: Resultant Set of Policy Provider (Stopped)
sacsvr: Special Administration Console Helper (Stopped)
SCardSvr: Smart Card (Stopped)
ScDeviceEnum: Smart Card Device Enumeration Service (Stopped)
SCPolicySvc: Smart Card Removal Policy (Stopped)
seclogon: Secondary Logon (Stopped)
SensorDataService: Sensor Data Service (Stopped)
SensorService: Sensor Service (Stopped)
SensrSvc: Sensor Monitoring Service (Stopped)
SessionEnv: Remote Desktop Configuration (Stopped)
SharedAccess: Internet Connection Sharing (ICS) (Stopped)
smphost: Microsoft Storage Spaces SMP (Stopped)
SNMPTRAP: SNMP Trap (Stopped)
sppsvc: Software Protection (Stopped)
SSDPSRV: SSDP Discovery (Stopped)
SstpSvc: Secure Socket Tunneling Protocol Service (Stopped)
stisvc: Windows Image Acquisition (WIA) (Stopped)
svsvc: Spot Verifier (Stopped)
swprv: Microsoft Software Shadow Copy Provider (Stopped)
SysMain: Superfetch (Stopped)
TabletInputService: Touch Keyboard and Handwriting Panel Service (Stopped)
TapiSrv: Telephony (Stopped)
TermService: Remote Desktop Services (Stopped)
TieringEngineService: Storage Tiers Management (Stopped)
TrkWks: Distributed Link Tracking Client (Stopped)
TrustedInstaller: Windows Modules Installer (Stopped)
tzautoupdate: Auto Time Zone Updater (Stopped)
UevAgentService: User Experience Virtualization Service (Stopped)
UI0Detect: Interactive Services Detection (Stopped)
UmRdpService: Remote Desktop Services UserMode Port Redirector (Stopped)
UnistoreSvc_7155e: User Data Storage_7155e (Stopped)
upnphost: UPnP Device Host (Stopped)
UserDataSvc_7155e: User Data Access_7155e (Stopped)
vmicguestinterface: Hyper-V Guest Service Interface (Stopped)
vmicheartbeat: Hyper-V Heartbeat Service (Stopped)
vmickvpexchange: Hyper-V Data Exchange Service (Stopped)
vmicrdv: Hyper-V Remote Desktop Virtualization Service (Stopped)
vmicshutdown: Hyper-V Guest Shutdown Service (Stopped)
vmictimesync: Hyper-V Time Synchronization Service (Stopped)
vmicvmsession: Hyper-V PowerShell Direct Service (Stopped)
vmicvss: Hyper-V Volume Shadow Copy Requestor (Stopped)
vmvss: VMware Snapshot Provider (Stopped)
VMwareCAFCommAmqpListener: VMware CAF AMQP Communication Service (Stopped)
VMwareCAFManagementAgentHost: VMware CAF Management Agent Service (Stopped)
VSS: Volume Shadow Copy (Stopped)
WalletService: WalletService (Stopped)
WbioSrvc: Windows Biometric Service (Stopped)
WdiServiceHost: Diagnostic Service Host (Stopped)
WdiSystemHost: Diagnostic System Host (Stopped)
WdNisSvc: Windows Defender Network Inspection Service (Stopped)
Wecsvc: Windows Event Collector (Stopped)
WEPHOSTSVC: Windows Encryption Provider Host Service (Stopped)
wercplsupport: Problem Reports and Solutions Control Panel Support (Stopped)
WerSvc: Windows Error Reporting Service (Stopped)
WiaRpc: Still Image Acquisition Events (Stopped)
WinHttpAutoProxySvc: WinHTTP Web Proxy Auto-Discovery Service (Stopped)
wisvc: Windows Insider Service (Stopped)
wlidsvc: Microsoft Account Sign-in Assistant (Stopped)
wmiApSrv: WMI Performance Adapter (Stopped)
WPDBusEnum: Portable Device Enumerator Service (Stopped)
WpnUserService_7155e: Windows Push Notifications User Service_7155e (Stopped)
WSearch: Windows Search (Stopped)
wuauserv: Windows Update (Stopped)
XblAuthManager: Xbox Live Auth Manager (Stopped)
XblGameSave: Xbox Live Game Save (Stopped)


[======== POWERSHELL SETTINGS ========]
PowerShell v2 Version: 2.0
PowerShell v5 Version: 5.1.14393.0

|-------- Transcription Settings --------|
No Transcription Settings Found.

|-------- Module Logging Settings --------|
No Module Logging Settings Found.

|-------- Scriptblock Logging Settings --------|
No Script Block Settings Found.


[======== .NET VERSIONS ========]
4.6.01586
4.6.01586


[======== AUDIT SETTINGS ========]
No Audit Settings Found


[======== WEF SETTINGS ========]
No WEF Settings Found
```