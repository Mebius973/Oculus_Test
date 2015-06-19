using System;
using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmEyeHeight : Malcolm
  {
    private readonly EyeHeight _eyeHeight;
    public MalcolmEyeHeight(string dllVersion, TextBlock field)
    {
      _eyeHeight = new EyeHeight(dllVersion);
    }

    public new void Update()
    {
      // This technique of display will be a problem when we ask the size several time in a row
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_eyeHeight.Show()));
    }
  }
}
