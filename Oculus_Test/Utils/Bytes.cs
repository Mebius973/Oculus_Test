using System;
using System.Drawing;

namespace Oculus_Test.Utils
{
  static class Bytes
  {
    private const int Rgbmode = 3;
    private const int Rgbamode = 4;
    private const int RenderWidth = 1180;
    private const int RenderHeight = 1460;
    private const int RgbRenderWidth = Rgbmode*RenderWidth;
    private const int RgbaRenderWidth = Rgbamode*RenderWidth;
    private const int Size = RenderHeight*RenderWidth;
    private const int SizeRgb = RenderHeight*RgbRenderWidth;
    private const int SizeRgba = RenderHeight*RgbaRenderWidth;

    public static byte[] BmpToBytes(Image source)
    {
      var converter = new ImageConverter();
      var target = (byte[])converter.ConvertTo(source, typeof(byte[]));
      if (target != null) return target;
      throw new ArgumentNullException();
    }

    public static byte[] ConvertRgbToRgba(byte[] sourceRgb)
    {
      var targetRgba  = new byte[SizeRgba];
      for (int i = 0; i < targetRgba.Length; i++) { targetRgba[i] = 0; }
      if (targetRgba.Length / sourceRgb.Length != 4 / 3)
      {
        throw new ArgumentException();
      }
      var target = new byte[4];
      for (var i = 0; i < Size; i++)
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
      var rgbDataBytes = new byte[SizeRgb] ;
      for (int i = 0; i < rgbDataBytes.Length; i++) { rgbDataBytes[i] = 0; }
      for (var y = 0; y < RenderHeight; y++)
      {
        for (var x = 0; x < RgbRenderWidth; x++)
        {
          if (x < RgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((RenderHeight - 1 - y) * RgbRenderWidth)] = leftDataBytes[x + (y * RgbRenderWidth / 2)];
          }
          else if ((RgbRenderWidth - x) < RgbRenderWidth / 2)
          {
            rgbDataBytes[x + ((RenderHeight - 1 - y) * RgbRenderWidth)] = rightDataBytes[x - (RgbRenderWidth - (RgbRenderWidth / 2)) + (y * RgbRenderWidth / 2)];
          }
          else
          {
            rgbDataBytes[x + ((RenderHeight - 1 - y) * RgbRenderWidth)] = 0;
          }
        }
      }
      return rgbDataBytes;
    }
  }
}
