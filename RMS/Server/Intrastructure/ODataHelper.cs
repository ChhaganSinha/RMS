
namespace RMS.Server.Intrastructure
{
 
    using Microsoft.AspNetCore.OData;
    using Microsoft.OData.Edm;
    using Microsoft.OData.ModelBuilder;
    using Microsoft.AspNetCore.Authorization;
    using RMS.Dto;
  

    public static class ODataHelper
    {
        public static IMvcBuilder AddODataControllers(this IMvcBuilder builder)
        {
            return builder.AddOData(option =>
            {
                option.Select();
                option.Expand();
                option.Filter();
                option.OrderBy();
                option.Count();
                option.SetMaxTop(100);
                option.SkipToken();
                option.AddRouteComponents("Odata", GetModel());
            });
        }
        [Authorize]
        private static IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Details>("Details");
            builder.EntitySet<RoomCategories>("RoomCategories");
            builder.EntitySet<RoomFacilities>("RoomFacilities");
            builder.EntitySet<Room>("Room");

            return builder.GetEdmModel();
        }
    }

    
}
