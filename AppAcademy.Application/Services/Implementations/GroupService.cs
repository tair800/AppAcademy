using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Exceptions;
using AppAcademy.Application.Services.Interfaces;
using AppAcademy.Core.Entities;
using AppAcademy.Data.Data;
using AutoMapper;

namespace AppAcademy.Application.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly AcademyContext _context;
        private readonly IMapper _mapper;

        public GroupService(AcademyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(GroupCreateDto groupCreateDto)
        {
            if (_context.Groups.Any(g => g.Name.ToLower() == groupCreateDto.Name.ToLower()))
                throw new DublicateEntityException("Dublicate entity");

            var group = _mapper.Map<Group>(groupCreateDto);
            _context.Groups.Add(group);
            _context.SaveChanges();

            return group.Id;

        }

        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }
    }
}
