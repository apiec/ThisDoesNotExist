using ThisDoesNotExist;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IImageGenerator, ImageGenerator>();
builder.Services.AddSingleton<IPage, MainPage>();
builder.Services.AddSingleton<IRequestTracker, RequestTracker>();

builder.Services.AddHostedService<ImageGeneratorRunner>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseMiddleware<RequestTrackingMiddleware>();
app.MapGet("/", (IPage page) => Results.Extensions.Html(page.Content));

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.Run();
