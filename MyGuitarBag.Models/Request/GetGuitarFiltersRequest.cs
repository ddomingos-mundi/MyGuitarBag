using System.Collections.Generic;
using WebApi.Models.Request;

namespace MyGuitarBag.Models.Request
{
    public class GetGuitarFiltersRequest : ListRequest
    {
        public string Color { get; set; }
        public string Model { get; set; }

        public Dictionary<string, string> GetQuery()
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(this.Color))
            {
                query.Add("color", this.Color);
            }
            if (!string.IsNullOrEmpty(this.Model))
            {
                query.Add("model", this.Model);
            }

            query.Add("page", this.Page.ToString());
            query.Add("size", this.Size.ToString());

            return query;
        }
    }
}
