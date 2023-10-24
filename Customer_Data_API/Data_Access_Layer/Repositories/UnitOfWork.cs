using AutoMapper;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public IAdminRepository AdminRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            AdminRepository = new AdminRepository(_db, _mapper);
            UserRepository = new UserRepository(_db, _mapper);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
