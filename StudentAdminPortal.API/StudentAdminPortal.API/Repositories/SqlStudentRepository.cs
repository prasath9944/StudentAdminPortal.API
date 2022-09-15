using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        public readonly StudentAdminContext Context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            Context = context;
        }

        

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await Context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        
    }
}
