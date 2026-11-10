using Microsoft.AspNetCore.Components.Forms;

namespace user_interface_private_web.Entities
{
    public class UploadComment
    {
        public string Text { get; set; } = string.Empty;

        public IBrowserFile? BrowserFile { get; set; } = null;

        public List<NotificationTo> Recipients { get; set; } = new(); 
    }
}
