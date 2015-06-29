using System;
using Oculus_Test.Properties;

namespace Oculus_Test
{
  public class OculusAction
  {
    protected static IntPtr HGetProcIddll;

    public OculusAction(string dllVersion)
    {
      HGetProcIddll = OculusDll.Load(dllVersion);
      Console.WriteLine(@"HGetProcIddll vaut: " + HGetProcIddll);
      if (HGetProcIddll == IntPtr.Zero)
      {
        Console.WriteLine(Resources.OculusAction_OculusAction_Error_could_not_load_the_dynamic_library);
      }
    }

    public static bool IsDllLoad()
    {
      return (HGetProcIddll != IntPtr.Zero);
    }

    public string Show()
    {
      throw new NotImplementedException();
    }
  }
}
