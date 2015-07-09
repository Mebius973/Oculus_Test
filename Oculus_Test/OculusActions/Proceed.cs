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
    private unsafe delegate void Process(byte* data);

    private IntPtr RetrieveDllProcessFunction()
    {
      var process = Dll.GetProcAddress(HGetProcIddll, "process");
      if (process != IntPtr.Zero) return process;
      Console.WriteLine(Resources.Proceed_RetrieveDllProcessFunction_RetrieveDllInitFunction_Error__init_function_not_found_in_dll);
      _status = "Oculus' process function not found in dll, we drifted into the rift!";
      throw new NullReferenceException();
    }

    private Image GetImage(string side)
    {
      return Image.FromFile(side == "left" ? @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-left-eye.bmp" : @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-right-eye.bmp");
    }

    private unsafe void ProcessOculus()
    {
      // Retrieving the Process function from the dll
      var process = RetrieveDllProcessFunction();
      var processOculus = (Process)Marshal.GetDelegateForFunctionPointer(process, typeof(Process));

      // Left eye image
      var bmp = GetImage("left");
      var leftDataBytes = Bytes.BmpToBytes(bmp); // TODO: try/catch the exception raised by BmpToBytes

      // Right eye image
      bmp = GetImage("right");
      var rightDataBytes = Bytes.BmpToBytes(bmp); // TODO: try/catch the exception raised by BmpToBytes

      // We juxtapose the images
      byte[] rgbDataBytes = Bytes.EyeImagesToOculusRgb(leftDataBytes, rightDataBytes);

      // Then we convert to RGBA
      byte[] rgbaDataBytes = Bytes.ConvertRgbToRgba(rgbDataBytes);

      // Finally displays everything
      MainWindow.SetLeftEyeImage(leftDataBytes);
      MainWindow.SetRightEyeImage(rightDataBytes);
      fixed (byte* bytes = rgbaDataBytes)
      {
        processOculus(bytes);
      }

      _status = "Oculus has been proceed";
      _isProceed = true;
    }
  }
}
