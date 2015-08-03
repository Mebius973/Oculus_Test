using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmEyeHeight : Malcolm
  {
    private readonly EyeHeight _eyeHeight;

    public MalcolmEyeHeight(string dllVersion, string imageMode, TextBlock field)
      : base(dllVersion, imageMode, field)
    {
      OculusDll.InitializeOculus(dllVersion);
      OculusDll.ProcessOculus(dllVersion, imageMode);
      _eyeHeight = new EyeHeight(dllVersion);
    }

    public new void Update()
    {
      if (Textblock.Inlines.Count > 1) Textblock.Inlines.Remove(Textblock.Inlines.LastInline);
      Textblock.Inlines.InsertAfter(Textblock.Inlines.FirstInline, new Run("\n" + _eyeHeight.Show()));
    }
  }
}
