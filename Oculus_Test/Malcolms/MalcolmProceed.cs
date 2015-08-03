using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;
using Oculus_Test.Utils;

namespace Oculus_Test.Malcolms
{
  public class MalcolmProceed : Malcolm
  {
    private readonly Proceed _proceed;

    public MalcolmProceed(string dllVersion, string imageMode, TextBlock field)
      : base(dllVersion, imageMode, field)
    {
      OculusDll.InitializeOculus(dllVersion);
      switch (imageMode)
      {
        case "Mono":
          Bytes.SetMode("Mono");
          _proceed = new ProceedMono(dllVersion);
          break;
        case "Dual":
          Bytes.SetMode("Dual");
          _proceed = new ProceedDual(dllVersion);
          break;
        case "None":
          // This is set here in an explicit way because we don't want a switch case somewhere else and it says explicitly what the default image mode is
          Bytes.SetMode("Dual");
          _proceed = new ProceedDual(dllVersion);
          break;
      }
    }

    public new void Update()
    {
      if (Textblock.Inlines.Count > 1) Textblock.Inlines.Remove(Textblock.Inlines.LastInline);
      Textblock.Inlines.InsertAfter(Textblock.Inlines.FirstInline, new Run("\n" + _proceed.Show()));
    }
  }
}
