using RMS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Repositories
{
    public interface IAppRepository
    {
        Task<Details> GetDetailsById(int id);
        Task<IEnumerable<Details>> GetAllDetails();
    }
}
