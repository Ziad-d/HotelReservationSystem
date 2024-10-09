﻿using HotelReservationSystem.Constants;
using HotelReservationSystem.DTOs.UserDTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservationSystem.Helpers
{
    public class TokenGenerator
    {
        public static string GenerateToken(UserForTokenDTO userDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Key);

            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.Id, userDTO.Id.ToString()),
                new Claim(CustomClaimTypes.UserName, userDTO.UserName),
                new Claim(CustomClaimTypes.Email, userDTO.EmailAddress)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.DurationInMinutes),
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
