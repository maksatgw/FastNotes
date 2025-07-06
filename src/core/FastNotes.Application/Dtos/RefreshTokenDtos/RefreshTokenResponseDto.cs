namespace FastNotes.Application.Dtos.RefreshTokenDtos
{
    /// <summary>
    /// Yenileme jetonu ile ilgili yanıt DTO'su.
    /// </summary>
    public class RefreshTokenResponseDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}