using Microsoft.Extensions.DependencyInjection;
using Ecommerce.models;
using Ecommerce.repositories;
using Ecommerce.repositories.interfaces;
using Ecommerce.services.interfaces;
using Ecommerce.services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Ecommerce.controllers
{
    public static class ServiceExtenstions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<ecommerceContext>, UnitOfWork>();

            #region Product
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ProductRepository>();
            #endregion

            #region Category
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryRepository>();
            #endregion

            #region Order
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<OrderRepository>();
            #endregion

            #region User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserRepository>();
            #endregion
        }

        public static void AddAuth(this IServiceCollection services){
             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                var validations = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidAudience = "EcommerceServicePostmanClient",
                    ValidIssuer = "EcommerceAuthenticationServer",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsjdbf78sdyfssdfsdfbuidfs98gdfsdbf"))
                };
                options.TokenValidationParameters = validations;
            });
        }
    }
}