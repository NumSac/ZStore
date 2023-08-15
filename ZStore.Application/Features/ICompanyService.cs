using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.DTOs;
using ZStore.Domain.Utils;

namespace ZStore.Application.Features
{
    public interface ICompanyService
    {
        Task<Response<string>> EditCompany(int id, EditCompanyRequest request);
        Task<Response<CompanyDTO>> GetCompany(int id);
        Task<Response<string>> RegisterCompany(RegisterCompanyRequest request);
    }
}
