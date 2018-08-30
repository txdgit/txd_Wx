using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    /// <summary>
    /// 基础实体类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }= ObjectId.GenerateNewId().ToString();

        /// <summary>
        /// 创建时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 微信ID
        /// </summary>
        public string OpenID { get; set; }
    }
}
