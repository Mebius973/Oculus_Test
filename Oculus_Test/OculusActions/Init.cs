using System;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Init : OculusAction
  {
    private string _status;
    private bool _initSuccess;

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

    public bool IsInitialized()
    {
      return _initSuccess;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate bool Initialize();

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
      _initSuccess = initializeOculus();
      _status = _initSuccess ? "Oculus is ready" : "Failed to initialize Oculus" ;
    }
  }
}
