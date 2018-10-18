using AMcom.Teste.DAL.Interfaces.Entidade.Base;
using Flunt.Notifications;
using Flunt.Validations;

namespace AMcom.Teste.DAL.Entidades.Base
{
    public class EntityBase : Notifiable, IEntityBase
    {
        public int Id { get; private set; }

        public void SetId(int id)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsLowerThan(0, id, "Id", "O campo identidade deve ser maior que zero."));

            if (Valid)
                Id = id;
        }
    }
}
