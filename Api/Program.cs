var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.WithOrigins("http://localhost:3000") 
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
app.UseCors("AllowReact");
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
