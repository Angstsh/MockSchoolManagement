using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MockSchoolManagement
{
    public class Startup
    {
        /*配置应用程序所需要的服务*/
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(a=>a.EnableEndpointRouting=false);
            services.AddControllersWithViews(a=>a.EnableEndpointRouting=false);
        }

        /*配置应用程序的请求处理管道*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //使用纯静态文件支持的中间件，而不使用终端中间件
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.Run(async(context)=>
            {
                //返回当前的环境变量
                await context.Response.WriteAsync("Hosting Environment:"+env.EnvironmentName);
            });
        }
    }
}
