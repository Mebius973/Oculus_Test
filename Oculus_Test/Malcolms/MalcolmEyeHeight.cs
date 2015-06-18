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

    public void Update()
    {
      TextBlock.Inlines.Add(new Run("\n       "));
      TextBlock.Inlines.Add(new Run(_eyeHeight.Show()));
    }
  }
}