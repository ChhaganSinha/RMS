
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using RMS.Dto;
using RMS.Client.Client;
using RMS.Dto.Dashboard;
using RMS.Dto.Auth;
using Microsoft.JSInterop;

namespace RMS.Client.Client
{
    public class AppClient : BaseHttpClient
    {
        public AppClient(ILogger<AppClient> logger, HttpClient httpClient) : base(logger, httpClient)
        {

        }

        #region Details
        public async Task<Details> GetDetailsById(int id)
        {
            Details details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/details/{id}");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<Details>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }
        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            IEnumerable<Details> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-details");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<Details>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<Details> UpsertDetailsAsync(Details details)
        {

            Details result = null;

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertDetails", details);

                res.EnsureSuccessStatusCode();

                result = await res.Content.ReadFromJsonAsync<Details>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return result;

        }
        #endregion

    }
}
