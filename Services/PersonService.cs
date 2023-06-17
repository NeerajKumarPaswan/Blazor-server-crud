using BlazorCrud.Models;

namespace BlazorCrud.Services
{
    public class PersonService : IPersonService
    {

        private readonly DatabaseContext _ctx;

        public PersonService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public bool AddUpdate(Person person)
        {
            try
            {
                if(person.Id == 0) {
                    _ctx.Person.Add(person);
                    _ctx.SaveChanges();
                }
                else
                {
                    _ctx.Person.Update(person);
                    _ctx.SaveChanges();
                }

                return true;
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                   var person = FindById(id);
                if(person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                {
                   
                    return false;
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

#pragma warning disable CS8603 // Possible null reference return.
        public Person FindById(int id) => _ctx.Person.Find(id);
#pragma warning restore CS8603 // Possible null reference return.

        public List<Person> GetAll()
        {
            return _ctx.Person.ToList();
        }
    }
}
