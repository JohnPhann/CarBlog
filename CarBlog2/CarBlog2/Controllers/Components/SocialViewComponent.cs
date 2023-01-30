using Microsoft.AspNetCore.Mvc;
using CarBlog2.Enum;
using CarBlog2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using CarBlog2.ModelView;
using Microsoft.Extensions.Configuration;

namespace CarBlog2.Controllers.Components
{
    public class SocialViewComponent : ViewComponent
    {
        private readonly IConfiguration _config;
        private IMemoryCache _memoryCache;
        public SocialViewComponent(IConfiguration config, IMemoryCache memoryCache)
        {
            _config = config;
            _memoryCache = memoryCache;


        }

        public IViewComponentResult Invoke()
        {
            var _social = _memoryCache.GetOrCreate(CacheKeys.Social, entry =>
            {
                entry.SlidingExpiration = TimeSpan.MaxValue;
                return GetlsSocials();


            });
            return View(_social);


        }

        public SocailVM GetlsSocials(){

            SocailVM socialVM = new SocailVM();
            socialVM.Facebook = _config.GetValue<string>("SocialLinks:facebook");
            socialVM.Twitter = _config.GetValue<string>("SocialLinks:Twitter");
            socialVM.Instagram = _config.GetValue<string>("SocialLinks:Instagram");
            socialVM.Youtube = _config.GetValue<string>("SocialLinks:Youtube");

            return socialVM;


        }           
    }




}

