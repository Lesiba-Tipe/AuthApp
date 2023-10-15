
namespace AuthApp.Entity
{
    enum ApartmentType
    {
        Bachelor, Suite, Twin, Coutage,
    };
    public class Apartment
    {
        public string Id { get; set; }
        public int Number { get; set; }
        
    }
}
