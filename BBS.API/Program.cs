using BBS.Commom.MEF.Base;

var builder = WebApplication.CreateBuilder(args);
//���ÿ���
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
//����ĵ�ע��
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ManagerAPI", Version = "v1" });
    //����ĵ�ע��
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
    var xmlPath = Path.Combine(basePath, "BBS.API.xml");
    c.IncludeXmlComments(xmlPath);
}
);

var app = builder.Build();

// ������������
if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI();

//ע��MEF��ʵ������ע��
InterFaceList.Regisgter();


app.UseAuthorization();
app.MapControllers();
app.UseCors("myCors");

app.Run();
