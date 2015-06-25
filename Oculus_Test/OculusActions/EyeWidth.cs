using System;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class EyeWidth : OculusAction
  {
    private int _width;

    public EyeWidth(string dllVersion)
    : base(dllVersion)
    {
      Ask();
    }

    public new string Show()
    {
      return _width.ToString();
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetImageWidth();

    private static IntPtr RetrieveDllGetImageWidthFunction()
    {
      var eyeWidth = Dll.GetProcAddress(HGetProcIddll, "getImageWidth");
      if (eyeWidth != IntPtr.Zero) return eyeWidth;
      Console.WriteLine(Resources.EyeWidth_RetrieveDllGetImageWidthFunction_Ask_Error__can_t_find_the_getImageWidth_function_from_the_dll);
      throw new NullReferenceException();
    }

    private void Ask()
    {
      var eyeWidth = RetrieveDllGetImageWidthFunction();
      var retrieveEyeWidth = (GetImageWidth)Marshal.GetDelegateForFunctionPointer(eyeWidth, typeof(GetImageWidth));
      _width = retrieveEyeWidth();
    }
  }
}
