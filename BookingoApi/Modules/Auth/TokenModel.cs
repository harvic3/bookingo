using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.Auth
{
    public partial class TokenModel
    {
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public long ExpirationTimeSeconds { get; set; }
        public long IssuedAtTimeSeconds { get; set; }
        public string Uid { get; set; }
        public IReadOnlyDictionary<string, object> Claims { get; set; }
    }
}