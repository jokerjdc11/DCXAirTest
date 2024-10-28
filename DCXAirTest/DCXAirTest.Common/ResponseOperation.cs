namespace DCXAirTest.Common
{
    public class ResponseOperation<T>
    {
        public T Data { get; set; }

        public bool SuccessfulResult { get; set; }

        public string Message { get; set; }
    }
}
