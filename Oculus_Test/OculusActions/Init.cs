using System;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Init : OculusAction
  {
    private string _status;

    public Init(string dllVersion)
      : base(dllVersion)
    {
      _status = "Initializing";
      InitializeOculus();
    }

    public new string Show()
    {
      return _status;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int Initialize();

    private IntPtr RetrieveDllInitFunction()
    {
      var init = Dll.GetProcAddress(HGetProcIddll, "birth");
      if (init != IntPtr.Zero) return init;
      Console.WriteLine(Resources.Init_RetrieveDllInitFunction_Error__init_function_not_found_in_dll);
      _status = "Oculus' init function not found in dll, we drifted into the rift!";
      throw new NullReferenceException();
    }

    private void InitializeOculus()
    {
      var init = RetrieveDllInitFunction();
      var initializeOculus = (Initialize)Marshal.GetDelegateForFunctionPointer(init, typeof(Initialize));
      initializeOculus();
      _status = "Oculus might be ready";
    }
  }
}
