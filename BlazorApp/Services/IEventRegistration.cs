using BlazorApp.Data;
using System;

namespace BlazorApp.Services
{
    public interface IEventRegistration
    {
        List<Data.EventRegistration> GetAllEventRegistration();
        bool AddUpdateEventRegistration(Data.EventRegistration eventRegistration);
        Data.EventRegistration FindById(Guid id);
        void DeleteEventRegistration(int eventRegistrationId);
    }
}
