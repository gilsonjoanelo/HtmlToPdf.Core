namespace HtmlToPdf.Core.Enums
{
    public class PageMargins
    {
        /// <summary>
        /// Margem superior (Em milímetros)
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Margem direita  (Em milímetros)
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Margem inferior (Em milímetros)
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Margem esquerda (Em milímetros)
        /// </summary>
        public int Left { get; set; }

        public PageMargins(int top = 10, int right = 10, int bottom = 10, int left = 10)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
    }
}
