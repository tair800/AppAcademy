using AppAcademy.Application.Dtos.StudentDtos;
using AppAcademy.Application.Exceptions;
using AppAcademy.Application.Services.Interfaces;
using AppAcademy.Core.Entities;
using AppAcademy.Data.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppAcademy.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly AcademyContext _context;
        private readonly IMapper _mapper;


        public StudentService(AcademyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(StudentCreateDto studentCreateDto)
        {
            var group = _context.Groups
                .Include("Students")
                .FirstOrDefault(g => g.Id == studentCreateDto.GroupId);

            if (group is null)
                throw new NotFoundEntityException("Given GroupId doesnt exist");

            if (group.Students.Count() >= group.Limit)
                throw new LimitEntityException("Limit is reached in group");

            var student = _mapper.Map<Student>(studentCreateDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            return student.Id;

        }
    }
}
