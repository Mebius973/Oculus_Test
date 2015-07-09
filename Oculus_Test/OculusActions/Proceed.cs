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

    private byte[] BmpToBytes(Image source)
    {
      var converter = new ImageConverter();
      var bytes = (byte[])converter.ConvertTo(source, typeof(byte[]));
      if (bytes != null) return bytes;      
        _status = "Couldn't open image files";
      throw new ArgumentNullException();
    }

    private void ConvertRgbToRgba(byte[] sourceRgb, byte[] targetRgba)
    {
      if (targetRgba.Length / sourceRgb.Length != 4 / 3)
      { 
        throw new ArgumentException();
      }
      var target = new byte[4];
      for (var i = 0; i < sourceRgb.Length / 3; i++)
      {
        target[2] = sourceRgb[3 * i];
        target[1] = sourceRgb[3 * i + 1];
        target[0] = sourceRgb[3 * i + 2];
        target[3] = 0;

        target.CopyTo(targetRgba, 4 * i);
      }
    }

    private unsafe void ProcessOculus()
    {
      //TODO: Oculus Params which should be somewhere else
      var RGBMODE = 3;
      var RGBAMODE = 4;
      var renderWidth = 2360;
      var sourceRgbRenderWidth = RGBMODE * renderWidth;
      var rgbRenderWidth = RGBMODE * renderWidth + 0;
      var rgbaRenderWidth = RGBAMODE * renderWidth + 0;
      var renderHeight = 1460;
      var sizeRGB = renderHeight * rgbRenderWidth;
      var sizeRGBA = renderHeight * rgbaRenderWidth;

      // rgb and rgba byte[] used to load the image from the bmp and then preparing it to be transfered to the Oculus.
      byte[] rgbDataBytes = new byte[sizeRGB] ;
      for (int i = 0; i < rgbDataBytes.Length; i++) { rgbDataBytes[i] = 0; }
      byte[] rgbaDataBytes = new byte[sizeRGBA];
      for (int i = 0; i < rgbaDataBytes.Length; i++) { rgbaDataBytes[i] = 0; }

      // Retrieving the Process function from the dll
      var process = RetrieveDllProcessFunction();
      var processOculus = (Process)Marshal.GetDelegateForFunctionPointer(process, typeof(Process));

      // Left eye image
      var bmp = GetImage("left");
      var leftDataBytes = BmpToBytes(bmp);

      Console.Write("2 * leftDataBytes.Length - sizeRGB: ");
      Console.WriteLine(2 * leftDataBytes.Length - sizeRGB);

      // Right eye image
      bmp = GetImage("right");
      var rightDataBytes = BmpToBytes(bmp);
      //We juxtapose the images

      var maxIteration = 0;
      for (var y = 0; y < renderHeight; y++)
      {
        for (var x = 0; x < rgbRenderWidth; x++)
        {
          if (x < sourceRgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = leftDataBytes[x + (y * sourceRgbRenderWidth / 2)];
          }
          else if ((rgbRenderWidth - x) < sourceRgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = rightDataBytes[x - (rgbRenderWidth - (sourceRgbRenderWidth / 2)) + (y * sourceRgbRenderWidth / 2)];
          }
          else 
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = 0;
          }
          maxIteration++;
        }
      }

      ConvertRgbToRgba(rgbDataBytes, rgbaDataBytes);
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
