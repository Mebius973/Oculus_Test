using System;
using System.Windows.Controls;

namespace Oculus_Test
{
  public class Malcolm
  {
    protected readonly TextBlock TextBlock;
    public Malcolm(string dllVersion, TextBlock field)
    {
      TextBlock = field;
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