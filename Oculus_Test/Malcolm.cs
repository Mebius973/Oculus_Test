using System;
using System.Windows.Controls;

namespace Oculus_Test
{
  public class Malcolm
  {
    protected readonly string DllVersion;
    protected readonly string ImageMode;
    protected readonly TextBlock Textblock;

    protected Malcolm(string dllVersion, string imageMode, TextBlock field)
    {
      DllVersion = dllVersion;
      Textblock = field;
      ImageMode = imageMode;
    }

    public void Update()
    {
      throw new NotImplementedException();
    }
  }
}
