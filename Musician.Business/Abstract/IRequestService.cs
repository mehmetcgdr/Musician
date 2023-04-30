﻿using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface IRequestService
    {
        Task CreateAsync(Request request);
        Task<Request> GetByIdAsync(int id);
        Task<List<Request>> GetAllAsync();
        void Update(Request request);
        Task DeleteAsync(Request request);
    }
}
