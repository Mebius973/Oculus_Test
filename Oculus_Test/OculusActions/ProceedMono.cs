using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
  public class ProceedMono : Proceed
  {
    public ProceedMono(string dllVersion)
      : base(dllVersion)
    {
      ProcessOculus();
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate void Process(byte* data);


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

      // We juxtapose the images
      byte[] rgbDataBytes = Bytes.EyeImagesToOculusRgb(leftDataBytes, rightDataBytes);

      // Then we convert to RGBA
      byte[] rgbaDataBytes = Bytes.ConvertRgbToRgba(rgbDataBytes);

      // We flip vertically the images because the image is upside down
      rgbaDataBytes = Bytes.VerticalFlip(rgbaDataBytes);

      // Finally displays everything
      MainWindow.SetLeftEyeImage(leftDataBytes);
      MainWindow.SetRightEyeImage(rightDataBytes);
      fixed (byte* dataBytes = rgbaDataBytes)
      {
        processOculus(dataBytes);
      }

      Status = "Oculus has been proceed";
      _isProceed = true;
    }
  }
}
