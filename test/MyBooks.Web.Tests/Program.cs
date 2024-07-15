using Microsoft.AspNetCore.Builder;
using MyBooks;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<MyBooksWebTestModule>();

public partial class Program
{
}
