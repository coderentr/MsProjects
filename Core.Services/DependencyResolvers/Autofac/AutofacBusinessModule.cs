using Autofac;
using Core.Infrastructure.Utilities.Security.JwtToken;
using Core.Services.Interfaces;
using Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}
