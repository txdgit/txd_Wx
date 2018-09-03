using BLL.Comm;
using Business.Weixin;
using Dal;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    /// <summary>
    /// 邀请业务处理类
    /// </summary>
    public class InviteBll
    {
        /// <summary>
        /// 数据库操作类
        /// </summary>
        private BaseDal<Invite> dal = new BaseDal<Invite>();

        /// <summary>
        /// 邀请个数
        /// </summary>
        public long InviteCount(string ParenOpenID)
        {
            return dal.Total(p => p.ParentOpenID == ParenOpenID);
        }

        /// <summary>
        /// 查询实体
        /// </summary>
        public Invite GetModel(string OpenID, int i = 0)
        {
            Invite invite = dal.GetQueryable().Where(p => p.OpenID == OpenID).FirstOrDefault();
            if (invite == null && i < 3)
            {
                System.Threading.Thread.Sleep(1000);
                invite = GetModel(OpenID, i++);
            }
            if (invite == null) return null;
            if ((DateTime.Now - invite.UpdTime).TotalHours < 72)
                return invite;
            invite.PosterCoder = UploadImg(invite.Poster);
            invite.UpdTime = DateTime.Now;
            dal.Update(p => p.OpenID == OpenID, invite);
            return invite;
        }

        /// <summary>
        /// 上传临时素材
        /// </summary>
        private string UploadImg(string filePath)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Upload_Img_Url, WxConfig.Access_Token);
            string strRes = HttpHelper.PostUpload(url, filePath);
            JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);
            return jObject["media_id"].ToString();
        }

        /// <summary>
        /// 检查数据
        /// </summary>
        public async void CheckData(string OpenID, string ParenOpenID)
        {
            await Task.Run(() =>
            {
                try
                {
                    long count = dal.Total(p => p.OpenID == OpenID);
                    if (count <= 0)
                        Add(OpenID, ParenOpenID);
                    Invite invite = GetModel(OpenID);

                }
                catch (Exception ex)
                {
                    LogHelper.Write("Ex..11.." + ex.Message);
                }

            });
        }

        private void Add(string OpenID, string ParenOpenID)
        {
            string ticket = QRCoder(OpenID);
            string qRCoderFilePath = DowQRCoder(ticket, OpenID);
            string posterFilePath = Poster(OpenID, qRCoderFilePath);
            string posterCoder = UploadImg(posterFilePath);
            dal.Insert(new Invite()
            {
                OpenID = OpenID,
                ParentOpenID = ParenOpenID,
                QRCoder = qRCoderFilePath,
                Poster = posterFilePath,
                PosterCoder = posterCoder
            });
        }

        /// <summary>
        /// 生成二微码
        /// </summary>
        private string QRCoder(string OpenID)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Create_QRCoder_Url, WxConfig.Access_Token);
            string json = "{\"expire_seconds\": 864000, \"action_name\": \"QR_STR_SCENE\", \"action_info\": {\"scene\": {\"scene_str\": \"" + OpenID + "\"}}}";
            string strRes = HttpHelper.Post(url, json);
            JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);
            return jObject["ticket"].ToString();
        }

        /// <summary>
        /// 下载二维码
        /// </summary>
        private string DowQRCoder(string ticket, string OpenID)
        {
            string filePath = ConfigurationManager.AppSettings["UploadPath"];
            filePath += DateTime.Now.ToString("yyyyMMdd");
            if (!System.IO.Directory.Exists(filePath))
                System.IO.Directory.CreateDirectory(filePath);
            filePath += "\\" + OpenID + ".jpg";
            string url = string.Format(WxUrlConfig.Down_QRCoder_Url, System.Web.HttpUtility.UrlEncode(ticket));
            Task<Stream> taskStream = HttpHelper.GetStream(url);
            taskStream.GetAwaiter();
            Stream stream = taskStream.Result;
            Image img = Image.FromStream(stream);
            img.Save(filePath, ImageFormat.Jpeg);
            return filePath;
        }

        /// <summary>
        /// 生成海报
        /// </summary>
        public string Poster(string OpenID, string QRCoderPath)
        {
            string backPath = ConfigurationManager.AppSettings["UploadPath"]; ;
            string filePath = backPath;
            filePath += DateTime.Now.ToString("yyyyMMdd");
            if (!System.IO.Directory.Exists(filePath))
                System.IO.Directory.CreateDirectory(filePath);
            filePath += "\\" + OpenID + "_P.png";
            Image imgBack = System.Drawing.Image.FromFile(backPath + "back.png"); //相框图片 
            Image img = System.Drawing.Image.FromFile(QRCoderPath); //照片图片(二维码)
            Graphics g = Graphics.FromImage(imgBack);
            g.DrawImage(img, 400, 787, 150, 150);
            GC.Collect();
            imgBack.Save(filePath, ImageFormat.Png);
            return filePath;
        }
    }
}
