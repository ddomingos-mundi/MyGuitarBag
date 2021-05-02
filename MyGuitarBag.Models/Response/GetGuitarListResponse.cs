using System.Collections.Generic;
using WebApi.Models.Response;

namespace MyGuitarBag.Models.Response
{
    public class GetGuitarListResponse : ListResponse<GetGuitarResponse>
    {
        public GetGuitarListResponse(){}

        public GetGuitarListResponse(List<GetGuitarResponse> items, int page = 1, int size = 10, long totalItems = 0) 
            : base(items, page, size, totalItems)
        {

        }
    }
}
