using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using tusdotnet;
using tusdotnet.Interfaces;
using tusdotnet.Models;
using tusdotnet.Models.Configuration;
using tusdotnet.Stores;
using System.IO;

namespace ElixrMarket.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IWebHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ElixrDataContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ElixrUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ElixrDataContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Identity/Account/Login";
            });

            services.AddRazorPages()
                .ConfigureApiBehaviorOptions(options => {
                        options.InvalidModelStateResponseFactory = context => {
                            return new BadRequestObjectResult(context.ModelState);
                        };
                    });
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => {
                    options.InvalidModelStateResponseFactory = context => {
                        return new BadRequestObjectResult(context.ModelState);
                    };
                });

            services.AddScoped<IProductsService, EFCoreProductsService>();
            services.AddScoped<IEditorService, EFCoreEditorService>();
            services.AddScoped<DbSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(ElixrDataContext dbContext, IServiceProvider services, IApplicationBuilder app, IWebHostEnvironment env)
        {
            Environment = env;

            var seeder = services.GetRequiredService<DbSeeder>();

            // seed roles
            services.GetRequiredService<DbSeeder>().SeedRoles();
            services.GetRequiredService<DbSeeder>().SeedAdmin();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                seeder.SeedDevUsers();
                seeder.SeedProducts();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseTus(httpContext => new DefaultTusConfiguration {
                // TODO: add env variable for this
                Store = new TusDiskStore("/home/chase/tusfiles/"),
                UrlPath = "/binfiles",
                Events = new Events {
                    OnAuthorizeAsync = async eventContext => {
                        var user = (await eventContext.HttpContext.AuthenticateAsync()).Principal;

                        if (!user.Identity.IsAuthenticated)
                        {
                            eventContext.FailRequest(System.Net.HttpStatusCode.Unauthorized);
                            return;
                        }
                        if (!user.IsInRole("Developer"))
                        {
                            eventContext.FailRequest(System.Net.HttpStatusCode.Forbidden, "Only developers can upload.");
                            return;
                        }
                    },
                    OnFileCompleteAsync = async eventContext => {
                        var file = await eventContext.GetFileAsync();
                        if (file != null)
                        {
                            
                            var metadata = await file.GetMetadataAsync(eventContext.CancellationToken);
                            var productName = metadata["productName"].GetString(System.Text.Encoding.UTF8);
                            var productId = Convert.ToInt32(metadata["productId"].GetString(System.Text.Encoding.UTF8));
                            var fileType = metadata["filetype"].GetString(System.Text.Encoding.UTF8);

                            var fileLocation = env.WebRootPath + $@"/product-files/{productId}/bin/{productName}_installer";
                            using (var stream = await file.GetContentAsync(eventContext.CancellationToken))
                            {
                                using (var fileStream = File.Create(fileLocation))
                                {
                                    stream.Seek(0, SeekOrigin.Begin);
                                    await stream.CopyToAsync(fileStream);
                                    
                                }
                            }

                            // delete file from tusstore
                            var terminationStore = (ITusTerminationStore)eventContext.Store;
                            await terminationStore.DeleteFileAsync(file.Id, eventContext.CancellationToken);
                        }
                    }
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
