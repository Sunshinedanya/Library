using ReadersApi.DataBaseContext;

namespace ReadersApi.Services.Interfaces;

public interface IService
{
    public ReadersContext Context { get; }
}