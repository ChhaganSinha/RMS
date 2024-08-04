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
            var data = DbContext.ReservationDetails
                .Select(assignment => new ReservationDetailsDto
                {
                    Id = assignment.Id,
                    BookingReferenceNo = assignment.BookingReferenceNo,
                    RoomNos = string.Join(", ", assignment.RoomBookings.Select(rb => rb.RoomNo)),
                    CheckIn = assignment.CheckIn,
                    CheckOut = assignment.CheckOut,
                    ArrivalFrom = assignment.ArrivalFrom,
                    BookingType = assignment.BookingType,
                    PurposeOfVisit = assignment.PurposeOfVisit,
                    Remarks = assignment.Remarks,
                    Status = assignment.Status,
                    RoomBookings = assignment.RoomBookings.Select(rb => new RoomBookingDto
                    {
                        RoomType = rb.RoomType,
                        RoomId = rb.RoomId,
                        RoomNo = rb.RoomNo,
                        Adults = rb.Adults,
                        Children = rb.Children
                    }).ToList(),
                    CustomerInfo = assignment.CustomerInfo.Select(ci => new CustomerInfoDto
                    {
                        SL = ci.SL,
                        Name = ci.Name,
                        MobileNo = ci.MobileNo,
                        Email = ci.Email
                    }).ToList(),
                    PaymentDetails = new PaymentDetailsDto
                    {
                        DiscountReason = assignment.PaymentDetails.DiscountReason,
                        DiscountRate = assignment.PaymentDetails.DiscountRate,
                        DiscountAmount = assignment.PaymentDetails.DiscountAmount,
                        CommissionRate = assignment.PaymentDetails.CommissionRate,
                        CommissionAmount = assignment.PaymentDetails.CommissionAmount
                    },
                    BillingDetails = new BillingDetailsDto
                    {
                        BookingCharge = assignment.BillingDetails.BookingCharge,
                        Tax = assignment.BillingDetails.Tax,
                        ServiceCharge = assignment.BillingDetails.ServiceCharge,
                        TotalCharge = assignment.BillingDetails.TotalCharge
                    }
                });

            return data.AsQueryable();
        }

    }
}
