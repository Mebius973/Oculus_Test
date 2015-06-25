using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmRelease : Malcolm
  {
    private readonly Release _release;

    public MalcolmRelease(string dllVersion, TextBlock field)
      : base(dllVersion, field)
    {
      _release = new Release(dllVersion);
    }

    public new void Update()
    {
      // This technique of display will be a problem when we ask the size several time in a row
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_release.Show()));
    }
  }
}
