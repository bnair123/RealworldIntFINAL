using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace RealworldIntFINAL;

public class BrandfetchAPI
{
    private static readonly HttpClient client = new HttpClient();
    private string apiKey = "ojBr7P0+LwuO/XZNopma6Dudv8OVnZSX+Ttv5edp/60=";

    public BrandfetchAPI()
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<BrandInfoResult> GetBrandInfo(string brandName)
    {
        var searchResult = await SearchBrand(brandName);
        if (searchResult == null || searchResult.Count == 0)
        {
            return null;
        }

        var brandDomain = searchResult[0].domain;
        var brandInfoUrl = $"https://api.brandfetch.io/v2/brands/{brandDomain}";
        var brandInfoResponse = await client.GetAsync(brandInfoUrl);
        brandInfoResponse.EnsureSuccessStatusCode();
        var brandInfoJson = await brandInfoResponse.Content.ReadAsStringAsync();
        var brandInfo = JsonSerializer.Deserialize<BrandInfoResult>(brandInfoJson);

        return brandInfo;
    }

    private async Task<List<BrandSearchResult>> SearchBrand(string brandName)
    {
        var searchUrl = $"https://api.brandfetch.io/v2/search/{brandName}";
        var searchResponse = await client.GetAsync(searchUrl);
        searchResponse.EnsureSuccessStatusCode();
        var searchJson = await searchResponse.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<List<BrandSearchResult>>(searchJson);

        return searchResult;
    }
}
/*
 * Example Implementation:
 * var brandfetchAPI = new BrandfetchAPI();
        var brandInfo = await brandfetchAPI.GetBrandInfo("Microsoft");

        if (brandInfo != null)
        {
            Console.WriteLine($"Brand Name: {brandInfo.name}");
            Console.WriteLine($"Domain: {brandInfo.domain}");
            Console.WriteLine($"Claimed: {brandInfo.claimed}");
            Console.WriteLine($"Description: {brandInfo.description}");

            Console.WriteLine("\nLinks:");
            foreach (var link in brandInfo.links)
            {
                Console.WriteLine($"- {link.name}: {link.url}");
            }

            Console.WriteLine("\nLogos:");
            foreach (var logo in brandInfo.logos)
            {
                Console.WriteLine($"- Theme: {logo.theme}, Type: {logo.type}");
                foreach (var format in logo.formats)
                {
                    Console.WriteLine($"  - Format: {format.format}, Src: {format.src}");
                }
            }
*/