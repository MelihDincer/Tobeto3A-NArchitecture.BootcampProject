using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationStateRepository : EfRepositoryBase<ApplicationState, short, BaseDbContext>, IApplicationStateRepository
{
    public ApplicationStateRepository(BaseDbContext context)
        : base(context) { }
}
