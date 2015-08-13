using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Proceed : OculusAction
  {
    protected string Status;
    protected bool _isProceed;

    protected Proceed(string dllVersion)
      : base(dllVersion)
    {
      Status = "Beginning processing Oculus";
    }

    public new string Show()
    {
      return Status;
    }

    public bool IsProceed()
    {
      return _isProceed;
    }

    protected IntPtr RetrieveDllProcessFunction()
    {
      var process = Dll.GetProcAddress(HGetProcIddll, "process");
      if (process != IntPtr.Zero) return process;
      Console.WriteLine(Resources.Proceed_RetrieveDllProcessFunction_RetrieveDllInitFunction_Error__init_function_not_found_in_dll);
      Status = "Oculus' process function not found in dll, we drifted into the rift!";
      throw new NullReferenceException();
    }

    protected static Image GetImage(string side)
    {
      return Image.FromFile(side == "left" ? @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-left-eye-autogen-guillaume.bmp" : @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-right-eye-autogen-guillaume.bmp");
    }

    protected static void ProcessOculus()
    {
      throw new NotImplementedException();
    }
  }
}
