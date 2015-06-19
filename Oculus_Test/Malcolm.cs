using System;
using System.Windows.Controls;

namespace Oculus_Test
{
  public class Malcolm
  {
    protected string DllVersion;
    protected TextBlock Textblock;

    public Malcolm(string dllVersion, TextBlock field)
    {
      DllVersion = dllVersion;
      Textblock = field;
    }

    public void Update()
    {
      throw new NotImplementedException();
    }

    protected Malcolm()
    {
      throw new ArgumentException();
    }
  }
}
