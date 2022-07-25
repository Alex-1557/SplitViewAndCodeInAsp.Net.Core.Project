Imports FrontEnd.Data
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Identity
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.FileProviders
Imports Microsoft.Extensions.Hosting

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)
        'Add services to the container.
        Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        builder.Services.AddDbContext(Of ApplicationDbContext)(Function(options) options.UseSqlServer(connectionString))
        builder.Services.AddDatabaseDeveloperPageExceptionFilter()
        builder.Services.AddDefaultIdentity(Of IdentityUser)(Function(options) options.SignIn.RequireConfirmedAccount = True).
        AddEntityFrameworkStores(Of ApplicationDbContext)()
        builder.Services.AddControllersWithViews()
        Dim app = builder.Build()

        'Configure the HTTP request pipeline.
        If app.Environment.IsDevelopment() Then
            'The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseMigrationsEndPoint()
        Else
            app.UseExceptionHandler("/Home/Error")
            app.UseHsts()
        End If

        app.UseHttpsRedirection()
        app.UseStaticFiles(New StaticFileOptions With {.FileProvider = New PhysicalFileProvider(builder.Configuration("StaticFilesRoot"))})
        app.UseRouting()
        app.UseAuthentication()
        app.UseAuthorization()
        app.MapControllerRoute(name:="default", pattern:="{controller=Home}/{action=Index}/{id?}")
        app.MapRazorPages()
        app.Run()

    End Sub
End Module
