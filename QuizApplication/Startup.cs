using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Quiz.Core.Data;
using Quiz.Core.IRepositories;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Mappers;
using Quiz.Domain.Models.Authorization;
using Quiz.Domain.Services;
using Quiz.Infrastructure.Repositories;
using Quiz.Infrastructure.UoW;

namespace QuizApplication
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
            services.AddDbContext<QuizContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("QuizConnection")));
            services.AddSingleton<HttpContextAccessor>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStatisticService, StatisticService>();

            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IQAUnitOfWork, QAUnitOfWork>();

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMapper());
                mc.AddProfile(new TopicMapper());
                mc.AddProfile(new QuestionMapper());
                mc.AddProfile(new AnswerMapper());
                mc.AddProfile(new StatisticMapper());
            })
            .CreateMapper()
            );

            var authOptions = Configuration.GetSection("AuthOptions").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = authOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(authOptions.KEY),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddControllers();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/client-app";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            // Code omitted for brevity

            app.UseAuthentication();
            app.UseAuthorization();

            // Code omitted for brevity

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
