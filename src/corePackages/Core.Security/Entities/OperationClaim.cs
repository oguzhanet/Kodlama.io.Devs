using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        public OperationClaim()
        {

        }
        public OperationClaim(string name, int id, bool isActive) : base(id)
        {
            Name = name;
        }
    }
}
