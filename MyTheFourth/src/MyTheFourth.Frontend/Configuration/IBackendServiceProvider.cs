using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Configuration;

public interface IBackendServiceProvider
{
    IMyTheFourthService? Current { get; }
    void SetServiceId(string serviceId);
    void SetDefault();


}