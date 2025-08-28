using System.Runtime.InteropServices;
using CMSL.Core.Logging;

namespace CMSL.Core.Info;

public static class SystemInfo
{
    public static OSType OS { get; private set; } = OSType.Windows;

    // for Mica effect, we need to know the OS version
    public static bool IsWindows11 { get; private set; } = false;

    public static bool Is64Bit { get; private set; } = true;
    
    public static OSArch Arch { get; private set; } = OSArch.X86_64;
    
    public static void Init()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            OS = OSType.Windows;

            var winVer = Environment.OSVersion.Version;
            
            // Win11's first release build number is 22000
            if (winVer.Major > 10 || (winVer.Major == 10 && winVer.Build >= 22000))
            {
                IsWindows11 = true;
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            OS = OSType.Linux;
        } 
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            OS = OSType.MacOS;
        }
        
        if (Environment.Is64BitOperatingSystem)
        {
            Is64Bit = true;
            
            if (RuntimeInformation.OSArchitecture == Architecture.Arm64)
            {
                Arch = OSArch.Aarch64;
            }
            else
            {
                Arch = OSArch.X86_64;
            }
        }
        else
        {
            Logger.Warn("32-bit operating system will be broken in 2038. Using 64-bit operating system is recommended.");
            Is64Bit = false;
            
            if (RuntimeInformation.OSArchitecture == Architecture.Arm)
            {
                Arch = OSArch.Arm;
            }
            else
            {
                Arch = OSArch.X86;
            }
        }
    }
}

public enum OSType
{
    Windows,
    Linux,
    MacOS
}

public enum OSArch
{
    X86,
    X86_64,
    Arm,
    Aarch64
}
