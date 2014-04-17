using FluentNHibernate.Data;

namespace RestauranteMobile.Models
{
    public class ModelBase <T>
    {
        public T Entity { get; set; }

    }
}