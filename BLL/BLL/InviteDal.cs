using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    /// <summary>
    /// 邀请业务处理类
    /// </summary>
    public class InviteDal
    {
        /// <summary>
        /// 数据库操作类
        /// </summary>
        private BaseDal<Invite> dal = new BaseDal<Invite>();

        /// <summary>
        /// 检查数据
        /// </summary>
        public async void CheckData(string OpenID, string ParenOpenID)
        {
            await Task.Run(()=> {

            });
        }

        /// <summary>
        /// 生成二微码
        /// </summary>
        private string QRCoder()
        {
            return null;
        }

        /// <summary>
        /// 下载二维码
        /// </summary>
        private string DowQRCoder()
        {
            return null;
        }

        /// <summary>
        /// 生成海报
        /// </summary>
        private string Poster()
        {
            return null;
        }
    }
}
