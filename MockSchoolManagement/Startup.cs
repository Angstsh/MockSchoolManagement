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

namespace MockSchoolManagement
{
    public class Startup
    {
        /*若要访问Startup中的配置信息，则需要在其中注入IConfiguration服务，它是由ASP.NET CORE框架提供的*/
        private IConfiguration _configuration;
        //需要先添加一个构造方法，然后将IConfiguration服务注入方法中
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*配置应用程序所需要的服务*/
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /*配置应用程序的请求处理管道*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async(context)=>
            {
                //防止乱码
                context.Response.ContentType = "text/plain;charset=utf-8";
                //注入后通过_configuration访问MyKey
                await context.Response.WriteAsync(_configuration["MyKey"]);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //获取执行应用程序的进程名称
                    var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                    await context.Response.WriteAsync(processName);
                });
            });
        }
    }
}
