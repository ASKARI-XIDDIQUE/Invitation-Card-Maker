namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class StickerResponseDTO
    {
        public Guid GlobalId { get; set; }
        public bool Active { get; set; }
        public string Sticker { get; set; }
        public string? StickerStyle { get; set; }
    }
}
