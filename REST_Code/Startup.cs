namespace REST_Code
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using NSwag;
    using NSwag.SwaggerGeneration.Processors.Security;
    using REST_Code.Data;
    using REST_Code.Data.Repository;
    using REST_Code.Models.IRepository;
    using System;
    using System.Text;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOpenApiDocument(c =>
                {
                    c.DocumentName = "apidocs";
                    c.Title = "Code API";
                    c.Version = "v1";
                    c.Description = "API for the code forum.";
                    c.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token", new SwaggerSecurityScheme
                    {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = SwaggerSecurityApiKeyLocation.Header,
                        Description = "Copy 'Bearer' + valid JWT token into field"
                    }
                    ));
                    c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
                }
            );

            services.AddIdentity<IdentityUser, IdentityRole>(config => config.User.RequireUniqueEmail = true).AddEntityFrameworkStores<CodeContext>();
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true
                    };
                }
            );

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYS0123456789-._@?+";
                    options.User.RequireUniqueEmail = true;
                }
            );
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
            services.AddDbContext<CodeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CodeContext"))
            );

            services.AddScoped<CodeDataInitializer>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CodeDataInitializer codeDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();

            //codeDataInitializer.InitializeDataAsync().Wait();
        }
    }
}
