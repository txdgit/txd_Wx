using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 邀请
    /// </summary>
    public class Invite:BaseEntity
    {
        /// <summary>
        /// 邀请微信ID
        /// </summary>
        public string ParentOpenID { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCoder { get; set; }

        /// <summary>
        /// 海报地址
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        /// 海报上传微信临时素材ID
        /// </summary>
        public string PosterCoder { get; set; }
    }
}
