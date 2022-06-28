using System;
using Services.Interface;
using SqlModels.Repository;
using SqlModels.Repository.Interface;
using SqlModels.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ForumService : GenericService<Forum>
    {
        public ForumService(DbContext context) : base(context)
        {
        }
    }
}