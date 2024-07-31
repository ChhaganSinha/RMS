using RMS.DataContext;
using RMS.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using RMS.Server.Intrastructure.ActionFilters;

namespace RMS.Server.Controllers.Api.OData
{

    public class RoomCleaningAssignmentModelController : ODataController
    {
        public ILogger<RoomCleaningAssignmentModelController> Logger { get; }
        public AppDbContext DbContext { get; }
        public RoomCleaningAssignmentModelController(ILogger<RoomCleaningAssignmentModelController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<RoomCleaningAssignmentModel> Get()
        {
            //  var data = DbContext.RoomCleaningAssignmentModel.AsQueryable();

            var data = from assignment in DbContext.RoomCleaningAssignmentModel
                       from room in assignment.SelectedRooms
                       select new RoomCleaningAssignmentModel
                       {
                           Id = assignment.Id,
                          // HouseKeeperId = assignment.HouseKeeperId,
                           HouseKeeper = assignment.HouseKeeper,
                           RoomNo = room.RoomNo,
                           RoomType = assignment.RoomType,
                           Status = room.Status,
                           IsSelected = room.IsSelected,
                           StartDate = room.StartDate,
                           EndDate = room.EndDate
                       };


            return data.AsQueryable();
        }
    }
}
