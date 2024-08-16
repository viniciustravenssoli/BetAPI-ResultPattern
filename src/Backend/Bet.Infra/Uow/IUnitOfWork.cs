namespace Bet.Infra.Uow;
public interface IUnitOfWork
{
    Task Commit();
}
