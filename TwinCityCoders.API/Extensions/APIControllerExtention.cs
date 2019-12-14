using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace TwinCityCoders.API.Extensions
{
    public abstract class APIControllerExtention : ControllerBase
    { 
        [NonAction]
        public HeaderData GetProfile()
        {
            string response = Request.Headers["Authorization"];
            response = response.Replace("Bearer ", "");
            var res = GetTokenData(response);
            HeaderData header = new HeaderData()
            {
                Role = res["role"],
                Name = res["unique_name"],
                UserId = Convert.ToInt32(res["nameid"]),
                AssociatedId = Convert.ToInt32(res["groupsid"])
            };
            return header;
        }

        public static Dictionary<string, string> GetTokenData(string tokenHeader)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtInput = tokenHeader;
            var readableToken = jwtHandler.CanReadToken(jwtInput);
            Dictionary<string, string> headerData = new Dictionary<string, string>();

            if (readableToken == true)
            {
                var token = jwtHandler.ReadJwtToken(jwtInput);
                var claims = token.Claims;

                foreach (Claim c in claims)
                {
                    headerData.Add(c.Type, c.Value);
                }
            }
            return headerData;
        }

    }
    public class HeaderData
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int AssociatedId { get; set; }
    }
}
