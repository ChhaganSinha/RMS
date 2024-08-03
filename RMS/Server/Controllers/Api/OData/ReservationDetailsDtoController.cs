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
    [Authorize]
    public class ReservationDetailsDtoController : ODataController
    {
        public ILogger<ReservationDetailsDtoController> Logger { get; }
        public AppDbContext DbContext { get; }
        public ReservationDetailsDtoController(ILogger<ReservationDetailsDtoController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<ReservationDetailsDto> Get()
        {
            //return DbContext.ReservationDetails.AsQueryable();
            var data = from assignment in DbContext.ReservationDetails
                       from room in assignment.RoomBookings
                       select new ReservationDetailsDto
                       {
                           Id = assignment.Id,
                           BookingReferenceNo = assignment.BookingReferenceNo,
                           RoomNos = string.Join(", ", assignment.RoomBookings.Select(rb => rb.RoomNo)),
                           AcceptedCheckIn = assignment.AcceptedCheckIn,
                           AcceptedCheckOut = assignment.AcceptedCheckOut,  
                           CheckIn = assignment.CheckIn,
                           CheckOut = assignment.CheckOut,
                           ArrivalFrom = assignment.ArrivalFrom,
                           BookingType = assignment.BookingType,
                           PurposeOfVisit = assignment.PurposeOfVisit,
                           Remarks = assignment.Remarks,
                           Status = assignment.Status,
                           RoomBookings = assignment.RoomBookings,
                           CustomerInfo = assignment.CustomerInfo,
                           PaymentDetails = assignment.PaymentDetails,
                           BillingDetails = assignment.BillingDetails
                       };
            return data.AsQueryable();
        }
    }
}
