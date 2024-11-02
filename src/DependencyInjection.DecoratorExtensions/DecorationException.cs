namespace DependencyInjection.DecoratorExtensions;

public class DecorationException(Type serviceType)
    : InvalidOperationException($"Could not find any registered service to decorate for type '{serviceType.FullName}'.")
{
    public Type ServiceType { get; } = serviceType;
}