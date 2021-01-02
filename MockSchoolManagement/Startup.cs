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
        /*����Ӧ�ó�������Ҫ�ķ���*/
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /*����Ӧ�ó����������ܵ�*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            app.Use(async(context,next)=>
            {
                logger.LogInformation("MW1:��������");
                await next();
                logger.LogInformation("MW1:������Ӧ");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2:��������");
                await next();
                logger.LogInformation("MW2:������Ӧ");
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType="text/plain;charset=utf-8";
                await context.Response.WriteAsync("MW3: ��������������Ӧ");
                logger.LogInformation("MW3: ��������������Ӧ");
            });
        }
    }
}
