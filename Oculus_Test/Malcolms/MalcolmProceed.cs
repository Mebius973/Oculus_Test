using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmProceed : Malcolm
  {
    private readonly Proceed _proceed;

    public MalcolmProceed(string dllVersion, TextBlock field)
      : base(dllVersion, field)
    {
      OculusDll.InitializeOculus(dllVersion);
      _proceed = new Proceed(dllVersion);
    }

    public new void Update()
    {
      if (Textblock.Inlines.Count > 1) Textblock.Inlines.Remove(Textblock.Inlines.LastInline);
      Textblock.Inlines.InsertAfter(Textblock.Inlines.FirstInline, new Run("\n" + _proceed.Show()));
    }
  }
}
