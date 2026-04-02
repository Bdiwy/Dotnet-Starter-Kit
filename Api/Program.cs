var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.WithOrigins("http://localhost:3000") 
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
app.UseExceptionHandler("/error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowReact");
app.UseDefaultFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
// custom middlware here 
app.Run();
