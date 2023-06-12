using System;
using BlazorApp.Data;

namespace BlazorApp.Services
{
    public class EventRegistration : IEventRegistration
    {
        private readonly BlazorDBContext _dbContext;

        public EventRegistration(BlazorDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Data.EventRegistration> GetAllEventRegistration()
        {
            return _dbContext.eventRegistration.ToList();
        }
        public Data.EventRegistration FindById(Guid id)
        {
            return _dbContext.eventRegistration.Find(id);
        }

        public bool AddUpdateEventRegistration(Data.EventRegistration eventRegistration)
        {
            try
            {
                if (eventRegistration.Id != Guid.Empty)
                    _dbContext.eventRegistration.Update(eventRegistration);
                else
                    _dbContext.eventRegistration.Add(eventRegistration);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteEventRegistration(int productId)
        {
            var product = _dbContext.eventRegistration.Find(productId);
            if (product != null)
            {
                _dbContext.eventRegistration.Remove(product);
                _dbContext.SaveChanges();
            }
        }
        

    }
}
