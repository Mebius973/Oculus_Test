using System;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Release : OculusAction
  {
    private string _status;

    public Release(string dllVersion)
    : base(dllVersion)
    {
      _status = "Releasing";
      ReleaseOculus();
    }

    public new string Show()
    {
      return _status;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void Released();

    private IntPtr RetrieveDllReleaseFunction()
    {
      var release = Dll.GetProcAddress(HGetProcIddll, "death");
      if (release != IntPtr.Zero) return release;
      Console.WriteLine(Resources.Release_RetrieveDllReleaseFunction_RetrieveDllReleaseFunction_Error__release_function_not_found_in_dll);
      _status = "Oculus' release function not found in dll, we drifted into the rift!";
      throw new NullReferenceException();
    }

    private void ReleaseOculus()
    {
      var release = RetrieveDllReleaseFunction();
      var releaseOculus = (Released)Marshal.GetDelegateForFunctionPointer(release, typeof(Released));
      releaseOculus();
      _status = "Oculus might be released";
      OculusDll.ReleaseOculus();
    }
  }
}
