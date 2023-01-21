using System.Threading.Tasks;

namespace SoftDeleted.Model
{
    public interface IRepository
    {
        public Task<Employee> Create(Employee employee);
        Task Delete(int id);
    }
}
