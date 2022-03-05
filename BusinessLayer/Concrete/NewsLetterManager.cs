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

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLatterDal.Insert(newsLetter);
        }
    }
}
