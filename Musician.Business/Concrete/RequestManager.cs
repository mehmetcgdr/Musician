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
    public class RequestManager : IRequestService
    {
        private IRequestRepository _requestRepository;

        public RequestManager(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task CreateAsync(Request request)
        {
             await _requestRepository.CreateAsync(request);
        }

        public async Task DeleteAsync(Request request)
        {
           await _requestRepository.DeleteAsync(request);
        }

        public async Task<List<Request>> GetAllAsync()
        {
            return await _requestRepository.GetAllAsync();
        }

        public async Task<Request> GetByIdAsync(int id)
        {
          return await _requestRepository.GetByIdAsync(id);
        }

        public async Task<List<Request>> GetRequestsByStudentAsync(string id)
        {
            return await _requestRepository.GetRequestsByStudentAsync(id);
        }

        public async Task<List<Request>> GetRequestsByTeacherAsync(int id)
        {
            return await _requestRepository.GetRequestsByTeacherAsync(id);
        }

        public void Update(Request request)
        {
            _requestRepository.Update(request);
        }
        public async Task<List<Request>> GetRequestsInAdminAsync()
        {
            return await _requestRepository.GetRequestsInAdminAsync();
        }
    }
}
