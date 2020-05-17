using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Tmds.DBus.Connection.DynamicAssemblyName)]
namespace Calendar.DBus
{
    [DBusInterface("org.kde.StatusNotifierWatcher")]
    interface IStatusNotifierWatcher : IDBusObject
    {
        Task RegisterStatusNotifierHostAsync(string ServiceName);
        Task RegisterStatusNotifierItemAsync(string ServiceName);
        Task<IDisposable> WatchStatusNotifierItemRegisteredAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchStatusNotifierItemUnregisteredAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchStatusNotifierHostRegisteredAsync(Action handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<StatusNotifierWatcherProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class StatusNotifierWatcherProperties
    {
        private string[] _RegisteredStatusNotifierItems = default (string[]);
        public string[] RegisteredStatusNotifierItems
        {
            get
            {
                return _RegisteredStatusNotifierItems;
            }

            set
            {
                _RegisteredStatusNotifierItems = (value);
            }
        }

        private bool _IsStatusNotifierHostRegistered = default (bool);
        public bool IsStatusNotifierHostRegistered
        {
            get
            {
                return _IsStatusNotifierHostRegistered;
            }

            set
            {
                _IsStatusNotifierHostRegistered = (value);
            }
        }

        private int _ProtocolVersion = default (int);
        public int ProtocolVersion
        {
            get
            {
                return _ProtocolVersion;
            }

            set
            {
                _ProtocolVersion = (value);
            }
        }
    }

    static class StatusNotifierWatcherExtensions
    {
        public static Task<string[]> GetRegisteredStatusNotifierItemsAsync(this IStatusNotifierWatcher o) => o.GetAsync<string[]>("RegisteredStatusNotifierItems");
        public static Task<bool> GetIsStatusNotifierHostRegisteredAsync(this IStatusNotifierWatcher o) => o.GetAsync<bool>("IsStatusNotifierHostRegistered");
        public static Task<int> GetProtocolVersionAsync(this IStatusNotifierWatcher o) => o.GetAsync<int>("ProtocolVersion");
    }

    [DBusInterface("com.deepin.daemon.Appearance")]
    interface IAppearance : IDBusObject
    {
        Task DeleteAsync(string Type, string Name);
        Task<double> GetScaleFactorAsync();
        Task<IDictionary<string, double>> GetScreenScaleFactorsAsync();
        Task<string> ListAsync(string Type);
        Task ResetAsync();
        Task SetAsync(string Type, string Value);
        Task SetScaleFactorAsync(double ScaleFactor);
        Task SetScreenScaleFactorsAsync(IDictionary<string, double> ScaleFactors);
        Task<string> ShowAsync(string Type, string[] Names);
        Task<string> ThumbnailAsync(string Type, string Name);
        Task<IDisposable> WatchChangedAsync(Action<(string type0, string value)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRefreshedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<AppearanceProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class AppearanceProperties
    {
        private string _CursorTheme = default (string);
        public string CursorTheme
        {
            get
            {
                return _CursorTheme;
            }

            set
            {
                _CursorTheme = (value);
            }
        }

        private string _Background = default (string);
        public string Background
        {
            get
            {
                return _Background;
            }

            set
            {
                _Background = (value);
            }
        }

        private string _StandardFont = default (string);
        public string StandardFont
        {
            get
            {
                return _StandardFont;
            }

            set
            {
                _StandardFont = (value);
            }
        }

        private string _MonospaceFont = default (string);
        public string MonospaceFont
        {
            get
            {
                return _MonospaceFont;
            }

            set
            {
                _MonospaceFont = (value);
            }
        }

        private double _FontSize = default (double);
        public double FontSize
        {
            get
            {
                return _FontSize;
            }

            set
            {
                _FontSize = (value);
            }
        }

        private string _WallpaperSlideShow = default (string);
        public string WallpaperSlideShow
        {
            get
            {
                return _WallpaperSlideShow;
            }

            set
            {
                _WallpaperSlideShow = (value);
            }
        }

        private string _GtkTheme = default (string);
        public string GtkTheme
        {
            get
            {
                return _GtkTheme;
            }

            set
            {
                _GtkTheme = (value);
            }
        }

        private string _IconTheme = default (string);
        public string IconTheme
        {
            get
            {
                return _IconTheme;
            }

            set
            {
                _IconTheme = (value);
            }
        }

        private double _Opacity = default (double);
        public double Opacity
        {
            get
            {
                return _Opacity;
            }

            set
            {
                _Opacity = (value);
            }
        }

        private string _QtActiveColor = default (string);
        public string QtActiveColor
        {
            get
            {
                return _QtActiveColor;
            }

            set
            {
                _QtActiveColor = (value);
            }
        }
    }

    static class AppearanceExtensions
    {
        public static Task<string> GetCursorThemeAsync(this IAppearance o) => o.GetAsync<string>("CursorTheme");
        public static Task<string> GetBackgroundAsync(this IAppearance o) => o.GetAsync<string>("Background");
        public static Task<string> GetStandardFontAsync(this IAppearance o) => o.GetAsync<string>("StandardFont");
        public static Task<string> GetMonospaceFontAsync(this IAppearance o) => o.GetAsync<string>("MonospaceFont");
        public static Task<double> GetFontSizeAsync(this IAppearance o) => o.GetAsync<double>("FontSize");
        public static Task<string> GetWallpaperSlideShowAsync(this IAppearance o) => o.GetAsync<string>("WallpaperSlideShow");
        public static Task<string> GetGtkThemeAsync(this IAppearance o) => o.GetAsync<string>("GtkTheme");
        public static Task<string> GetIconThemeAsync(this IAppearance o) => o.GetAsync<string>("IconTheme");
        public static Task<double> GetOpacityAsync(this IAppearance o) => o.GetAsync<double>("Opacity");
        public static Task<string> GetQtActiveColorAsync(this IAppearance o) => o.GetAsync<string>("QtActiveColor");
        public static Task SetFontSizeAsync(this IAppearance o, double val) => o.SetAsync("FontSize", val);
        public static Task SetWallpaperSlideShowAsync(this IAppearance o, string val) => o.SetAsync("WallpaperSlideShow", val);
        public static Task SetOpacityAsync(this IAppearance o, double val) => o.SetAsync("Opacity", val);
        public static Task SetQtActiveColorAsync(this IAppearance o, string val) => o.SetAsync("QtActiveColor", val);
    }

    [DBusInterface("com.deepin.sync.Config")]
    interface IConfig : IDBusObject
    {
        Task<byte[]> GetAsync();
        Task SetAsync(byte[] Data);
    }

    [DBusInterface("com.deepin.daemon.Daemon")]
    interface IDaemon : IDBusObject
    {
        Task CallTraceAsync(uint Times, uint Seconds);
        Task StartPart2Async();
    }

    [DBusInterface("com.deepin.daemon.Network")]
    interface INetwork : IDBusObject
    {
        Task<ObjectPath> ActivateAccessPointAsync(string Uuid, ObjectPath ApPath, ObjectPath DevPath);
        Task<ObjectPath> ActivateConnectionAsync(string Uuid, ObjectPath DevPath);
        Task DeactivateConnectionAsync(string Uuid);
        Task DeleteConnectionAsync(string Uuid);
        Task DisableWirelessHotspotModeAsync(ObjectPath DevPath);
        Task DisconnectDeviceAsync(ObjectPath DevPath);
        Task EnableDeviceAsync(ObjectPath DevPath, bool Enabled);
        Task EnableWirelessHotspotModeAsync(ObjectPath DevPath);
        Task<string> GetAccessPointsAsync(ObjectPath Path);
        Task<string> GetActiveConnectionInfoAsync();
        Task<string> GetAutoProxyAsync();
        Task<(string host, string port)> GetProxyAsync(string ProxyType);
        Task<string> GetProxyIgnoreHostsAsync();
        Task<string> GetProxyMethodAsync();
        Task<string[]> GetSupportedConnectionTypesAsync();
        Task<bool> IsDeviceEnabledAsync(ObjectPath DevPath);
        Task<bool> IsWirelessHotspotModeEnabledAsync(ObjectPath DevPath);
        Task<ObjectPath[]> ListDeviceConnectionsAsync(ObjectPath DevPath);
        Task RequestWirelessScanAsync();
        Task SetAutoProxyAsync(string ProxyAuto);
        Task SetDeviceManagedAsync(string DevPathOrIfc, bool Managed);
        Task SetProxyAsync(string ProxyType, string Host, string Port);
        Task SetProxyIgnoreHostsAsync(string IgnoreHosts);
        Task SetProxyMethodAsync(string ProxyMode);
        Task<IDisposable> WatchAccessPointAddedAsync(Action<(string devPath, string apJSON)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAccessPointRemovedAsync(Action<(string devPath, string apJSON)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAccessPointPropertiesChangedAsync(Action<(string devPath, string apJSON)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeviceEnabledAsync(Action<(string devPath, bool enabled)> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<NetworkProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class NetworkProperties
    {
        private string _Devices = default (string);
        public string Devices
        {
            get
            {
                return _Devices;
            }

            set
            {
                _Devices = (value);
            }
        }

        private string _Connections = default (string);
        public string Connections
        {
            get
            {
                return _Connections;
            }

            set
            {
                _Connections = (value);
            }
        }

        private string _ActiveConnections = default (string);
        public string ActiveConnections
        {
            get
            {
                return _ActiveConnections;
            }

            set
            {
                _ActiveConnections = (value);
            }
        }

        private uint _State = default (uint);
        public uint State
        {
            get
            {
                return _State;
            }

            set
            {
                _State = (value);
            }
        }

        private uint _Connectivity = default (uint);
        public uint Connectivity
        {
            get
            {
                return _Connectivity;
            }

            set
            {
                _Connectivity = (value);
            }
        }

        private bool _NetworkingEnabled = default (bool);
        public bool NetworkingEnabled
        {
            get
            {
                return _NetworkingEnabled;
            }

            set
            {
                _NetworkingEnabled = (value);
            }
        }

        private bool _VpnEnabled = default (bool);
        public bool VpnEnabled
        {
            get
            {
                return _VpnEnabled;
            }

            set
            {
                _VpnEnabled = (value);
            }
        }
    }

    static class NetworkExtensions
    {
        public static Task<string> GetDevicesAsync(this INetwork o) => o.GetAsync<string>("Devices");
        public static Task<string> GetConnectionsAsync(this INetwork o) => o.GetAsync<string>("Connections");
        public static Task<string> GetActiveConnectionsAsync(this INetwork o) => o.GetAsync<string>("ActiveConnections");
        public static Task<uint> GetStateAsync(this INetwork o) => o.GetAsync<uint>("State");
        public static Task<uint> GetConnectivityAsync(this INetwork o) => o.GetAsync<uint>("Connectivity");
        public static Task<bool> GetNetworkingEnabledAsync(this INetwork o) => o.GetAsync<bool>("NetworkingEnabled");
        public static Task<bool> GetVpnEnabledAsync(this INetwork o) => o.GetAsync<bool>("VpnEnabled");
        public static Task SetNetworkingEnabledAsync(this INetwork o, bool val) => o.SetAsync("NetworkingEnabled", val);
        public static Task SetVpnEnabledAsync(this INetwork o, bool val) => o.SetAsync("VpnEnabled", val);
    }

    [DBusInterface("com.deepin.daemon.Network.ProxyChains")]
    interface IProxyChains : IDBusObject
    {
        Task SetAsync(string Type0, string Ip, uint Port, string User, string Password);
        Task<T> GetAsync<T>(string prop);
        Task<ProxyChainsProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class ProxyChainsProperties
    {
        private string _Password = default (string);
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = (value);
            }
        }

        private string _Type = default (string);
        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = (value);
            }
        }

        private string _IP = default (string);
        public string IP
        {
            get
            {
                return _IP;
            }

            set
            {
                _IP = (value);
            }
        }

        private uint _Port = default (uint);
        public uint Port
        {
            get
            {
                return _Port;
            }

            set
            {
                _Port = (value);
            }
        }

        private string _User = default (string);
        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                _User = (value);
            }
        }
    }

    static class ProxyChainsExtensions
    {
        public static Task<string> GetPasswordAsync(this IProxyChains o) => o.GetAsync<string>("Password");
        public static Task<string> GetTypeAsync(this IProxyChains o) => o.GetAsync<string>("Type");
        public static Task<string> GetIPAsync(this IProxyChains o) => o.GetAsync<string>("IP");
        public static Task<uint> GetPortAsync(this IProxyChains o) => o.GetAsync<uint>("Port");
        public static Task<string> GetUserAsync(this IProxyChains o) => o.GetAsync<string>("User");
    }

    [DBusInterface("com.deepin.daemon.ClipboardManager")]
    interface IClipboardManager : IDBusObject
    {
        Task BecomeClipboardOwnerAsync();
        Task RemoveTargetAsync(uint Target);
        Task SaveClipboardAsync();
        Task WriteContentAsync();
    }

    [DBusInterface("com.deepin.daemon.SystemInfo")]
    interface ISystemInfo : IDBusObject
    {
        Task<T> GetAsync<T>(string prop);
        Task<SystemInfoProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SystemInfoProperties
    {
        private long _SystemType = default (long);
        public long SystemType
        {
            get
            {
                return _SystemType;
            }

            set
            {
                _SystemType = (value);
            }
        }

        private string _Version = default (string);
        public string Version
        {
            get
            {
                return _Version;
            }

            set
            {
                _Version = (value);
            }
        }

        private string _DistroID = default (string);
        public string DistroID
        {
            get
            {
                return _DistroID;
            }

            set
            {
                _DistroID = (value);
            }
        }

        private string _DistroDesc = default (string);
        public string DistroDesc
        {
            get
            {
                return _DistroDesc;
            }

            set
            {
                _DistroDesc = (value);
            }
        }

        private string _DistroVer = default (string);
        public string DistroVer
        {
            get
            {
                return _DistroVer;
            }

            set
            {
                _DistroVer = (value);
            }
        }

        private string _Processor = default (string);
        public string Processor
        {
            get
            {
                return _Processor;
            }

            set
            {
                _Processor = (value);
            }
        }

        private ulong _DiskCap = default (ulong);
        public ulong DiskCap
        {
            get
            {
                return _DiskCap;
            }

            set
            {
                _DiskCap = (value);
            }
        }

        private ulong _MemoryCap = default (ulong);
        public ulong MemoryCap
        {
            get
            {
                return _MemoryCap;
            }

            set
            {
                _MemoryCap = (value);
            }
        }
    }

    static class SystemInfoExtensions
    {
        public static Task<long> GetSystemTypeAsync(this ISystemInfo o) => o.GetAsync<long>("SystemType");
        public static Task<string> GetVersionAsync(this ISystemInfo o) => o.GetAsync<string>("Version");
        public static Task<string> GetDistroIDAsync(this ISystemInfo o) => o.GetAsync<string>("DistroID");
        public static Task<string> GetDistroDescAsync(this ISystemInfo o) => o.GetAsync<string>("DistroDesc");
        public static Task<string> GetDistroVerAsync(this ISystemInfo o) => o.GetAsync<string>("DistroVer");
        public static Task<string> GetProcessorAsync(this ISystemInfo o) => o.GetAsync<string>("Processor");
        public static Task<ulong> GetDiskCapAsync(this ISystemInfo o) => o.GetAsync<ulong>("DiskCap");
        public static Task<ulong> GetMemoryCapAsync(this ISystemInfo o) => o.GetAsync<ulong>("MemoryCap");
    }

    [DBusInterface("com.deepin.daemon.Bluetooth")]
    interface IBluetooth : IDBusObject
    {
        Task ClearUnpairedDeviceAsync();
        Task ConfirmAsync(ObjectPath Device, bool Accept);
        Task ConnectDeviceAsync(ObjectPath Device);
        Task<string> DebugInfoAsync();
        Task DisconnectDeviceAsync(ObjectPath Device);
        Task FeedPasskeyAsync(ObjectPath Device, bool Accept, uint Passkey);
        Task FeedPinCodeAsync(ObjectPath Device, bool Accept, string PinCode);
        Task<string> GetAdaptersAsync();
        Task<string> GetDevicesAsync(ObjectPath Adapter);
        Task RemoveDeviceAsync(ObjectPath Adapter, ObjectPath Device);
        Task RequestDiscoveryAsync(ObjectPath Adapter);
        Task SetAdapterAliasAsync(ObjectPath Adapter, string Alias);
        Task SetAdapterDiscoverableAsync(ObjectPath Adapter, bool Discoverable);
        Task SetAdapterDiscoverableTimeoutAsync(ObjectPath Adapter, uint Timeout);
        Task SetAdapterDiscoveringAsync(ObjectPath Adapter, bool Discovering);
        Task SetAdapterPoweredAsync(ObjectPath Adapter, bool Powered);
        Task SetDeviceAliasAsync(ObjectPath Device, string Alias);
        Task SetDeviceTrustedAsync(ObjectPath Device, bool Trusted);
        Task<IDisposable> WatchAdapterAddedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAdapterRemovedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAdapterPropertiesChangedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeviceAddedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeviceRemovedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDevicePropertiesChangedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDisplayPinCodeAsync(Action<(ObjectPath device, string pinCode)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDisplayPasskeyAsync(Action<(ObjectPath device, uint passkey, uint entered)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRequestConfirmationAsync(Action<(ObjectPath device, string passkey)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRequestAuthorizationAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRequestPinCodeAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRequestPasskeyAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCancelledAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<BluetoothProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class BluetoothProperties
    {
        private uint _State = default (uint);
        public uint State
        {
            get
            {
                return _State;
            }

            set
            {
                _State = (value);
            }
        }
    }

    static class BluetoothExtensions
    {
        public static Task<uint> GetStateAsync(this IBluetooth o) => o.GetAsync<uint>("State");
    }

    [DBusInterface("com.deepin.daemon.Gesture")]
    interface IGesture : IDBusObject
    {
        Task<uint> GetLongPressDurationAsync();
        Task SetLongPressDurationAsync(uint Duration);
        Task<T> GetAsync<T>(string prop);
        Task<GestureProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class GestureProperties
    {
        private (string, string, int, (string, string))[] _Infos = default ((string, string, int, (string, string))[]);
        public (string, string, int, (string, string))[] Infos
        {
            get
            {
                return _Infos;
            }

            set
            {
                _Infos = (value);
            }
        }
    }

    static class GestureExtensions
    {
        public static Task<(string, string, int, (string, string))[]> GetInfosAsync(this IGesture o) => o.GetAsync<(string, string, int, (string, string))[]>("Infos");
    }

    [DBusInterface("com.deepin.daemon.Keybinding")]
    interface IKeybinding : IDBusObject
    {
        Task<(string ret0, bool ret1)> AddAsync(string Name, string Action, string Keystroke);
        Task<(string id, int type)> AddCustomShortcutAsync(string Name, string Action, string Keystroke);
        Task AddShortcutKeystrokeAsync(string Id, int Type, string Keystroke);
        Task<(bool available, string shortcut)> CheckAvaliableAsync(string Keystroke);
        Task ClearShortcutKeystrokesAsync(string Id, int Type);
        Task DeleteAsync(string Id, int Type);
        Task DeleteCustomShortcutAsync(string Id);
        Task DeleteShortcutKeystrokeAsync(string Id, int Type, string Keystroke);
        Task DisableAsync(string Id, int Type);
        Task<int> GetCapsLockStateAsync();
        Task<string> GetShortcutAsync(string Id, int Type);
        Task GrabScreenAsync();
        Task<string> ListAsync();
        Task<string> ListAllShortcutsAsync();
        Task<string> ListShortcutsByTypeAsync(int Type);
        Task<string> LookupConflictingShortcutAsync(string Keystroke);
        Task<(bool ret0, string ret1)> ModifiedAccelAsync(string Id, int Type, string Keystroke, bool Add);
        Task ModifyCustomShortcutAsync(string Id, string Name, string Cmd, string Keystroke);
        Task<string> QueryAsync(string Id, int Type);
        Task ResetAsync();
        Task<string> SearchShortcutsAsync(string Query);
        Task SelectKeystrokeAsync();
        Task SetCapsLockStateAsync(int State);
        Task SetNumLockStateAsync(int State);
        Task<IDisposable> WatchAddedAsync(Action<(string id, int typ)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeletedAsync(Action<(string id, int typ)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchChangedAsync(Action<(string id, int typ)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchKeyEventAsync(Action<(bool pressed, string keystroke)> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<KeybindingProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class KeybindingProperties
    {
        private int _NumLockState = default (int);
        public int NumLockState
        {
            get
            {
                return _NumLockState;
            }

            set
            {
                _NumLockState = (value);
            }
        }

        private uint _ShortcutSwitchLayout = default (uint);
        public uint ShortcutSwitchLayout
        {
            get
            {
                return _ShortcutSwitchLayout;
            }

            set
            {
                _ShortcutSwitchLayout = (value);
            }
        }
    }

    static class KeybindingExtensions
    {
        public static Task<int> GetNumLockStateAsync(this IKeybinding o) => o.GetAsync<int>("NumLockState");
        public static Task<uint> GetShortcutSwitchLayoutAsync(this IKeybinding o) => o.GetAsync<uint>("ShortcutSwitchLayout");
        public static Task SetShortcutSwitchLayoutAsync(this IKeybinding o, uint val) => o.SetAsync("ShortcutSwitchLayout", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevices")]
    interface IInputDevices : IDBusObject
    {
        Task<T> GetAsync<T>(string prop);
        Task<InputDevicesProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class InputDevicesProperties
    {
        private (string, string)[] _Infos = default ((string, string)[]);
        public (string, string)[] Infos
        {
            get
            {
                return _Infos;
            }

            set
            {
                _Infos = (value);
            }
        }

        private uint _WheelSpeed = default (uint);
        public uint WheelSpeed
        {
            get
            {
                return _WheelSpeed;
            }

            set
            {
                _WheelSpeed = (value);
            }
        }
    }

    static class InputDevicesExtensions
    {
        public static Task<(string, string)[]> GetInfosAsync(this IInputDevices o) => o.GetAsync<(string, string)[]>("Infos");
        public static Task<uint> GetWheelSpeedAsync(this IInputDevices o) => o.GetAsync<uint>("WheelSpeed");
        public static Task SetWheelSpeedAsync(this IInputDevices o, uint val) => o.SetAsync("WheelSpeed", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevice.Mouse")]
    interface IMouse : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<MouseProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class MouseProperties
    {
        private bool _NaturalScroll = default (bool);
        public bool NaturalScroll
        {
            get
            {
                return _NaturalScroll;
            }

            set
            {
                _NaturalScroll = (value);
            }
        }

        private double _MotionAcceleration = default (double);
        public double MotionAcceleration
        {
            get
            {
                return _MotionAcceleration;
            }

            set
            {
                _MotionAcceleration = (value);
            }
        }

        private double _MotionScaling = default (double);
        public double MotionScaling
        {
            get
            {
                return _MotionScaling;
            }

            set
            {
                _MotionScaling = (value);
            }
        }

        private int _DragThreshold = default (int);
        public int DragThreshold
        {
            get
            {
                return _DragThreshold;
            }

            set
            {
                _DragThreshold = (value);
            }
        }

        private bool _Exist = default (bool);
        public bool Exist
        {
            get
            {
                return _Exist;
            }

            set
            {
                _Exist = (value);
            }
        }

        private bool _LeftHanded = default (bool);
        public bool LeftHanded
        {
            get
            {
                return _LeftHanded;
            }

            set
            {
                _LeftHanded = (value);
            }
        }

        private bool _MiddleButtonEmulation = default (bool);
        public bool MiddleButtonEmulation
        {
            get
            {
                return _MiddleButtonEmulation;
            }

            set
            {
                _MiddleButtonEmulation = (value);
            }
        }

        private bool _AdaptiveAccelProfile = default (bool);
        public bool AdaptiveAccelProfile
        {
            get
            {
                return _AdaptiveAccelProfile;
            }

            set
            {
                _AdaptiveAccelProfile = (value);
            }
        }

        private double _MotionThreshold = default (double);
        public double MotionThreshold
        {
            get
            {
                return _MotionThreshold;
            }

            set
            {
                _MotionThreshold = (value);
            }
        }

        private int _DoubleClick = default (int);
        public int DoubleClick
        {
            get
            {
                return _DoubleClick;
            }

            set
            {
                _DoubleClick = (value);
            }
        }

        private string _DeviceList = default (string);
        public string DeviceList
        {
            get
            {
                return _DeviceList;
            }

            set
            {
                _DeviceList = (value);
            }
        }

        private bool _DisableTpad = default (bool);
        public bool DisableTpad
        {
            get
            {
                return _DisableTpad;
            }

            set
            {
                _DisableTpad = (value);
            }
        }
    }

    static class MouseExtensions
    {
        public static Task<bool> GetNaturalScrollAsync(this IMouse o) => o.GetAsync<bool>("NaturalScroll");
        public static Task<double> GetMotionAccelerationAsync(this IMouse o) => o.GetAsync<double>("MotionAcceleration");
        public static Task<double> GetMotionScalingAsync(this IMouse o) => o.GetAsync<double>("MotionScaling");
        public static Task<int> GetDragThresholdAsync(this IMouse o) => o.GetAsync<int>("DragThreshold");
        public static Task<bool> GetExistAsync(this IMouse o) => o.GetAsync<bool>("Exist");
        public static Task<bool> GetLeftHandedAsync(this IMouse o) => o.GetAsync<bool>("LeftHanded");
        public static Task<bool> GetMiddleButtonEmulationAsync(this IMouse o) => o.GetAsync<bool>("MiddleButtonEmulation");
        public static Task<bool> GetAdaptiveAccelProfileAsync(this IMouse o) => o.GetAsync<bool>("AdaptiveAccelProfile");
        public static Task<double> GetMotionThresholdAsync(this IMouse o) => o.GetAsync<double>("MotionThreshold");
        public static Task<int> GetDoubleClickAsync(this IMouse o) => o.GetAsync<int>("DoubleClick");
        public static Task<string> GetDeviceListAsync(this IMouse o) => o.GetAsync<string>("DeviceList");
        public static Task<bool> GetDisableTpadAsync(this IMouse o) => o.GetAsync<bool>("DisableTpad");
        public static Task SetNaturalScrollAsync(this IMouse o, bool val) => o.SetAsync("NaturalScroll", val);
        public static Task SetMotionAccelerationAsync(this IMouse o, double val) => o.SetAsync("MotionAcceleration", val);
        public static Task SetMotionScalingAsync(this IMouse o, double val) => o.SetAsync("MotionScaling", val);
        public static Task SetDragThresholdAsync(this IMouse o, int val) => o.SetAsync("DragThreshold", val);
        public static Task SetLeftHandedAsync(this IMouse o, bool val) => o.SetAsync("LeftHanded", val);
        public static Task SetMiddleButtonEmulationAsync(this IMouse o, bool val) => o.SetAsync("MiddleButtonEmulation", val);
        public static Task SetAdaptiveAccelProfileAsync(this IMouse o, bool val) => o.SetAsync("AdaptiveAccelProfile", val);
        public static Task SetMotionThresholdAsync(this IMouse o, double val) => o.SetAsync("MotionThreshold", val);
        public static Task SetDoubleClickAsync(this IMouse o, int val) => o.SetAsync("DoubleClick", val);
        public static Task SetDisableTpadAsync(this IMouse o, bool val) => o.SetAsync("DisableTpad", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevice.TrackPoint")]
    interface ITrackPoint : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<TrackPointProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class TrackPointProperties
    {
        private double _MotionAcceleration = default (double);
        public double MotionAcceleration
        {
            get
            {
                return _MotionAcceleration;
            }

            set
            {
                _MotionAcceleration = (value);
            }
        }

        private double _MotionThreshold = default (double);
        public double MotionThreshold
        {
            get
            {
                return _MotionThreshold;
            }

            set
            {
                _MotionThreshold = (value);
            }
        }

        private double _MotionScaling = default (double);
        public double MotionScaling
        {
            get
            {
                return _MotionScaling;
            }

            set
            {
                _MotionScaling = (value);
            }
        }

        private bool _MiddleButtonEnabled = default (bool);
        public bool MiddleButtonEnabled
        {
            get
            {
                return _MiddleButtonEnabled;
            }

            set
            {
                _MiddleButtonEnabled = (value);
            }
        }

        private bool _WheelEmulation = default (bool);
        public bool WheelEmulation
        {
            get
            {
                return _WheelEmulation;
            }

            set
            {
                _WheelEmulation = (value);
            }
        }

        private int _WheelEmulationButton = default (int);
        public int WheelEmulationButton
        {
            get
            {
                return _WheelEmulationButton;
            }

            set
            {
                _WheelEmulationButton = (value);
            }
        }

        private int _WheelEmulationTimeout = default (int);
        public int WheelEmulationTimeout
        {
            get
            {
                return _WheelEmulationTimeout;
            }

            set
            {
                _WheelEmulationTimeout = (value);
            }
        }

        private bool _LeftHanded = default (bool);
        public bool LeftHanded
        {
            get
            {
                return _LeftHanded;
            }

            set
            {
                _LeftHanded = (value);
            }
        }

        private string _DeviceList = default (string);
        public string DeviceList
        {
            get
            {
                return _DeviceList;
            }

            set
            {
                _DeviceList = (value);
            }
        }

        private bool _Exist = default (bool);
        public bool Exist
        {
            get
            {
                return _Exist;
            }

            set
            {
                _Exist = (value);
            }
        }

        private bool _WheelHorizScroll = default (bool);
        public bool WheelHorizScroll
        {
            get
            {
                return _WheelHorizScroll;
            }

            set
            {
                _WheelHorizScroll = (value);
            }
        }

        private int _MiddleButtonTimeout = default (int);
        public int MiddleButtonTimeout
        {
            get
            {
                return _MiddleButtonTimeout;
            }

            set
            {
                _MiddleButtonTimeout = (value);
            }
        }
    }

    static class TrackPointExtensions
    {
        public static Task<double> GetMotionAccelerationAsync(this ITrackPoint o) => o.GetAsync<double>("MotionAcceleration");
        public static Task<double> GetMotionThresholdAsync(this ITrackPoint o) => o.GetAsync<double>("MotionThreshold");
        public static Task<double> GetMotionScalingAsync(this ITrackPoint o) => o.GetAsync<double>("MotionScaling");
        public static Task<bool> GetMiddleButtonEnabledAsync(this ITrackPoint o) => o.GetAsync<bool>("MiddleButtonEnabled");
        public static Task<bool> GetWheelEmulationAsync(this ITrackPoint o) => o.GetAsync<bool>("WheelEmulation");
        public static Task<int> GetWheelEmulationButtonAsync(this ITrackPoint o) => o.GetAsync<int>("WheelEmulationButton");
        public static Task<int> GetWheelEmulationTimeoutAsync(this ITrackPoint o) => o.GetAsync<int>("WheelEmulationTimeout");
        public static Task<bool> GetLeftHandedAsync(this ITrackPoint o) => o.GetAsync<bool>("LeftHanded");
        public static Task<string> GetDeviceListAsync(this ITrackPoint o) => o.GetAsync<string>("DeviceList");
        public static Task<bool> GetExistAsync(this ITrackPoint o) => o.GetAsync<bool>("Exist");
        public static Task<bool> GetWheelHorizScrollAsync(this ITrackPoint o) => o.GetAsync<bool>("WheelHorizScroll");
        public static Task<int> GetMiddleButtonTimeoutAsync(this ITrackPoint o) => o.GetAsync<int>("MiddleButtonTimeout");
        public static Task SetMotionAccelerationAsync(this ITrackPoint o, double val) => o.SetAsync("MotionAcceleration", val);
        public static Task SetMotionThresholdAsync(this ITrackPoint o, double val) => o.SetAsync("MotionThreshold", val);
        public static Task SetMotionScalingAsync(this ITrackPoint o, double val) => o.SetAsync("MotionScaling", val);
        public static Task SetMiddleButtonEnabledAsync(this ITrackPoint o, bool val) => o.SetAsync("MiddleButtonEnabled", val);
        public static Task SetWheelEmulationAsync(this ITrackPoint o, bool val) => o.SetAsync("WheelEmulation", val);
        public static Task SetWheelEmulationButtonAsync(this ITrackPoint o, int val) => o.SetAsync("WheelEmulationButton", val);
        public static Task SetWheelEmulationTimeoutAsync(this ITrackPoint o, int val) => o.SetAsync("WheelEmulationTimeout", val);
        public static Task SetLeftHandedAsync(this ITrackPoint o, bool val) => o.SetAsync("LeftHanded", val);
        public static Task SetWheelHorizScrollAsync(this ITrackPoint o, bool val) => o.SetAsync("WheelHorizScroll", val);
        public static Task SetMiddleButtonTimeoutAsync(this ITrackPoint o, int val) => o.SetAsync("MiddleButtonTimeout", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevice.Keyboard")]
    interface IKeyboard : IDBusObject
    {
        Task AddLayoutOptionAsync(string Option);
        Task AddUserLayoutAsync(string Layout);
        Task ClearLayoutOptionAsync();
        Task DeleteLayoutOptionAsync(string Option);
        Task DeleteUserLayoutAsync(string Layout);
        Task<string> GetLayoutDescAsync(string Layout);
        Task<IDictionary<string, string>> LayoutListAsync();
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<KeyboardProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class KeyboardProperties
    {
        private int _LayoutScope = default (int);
        public int LayoutScope
        {
            get
            {
                return _LayoutScope;
            }

            set
            {
                _LayoutScope = (value);
            }
        }

        private string[] _UserLayoutList = default (string[]);
        public string[] UserLayoutList
        {
            get
            {
                return _UserLayoutList;
            }

            set
            {
                _UserLayoutList = (value);
            }
        }

        private bool _RepeatEnabled = default (bool);
        public bool RepeatEnabled
        {
            get
            {
                return _RepeatEnabled;
            }

            set
            {
                _RepeatEnabled = (value);
            }
        }

        private bool _CapslockToggle = default (bool);
        public bool CapslockToggle
        {
            get
            {
                return _CapslockToggle;
            }

            set
            {
                _CapslockToggle = (value);
            }
        }

        private int _CursorBlink = default (int);
        public int CursorBlink
        {
            get
            {
                return _CursorBlink;
            }

            set
            {
                _CursorBlink = (value);
            }
        }

        private uint _RepeatInterval = default (uint);
        public uint RepeatInterval
        {
            get
            {
                return _RepeatInterval;
            }

            set
            {
                _RepeatInterval = (value);
            }
        }

        private string _CurrentLayout = default (string);
        public string CurrentLayout
        {
            get
            {
                return _CurrentLayout;
            }

            set
            {
                _CurrentLayout = (value);
            }
        }

        private string[] _UserOptionList = default (string[]);
        public string[] UserOptionList
        {
            get
            {
                return _UserOptionList;
            }

            set
            {
                _UserOptionList = (value);
            }
        }

        private uint _RepeatDelay = default (uint);
        public uint RepeatDelay
        {
            get
            {
                return _RepeatDelay;
            }

            set
            {
                _RepeatDelay = (value);
            }
        }
    }

    static class KeyboardExtensions
    {
        public static Task<int> GetLayoutScopeAsync(this IKeyboard o) => o.GetAsync<int>("LayoutScope");
        public static Task<string[]> GetUserLayoutListAsync(this IKeyboard o) => o.GetAsync<string[]>("UserLayoutList");
        public static Task<bool> GetRepeatEnabledAsync(this IKeyboard o) => o.GetAsync<bool>("RepeatEnabled");
        public static Task<bool> GetCapslockToggleAsync(this IKeyboard o) => o.GetAsync<bool>("CapslockToggle");
        public static Task<int> GetCursorBlinkAsync(this IKeyboard o) => o.GetAsync<int>("CursorBlink");
        public static Task<uint> GetRepeatIntervalAsync(this IKeyboard o) => o.GetAsync<uint>("RepeatInterval");
        public static Task<string> GetCurrentLayoutAsync(this IKeyboard o) => o.GetAsync<string>("CurrentLayout");
        public static Task<string[]> GetUserOptionListAsync(this IKeyboard o) => o.GetAsync<string[]>("UserOptionList");
        public static Task<uint> GetRepeatDelayAsync(this IKeyboard o) => o.GetAsync<uint>("RepeatDelay");
        public static Task SetLayoutScopeAsync(this IKeyboard o, int val) => o.SetAsync("LayoutScope", val);
        public static Task SetRepeatEnabledAsync(this IKeyboard o, bool val) => o.SetAsync("RepeatEnabled", val);
        public static Task SetCapslockToggleAsync(this IKeyboard o, bool val) => o.SetAsync("CapslockToggle", val);
        public static Task SetCursorBlinkAsync(this IKeyboard o, int val) => o.SetAsync("CursorBlink", val);
        public static Task SetRepeatIntervalAsync(this IKeyboard o, uint val) => o.SetAsync("RepeatInterval", val);
        public static Task SetCurrentLayoutAsync(this IKeyboard o, string val) => o.SetAsync("CurrentLayout", val);
        public static Task SetRepeatDelayAsync(this IKeyboard o, uint val) => o.SetAsync("RepeatDelay", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevice.Wacom")]
    interface IWacom : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<WacomProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class WacomProperties
    {
        private uint _StylusPressureSensitive = default (uint);
        public uint StylusPressureSensitive
        {
            get
            {
                return _StylusPressureSensitive;
            }

            set
            {
                _StylusPressureSensitive = (value);
            }
        }

        private uint _StylusRawSample = default (uint);
        public uint StylusRawSample
        {
            get
            {
                return _StylusRawSample;
            }

            set
            {
                _StylusRawSample = (value);
            }
        }

        private uint _StylusThreshold = default (uint);
        public uint StylusThreshold
        {
            get
            {
                return _StylusThreshold;
            }

            set
            {
                _StylusThreshold = (value);
            }
        }

        private uint _EraserThreshold = default (uint);
        public uint EraserThreshold
        {
            get
            {
                return _EraserThreshold;
            }

            set
            {
                _EraserThreshold = (value);
            }
        }

        private bool _ForceProportions = default (bool);
        public bool ForceProportions
        {
            get
            {
                return _ForceProportions;
            }

            set
            {
                _ForceProportions = (value);
            }
        }

        private string _KeyUpAction = default (string);
        public string KeyUpAction
        {
            get
            {
                return _KeyUpAction;
            }

            set
            {
                _KeyUpAction = (value);
            }
        }

        private uint _EraserPressureSensitive = default (uint);
        public uint EraserPressureSensitive
        {
            get
            {
                return _EraserPressureSensitive;
            }

            set
            {
                _EraserPressureSensitive = (value);
            }
        }

        private (string, string)[] _ActionInfos = default ((string, string)[]);
        public (string, string)[] ActionInfos
        {
            get
            {
                return _ActionInfos;
            }

            set
            {
                _ActionInfos = (value);
            }
        }

        private string _DeviceList = default (string);
        public string DeviceList
        {
            get
            {
                return _DeviceList;
            }

            set
            {
                _DeviceList = (value);
            }
        }

        private string _MapOutput = default (string);
        public string MapOutput
        {
            get
            {
                return _MapOutput;
            }

            set
            {
                _MapOutput = (value);
            }
        }

        private bool _CursorMode = default (bool);
        public bool CursorMode
        {
            get
            {
                return _CursorMode;
            }

            set
            {
                _CursorMode = (value);
            }
        }

        private uint _EraserRawSample = default (uint);
        public uint EraserRawSample
        {
            get
            {
                return _EraserRawSample;
            }

            set
            {
                _EraserRawSample = (value);
            }
        }

        private bool _Exist = default (bool);
        public bool Exist
        {
            get
            {
                return _Exist;
            }

            set
            {
                _Exist = (value);
            }
        }

        private bool _LeftHanded = default (bool);
        public bool LeftHanded
        {
            get
            {
                return _LeftHanded;
            }

            set
            {
                _LeftHanded = (value);
            }
        }

        private string _KeyDownAction = default (string);
        public string KeyDownAction
        {
            get
            {
                return _KeyDownAction;
            }

            set
            {
                _KeyDownAction = (value);
            }
        }

        private uint _Suppress = default (uint);
        public uint Suppress
        {
            get
            {
                return _Suppress;
            }

            set
            {
                _Suppress = (value);
            }
        }
    }

    static class WacomExtensions
    {
        public static Task<uint> GetStylusPressureSensitiveAsync(this IWacom o) => o.GetAsync<uint>("StylusPressureSensitive");
        public static Task<uint> GetStylusRawSampleAsync(this IWacom o) => o.GetAsync<uint>("StylusRawSample");
        public static Task<uint> GetStylusThresholdAsync(this IWacom o) => o.GetAsync<uint>("StylusThreshold");
        public static Task<uint> GetEraserThresholdAsync(this IWacom o) => o.GetAsync<uint>("EraserThreshold");
        public static Task<bool> GetForceProportionsAsync(this IWacom o) => o.GetAsync<bool>("ForceProportions");
        public static Task<string> GetKeyUpActionAsync(this IWacom o) => o.GetAsync<string>("KeyUpAction");
        public static Task<uint> GetEraserPressureSensitiveAsync(this IWacom o) => o.GetAsync<uint>("EraserPressureSensitive");
        public static Task<(string, string)[]> GetActionInfosAsync(this IWacom o) => o.GetAsync<(string, string)[]>("ActionInfos");
        public static Task<string> GetDeviceListAsync(this IWacom o) => o.GetAsync<string>("DeviceList");
        public static Task<string> GetMapOutputAsync(this IWacom o) => o.GetAsync<string>("MapOutput");
        public static Task<bool> GetCursorModeAsync(this IWacom o) => o.GetAsync<bool>("CursorMode");
        public static Task<uint> GetEraserRawSampleAsync(this IWacom o) => o.GetAsync<uint>("EraserRawSample");
        public static Task<bool> GetExistAsync(this IWacom o) => o.GetAsync<bool>("Exist");
        public static Task<bool> GetLeftHandedAsync(this IWacom o) => o.GetAsync<bool>("LeftHanded");
        public static Task<string> GetKeyDownActionAsync(this IWacom o) => o.GetAsync<string>("KeyDownAction");
        public static Task<uint> GetSuppressAsync(this IWacom o) => o.GetAsync<uint>("Suppress");
        public static Task SetStylusPressureSensitiveAsync(this IWacom o, uint val) => o.SetAsync("StylusPressureSensitive", val);
        public static Task SetStylusRawSampleAsync(this IWacom o, uint val) => o.SetAsync("StylusRawSample", val);
        public static Task SetStylusThresholdAsync(this IWacom o, uint val) => o.SetAsync("StylusThreshold", val);
        public static Task SetEraserThresholdAsync(this IWacom o, uint val) => o.SetAsync("EraserThreshold", val);
        public static Task SetForceProportionsAsync(this IWacom o, bool val) => o.SetAsync("ForceProportions", val);
        public static Task SetKeyUpActionAsync(this IWacom o, string val) => o.SetAsync("KeyUpAction", val);
        public static Task SetEraserPressureSensitiveAsync(this IWacom o, uint val) => o.SetAsync("EraserPressureSensitive", val);
        public static Task SetCursorModeAsync(this IWacom o, bool val) => o.SetAsync("CursorMode", val);
        public static Task SetEraserRawSampleAsync(this IWacom o, uint val) => o.SetAsync("EraserRawSample", val);
        public static Task SetLeftHandedAsync(this IWacom o, bool val) => o.SetAsync("LeftHanded", val);
        public static Task SetKeyDownActionAsync(this IWacom o, string val) => o.SetAsync("KeyDownAction", val);
        public static Task SetSuppressAsync(this IWacom o, uint val) => o.SetAsync("Suppress", val);
    }

    [DBusInterface("com.deepin.daemon.InputDevice.TouchPad")]
    interface ITouchPad : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<TouchPadProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class TouchPadProperties
    {
        private int _DragThreshold = default (int);
        public int DragThreshold
        {
            get
            {
                return _DragThreshold;
            }

            set
            {
                _DragThreshold = (value);
            }
        }

        private int _DeltaScroll = default (int);
        public int DeltaScroll
        {
            get
            {
                return _DeltaScroll;
            }

            set
            {
                _DeltaScroll = (value);
            }
        }

        private int _PalmMinZ = default (int);
        public int PalmMinZ
        {
            get
            {
                return _PalmMinZ;
            }

            set
            {
                _PalmMinZ = (value);
            }
        }

        private int _DoubleClick = default (int);
        public int DoubleClick
        {
            get
            {
                return _DoubleClick;
            }

            set
            {
                _DoubleClick = (value);
            }
        }

        private bool _TPadEnable = default (bool);
        public bool TPadEnable
        {
            get
            {
                return _TPadEnable;
            }

            set
            {
                _TPadEnable = (value);
            }
        }

        private bool _EdgeScroll = default (bool);
        public bool EdgeScroll
        {
            get
            {
                return _EdgeScroll;
            }

            set
            {
                _EdgeScroll = (value);
            }
        }

        private bool _VertScroll = default (bool);
        public bool VertScroll
        {
            get
            {
                return _VertScroll;
            }

            set
            {
                _VertScroll = (value);
            }
        }

        private int _PalmMinWidth = default (int);
        public int PalmMinWidth
        {
            get
            {
                return _PalmMinWidth;
            }

            set
            {
                _PalmMinWidth = (value);
            }
        }

        private bool _Exist = default (bool);
        public bool Exist
        {
            get
            {
                return _Exist;
            }

            set
            {
                _Exist = (value);
            }
        }

        private bool _NaturalScroll = default (bool);
        public bool NaturalScroll
        {
            get
            {
                return _NaturalScroll;
            }

            set
            {
                _NaturalScroll = (value);
            }
        }

        private bool _HorizScroll = default (bool);
        public bool HorizScroll
        {
            get
            {
                return _HorizScroll;
            }

            set
            {
                _HorizScroll = (value);
            }
        }

        private bool _PalmDetect = default (bool);
        public bool PalmDetect
        {
            get
            {
                return _PalmDetect;
            }

            set
            {
                _PalmDetect = (value);
            }
        }

        private double _MotionAcceleration = default (double);
        public double MotionAcceleration
        {
            get
            {
                return _MotionAcceleration;
            }

            set
            {
                _MotionAcceleration = (value);
            }
        }

        private double _MotionThreshold = default (double);
        public double MotionThreshold
        {
            get
            {
                return _MotionThreshold;
            }

            set
            {
                _MotionThreshold = (value);
            }
        }

        private bool _LeftHanded = default (bool);
        public bool LeftHanded
        {
            get
            {
                return _LeftHanded;
            }

            set
            {
                _LeftHanded = (value);
            }
        }

        private bool _DisableIfTyping = default (bool);
        public bool DisableIfTyping
        {
            get
            {
                return _DisableIfTyping;
            }

            set
            {
                _DisableIfTyping = (value);
            }
        }

        private bool _TapClick = default (bool);
        public bool TapClick
        {
            get
            {
                return _TapClick;
            }

            set
            {
                _TapClick = (value);
            }
        }

        private double _MotionScaling = default (double);
        public double MotionScaling
        {
            get
            {
                return _MotionScaling;
            }

            set
            {
                _MotionScaling = (value);
            }
        }

        private string _DeviceList = default (string);
        public string DeviceList
        {
            get
            {
                return _DeviceList;
            }

            set
            {
                _DeviceList = (value);
            }
        }
    }

    static class TouchPadExtensions
    {
        public static Task<int> GetDragThresholdAsync(this ITouchPad o) => o.GetAsync<int>("DragThreshold");
        public static Task<int> GetDeltaScrollAsync(this ITouchPad o) => o.GetAsync<int>("DeltaScroll");
        public static Task<int> GetPalmMinZAsync(this ITouchPad o) => o.GetAsync<int>("PalmMinZ");
        public static Task<int> GetDoubleClickAsync(this ITouchPad o) => o.GetAsync<int>("DoubleClick");
        public static Task<bool> GetTPadEnableAsync(this ITouchPad o) => o.GetAsync<bool>("TPadEnable");
        public static Task<bool> GetEdgeScrollAsync(this ITouchPad o) => o.GetAsync<bool>("EdgeScroll");
        public static Task<bool> GetVertScrollAsync(this ITouchPad o) => o.GetAsync<bool>("VertScroll");
        public static Task<int> GetPalmMinWidthAsync(this ITouchPad o) => o.GetAsync<int>("PalmMinWidth");
        public static Task<bool> GetExistAsync(this ITouchPad o) => o.GetAsync<bool>("Exist");
        public static Task<bool> GetNaturalScrollAsync(this ITouchPad o) => o.GetAsync<bool>("NaturalScroll");
        public static Task<bool> GetHorizScrollAsync(this ITouchPad o) => o.GetAsync<bool>("HorizScroll");
        public static Task<bool> GetPalmDetectAsync(this ITouchPad o) => o.GetAsync<bool>("PalmDetect");
        public static Task<double> GetMotionAccelerationAsync(this ITouchPad o) => o.GetAsync<double>("MotionAcceleration");
        public static Task<double> GetMotionThresholdAsync(this ITouchPad o) => o.GetAsync<double>("MotionThreshold");
        public static Task<bool> GetLeftHandedAsync(this ITouchPad o) => o.GetAsync<bool>("LeftHanded");
        public static Task<bool> GetDisableIfTypingAsync(this ITouchPad o) => o.GetAsync<bool>("DisableIfTyping");
        public static Task<bool> GetTapClickAsync(this ITouchPad o) => o.GetAsync<bool>("TapClick");
        public static Task<double> GetMotionScalingAsync(this ITouchPad o) => o.GetAsync<double>("MotionScaling");
        public static Task<string> GetDeviceListAsync(this ITouchPad o) => o.GetAsync<string>("DeviceList");
        public static Task SetDragThresholdAsync(this ITouchPad o, int val) => o.SetAsync("DragThreshold", val);
        public static Task SetDeltaScrollAsync(this ITouchPad o, int val) => o.SetAsync("DeltaScroll", val);
        public static Task SetPalmMinZAsync(this ITouchPad o, int val) => o.SetAsync("PalmMinZ", val);
        public static Task SetDoubleClickAsync(this ITouchPad o, int val) => o.SetAsync("DoubleClick", val);
        public static Task SetTPadEnableAsync(this ITouchPad o, bool val) => o.SetAsync("TPadEnable", val);
        public static Task SetEdgeScrollAsync(this ITouchPad o, bool val) => o.SetAsync("EdgeScroll", val);
        public static Task SetVertScrollAsync(this ITouchPad o, bool val) => o.SetAsync("VertScroll", val);
        public static Task SetPalmMinWidthAsync(this ITouchPad o, int val) => o.SetAsync("PalmMinWidth", val);
        public static Task SetNaturalScrollAsync(this ITouchPad o, bool val) => o.SetAsync("NaturalScroll", val);
        public static Task SetHorizScrollAsync(this ITouchPad o, bool val) => o.SetAsync("HorizScroll", val);
        public static Task SetPalmDetectAsync(this ITouchPad o, bool val) => o.SetAsync("PalmDetect", val);
        public static Task SetMotionAccelerationAsync(this ITouchPad o, double val) => o.SetAsync("MotionAcceleration", val);
        public static Task SetMotionThresholdAsync(this ITouchPad o, double val) => o.SetAsync("MotionThreshold", val);
        public static Task SetLeftHandedAsync(this ITouchPad o, bool val) => o.SetAsync("LeftHanded", val);
        public static Task SetDisableIfTypingAsync(this ITouchPad o, bool val) => o.SetAsync("DisableIfTyping", val);
        public static Task SetTapClickAsync(this ITouchPad o, bool val) => o.SetAsync("TapClick", val);
        public static Task SetMotionScalingAsync(this ITouchPad o, double val) => o.SetAsync("MotionScaling", val);
    }

    [DBusInterface("com.deepin.daemon.Audio")]
    interface IAudio : IDBusObject
    {
        Task NoRestartPulseAudioAsync();
        Task ResetAsync();
        Task SetPortAsync(uint CardId, string PortName, int Direction);
        Task<T> GetAsync<T>(string prop);
        Task<AudioProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class AudioProperties
    {
        private ObjectPath _DefaultSink = default (ObjectPath);
        public ObjectPath DefaultSink
        {
            get
            {
                return _DefaultSink;
            }

            set
            {
                _DefaultSink = (value);
            }
        }

        private ObjectPath _DefaultSource = default (ObjectPath);
        public ObjectPath DefaultSource
        {
            get
            {
                return _DefaultSource;
            }

            set
            {
                _DefaultSource = (value);
            }
        }

        private string _Cards = default (string);
        public string Cards
        {
            get
            {
                return _Cards;
            }

            set
            {
                _Cards = (value);
            }
        }

        private bool _IncreaseVolume = default (bool);
        public bool IncreaseVolume
        {
            get
            {
                return _IncreaseVolume;
            }

            set
            {
                _IncreaseVolume = (value);
            }
        }

        private double _MaxUIVolume = default (double);
        public double MaxUIVolume
        {
            get
            {
                return _MaxUIVolume;
            }

            set
            {
                _MaxUIVolume = (value);
            }
        }

        private ObjectPath[] _SinkInputs = default (ObjectPath[]);
        public ObjectPath[] SinkInputs
        {
            get
            {
                return _SinkInputs;
            }

            set
            {
                _SinkInputs = (value);
            }
        }

        private ObjectPath[] _Sinks = default (ObjectPath[]);
        public ObjectPath[] Sinks
        {
            get
            {
                return _Sinks;
            }

            set
            {
                _Sinks = (value);
            }
        }

        private ObjectPath[] _Sources = default (ObjectPath[]);
        public ObjectPath[] Sources
        {
            get
            {
                return _Sources;
            }

            set
            {
                _Sources = (value);
            }
        }
    }

    static class AudioExtensions
    {
        public static Task<ObjectPath> GetDefaultSinkAsync(this IAudio o) => o.GetAsync<ObjectPath>("DefaultSink");
        public static Task<ObjectPath> GetDefaultSourceAsync(this IAudio o) => o.GetAsync<ObjectPath>("DefaultSource");
        public static Task<string> GetCardsAsync(this IAudio o) => o.GetAsync<string>("Cards");
        public static Task<bool> GetIncreaseVolumeAsync(this IAudio o) => o.GetAsync<bool>("IncreaseVolume");
        public static Task<double> GetMaxUIVolumeAsync(this IAudio o) => o.GetAsync<double>("MaxUIVolume");
        public static Task<ObjectPath[]> GetSinkInputsAsync(this IAudio o) => o.GetAsync<ObjectPath[]>("SinkInputs");
        public static Task<ObjectPath[]> GetSinksAsync(this IAudio o) => o.GetAsync<ObjectPath[]>("Sinks");
        public static Task<ObjectPath[]> GetSourcesAsync(this IAudio o) => o.GetAsync<ObjectPath[]>("Sources");
        public static Task SetIncreaseVolumeAsync(this IAudio o, bool val) => o.SetAsync("IncreaseVolume", val);
    }

    [DBusInterface("com.deepin.daemon.Audio.Sink")]
    interface ISink : IDBusObject
    {
        Task<ObjectPath> GetMeterAsync();
        Task SetBalanceAsync(double Value, bool IsPlay);
        Task SetFadeAsync(double Value);
        Task SetMuteAsync(bool Value);
        Task SetPortAsync(string Name);
        Task SetVolumeAsync(double Value, bool IsPlay);
        Task<T> GetAsync<T>(string prop);
        Task<SinkProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SinkProperties
    {
        private bool _SupportFade = default (bool);
        public bool SupportFade
        {
            get
            {
                return _SupportFade;
            }

            set
            {
                _SupportFade = (value);
            }
        }

        private (string, string, byte)_ActivePort = default ((string, string, byte));
        public (string, string, byte)ActivePort
        {
            get
            {
                return _ActivePort;
            }

            set
            {
                _ActivePort = (value);
            }
        }

        private bool _SupportBalance = default (bool);
        public bool SupportBalance
        {
            get
            {
                return _SupportBalance;
            }

            set
            {
                _SupportBalance = (value);
            }
        }

        private double _Fade = default (double);
        public double Fade
        {
            get
            {
                return _Fade;
            }

            set
            {
                _Fade = (value);
            }
        }

        private string _Name = default (string);
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = (value);
            }
        }

        private string _Description = default (string);
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = (value);
            }
        }

        private double _BaseVolume = default (double);
        public double BaseVolume
        {
            get
            {
                return _BaseVolume;
            }

            set
            {
                _BaseVolume = (value);
            }
        }

        private bool _Mute = default (bool);
        public bool Mute
        {
            get
            {
                return _Mute;
            }

            set
            {
                _Mute = (value);
            }
        }

        private double _Volume = default (double);
        public double Volume
        {
            get
            {
                return _Volume;
            }

            set
            {
                _Volume = (value);
            }
        }

        private double _Balance = default (double);
        public double Balance
        {
            get
            {
                return _Balance;
            }

            set
            {
                _Balance = (value);
            }
        }

        private (string, string, byte)[] _Ports = default ((string, string, byte)[]);
        public (string, string, byte)[] Ports
        {
            get
            {
                return _Ports;
            }

            set
            {
                _Ports = (value);
            }
        }

        private uint _Card = default (uint);
        public uint Card
        {
            get
            {
                return _Card;
            }

            set
            {
                _Card = (value);
            }
        }
    }

    static class SinkExtensions
    {
        public static Task<bool> GetSupportFadeAsync(this ISink o) => o.GetAsync<bool>("SupportFade");
        public static Task<(string, string, byte)> GetActivePortAsync(this ISink o) => o.GetAsync<(string, string, byte)>("ActivePort");
        public static Task<bool> GetSupportBalanceAsync(this ISink o) => o.GetAsync<bool>("SupportBalance");
        public static Task<double> GetFadeAsync(this ISink o) => o.GetAsync<double>("Fade");
        public static Task<string> GetNameAsync(this ISink o) => o.GetAsync<string>("Name");
        public static Task<string> GetDescriptionAsync(this ISink o) => o.GetAsync<string>("Description");
        public static Task<double> GetBaseVolumeAsync(this ISink o) => o.GetAsync<double>("BaseVolume");
        public static Task<bool> GetMuteAsync(this ISink o) => o.GetAsync<bool>("Mute");
        public static Task<double> GetVolumeAsync(this ISink o) => o.GetAsync<double>("Volume");
        public static Task<double> GetBalanceAsync(this ISink o) => o.GetAsync<double>("Balance");
        public static Task<(string, string, byte)[]> GetPortsAsync(this ISink o) => o.GetAsync<(string, string, byte)[]>("Ports");
        public static Task<uint> GetCardAsync(this ISink o) => o.GetAsync<uint>("Card");
    }

    [DBusInterface("com.deepin.daemon.Audio.Source")]
    interface ISource : IDBusObject
    {
        Task<ObjectPath> GetMeterAsync();
        Task SetBalanceAsync(double Value, bool IsPlay);
        Task SetFadeAsync(double Value);
        Task SetMuteAsync(bool Value);
        Task SetPortAsync(string Name);
        Task SetVolumeAsync(double Value, bool IsPlay);
        Task<T> GetAsync<T>(string prop);
        Task<SourceProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SourceProperties
    {
        private string _Name = default (string);
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = (value);
            }
        }

        private string _Description = default (string);
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = (value);
            }
        }

        private bool _Mute = default (bool);
        public bool Mute
        {
            get
            {
                return _Mute;
            }

            set
            {
                _Mute = (value);
            }
        }

        private double _Volume = default (double);
        public double Volume
        {
            get
            {
                return _Volume;
            }

            set
            {
                _Volume = (value);
            }
        }

        private double _Balance = default (double);
        public double Balance
        {
            get
            {
                return _Balance;
            }

            set
            {
                _Balance = (value);
            }
        }

        private bool _SupportBalance = default (bool);
        public bool SupportBalance
        {
            get
            {
                return _SupportBalance;
            }

            set
            {
                _SupportBalance = (value);
            }
        }

        private (string, string, byte)[] _Ports = default ((string, string, byte)[]);
        public (string, string, byte)[] Ports
        {
            get
            {
                return _Ports;
            }

            set
            {
                _Ports = (value);
            }
        }

        private uint _Card = default (uint);
        public uint Card
        {
            get
            {
                return _Card;
            }

            set
            {
                _Card = (value);
            }
        }

        private double _BaseVolume = default (double);
        public double BaseVolume
        {
            get
            {
                return _BaseVolume;
            }

            set
            {
                _BaseVolume = (value);
            }
        }

        private double _Fade = default (double);
        public double Fade
        {
            get
            {
                return _Fade;
            }

            set
            {
                _Fade = (value);
            }
        }

        private bool _SupportFade = default (bool);
        public bool SupportFade
        {
            get
            {
                return _SupportFade;
            }

            set
            {
                _SupportFade = (value);
            }
        }

        private (string, string, byte)_ActivePort = default ((string, string, byte));
        public (string, string, byte)ActivePort
        {
            get
            {
                return _ActivePort;
            }

            set
            {
                _ActivePort = (value);
            }
        }
    }

    static class SourceExtensions
    {
        public static Task<string> GetNameAsync(this ISource o) => o.GetAsync<string>("Name");
        public static Task<string> GetDescriptionAsync(this ISource o) => o.GetAsync<string>("Description");
        public static Task<bool> GetMuteAsync(this ISource o) => o.GetAsync<bool>("Mute");
        public static Task<double> GetVolumeAsync(this ISource o) => o.GetAsync<double>("Volume");
        public static Task<double> GetBalanceAsync(this ISource o) => o.GetAsync<double>("Balance");
        public static Task<bool> GetSupportBalanceAsync(this ISource o) => o.GetAsync<bool>("SupportBalance");
        public static Task<(string, string, byte)[]> GetPortsAsync(this ISource o) => o.GetAsync<(string, string, byte)[]>("Ports");
        public static Task<uint> GetCardAsync(this ISource o) => o.GetAsync<uint>("Card");
        public static Task<double> GetBaseVolumeAsync(this ISource o) => o.GetAsync<double>("BaseVolume");
        public static Task<double> GetFadeAsync(this ISource o) => o.GetAsync<double>("Fade");
        public static Task<bool> GetSupportFadeAsync(this ISource o) => o.GetAsync<bool>("SupportFade");
        public static Task<(string, string, byte)> GetActivePortAsync(this ISource o) => o.GetAsync<(string, string, byte)>("ActivePort");
    }

    [DBusInterface("com.deepin.daemon.Miracast")]
    interface IMiracast : IDBusObject
    {
        Task ConnectAsync(ObjectPath Sink, uint X, uint Y, uint W, uint H);
        Task DisconnectAsync(ObjectPath Sink);
        Task EnableAsync(ObjectPath Link, bool Enabled);
        Task<(string, string, string, bool, bool, ObjectPath)[]> ListLinksAsync();
        Task<(string, string, string, bool, ObjectPath, ObjectPath)[]> ListSinksAsync();
        Task ScanningAsync(ObjectPath Link, bool Enabled);
        Task SetLinkNameAsync(ObjectPath Link, string Name);
        Task<IDisposable> WatchAddedAsync(Action<(ObjectPath path, string detailJSON)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRemovedAsync(Action<(ObjectPath path, string detailJSON)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchEventAsync(Action<(byte eventType, ObjectPath path)> handler, Action<Exception> onError = null);
    }

    [DBusInterface("com.deepin.daemon.Calendar.Scheduler")]
    interface IScheduler : IDBusObject
    {
        Task<long> CreateJobAsync(string JobInfo);
        Task<long> CreateTypeAsync(string TypeInfo);
        Task DebugRemindJobAsync(long Id);
        Task DeleteJobAsync(long Id);
        Task DeleteTypeAsync(long Id);
        Task<string> GetJobAsync(long Id);
        Task<string> GetJobsAsync(int StartYear, int StartMonth, int StartDay, int EndYear, int EndMonth, int EndDay);
        Task<string> GetTypeAsync(long Id);
        Task<string> GetTypesAsync();
        Task<string> QueryJobsAsync(string Params);
        Task UpdateJobAsync(string JobInfo);
        Task UpdateTypeAsync(string TypeInfo);
        Task<IDisposable> WatchJobsUpdatedAsync(Action<long[]> handler, Action<Exception> onError = null);
    }

    [DBusInterface("com.deepin.daemon.Power")]
    interface IPower : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<PowerProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class PowerProperties
    {
        private IDictionary<string, double> _BatteryPercentage = default (IDictionary<string, double>);
        public IDictionary<string, double> BatteryPercentage
        {
            get
            {
                return _BatteryPercentage;
            }

            set
            {
                _BatteryPercentage = (value);
            }
        }

        private bool _ScreenBlackLock = default (bool);
        public bool ScreenBlackLock
        {
            get
            {
                return _ScreenBlackLock;
            }

            set
            {
                _ScreenBlackLock = (value);
            }
        }

        private bool _LidClosedSleep = default (bool);
        public bool LidClosedSleep
        {
            get
            {
                return _LidClosedSleep;
            }

            set
            {
                _LidClosedSleep = (value);
            }
        }

        private bool _LidIsPresent = default (bool);
        public bool LidIsPresent
        {
            get
            {
                return _LidIsPresent;
            }

            set
            {
                _LidIsPresent = (value);
            }
        }

        private bool _HasAmbientLightSensor = default (bool);
        public bool HasAmbientLightSensor
        {
            get
            {
                return _HasAmbientLightSensor;
            }

            set
            {
                _HasAmbientLightSensor = (value);
            }
        }

        private IDictionary<string, bool> _BatteryIsPresent = default (IDictionary<string, bool>);
        public IDictionary<string, bool> BatteryIsPresent
        {
            get
            {
                return _BatteryIsPresent;
            }

            set
            {
                _BatteryIsPresent = (value);
            }
        }

        private int _LinePowerScreenBlackDelay = default (int);
        public int LinePowerScreenBlackDelay
        {
            get
            {
                return _LinePowerScreenBlackDelay;
            }

            set
            {
                _LinePowerScreenBlackDelay = (value);
            }
        }

        private int _LinePowerSleepDelay = default (int);
        public int LinePowerSleepDelay
        {
            get
            {
                return _LinePowerSleepDelay;
            }

            set
            {
                _LinePowerSleepDelay = (value);
            }
        }

        private int _BatteryScreenBlackDelay = default (int);
        public int BatteryScreenBlackDelay
        {
            get
            {
                return _BatteryScreenBlackDelay;
            }

            set
            {
                _BatteryScreenBlackDelay = (value);
            }
        }

        private bool _SleepLock = default (bool);
        public bool SleepLock
        {
            get
            {
                return _SleepLock;
            }

            set
            {
                _SleepLock = (value);
            }
        }

        private bool _AmbientLightAdjustBrightness = default (bool);
        public bool AmbientLightAdjustBrightness
        {
            get
            {
                return _AmbientLightAdjustBrightness;
            }

            set
            {
                _AmbientLightAdjustBrightness = (value);
            }
        }

        private bool _UseWayland = default (bool);
        public bool UseWayland
        {
            get
            {
                return _UseWayland;
            }

            set
            {
                _UseWayland = (value);
            }
        }

        private int _LinePowerScreensaverDelay = default (int);
        public int LinePowerScreensaverDelay
        {
            get
            {
                return _LinePowerScreensaverDelay;
            }

            set
            {
                _LinePowerScreensaverDelay = (value);
            }
        }

        private int _BatterySleepDelay = default (int);
        public int BatterySleepDelay
        {
            get
            {
                return _BatterySleepDelay;
            }

            set
            {
                _BatterySleepDelay = (value);
            }
        }

        private bool _LinePowerLidClosedSleep = default (bool);
        public bool LinePowerLidClosedSleep
        {
            get
            {
                return _LinePowerLidClosedSleep;
            }

            set
            {
                _LinePowerLidClosedSleep = (value);
            }
        }

        private bool _OnBattery = default (bool);
        public bool OnBattery
        {
            get
            {
                return _OnBattery;
            }

            set
            {
                _OnBattery = (value);
            }
        }

        private uint _WarnLevel = default (uint);
        public uint WarnLevel
        {
            get
            {
                return _WarnLevel;
            }

            set
            {
                _WarnLevel = (value);
            }
        }

        private IDictionary<string, uint> _BatteryState = default (IDictionary<string, uint>);
        public IDictionary<string, uint> BatteryState
        {
            get
            {
                return _BatteryState;
            }

            set
            {
                _BatteryState = (value);
            }
        }

        private int _BatteryScreensaverDelay = default (int);
        public int BatteryScreensaverDelay
        {
            get
            {
                return _BatteryScreensaverDelay;
            }

            set
            {
                _BatteryScreensaverDelay = (value);
            }
        }

        private bool _BatteryLidClosedSleep = default (bool);
        public bool BatteryLidClosedSleep
        {
            get
            {
                return _BatteryLidClosedSleep;
            }

            set
            {
                _BatteryLidClosedSleep = (value);
            }
        }

        private int _LinePowerLockDelay = default (int);
        public int LinePowerLockDelay
        {
            get
            {
                return _LinePowerLockDelay;
            }

            set
            {
                _LinePowerLockDelay = (value);
            }
        }

        private int _BatteryLockDelay = default (int);
        public int BatteryLockDelay
        {
            get
            {
                return _BatteryLockDelay;
            }

            set
            {
                _BatteryLockDelay = (value);
            }
        }
    }

    static class PowerExtensions
    {
        public static Task<IDictionary<string, double>> GetBatteryPercentageAsync(this IPower o) => o.GetAsync<IDictionary<string, double>>("BatteryPercentage");
        public static Task<bool> GetScreenBlackLockAsync(this IPower o) => o.GetAsync<bool>("ScreenBlackLock");
        public static Task<bool> GetLidClosedSleepAsync(this IPower o) => o.GetAsync<bool>("LidClosedSleep");
        public static Task<bool> GetLidIsPresentAsync(this IPower o) => o.GetAsync<bool>("LidIsPresent");
        public static Task<bool> GetHasAmbientLightSensorAsync(this IPower o) => o.GetAsync<bool>("HasAmbientLightSensor");
        public static Task<IDictionary<string, bool>> GetBatteryIsPresentAsync(this IPower o) => o.GetAsync<IDictionary<string, bool>>("BatteryIsPresent");
        public static Task<int> GetLinePowerScreenBlackDelayAsync(this IPower o) => o.GetAsync<int>("LinePowerScreenBlackDelay");
        public static Task<int> GetLinePowerSleepDelayAsync(this IPower o) => o.GetAsync<int>("LinePowerSleepDelay");
        public static Task<int> GetBatteryScreenBlackDelayAsync(this IPower o) => o.GetAsync<int>("BatteryScreenBlackDelay");
        public static Task<bool> GetSleepLockAsync(this IPower o) => o.GetAsync<bool>("SleepLock");
        public static Task<bool> GetAmbientLightAdjustBrightnessAsync(this IPower o) => o.GetAsync<bool>("AmbientLightAdjustBrightness");
        public static Task<bool> GetUseWaylandAsync(this IPower o) => o.GetAsync<bool>("UseWayland");
        public static Task<int> GetLinePowerScreensaverDelayAsync(this IPower o) => o.GetAsync<int>("LinePowerScreensaverDelay");
        public static Task<int> GetBatterySleepDelayAsync(this IPower o) => o.GetAsync<int>("BatterySleepDelay");
        public static Task<bool> GetLinePowerLidClosedSleepAsync(this IPower o) => o.GetAsync<bool>("LinePowerLidClosedSleep");
        public static Task<bool> GetOnBatteryAsync(this IPower o) => o.GetAsync<bool>("OnBattery");
        public static Task<uint> GetWarnLevelAsync(this IPower o) => o.GetAsync<uint>("WarnLevel");
        public static Task<IDictionary<string, uint>> GetBatteryStateAsync(this IPower o) => o.GetAsync<IDictionary<string, uint>>("BatteryState");
        public static Task<int> GetBatteryScreensaverDelayAsync(this IPower o) => o.GetAsync<int>("BatteryScreensaverDelay");
        public static Task<bool> GetBatteryLidClosedSleepAsync(this IPower o) => o.GetAsync<bool>("BatteryLidClosedSleep");
        public static Task<int> GetLinePowerLockDelayAsync(this IPower o) => o.GetAsync<int>("LinePowerLockDelay");
        public static Task<int> GetBatteryLockDelayAsync(this IPower o) => o.GetAsync<int>("BatteryLockDelay");
        public static Task SetScreenBlackLockAsync(this IPower o, bool val) => o.SetAsync("ScreenBlackLock", val);
        public static Task SetLidClosedSleepAsync(this IPower o, bool val) => o.SetAsync("LidClosedSleep", val);
        public static Task SetLinePowerScreenBlackDelayAsync(this IPower o, int val) => o.SetAsync("LinePowerScreenBlackDelay", val);
        public static Task SetLinePowerSleepDelayAsync(this IPower o, int val) => o.SetAsync("LinePowerSleepDelay", val);
        public static Task SetBatteryScreenBlackDelayAsync(this IPower o, int val) => o.SetAsync("BatteryScreenBlackDelay", val);
        public static Task SetSleepLockAsync(this IPower o, bool val) => o.SetAsync("SleepLock", val);
        public static Task SetAmbientLightAdjustBrightnessAsync(this IPower o, bool val) => o.SetAsync("AmbientLightAdjustBrightness", val);
        public static Task SetLinePowerScreensaverDelayAsync(this IPower o, int val) => o.SetAsync("LinePowerScreensaverDelay", val);
        public static Task SetBatterySleepDelayAsync(this IPower o, int val) => o.SetAsync("BatterySleepDelay", val);
        public static Task SetLinePowerLidClosedSleepAsync(this IPower o, bool val) => o.SetAsync("LinePowerLidClosedSleep", val);
        public static Task SetBatteryScreensaverDelayAsync(this IPower o, int val) => o.SetAsync("BatteryScreensaverDelay", val);
        public static Task SetBatteryLidClosedSleepAsync(this IPower o, bool val) => o.SetAsync("BatteryLidClosedSleep", val);
        public static Task SetLinePowerLockDelayAsync(this IPower o, int val) => o.SetAsync("LinePowerLockDelay", val);
        public static Task SetBatteryLockDelayAsync(this IPower o, int val) => o.SetAsync("BatteryLockDelay", val);
    }

    [DBusInterface("com.deepin.daemon.Power.WarnLevelConfig")]
    interface IWarnLevelConfig : IDBusObject
    {
        Task ResetAsync();
        Task<T> GetAsync<T>(string prop);
        Task<WarnLevelConfigProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class WarnLevelConfigProperties
    {
        private int _DangerTime = default (int);
        public int DangerTime
        {
            get
            {
                return _DangerTime;
            }

            set
            {
                _DangerTime = (value);
            }
        }

        private int _CriticalPercentage = default (int);
        public int CriticalPercentage
        {
            get
            {
                return _CriticalPercentage;
            }

            set
            {
                _CriticalPercentage = (value);
            }
        }

        private bool _UsePercentageForPolicy = default (bool);
        public bool UsePercentageForPolicy
        {
            get
            {
                return _UsePercentageForPolicy;
            }

            set
            {
                _UsePercentageForPolicy = (value);
            }
        }

        private int _LowTime = default (int);
        public int LowTime
        {
            get
            {
                return _LowTime;
            }

            set
            {
                _LowTime = (value);
            }
        }

        private int _CriticalTime = default (int);
        public int CriticalTime
        {
            get
            {
                return _CriticalTime;
            }

            set
            {
                _CriticalTime = (value);
            }
        }

        private int _ActionTime = default (int);
        public int ActionTime
        {
            get
            {
                return _ActionTime;
            }

            set
            {
                _ActionTime = (value);
            }
        }

        private int _LowPercentage = default (int);
        public int LowPercentage
        {
            get
            {
                return _LowPercentage;
            }

            set
            {
                _LowPercentage = (value);
            }
        }

        private int _DangerPercentage = default (int);
        public int DangerPercentage
        {
            get
            {
                return _DangerPercentage;
            }

            set
            {
                _DangerPercentage = (value);
            }
        }

        private int _ActionPercentage = default (int);
        public int ActionPercentage
        {
            get
            {
                return _ActionPercentage;
            }

            set
            {
                _ActionPercentage = (value);
            }
        }
    }

    static class WarnLevelConfigExtensions
    {
        public static Task<int> GetDangerTimeAsync(this IWarnLevelConfig o) => o.GetAsync<int>("DangerTime");
        public static Task<int> GetCriticalPercentageAsync(this IWarnLevelConfig o) => o.GetAsync<int>("CriticalPercentage");
        public static Task<bool> GetUsePercentageForPolicyAsync(this IWarnLevelConfig o) => o.GetAsync<bool>("UsePercentageForPolicy");
        public static Task<int> GetLowTimeAsync(this IWarnLevelConfig o) => o.GetAsync<int>("LowTime");
        public static Task<int> GetCriticalTimeAsync(this IWarnLevelConfig o) => o.GetAsync<int>("CriticalTime");
        public static Task<int> GetActionTimeAsync(this IWarnLevelConfig o) => o.GetAsync<int>("ActionTime");
        public static Task<int> GetLowPercentageAsync(this IWarnLevelConfig o) => o.GetAsync<int>("LowPercentage");
        public static Task<int> GetDangerPercentageAsync(this IWarnLevelConfig o) => o.GetAsync<int>("DangerPercentage");
        public static Task<int> GetActionPercentageAsync(this IWarnLevelConfig o) => o.GetAsync<int>("ActionPercentage");
        public static Task SetDangerTimeAsync(this IWarnLevelConfig o, int val) => o.SetAsync("DangerTime", val);
        public static Task SetCriticalPercentageAsync(this IWarnLevelConfig o, int val) => o.SetAsync("CriticalPercentage", val);
        public static Task SetUsePercentageForPolicyAsync(this IWarnLevelConfig o, bool val) => o.SetAsync("UsePercentageForPolicy", val);
        public static Task SetLowTimeAsync(this IWarnLevelConfig o, int val) => o.SetAsync("LowTime", val);
        public static Task SetCriticalTimeAsync(this IWarnLevelConfig o, int val) => o.SetAsync("CriticalTime", val);
        public static Task SetActionTimeAsync(this IWarnLevelConfig o, int val) => o.SetAsync("ActionTime", val);
        public static Task SetLowPercentageAsync(this IWarnLevelConfig o, int val) => o.SetAsync("LowPercentage", val);
        public static Task SetDangerPercentageAsync(this IWarnLevelConfig o, int val) => o.SetAsync("DangerPercentage", val);
        public static Task SetActionPercentageAsync(this IWarnLevelConfig o, int val) => o.SetAsync("ActionPercentage", val);
    }

    [DBusInterface("com.deepin.daemon.Timedate")]
    interface ITimedate : IDBusObject
    {
        Task AddUserTimezoneAsync(string Zone);
        Task DeleteUserTimezoneAsync(string Zone);
        Task<string[]> GetSampleNTPServersAsync();
        Task<(string zoneInfo, string, int, (long, long, int))> GetZoneInfoAsync(string Zone);
        Task<string[]> GetZoneListAsync();
        Task ResetAsync();
        Task SetDateAsync(int Year, int Month, int Day, int Hour, int Min, int Sec, int Nsec);
        Task SetLocalRTCAsync(bool LocaleRTC, bool FixSystem);
        Task SetNTPAsync(bool UseNTP);
        Task SetNTPServerAsync(string Server);
        Task SetTimeAsync(long Usec, bool Relative);
        Task SetTimezoneAsync(string Zone);
        Task<T> GetAsync<T>(string prop);
        Task<TimedateProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class TimedateProperties
    {
        private bool _NTP = default (bool);
        public bool NTP
        {
            get
            {
                return _NTP;
            }

            set
            {
                _NTP = (value);
            }
        }

        private bool _LocalRTC = default (bool);
        public bool LocalRTC
        {
            get
            {
                return _LocalRTC;
            }

            set
            {
                _LocalRTC = (value);
            }
        }

        private string _Timezone = default (string);
        public string Timezone
        {
            get
            {
                return _Timezone;
            }

            set
            {
                _Timezone = (value);
            }
        }

        private string _NTPServer = default (string);
        public string NTPServer
        {
            get
            {
                return _NTPServer;
            }

            set
            {
                _NTPServer = (value);
            }
        }

        private bool _Use24HourFormat = default (bool);
        public bool Use24HourFormat
        {
            get
            {
                return _Use24HourFormat;
            }

            set
            {
                _Use24HourFormat = (value);
            }
        }

        private int _DSTOffset = default (int);
        public int DSTOffset
        {
            get
            {
                return _DSTOffset;
            }

            set
            {
                _DSTOffset = (value);
            }
        }

        private string[] _UserTimezones = default (string[]);
        public string[] UserTimezones
        {
            get
            {
                return _UserTimezones;
            }

            set
            {
                _UserTimezones = (value);
            }
        }

        private bool _CanNTP = default (bool);
        public bool CanNTP
        {
            get
            {
                return _CanNTP;
            }

            set
            {
                _CanNTP = (value);
            }
        }
    }

    static class TimedateExtensions
    {
        public static Task<bool> GetNTPAsync(this ITimedate o) => o.GetAsync<bool>("NTP");
        public static Task<bool> GetLocalRTCAsync(this ITimedate o) => o.GetAsync<bool>("LocalRTC");
        public static Task<string> GetTimezoneAsync(this ITimedate o) => o.GetAsync<string>("Timezone");
        public static Task<string> GetNTPServerAsync(this ITimedate o) => o.GetAsync<string>("NTPServer");
        public static Task<bool> GetUse24HourFormatAsync(this ITimedate o) => o.GetAsync<bool>("Use24HourFormat");
        public static Task<int> GetDSTOffsetAsync(this ITimedate o) => o.GetAsync<int>("DSTOffset");
        public static Task<string[]> GetUserTimezonesAsync(this ITimedate o) => o.GetAsync<string[]>("UserTimezones");
        public static Task<bool> GetCanNTPAsync(this ITimedate o) => o.GetAsync<bool>("CanNTP");
        public static Task SetUse24HourFormatAsync(this ITimedate o, bool val) => o.SetAsync("Use24HourFormat", val);
        public static Task SetDSTOffsetAsync(this ITimedate o, int val) => o.SetAsync("DSTOffset", val);
    }

    [DBusInterface("com.deepin.daemon.Zone")]
    interface IZone : IDBusObject
    {
        Task<string> BottomLeftActionAsync();
        Task<string> BottomRightActionAsync();
        Task EnableZoneDetectedAsync(bool Enabled);
        Task SetBottomLeftAsync(string Value);
        Task SetBottomRightAsync(string Value);
        Task SetTopLeftAsync(string Value);
        Task SetTopRightAsync(string Value);
        Task<string> TopLeftActionAsync();
        Task<string> TopRightActionAsync();
    }

    [DBusInterface("com.deepin.daemon.SessionWatcher")]
    interface ISessionWatcher : IDBusObject
    {
        Task<ObjectPath[]> GetSessionsAsync();
        Task<bool> IsX11SessionActiveAsync();
        Task<T> GetAsync<T>(string prop);
        Task<SessionWatcherProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SessionWatcherProperties
    {
        private bool _IsActive = default (bool);
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                _IsActive = (value);
            }
        }
    }

    static class SessionWatcherExtensions
    {
        public static Task<bool> GetIsActiveAsync(this ISessionWatcher o) => o.GetAsync<bool>("IsActive");
    }

    [DBusInterface("com.deepin.daemon.Mime")]
    interface IMime : IDBusObject
    {
        Task AddUserAppAsync(string[] MimeTypes, string DesktopId);
        Task DeleteAppAsync(string[] MimeTypes, string DesktopId);
        Task DeleteUserAppAsync(string DesktopId);
        Task<string> GetDefaultAppAsync(string MimeType);
        Task<string> ListAppsAsync(string MimeType);
        Task<string> ListUserAppsAsync(string MimeType);
        Task SetDefaultAppAsync(string[] MimeTypes, string DesktopId);
        Task<IDisposable> WatchChangeAsync(Action handler, Action<Exception> onError = null);
    }

    [DBusInterface("com.deepin.dde.daemon.Dock")]
    interface IDock : IDBusObject
    {
        Task ActivateWindowAsync(uint Win);
        Task CancelPreviewWindowAsync();
        Task CloseWindowAsync(uint Win);
        Task DebugRegisterWWAsync(uint WinId);
        Task DebugSetActiveWindowAsync(uint WinId);
        Task<string[]> GetDockedAppsDesktopFilesAsync();
        Task<string[]> GetEntryIDsAsync();
        Task<string> GetPluginSettingsAsync();
        Task<bool> IsDockedAsync(string DesktopFile);
        Task<bool> IsOnDockAsync(string DesktopFile);
        Task MakeWindowAboveAsync(uint Win);
        Task MaximizeWindowAsync(uint Win);
        Task MergePluginSettingsAsync(string JsonStr);
        Task MinimizeWindowAsync(uint Win);
        Task MoveEntryAsync(int Index, int NewIndex);
        Task MoveWindowAsync(uint Win);
        Task PreviewWindowAsync(uint Win);
        Task<string> QueryWindowIdentifyMethodAsync(uint Win);
        Task RemovePluginSettingsAsync(string Key1, string[] Key2List);
        Task<bool> RequestDockAsync(string DesktopFile, int Index);
        Task<bool> RequestUndockAsync(string DesktopFile);
        Task SetFrontendWindowRectAsync(int X, int Y, uint Width, uint Height);
        Task SetPluginSettingsAsync(string JsonStr);
        Task<IDisposable> WatchServiceRestartedAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchEntryAddedAsync(Action<(ObjectPath path, int index)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchEntryRemovedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchPluginSettingsSyncedAsync(Action handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<DockProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class DockProperties
    {
        private uint _ShowTimeout = default (uint);
        public uint ShowTimeout
        {
            get
            {
                return _ShowTimeout;
            }

            set
            {
                _ShowTimeout = (value);
            }
        }

        private uint _WindowSizeEfficient = default (uint);
        public uint WindowSizeEfficient
        {
            get
            {
                return _WindowSizeEfficient;
            }

            set
            {
                _WindowSizeEfficient = (value);
            }
        }

        private double _Opacity = default (double);
        public double Opacity
        {
            get
            {
                return _Opacity;
            }

            set
            {
                _Opacity = (value);
            }
        }

        private int _HideState = default (int);
        public int HideState
        {
            get
            {
                return _HideState;
            }

            set
            {
                _HideState = (value);
            }
        }

        private int _Position = default (int);
        public int Position
        {
            get
            {
                return _Position;
            }

            set
            {
                _Position = (value);
            }
        }

        private uint _IconSize = default (uint);
        public uint IconSize
        {
            get
            {
                return _IconSize;
            }

            set
            {
                _IconSize = (value);
            }
        }

        private int _DisplayMode = default (int);
        public int DisplayMode
        {
            get
            {
                return _DisplayMode;
            }

            set
            {
                _DisplayMode = (value);
            }
        }

        private uint _HideTimeout = default (uint);
        public uint HideTimeout
        {
            get
            {
                return _HideTimeout;
            }

            set
            {
                _HideTimeout = (value);
            }
        }

        private uint _WindowSizeFashion = default (uint);
        public uint WindowSizeFashion
        {
            get
            {
                return _WindowSizeFashion;
            }

            set
            {
                _WindowSizeFashion = (value);
            }
        }

        private string[] _DockedApps = default (string[]);
        public string[] DockedApps
        {
            get
            {
                return _DockedApps;
            }

            set
            {
                _DockedApps = (value);
            }
        }

        private (int, int, uint, uint)_FrontendWindowRect = default ((int, int, uint, uint));
        public (int, int, uint, uint)FrontendWindowRect
        {
            get
            {
                return _FrontendWindowRect;
            }

            set
            {
                _FrontendWindowRect = (value);
            }
        }

        private ObjectPath[] _Entries = default (ObjectPath[]);
        public ObjectPath[] Entries
        {
            get
            {
                return _Entries;
            }

            set
            {
                _Entries = (value);
            }
        }

        private int _HideMode = default (int);
        public int HideMode
        {
            get
            {
                return _HideMode;
            }

            set
            {
                _HideMode = (value);
            }
        }
    }

    static class DockExtensions
    {
        public static Task<uint> GetShowTimeoutAsync(this IDock o) => o.GetAsync<uint>("ShowTimeout");
        public static Task<uint> GetWindowSizeEfficientAsync(this IDock o) => o.GetAsync<uint>("WindowSizeEfficient");
        public static Task<double> GetOpacityAsync(this IDock o) => o.GetAsync<double>("Opacity");
        public static Task<int> GetHideStateAsync(this IDock o) => o.GetAsync<int>("HideState");
        public static Task<int> GetPositionAsync(this IDock o) => o.GetAsync<int>("Position");
        public static Task<uint> GetIconSizeAsync(this IDock o) => o.GetAsync<uint>("IconSize");
        public static Task<int> GetDisplayModeAsync(this IDock o) => o.GetAsync<int>("DisplayMode");
        public static Task<uint> GetHideTimeoutAsync(this IDock o) => o.GetAsync<uint>("HideTimeout");
        public static Task<uint> GetWindowSizeFashionAsync(this IDock o) => o.GetAsync<uint>("WindowSizeFashion");
        public static Task<string[]> GetDockedAppsAsync(this IDock o) => o.GetAsync<string[]>("DockedApps");
        public static Task<(int, int, uint, uint)> GetFrontendWindowRectAsync(this IDock o) => o.GetAsync<(int, int, uint, uint)>("FrontendWindowRect");
        public static Task<ObjectPath[]> GetEntriesAsync(this IDock o) => o.GetAsync<ObjectPath[]>("Entries");
        public static Task<int> GetHideModeAsync(this IDock o) => o.GetAsync<int>("HideMode");
        public static Task SetShowTimeoutAsync(this IDock o, uint val) => o.SetAsync("ShowTimeout", val);
        public static Task SetWindowSizeEfficientAsync(this IDock o, uint val) => o.SetAsync("WindowSizeEfficient", val);
        public static Task SetPositionAsync(this IDock o, int val) => o.SetAsync("Position", val);
        public static Task SetIconSizeAsync(this IDock o, uint val) => o.SetAsync("IconSize", val);
        public static Task SetDisplayModeAsync(this IDock o, int val) => o.SetAsync("DisplayMode", val);
        public static Task SetHideTimeoutAsync(this IDock o, uint val) => o.SetAsync("HideTimeout", val);
        public static Task SetWindowSizeFashionAsync(this IDock o, uint val) => o.SetAsync("WindowSizeFashion", val);
        public static Task SetHideModeAsync(this IDock o, int val) => o.SetAsync("HideMode", val);
    }

    [DBusInterface("com.deepin.dde.daemon.Dock.Entry")]
    interface IEntry : IDBusObject
    {
        Task ActivateAsync(uint Timestamp);
        Task CheckAsync();
        Task ForceQuitAsync();
        Task<uint[]> GetAllowedCloseWindowsAsync();
        Task HandleDragDropAsync(uint Timestamp, string[] Files);
        Task HandleMenuItemAsync(uint Timestamp, string Id);
        Task NewInstanceAsync(uint Timestamp);
        Task PresentWindowsAsync();
        Task RequestDockAsync();
        Task RequestUndockAsync();
        Task<T> GetAsync<T>(string prop);
        Task<EntryProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class EntryProperties
    {
        private string _Name = default (string);
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = (value);
            }
        }

        private string _Icon = default (string);
        public string Icon
        {
            get
            {
                return _Icon;
            }

            set
            {
                _Icon = (value);
            }
        }

        private string _DesktopFile = default (string);
        public string DesktopFile
        {
            get
            {
                return _DesktopFile;
            }

            set
            {
                _DesktopFile = (value);
            }
        }

        private uint _CurrentWindow = default (uint);
        public uint CurrentWindow
        {
            get
            {
                return _CurrentWindow;
            }

            set
            {
                _CurrentWindow = (value);
            }
        }

        private bool _IsDocked = default (bool);
        public bool IsDocked
        {
            get
            {
                return _IsDocked;
            }

            set
            {
                _IsDocked = (value);
            }
        }

        private string _Id = default (string);
        public string Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = (value);
            }
        }

        private bool _IsActive = default (bool);
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                _IsActive = (value);
            }
        }

        private string _Menu = default (string);
        public string Menu
        {
            get
            {
                return _Menu;
            }

            set
            {
                _Menu = (value);
            }
        }

        private IDictionary<uint, (string, bool)> _WindowInfos = default (IDictionary<uint, (string, bool)>);
        public IDictionary<uint, (string, bool)> WindowInfos
        {
            get
            {
                return _WindowInfos;
            }

            set
            {
                _WindowInfos = (value);
            }
        }
    }

    static class EntryExtensions
    {
        public static Task<string> GetNameAsync(this IEntry o) => o.GetAsync<string>("Name");
        public static Task<string> GetIconAsync(this IEntry o) => o.GetAsync<string>("Icon");
        public static Task<string> GetDesktopFileAsync(this IEntry o) => o.GetAsync<string>("DesktopFile");
        public static Task<uint> GetCurrentWindowAsync(this IEntry o) => o.GetAsync<uint>("CurrentWindow");
        public static Task<bool> GetIsDockedAsync(this IEntry o) => o.GetAsync<bool>("IsDocked");
        public static Task<string> GetIdAsync(this IEntry o) => o.GetAsync<string>("Id");
        public static Task<bool> GetIsActiveAsync(this IEntry o) => o.GetAsync<bool>("IsActive");
        public static Task<string> GetMenuAsync(this IEntry o) => o.GetAsync<string>("Menu");
        public static Task<IDictionary<uint, (string, bool)>> GetWindowInfosAsync(this IEntry o) => o.GetAsync<IDictionary<uint, (string, bool)>>("WindowInfos");
    }

    [DBusInterface("com.deepin.dde.daemon.Launcher")]
    interface ILauncher : IDBusObject
    {
        Task<(string, string, string, string, long, long)[]> GetAllItemInfosAsync();
        Task<string[]> GetAllNewInstalledAppsAsync();
        Task<bool> GetDisableScalingAsync(string Id);
        Task<(string itemInfo, string, string, string, long, long)> GetItemInfoAsync(string Id);
        Task<bool> GetUseProxyAsync(string Id);
        Task<bool> IsItemOnDesktopAsync(string Id);
        Task MarkLaunchedAsync(string Id);
        Task<bool> RequestRemoveFromDesktopAsync(string Id);
        Task<bool> RequestSendToDesktopAsync(string Id);
        Task RequestUninstallAsync(string Id, bool Purge);
        Task SearchAsync(string Key);
        Task SetDisableScalingAsync(string Id, bool Value);
        Task SetUseProxyAsync(string Id, bool Value);
        Task<IDisposable> WatchSearchDoneAsync(Action<string[]> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchItemChangedAsync(Action<(string status, (string, string, string, string, long, long)itemInfo, long categoryID)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchNewAppLaunchedAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUninstallSuccessAsync(Action<string> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUninstallFailedAsync(Action<(string appId, string errMsg)> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<LauncherProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class LauncherProperties
    {
        private int _DisplayMode = default (int);
        public int DisplayMode
        {
            get
            {
                return _DisplayMode;
            }

            set
            {
                _DisplayMode = (value);
            }
        }

        private bool _Fullscreen = default (bool);
        public bool Fullscreen
        {
            get
            {
                return _Fullscreen;
            }

            set
            {
                _Fullscreen = (value);
            }
        }
    }

    static class LauncherExtensions
    {
        public static Task<int> GetDisplayModeAsync(this ILauncher o) => o.GetAsync<int>("DisplayMode");
        public static Task<bool> GetFullscreenAsync(this ILauncher o) => o.GetAsync<bool>("Fullscreen");
        public static Task SetDisplayModeAsync(this ILauncher o, int val) => o.SetAsync("DisplayMode", val);
        public static Task SetFullscreenAsync(this ILauncher o, bool val) => o.SetAsync("Fullscreen", val);
    }

    [DBusInterface("com.deepin.dde.TrayManager")]
    interface ITrayManager : IDBusObject
    {
        Task EnableNotificationAsync(uint Win, bool Enabled);
        Task<string> GetNameAsync(uint Win);
        Task<bool> ManageAsync();
        Task<IDisposable> WatchInitedAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAddedAsync(Action<uint> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRemovedAsync(Action<uint> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchChangedAsync(Action<uint> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<TrayManagerProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class TrayManagerProperties
    {
        private uint[] _TrayIcons = default (uint[]);
        public uint[] TrayIcons
        {
            get
            {
                return _TrayIcons;
            }

            set
            {
                _TrayIcons = (value);
            }
        }
    }

    static class TrayManagerExtensions
    {
        public static Task<uint[]> GetTrayIconsAsync(this ITrayManager o) => o.GetAsync<uint[]>("TrayIcons");
    }

    [DBusInterface("com.deepin.api.XEventMonitor")]
    interface IXEventMonitor : IDBusObject
    {
        Task BeginTouchAsync();
        Task<string> DebugGetPidAreasMapAsync();
        Task<string> RegisterAreaAsync(int X1, int Y1, int X2, int Y2, int Flag);
        Task<string> RegisterAreasAsync((int, int, int, int)[] Areas, int Flag);
        Task<string> RegisterFullScreenAsync();
        Task<bool> UnregisterAreaAsync(string Id);
        Task<IDisposable> WatchCancelAllAreaAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCursorIntoAsync(Action<(int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCursorOutAsync(Action<(int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCursorMoveAsync(Action<(int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchButtonPressAsync(Action<(int button, int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchButtonReleaseAsync(Action<(int button, int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchKeyPressAsync(Action<(string key, int x, int y, string id)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchKeyReleaseAsync(Action<(string key, int x, int y, string id)> handler, Action<Exception> onError = null);
    }

    [DBusInterface("com.deepin.LastoreSessionHelper")]
    interface ILastoreSessionHelper : IDBusObject
    {
        Task<bool> IsDiskSpaceSufficientAsync();
        Task<T> GetAsync<T>(string prop);
        Task<LastoreSessionHelperProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class LastoreSessionHelperProperties
    {
        private bool _SourceCheckEnabled = default (bool);
        public bool SourceCheckEnabled
        {
            get
            {
                return _SourceCheckEnabled;
            }

            set
            {
                _SourceCheckEnabled = (value);
            }
        }
    }

    static class LastoreSessionHelperExtensions
    {
        public static Task<bool> GetSourceCheckEnabledAsync(this ILastoreSessionHelper o) => o.GetAsync<bool>("SourceCheckEnabled");
    }

    [DBusInterface("org.freedesktop.ScreenSaver")]
    interface IScreenSaver : IDBusObject
    {
        Task<uint> InhibitAsync(string Name, string Reason);
        Task SetTimeoutAsync(uint Seconds, uint Interval, bool Blank);
        Task SimulateUserActivityAsync();
        Task UnInhibitAsync(uint Cookie);
        Task<IDisposable> WatchIdleOnAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCycleActiveAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchIdleOffAsync(Action handler, Action<Exception> onError = null);
    }
}