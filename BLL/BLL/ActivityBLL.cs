using BLL.Comm;
using Business.Weixin;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public  class ActivityBLL
    {
        private UserInfoBll userInfoBll = new UserInfoBll();

        private InviteBll inviteBll = new InviteBll();

        public async void Subscribe(string OpenID, string ParenOpenID)
        {
            //if (ParenOpenID == OpenID)
            //    return;

            //判断用户是否存在数据库
            await Task.Run(()=> {
                userInfoBll.UserCheckAdd(OpenID);
            });
            
            //子用户业务处理
            await Task.Run(()=> {
                //增加邀请信息
                inviteBll.Add(OpenID,ParenOpenID);
                //查询邀请信息
                Invite invite = inviteBll.GetModel(OpenID);
                if (invite == null || invite.Pay)
                    return;
                //查询邀请个数
                long count = inviteBll.Count(OpenID);
                if (count == 0) //等于0说明刚才关注 所以发两条信息
                {
                    SendText(OpenID, FirstMsg());
                    SendImg(OpenID, invite.PosterCoder);
                }
                else if (count >= 2) //等于2说明已经邀请了2位好友 所以发两条信息
                {
                    SendText(OpenID, EndMsg());
                }
                else  
                {
                    SendText(OpenID, TwoMsg());
                    SendImg(OpenID, invite.PosterCoder);
                }
            });
            
            //父用户业务处理
            await Task.Run(()=> {

                System.Threading.Thread.Sleep(1000*10);

                Invite invite = inviteBll.GetModel(ParenOpenID);
                if (invite != null && invite.Pay)
                    return;

                //查询邀请个数
                long count = inviteBll.Count(ParenOpenID);
                if (count > 2)
                    return;
                if (count <= 2)
                {
                    //邀请用户信息
                    UserInfo userInfo = userInfoBll.GetModel(OpenID);
                    if (userInfo != null)
                        SendText(ParenOpenID, InviteMsg(userInfo.NickName,count));
                }
                if (count == 2)
                {
                    System.Threading.Thread.Sleep(1000 * 2);
                    SendText(ParenOpenID, SendGoods());
                }
            });
        }

        public async void BuyGoods(string OpenID)
        {
            LogHelper.Write("BuyGoods：1111");
            await Task.Run(()=> {
                LogHelper.Write("BuyGoods：22222");
                SendText(OpenID, SendGoods());
                inviteBll.BuyUpd(OpenID);
                userInfoBll.Update(OpenID);
            });
        } 

        private string InviteMsg(string NickName,long count)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(NickName+"  通过您的邀请已加入!");
            if(count<2)
                sb.AppendLine("加油！再邀请1个小伙伴，【免费】获得资料。");
            return sb.ToString();
        }

        private string EndMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("本次活动您已【免费】获得资料。下次活动正在准备，敬请期待!");
            return sb.ToString();
        }

        private string TwoMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("将下面的邀请卡转发到微信群或朋友圈，1个小伙伴扫码关注后，会【免费】获得资料。");
            sb.AppendLine("【土豪通道】不方便转发的同学可以<a href='http://www.zy168.shop/Wx/wx.aspx?type=2'>点击这里付费</a>即可直接查看资料。");
            return sb.ToString();
        }

        private string FirstMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("赠送《懒人健身法 每周两小时 在家就能练出好身材 刘洹健身教程》<a href='http://www.qq.com'>点击这里</a>查看详情。");
            sb.AppendLine("【免费方法】将下面的邀请卡转发到微信群或朋友圈，2个小伙伴扫码关注后，会自动弹出资料链接。");
            sb.AppendLine("【土豪通道】不方便转发的同学可以<a href='http://www.zy168.shop/Wx/wx.aspx?type=2'>点击这里付费</a>即可直接查看资料。");
            return sb.ToString();
        }

        private string SendGoods()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("恭喜您，网盘资料：");
            sb.AppendLine("链接：https://pan.baidu.com/s/1KkdAPKOSdQeNynxzMw0okQ 密码：j9fv");
            sb.AppendLine("【请妥善保管链接只发一次，分享转发失效!!】");
            return sb.ToString();
        }

        private void SendText(string OpenID,string content)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Msg_Send_Url, WxConfig.Access_Token);
            string json = "{\"touser\":\""+OpenID+"\", \"msgtype\":\"text\",\"text\":{\"content\":\""+ content + "\"}}";
            string res =  HttpHelper.Post(url, json);
            LogHelper.Write("SendText："+json+  res);
        }

        private void SendImg(string OpenID, string media_id)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Msg_Send_Url, WxConfig.Access_Token);
            string json = "{\"touser\":\"+OpenID+\", \"msgtype\":\"image\",\"image\":{\"media_id\":\"" + media_id + "\"}}";
            HttpHelper.Post(url, json);
        }
    }
}
