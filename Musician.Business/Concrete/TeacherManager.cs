using Musician.Business.Abstract;
using Musician.Data.Abstract;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private  ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherRepository.CreateAsync(teacher);
        }

        public async Task DeleteAsync(Teacher teacher)
        {
           await _teacherRepository.DeleteAsync(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync(); 
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllTeachersAsync();
        }

        public Task<Teacher> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Teacher> GetTeacherByIdAsync(string id)
        {
            return await _teacherRepository.GetTeacherByIdAsync(id);

        }

        public async Task<Teacher> GetTeacherByCardId(int id)
        {
            return await _teacherRepository.GetTeacherByCardId(id);
        }
    }
}
