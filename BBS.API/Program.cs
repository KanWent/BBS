using BBS.Commom.MEF.Base;

var builder = WebApplication.CreateBuilder(args);
//配置跨域
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myCors", builde =>
    {
        builde.WithOrigins("*", "*", "*")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//添加文档注释
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ManagerAPI", Version = "v1" });
    //添加文档注释
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
    var xmlPath = Path.Combine(basePath, "BBS.API.xml");
    c.IncludeXmlComments(xmlPath);
}
);

var app = builder.Build();

// 开发环境配置
if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI();

//注册MEF，实现依赖注入
InterFaceList.Regisgter();


app.UseAuthorization();
app.MapControllers();
app.UseCors("myCors");

app.Run();
