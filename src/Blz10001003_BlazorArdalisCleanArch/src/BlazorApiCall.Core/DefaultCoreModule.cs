using Autofac;
using BlazorApiCall.Core.Interfaces;
using BlazorApiCall.Core.Services;

namespace BlazorApiCall.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
