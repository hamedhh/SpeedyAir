using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Core
{
    public enum CityCode
    {
        YUL = 1,
        YYZ = 2,
        YYC = 3,
        YVR = 4,
        NA = 5
    }
    public static class CityCodeExtensions
    {
        public static CityCode ToCityCode(this string destination)
        {
            return destination switch
            {
                "YUL" => CityCode.YUL,
                "YYZ" => CityCode.YYZ,
                "YYC" => CityCode.YYC,
                "YVR" => CityCode.YVR,
                _ => CityCode.NA
            };
        }
    }
}
