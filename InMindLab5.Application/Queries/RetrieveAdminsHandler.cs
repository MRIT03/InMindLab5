using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace InMindLab5.Application.Queries;

public class RetrieveAdminsHandler : IRequestHandler<RetrieveAdminsQuery, List<AdminDto>>
{
    private readonly IRepository<Admin> _repository;

    public RetrieveAdminsHandler(IRepository<Admin> repository)
    {
        _repository = repository;
    }

    public async Task<List<AdminDto>> Handle(RetrieveAdminsQuery request, CancellationToken cancellationToken)
    {
        var admins = await _repository.GetAllAsync();
        return admins.ToDtoList();
    }
}