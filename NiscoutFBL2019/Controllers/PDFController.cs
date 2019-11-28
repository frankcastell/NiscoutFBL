using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp;
using iTextSharp.text;
using System.Web;
using iTextSharp.text.pdf;
using System.IO;
using NiscoutFBL2019.Models;
using System.Web.Mvc;
using BaseColor = iTextSharp.text.BaseColor;
using Font = iTextSharp.text.Font;

namespace NiscoutFBL2019.Reportes
{
    public class PDFController : Controller
    {
      private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();
        
        public ActionResult reportePDF()
        {
            MemoryStream ms = new MemoryStream();
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,30f,20f,50f,40f);          
            PdfWriter pw = PdfWriter.GetInstance(doc, ms);
            
            pw.PageEvent = new HeaderFooter();
            
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            Font fontText = new Font(bf, 12, 0, BaseColor.BLACK);
                    

            // Abrimos el archivo
            doc.Open();
            // Agregar logo superior
            Image logo = Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("~/Content/assets/images/Logov2.png"));
            logo.ScalePercent(100f);
            logo.SetAbsolutePosition(24f,700f);
            doc.Add(logo);
            doc.Add(Chunk.NEWLINE);

            // Agregar logo inferior
            Image inferior = Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("~/Content/assets/images/Logov2.png"));
            inferior.ScalePercent(100f);
            inferior.SetAbsolutePosition(0f,0f);
            doc.Add(inferior);
            doc.Add(Chunk.NEWLINE);


            //Descripción del nombre de asociacion de Scouts
            Phrase parrafo = new Phrase(string.Format("Asociación de Scouts de Nicaragua",fontText));
            //PdfContentByte cb = pw.DirectContent();
            //ColumnText ct = new ColumnText(cb);
            //ct.SetSimpleColumn(parrafo,312f,530f,762f,580f,25,Element.ALIGN_CENTER);
            //ct.Go();
            PdfPTable table = new PdfPTable(3);

            table.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clCodigo = new PdfPCell(new Phrase("Código"));
            
            PdfPCell clNom_Distrito = new PdfPCell(new Phrase("Nombre Distrito"));
           
            PdfPCell clDescripcion = new PdfPCell(new Phrase("Descripción"));
            

            // Añadimos las celdas a la tabla
            table.AddCell(clCodigo);
            table.AddCell(clNom_Distrito);
            table.AddCell(clDescripcion);

            List<Distrito> distritos = db.Distritos.ToList();
            foreach (var item in distritos)
            {
                PdfPCell cel = new PdfPCell();

                cel = new PdfPCell(new Paragraph(item.Cod_Distrito));
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cel);

                cel = new PdfPCell(new Paragraph(item.Nombre_Distrito));
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cel);

                cel = new PdfPCell(new Paragraph(item.Descripcion));
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cel);

            }
            doc.Add(table);
            doc.Close();

            byte[] bytestream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytestream,0,bytestream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");

        }

    }
    class HeaderFooter : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //base.OnEndPage(writer, document);
            PdfPTable tbHeader = new PdfPTable(3);
            tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbHeader.DefaultCell.Border = 0;

            tbHeader.AddCell(new Paragraph());
                        
            PdfPCell cel = new PdfPCell(new Paragraph("Lista de Distritos"));
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Border = 0;

            tbHeader.AddCell(cel);
            tbHeader.AddCell(new Paragraph());
            tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin)+40,writer.DirectContent);

            ///////////////////////////////////// tbFooter
            PdfPTable tbFooter = new PdfPTable(3);
            tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbFooter.DefaultCell.Border = 0;
            tbFooter.AddCell(new Paragraph());

            cel = new PdfPCell(new Paragraph("Ubicación de todos los distritos"));
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Border = 0;

            tbFooter.AddCell(cel);
            cel = new PdfPCell(new Paragraph("Página "+ writer.PageNumber));
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Border = 0;
            tbFooter.AddCell(cel);
            tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) + 40, writer.DirectContent);
        }
    }
}