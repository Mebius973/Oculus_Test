using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmEyeHeight : Malcolm
  {
    private readonly EyeWidth _eyeWidth;
    public MalcolmEyeHeight(string dllVersion, TextBlock field)
    {
      _eyeWidth = new EyeWidth(dllVersion);
    }

    public void Update()
    {
      // This technique of display will be a problem when we ask the size several time in a row
      TextBlock.Inlines.Add(new Run("\n       "));
      TextBlock.Inlines.Add(new Run(_eyeWidth.Show()));
    }
  }
}
