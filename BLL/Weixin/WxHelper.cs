using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// 微信共用方法
    /// </summary>
    public class WxHelper
    {

        /// <summary>
        /// Access_Token 加载
        /// </summary>
        public void LoadWx()
        {
            if (string.IsNullOrEmpty(WxConfig.Access_Token) || (DateTime.Now - WxConfig.Access_Token_LastDate).TotalMinutes > 100)
            {
                string strRes = HttpHelper.Get(WxUrlConfig.Get_Access_Token_Url);
                JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);
                WxConfig.Access_Token = jObject["access_token"].ToString();
                WxConfig.Access_Token_LastDate = DateTime.Now;
            }
        }


        /// <summary>
        /// 验证是否为微信接入数据   也做首次的配置使用 
        /// </summary>
        /// <param name="strTimeStamp"></param>
        /// <param name="strNonce"></param>
        /// <param name="strSignature"></param>
        /// <returns></returns>
        public bool DeveloperAuthentication(string strTimeStamp, string strNonce, string strSignature)
        {
            string strToken = WxConfig.Token;

            if (CheckSignature(strToken, strTimeStamp, strNonce, strSignature))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查加密算法　　
        /// </summary>
        /// <param name="strToken"></param>
        /// <param name="strTimeStamp"></param>
        /// <param name="strNonce"></param>
        /// <param name="strSignature"></param>
        /// <returns></returns>
        public bool CheckSignature(string strToken, string strTimeStamp, string strNonce, string strSignature)
        {
            string strSortString = DictionarySortString(strToken, strTimeStamp, strNonce);
            string strCheckString = SHA1Check(strSortString).ToLower();
            if (strSignature == strCheckString)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 字典排序
        /// </summary>
        /// <param name="strToken"></param>
        /// <param name="strTimeStamp"></param>
        /// <param name="strNonce"></param>
        /// <returns></returns>
        private string DictionarySortString(string strToken, string strTimeStamp, string strNonce)
        {
            List<string> lstString = new List<string>();
            StringBuilder sbResult = new StringBuilder();
            StringBuilder sbResult1 = new StringBuilder();
            lstString.Add(strToken);
            lstString.Add(strTimeStamp);
            lstString.Add(strNonce);
            List<string> lst = lstString.OrderBy(s => s).ToList();
            foreach (var item in lst)
            {
                sbResult.Append(item);
            }
            return sbResult.ToString();
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public string SHA1Check(string strIn)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strIn));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strIn, "SHA1");
        }

        /**
     　　* 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
      　 * @return 时间戳
     　　*/
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
