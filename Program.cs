using BlazorChatApp;
using BlazorChatApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddSignalR();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.UseRouting();
app.UseAntiforgery();

// middleware pipeline to direct incoming HTTP requests to the appropriate Razor Page based on the URL and routing rules defined in your project.
app.MapRazorPages();
//map a SignalR hub to a specific endpoint in your application. 
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
