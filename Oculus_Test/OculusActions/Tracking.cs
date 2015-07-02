using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test.OculusActions
{
    public class Tracking : OculusAction
    {
      private float[] _tracking;

      public Tracking(string dllVersion)
        : base(dllVersion)
        {
          Ask();
        }

        public new string Show()
        {
          var result = "";
          // on tronque _tracking à 10e-3 près parce que sinon l'affichage est moche et qu'on n'a pas besoin d'autant de précision
          for (var i = 0; i < 3; i++)
          {
            _tracking[i] = _tracking[i]*1000;
            _tracking[i] = (int) _tracking[i];
            _tracking[i] = _tracking[i]/1000;
            _tracking[i+3] = _tracking[i+3] * 1000;
            _tracking[i+3] = (int)_tracking[i+3];
            _tracking[i+3] = _tracking[i+3] / 1000;

            result = string.Concat(result, _tracking[i] + "   " + _tracking[i+3] + "\n");
          }
          return result;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr GetTracker();

        private static IntPtr RetrieveDllGetTrackerFunction()
        {
          var tracker = Dll.GetProcAddress(HGetProcIddll, "getTracker");
          if (tracker != IntPtr.Zero) return tracker;
          Console.WriteLine(Resources.Tracking_RetrieveDllGetTrackerFunction_Ask_Error__can_t_find_the_getTracker_function_from_the_dll);
          throw new NullReferenceException();
        }

        private void Ask()
        {
          var tracker = RetrieveDllGetTrackerFunction();
          var retrieveTracking = (GetTracker)Marshal.GetDelegateForFunctionPointer(tracker, typeof(GetTracker));
          var resultPtr = retrieveTracking();
          var result = new float[6];
          Marshal.Copy(resultPtr, result, 0, 6);
          _tracking = result;
        }
    }
}
