namespace user_interface_public_web.Entities
{
    public class NotificationTo
    {
        public string? UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? OrganizationId { get; set; }

        public bool Added { get; set; }

        public bool Checked { get; set; }
    }
}
