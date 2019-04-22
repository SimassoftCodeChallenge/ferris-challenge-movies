using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Ferris.Challenge.Movies.Infra.Common
{
    public static class Utils
    {
        public static object SerializeToJson(string json, object objectInput)
        {
            var dto = Activator.CreateInstance(objectInput.GetType());
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)); 
            DataContractJsonSerializer ser = new DataContractJsonSerializer(dto.GetType());  
            dto = ser.ReadObject(ms);
            ms.Close();
            return dto;
        }        
    }
}