using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmEyeWidth : Malcolm
  {
    private readonly EyeWidth _eyeWidth;

    public MalcolmEyeWidth(string dllVersion, TextBlock field)
      : base(dllVersion, field)
    {
      _eyeWidth = new EyeWidth(dllVersion);
    }

    public new void Update()
    {
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_eyeWidth.Show()));
    }
  }
}
