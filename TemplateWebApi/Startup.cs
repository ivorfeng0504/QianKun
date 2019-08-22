using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TemplateWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "QianKun API",
                    Description = "太极生两仪，两仪生四象",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Sayook",
                        Email = "sayook@qq.com",
                        Url = "www.baidu.com"
                    },
                    License = new License
                    {
                        Name = "许可证名字",
                        Url = "http://www.cnblogs.com/yilezhu/"
                    }
                });
                //获取应用程序所在目录
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                // 添加接口注释
                c.IncludeXmlComments(Path.Combine(basePath, "TemplateWebApi.xml"), true);
                // 添加model注释
                c.IncludeXmlComments(Path.Combine(basePath, "QianKunModel.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QunKun API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}