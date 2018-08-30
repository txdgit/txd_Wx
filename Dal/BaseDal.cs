using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    /// <summary>
    /// MongoDB操作类
    /// </summary>
    /// <typeparam name="T">对应实体类</typeparam>
    public class BaseDal<T> where T:class
    {
        /// <summary>
        /// 路径
        /// </summary>
        private static string DBPath = ConfigurationManager.AppSettings["MongoDB"];

        /// <summary>
        /// 表名
        /// </summary>
        private  string TableName = typeof(T).Name;

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static IMongoDatabase Database=null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseDal()
        {
            if (Database != null)
                return;
            var url = new MongoUrl(DBPath);
            MongoClientSettings mcs = MongoClientSettings.FromUrl(url);
            mcs.MaxConnectionLifeTime = TimeSpan.FromMilliseconds(2000);
            var client = new MongoClient(mcs);
            Database = client.GetDatabase(url.DatabaseName);
        }

        /// <summary>
        /// 创建集合对象
        /// </summary>
        ///<returns>集合对象</returns>
        private IMongoCollection<T> GetColletion()
        {
            return Database.GetCollection<T>(TableName);
        }

        #region 增加
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="t">插入的对象</param>
        public void Insert(T t)
        {
            var coll = GetColletion();
            coll.InsertOne(t);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="ts">要插入的对象集合</param>
        public void InsertBath(IEnumerable<T> ts)
        {
            var coll = GetColletion();
            coll.InsertMany(ts);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 按条件表达式删除 单条记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        public Int64 Delete(Expression<Func<T, Boolean>> predicate)
        {
            var coll = GetColletion();
            var result = coll.DeleteOne(predicate);
            return result.DeletedCount;
        }

        /// <summary>
        /// 按条件表达式删除 多条记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        public Int64 DeleteMany(Expression<Func<T, Boolean>> predicate)
        {
            var coll = GetColletion();
            var result = coll.DeleteMany(predicate);
            return result.DeletedCount;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改文档
        /// </summary>
        /// <param name="filter">修改条件</param>
        /// <param name="update">修改结果</param>
        /// <param name="upsert">是否插入新文档（filter条件满足就更新，否则插入新文档）</param>
        public Int64 Update(Expression<Func<T, Boolean>> filter, UpdateDefinition<T> update, Boolean upsert = true)
        {
            var coll = GetColletion();
            var result = coll.UpdateMany(filter, update, new UpdateOptions { IsUpsert = upsert });
            return result.ModifiedCount;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询，复杂查询直接用Linq处理
        /// </summary>
        public IQueryable<T> GetQueryable()
        {
            var coll = GetColletion();
            return coll.AsQueryable<T>();
        }

        /// <summary>
        /// 查询个数
        /// </summary>
        /// <param name="expression">查询条件</param>
        public long Total(Expression<Func<T, bool>> expression)
        {
            long count = GetColletion().CountDocuments(expression);
            return count;
        }
        #endregion
    }
}
