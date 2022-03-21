using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLatterDal;

        public NewsLetterManager(INewsLetterDal newsLatterDal)
        {
            _newsLatterDal = newsLatterDal;
        }

        public List<NewsLetter> GetList()
        {
           return _newsLatterDal.GetListAll();
        }

        public void TAdd(NewsLetter t)
        {
            _newsLatterDal.Insert(t);
        }

        public void TDelete(NewsLetter t)
        {
            throw new NotImplementedException();
        }

        public NewsLetter TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(NewsLetter t)
        {
            throw new NotImplementedException();
        }
    }
}
