

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common;
using Main.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models;
using Services;

namespace Main
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ReadPolicy", policy => policy.Requirements.Add(new AuthPolicyRequirement(UserRoleType.Default)));
                options.AddPolicy("AdminPolicy", policy => policy.Requirements.Add(new AuthPolicyRequirement(UserRoleType.Admin)));
            });

            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddWebSocketManager();
            

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, AuthPolicyHandler>();
            services.AddScoped<ILoginService, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DataContext ctx, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseWebSockets();

            //app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
                LoginPath = "/Account/Login",
                AccessDeniedPath = "/Account/Login",
                LogoutPath ="/Account/Logout",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                CookieSecure = CookieSecurePolicy.SameAsRequest,
                //CookiePath = "/",
                CookieHttpOnly = true,
                SlidingExpiration = true,
                CookieName = "rrAuth",
            });

            app.UseClaimsTransformation(context =>
            {
                if (context.Principal.Identity.IsAuthenticated)
                {
                    context.Principal.Identities.First().AddClaim(new Claim("now", DateTime.Now.ToString()));
                }

                return Task.FromResult(context.Principal);
            });



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapWebSocketManager("/notifications", serviceProvider.GetService<NotificationsMessageHandler>());

            SeedData.Initialize(ctx);
        }
    }
}
