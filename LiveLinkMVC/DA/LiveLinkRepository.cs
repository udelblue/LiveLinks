using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

namespace LiveLinkMVC.Models
{
 
       public class LiveLinkRepository : IRepository<LiveLink>, IDisposable
        {

            private LiveLinkContext _context;

            public LiveLinkRepository()
            {
                _context = new LiveLinkContext();
            }

            public LiveLink GetById(int id)
            {
                return _context.LiveLinks.
                    Where(d => d.ID == id).
                    FirstOrDefault();
            }

            public LiveLink[] GetAll()
            {
                return _context.LiveLinks.ToArray();
            }

            public IQueryable<LiveLink> Query(Expression<Func<LiveLink, bool>> filter)
            {
                return _context.LiveLinks.Where(filter);
            }

            public void Dispose()
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
                GC.SuppressFinalize(this);
            }


            public void DeleteById(int id)
            {
               LiveLink link =  _context.LiveLinks.
                   Where(d => d.ID == id).FirstOrDefault();
               _context.LiveLinks.Remove(link);
               _context.SaveChanges();
            }

            public void Update(LiveLink livelink)
            {
               _context.Entry(livelink).State = EntityState.Modified;
               _context.SaveChanges();
            }

            public void Add(LiveLink livelink)
            {
                _context.LiveLinks.Add(livelink);
                _context.SaveChanges();
            }
        }

    }

