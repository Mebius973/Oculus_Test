using System;
using System.Windows.Controls;

namespace Oculus_Test
{
  public class Malcolm
  {
    protected readonly string DllVersion;
    protected readonly TextBlock Textblock;

    protected Malcolm(string dllVersion, TextBlock field)
    {
      DllVersion = dllVersion;
      Textblock = field;
    }

    public void Update()
    {
      throw new NotImplementedException();
    }
  }
}
