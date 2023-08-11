// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using eShopOnContainers.CodeGenerator.Artifacts;
using eShopOnContainers.CodeGenerator.Artifacts.Files;
using eShopOnContainers.CodeGenerator.Domain;
using eShopOnContainers.CodeGenerator.Services;
using eShopOnContainers.CodeGenerator.Syntax;
using System.IO.Abstractions;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCodeGeneratorServices(this IServiceCollection services, Action<CodeGeneratorOptions> configure)
    {
        services.Configure(configure);
        services.AddSingleton<IDomainModelParser, DomainModelParser>();
        services.AddSingleton<IArtifactGenerator, ArtifactGenerator>();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddSingleton<IFileFactory, FileFactory>();
        services.AddSingleton<ITemplateProcessor, RazorTemplateProcessor>();
        services.AddSingleton<ITemplateLocator, TemplateLocator>();
        services.AddSingleton<ICommandService, CommandService>();
        services.AddSingleton<ISyntaxGenerator, SyntaxGenerator>();
        services.AddSingleton(typeof(ISyntaxGenerationStrategy<>), typeof(DomainModel).Assembly);
        services.AddSingleton(typeof(IArtifactGenerationStrategy<>), typeof(DomainModel).Assembly);
    }

    public static void AddSingleton(this IServiceCollection services, Type @interface, Assembly assembly)
    {
        var implementations = assembly.GetTypes()
            .Where(type =>
                !type.IsAbstract &&
                type.GetInterfaces().Any(interfaceType =>
                    interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == @interface
                )
            )
            .ToList();

        foreach (var implementation in implementations)
        {
            foreach (var implementedInterface in implementation.GetInterfaces())
            {
                if (implementedInterface.IsGenericType && implementedInterface.GetGenericTypeDefinition() == @interface)
                {
                    services.AddSingleton(implementedInterface, implementation);
                }
            }
        }
    }

}
