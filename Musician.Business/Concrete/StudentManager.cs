using Musician.Business.Abstract;
using Musician.Data.Abstract;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public async Task DeleteAsync(Student student)
        {
           await _studentRepository.DeleteAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
          return  await _studentRepository.GetAllAsync();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
       
    }
}
