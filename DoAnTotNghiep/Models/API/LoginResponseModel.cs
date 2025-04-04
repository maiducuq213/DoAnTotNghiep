namespace DoAnTotNghiep.Models.API
{
    public class LoginResponseModel
    {
        public bool Success { get; set; }  // ✅ Trạng thái của API
        public string Message { get; set; }
        public string? UserName { get; set; } // ten tai khoan
        public string? AccessToken { get; set; } // chuoi token
        public int ExpiresIn { get; set; } // thoi gian hieu luc cua token
    }
}
