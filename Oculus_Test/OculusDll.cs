using System;
using Oculus_Test.OculusActions;
using Oculus_Test.Utils;

namespace Oculus_Test
{
  static class OculusDll
  {
    private static IntPtr _dllPtr;
    private static string _currentVersion;
    private static bool _isInitialzed;
    private static bool _isProceed;

    public static IntPtr Load(string dllVersion)
    {
      if (_dllPtr != IntPtr.Zero && _currentVersion != dllVersion)
      {
        var test = Dll.FreeLibrary(_dllPtr);
        Console.WriteLine(test);
      }
      _dllPtr = SelectVersion(dllVersion);
      _currentVersion = dllVersion;
      return _dllPtr;
    }

    public static void InitializeOculus(string dllVersion)
    {
      if (_currentVersion == dllVersion && _isInitialzed) return;
      var init = new Init(dllVersion);
      _isInitialzed = init.IsInitialized();
    }

    public static void ProcessOculus(string dllVersion)
    {
      if (_currentVersion == dllVersion && _isProceed) return;
      var proceed = new Proceed(dllVersion);
      _isProceed = proceed.IsProceed();
    }

    public static void ReleaseOculus()
    {
      _isInitialzed = false;
    }

    private static IntPtr SelectVersion(string dllVersion)
    {
      switch (dllVersion)
      {
        case "New":
          return Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus (DX11).dll");
        case "Old":
          return Dll.LoadLibrary(@"C:\SiVIC2010\OculusRiftSDK\Samples\OculusRoomTiny\Bin\Win\VS2010\Debug\Win32\OculusRoomTiny.dll");
        case "None":
          // By default, when no version is specified, we will use the old one
          return Dll.LoadLibrary(@"C:\SiVIC2010\OculusRiftSDK\Samples\OculusRoomTiny\Bin\Win\VS2010\Debug\Win32\OculusRoomTiny.dll");
      }
      return IntPtr.Zero;
    }
  }
}
