using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using StationDesktop.Windows;
using System.Windows.Controls;

namespace StationDesktop.Services
{
    public class CreatePDFReport
    {
        Grid mainGrid;
        public CreatePDFReport(Grid grid)
        {
            this.mainGrid = grid;
            CreateFixedDocument();
            
        }

        private void CreateFixedDocument()
        {
            if (mainGrid.Parent != null)
            {
                
            }
            var fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new System.Windows.Size(96 * 8.5, 96 * 11);
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            fixedPage.Children.Add(mainGrid);
            fixedDocument.Pages.Add(pageContent);
            ((IAddChild)pageContent).AddChild(fixedPage);
            Document document = new Document(PageSize.LETTER, 0f, 0f, 0f, 0f);
            PdfWriter.GetInstance(document, new FileStream("C:\\myfile.pdf", FileMode.Create));
            document.Open();
            DocumentPaginator paginator = fixedDocument.DocumentPaginator;
            for (int i = 0; i < paginator.PageCount; i++)
            {
                Visual visual = paginator.GetPage(i).Visual;

                string targetFile = Path.GetTempFileName();

                using(FileStream fs = new FileStream(targetFile, FileMode.Create))
                {
                    CreateBitmapFromVisual(visual, targetFile);
                }
                using (FileStream fs = new FileStream(targetFile, FileMode.Open))
                {
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), System.Drawing.Imaging.ImageFormat.Png);
                    png.ScalePercent(24f);
                    document.Add(png);
                }
            }
            document.Close();
        }
        public static void CreateBitmapFromVisual(Visual target, string fileName)
        {
            var bounds = VisualTreeHelper.GetDescendantBounds(target);
            var renderTarget = new RenderTargetBitmap(
                (int)bounds.Width,
                (int)bounds.Height,
                96,
                96,
                PixelFormats.Pbgra32);

            var visual = new DrawingVisual();

            using (var context = visual.RenderOpen())
            {
                var visualBrush = new VisualBrush(target);
                context.DrawRectangle(visualBrush, null, new Rect(new System.Windows.Point(), bounds.Size));
            }

            renderTarget.Render(visual);
            var bitmapEncoder = new BmpBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            using (var stm = File.Create(fileName))
                bitmapEncoder.Save(stm);
        }
    }
}
