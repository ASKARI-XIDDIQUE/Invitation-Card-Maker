namespace Invitation_Card_Maker.Models
{
    public class Stickers:BaseClass
    {
        public  string Sticker { get; set; }
        public string?  StickerStyle { get; set; }
        public ICollection<TemplateStickers>? TemplateStickers { get; set; }


    }
}
