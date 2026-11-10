namespace user_interface_public_web.Entities
{
    public class Comment
    {
        public bool Show { get; set; }

        public string Status { get; set; } = "info";

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public Comment(bool show, string status, string title, string message)
        {
            Show = show;
            Status = status;
            Title = title;
            Message = message;
        }

    }
}
