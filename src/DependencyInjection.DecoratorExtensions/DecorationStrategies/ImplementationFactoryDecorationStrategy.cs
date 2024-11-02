using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.DecoratorExtensions.DecorationStrategies;

internal class ImplementationFactoryDecorationStrategy(
    Type decoratedType,
    Func<object, IServiceProvider, object> decoratorFactory)
    : DecorationStrategy(decoratedType)

{
    public override bool CanDecorate(Type type) => type == TargetDecoratedType;

    public override Func<IServiceProvider, object> CreateImplementationFactory(DecoratedTypeProxy decoratedType)
    {
        return serviceProvider =>
        {
            var decoratedTypeInstance = serviceProvider.GetRequiredService(decoratedType);
            return decoratorFactory(decoratedTypeInstance, serviceProvider);
        };
    }
}