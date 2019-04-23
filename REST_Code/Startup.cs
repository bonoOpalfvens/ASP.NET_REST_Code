namespace REST_Code
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NSwag;
    using NSwag.SwaggerGeneration.Processors.Security;
    using REST_Code.Data;
    using REST_Code.Data.Repository;
    using REST_Code.Models.IRepository;

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
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
            services.AddDbContext<CodeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CodeContext"))
            );

            services.AddScoped<CodeDataInitializer>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseCors("AllowAllOrigins");

            codeDataInitializer.InitializeData();
        }
    }
}
