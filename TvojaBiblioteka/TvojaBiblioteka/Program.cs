using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TvojaBiblioteka.Persistence.DbContext;
using TvojaBiblioteka.Services;

namespace TvojaBiblioteka
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var form1 = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(form1);
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            // Main form
            services.AddSingleton<LoginForm>();

            services.AddSingleton<CurrentUser>();
        }
    }
}
