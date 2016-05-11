#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("8sHxxmQMaTZVyoUUsWw5FLHI8K94cKkmnxFWGbC7GE/Vr0i9pJDN3Nc4LtxBYjnyRYKtY55oVOQGewpxw3Hy0cP+9frZdbt1BP7y8vL28/Ap9WT8AOvwLBMXNr8qmeLtajDTOjBKARfPiT5ZPMG5uWHYnFcEBIfOP73QuzplNaDDQ6pF8ohrMq2j3eMtDwJhwt9meU5ZAZfvWw2Wv/pOG25RReoM5+ihFPuOttHMrqQSXAUFcfL888Nx8vnxcfLy82WDZ/1NhJnjFwVLV6jyaZ8ZX9W4ZOqAmvR/eqUHx3IeI8HfAB4CRIAtbaQEX/54lcbEAz26e/NyfWaCXXDURSlzMyJbNmah8oip2g2KLrBptpahwIh/0zvfIpWXMoUAivHw8vPy");
        private static int[] order = new int[] { 5,4,7,5,12,6,10,13,9,12,11,13,13,13,14 };
        private static int key = 243;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
