using BLL.BLL;
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
            new UserInfoBll().UserCheckAdd("5cfa2fc3-e198-4d75-8cce-f8317a49761d");
            Console.Read();
        }
    }
}
