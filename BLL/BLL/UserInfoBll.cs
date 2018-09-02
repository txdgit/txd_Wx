using Business.Weixin;
using Dal;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    /// <summary>
    /// 用户业务处理
    /// </summary>
    public class UserInfoBll
    {
        /// <summary>
        /// 数据库操作类
        /// </summary>
        private BaseDal<UserInfo> dal = new BaseDal<UserInfo>();

        public void Update(UserInfo userInfo)
        {
            dal.Update(p => p.OpenID == userInfo.OpenID, userInfo);
        }

        public UserInfo GetModel(string OpenID)
        {
            return dal.GetQueryable().Where(p=>p.OpenID==OpenID).FirstOrDefault<UserInfo>();
        }

        /// <summary>
        /// 用户关注
        /// </summary>
        public void Subscribe(string OpenID,string ParenOpenID)
        {
            UserCheckAdd(OpenID);
            new InviteBll().CheckData(OpenID, ParenOpenID);
        }

        /// <summary>
        /// 判断用户是否存在，如果不存在增加数据库
        /// </summary>
        /// <param name="OpenID">微信ID</param>
        public async void UserCheckAdd(string OpenID)
        {
            await Task.Run(()=> {

                long count = dal.Total(p => p.OpenID == OpenID);
                if (count > 0) return;

                new WxHelper().LoadWx();
                string url = string.Format(WxUrlConfig.Get_UserInfo_Url,WxConfig.Access_Token,OpenID);
                string strRes = HttpHelper.Get(url);
                JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);
                string nickName = jObject["nickname"].ToString();
                string icon = jObject["headimgurl"].ToString();

                dal.Insert(new UserInfo()
                {
                    Icon = icon,
                    NickName = nickName,
                    OpenID = OpenID
                });
            });
        }

        /// <summary>
        /// 删除取消关注的用户
        /// </summary>
        /// <param name="OpenID"></param>
        public void Delete(string OpenID)
        {
            dal.Delete(p => p.OpenID == OpenID);
        }
    }
}
