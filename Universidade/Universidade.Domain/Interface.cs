using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidade.Domain
{
    public interface IProfessorRepository
    {
        Task<Professor> GetByIdAsync(int id);
        Task<IEnumerable<Professor>> GetAllAsync();
        Task AddAsync(Professor professor);
        void Update(Professor professor);
        void Delete(Professor professor);
    }
}
