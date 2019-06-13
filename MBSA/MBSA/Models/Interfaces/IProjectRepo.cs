using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBSA.Models.Interfaces
{
   public interface IProjectRepo
    {
        List<Project> GetProjects(int pageSize, int pageNumber);
        int GetTotalCount();
    }
}
