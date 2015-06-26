using System;
using Oculus_Test.Utils;

namespace Oculus_Test
{
  static class OculusDll
  {
    private static IntPtr _dllPtr;

    public static IntPtr Load(string dllVersion)
    {
      if (_dllPtr != IntPtr.Zero)
      {
       var test = Dll.FreeLibrary(_dllPtr);
        Console.WriteLine(test);
      }
      _dllPtr = SelectVersion(dllVersion);
      return _dllPtr;
    }

    private static IntPtr SelectVersion(string dllVersion)
    {
      switch (dllVersion)
      {
        case "New":
          return Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus (DX11).dll");
        case "Old":
          return Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus.dll");
        case "None":
          // By default, when no version is specified, we will use the old one
          return Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus.dll");
      }
      return IntPtr.Zero;
    }
  }
}
