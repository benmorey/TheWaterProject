using System.Runtime.CompilerServices;

namespace TheWaterProject.Models
{
    public class EWaterRepositorycs : IWaterRepository
    {
        private WaterProjectContext _context;
        public EWaterRepositorycs(WaterProjectContext temp) 
        { 
             _context = temp;
        }
        public new IQueryable<Project> Projects => _context.Projects;
    }
}
