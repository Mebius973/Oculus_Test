using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmTracking : Malcolm
  {
    private readonly Tracking _tracking;
    public MalcolmTracking(string dllVersion, TextBlock field)
    {
      _tracking = new Tracking(dllVersion);
    }

    public new void Update()
    {
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_tracking.Show()));
    }
  }
}