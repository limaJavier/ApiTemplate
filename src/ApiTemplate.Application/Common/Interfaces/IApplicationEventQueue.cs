namespace ApiTemplate.Application.Common.Interfaces;

public interface IApplicationEventQueue
{
    Task PushAsync(IApplicationEvent applicationEvent);
}
