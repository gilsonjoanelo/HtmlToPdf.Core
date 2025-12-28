namespace HtmlToPdf.Core
{
    public sealed class PdfHeader
    {
        /// <summary>
        /// HTML para cabeçalho
        /// </summary>
        public string? HeaderHtml { get; set; }

        /// <summary>
        /// Texto à esquerda no cabeçalho
        /// </summary>
        public string? HeaderLeft { get; set; }

        /// <summary>
        /// Texto central no cabeçalho
        /// </summary>
        public string? HeaderCenter { get; set; }

        /// <summary>
        /// Texto à direita no cabeçalho 
        /// </summary>
        public string? HeaderRight { get; set; }
    }
}
