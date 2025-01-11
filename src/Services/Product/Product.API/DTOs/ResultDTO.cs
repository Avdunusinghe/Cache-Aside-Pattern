namespace Product.API.DTOs
{
    public class ResultDTO
    {
        internal ResultDTO(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        internal ResultDTO(bool succeeded, string successMessage, string id = null, string data = null)
        {
            Succeeded = succeeded;
            SuccessMessage = successMessage;
            Id = id;
            Data = data;
        }

        public string Id { get; set; }
        public bool Succeeded { get; set; }
        public string SuccessMessage { get; set; }
        public string Data { get; set; }
        public string[] Errors { get; set; }

        public static ResultDTO Success(string messeage, string id = null, string data = null)
        {
            return new ResultDTO(true, messeage, id, data);
        }

        public static ResultDTO Failure(IEnumerable<string> errors)
        {
            return new ResultDTO(false, errors);
        }
    }
}
