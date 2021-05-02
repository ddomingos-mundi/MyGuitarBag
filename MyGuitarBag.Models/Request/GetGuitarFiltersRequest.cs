using WebApi.Models.Request;

namespace MyGuitarBag.Models.Request
{
    public class GetGuitarFiltersRequest : ListRequest
    {
        public string Color { get; set; }
        public string Model { get; set; }
    }
}
