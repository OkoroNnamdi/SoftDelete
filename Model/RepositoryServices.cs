using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftDeleted.DAL;


namespace SoftDeleted.Model
{
    public class RepositoryServices : IRepository

    {
        private readonly IRepository _repository;
        public readonly AppDbContext _appDbContext;
        public RepositoryServices(IRepository repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        public async Task<Employee> Create(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;

            ;
        }

        public async Task Delete(int id)
        {
            var Employee = _appDbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (Employee != null)
            {
                _appDbContext.Employees.Remove(Employee);
                _appDbContext.SaveChanges();
            }
        }
    }
}
