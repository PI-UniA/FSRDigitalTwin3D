namespace FSR.DigitalTwin.API;

using FSR.DigitalTwin.App.GRPC.Common.Utils;
using IO.Swagger.Lib.V3.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public interface IApiAdapter {
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    static IApiAdapter CreateDefaultAdapter() => new DefaultApiAdapter();
}

internal class DefaultApiAdapter : IApiAdapter
{
    private const string CORS_POLICY_NAME = "AllowALl";
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
        else app.UseExceptionHandler("/Error");
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors(CORS_POLICY_NAME);
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("Final-Draft/swagger.json", "DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", () => "*** Welcome to FORSocialRobots Digital Twin Framework! ***");
            endpoints.MapAppGrpcServices();
        });
    }
}