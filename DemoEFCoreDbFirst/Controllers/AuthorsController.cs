using Common.FECore;
using Common.FECore.Models.DTOs;
using Common.FECore.Models;
using DemoEFCoreDbFirst.Entities;
using DemoEFCoreDbFirst.Entities.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoEFCoreDbFirst.UnitOffWorks;
using Microsoft.IdentityModel.Tokens;

namespace DemoEFCoreDbFirst.Controllers
{
    public class AuthorsController : ControllerBase
    {
        private readonly DemoDbContext _dbContext;
        private readonly IUnitOffWork<DemoDbContext> _unitOffWork;
        public AuthorsController(DemoDbContext dbContext, IUnitOffWork<DemoDbContext> unitOffWork)
        {
            _dbContext = dbContext;
            _unitOffWork = unitOffWork;
        }

        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            return Ok(await _dbContext.Authors.ToListAsync());
        }
        public async Task<ActionResult<IBasePaging<Author>>> GetPaging(FilterBodyRequest request)
        {
            var query = _unitOffWork.Repository<Author, Guid>().GetNoTrackingEntities();

            if (!request.SearchValue.IsNullOrEmpty())
            {
                query = query.Where(e => e.Name!.Contains(request.SearchValue ?? ""));
            }
            var result = await query.ToPagingAsync(request);
            return Ok(result);
        }
    }
}
