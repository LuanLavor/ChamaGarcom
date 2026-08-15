using ChamaGarcom.Data;
using ChamaGarcom.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;

namespace ChamaGarcom.Pages;

public class QRCodesModel : PageModel
{
    private readonly AppDbContext _context;

    public List<MesaQR> Mesas { get; set; } = new List<MesaQR>();

    public QRCodesModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        var tables = _context.RestaurantTables.ToList();

        foreach (var table in tables)
        {
            var url = $"http://192.168.1.14:5035/Call?tableId={table.Id}";

            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrData);
            var qrBytes = qrCode.GetGraphic(20);
            var qrBase64 = Convert.ToBase64String(qrBytes);

            Mesas.Add(new MesaQR
            {
                TableId = table.Id,
                Number = table.Number,
                QRCodeBase64 = qrBase64
            });
        }
    }
}

public class MesaQR
{
    public int TableId { get; set; }
    public int Number { get; set; }
    public string QRCodeBase64 { get; set; } = "";
}
