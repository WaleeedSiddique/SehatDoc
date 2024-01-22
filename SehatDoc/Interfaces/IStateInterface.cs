using SehatDoc.Models;

namespace SehatDoc.Interfaces
{
    public interface IStateInterface
    {
        public IEnumerable<State> GetAllState();
        public State AddState(State state);
        public State GetState(int id);
        public void DeleteState(int id);
        public State UpdateState(State state);
    }
}
