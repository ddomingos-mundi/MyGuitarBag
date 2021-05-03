using MyGuitarBag.Models.Request;
using MyGuitarBag.Models.Response;
using MyGuitarBag.Sdk.Resources.Interfaces;
using RestSharp.Easy.Interfaces;
using RestSharp.Easy.Models;
using System;
using System.Net.Http;

namespace MyGuitarBag.Sdk.Resources
{
    public class GuitarResource : IGuitarResource
    {
        private readonly IEasyRestClient RestClient;

        public GuitarResource(IEasyRestClient restClient)
        {
            RestClient = restClient;
        }

        public BaseResponse<GetGuitarResponse, object> CreateGuitar(PostGuitarRequest request)
        {
            var method = HttpMethod.Post;
            return this.RestClient.SendRequest<GetGuitarResponse, object>(method, "guitars", request);
        }

        public BaseResponse<object, object> DeleteGuitar(Guid id)
        {
            var method = HttpMethod.Delete;
            return this.RestClient.SendRequest<object, object>(method, $"guitars/{id}");
        }

        public BaseResponse<GetGuitarListResponse, object> GetGuitar(GetGuitarFiltersRequest request)
        {
            var method = HttpMethod.Get;
            var endpoint = $"guitars";

            return this.RestClient.SendRequest<GetGuitarListResponse, object>(method, endpoint, query: request?.GetQuery());
        }

        public BaseResponse<GetGuitarResponse, object> GetGuitar(Guid id)
        {
            var method = HttpMethod.Get;
            return this.RestClient.SendRequest<GetGuitarResponse, object>(method, $"guitars/{id}");
        }
    }
}
