using Student.Entity.Student;

namespace Student.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        public IBaseRepository<Entity.Student.Student?, int> StudentRepository { get; set; }
        public IBaseRepository<Family?, int> FamilyRepository { get; set; }
        public IBaseRepository<Guardian?, int> GuardianRepository { get; set; }
        public IBaseRepository<GuardianType?, int> GuardianTypeRepository { get; set; }
        public IBaseRepository<Address?, int> AddressRepository { get; set; }

        public Task Commit();
    }
}