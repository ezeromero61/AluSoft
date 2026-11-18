using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AluSoft.UI
{
    internal static class TemaMenus
    {
        private static readonly Color Azul = Color.FromArgb(8, 46, 75);
        private static readonly Color Turquesa = Color.FromArgb(0, 167, 184);
        private static readonly Color Suave = Color.FromArgb(232, 247, 249);

        internal static void Aplicar(Form ventana, ToolStrip barra, Panel contenido, string perfil)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer(new ColoresMenu());
            renderer.RoundedEdges = false;
            barra.Renderer = renderer;
            foreach (ToolStripItem item in barra.Items)
                EstilizarOpcion(item, renderer, true);

            ComponentResourceManager recursos = new ComponentResourceManager(ventana.GetType());
            Image recurso = recursos.GetObject("AluSoft.FondoBienvenida") as Image;
            Image ilustracion = recurso == null ? null : (Image)recurso.Clone();
            contenido.Paint += delegate(object sender, PaintEventArgs e)
            {
                if (contenido.Controls.Count == 0)
                    DibujarBienvenida(e.Graphics, contenido.ClientRectangle, perfil, ilustracion);
            };
            contenido.Resize += delegate { contenido.Invalidate(); };
            contenido.ControlRemoved += delegate { contenido.Invalidate(); };
            ventana.Disposed += delegate { if (ilustracion != null) ilustracion.Dispose(); };
            contenido.Invalidate();
        }

        private static void EstilizarOpcion(ToolStripItem item, ToolStripRenderer renderer, bool principal)
        {
            item.ForeColor = Azul;
            item.BackColor = Color.White;
            item.Padding = principal ? new Padding(14, 8, 14, 8) : new Padding(8, 5, 8, 5);
            item.Margin = principal ? new Padding(3, 1, 3, 1) : Padding.Empty;
            ToolStripDropDownItem menu = item as ToolStripDropDownItem;
            if (menu == null) return;
            menu.DropDown.Renderer = renderer;
            menu.DropDown.BackColor = Color.White;
            menu.DropDown.Font = item.Font;
            foreach (ToolStripItem hijo in menu.DropDownItems)
                EstilizarOpcion(hijo, renderer, false);
        }

        private static void DibujarBienvenida(Graphics g, Rectangle area, string perfil, Image imagen)
        {
            if (area.Width <= 0 || area.Height <= 0) return;
            float escala = g.DpiX / 96f;
            int margen = (int)(48 * escala);
            int anchoArte = (int)(area.Width * 0.32f);
            Rectangle arte = new Rectangle(area.Right - anchoArte, area.Top, anchoArte, area.Height);
            g.Clear(Color.FromArgb(246, 248, 251));
            using (SolidBrush fondo = new SolidBrush(Azul)) g.FillRectangle(fondo, arte);
            if (imagen != null && arte.Width > 0 && arte.Height > 0)
            {
                float factor = Math.Max((float)arte.Width / imagen.Width, (float)arte.Height / imagen.Height);
                float anchoOrigen = arte.Width / factor;
                float altoOrigen = arte.Height / factor;
                RectangleF origen = new RectangleF((imagen.Width - anchoOrigen) / 2,
                    (imagen.Height - altoOrigen) / 2, anchoOrigen, altoOrigen);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagen, arte, origen, GraphicsUnit.Pixel);
            }
            int anchoTexto = Math.Max(1, arte.Left - margen * 2);
            int y = Math.Max(margen, (area.Height - (int)(240 * escala)) / 2);
            using (SolidBrush acento = new SolidBrush(Turquesa))
                g.FillRectangle(acento, margen, y, (int)(54 * escala), (int)(5 * escala));
            using (Font titulo = new Font("Segoe UI", 30, FontStyle.Bold))
            using (Font subtitulo = new Font("Segoe UI", 16, FontStyle.Regular))
            using (Font texto = new Font("Segoe UI", 11, FontStyle.Regular))
            {
                TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.NoPadding;
                TextRenderer.DrawText(g, "Bienvenido a AluSoft", titulo,
                    new Rectangle(margen, y + (int)(25 * escala), anchoTexto, (int)(104 * escala)), Azul, flags);
                TextRenderer.DrawText(g, "Perfil " + perfil, subtitulo,
                    new Rectangle(margen, y + (int)(140 * escala), anchoTexto, (int)(40 * escala)), Azul, flags);
                TextRenderer.DrawText(g, "Seleccioná una opción del menú superior\npara comenzar a trabajar.", texto,
                    new Rectangle(margen, y + (int)(193 * escala), anchoTexto, (int)(72 * escala)),
                    Color.FromArgb(93, 111, 132), flags);
            }
        }

        private sealed class ColoresMenu : ProfessionalColorTable
        {
            public ColoresMenu() { UseSystemColors = false; }
            public override Color ToolStripGradientBegin { get { return Color.White; } }
            public override Color ToolStripGradientMiddle { get { return Color.White; } }
            public override Color ToolStripGradientEnd { get { return Color.White; } }
            public override Color ToolStripDropDownBackground { get { return Color.White; } }
            public override Color ImageMarginGradientBegin { get { return Color.White; } }
            public override Color ImageMarginGradientMiddle { get { return Color.White; } }
            public override Color ImageMarginGradientEnd { get { return Color.White; } }
            public override Color MenuItemSelected { get { return Suave; } }
            public override Color MenuItemBorder { get { return Turquesa; } }
            public override Color MenuBorder { get { return Color.FromArgb(218, 228, 235); } }
            public override Color ToolStripBorder { get { return Color.FromArgb(218, 228, 235); } }
            public override Color MenuItemSelectedGradientBegin { get { return Suave; } }
            public override Color MenuItemSelectedGradientEnd { get { return Suave; } }
            public override Color MenuItemPressedGradientBegin { get { return Suave; } }
            public override Color MenuItemPressedGradientMiddle { get { return Suave; } }
            public override Color MenuItemPressedGradientEnd { get { return Suave; } }
            public override Color ButtonSelectedGradientBegin { get { return Suave; } }
            public override Color ButtonSelectedGradientMiddle { get { return Suave; } }
            public override Color ButtonSelectedGradientEnd { get { return Suave; } }
            public override Color ButtonSelectedBorder { get { return Turquesa; } }
            public override Color ButtonPressedGradientBegin { get { return Suave; } }
            public override Color ButtonPressedGradientMiddle { get { return Suave; } }
            public override Color ButtonPressedGradientEnd { get { return Suave; } }
            public override Color ButtonPressedBorder { get { return Turquesa; } }
        }
    }
}
