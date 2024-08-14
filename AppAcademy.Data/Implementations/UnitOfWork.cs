﻿using AppAcademy.Core.Repositories;
using AppAcademy.Data.Data;

namespace AppAcademy.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AcademyContext _context;
        public IGroupRepository groupRepository { get; private set; }
        public UnitOfWork(AcademyContext context)
        {
            _context = context;
            groupRepository = new GroupRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
