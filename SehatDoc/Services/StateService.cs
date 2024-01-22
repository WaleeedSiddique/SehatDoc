using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorModels;
using SehatDoc.Interfaces;
using SehatDoc.Models;

namespace SehatDoc.Services
{
    public class StateService: IStateInterface
    {
        private readonly AppDbContext _context;

        public StateService(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<State> GetAllState()
        {
            var state = _context.states.ToList();
            return state;
        }
        public State AddState(State state)
        {
            var states = _context.states.Add(state);
            _context.SaveChanges();
            return state;
        }
        public State GetState(int id)
        {
            var state = _context.states.FirstOrDefault(x => x.Id == id);
            return state;
        }
        public State UpdateState(State state)
        {
            var states = _context.states.Attach(state);
            states.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return state;
        }
        public void DeleteState(int id)
        {
            var state = _context.states.FirstOrDefault(x => x.Id == id);
            if (state != null)
            {
                _context.states.Remove(state);
                _context.SaveChanges();
            }
        }
    }
}
