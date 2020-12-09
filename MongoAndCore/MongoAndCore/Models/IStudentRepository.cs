using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAndCore.Models
{
    public interface IStudentRepository
    {
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(string id);
        Task<Student> GetStudent(string id);
        Task<IEnumerable<Student>> GetStudent();
    }
}
