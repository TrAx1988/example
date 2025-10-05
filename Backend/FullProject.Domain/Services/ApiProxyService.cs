namespace FullProject.Domain.Services
{
    public interface IApiProxyService
    {
        ValueTask<object?> Test();
    }
}
