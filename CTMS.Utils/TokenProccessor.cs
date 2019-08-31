using System;

namespace CTMS.Utils
{
    public static class TokenProccessor
    {
        /**
         * 生成Token
         * Token：Nv6RRuGEVvmGjB+jimI/gw==
         * @return
         */
        public static string MakeToken()
        {
            string token = (DateTime.Now.Millisecond + new Random().Next(999999999)) + "";
            return "Hm3052716655fb36e7dda2e0f55e232ec7";
        }
    }
}
