using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmRelease : Malcolm
  {
    private readonly Release _release;

    public MalcolmRelease(string dllVersion, string imageMode, TextBlock field)
      : base(dllVersion, imageMode, field)
    {
      OculusDll.InitializeOculus(dllVersion);
      OculusDll.ProcessOculus(dllVersion, imageMode);
      _release = new Release(dllVersion);
    }

    public new void Update()
    {
      if (Textblock.Inlines.Count > 1) Textblock.Inlines.Remove(Textblock.Inlines.LastInline);
      Textblock.Inlines.InsertAfter(Textblock.Inlines.FirstInline, new Run("\n" + _release.Show()));
    }
  }
}
