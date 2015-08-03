using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class ProceedDual : Proceed
  {
    public ProceedDual(string dllVersion)
      : base(dllVersion)
    {
      Bytes.SetMode("Dual");
      ProcessOculus();
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate void Process(byte* leftData, byte* rightData);

    private new unsafe void ProcessOculus()
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

      // Then we convert to RGBA
      byte[] rgbaLeftDataBytes = Bytes.ConvertRgbToRgba(leftDataBytes);
      byte[] rgbaRightDataBytes = Bytes.ConvertRgbToRgba(rightDataBytes);

      // We flip vertically the images because the image is upside down
      rgbaLeftDataBytes = Bytes.VerticalFlip(rgbaLeftDataBytes);
      rgbaRightDataBytes = Bytes.VerticalFlip(rgbaRightDataBytes);

      // Finally displays everything
      MainWindow.SetLeftEyeImage(leftDataBytes);
      MainWindow.SetRightEyeImage(rightDataBytes);
      fixed (byte* leftBytes = rgbaLeftDataBytes)
      {
        fixed (byte* rightBytes = rgbaRightDataBytes)
        {
          processOculus(leftBytes, rightBytes);
        }
      }

      Status = "Oculus has been proceed";
      _isProceed = true;
    }
  }
}
