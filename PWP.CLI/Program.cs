using MudBlazor.Services;
using PWPCli.Shared;

namespace PWP.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();



            builder.Services.AddScoped<IScrollInfoService, ScrollInfoService>();

            builder.Services.AddMudServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            //sección de redirección a página 404
            app.UseStatusCodePages(async context => {
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    context.HttpContext.Response.Redirect("/404");
                }
            });

            app.MapBlazorHub();
            app.MapFallbackToPage("/404notfound");

            app.Run();
        }
    }
}