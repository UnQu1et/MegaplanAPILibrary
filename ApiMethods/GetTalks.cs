using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MegaplanAPILibrary.Base;
using MegaplanAPILibrary.ApiClasses;

namespace MegaplanAPILibrary.ApiMethods
{
    public class GetTalks : BaseRequestResponse<GetTalksRequest, GetTalksResponse, GetTalksRequest.Params>
    {
    }
    public class GetTalksRequest : BaseRequest<GetTalksRequest.Params>
    {
        public override string Uri { get { return "/BumsCommonApiV01/Message/list.api"; } }
        public override string HTTPMethod { get { return "GET"; } }
        public class Params
        {
            public string Folder { get; set; }
            public bool FavoritesOnly { get; set; }
            public string DateFrom { get; set; }
            public string DateTo { get; set; }
            public int Limit { get; set; }
            public string TimeUpdated { get; set; }
            public int Offset { get; set; }
        }
    }
    public class GetTalksResponse : BaseResponse
    {
        public GetTalksResponseData data { get; set; }
    }

    public class GetTalksResponseData
    {
        public Talk[] messages { get; set; }
    }
}
