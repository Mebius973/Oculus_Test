using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Oculus_Test.Utils
{
  static class Bytes
  {
    public static int RGBMODE = 3;
    public static int RGBAMODE = 4;
    private static int renderWidth = 2360;
    private static int renderHeight = 1460;
    private static int rgbRenderWidth = RGBMODE * renderWidth;
    private static int rgbaRenderWidth = RGBAMODE * renderWidth;
    public static int sizeRGB = renderHeight * rgbRenderWidth;
    private static int sizeRGBA = renderHeight * rgbaRenderWidth;

    public static byte[] BmpToBytes(Image source)
    {
      var converter = new ImageConverter();
      var target = (byte[])converter.ConvertTo(source, typeof(byte[]));
      if (target != null) return target;
      throw new ArgumentNullException();
    }

    public static byte[] ConvertRgbToRgba(byte[] sourceRgb)
    {
      var targetRgba  = new byte[sizeRGBA];
      for (int i = 0; i < targetRgba.Length; i++) { targetRgba[i] = 0; }
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
      return targetRgba;
    }

    public static byte[] EyeImagesToOculusRgb(byte[] leftDataBytes, byte[] rightDataBytes)
    {
      var rgbDataBytes = new byte[sizeRGB] ;
      for (int i = 0; i < rgbDataBytes.Length; i++) { rgbDataBytes[i] = 0; }
      for (var y = 0; y < renderHeight; y++)
      {
        for (var x = 0; x < rgbRenderWidth; x++)
        {
          if (x < rgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = leftDataBytes[x + (y * rgbRenderWidth / 2)];
          }
          else if ((rgbRenderWidth - x) < rgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = rightDataBytes[x - (rgbRenderWidth - (rgbRenderWidth / 2)) + (y * rgbRenderWidth / 2)];
          }
          else
          {
            rgbDataBytes[x + ((renderHeight - 1 - y) * rgbRenderWidth)] = 0;
          }
        }
      }
      return rgbDataBytes;
    }
  }
}
