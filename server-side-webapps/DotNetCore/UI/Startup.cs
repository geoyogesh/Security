using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(options => new CookieAuthenticationOptions
            {
                //AuthenticationScheme = "Cookies", // Removed in 2.0
                ExpireTimeSpan = TimeSpan.FromHours(12),
                SlidingExpiration = false,
                Cookie = new CookieBuilder
                {
                    Path = "mypath",
                    Name = "MyCookie"
                }
            })
                .AddOpenIdConnect(options => 
                {
                    options.ClientId = "asp.netcore_webapp";
                    options.ClientSecret = "secret";
                    options.Authority = "http://localhost:53382/";
                    options.MetadataAddress = "http://localhost:53382/.well-known/openid-configuration";
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SignInScheme = "Cookies";
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.SaveTokens = true;

                    //options.CallbackPath = new PathString("...")
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        // This sets the value of User.Identity.Name to users AD username
                        // NameClaimType = IdentityClaimTypes.WindowsAccountName,
                        // RoleClaimType = IdentityClaimTypes.Role,
                        AuthenticationType = "Cookies",
                        ValidateIssuer = false
                    };

                    // Scopes needed by application
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.RequireHttpsMetadata = false;

                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
