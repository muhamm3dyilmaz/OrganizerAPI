﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    //Nesnelere özel yazılan Repo InterFacelerin kayıt alanı.
    public interface IRepositoryManager
    {
        Task SaveAsync();
    }
}
