﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

   

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id).FirstOrDefault();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
