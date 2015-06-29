using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmTracking : Malcolm
  {
    private readonly Tracking _tracking;

    public MalcolmTracking(string dllVersion, TextBlock field)
      : base(dllVersion, field)
    {
      OculusDll.InitializeOculus(dllVersion);
      OculusDll.ProcessOculus(dllVersion);
      _tracking = new Tracking(dllVersion);
    }

    public new void Update()
    {
      if (Textblock.Inlines.Count > 1) Textblock.Inlines.Remove(Textblock.Inlines.LastInline);
      Textblock.Inlines.InsertAfter(Textblock.Inlines.FirstInline, new Run("\n" + _tracking.Show()));
    }
  }
}