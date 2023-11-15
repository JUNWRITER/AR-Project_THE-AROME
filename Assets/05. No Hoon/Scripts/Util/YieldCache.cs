using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    static class YieldCache
    {
        class FloatComparer : IEqualityComparer<float>
        {
            bool IEqualityComparer<float>.Equals(float x, float y)
            {
                return x == y;
            }
            int IEqualityComparer<float>.GetHashCode(float obj)
            {
                return obj.GetHashCode();
            }
        }

        public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

        private static readonly Dictionary<float, WaitForSeconds> timeInterval = new Dictionary<float, WaitForSeconds>(new FloatComparer());
        private static readonly Dictionary<float, WaitForSecondsRealtime> timeIntervalReal = new Dictionary<float, WaitForSecondsRealtime>(new FloatComparer());

        public static WaitForSeconds WaitForSeconds(float seconds)
        {
            WaitForSeconds waitForSeconds;
            if (!timeInterval.TryGetValue(seconds, out waitForSeconds))
                timeInterval.Add(seconds, waitForSeconds = new WaitForSeconds(seconds));

            return waitForSeconds;
        }

        public static WaitForSecondsRealtime WaitForSecondsRealTime(float seconds)
        {
            WaitForSecondsRealtime waitForSecondsRealtime;
            if (!timeIntervalReal.TryGetValue(seconds, out waitForSecondsRealtime))
                timeIntervalReal.Add(seconds, waitForSecondsRealtime = new WaitForSecondsRealtime(seconds));

            return waitForSecondsRealtime;
        }
    }
}
