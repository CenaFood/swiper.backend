using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service
{
    static class RandomLinqExtensionMethods
    {
        public static IQueryable<T> OrderByRandom<T>(this IQueryable<T> query)
        {
            return (from q in query
                    orderby Guid.NewGuid()
                    select q);
        }
    }
}
