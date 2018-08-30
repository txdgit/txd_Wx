using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserInfo:BaseEntity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像路径
        /// </summary>
        public string Icon { get; set; }
    }
}
