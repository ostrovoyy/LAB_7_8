using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IDistrictService
    {
        IEnumerable<DistrictDto> GetDistricts(int page);
    }
}
