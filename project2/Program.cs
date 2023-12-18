var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
    //Ошибка!!!
    //InvalidCastException: Cannot write DateTime with Kind=Unspecified to PostgreSQL type 'timestamp with time zone',
    //only UTC is supported. Note that it's not possible to mix DateTimes with different Kinds in an array/range.
    //See the Npgsql.EnableLegacyTimestampBehavior AppContext switch to enable legacy behavior.
    //Решение!!!
    //Настройка Npgsql для использования легаси поведения (не рекомендуется):
    //Как указано в сообщении об ошибке, есть AppContext switch, который можно использовать для включения "легаси" поведения. 
    //Однако, использование легаси поведения не рекомендуется, так как оно может вызвать другие проблемы.
    //Вы можете установить этот переключатель перед использованием Npgsql:

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=IndexNew}/{id?}");


app.Run();
