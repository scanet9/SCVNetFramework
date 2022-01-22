namespace SqlApiBase.DataLayer.DataTransferObjects
{
    public class UpdateUserRequestDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
