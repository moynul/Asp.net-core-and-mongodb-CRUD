using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAndCore.Models
{
    public class StudentRepository : IStudentRepository
    {
        MongoDbContext db = new MongoDbContext();
        public async Task Add(Student student)
        {
            try
            {
                await db.Student.InsertOneAsync(student);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Student> data = Builders<Student>.Filter.Eq("Id", id);
                await db.Student.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Student> GetStudent(string id)
        {
            try
            {
                FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("Id", id);
                return await db.Student.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetStudent()
        {
            try
            {
                return await db.Student.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Student student)
        {
            await db.Student.ReplaceOneAsync(filter: g => g.Id == student.Id, replacement: student);
        }
    }
}
