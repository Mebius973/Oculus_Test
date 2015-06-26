using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class Proceed : OculusAction
  {
    private string _status;

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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int Process(char[] data);

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
      var bmp = Bitmap.FromFile(@"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-left-eye.bmp");
      var converter = new ImageConverter();
      var dataBytes = (byte[]) converter.ConvertTo(bmp, typeof (byte[]));
      var data = System.Text.Encoding.UTF8.GetString(dataBytes).ToCharArray();
      var process = RetrieveDllProcessFunction();
      var processOculus = (Process)Marshal.GetDelegateForFunctionPointer(process, typeof(Process));

      processOculus(data);
      _status = "Oculus has been proceed";
    }
  }
}
