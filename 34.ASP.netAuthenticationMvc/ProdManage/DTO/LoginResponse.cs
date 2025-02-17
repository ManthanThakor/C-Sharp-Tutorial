namespace ProdManage.DTO
{
    public class LoginResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
