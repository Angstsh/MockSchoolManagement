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
            //services.AddMvc(a=>a.EnableEndpointRouting=false);
            services.AddControllersWithViews(a=>a.EnableEndpointRouting=false);
        }

        /*����Ӧ�ó����������ܵ�*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ʹ�ô���̬�ļ�֧�ֵ��м��������ʹ���ն��м��
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.Run(async(context)=>
            {
                //���ص�ǰ�Ļ�������
                await context.Response.WriteAsync("Hosting Environment:"+env.EnvironmentName);
            });
        }
    }
}
