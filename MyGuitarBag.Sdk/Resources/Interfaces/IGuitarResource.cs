using MyGuitarBag.Models.Request;
using MyGuitarBag.Models.Response;
using RestSharp.Easy.Models;
using System;

namespace MyGuitarBag.Sdk.Resources.Interfaces
{
    public interface IGuitarResource
    {
        BaseResponse<GetGuitarResponse, object> CreateGuitar(PostGuitarRequest request);
        BaseResponse<object, object> DeleteGuitar(Guid id);
        BaseResponse<GetGuitarListResponse, object> GetGuitar(GetGuitarFiltersRequest request);
        BaseResponse<GetGuitarResponse, object> GetGuitar(Guid id);

    }
}
