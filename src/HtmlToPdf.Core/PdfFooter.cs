namespace HtmlToPdf.Core
{
    public sealed class PdfFooter
    {
        /// <summary>
        /// HTML para rodapé
        /// </summary>
        public string? FooterHtml { get; set; }

        /// <summary>
        /// Texto à esquerda no rodapé
        /// </summary>
        public string? FooterLeft { get; set; }

        /// <summary>
        /// Texto central no rodapé
        /// </summary>
        public string? FooterCenter { get; set; }

        /// <summary>
        /// Texto à direita no rodapé
        /// </summary>
        public string? FooterRight { get; set; }
    }
}
