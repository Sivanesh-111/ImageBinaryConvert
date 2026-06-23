using ImageBinaryConvert.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageBinaryConvert.Services
{
    public class ImageService
    {
        private readonly AppDbContext _context;

        public ImageService(AppDbContext context)
        {
            _context = context;
        }

        // Download images from Blob URL and store binary
        public async Task DownloadImages()
        {
            string baseUrl = "https://acproductionstorage.blob.core.windows.net/email/logo/";

            using HttpClient client = new HttpClient();

            var customers = _context.Client.ToList();

            foreach (var customer in customers)
            {
                try
                {
                    string imageUrl = baseUrl + customer.EmailLogo;           

                    Console.WriteLine(imageUrl);

                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                    customer.BinaryData = imageBytes;

                    Console.WriteLine(customer.EmailLogo + " Downloaded");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(customer.EmailLogo + " : " + ex.Message);
                }
            }

            await _context.SaveChangesAsync();

            Console.WriteLine("All Images Saved Successfully.");
        }

        // Get image binary using Customer ID
        public byte[]? GetImage(short customerId)
        {
            var customer = _context.Client.FirstOrDefault(x => x.CustomerID == customerId);

            if (customer == null)
                return null;

            return customer.BinaryData;
        }
    }
}