using Application.Features.Employees.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Employees.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILocalizationService _localizationService;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository, ILocalizationService localizationService)
    {
        _employeeRepository = employeeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EmployeesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EmployeeShouldExistWhenSelected(Employee? employee)
    {
        if (employee == null)
            await throwBusinessException(EmployeesBusinessMessages.EmployeeNotExists);
    }

    public async Task EmployeeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Employee? employee = await _employeeRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EmployeeShouldExistWhenSelected(employee);
    }
}