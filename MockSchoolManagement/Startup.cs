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
        }

        /*配置应用程序的请求处理管道*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            app.Use(async(context,next)=>
            {
                logger.LogInformation("MW1:传入请求");
                await next();
                logger.LogInformation("MW1:传出响应");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2:传入请求");
                await next();
                logger.LogInformation("MW2:传出响应");
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType="text/plain;charset=utf-8";
                await context.Response.WriteAsync("MW3: 处理请求并生成响应");
                logger.LogInformation("MW3: 处理请求并生成响应");
            });
        }
    }
}
