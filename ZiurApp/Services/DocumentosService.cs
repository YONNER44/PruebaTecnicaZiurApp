using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ZiurApp.Services
{
    public class Documento
    {
        public int Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool VActiva { get; set; }
    }

    public class DocumentosService
    {
        private readonly HttpClient _http;

        public DocumentosService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "ae8bad44-7348-11ee-b962-0242ac120002");
        }

        public async Task<List<Documento>> GetDocumentosAsync()
        {
            var response = await _http.GetFromJsonAsync<List<Documento>>(
                "https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos"
            );
            return response ?? new List<Documento>();
        }
    }
}
