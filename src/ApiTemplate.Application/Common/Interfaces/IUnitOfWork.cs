namespace ApiTemplate.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync();
}
