using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationStateRepository : IAsyncRepository<ApplicationState, short>, IRepository<ApplicationState, short>
{
}