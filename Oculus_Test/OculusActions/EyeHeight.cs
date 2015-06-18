using System;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class EyeHeight : OculusAction
  {
    private int _height;

    public EyeHeight(string dllVersion)
    {
      Ask();
    }

    public new string Show()
    {
      return _height.ToString();
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetImageHeight();

    private static IntPtr RetrieveDllGetImageHeightFunction()
    {
      var eyeHeight = Dll.GetProcAddress(HGetProcIddll, "getImageHeight");
      if (eyeHeight != IntPtr.Zero) return eyeHeight;
      Console.WriteLine(Resources.EyeHeight_Ask_Error__can_t_find_the_getImageHeight_function_from_the_dll);
      throw new NullReferenceException();
    }

    private void Ask()
    {
      var eyeHeight = RetrieveDllGetImageHeightFunction();
      var getImageHeight = (GetImageHeight)Marshal.GetDelegateForFunctionPointer(eyeHeight, typeof(GetImageHeight));
      _height = getImageHeight();
    }
  }
}
