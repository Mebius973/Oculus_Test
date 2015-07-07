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

    private static Image GetImage(string side)
    {
      return Image.FromFile(side == "left" ? @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-left-eye.bmp" : @"C:\Users\Casque2\OneDrive\Stage IFSTTAR\Oculus_Test\Oculus_Test\assets\pirate-ship-right-eye.bmp");
    }

    private unsafe void ProcessOculus()
    {
      var converter = new ImageConverter();

      // Left eye image
      var bmp = GetImage("left");
      var dataBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
      if (dataBytes == null)
      {
        _status = "Couldn't open image files";
        return;
      }
      MainWindow.SetLeftEyeImage(dataBytes);
      var process = RetrieveDllProcessFunction();
      var processOculus = (Process)Marshal.GetDelegateForFunctionPointer(process, typeof(Process));
      var renderWidth = 2360;
      var renderHeight = 1460;
      var RGBAMODE = 4;

      var size = renderHeight * renderWidth * RGBAMODE;
      byte[] normedDataBytes = new byte[size];
      for (var i = 0; i < size/2; i++)
      {
        if (i < dataBytes.Length)
        {
          normedDataBytes[i] = dataBytes[i];
        }
        else
        {
          normedDataBytes[i] = 0;
        }
      }

      bmp = GetImage("right");
      dataBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
      if (dataBytes == null)
      {
        _status = "Couldn't open image files";
        return;
      }
      MainWindow.SetRightEyeImage(dataBytes);

      for (var i = size/2; i < size / 2; i++)
      {
        if ((i - size/2) < dataBytes.Length)
        {
          normedDataBytes[i] = dataBytes[i];
        }
        else
        {
          normedDataBytes[i] = 0;
        }
      }
      fixed (byte* bytes = normedDataBytes)
      {
        processOculus(bytes);
      }
   
      _status = "Oculus has been proceed";
      _isProceed = true;
    }
  }
}
