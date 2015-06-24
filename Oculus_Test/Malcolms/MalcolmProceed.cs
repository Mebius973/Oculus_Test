using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmProceed : Malcolm
  {
    private readonly Proceed _proceed;
    public MalcolmProceed(string dllVersion, TextBlock field)
    {
      _proceed = new Proceed(dllVersion);
    }

    public new void Update()
    {
      // This technique of display will be a problem when we ask the size several time in a row
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_proceed.Show()));
    }
  }
}
