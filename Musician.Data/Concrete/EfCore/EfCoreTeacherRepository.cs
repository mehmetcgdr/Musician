﻿using Microsoft.EntityFrameworkCore;
using Musician.Data.Abstract;
using Musician.Data.Concrete.EfCore.Context;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
           List<Teacher> teachers = await AppContext.Teachers.ToListAsync();
            return teachers;
        }
    }
}
