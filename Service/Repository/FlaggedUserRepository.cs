﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public class FlaggedUserRepository : Repository<Entities.FlaggedUser>
    {
        public FlaggedUserRepository() { }
        public FlaggedUserRepository(ContextEntities context) : base(context)
        {

            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}