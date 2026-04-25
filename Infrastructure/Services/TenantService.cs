using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
public class TenantService(IHttpContextAccessor httpContextAccessor) : ITenantService
    {
        public Guid? GetTenantId()
        {
            var claim = httpContextAccessor.HttpContext?.User?.FindFirst("tenantId")?.Value;
            return Guid.TryParse(claim, out var tenantId) ? tenantId : null;
        }
    }
}