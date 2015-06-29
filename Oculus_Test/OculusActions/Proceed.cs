using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Proceed : OculusAction
  {
    private string _status;
    private bool _isProceed;

    public Proceed(string dllVersion)
      : base(dllVersion)
    {
      _status = "Beginning precessing Oculus";
      ProcessOculus();
    }

    public new string Show()
    {
      return _status;
    }

    public bool IsProceed()
    {
      return _isProceed;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void Process(
    [MarshalAs(UnmanagedType.LPStr)]StringBuilder data);

    private IntPtr RetrieveDllProcessFunction()
    {
      var process = Dll.GetProcAddress(HGetProcIddll, "process");
      if (process != IntPtr.Zero) return process;
      Console.WriteLine(Resources.Proceed_RetrieveDllProcessFunction_RetrieveDllInitFunction_Error__init_function_not_found_in_dll);
      _status = "Oculus' process function not found in dll, we drifted into the rift!";
      throw new NullReferenceException();
    }

    private void ProcessOculus()
    {
      var bmp = Image.FromFile(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-left-eye.bmp");
      var converter = new ImageConverter();
      var dataBytes = (byte[]) converter.ConvertTo(bmp, typeof (byte[]));
      if (dataBytes == null)
      {
        _status = "Couldn't open image files";
        return;
      }
      var data = new StringBuilder();
      foreach (var databyte in dataBytes)
      {
        data.Append(databyte);
      }
      var process = RetrieveDllProcessFunction();
      var processOculus = (Process)Marshal.GetDelegateForFunctionPointer(process, typeof(Process));
      processOculus(data);
      _status = "Oculus has been proceed";
      _isProceed = true;
    }
  }
}
