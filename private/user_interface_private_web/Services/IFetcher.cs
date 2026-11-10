using Microsoft.JSInterop;
using user_interface_private_web.Entities;

namespace user_interface_private_web.Services
{
    public interface IFetcher
    {
        Task<FetchAnswer> FetchAsync(string _url, byte[] _bytes, string _type);
    }

    public class Fetcher : IFetcher
    {
        private IJSRuntime _jsr;

        public Fetcher(IJSRuntime jsr)
        {
            _jsr = jsr;
        }

        public async Task<FetchAnswer> FetchAsync(string _url, byte[] _bytes, string _type)
        {
            FetchAnswer _answer = new();

            try
            {
                var dataReference =
                    _type.Equals("POST")
                        ? await _jsr.InvokeAsync<IJSStreamReference>("PostBytesAsync", _url, _bytes)
                        : await _jsr.InvokeAsync<IJSStreamReference>("GetBytesAsync", _url);

                using var dataReferenceStream =
                    await dataReference.OpenReadStreamAsync(maxAllowedSize: 10_000_000);

                using (MemoryStream ms = new MemoryStream())
                {
                    await dataReferenceStream.CopyToAsync(ms);
                    _answer.Message = ms.ToArray();
                    _answer.Code = 200;
                }
            }
            catch
            {
                _answer = new() { Code = 200, Message = new byte[0] };
            }

            return _answer;
        }
    }

}
