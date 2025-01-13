using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Repositories;
using Invitation_Card_Maker.Services;

namespace Invitation_Card_Maker.Infrastructure
{
    public class ServiceConfiguration
    {
            public static void Register(IServiceCollection services)
             {
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<CategoryService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<AuthService>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<TemplateService>();
            services.AddScoped<IUserTemplateRepository, UserTemplateRepository>();
            services.AddScoped<UserTemplateService>();
            services.AddScoped<ICustomTemplatesRepository, CustomTemplateRepository>();
            services.AddScoped<CustomTemplateService>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<RoleService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ITemplateUserImagesRepository, TemplateUserImagesRepository>();
            services.AddScoped<ITemplateTextBoxRepository, TemplateTextBoxRepository>();
            services.AddScoped<IStickerRepository, StickerRepository>();
            services.AddScoped<StickerService>();
            services.AddScoped<ITemplateStickerRepository,TemplateStickerRepository>();



        }
    }
}
