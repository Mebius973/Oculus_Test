using System;
using System.Drawing;

namespace Oculus_Test.Utils
{
  static class Bytes
  {
    private static int _nbImage;
    private const int Rgbmode = 3;
    private const int Rgbamode = 4;
    private static int _renderWidth;
    private static int _renderHeight;
    private static int _rgbRenderWidth;
    private static int _rgbaRenderWidth;
    private static int _size;
    private static int _sizeRgb;
    private static int _sizeRgba;

    // No matter what you do, always set the mode first!
    public static void SetMode(string imageMode)
    {
      _nbImage = (imageMode == "Mono" ? 2 : 1);
      UpdateConstants();
    }

    public static byte[] BmpToBytes(Image source)
    {
      var converter = new ImageConverter();
      var target = (byte[])converter.ConvertTo(source, typeof(byte[]));
      if (target != null) return target;
      throw new ArgumentNullException();
    }

    public static byte[] ConvertRgbToRgba(byte[] sourceRgb)
    {
      var targetRgba = new byte[_sizeRgba];
      for (int i = 0; i < targetRgba.Length; i++) { targetRgba[i] = 0; }
      if (targetRgba.Length / sourceRgb.Length != 4 / 3)
      {
        throw new ArgumentException();
      }
      var target = new byte[4];
      for (var i = 0; i < _size; i++)
      {
        target[2] = sourceRgb[3 * i];
        target[1] = sourceRgb[3 * i + 1];
        target[0] = sourceRgb[3 * i + 2];
        target[3] = 0;

        target.CopyTo(targetRgba, 4 * i);
      }
      return targetRgba;
    }

    public static byte[] VerticalFlip(byte[] dataBytes)
    {
      var flipedBytes = new byte[_sizeRgba];
      for (var y = 0; y < _renderHeight; y++)
      {
        for (var x = 0; x < _rgbaRenderWidth; x++)
        {
          flipedBytes[x + ((_renderHeight - 1 - y) * _rgbaRenderWidth)] = dataBytes[x + y * _rgbaRenderWidth];
        }
      }
      return flipedBytes;
    }

    public static byte[] EyeImagesToOculusRgb(byte[] leftDataBytes, byte[] rightDataBytes)
    {
      var rgbDataBytes = new byte[_sizeRgb];
      for (int i = 0; i < rgbDataBytes.Length; i++) { rgbDataBytes[i] = 0; }
      for (var y = 0; y < _renderHeight; y++)
      {
        for (var x = 0; x < _rgbRenderWidth; x++)
        {
          if (x < _rgbRenderWidth / 2)
          {
            rgbDataBytes[x + y * _rgbRenderWidth] = leftDataBytes[x + (y * _rgbRenderWidth / 2)];
          }
          else if ((_rgbRenderWidth - x) < _rgbRenderWidth / 2)
          {
            rgbDataBytes[x + y * _rgbRenderWidth] = rightDataBytes[x - (_rgbRenderWidth - (_rgbRenderWidth / 2)) + (y * _rgbRenderWidth / 2)];
          }
          else
          {
            rgbDataBytes[x + y * _rgbRenderWidth] = 0;
          }
        }
      }
      return rgbDataBytes;
    }
    
    private static void UpdateConstants()
    {
      _renderWidth = 1180 * _nbImage;
      _renderHeight = 1460;
      _rgbRenderWidth = Rgbmode * _renderWidth;
      _rgbaRenderWidth = Rgbamode * _renderWidth;
      _size = _renderHeight * _renderWidth;
      _sizeRgb = _renderHeight * _rgbRenderWidth;
      _sizeRgba = _renderHeight * _rgbaRenderWidth;
    }
  }
}
