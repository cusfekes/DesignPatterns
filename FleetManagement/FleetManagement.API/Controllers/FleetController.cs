using FleetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FleetController : Controller
    {
        [HttpGet(template: "GetAllPackage", Name = "AllPackage")]
        public IEnumerable<PackageModel> GetAllPackage()
        {
            return Enumerable.Range(1, 5).Select(index => new PackageModel
            {
                Barcode = "P7988000121",
                Desi = 5
            })
            .ToArray();
        }

        [HttpGet(template: "GetPackageByBarcode", Name = "PackageByBarcode")]
        public IEnumerable<PackageModel> GetPackageByBarcode(string barcode)
        {
            return Enumerable.Range(1, 5).Select(index => new PackageModel
            {
                Barcode = "P79880001212",
                Desi = 25
            })
            .ToArray();
        }
    }
}
