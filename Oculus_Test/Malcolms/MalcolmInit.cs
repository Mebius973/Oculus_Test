using System.Windows.Controls;
using System.Windows.Documents;
using Oculus_Test.OculusActions;

namespace Oculus_Test.Malcolms
{
  public class MalcolmInit : Malcolm
  {
    private readonly Init _init;

    public MalcolmInit(string dllVersion, TextBlock field)
      : base(dllVersion, field)
    {
      _init = new Init(dllVersion);
    }

    public new void Update()
    {
      Textblock.Inlines.Add(new Run("\n       "));
      Textblock.Inlines.Add(new Run(_init.Show()));
    }
  }
}
