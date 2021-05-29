using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;

namespace DAL.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, EfContext>, IProductImageDal
    {
        public bool IsExist(int id)
        {
            using (EfContext context = new EfContext())
            {
                return context.ProductImages.Any(p => p.Id == id);
            }
        }
    }
}
