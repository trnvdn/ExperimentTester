using ExperimentTester.DatabaseContext;

namespace ExperimentTester.Services
{
    public class BaseService
    {
        protected readonly ApplicationDbContext _context;
        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
