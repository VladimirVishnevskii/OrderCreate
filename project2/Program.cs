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
    //������!!!
    //InvalidCastException: Cannot write DateTime with Kind=Unspecified to PostgreSQL type 'timestamp with time zone',
    //only UTC is supported. Note that it's not possible to mix DateTimes with different Kinds in an array/range.
    //See the Npgsql.EnableLegacyTimestampBehavior AppContext switch to enable legacy behavior.
    //�������!!!
    //��������� Npgsql ��� ������������� ������ ��������� (�� �������������):
    //��� ������� � ��������� �� ������, ���� AppContext switch, ������� ����� ������������ ��� ��������� "������" ���������. 
    //������, ������������� ������ ��������� �� �������������, ��� ��� ��� ����� ������� ������ ��������.
    //�� ������ ���������� ���� ������������� ����� �������������� Npgsql:

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=IndexNew}/{id?}");


app.Run();
