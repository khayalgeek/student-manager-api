using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete.MsSql;
using Student.Entity.Student;

namespace Student.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        // Lazy Loading Repository
        private IBaseRepository<Entity.Student.Student, int> _studentRepository;

        public IBaseRepository<Entity.Student.Student?, int> StudentRepository
        {
            get => RepositoryBuilder<Entity.Student.Student, int>.Builder(_studentRepository, _dbContext);
            set => _studentRepository = value;
        }

        private IBaseRepository<Family, int> _familyRepository;

        public IBaseRepository<Family?, int> FamilyRepository   
        {
            get => RepositoryBuilder<Family, int>.Builder(_familyRepository, _dbContext);
            set => FamilyRepository = value;
        }

        private IBaseRepository<Guardian, int> _guardianRepository;

        public IBaseRepository<Guardian?, int> GuardianRepository
        {
            get => RepositoryBuilder<Guardian, int>.Builder(_guardianRepository, _dbContext);
            set => GuardianRepository = value;
        }

        private IBaseRepository<GuardianType, int> _guardianTypeRepository;

        public IBaseRepository<GuardianType?, int> GuardianTypeRepository
        {
            get => RepositoryBuilder<GuardianType, int>.Builder(_guardianTypeRepository, _dbContext);
            set => GuardianTypeRepository = value;
        }

        private IBaseRepository<Address, int> _addressRepository;

        public IBaseRepository<Address?, int> AddressRepository
        {
            get => RepositoryBuilder<Address, int>.Builder(_addressRepository, _dbContext);
            set => AddressRepository = value;
        }

        private readonly StudentDbContext _dbContext;

        public UnitOfWork(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}