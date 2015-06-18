using System;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test
{
  public class OculusAction
  {
    public static IntPtr HGetProcIddll;

    public OculusAction(string dllVersion)
    {
      switch (dllVersion)
      {
        case "New":
          HGetProcIddll = Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus (DX11).dll");
          Console.WriteLine(@"HGetProcIddll vaut: " + HGetProcIddll);
          break;
        case "Old":
          HGetProcIddll = Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus.dll");
          Console.WriteLine(@"HGetProcIddll vaut: " + HGetProcIddll);
          break;
        case "None":
          // By default, when no version is specified, we will use the old one
          HGetProcIddll = Dll.LoadLibrary(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\Oculus.dll");
          Console.WriteLine(@"HGetProcIddll vaut: " + HGetProcIddll);
          break;
      }

      if (HGetProcIddll == IntPtr.Zero)
      {
        Console.WriteLine(Resources.OculusAction_OculusAction_Error_could_not_load_the_dynamic_library);
      }
    }

    public bool IsDllLoad()
    {
      return (HGetProcIddll != IntPtr.Zero);
    }

    public string Show()
    {
      throw new NotImplementedException();
    }

    protected OculusAction()
    {
    }
  }
}
