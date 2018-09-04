using BLL.BLL;
using BLL.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxTest
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                //UserInfoBll bll = new UserInfoBll();
                //var u = bll.GetModel("ozpkJ1MjHFm9f9W_HNCQ3tkRIIts");
                //u.NickName = "田晓东";
                //bll.Update(u);
                //new InviteBll().Poster();
                LogHelper.Write("支付中：---------");
                Console.WriteLine("0000000");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

          
            Console.Read();
        }
    }
}
