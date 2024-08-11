using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Core.Entities;

namespace AppAcademy.Application.Services.Interfaces
{
    public interface IGroupService
    {
        int Create(GroupCreateDto groupCreateDto);
        List<Group> GetAll();
    }
}
