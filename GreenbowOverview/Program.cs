
using Newtonsoft.Json;
using System.Net.Http.Headers;

string accessToken = "Enter Greenbow api key"; // Ensure to replace with actual access token

List<Transaction> allData = new List<Transaction>();
string apiEndpoint = "https://api.greenbow.dk/v1/me/chargers/9a53d6f1-fc80-4deb-93c7-31eca4349d8a/sessions";

using (HttpClient httpClient = new HttpClient())
{
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    while (!string.IsNullOrEmpty(apiEndpoint))
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

                allData.AddRange(apiResponse.Data);
                apiEndpoint = apiResponse.Links?.Next;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            break;
        }
    }
}

var groupedData = allData
    .GroupBy(x => new { x.started_by_extra, x.started_at.Month, x.started_at.Year })
    .Select(x => new
    {
        x.Key.started_by_extra,
        x.Key.Month,
        x.Key.Year,
        amount_total = x.Sum(y => decimal.Parse(y.amount_base)),
        transactions = x.Count()
    }).ToList();

foreach (var group in groupedData)
{
    Console.WriteLine($"{group.started_by_extra}: {group.amount_total / 100 :N2} for {group.Month}/{group.Year} (total transactions: {group.transactions}" );
}
