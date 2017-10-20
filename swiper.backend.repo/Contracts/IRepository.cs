﻿using ch.cena.swiper.backend.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.repo.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
