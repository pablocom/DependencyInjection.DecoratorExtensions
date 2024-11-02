namespace DependencyInjection.DecoratorExtensions.DecorationStrategies;

internal abstract class DecorationStrategy(Type decoratedType)
{
    public Type TargetDecoratedType { get; } = decoratedType;

    public abstract bool CanDecorate(Type type);
    public abstract Func<IServiceProvider, object> CreateImplementationFactory(DecoratedTypeProxy decoratedType);
}