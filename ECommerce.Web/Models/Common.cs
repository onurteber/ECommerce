using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class HeaderModel
    {
        public HeaderModel()
        {
            CustomProperties = new Dictionary<string, dynamic>();
        }
        public string Logo { get; set; }
        public int LogoWidth { get; set; }
        public int LogoHeight { get; set; }
        public string CouponText { get; set; }
        public string CouponLink { get; set; }
        public DateTime CouponEndDate { get; set; }
        public Dictionary<string,dynamic> CustomProperties { get; set; }

        public int BaketsCount { get; set; }
    }

    public class FooterModel
    {

        public FooterModel()
        {
            SocialMedia = new Dictionary<string, string>();
        }

        public string Logo { get; set; }
        public int LogoWidth { get; set; }
        public int LogoHeight { get; set; }
        public Dictionary<string, string> SocialMedia { get; set; }
    }

}