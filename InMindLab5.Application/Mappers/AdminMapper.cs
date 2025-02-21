using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.Mappers;

public static class AdminMapper
{
    public static AdminDto ToDto(this Admin admin)
    {
        return new AdminDto
        {
            Id = admin.AdminId,
            Name = admin.Name,
        };
    }

    public static List<AdminDto> ToDtoList(this List<Admin> admins)
    {
        return admins.Select( a => a.ToDto()).ToList();
    }
}