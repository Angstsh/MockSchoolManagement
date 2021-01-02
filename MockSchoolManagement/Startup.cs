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
        /*��Ҫ����Startup�е�������Ϣ������Ҫ������ע��IConfiguration����������ASP.NET CORE����ṩ��*/
        private IConfiguration _configuration;
        //��Ҫ�����һ�����췽����Ȼ��IConfiguration����ע�뷽����
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*����Ӧ�ó�������Ҫ�ķ���*/
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /*����Ӧ�ó����������ܵ�*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async(context)=>
            {
                //��ֹ����
                context.Response.ContentType = "text/plain;charset=utf-8";
                //ע���ͨ��_configuration����MyKey
                await context.Response.WriteAsync(_configuration["MyKey"]);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //��ȡִ��Ӧ�ó���Ľ�������
                    var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                    await context.Response.WriteAsync(processName);
                });
            });
        }
    }
}
