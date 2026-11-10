using System.Net;

namespace user_interface_private_web.Entities
{
    public class UploadFile : StreamContent
    {
        private readonly Stream _fileStream;
        private readonly int _maxBuffer = 1024 * 4;

        public UploadFile(Stream stream, int maxBuffer, Action<long, double> onProgress) : base(stream)
        {
            _fileStream = stream;
            _maxBuffer = maxBuffer;
            OnProgress += onProgress;
        }

        /// <summary>
        /// Event that we can subscribe to which will be triggered everytime after part of the file gets uploaded.
        /// It passes the total amount of uploaded bytes and the percentage as well
        /// </summary>
        public event Action<long, double> OnProgress;

        // Override the SerialzeToStreamAsync method which provides us with the stream that we can write our chunks into it
        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            var buffer = new byte[_maxBuffer];
            long totalLength = _fileStream.Length;
            long uploaded = 0;

            while (true)
            {
                using (_fileStream)
                {
                    int length = await _fileStream.ReadAsync(buffer, 0, _maxBuffer);

                    if (length <= 0)
                    {
                        break;
                    }

                    uploaded += length;

                    double percentage = Convert.ToDouble(uploaded * 100 / _fileStream.Length);

                    await stream.WriteAsync(buffer);

                    OnProgress?.Invoke(uploaded, percentage);

                    await Task.Delay(250);
                }
            }
        }

    }

}
