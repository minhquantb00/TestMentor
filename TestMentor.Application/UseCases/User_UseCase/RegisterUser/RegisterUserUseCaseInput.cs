using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestMentor.Domain.EnumeratesConstants;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = System.Text.Json.Serialization.JsonConverterAttribute;

namespace TestMentor.Application.UseCases.User_UseCase.RegisterUser
{
    public class RegisterUserUseCaseInput
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Enumerates.Gender Gender { get; set; }
    }
}
